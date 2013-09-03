﻿using System;
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

public partial class Incident_IncidentLog : System.Web.UI.Page
{
    Incident_mst objIncident = new Incident_mst();
    IncidentLog objIncidentLog = new IncidentLog();
    UserLogin_mst objUser = new UserLogin_mst();
    Organization_mst objOrganization = new Organization_mst();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        
        
        }
        
    }
    protected void btnapprove_Click(object sender, EventArgs e)
    {
        int userid=0;
        int incidentid = Convert.ToInt16(Session["incidentid"].ToString());
        if (incidentid != 0)
        {

            //objIncidentLog = objIncidentLog.Get_By_id(incidentid);
            //if (objIncidentLog.Incidentid != 0)
            //{
            //    objIncidentLog.Incidentid = incidentid;
            //    objIncidentLog.Incidentlog = txtcomments.Text;
            //    objIncidentLog.Update();

            //}
            //else 
            //{
            //    objIncidentLog.Incidentid = incidentid;
            //    objIncidentLog.Incidentlog = txtcomments.Text;
            //    objIncidentLog.Insert();
            
            //}

        string userName="";
        MembershipUser User = Membership.GetUser();
        if (User != null)
        {
            userName = User.UserName.ToString();
        }


        if (userName != "")
        {
           
            objOrganization = objOrganization.Get_Organization();
            objUser = objUser.Get_UserLogin_By_UserName(userName, objOrganization.Orgid);
            if (objUser.Userid != 0)
            {
                userid = objUser.Userid;
            }
        }

            objIncidentLog.Incidentid = incidentid;
            objIncidentLog.Userid = userid;
            objIncidentLog.Incidentlog = txtcomments.Text;
            objIncidentLog.Insert();
         
            string myScript;
            myScript = "<script language=javascript>javascript:refreshParent(); javascript:window.close();</script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        
        
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
    }
}
