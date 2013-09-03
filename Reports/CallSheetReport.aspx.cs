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

public partial class Reports_CallSheetReport : System.Web.UI.Page
{
    Site_mst objSite = new Site_mst();
    BLLCollection<Site_mst> colSite = new BLLCollection<Site_mst>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSite();
            
        }

    }
    protected void BindSite()
    {
        colSite = objSite.Get_All();
        drpsite.DataTextField = "sitename";
        drpsite.DataValueField = "siteid";
        drpsite.DataSource = colSite;
        drpsite.DataBind();
        ListItem item = new ListItem();
        item.Text = "---Select Site---";
        item.Value = "0";
        drpsite.Items.Add(item);
        drpsite.SelectedValue = "0";
    
    }
    protected void btnViewreport_Click(object sender, EventArgs e)
    {
        string vardate;
        string vardate1;
        string siteid;
        string[] tempdate = txtFromDate.Text.ToString().Split(("/").ToCharArray());
        vardate = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];
        string[] tempdate1 = txttoDate.Text.ToString().Split(("/").ToCharArray());
        vardate1 = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];
        siteid =drpsite.SelectedValue;
        ReportParameter[] Param = new ReportParameter[3];
        Param[0] = new ReportParameter("Fromdate", vardate);
        Param[1] = new ReportParameter("Todate", vardate1);
        Param[2] = new ReportParameter("Siteid", siteid);
        ReportViewer1.Attributes.Add("style", "overflow:auto;");
        ReportViewer1.ShowCredentialPrompts = false;
        ReportViewer1.ServerReport.ReportServerCredentials = new ReportClass.ReportCredentials(ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[0], ConfigurationSettings.AppSettings["Credentials"].ToString().Split('\\')[1], "");
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ConfigurationSettings.AppSettings["ReportServerURL"].ToString());
        ReportViewer1.ServerReport.ReportPath = "/TerexBESTREPORT/CallSheetReport";
        ReportViewer1.ServerReport.SetParameters(Param);
        ReportViewer1.ServerReport.Refresh();
    }
}
