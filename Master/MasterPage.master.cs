using System;
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

public partial class Master_MasterPage : System.Web.UI.MasterPage
{
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    ContactInfo_mst objContact = new ContactInfo_mst();
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblUser.Text = Session["User"].ToString();
        if (!IsPostBack)
        {

            MembershipUser User = Membership.GetUser();
            objOrganization = objOrganization.Get_Organization();
            int userid = objUser.Get_By_UserName(User.UserName.ToString(), objOrganization.Orgid);
            if (userid != 0)
            {
                objContact = objContact.Get_By_id(userid);
                lblUser.Text = objContact.Firstname + "&nbsp;&nbsp;" + objContact.Lastname;
            }
            //added by lalit to view Mail link only to SDE. checking here SDE is logged on.
            if (Roles.IsUserInRole(User.UserName.ToString(), "SDE"))
            {
                trautocall.Visible = true;
                //trRejectedcall.Visible = true;
            }
            if (Roles.IsUserInRole(User.UserName.ToString(), "admin"))
            {
                //trautocall.Visible = true;
                trRejectedcall.Visible = true;
            }
            //if (Roles.IsUserInRole(User.UserName.ToString(), "SDE"))
            //{
            //    //trautocall.Visible = true;
            //    trRejectedcall.Visible = true;
            //}
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Incident/NNMcalls.aspx");
    }
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Session["Filterid"] = drpFilter.SelectedValue;
        Session["keyword"] = txtKeyword.Text;
        if (drpFilter.SelectedValue == "1")
        {

            string Str = txtKeyword.Text.Trim();

            double Num;

            bool isNum = double.TryParse(Str, out Num);

            if (isNum)
            {
                Response.Redirect("../Incident/default.aspx");

            }





        }
        else
        {
            Response.Redirect("../Incident/default.aspx");

        }

    }
    protected void lnkNewRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Incident/IncidentRequest.aspx");
    }
    protected void lnkShowRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Incident/default.aspx");
    }
    protected void lnkhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Login/default.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string myScript;
        string solution = txtSolution.Text;
        string url = "../Incident/SearchSolution.aspx?solution=" + solution;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "window.open('" + url + "','popupwindow','width=920,height=600,left=200,top=230,Scrollbars=yes')", "window.open('" + url + "','popupwindow','width=920,height=600,left=200,top=230,Scrollbars=yes');", true);

        myScript = "<script language=javascript>javascript:window.open('" + url + "','popupwindow','width=920,height=600,left=200,top=230,Scrollbars=yes');</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);


        //Response.Redirect("../Incident/SearchSolution.aspx?solution=" + solution );
    }


    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Incident/Viewrejectedcalls.aspx");
    }
    //protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    //{
    //    Session["Filterid"] = drpFilter.SelectedValue;
    //    Session["keyword"] = txtKeyword.Text;
    //    if (drpFilter.SelectedValue == "1")
    //    {

    //        string Str = txtKeyword.Text.Trim();

    //        double Num;

    //        bool isNum = double.TryParse(Str, out Num);

    //        if (isNum)
    //        {
    //            Response.Redirect("../Incident/default.aspx");

    //        }





    //    }
    //    else
    //    {
    //        Response.Redirect("../Incident/default.aspx");

    //    }

    //}
    //protected void lnkNewRequest_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("../Incident/IncidentRequest.aspx");
    //}
    //protected void lnkShowRequest_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("../Incident/default.aspx");
    //}
    //protected void lnkhome_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("../Login/default.aspx");
    //}
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string myScript;
        string solution = txtSolution.Text;
        string url = "../Incident/SearchSolution.aspx?solution=" + solution;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "window.open('" + url + "','popupwindow','width=920,height=600,left=200,top=230,Scrollbars=yes')", "window.open('" + url + "','popupwindow','width=920,height=600,left=200,top=230,Scrollbars=yes');", true);

        myScript = "<script language=javascript>javascript:window.open('" + url + "','popupwindow','width=920,height=600,left=200,top=230,Scrollbars=yes');</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);

    }

}




