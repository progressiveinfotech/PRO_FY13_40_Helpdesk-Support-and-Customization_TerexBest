<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="IncidentRequest.aspx.cs" Inherits="Incident_IncidentRequest" Title="Untitled Page" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
   
<script language="JavaScript"  type="text/javascript">

    var imagePath = '/TerexBest(new)/images/';

    var ie = document.all;
    var dom = document.getElementById;
    var ns4 = document.layers;
    var bShow = false;
    var textCtl;

    function setTimePicker(t) {
        textCtl.value = t;
        closeTimePicker();
    }

    function refreshTimePicker(mode) {

        if (mode == 0) {
            suffix = "am";
        }
        else {
            suffix = "pm";
        }

        sHTML = "<table><tr><td><table cellpadding=3 cellspacing=0 bgcolor='#f0f0f0'>";
        for (i = 0; i <= 11; i++) {

            sHTML += "<tr align=right style='font-family:verdana;font-size:9px;color:#000000;'>";

            if (i == 0) {
                hr = 12;
            }
            else {
                hr = i;
            }

            for (j = 0; j < 4; j++) {
                sHTML += "<td width=57 style='cursor:hand' onmouseover='this.style.backgroundColor=\"#66CCFF\"' onmouseout='this.style.backgroundColor=\"\"' onclick='setTimePicker(\"" + hr + ":" + padZero(j * 15) + " " + suffix + "\")'><a style='text-decoration:none;color:#000000' href='javascript:setTimePicker(\"" + hr + ":" + padZero(j * 15) + " " + suffix + "\")'>" + hr + ":" + padZero(j * 15) + "<font color=\"#808080\">" + suffix + "</font></a></td>";
            }

            sHTML += "</tr>";
        }
        sHTML += "</table></td></tr></table>";
        document.getElementById("timePickerContent").innerHTML = sHTML;
    }

    if (dom) {
        document.write("<div id='timepicker' style='z-index:+999;position:absolute;visibility:hidden;'><table style='border-width:3px;border-style:solid;border-color:#0033AA' bgcolor='#ffffff' cellpadding=0><tr bgcolor='#0033AA'><td><table cellpadding=0 cellspacing=0 width='100%' background='" + imagePath + "titleback.gif'><tr valign=bottom height=21><td style='font-family:verdana;font-size:11px;color:#ffffff;padding:3px' valign=center><B>&nbsp;&nbsp;Select a Time&nbsp;&nbsp;</B></td><td><img id='iconAM' src='" + imagePath + "am1.gif' onclick='document.getElementById(\"iconAM\").src=\"" + imagePath + "am1.gif\";document.getElementById(\"iconPM\").src=\"" + imagePath + "pm2.gif\";refreshTimePicker(0)' style='cursor:hand'></td><td><img id='iconPM' src='" + imagePath + "pm2.gif' onclick='document.getElementById(\"iconAM\").src=\"" + imagePath + "am2.gif\";document.getElementById(\"iconPM\").src=\"" + imagePath + "pm1.gif\";refreshTimePicker(1)' style='cursor:hand'></td><td align=right valign=center>&nbsp;<img onclick='closeTimePicker()' src='" + imagePath + "close.gif'  STYLE='cursor:hand'>&nbsp;</td></tr></table></td></tr><tr><td colspan=2><span id='timePickerContent'></span></td></tr></table></div>");
        refreshTimePicker(0);
    }

    var crossobj = (dom) ? document.getElementById("timepicker").style : ie ? document.all.timepicker : document.timepicker;
    var currentCtl

    function selectTime(ctl, ctl2) {
        var leftpos = 0
        var toppos = 0

        textCtl = ctl2;
        currentCtl = ctl
        currentCtl.src = imagePath + "timepicker2.gif";

        aTag = ctl
        do {
            aTag = aTag.offsetParent;
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
        } while (aTag.tagName != "BODY");
        crossobj.left = ctl.offsetLeft + leftpos
        crossobj.top = ctl.offsetTop + toppos + ctl.offsetHeight + 2
        crossobj.visibility = (dom || ie) ? "visible" : "show"
        hideElement('SELECT', document.getElementById("calendar"));
        hideElement('APPLET', document.getElementById("calendar"));
        bShow = true;
    }

    // hides <select> and <applet> objects (for IE only)
    function hideElement(elmID, overDiv) {
        if (ie) {
            for (i = 0; i < document.all.tags(elmID).length; i++) {
                obj = document.all.tags(elmID)[i];
                if (!obj || !obj.offsetParent) {
                    continue;
                }
                // Find the element's offsetTop and offsetLeft relative to the BODY tag.
                objLeft = obj.offsetLeft;
                objTop = obj.offsetTop;
                objParent = obj.offsetParent;
                while (objParent.tagName.toUpperCase() != "BODY") {
                    objLeft += objParent.offsetLeft;
                    objTop += objParent.offsetTop;
                    // objParent = objParent.offsetParent;
                }
                objHeight = obj.offsetHeight;
                objWidth = obj.offsetWidth;
                if ((overDiv.offsetLeft + overDiv.offsetWidth) <= objLeft);
                else if ((overDiv.offsetTop + overDiv.offsetHeight) <= objTop);
                else if (overDiv.offsetTop >= (objTop + objHeight + obj.height));
                else if (overDiv.offsetLeft >= (objLeft + objWidth));
                else {
                    obj.style.visibility = "hidden";
                }
            }
        }
    }

    //unhides <select> and <applet> objects (for IE only)
    function showElement(elmID) {
        if (ie) {
            for (i = 0; i < document.all.tags(elmID).length; i++) {
                obj = document.all.tags(elmID)[i];
                if (!obj || !obj.offsetParent) {
                    continue;
                }
                obj.style.visibility = "";
            }
        }
    }

    function closeTimePicker() {
        crossobj.visibility = "hidden"
        showElement('SELECT');
        showElement('APPLET');
        currentCtl.src = imagePath + "timepicker.gif"
    }

    document.onkeypress = function hideTimePicker1() {
        if (event.keyCode == 27) {
            if (!bShow) {
                closeTimePicker();
            }
        }
    }

    function isDigit(c) {

        return ((c == '0') || (c == '1') || (c == '2') || (c == '3') || (c == '4') || (c == '5') || (c == '6') || (c == '7') || (c == '8') || (c == '9'))
    }

    function isNumeric(n) {

        num = parseInt(n, 10);

        return !isNaN(num);
    }

    function padZero(n) {
        v = "";
        if (n < 10) {
            return ('0' + n);
        }
        else {
            return n;
        }
    }

    function validateDatePicker(ctl) {

        t = ctl.value.toLowerCase();
        t = t.replace(" ", "");
        t = t.replace(".", ":");
        t = t.replace("-", "");

        if ((isNumeric(t)) && (t.length == 4)) {
            t = t.charAt(0) + t.charAt(1) + ":" + t.charAt(2) + t.charAt(3);
        }

        var t = new String(t);
        tl = t.length;

        if (tl == 1) {
            if (isDigit(t)) {
                ctl.value = t + ":00 am";
            }
            else {
                return false;
            }
        }
        else if (tl == 2) {
            if (isNumeric(t)) {
                if (parseInt(t, 10) < 13) {
                    if (t.charAt(1) != ":") {
                        ctl.value = t + ':00 am';
                    }
                    else {
                        ctl.value = t + '00 am';
                    }
                }
                else if (parseInt(t, 10) == 24) {
                    ctl.value = "0:00 am";
                }
                else if (parseInt(t, 10) < 24) {
                    if (t.charAt(1) != ":") {
                        ctl.value = (t - 12) + ':00 pm';
                    }
                    else {
                        ctl.value = (t - 12) + '00 pm';
                    }
                }
                else if (parseInt(t, 10) <= 60) {
                    ctl.value = '0:' + padZero(t) + ' am';
                }
                else {
                    ctl.value = '1:' + padZero(t % 60) + ' am';
                }
            }
            else {
                if ((t.charAt(0) == ":") && (isDigit(t.charAt(1)))) {
                    ctl.value = "0:" + padZero(parseInt(t.charAt(1), 10)) + " am";
                }
                else {
                    return false;
                }
            }
        }
        else if (tl >= 3) {

            var arr = t.split(":");
            if (t.indexOf(":") > 0) {
                hr = parseInt(arr[0], 10);
                mn = parseInt(arr[1], 10);

                if (t.indexOf("pm") > 0) {
                    mode = "pm";
                }
                else {
                    mode = "am";
                }

                if (isNaN(hr)) {
                    hr = 0;
                } else {
                    if (hr > 24) {
                        return false;
                    }
                    else if (hr == 24) {
                        mode = "am";
                        hr = 0;
                    }
                    else if (hr > 12) {
                        mode = "pm";
                        hr -= 12;
                    }
                }

                if (isNaN(mn)) {
                    mn = 0;
                }
                else {
                    if (mn > 60) {
                        mn = mn % 60;
                        hr += 1;
                    }
                }
            } else {

                hr = parseInt(arr[0], 10);

                if (isNaN(hr)) {
                    hr = 0;
                } else {
                    if (hr > 24) {
                        return false;
                    }
                    else if (hr == 24) {
                        mode = "am";
                        hr = 0;
                    }
                    else if (hr > 12) {
                        mode = "pm";
                        hr -= 12;
                    }
                }

                mn = 0;
            }

            if (hr == 24) {
                hr = 0;
                mode = "am";
            }
            ctl.value = hr + ":" + padZero(mn) + " " + mode;
        }
    }




    function dateValidation() {

        var obj = document.getElementById("<%=txtReportedDate.ClientID%>");

        var jsDay = obj.value.split("/")[0];
        var jsMonth = obj.value.split("/")[1];
        var jsYear = obj.value.split("/")[2];

        var finaldate = new Date(jsYear, jsMonth - 1, jsDay);
        var today = new Date();

        if (jsDay != "") {

            if (jsDay != finaldate.getDate()) {

                alert('Day is not valid!');
                return false;
            }
        }





        if (jsYear < 1900) {
            alert('Year must be greater than 1900.');
            return false;
        }



        if (finaldate == 'undefined') {
            alert("you have entered invalid date!");
            return false;
        }
    }
    function CheckForPastDate(sender, args) {

        var selectedDate = new Date();

        selectedDate = sender._selectedDate;

        var todayDate = new Date();

        if (selectedDate.getDateOnly() > todayDate.getDateOnly()) {

            sender._selectedDate = todayDate;
            sender._textbox.set_Value(sender._selectedDate.format(sender._format));

            alert("Date Cannot be in the future");
            //            document.getElementById("<%= txtReportedDate.ClientID %>").value = '';
        }
    }


    function refreshParent() {
        window.opener.location.href = window.opener.location.href;
        if (window.opener.progressWindow) {
            window.opener.progressWindow.close()
        }
        window.close();
    }
  </script>
  
  
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr><td>
 <asp:UpdatePanel ID="CategoryPanal1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel>
 
 </td></tr>
 <tr><td>


    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;New Ticket</td>
           
    </tr>
   
    <tr style="padding-top:17px;"><td>
    <asp:UpdatePanel ID="CategoryPanal2" runat="server">
<ContentTemplate>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td width="10%">&nbsp;&nbsp;Call type</td>
    <td width="18%" align="left"><asp:DropDownList Width="170px" ID="drpRequestType" 
            runat="server">
    
    </asp:DropDownList></td>
    <td width="10%">Mode</td>
    <td width="25%" align="left">
     <asp:DropDownList ID="drpMode" Width="170px" runat="server">
    </asp:DropDownList>
    
    </td>
    </tr>
    <tr>
    <td width="10%">&nbsp;&nbsp;Status</td>
    <td width="18%" align="left"><asp:DropDownList Width="170px" ID="drpStatus" runat="server">
    
    </asp:DropDownList></td>
    <td width="10%">Priority</td>
    <td width="25%" align="left">
   <asp:DropDownList ID="drpPriority" Width="170px" runat="server">
     
    </asp:DropDownList>
    </td>
    </tr>
    
    </table>
  
    </ContentTemplate>
</asp:UpdatePanel>
    
    </td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Requester Details</td>
           
    </tr>
   
    <tr style="padding-top:17px;">
    <td>
     <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td width="10%"><font class="mandatory">*</font>Requester Name</td>
    <td width="18%" align="left">
    <asp:TextBox ID="txtUsername" Width="165px"  runat="server" AutoPostBack="true" ontextchanged="txtUsername_TextChanged" 
             ></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValUserName" runat="server" ControlToValidate="txtUsername" ForeColor="Red" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator></td>
    <td visible="false" width="10%">Reported Date</td>
    <td width="25%" visible="false" align="left">
  <%--  <asp:TextBox ID="txtassignasset" Width="165px"  runat="server" ReadOnly ="true"></asp:TextBox>&nbsp;--%>
    <%--<asp:ImageButton ID="imgselectasset" CausesValidation="false" runat="server" 
        ImageUrl="~/images/Searchlogo.jpg" 
            OnClientClick="javascript:window.open('SelectAsset.aspx','popupwindow','width=770,height=590,left=380,top=230,Scrollbars=yes');"/>--%>
           
       <asp:TextBox ID="txtReportedDate" runat="server" MaxLength="10" Width="180px" 
                                        Enabled="false" 
            Font-Names="verdana,arial,helvetica,sans-serif"></asp:TextBox>

       
       <asp:Image ID="imgCal" runat="server" ImageUrl="../images/cal.gif" />
       <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" Animated="true" PopupButtonID="imgCal" TargetControlID="txtReportedDate" Enabled="True" OnClientDateSelectionChanged="CheckForPastDate" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtReportedDate"
       ErrorMessage="(dd/mm/yyyy)" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
        Display="Dynamic"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Date Required"
           ControlToValidate="txtReportedDate"  Style="text-align: justify"
         Display="Dynamic"></asp:RequiredFieldValidator>
    </td>
    
    </tr>
    <tr>
    <td width="10%" valign="top"><font class="mandatory">*</font>Email</td>
    <td width="18%"  align="left">
   <asp:TextBox ID="txtEmail" Width="165px"  runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Enter Email"></asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator ID="regExtxtEmailId" runat="server" EnableClientScript="true" ControlToValidate="txtEmail" ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ErrorMessage="Enter Valid Email-Id"></asp:RegularExpressionValidator></td>
  <td>
      <asp:Label ID="Label6" runat="server" Text="Reported Time"></asp:Label>
       
    &nbsp;</td>
    <td>
     
     
       
       
   <%--<asp:TextBox ID="timepicker" Text="12:00 am" runat="server"  onblur="javascript:validateDatePicker(this);"></asp:TextBox>--%>
    
   <%--<img src="~/images/timepicker.gif" id="imgTime" runat="server" onclick="javascript:selectTime(this,ctl00_ContentPlaceHolder1_txtTime1);" />--%>
   <%--<img src="~/images/timepicker.gif" id="imgTime" runat="server" alt="" onclick="selectTime(this,ctl00_ContentPlaceHolder1_timepicker)" />--%>
        <asp:DropDownList 
            ID="drpTimeHours" runat="server" Height="16px" Width="38px">
        </asp:DropDownList>
        <asp:Label ID="Label7" runat="server" Text=":"></asp:Label>
        <asp:DropDownList ID="drpTimeMin" runat="server" Height="16px" Width="39px">
        </asp:DropDownList>
        
        </td>
    </tr>
   </table> 
    </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
       <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Other Details</td>
         </tr>
       
         <tr style="padding-top:17px;">
         <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
         <tr>
    <td><font class="mandatory">*</font>Owner</td>
    <td align="left">
    <asp:DropDownList ID="drpCustomer" Width="170px" AutoPostBack="true" runat="server" 
            onselectedindexchanged="drpCustomer_SelectedIndexChanged" >
    
    </asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpCustomer" runat="server" EnableClientScript="true" ControlToValidate="drpCustomer"  ErrorMessage="Select Customer"  InitialValue="0"></asp:RequiredFieldValidator></td>
    <td><font class="mandatory">*</font>Distributer</td>
    <td align="left">
    <asp:DropDownList ID="drpSite" Width="170px" AutoPostBack="true" runat="server" 
            onselectedindexchanged="drpSite_SelectedIndexChanged">
    
    </asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="true" ControlToValidate="drpSite"  ErrorMessage="Select Site"  InitialValue="0"></asp:RequiredFieldValidator></td>
    </tr>
          <tr>
    <td width="10%">&nbsp;&nbsp;Category</td>
    <td width="18%" align="left">
    <asp:DropDownList ID="drpCategory" Width="170px" AutoPostBack="true" runat="server" onselectedindexchanged="drpCategory_SelectedIndexChanged">
            
     
    </asp:DropDownList></td>
    <td width="10%">SubCategory</td>
    <td width="25%" align="left">
    <asp:DropDownList ID="drpSubcategory" Width="170px" runat="server" 
         AutoPostBack="true"    onselectedindexchanged="drpSubcategory_SelectedIndexChanged">
    
    </asp:DropDownList>
    </td>
    </tr>
     <%--<tr>
    <td >&nbsp;&nbsp;Technician</td>
    <td align="left">
    </td>
    <td >&nbsp;</td>
    <td  align="left">
    &nbsp;
    </td>
    </tr>--%>
    <tr>
    <td width="10%">&nbsp; Assign to</td>
     <td align="left" width="18%">
         <asp:DropDownList ID="drpTechnician" runat="server" Width="170px">
         </asp:DropDownList>
        </td>
        <td width="10%">
            Department</td>
        <td align="left" width="25%">
            <asp:DropDownList ID="drpDepartment" runat="server" Width="170px">
            </asp:DropDownList>
        </td>
    </tr>
    
    <tr>
    <td><font class="mandatory">*</font>Title</td>
     <td colspan="3"><asp:TextBox ID="txtTitle" runat="server" Width="350px"></asp:TextBox>
     <%--<asp:DropDownList ID="drpTitle" runat="server" Width="390px"></asp:DropDownList>--%>
     
     &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValSubject" runat="server" ControlToValidate="txtTitle" ForeColor="Red" ErrorMessage="Enter Title"></asp:RequiredFieldValidator></td>
    </tr>
    
     <tr style="padding-bottom:12px;">
    <td>&nbsp;&nbsp;Description</td>
     <td colspan="3"><asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="50px" runat="server" Width="620px"></asp:TextBox>
     
     
     </td>
    </tr>
    
         </table>
           </ContentTemplate>
          </asp:UpdatePanel>
         </td>
         
         </tr>
      
          <tr >
        <td  background="../images/tdimg.bmp" align="center">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnAdd" runat="server" Text="Add Request" 
                onclick="btnAdd_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnReset"  CausesValidation="false" runat="server" Text="Reset" 
                    onclick="btnReset_Click"/>
            </ContentTemplate>
          </asp:UpdatePanel>
            </td>
         </tr>
    
    
    
    <tr><td align="center"> 
   
       
        </td></tr>
       

 
        
   
   

</table>

 </td></tr>
 </table>
</asp:Content>

