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
using System.Xml;
using System.Xml.Linq;

public partial class admin_AppSetting : System.Web.UI.Page
{
        XmlDocument loResource = new XmlDocument();
        
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadResource();
        }
    }
    protected void LoadResource()
    {
        loResource.Load(Server.MapPath("~/App_LocalResources/resouce.resx"));
        XmlNode loservername = loResource.SelectSingleNode("root/data[@name='serverNameForChangePage']/value");
        XmlNode lomailserver = loResource.SelectSingleNode("root/data[@name='strMailServer']/value");
        XmlNode loadminmail = loResource.SelectSingleNode("root/data[@name='strAdminEmail']/value");
        XmlNode lolevel1esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel1Escalate']/value");
        XmlNode lolevel2esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel2Escalate']/value");
        XmlNode lolevel3esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel3Escalate']/value");
        XmlNode lostrcontactno = loResource.SelectSingleNode("root/data[@name='strContactNumber']/value");
        XmlNode lostrfeedbackmode = loResource.SelectSingleNode("root/data[@name='strFeedBackMode']/value");
        if (lostrfeedbackmode.InnerText == "0")
        {
            Ddlfeedbackmode.SelectedItem.Selected = false;
            Ddlfeedbackmode.Items.FindByValue("0").Selected = true;
        }
        else
        {
            Ddlfeedbackmode.SelectedItem.Selected =false;
            Ddlfeedbackmode.Items.FindByText("Call wise").Selected = true;
        }
        txtservername.Text=loservername.InnerText;
        txtmailserver.Text = lomailserver.InnerText;
        txtadminmailid.Text = loadminmail.InnerText;
        txtlevel1esc.Text = lolevel1esc.InnerText;
        txtlevel2esc.Text = lolevel2esc.InnerText;
        txtlevel3esc.Text = lolevel3esc.InnerText;
        txtcontactno.Text = lostrcontactno.InnerText;

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        loResource.Load(Server.MapPath("~/App_LocalResources/resouce.resx"));
        XmlNode loservername = loResource.SelectSingleNode("root/data[@name='serverNameForChangePage']/value");
        XmlNode lomailserver = loResource.SelectSingleNode("root/data[@name='strMailServer']/value");
        XmlNode loadminmail = loResource.SelectSingleNode("root/data[@name='strAdminEmail']/value");
        XmlNode lolevel1esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel1Escalate']/value");
        XmlNode lolevel2esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel2Escalate']/value");
        XmlNode lolevel3esc = loResource.SelectSingleNode("root/data[@name='strEmailFromLevel3Escalate']/value");
        XmlNode lostrcontactno = loResource.SelectSingleNode("root/data[@name='strContactNumber']/value");
        XmlNode lostrsmtpserverno = loResource.SelectSingleNode("root/data[@name='strSMTPServer']/value");
        XmlNode lostrfeedbackmode = loResource.SelectSingleNode("root/data[@name='strFeedBackMode']/value");

        loservername.InnerText = txtservername.Text;
        lomailserver.InnerText = txtmailserver.Text;
        loadminmail.InnerText = txtadminmailid.Text;
        lolevel1esc.InnerText = txtlevel1esc.Text;
        lolevel2esc.InnerText = txtlevel2esc.Text;
        lolevel3esc.InnerText = txtlevel3esc.Text;
        lostrcontactno.InnerText = txtcontactno.Text;
        lostrsmtpserverno.InnerText = txtmailserver.Text;
        if (Ddlfeedbackmode.SelectedItem.Value == "1")
        {
            lostrfeedbackmode.InnerText = "1";
        }
        else 
        {
            lostrfeedbackmode.InnerText = "0";
        }
        loResource.Save(Server.MapPath("~/App_LocalResources/resouce.resx"));
        lblMessage.Text = "Updated successfully";

    }

    }
