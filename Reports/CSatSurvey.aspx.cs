﻿using System;
using System.Security.Principal;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Reports_CSatSurvey : System.Web.UI.Page
{
    RoleInfo_mst objRole = new RoleInfo_mst();
    BLLCollection<UserLogin_mst> colUser = new BLLCollection<UserLogin_mst>();
    UserLogin_mst objUser = new UserLogin_mst();
    Site_mst objSite = new Site_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack )
        {
           // BindDropSite();
            
        }
      
      
    }
   
    //protected void BindDropSite()
    //{
    //    colSite = objSite.Get_All();
    //    drpSite.DataTextField = "sitename";
    //    drpSite.DataValueField = "siteid";
    //    drpSite.DataSource = colSite;
    //    drpSite.DataBind();
    //    ListItem item = new ListItem();
    //    item.Text = "-----------Select-----------";
    //    item.Value = "0";
    //    drpSite.Items.Add(item);
    //    drpSite.SelectedValue = "0";
       
    //}

    protected void drpSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindDropTechnician();
    }
    protected void btnViewreport_Click(object sender, EventArgs e)
    {
            string vardate;
            string vardate1;
           // string siteid;
           
            string[] tempdate = txtFromDate.Text.ToString().Split(("/").ToCharArray());
            vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
            string[] tempdate1 = txttoDate.Text.ToString().Split(("/").ToCharArray());
            vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];
           // siteid = drpSite.SelectedValue;
           
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("fromdate", vardate);              //change f
            Param[1] = new ReportParameter("todate", vardate1);                //change t
           // Param[2] = new ReportParameter("Siteid", siteid);
            //Param[3] = new ReportParameter("technicianid", technicianid);
            ReportViewer1.ShowCredentialPrompts = false;
            ReportViewer1.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/TerexBESTREPORT/CSatSurvey";
            ReportViewer1.ServerReport.SetParameters(Param);
            ReportViewer1.ServerReport.Refresh();
    }
}
