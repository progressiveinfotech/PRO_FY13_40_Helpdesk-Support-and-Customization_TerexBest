<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerFeedback.aspx.cs" Inherits="WithoutLoginPageAccess_CustomerFeedback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
      <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
    <title>Customer Feedback</title>
    <script language="javascript" Type="text/javascript" >
     function refreshParent() 
        {
            window.opener.location.href = window.opener.location.href;
            if (window.opener.progressWindow)
	        {
                window.opener.progressWindow.close();
            }
                window.close();
        }
        function CloseWindow()

{

window.opener = self;

window.close();



}


    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
 &nbsp;<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    
  
    
   
   <tr><td class="tdheader"> <asp:Label ID="lblapprove" runat="server" ></asp:Label>
 <%-- &nbsp;Kindly provide your valuable feedback by choosing one of the Options.&nbsp;&nbsp;&nbsp;--%>
       <asp:Label ID="lblApproved" runat="server" Text="Kindly provide your valuable feedback by choosing one of the Options"></asp:Label>
       <br />
       <br />
       <%--<asp:Label ID="lblapprove0" runat="server" ></asp:Label>
       &nbsp;feedback save.&nbsp;&nbsp;&nbsp;
       <br />
       <br />--%>
 </td></tr>
    
 <tr>
 <td><table><tr><td><asp:Label ID="labGood" runat="server" Text="Good"></asp:Label></td><td><asp:RadioButton  ID="satisfiedrdbutton" 
         runat="server" GroupName="id" 
         oncheckedchanged="satisfiedrdbutton_CheckedChanged" AutoPostBack="true"  /></td></tr>
 <tr><td><asp:Label ID="labVeryGood" runat="server" Text="Very Good"></asp:Label></td><td><asp:RadioButton  ID="verysatisfied" runat="server" 
         GroupName="id" AutoPostBack="true" 
         oncheckedchanged="verysatisfied_CheckedChanged" /></td></tr>
 <tr><td><asp:Label ID="labAverage" runat="server" Text="Average"></asp:Label></td><td><asp:RadioButton  ID="Rddisatisfied" runat="server" 
         GroupName="id" AutoPostBack="true" 
         oncheckedchanged="Rddisatisfied_CheckedChanged"/></td></tr>
 <tr><td><asp:Label ID="labPoor" runat="server" Text="Poor"></asp:Label></td><td><asp:RadioButton  ID="Rdverydissatisfied" runat="server" 
         GroupName="id" AutoPostBack="true" 
         oncheckedchanged="Rdverydissatisfied_CheckedChanged" /></td></tr>
 <tr id="Rmk" runat="server" visible="false"><td><asp:Label ID="lblRemark" runat="server" Text="Remark"></asp:Label></td><td>
     <asp:TextBox ID="TextRmk" runat="server" TextMode="MultiLine" 
         ontextchanged="TextRmk_TextChanged"></asp:TextBox>
  </td></tr></table>
 
 <td align="center">
<asp:UpdatePanel ID="AddSolution1" runat="server">
     <ContentTemplate>
     
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr>
 <td><table>
 
 
 </table>
  &nbsp;<asp:Label ID="Lblmsg" ForeColor="Red" Visible="false" runat="server"></asp:Label></td>
 <td align="center">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
      
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr>
 <td><table></table>
  &nbsp; </td>
 <td align="center">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <ContentTemplate>
     
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr>
 <td><table></table>
 </td>
 <td align="center">
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
     <ContentTemplate>
     
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr><td>&nbsp;</td></tr>
 
 <tr><td class="tdheader" align="center">

 <asp:Button ID="btnFeedback" runat="server" Text="Vote Feedback" OnClick="btnFeedback_Click"   />
<%--<asp:Button ID="btnreject" runat="server" Text="Reject" OnClick="btnreject_Click" />--%>
 <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:window.close();" />--%>

     <br />
&nbsp;<br />
       <asp:Label ID="Lblmsg0" ForeColor="Red" Visible="false" runat="server"></asp:Label>

 </td></tr>
  
     
 </table>
    <div>
    
    </div>
    </form>
</body>
</html>
