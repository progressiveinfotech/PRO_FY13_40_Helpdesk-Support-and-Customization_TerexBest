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

public partial class Login_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkNewTicket_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Incident/incidentrequest.aspx");
    }
    protected void lnkMyTicket_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Incident/default.aspx");
    }
    protected void lnkKedb_Click(object sender, EventArgs e)
    {
        Response.Redirect("../KEDB/ViewSolution.aspx");
    }
    protected void lnkAsset_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Asset/default.aspx");
    }
    protected void lnkContract_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Contract/AddContract.aspx");
    }
    protected void lnkContact_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Problem/ProblemLog.aspx");
    }
    protected void lnkChat_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Change/ChangeLog.aspx");
    }
    protected void lnkReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Reports/Reports.aspx");
    }
}
