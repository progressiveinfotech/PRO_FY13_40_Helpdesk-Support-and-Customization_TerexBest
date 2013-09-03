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

public partial class Change_ChangeNotes : System.Web.UI.Page
{
    UserLogin_mst ObjUser = new UserLogin_mst();
    Organization_mst ObjOrganization = new Organization_mst();
    ChangeNotes ObjChangeNotes = new ChangeNotes();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnadd_Click(object sender, EventArgs e)
    {

        #region Fetch Current User

        // Fetch Current User and assign to local variable userName
        MembershipUser User = Membership.GetUser();
        string userName = User.UserName.ToString();
        #endregion
        ObjOrganization = ObjOrganization.Get_Organization();
        int orgid = Convert.ToInt16(ObjOrganization.Orgid);
        int userid = ObjUser.Get_By_UserName(userName, orgid);
        ObjChangeNotes.Username = userid;
        ObjChangeNotes.Changeid = Convert.ToInt16(Request.QueryString[0]);
        ObjChangeNotes.Comments = txtcomments.Text.ToString();
        ObjChangeNotes.Insert();
        string myScript;
        myScript = "<script language=javascript>refreshParent();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtcomments.Text = "";


    }
}
