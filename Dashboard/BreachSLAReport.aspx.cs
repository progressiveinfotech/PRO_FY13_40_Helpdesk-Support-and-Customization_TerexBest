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
using Microsoft.Reporting.WebForms;

public partial class Dashboard_BreachSLAReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            //string vardate;
            //string vardate1;


            //vardate = DateTime.Now.ToString();

            //vardate1 = DateTime.Now.ToString();

            //ReportParameter[] Param = new ReportParameter[2];
            //Param[0] = new ReportParameter("fromdate", vardate);
            //Param[1] = new ReportParameter("todate", vardate1);

            //ReportViewer1.ShowCredentialPrompts = false;
            //ReportViewer1.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
            //ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            //ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
            //ReportViewer1.ServerReport.ReportPath = "/BESTREPORT/SLABreachPerformance";
            //ReportViewer1.ServerReport.SetParameters(Param);
            //ReportViewer1.ServerReport.Refresh();

        }
    }

protected void btnViewreport_Click(object sender, EventArgs e)
    {
        string vardate;
        string vardate1;
        
        string[] tempdate = txtFromDate.Text.ToString().Split(("/").ToCharArray());
        vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
        string[] tempdate1 = txttoDate.Text.ToString().Split(("/").ToCharArray());
        vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];

        ReportParameter[] Param = new ReportParameter[2];
        Param[0] = new ReportParameter("fromdate", vardate);
        Param[1] = new ReportParameter("todate", vardate1);
        
        ReportViewer1.ShowCredentialPrompts = false;
        ReportViewer1.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
        ReportViewer1.ServerReport.ReportPath = "/BESTREPORT/SLABreachPerformance";
        ReportViewer1.ServerReport.SetParameters(Param);
        ReportViewer1.ServerReport.Refresh();
    }
}