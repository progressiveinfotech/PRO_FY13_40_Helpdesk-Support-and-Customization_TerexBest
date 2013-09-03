using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
//using System.Web.Mail;
using System.Net.Mail;


/// <summary>
/// Summary description for SentEmail
/// </summary>
public class SentEmail
{
    #region Private Fields

    
    private string _to;
   
    private string _from;
    private string _subject;
    private string _body;
    private string _smtpServer;
    private string _CC;
    #endregion

    #region Public Fields

    public string To
    {
        get { return _to; }
        set { _to = value; }
    }
   
    public string From
    {
        get { return _from; }
        set { _from = value; }
    }
    public string Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }
    public string Body
    {
        get { return _body; }
        set { _body = value; }
    }
    public string SmtpServer
    {
        get { return _smtpServer; }
        set { _smtpServer = value; }
    }
    public string CC
    {
        get { return _CC; }
        set { _CC = value; }
    }
    #endregion

    public SentEmail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void SentMail()
    {
        try
        {
            //previous mail sending 
            //MailMessage msgMail = new MailMessage();
            //msgMail.To = To;
            //msgMail.From = From;
            //msgMail.Subject = Subject;
            //msgMail.BodyFormat = MailFormat.Html;
            //msgMail.Body = Body.ToString();
            //SmtpMail.SmtpServer = SmtpServer;
            //SmtpMail.Send(msgMail); 
            //end previous
            MailMessage myMessage = new MailMessage();
            myMessage.From = new MailAddress(From);
            myMessage.To.Add(To);
          
            myMessage.Subject = Subject;
            myMessage.IsBodyHtml = true;
            myMessage.Body = Body.ToString();
            myMessage.CC.Add(CC);
            SmtpClient mySmtpClient = new SmtpClient();
            // System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("prachi.sharma@progressive.in", "pipl?123");
            // mySmtpClient.Host = "10.1.0.12";
            //  mySmtpClient.UseDefaultCredentials = false;
            //mySmtpClient.Credentials = myCredential;
            mySmtpClient.ServicePoint.MaxIdleTime = 1;
            //mySmtpClient.Port = 110;
            mySmtpClient.Send(myMessage);
            myMessage.Dispose();

        }
        catch (Exception ex)
        {
           
        }
    }
}
