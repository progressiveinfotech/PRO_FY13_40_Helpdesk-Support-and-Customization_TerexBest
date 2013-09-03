using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;

public partial class Incident_SearchSolution : System.Web.UI.Page
{
    Solution_mst ObjSolution = new Solution_mst();
    Category_mst ObjCategory = new Category_mst();
    SolutionKeyword ObjSolutionKeyword = new SolutionKeyword();
    SolutionCreator Objsolutioncreator = new SolutionCreator();
    public int Solutionid;
    public int approvestatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        string solution = Convert.ToString(Request.QueryString[0]);
        BLLCollection<Solution_mst> col = new BLLCollection<Solution_mst>();

       
        if (solution == "")
        {
            col = ObjSolution.Get_All();

        }
        else
        {

            string kewords = solution;
            col = ObjSolution.Get_SearchSolution_All(kewords);

        }


        PagedDataSource pgitems = new PagedDataSource();

        pgitems.DataSource = col;
        pgitems.AllowPaging = true;
        pgitems.PageSize = 5;
        pgitems.CurrentPageIndex = PageNumber;
        if (pgitems.PageCount > 1)
        {
            rptPages.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i < pgitems.PageCount; i++)
                pages.Add((i + 1).ToString());
            rptPages.Visible = true;
            rptPages.DataSource = pages;

            rptPages.DataBind();

        }
        else


            rptPages.Visible = false;

        Repeter.DataSource = pgitems;
        Repeter.DataBind();


    }

    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }

    }

    public string ConvertHtmlToPlainText(string htmlText)
    {
        string temp;
        return Regex.Replace(htmlText, "<[^>]*>", string.Empty);

    }

    public void Repeter_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            int topicid;

            //topicid = Convert.ToInt16(DataBinder.Eval(e.Item.DataItem, "topicid"));
            Label topicidL = (Label)e.Item.FindControl("lbltopicid");
            topicid = Convert.ToInt16(topicidL.Text);
            ObjCategory = ObjCategory.Get_By_id(topicid);
            topicidL.Text = ObjCategory.CategoryName;
            topicidL.Visible = true;


        }
        else if (e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int topicid;

            //topicid = Convert.ToInt16(DataBinder.Eval(e.Item.DataItem, "topicid"));
            Label topicidL = (Label)e.Item.FindControl("lbltopicid");
            topicid = Convert.ToInt16(topicidL.Text);
            ObjCategory = ObjCategory.Get_By_id(topicid);
            topicidL.Text = ObjCategory.CategoryName;
            topicidL.Visible = true;


        }


        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            CheckBox ck = (CheckBox)e.Item.FindControl("CheckBox1");

            Label lbl = (Label)e.Item.FindControl("lblapprove");
            Label solutionid = (Label)e.Item.FindControl("lblsolutionid");
            Image imgapprove = (Image)e.Item.FindControl("imgapprove");
            Image imgreject = (Image)e.Item.FindControl("Imgunapproved");
            Image imgdelete = (Image)e.Item.FindControl("Imgdelete");
            int slid = Convert.ToInt16(solutionid.Text);
            int solid = Convert.ToInt16(solutionid.Text);

            ObjSolution = ObjSolution.Get_By_id(solid);
            approvestatus = Convert.ToInt16(ObjSolution.SolutionStatus);
            if (approvestatus == 1)
            {


                lbl.Text = "Approved";
                imgapprove.Visible = true;
                imgreject.Visible = false;


            }

            else if (approvestatus == 2)
            {

                lbl.Text = "Rejected";
                imgapprove.Visible = false;
                imgreject.Visible = true;

            }
            else
            {

                lbl.Text = "Unapproved";
                imgapprove.Visible = false;
                imgreject.Visible = false;
                imgdelete.Visible = false;

            }

        }
    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPages.ItemCommand += new RepeaterCommandEventHandler(rptPages_ItemCommand);

    }

    void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        LoadData();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        string myScript;
        myScript = "<script language=javascript>javascript:window.close();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }
}
