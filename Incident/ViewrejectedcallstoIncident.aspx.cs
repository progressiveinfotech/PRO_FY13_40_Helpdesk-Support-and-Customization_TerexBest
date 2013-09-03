using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;

public partial class Incident_ViewrejectedcallstoIncident : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["subject"] != null && Session["body"] != null && Session["mail"] != null)
            {
                TxtSubject.Text = Session["subject"].ToString();
                TxtBody.Text = Session["body"].ToString();
                TxtMailFrom.Text = Session["mail"].ToString();
            }
        }
    }
    public void OpenConnection()
    {
        string connection = ConfigurationManager.ConnectionStrings["CSM_DB"].ConnectionString;
        con = new SqlConnection(connection);
        cmd = new SqlCommand();
        con.Open();
        cmd.Connection = con;
    }

    protected void BtnClick_Click(object sender, EventArgs e)
    {
        Session["subject"] = TxtSubject.Text;
        Session["body"] = TxtBody.Text;
        Session["mail"] = TxtMailFrom.Text;
        // find Username after Regards Text in mail body
        bool regards = Regex.IsMatch(TxtBody.Text, @"(^|\s)Regards(\s|$)");
        bool regard = Regex.IsMatch(TxtBody.Text, @"(^|\s)Regard(\s|$)");

        if (regard || regards)
        {
            int index = 0;
            if (TxtBody.Text.Contains("Regards"))
            {
                index = TxtBody.Text.LastIndexOf("Regards") + 7;
            }
            else
            {
                index = TxtBody.Text.LastIndexOf("Regard") + 6;
            }
            int length = TxtBody.Text.Length;
            string username = TxtBody.Text.Substring(index);
            Session["RegardsName"] = username;
            //end find username
        }
        else
        {
            //if no username after regards then pass session value(No user)
            Session["RegardsName"] = "No User";
            //end no username
        }

        string myScript;
        myScript = "<script language=javascript>javascript:redirect();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        string myScript;
        OpenConnection();
        int id = Convert.ToInt32(Session["id"].ToString());
        //cmd.CommandText = "update NNMcalls_mst set IsActive=0 where id='"+id+"'";
        cmd.CommandText = "delete from storemail  where id='" + id + "'";
        cmd.ExecuteNonQuery();
        myScript = "<script language=javascript>javascript:refreshParent();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }

}