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
using System.Xml.Linq;

public partial class Contract_AddVendor : System.Web.UI.Page
{
    Vendor_mst ObjVendor = new Vendor_mst();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reqValVendor.ErrorMessage = Resources.MessageResource.errVendorname.ToString();
           
        }
    }
    protected void btnVendoradd_Click(object sender, EventArgs e)
    {
        ObjVendor.Vendorname = txtvendorname.Text;
        ObjVendor.Contactperson = txtcontactperson.Text;
        ObjVendor.Insert();

        string myScript;
        myScript = "<script language=javascript>javascript:refreshParent(); javascript:window.close();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }
   
    protected void ClearControl()
    {
        txtcontactperson.Text = "";
        txtvendorname.Text = "";
      

    }
}
