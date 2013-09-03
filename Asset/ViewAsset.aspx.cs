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

public partial class Asset_ViewAsset : System.Web.UI.Page
{
    Asset_mst ObjAsset = new Asset_mst();
    BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    public void BindGrid()
    {

        col = ObjAsset.Get_By_comandname("A");
        grdvwViewAsset.DataSource = col;
        grdvwViewAsset.DataBind();
        ViewState["commandname"] = "a";

    }

    protected void grdvwViewAsset_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdvwViewAsset.PageIndex = e.NewPageIndex;
        BindGrid1();

    }


    protected void grdvwViewAsset_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            TableCell cell = e.Row.Cells[0];

            cell.ColumnSpan = 6;

            for (int i = 65; i <= (65 + 25); i++)
            {

                LinkButton lb = new LinkButton();

                lb.Text = Char.ConvertFromUtf32(i) + "&nbsp;&nbsp;&nbsp;";

                lb.CommandArgument = Char.ConvertFromUtf32(i);

                lb.CommandName = "AlphaPaging";
                lb.Font.Size = FontUnit.Large;
                cell.Controls.Add(lb);

            }

        }
    }
    protected void grdvwViewAsset_RowCommand(object sender, GridViewCommandEventArgs e)
    {



        if (e.CommandName.Equals("AlphaPaging"))
        {
            string commandname = e.CommandArgument.ToString();
            ViewState["commandname"] = e.CommandArgument.ToString();
            col = ObjAsset.Get_By_comandname(commandname);
            if (col.Count != 0)
            {
                grdvwViewAsset.DataSource = col;
                grdvwViewAsset.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("assetid");
                dt.Columns.Add("computername");
                dt.Columns.Add("domain");

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);

                grdvwViewAsset.DataSource = dt;
                grdvwViewAsset.DataBind();

                //grdvwViewAsset.Rows[0].Cells[3].Visible = false;
                //grdvwViewAsset.Rows[0].Cells[5].Visible = false;


            }


        }

    }

    protected void BindGrid1()
    {
        string commandname;
        commandname = ViewState["commandname"].ToString();
        col = ObjAsset.Get_By_comandname(commandname);
        if (col.Count != 0)
        {
            grdvwViewAsset.DataSource = col;
            grdvwViewAsset.DataBind();
        }

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {

        string name;

        if (txtname.Text == "")
        {
            col = ObjAsset.Get_By_comandname("");
            grdvwViewAsset.DataSource = col;
            grdvwViewAsset.DataBind();
            ViewState["commandname"] = "";
        }
        else
        {
            name = txtname.Text.ToString();
            col = ObjAsset.Get_By_comandname(name);
            grdvwViewAsset.DataSource = col;
            grdvwViewAsset.DataBind();
            ViewState["commandname"] = name;
        }
    }


    protected void grdvwViewAsset_RowEdit(object sender, GridViewEditEventArgs e)
    {
        int temp = 0;
        int Assetid = Convert.ToInt16(grdvwViewAsset.Rows[e.NewEditIndex].Cells[0].Text);
        string compname = grdvwViewAsset.Rows[e.NewEditIndex].Cells[1].Text.ToString();
        Session["Assetid"] = Assetid.ToString();
        Session["temp"] = temp;
        Response.Redirect("~/Asset/ViewAssetDetails.aspx?" + compname + "" );
    }
}
