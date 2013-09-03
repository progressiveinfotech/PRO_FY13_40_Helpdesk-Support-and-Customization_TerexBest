<%@ Page Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true" CodeFile="ViewAsset.aspx.cs" Inherits="Asset_ViewAsset" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td>
                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"> &nbsp;View Asset</td>
            
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                        <td class="tdsubheading" align="left">
                            &nbsp;&nbsp; Search By Name &nbsp;&nbsp;
                            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click"  />
                        </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                        <td align="center" width="80%">
                            <asp:GridView ID="grdvwViewAsset" runat="server" AllowPaging="true" 
                                OnPageIndexChanging="grdvwViewAsset_PageIndexChanging" OnRowCommand="grdvwViewAsset_RowCommand" 
                                OnRowCreated="grdvwViewAsset_RowCreated" OnRowEditing="grdvwViewAsset_RowEdit"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="0" CellSpacing="0" 
                                CssClass="grid-view" FooterStyle-BackColor="Red" FooterStyle-Font-Bold="true" 
                                ForeColor="Black" GridLines="Vertical" 
                                PageSize="20" 
                                ShowFooter="true" Width="984px">
                                <FooterStyle BackColor="white" />
                                <RowStyle BackColor="white" />
                                <AlternatingRowStyle BackColor="Silver" />
                                    <Columns>
                                        <asp:BoundField DataField="assetid" HeaderText="Asset Id" ReadOnly="true" />
                                        <asp:BoundField DataField="computername" HeaderText="Computer Name" ReadOnly="true" />
                                        <asp:BoundField DataField="domain" HeaderText="Domain Name" ReadOnly="true" />
                                        <asp:CommandField CausesValidation="false" ShowEditButton="true" EditText="View Details" HeaderText="ViewDetails" />
                                    </Columns>
                                <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
                            </asp:GridView>
                        </td>
                        </tr>
                    </table> 
                </ContentTemplate> 
            </asp:UpdatePanel> 
        </td> 
        </tr> 
    </table> 
</asp:Content>

