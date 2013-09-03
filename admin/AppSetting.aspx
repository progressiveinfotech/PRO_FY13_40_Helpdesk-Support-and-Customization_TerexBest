<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MasterAdmin.master" CodeFile="AppSetting.aspx.cs" Inherits="admin_AppSetting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
<td>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td class="tdsubheading" align="left">

 <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
 <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Visible="true" ForeColor="Red"></asp:Label>
 <%--<asp:RegularExpressionValidator ID="regxtxtPassword" runat="server"  EnableClientScript="true"    ControlToValidate="txtPassword" ValidationExpression="(?=^.{5,15}$)(?=.*\W+)(?![.\n])(?=.*[a-zA-Z]).*$" ></asp:RegularExpressionValidator>--%>
 </ContentTemplate></asp:UpdatePanel> 
</td></tr>

    <tr>
    <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Edit Application Setting</td>
       <td width="80%" align="right" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;&nbsp;&nbsp;</td>
   </tr>
  </table> 
</td>
</tr>
<tr><td>
<asp:Panel ID="panelUserLogin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    </tr __designer:mapid="14e5">
    </tr>
    </tr __designer:mapid="43b">
    <tr style="padding-top:8px;"><td class="tdsubheading" width="17%"><font class="mandatory">
        *</font>Change ServerName</td>
        <td width="83%">
            <asp:TextBox ID="txtservername" runat="server"  Width="155px" MaxLength="50"></asp:TextBox>
             &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValUsername" runat="server" 
                ControlToValidate="txtservername" EnableClientScript="true" 
                ForeColor="Red" ErrorMessage="please enter server name"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td  class="tdsubheading"><font class="mandatory">*</font>Change Email Server</td>
        <td>
           
            <asp:TextBox ID="txtmailserver" runat="server" Width="155px"></asp:TextBox>
             &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValPassword" runat="server" 
                ControlToValidate="txtmailserver" EnableClientScript="true" 
                ForeColor="Red" ErrorMessage="please enter mail server name"></asp:RequiredFieldValidator></td>
    </tr>
     <tr>
        <td class="tdsubheading"><font class="mandatory">*</font>Change Admin Email Id</td>
        
         <td>
             <asp:TextBox ID="txtadminmailid" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
             &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtRetypePassword" runat="server" 
                 ControlToValidate="txtadminmailid" EnableClientScript="true" 
                 ForeColor="Red" ErrorMessage="please enter admin email id"></asp:RequiredFieldValidator><%--<asp:CompareValidator  ID="cmpPassw" runat="server" ControlToCompare="txtPassword"    EnableClientScript="true"     ControlToValidate="txtRetypePassword" 
                Operator="Equal" SetFocusOnError="true"></asp:CompareValidator>--%>
                 
                 </td>
    </tr>
    <tr style="padding-top:8px;">
        <td class="tdsubheading">
            <font class="mandatory">*</font>Change Level1EscalateMail</td>
        <td>
            <asp:TextBox ID="txtlevel1esc" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtFname" runat="server"  
                ControlToValidate="txtlevel1esc" EnableClientScript="true" ForeColor="Red" 
                ErrorMessage="please enter email for Level1 escalation"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="tdsubheading">
            <font class="mandatory">*</font>Change Level2EscalateMail</td>
        <td> <asp:TextBox ID="txtlevel2esc" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
          
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtLname" runat="server" 
                ControlToValidate="txtlevel2esc" EnableClientScript="true" ForeColor="Red" 
                ErrorMessage="please enter email for Level2 escalation"></asp:RequiredFieldValidator></td>
        <tr>
            <td class="tdsubheading">
                <font class="mandatory">*</font>Change Level3EscalateMail</td>
            <td>
                <asp:TextBox ID="txtlevel3esc" runat="server" Width="155px" MaxLength="50"></asp:TextBox>&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtlevel3esc" EnableClientScript="true" ForeColor="Red" 
                    ErrorMessage="please enter email for Level3 escalation"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Change Contact No</td>
            <td>
                <asp:TextBox ID="txtcontactno" runat="server" MaxLength="20" Width="155px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdsubheading">
                User Feedback Mode</td>
            <td>
                <asp:DropDownList ID="Ddlfeedbackmode" runat="server" Width="100px">
                <asp:ListItem Text="Default" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Call wise" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
      
    </tr>
    </tr>
    <tr>
        <td align="center" background="../images/tdimg.bmp" 
            style="color:White;font-weight:bold;">
            &nbsp;&nbsp;</td>
        <td align="left" background="../images/tdimg.bmp" 
            style="color:White;font-weight:bold;">
            &nbsp;
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Save" />
        </td>
    </tr>
    
   
   
    </table> 
    </ContentTemplate>
    </asp:UpdatePanel> 
    </asp:Panel>
</td></tr>
<tr><td>&nbsp;</td></tr>
</table> 
 
  

</asp:Content>
