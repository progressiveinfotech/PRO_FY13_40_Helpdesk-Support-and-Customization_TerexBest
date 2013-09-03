using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Text;

public partial class Master_MasterAsset : System.Web.UI.MasterPage
{
    Asset_mst objasset = new Asset_mst();
    Organization_mst objOrganization = new Organization_mst();
    UserLogin_mst objUser = new UserLogin_mst();
    ContactInfo_mst objContact = new ContactInfo_mst();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MembershipUser User = Membership.GetUser();
            objOrganization = objOrganization.Get_Organization();
            int userid = objUser.Get_By_UserName(User.UserName.ToString(), objOrganization.Orgid);
            if (userid != 0)
            {
                string userName;
                userName = User.UserName.ToString();
                if (Roles.IsUserInRole(userName, "admin"))
                {
                    panel1.Visible = true;
                }
                objContact = objContact.Get_By_id(userid);
                lblUser.Text = objContact.Firstname + "&nbsp;&nbsp;" + objContact.Lastname;
            }
        }
            Bind_Tree();
           
    }

    public void Bind_Tree()
    {
        XmlDataSource ds = new XmlDataSource();
        ds.EnableCaching = false;
        string path = Server.MapPath("..//Files//Asset.xml");
        ds.DataFile = path;
        Treeview1.DataSource = ds;
        Treeview1.DataBind();
    }

    protected void Treeview1_SelectedNodeChanged(object sender, EventArgs e)
    {
        int temp = 0;
        string node_name = Treeview1.SelectedNode.Value;
        ViewState["node_name"] = node_name;
        if (node_name != "Computers")
        {
            temp = 1;
            Session["temp"] = temp;
            Session["param_node"] = node_name;
            Response.Redirect("~/Asset/ViewAssetDetails.aspx");
        }
    }

    protected void lnkrefresh_Click(object sender, EventArgs e)
    {
        string[] filenames;
        filenames = Get_Data_Files();
        Write_Computer_List(filenames);
    }

    public void Write_Computer_List(string[] filenames)
    {
        XmlDocument xd = new XmlDocument();
        XmlDeclaration xdec = xd.CreateXmlDeclaration("1.0", "utf-8", null);
        xd.InsertBefore(xdec, xd.DocumentElement);

        XmlElement xeroot = xd.CreateElement("Computers");
        xd.AppendChild(xeroot);

        foreach (string K in filenames)
        {
            string fname;
            fname = K.ToString();
            //getSerialNo(fname);
            XmlElement xeComputer = xd.CreateElement("Computer");
            xeroot.AppendChild(xeComputer);
            XmlAttribute xa = xd.CreateAttribute("Name");
            xa.Value = K.ToString();
            xeComputer.Attributes.Append(xa);
        }
        xd.Save(Server.MapPath("..//Files//Asset.xml"));
    }

    public string[] Get_Data_Files()
    {
        string[] filenames;
        
        DirectoryInfo di = new DirectoryInfo("C://Asset//Data");
        
        FileInfo[] fi = di.GetFiles();
        int countfile = fi.GetLength(0);

        int i = 0;
        filenames = new string[countfile];
        foreach (FileInfo K in fi)
        {
            string[] fname = K.Name.Split(new char[] { '.' });
            filenames[i] = fname[0].ToString();
            i++;
        }
        return filenames;
    }

    protected void lnkSaveinventory_Click(object sender, EventArgs e)
    {
        try
        {
            SaveAssetInventory obj = new SaveAssetInventory();
            obj.SaveInventory();
            string myScript;
            myScript = "<script language=javascript>alert('Inventory of Assets has been Saved'); </script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        }
        catch (Exception ex)
        {
            string myScript;
            myScript = "<script language=javascript>alert('Error Occured ,While Saving the Inventory'); </script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        
        }
        
    }

    protected void btnSearchComputer_Click(object sender, ImageClickEventArgs e)
    {
        int count = 0;
        int temp = 0;
        count = objasset.Get_Asset_By_Cname(txtsearchcompname.Text.ToString());
        if (count != 0)
        {
            temp = 1;
            Session["temp"] = temp;
            Session["param_node"] = txtsearchcompname.Text.ToString();
            Response.Redirect("~/Asset/ViewAssetDetails.aspx");
        }
        else
        {
            string myScript;
            myScript = "<script language=javascript>alert('Computer not found!, Ensure that computer is in the Domain and User Login to the Domain.'); </script>";
            Page.RegisterClientScriptBlock("MyScript", myScript);
        }
    }
    protected void lnkAddAsset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Asset/AddAsset.aspx");
    }
    protected void lnkShowAsset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Asset/ViewAsset.aspx");
    }
    protected void lnkAssetToSiteMapping_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Asset/UserToAssetMapping.aspx");
    }
    protected void lnkhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Login/Default.aspx");
    }
}