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


/// <summary>
/// Summary description for SentMailToUser
/// </summary>
public class SentMailToUser
{
    Incident_mst objIncident = new Incident_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    IncidentStates objIncidentStates = new IncidentStates();
    IncidentResolution objIncidentResolution = new IncidentResolution();
    Priority_mst objPriority = new Priority_mst();
    Site_mst objSite = new Site_mst();
    AreaManager_mst objAreaManager = new AreaManager_mst();
    ContactInfo_mst objC_info = new ContactInfo_mst();
    UserLogin_mst objtech = new UserLogin_mst();
    UserLogin_mst objSDE = new UserLogin_mst();
    ContactInfo_mst objUserInfo = new ContactInfo_mst();
    RoleInfo_mst objRole = new RoleInfo_mst();
    BLLCollection<UserLogin_mst> colUser = new BLLCollection<UserLogin_mst>();
    UserToSiteMapping objUserToSiteMapping = new UserToSiteMapping();
    Change_mst ObjChange = new Change_mst();
    UserEmail objemail = new UserEmail();
    BLLCollection<UserEmail> colemailid = new BLLCollection<UserEmail>();
    SentEmail obj = new SentEmail();
    SLA_Priority_mst objSlaPriority = new SLA_Priority_mst();
    public SentMailToUser()
    { 
        //
        // TODO: Add constructor logic here
        //
    }
    #region Function Definition of Calculate Total Resolution time define for particular SLA
    public string GetResolutionTimeInHours(int slaid)
    {
        int varDays = 0;
        int varHours = 0;
        int VarMins = 0;
        int TotalHours = 0;
        string total="";
        objSlaPriority = objSlaPriority.Get_By_id(slaid);
        if (objSlaPriority.Slaid != 0)
        {
            varDays = objSlaPriority.Resolutiondays;
            varHours = objSlaPriority.Resolutionhours;
            VarMins = objSlaPriority.Resolutionmin;
            if (VarMins <= 0)
            {
                TotalHours = (varDays * 24) + (varHours);
                total = TotalHours.ToString()+" "+"Hours";
            }
            else
            {
                TotalHours = (varDays * 24) + (varHours);
                total = TotalHours.ToString() + " " + "Hours" + VarMins + " " +"Minutes";
            }
        }

        return total;


    }
    #endregion
    public void SentmailUser(int userid, int incidentid, string status)
    {
        objIncident = objIncident.Get_By_id(incidentid);
        //added by lalit 02 nov to get resolution and show it to user when call closed mail goes to user
        objIncidentResolution = objIncidentResolution.Get_By_id(incidentid);
        //end
        objSite = objSite.Get_By_id(objIncident.Siteid);
        objAreaManager = objAreaManager.Get_By_id(objSite.Siteid);
        objIncidentStates = objIncidentStates.Get_By_id(incidentid);
        objPriority = objPriority.Get_By_id(objIncidentStates.Priorityid);
        objUser = objUser.Get_By_id(objIncident.Requesterid);
        objC_info = objC_info.Get_By_id(userid);
        objtech = objtech.Get_By_id(objIncidentStates.Technicianid);
        colemailid = objemail.Get_All_userid(userid);
        string strStatusOpen = Resources.MessageResource.strStatusOpen.ToString();
        string strStatusClose = Resources.MessageResource.strStatusClose.ToString();
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();

        if (strStatusOpen.ToLower() == status.ToLower())
        {
          foreach (UserEmail obj1 in colemailid)
            {
                if (obj1.Emailid != null)
                {
                    obj.From = Resources.MessageResource.strAdminEmail.ToString();
                    obj.To = obj1.Emailid;
                    obj.CC=objAreaManager.Email;
                    obj.Subject = "Call Logged. Ticket Id : " + incidentid;
                    obj.Body = "Dear " + objC_info.Firstname + ",<br/><br/> Thank you for contacting IT Service desk, please find below the new Ticket Id details for your future reference.<br/><br/><b>Incident Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                       + incidentid + "<br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                       + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                       + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                       + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                       + objPriority.Name + "<br/><b>Username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                                       + objUser.Username + "<br/><b>EstimatedResolutionTime&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                                       + GetResolutionTimeInHours(objIncident.Slaid)
                                       + "<br/><b>Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 

                                       + objC_info.Emailid + "<br/><br/> For any other support, kindly get in touch with us at " + strContactNumber + ".<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b> " + strYourSinscerely + "</b>";
                    obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
                    obj.SentMail();
                    string varPriority = Resources.MessageResource.strPriorityHigh.ToString();
                    if (objPriority.Priorityid != 0)
                    {
                        if (objPriority.Name.ToLower() == varPriority.ToLower())
                        {
                            SentMailToSDM(objSite.Siteid, incidentid, objUser.Userid);
                        }
                                                            
                    }
                 }
            }
            //if (objC_info.Emailid != null)
            //{
            //    obj.From = Resources.MessageResource.strAdminEmail.ToString();
            //    obj.To = objC_info.Emailid;
            //    obj.Subject = " New Call Logged. Ticket Id : " + incidentid;
            //    obj.Body = "Dear User,<br/> Thank you for contacting Service desk, please find below the Ticket Id details for your future reference.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><br/> For any other support kindly get in touch with us at <b>" + strContactNumber + "</b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            //    obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            //   //obj.SentMail();
            //    string varPriority = Resources.MessageResource.strPriorityHigh.ToString();
            //    if (objPriority.Priorityid != 0)
            //    {
            //        if (objPriority.Name.ToLower() == varPriority.ToLower())
            //        {
            //            SentMailToSDM(objSite.Siteid, incidentid, objUser.Userid);
            //        }
            //    }
            //}
        }
        if (strStatusClose.ToLower() == status.ToLower())
        {
            foreach (UserEmail obj1 in colemailid)
            {
                if (obj1.Emailid != null)
                {
                    int id = Convert.ToInt16(objIncident.Incidentid);
                    string varServerName1;
                    string varfeedbackmode;
                    varServerName1 = Resources.MessageResource.serverNameForChangePage.ToString();
                    //added by lalit to check feedback mode. feedback should add in mail or not.
                    //fetching value from resouce file which is from appsettting page.
                    varfeedbackmode = Resources.MessageResource.UserFeedbackmode.ToString();
                    string url11;
                    url11 = "http://" + varServerName1 + "/"+ getpath()+"/LoginPageAccess/CustomerFeedback.aspx?userid=" + userid+"&Clid="+objIncident.Incidentid;
                    //url11 = "../LoginPageAccess/CustomerFeedback.aspx?userid=" + userid + "&Clid=" + objIncident.Incidentid;
                    if (objC_info.Emailid != null)
                    {
                       // string url;
                    //    url = "<a  href=" + url11 + "&userid=" + objC_info.Firstname + " ' onclick=window.open()>Your Feedback</a>";
                        string url = "<a  href=" + url11 + " ' onclick=window.open()>Your Feedback</a>";
                        obj.From = Resources.MessageResource.strAdminEmail.ToString();
                        obj.To = obj1.Emailid;
                        obj.CC = objAreaManager.Email;
                        obj.Subject = "Call Closed Ticket id : " + incidentid;
                         //added by lalit
                        if (varfeedbackmode == "0") //0 means default mode where user will not recieve link in mail to give feedback
                        {
                                obj.Body = "Dear " + objC_info.Firstname 
                                + ",<br/><br/> <b>Incident Status:</b> Issue Resolved and call closed by&nbsp;<b>" 
                                + objtech.Username + "</b>&nbsp;on&nbsp;<b>" 
                                + objIncident.Completedtime + ".<br/><br/></b>We are pleased to confirm that the Service Call reported by you has been attended and resolved, should there be any further questions or queries, please do not hesitate to contact the Service Desk." + "<br/><br/><b>Incident Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + incidentid + "<br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;:</b> " 
                                + objIncident.Createdatetime + "<br/><b>Closed Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objIncident.Completedtime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                                + objIncident.Description + "<br/><b>Resolution&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objIncidentResolution.Resolution+ "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objPriority.Name + "<br/><b>Username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objUser.Username + "<br/><b>Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objC_info.Emailid + "<br/><br/> For any other support, kindly get in touch with us at " 
                                + strContactNumber + ".<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b>" 
                                + strYourSinscerely + "</b>";
                        }
                        else
                        {
                                obj.Body = "Dear " + objC_info.Firstname 
                                + ",<br/><br/> <b>Incident Status:</b> Issue Resolved and call closed by&nbsp;<b>" 
                                + objtech.Username + "</b>&nbsp;on&nbsp;<b>" 
                                + objIncident.Completedtime + ".<br/><br/></b>We are pleased to confirm that the Service Call reported by you has been attended and resolved, should there be any further questions or queries, please do not hesitate to contact the Service Desk." + "<br/><br/><b>Incident Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + incidentid + "<br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;:</b> " 
                                + objIncident.Createdatetime + "<br/><b>Closed Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objIncident.Completedtime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                                + objIncident.Description + "<br/><b>Resolution&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> "
                                + objIncidentResolution.Resolution + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objPriority.Name + "<br/><b>Username&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objUser.Username + "<br/><b>Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " 
                                + objC_info.Emailid + "<br/><br/> For any other support, kindly get in touch with us at "
                                + strContactNumber + ".<br/><br/>To give feedback click on "
                                + url + ".<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/><br/> <b>" 
                                + strYourSinscerely + "</b>";
                        }
                        obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
                        obj.SentMail();
                    }
                }
            }
            //int id = Convert.ToInt16(objIncident.Incidentid);
            //string varServerName1;
            //varServerName1 = Resources.MessageResource.serverNameForChangePage.ToString();
            //// varServerName = "10.80.0.15";
            //string url11;
            //url11 = "http://" + varServerName1 + "/BESTN/LoginPageAccess/CustomerFeedback.aspx?incident=" + id;
            //if (objC_info.Emailid != null)
            //{
            //    string url;
            //    url = "<a  href=" + url11 + "&userid=" + objC_info.Firstname + " ' onclick=window.open()>Your Feedback</a>";
            //    obj.From = Resources.MessageResource.strAdminEmail.ToString();
            //    obj.To = objC_info.Emailid;
            //    obj.Subject = "Call Closed Ticket id : " + incidentid;
            //    obj.Body = "Dear User,<br/> <b>Complaint Status:</b>Problem solved and call closed by&nbsp;<b>" + objtech.Username + "</b>&nbsp;on&nbsp;<b>" + objIncident.Completedtime + "</b>.We are pleased to inform you that your reported Service Call has been attended and problem solved as informed by our engineer.<br/>Should there be any further questions or queries, please do not hesitate to contact the Service Desk on 0120 4393941, quoting your Ticket Reference Number.   " + "<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "</br><b>Logged Date & Time&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><br/> For any other support kindly get in touch with us at <b>" + strContactNumber + "</b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Your Feedback</b><br/><br/>" + url + "<br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            //    obj.SmtpServer = obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            //   // obj.SentMail();
           //}
        }
    }
    public void SentFeedbackmailToUser(int userid, string Emailid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string varServerName = Resources.MessageResource.serverNameForChangePage.ToString();
        string url11;
        url11 = "http://" + varServerName + "/"+ getpath()+"/LoginPageAccess/CustomerFeedback.aspx?userid=" + userid;

        string url = "<a  href=" + url11 + " ' onclick=window.open()>Your Feedback</a>";
        obj.From = Resources.MessageResource.strAdminEmail.ToString();
        obj.To = Emailid;
        obj.Subject = "User Survey";
        obj.Body = "Dear User,<br/> Please provide the feedback for the user <br/>" + url + "</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
        obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
        obj.SentMail();
    }
    public string getpath()
    {
        string url = HttpContext.Current.Request.Url.AbsolutePath.ToString();
        string del = string.Empty;
        if (url.Contains("/"))
        {
            del = "/";
        }
        string[] splitUrl = url.Split(del.ToCharArray());
        string applicationname = splitUrl[1].ToString();
        return applicationname;
    }
    public void SentmailTechnician(int technicianid, int incidentid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        objIncident = objIncident.Get_By_id(incidentid);
        objSite = objSite.Get_By_id(objIncident.Siteid);
        objIncidentStates = objIncidentStates.Get_By_id(incidentid);
        objPriority = objPriority.Get_By_id(objIncidentStates.Priorityid);
        objUser = objUser.Get_By_id(objIncident.Requesterid);
        objtech = objtech.Get_By_id(technicianid);
        objSDE = objSDE.Get_By_id(objIncident.Createdbyid);
        objC_info = objC_info.Get_By_id(technicianid);
        objUserInfo = objUserInfo.Get_By_id(objIncident.Requesterid);

        if (objC_info.Emailid != null)
        {
            obj.To = objC_info.Emailid;
            obj.From = Resources.MessageResource.strAdminEmail.ToString();
            obj.Subject = " New Call Assigned to you. Ticket id : " + incidentid;
            obj.Body = "Dear&nbsp;" + objtech.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUser.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objUserInfo.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objC_info.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at <b>" + strContactNumber + "</b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            obj.SmtpServer = obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            obj.SentMail();
        }

    }
    public void SentMailToSDM(int siteid, int incidentid, int requesterid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        int FlagUser;
        string varRole = Resources.MessageResource.strSDMRole.ToString();
        int roleid;
        roleid = objRole.Get_By_RoleName(varRole);
        colUser = objUser.Get_All_By_Role(roleid);
        foreach (UserLogin_mst objusr in colUser)
        {

            FlagUser = objUserToSiteMapping.Get_By_Id(objusr.Userid, siteid);
            if (FlagUser != 0)
            {
                objIncident = objIncident.Get_By_id(incidentid);
                objSite = objSite.Get_By_id(objIncident.Siteid);
                objIncidentStates = objIncidentStates.Get_By_id(incidentid);
                objPriority = objPriority.Get_By_id(objIncidentStates.Priorityid);

                UserLogin_mst obju = new UserLogin_mst();
                UserLogin_mst objReq = new UserLogin_mst();
                obju = obju.Get_By_id(objUserToSiteMapping.Userid);
                objC_info = objC_info.Get_By_id(objusr.Userid);
                objReq = objReq.Get_By_id(requesterid);
                ContactInfo_mst objReqContInfo = new ContactInfo_mst();
                objReqContInfo = objReqContInfo.Get_By_id(objReq.Userid);

                obj.From = Resources.MessageResource.strAdminEmail.ToString();
                obj.To = objC_info.Emailid;
                obj.Subject = "High Priority Call. Ticket Id: " + incidentid;
                obj.Body = "Dear Sir/Madam,<br/>High Priority Call has been logged, please find below the Complaint  details .<br/><br/><b>Complaints Details : </b> <br/><br/><b>Ticket Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + incidentid + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Title + " <br/><b>Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSite.Sitename + "<br/><b>Logged Date & Time&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Createdatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objIncident.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objReq.Username + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objReqContInfo.Emailid + "<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
                obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
                obj.SentMail();


            }

        }

    }
    public void SentMailToPManager(int solutionid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        Solution_mst objSolution = new Solution_mst();
        SolutionCreator objSolutionCreator = new SolutionCreator();
        objSolution = objSolution.Get_By_id(solutionid);
        objSolutionCreator = objSolutionCreator.Get_By_id(solutionid);
        UserLogin_mst objUserCreator = new UserLogin_mst();
        objUserCreator = objUserCreator.Get_By_id(objSolutionCreator.Createdby);
        int FlagUser;
        string varRole = Resources.MessageResource.strPManagerRole.ToString();
        int roleid;
        roleid = objRole.Get_By_RoleName(varRole);
        colUser = objUser.Get_All_By_Role(roleid);
        foreach (UserLogin_mst objusr in colUser)
        {

            objC_info = objC_info.Get_By_id(objusr.Userid);
            obj.From = Resources.MessageResource.strAdminEmail.ToString();
            obj.To = objC_info.Emailid;
            obj.Subject = "New Solution Added. Solution Id : " + solutionid;
            obj.Body = "Dear Sir/Madam,<br/>A New Solution has been Added.Please find the New Solution details .<br/><br/><b>Solution Details : </b> <br/><br/><b>Solution Id &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSolution.Solutionid + "<br/><b>Title &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSolution.Title + " <br/><b>Added By &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objUserCreator.Username + "<br/><b>Created Date &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSolutionCreator.CreateDatetime + "<br/><b>Content&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objSolution.Content + "<br/><br/>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            obj.SentMail();

        }


    }
    public void SentMailToTechnicianForProblemCall(int problemid, int userid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        Problem_mst objProblem = new Problem_mst();
        objUser = objUser.Get_By_id(userid);
        ContactInfo_mst objCont_info = new ContactInfo_mst();
        objCont_info = objCont_info.Get_By_id(objUser.Userid);
        objProblem = objProblem.Get_By_id(problemid);
        objPriority = objPriority.Get_By_id(objProblem.Priorityid);
        UserLogin_mst objReq = new UserLogin_mst();
        objReq = objReq.Get_By_id(objProblem.Requesterid);
        ContactInfo_mst objReqCont = new ContactInfo_mst();
        objReqCont = objReqCont.Get_By_id(objReq.Userid);
        objSDE = objSDE.Get_By_id(objProblem.CreatedByid);

        if (objCont_info.Emailid != null)
        {
            obj.To = objCont_info.Emailid;
            obj.From = Resources.MessageResource.strAdminEmail.ToString();
            obj.Subject = " New Problem Call Assigned to you. Problem Id : " + problemid;
            obj.Body = "Dear&nbsp;" + objUser.Username + "," + "<br/>  A Call with the following details have been assigned to you.<br/><br/><b>Problem Details : </b> <br/><br/><b>Problem Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objProblem.ProblemId + "<br/><b>Title of Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objProblem.title + " <br/><b>Logged Date & Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;:</b>" + objProblem.CreateDatetime + "<br/><b>Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objProblem.Description + "<br/><b>Priority&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b> " + objPriority.Name + "<br/><b>UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objReq.Username + "<br/><b>Mobile No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objReqCont.Mobile + "<br/><b>Landline No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<b/>" + objReqCont.Landline + "<br/><b>Mail Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + objReqCont.Emailid + "<br/><b>Service Desk Executive&nbsp;&nbsp;&nbsp;:</b>" + objSDE.Username + "<br/><br/> For any other support kindly get in touch with us at <b>" + strContactNumber + "</b>.<br/><br/> <b>This is an auto generated mail. Please do not reply.</b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            obj.SmtpServer = obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            obj.SentMail();

        }



    }
    public void SentMailToChangeCommittee(int changeid, int changetypeid)
    {
        string strYourSinscerely = Resources.MessageResource.strYourSinscerely.ToString();
        string strContactNumber = Resources.MessageResource.strContactNumber.ToString();
        Cab_mst Objcabmember = new Cab_mst();
        ObjChange = ObjChange.Get_By_id(changeid);

        BLLCollection<Cab_mst> colmembers = new BLLCollection<Cab_mst>();
        UserLogin_mst objUserCreator = new UserLogin_mst();

        int FlagUser;

        int roleid;
        string varServerName;
        varServerName = Resources.MessageResource.serverNameForChangePage.ToString();
        // varServerName = "10.80.0.15";
        string url11;
        url11 = "http://" + varServerName + "/BEST/LoginPageAccess/ApproveorRejectChangeRequest.aspx?changeid=" + changeid;

        colmembers = Objcabmember.Get_All_By_ChangeTypeid(changetypeid);



        string url;
        foreach (Cab_mst objmember in colmembers)
        {

            url = "<a  href=" + url11 + "&userid=" + objmember.Membername + " ' onclick=window.open()>Click Here For Approval</a>";

            obj.From = Resources.MessageResource.strAdminEmail.ToString();

            obj.To = objmember.Emailid;
            obj.Subject = "New Change Added. Change Id : " + changeid;
            obj.Body = "Dear Sir/Madam,<br/>A New Change has been requested.Please.<br/><br/><b>Solution Details : </b> <br/><br/><b>Changeid Id &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + ObjChange.Changeid + "<br/><b>Title &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + ObjChange.Title + " <br/><b>Added By &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + ObjChange.CreatedByID + "<br/><b>Created Date &nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + ObjChange.Createdtime + "<br/><b>Content&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</b>" + ObjChange.Description + "<br/><br/>This is an auto generated mail. Please do not reply.</b><br/><br/></b><br/><b>Kindly Click the following link to Aprove or Reject the Change Request. <br></br>" + url + " <b><br/><br/><b>Yours sincerely,</b><br/> <b>" + strYourSinscerely + "</b>";
            obj.SmtpServer = Resources.MessageResource.strSMTPServer.ToString();
            obj.SentMail();


        }


    }

}
