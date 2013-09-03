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

public partial class admin_AddSolution : System.Web.UI.Page
{
    Category_mst ObjCategory = new Category_mst();
    Solution_mst ObjSolution=new Solution_mst ();
    SolutionKeyword ObjSolutionKeyword=new SolutionKeyword ();
    SolutionCreator ObjSolutionCreator = new SolutionCreator();
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    SentMailToUser objSentMailToUser = new SentMailToUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValTitle.ErrorMessage = Resources.MessageResource.errTitle.ToString();
            
            
            BindDrpCategory(); 
        
        }
        
    }
    protected void btnSolutionAdd_Click(object sender, EventArgs e)
    {
        string userName;
        MembershipUser User = Membership.GetUser();
        userName = User.UserName.ToString();
        int userid;
        objOrganization = objOrganization.Get_Organization();
        objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);

        int Solutionid;
        ObjSolution.Title = txtTitle.Text.ToString();
        ObjSolution.Content=Editor.Text.ToString();
        ObjSolution.Topicid = Convert.ToInt16(drpTopic.SelectedValue);
        ObjSolution.Solution = drpSolutionType.SelectedValue;
        ObjSolution.Insert();
        Solutionid = ObjSolutionKeyword.Get_SolutionId();
        ObjSolutionKeyword.Keywords=txtKeywords.Text.ToString();
        ObjSolutionKeyword.Solutionid = Solutionid;
        ObjSolutionKeyword.Insert();
        ObjSolutionCreator.Solutionid = Solutionid;
        ObjSolutionCreator.Createdby = objUser.Userid;
        ObjSolutionCreator.Insert();
        objSentMailToUser.SentMailToPManager(Solutionid);
        Response.Redirect("ViewSolution.aspx?solutionid" + Solutionid);


    }

    public void BindDrpCategory()
    {
        // Declare col as Collection of Category_mst Object to get all records from table 
        BLLCollection<Category_mst> col = new BLLCollection<Category_mst>();
        // declare object objOrganization of Category_mst_mst Class to call function Get_All() to fetch all records from database

        // Assign all records to variable col 
        col = ObjCategory.Get_All();
        drpTopic.DataTextField = "CategoryName";
        drpTopic.DataValueField = "categoryid";
        drpTopic.DataSource = col;
        drpTopic.DataBind();

       
        // Declare item as listItem to assign default value to drop down
        ListItem item = new ListItem();
        item.Text = Resources.MessageResource.errSelectTopic.ToString();
        item.Value = "0";
        drpTopic.Items.Add(item);
        drpTopic.SelectedValue = "0";
        





    }
}
