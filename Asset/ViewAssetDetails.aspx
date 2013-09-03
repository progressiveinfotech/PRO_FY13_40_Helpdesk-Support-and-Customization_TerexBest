<%@ Page Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true" CodeFile="ViewAssetDetails.aspx.cs" Inherits="Asset_ViewAssetDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 22px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>&nbsp;&nbsp;<b>Asset Id :</b>&nbsp;
                <asp:Label ID="lblAssetId" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  bgcolor="#667c97" class="style1" >
            &nbsp;&nbsp;
                <asp:LinkButton ID="imgcomputer" CausesValidation="false" runat="server" Text="General"
                    Font-Bold="true" ForeColor="White" Font-Size="Small" onclick="imgcomputer_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="imgproduct" CausesValidation="false"  runat="server" Text="Hardware"
                    Font-Bold="true" ForeColor="White" Font-Size="Small" onclick="imgproduct_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="imgnetwork" CausesValidation="false" runat="server" Text="Network"
                    Font-Bold="true" ForeColor="White" Font-Size="Small" onclick="imgnetwork_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="Imageoperatingsystem" CausesValidation="false" Text="Operating System"
                    Font-Bold="true" ForeColor="White" Font-Size="Small" runat="server" onclick="Imageoperatingsystem_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="updatepanel1" runat="server">
                                <ContentTemplate>
                                    
                                        <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">                
                                            <tr>
                                                <td align="right"><b>Last Inventory</b>&nbsp;
                                                    <asp:Label ID="lbllastinventory" Font-Bold="true" Font-Size="Small" Text="" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblassetname" Font-Bold="true" Font-Size="Medium" Text="" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr><td>&nbsp;</td></tr>
                                            <tr>
                                                <td>
                                                    
                                                    
                                                    
                                                    <asp:Panel ID="Panproduct" Visible="false" runat="server">
                                                        <table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">
                                                            <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblProductDetails" Text="Product" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Product Name</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblproduct" runat="server" ></asp:Label>
                                                                </td>
                                                                <td width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Product Manufacturer</b></td>
                                                                <td width="20%" align="left">
                                                                    <asp:Label ID="lblproductmanu" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Serial No</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblserialno" runat="server" ></asp:Label>
                                                                </td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Uuid</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblUuid" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>SKU No</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblskuno" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblProcessorDetails" Text="Processor(s)" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td valign="top" colspan="2">
                                                                    <asp:PlaceHolder ID="Processor_PlaceHolder" runat="server"></asp:PlaceHolder>
                                                                </td>
                                                               <td width="15%" align="left" valign="top">
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbldisk" Text="Disk Resources" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
                                                                    <asp:PlaceHolder ID="Disk_PlaceHolder" runat="server"></asp:PlaceHolder>  
                                                                </td>
                                                                <td width="20%">&nbsp;&nbsp;</td>                                                                
                                                            </tr>
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMemoryDetails" Text="Memory" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Physical Memry</b></td>
                                                                <td width="18%" align="left"><asp:Label ID="lblphysical" runat="server" ></asp:Label></td>
                                                           </tr>
                                                           <tr>     
                                                                <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Logical Memory</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lbllogical" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Page File</b></td>
                                                                <td  align="left"><asp:Label ID="lblpagefile" runat="server" ></asp:Label></td>
                                                            </tr> 
                                                              
                                                        </table>
                                                    </asp:Panel> 
                                                    
                                                    
                                                    
                                                    
                                                    <asp:Panel ID="PanHardware" Visible="false" runat="server">
                                                        <table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">
                                                            <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblProductDetails1" Text="Product" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Product Name</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblproduct1" runat="server" ></asp:Label>
                                                                </td>
                                                                <td width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Product Manufacturer</b></td>
                                                                <td width="25%" align="left">
                                                                    <asp:Label ID="lblproductmanu1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Serial No</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblserialno1" runat="server" ></asp:Label>
                                                                </td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Uuid</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblUuid1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>SKU No</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblskuno1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblProcessorDetails1" Text="Processor" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            
                                                            <tr>
                                                                <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Processor Name</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblprocessor1" runat="server" ></asp:Label>
                                                                </td>
                                                                <td width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Manufacturer</b></td>
                                                                <td width="25%" align="left">
                                                                    <asp:Label ID="lblmenufec1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Speed</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblspeed1" runat="server" ></asp:Label>
                                                                </td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Family</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblfamily1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Model</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblmodel1" runat="server" ></asp:Label>
                                                                </td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Stepping</b></td>
                                                                <td  align="left">
                                                                <asp:Label ID="lblstepping1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Max Speed</b></td>
                                                                <td  align="left"><asp:Label ID="lblmaxspeed1" runat="server" ></asp:Label></td>
                                                            </tr>
                                                            
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMemoryDetails1" Text="Memory" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Physical Memry</b></td>
                                                                <td width="18%" align="left"><asp:Label ID="lblphysical1" runat="server" ></asp:Label></td>
                                                                <td width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Logical Memory</b></td>
                                                                <td width="25%" align="left">
                                                                    <asp:Label ID="lbllogical1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Page File</b></td>
                                                                <td  align="left"><asp:Label ID="lblpagefile1" runat="server" ></asp:Label></td>
                                                            </tr> 
                                                              
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPhysicalMemrory1" Text="PhysicalDrive" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                           <tr>
                                                                <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Drive Name</b></td>
                                                                <td width="18%" align="left"><asp:Label ID="lbldrivename1" runat="server" ></asp:Label></td>
                                                                <td width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Manufacturer</b></td>
                                                                <td width="25%" align="left">
                                                                    <asp:Label ID="lbldrivemanufec1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Product Version</b></td>
                                                                <td  align="left"><asp:Label ID="lblproductversion1" runat="server" ></asp:Label></td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Product Id</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblproid1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Serial No</b></td>
                                                                <td  align="left"><asp:Label ID="lbldriveserialno1" runat="server" ></asp:Label></td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Capacity</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblcapacity1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLogicalDriveDetails1" Text="LogicalDrive" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                           <tr>
                                                                <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Drive Letter</b></td>
                                                                <td width="18%" align="left"><asp:Label ID="lbldriveletter1" runat="server" ></asp:Label></td>
                                                                <td width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Drive Type</b></td>
                                                                <td width="25%" align="left">
                                                                    <asp:Label ID="lbldrivetype1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                                <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Total Bytes</b></td>
                                                                <td  align="left"><asp:Label ID="lbltotalbytes1" runat="server" ></asp:Label></td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Free Bytes</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblfreebytes1" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>File System Name</b></td>
                                                                <td  align="left"><asp:Label ID="lblfilesystemname1" runat="server" ></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>



                                                    
                                                    
                                                    <asp:Panel ID="Pannetwork" Visible="false" runat="server">
                                                        <table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">

                                                            <tr>
                                                                <td width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Adaptor Name</b></td>
                                                                <td width="35%" align="left"><asp:Label ID="lbladaptor" runat="server" ></asp:Label></td>
                                                                <td width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>MAC Address</b></td>
                                                                <td width="35%" align="left">
                                                                    <asp:Label ID="lblmac" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Link Speed</b></td>
                                                                <td  width="18%" align="left"><asp:Label ID="lbllinkspeed" runat="server" ></asp:Label></td>
                                                                <td  width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>MTU</b></td>
                                                                <td width="25%" align="left">
                                                                    <asp:Label ID="lblmtu" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Type</b></td>
                                                                <td  align="left"><asp:Label ID="lbltype" runat="server" ></asp:Label></td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Protocol Name</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblprotocol" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>IP Address</b></td>
                                                                <td  align="left"><asp:Label ID="lblipaddress" runat="server" ></asp:Label></td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Subnet Mask</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblsubnet" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Gatway</b></td>
                                                                <td  align="left"><asp:Label ID="lblgatway" runat="server" ></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel> 
                                                    
                                                    
                                                    <asp:Panel ID="Pannetwork1" Visible="false" runat="server">
                                                        <table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">

                                                            <tr>
                                                                <td style="height: 15px">
                                                                    <asp:PlaceHolder ID="Network_PlaceHolder" runat="server"></asp:PlaceHolder>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>


                                                    <asp:Panel ID="Panos" Visible="false" runat="server">
                                                        <table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">
                                                            <tr>
                                                                <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>OS Name</b></td>
                                                                <td width="18%" align="left"><asp:Label ID="lblosname" runat="server" ></asp:Label></td>
                                                                <td width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Major Version</b></td>
                                                                <td width="25%" align="left">
                                                                    <asp:Label ID="lblmajorversion" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Minor Version</b></td>
                                                                <td  align="left"><asp:Label ID="lblminorversion" runat="server" ></asp:Label></td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Build No</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblbuildno" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Add information</b></td>
                                                                <td  align="left"><asp:Label ID="lbladdinfo" runat="server" ></asp:Label></td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>User Name</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblusername" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Reg Code</b></td>
                                                                <td  align="left"><asp:Label ID="lblregcode" runat="server" ></asp:Label></td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Reg Organization</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lblregorg" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Reg To</b></td>
                                                                <td  align="left"><asp:Label ID="lblregto" runat="server" ></asp:Label></td>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Localization</b></td>
                                                                <td  align="left">
                                                                    <asp:Label ID="lbllocalization" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Product Key</b></td>
                                                                <td  align="left"><asp:Label ID="lblproductkey" runat="server" ></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel> 
                                                    
                                                    
                                                    
                                                    <asp:Panel ID="pancomputer" Visible="false" runat="server">
                                                        <table align="left" width="45%" cellpadding="2" cellspacing="1" border="0">
                                                            
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblgenos" Text="Operating System" Font-Size="Small" Font-Underline="true" Font-Bold="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>OS Name</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblgenosname" runat="server" ></asp:Label>
                                                                </td>
                                                                
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Minor Version</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblgenmv" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Localization</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblgenlocal" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Reg Organisation</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblgenorg" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;</td>
                                                                <td style="width:24%; height: 15px;" align="left">
                                                                    <asp:LinkButton ID="lnkos" runat="server" Text="More Info..."  Font-Underline="true" ForeColor=blue  OnClick="lnkos_Click"></asp:LinkButton>
                                                                </td>
                                                           </tr>
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>AssetId</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblassetid1" runat="server" ></asp:Label>
                                                                </td>
                                                                
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Computer Name</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblcomputername" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Created Date</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lblcreateddate" runat="server" ></asp:Label>
                                                                </td>
                                                                
                                                            </tr> 
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Domain Name</b></td>
                                                                <td width="18%" align="left">
                                                                    <asp:Label ID="lbldomain" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table align="left" width="50%" cellpadding="2" cellspacing="1" border="0">
                                                            <tr><td>&nbsp;</td></tr>
                                                           <tr>
                                                                <td> 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblgenNetwork" Text="Network" Font-Size="Small" Font-Bold="true" Font-Underline="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="13%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Adaptor</b></td>
                                                                <td width="30%" align="left">
                                                                    <asp:Label ID="lblgenadaptor" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="13%" valign="top" colspan="2">
                                                                    <asp:PlaceHolder ID="phadaptor" runat="server"></asp:PlaceHolder>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="13%">&nbsp;&nbsp;</td>
                                                                <td style="width:26%; height: 15px;" align="left">
                                                                    <asp:LinkButton ID="lnkadaptor" runat="server" Text="More Info..."  Font-Underline="true" ForeColor=blue  OnClick="lnkadaptor_Click"></asp:LinkButton>
                                                                </td>
                                                           </tr>
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr>
                                                                <td > 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblgenProduct" Text="Hardware" Font-Size="Small" Font-Bold="true" Font-Underline="true" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Product</b></td>
                                                                <td width="24%" align="left">
                                                                    <asp:Label ID="lblgenprodname" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblProc" runat="server" Text="Processor" Font-Bold="true" Font-Underline="true"></asp:Label> </td>
                                                                <td width="24%" align="left">
                                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblgenprocname" runat="server" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" colspan="2">
                                                                    <asp:PlaceHolder ID="phprocessor" runat="server"></asp:PlaceHolder>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;&nbsp;</td>
                                                                <td style="width:24%; height: 15px;" align="left">
                                                                    <asp:LinkButton ID="lnkhrd" runat="server" Text="More Info..."  Font-Underline="true" ForeColor=blue  OnClick="lnkhrd_Click"></asp:LinkButton>
                                                                </td>
                                                                
                                                           </tr>
                                                        </table>
                                                        
                                                    </asp:Panel>
                                                    
                                                </td>
                                            </tr>
                                        </table>               
                                    
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
    </table>
</asp:Content>

