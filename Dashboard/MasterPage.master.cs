﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Dashboard_MasterPage : System.Web.UI.MasterPage
{
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    ContactInfo_mst objContact = new ContactInfo_mst();
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Get Current User and his Role
        MembershipUser User = Membership.GetUser();
        objOrganization = objOrganization.Get_Organization();
        int userid = objUser.Get_By_UserName(User.UserName.ToString(), objOrganization.Orgid);
        if (userid != 0)
        {
            objContact = objContact.Get_By_id(userid);
            lblUser.Text = objContact.Firstname + "&nbsp;&nbsp;" + objContact.Lastname;


        }


        #endregion
    }
    protected void lnkhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Login/Default.aspx");

    }
}
