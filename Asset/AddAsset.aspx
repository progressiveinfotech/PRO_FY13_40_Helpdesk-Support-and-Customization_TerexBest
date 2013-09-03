<%@ Page Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true" CodeFile="AddAsset.aspx.cs" Inherits="Asset_AddAsset" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            background-color: white;
            font-family: Tahoma;
            font-size: small;
            height: 25px;
        }
        .style2
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td>
        <asp:UpdatePanel ID="CategoryPanal1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel>
    </td>
    </tr>
 
    <tr>
    <td>
        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Computer Details
        </td>
        </tr>
    
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="CategoryPanal2" runat="server">
            <ContentTemplate>
            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td width="10%"><font class="mandatory">*</font>Computer Name
                </td>
                <td width="18%" align="left">
                    <asp:TextBox ID="txtcomputername" Width="165px"  runat="server" AutoPostBack="true" ></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="reqValComputerName" runat="server" ControlToValidate="txtcomputername" 
                    EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td width="10%">Domain</td>
                <td width="25%" align="left">
                    <asp:TextBox ID="txtdomain" Width="165px"  runat="server" AutoPostBack="true" ></asp:TextBox>
                </td>
                </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Product Details
        </td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td><font class="mandatory">*</font>Product Name</td>
                <td align="left">
                    <asp:TextBox ID="txtproductname" Width="165px"  runat="server"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="reqValProductName" runat="server" ControlToValidate="txtproductname" EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td><font class="mandatory">*</font>Product Manufacturer</td>
                <td align="left">
                    <asp:TextBox ID="txtproductmanufacture" Width="165px"  runat="server"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="reqValProductManufacturer" runat="server" ControlToValidate="txtproductmanufacture" EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                </tr>
                
                <tr>
                <td width="10%"><font class="mandatory">*</font>Serial Number</td>
                <td width="18%" align="left">   
                    <asp:TextBox ID="txtproductsno" Width="165px"  runat="server"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="reqValProductSerialno" runat="server" ControlToValidate="txtproductsno" EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td width="10%">Uuid</td>
                <td width="25%" align="left">
                    <asp:TextBox ID="txtuuid" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td >&nbsp;&nbsp;SKU Number</td>
                <td align="left">
                    <asp:TextBox ID="txtskuno" Width="165px"  runat="server"></asp:TextBox>
                </td>
                <td width="10%"></td>
                <td width="25%" align="left">
                    <asp:Label ID="lbldate" Text="null" Visible="false" runat="server"></asp:Label>
                </td>
                </tr>
    
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>  
    
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Processor Details
        </td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td><font class="mandatory">*</font>Processor Name</td>
                <td align="left">
                    <asp:TextBox ID="txtprocessorname" Width="165px"  runat="server"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="reqValProcessorname" runat="server" ControlToValidate="txtprocessorname" EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>Manufacturer</td>
                <td align="left">
                    <asp:TextBox ID="txtprocmanufacturer" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td width="10%">&nbsp;&nbsp;Speed</td>
                <td width="18%" align="left">
                    <asp:TextBox ID="txtspeed" Width="165px"  runat="server"></asp:TextBox>
                </td>
                <td width="10%">Family</td>
                <td width="25%" align="left">
                    <asp:TextBox ID="txtfamily" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                 <tr>
                <td >&nbsp;&nbsp;Model</td>
                <td align="left">
                    <asp:TextBox ID="txtmodel" Width="165px"  runat="server"></asp:TextBox>
                </td>
                <td >Stepping</td>
                <td align="left">
                    <asp:TextBox ID="txtstepping" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td >&nbsp;&nbsp;Max Speed</td>
                <td align="left">
                    <asp:TextBox ID="txtmaxspeed" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
    
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Memory Details
        </td>
        </tr>
        <tr style="padding-top:10px;">
        <td>
            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td width="10%">&nbsp;&nbsp;Physical Memory</td>
                <td width="18%" align="left">
                    <asp:TextBox ID="txtphysicalmemory" Width="165px"  runat="server" AutoPostBack="true"></asp:TextBox>
                </td>
                <td width="10%">Virtual Memory</td>
                <td width="25%" align="left">
                    <asp:TextBox ID="txtvirtualmemory" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td width="10%">&nbsp;&nbsp;Page File</td>
                <td width="18%" align="left">
                    <asp:TextBox ID="txtpagefile" Width="165px"  runat="server" AutoPostBack="true"></asp:TextBox>
                </td>
                </tr>
    
            </table> 
        </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Network Details
        </td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>&nbsp;&nbsp;Adapter Name</td>
                    <td align="left">
                        <asp:TextBox ID="txtadaptername" Width="165px"  runat="server"></asp:TextBox></td>
                    <td>MAC Address</td>
                    <td align="left">
                        <asp:TextBox ID="txtmacaddress" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                    <td width="10%">&nbsp;&nbsp;Link Speed</td>
                    <td width="18%" align="left">
                        <asp:TextBox ID="txtlinkspeed" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    <td width="10%">MTU</td>
                    <td width="25%" align="left">
                        <asp:TextBox ID="txtmtu" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    </tr>
                     <tr>
                    <td >&nbsp;&nbsp;Type</td>
                    <td align="left">
                        <asp:TextBox ID="txttype" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    <td >Protocol Name</td>
                    <td align="left">
                        <asp:TextBox ID="txtprotocol" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        &nbsp;&nbsp;IP Address
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtipaddress" runat="server" Width="165px"></asp:TextBox>
                    </td>
                    <td> Subnet Mask</td>
                    <td align="left">
                        <asp:TextBox ID="txtsubnet" runat="server" Width="165px"></asp:TextBox>
                    </td>
                    <tr>
                    <td> &nbsp;&nbsp;Gateway</td>
                    <td align="left">
                        <asp:TextBox ID="txtgateway" runat="server" Width="165px"></asp:TextBox>
                    </td>
                    </tr>
                </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
         
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Operating System Details
        </td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td>&nbsp;&nbsp;OS Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtosname" Width="165px"  runat="server"></asp:TextBox></td>
                        <td>Major Version</td>
                        <td align="left">
                            <asp:TextBox ID="txtmajorversion" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td width="10%">&nbsp;&nbsp;Minor Version</td>
                        <td width="18%" align="left">
                            <asp:TextBox ID="txtminorversion" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td width="10%">Build Number</td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="txtbuildno" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td >&nbsp;&nbsp;Add information</td>
                        <td align="left">
                            <asp:TextBox ID="txtaddinfo" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td >User Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtusername1" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td>
                            &nbsp;&nbsp;Reg Code
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtregcode" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        <td> Reg Organisation</td>
                        <td align="left">
                            <asp:TextBox ID="txtregorg" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        <tr>
                        <td> &nbsp;&nbsp;Reg To</td>
                        <td align="left">
                            <asp:TextBox ID="txtregto" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        <td>
                            Localization</td>
                        <td align="left">
                            <asp:TextBox ID="txtlocal" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td> &nbsp;&nbsp;Product Key</td>
                        <td align="left">
                            <asp:TextBox ID="txtprokey" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>

        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
        &nbsp;Physical Drive Details</td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td>&nbsp;&nbsp;Drive Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtdrivename" Width="165px"  runat="server"></asp:TextBox></td>
                        <td>Manufacturer</td>
                        <td align="left">
                            <asp:TextBox ID="txtmanufacturer" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td width="10%">&nbsp;&nbsp;Product Version</td>
                        <td width="18%" align="left">
                            <asp:TextBox ID="txtproductversion" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td width="10%">Product Id</td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="txtproductid" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td >&nbsp;&nbsp;Serial Number</td>
                        <td align="left">
                            <asp:TextBox ID="txtserialno" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td >Capacity</td>
                        <td align="left">
                            <asp:TextBox ID="txtcapacity" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
    
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"> &nbsp;Logical Drive Details</td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td>&nbsp;&nbsp;Drive Letter</td>
                        <td align="left">
                            <asp:TextBox ID="txtdriveletter" Width="165px"  runat="server"></asp:TextBox></td>
                        <td>Drive Type</td>
                        <td align="left">
                            <asp:TextBox ID="txtdrivetype" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td width="10%">&nbsp;&nbsp;Total Bytes</td>
                        <td width="18%" align="left">
                            <asp:TextBox ID="txttotalbytes" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td width="10%">Free Bytes</td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="txtfreebytes" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td >&nbsp;&nbsp;File System Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtfilesysname" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
    
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>  
         
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Details" OnClick="btnAdd_click"/>&nbsp;&nbsp;
                    <asp:Button ID="btnReset"  CausesValidation="false" runat="server" Text="Reset" OnClick="btnReset_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr> 
        <tr><td align="center"></td></tr>

    </table>
    </td>
    </tr>
</table>
</asp:Content>

