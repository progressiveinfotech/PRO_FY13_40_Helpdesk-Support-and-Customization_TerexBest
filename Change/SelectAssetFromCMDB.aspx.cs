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

public partial class Change_SelectAssetFromCMDB : System.Web.UI.Page
{
    BLLCollection<Configuration_mst> col = new BLLCollection<Configuration_mst>();
    Configuration_mst ObjConfigurationmst = new Configuration_mst();
    Category_mst objcategory = new Category_mst();
    Vendor_mst ObjVendor = new Vendor_mst();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();

        }
    }
    public void BindGrid()
    {

       
        col = ObjConfigurationmst.Get_All();
        grdvwViewAsset.DataSource = col;
        grdvwViewAsset.DataBind();
        

    }
    protected void grdvwViewAsset_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            int id = Convert.ToInt16(e.Row.Cells[3].Text);

            objcategory = objcategory.Get_By_id(id);
            //objcategory = objcategory.Get_By_CategoryName();
            e.Row.Cells[3].Text = objcategory.CategoryName.ToString();
            int vendorid = Convert.ToInt16(e.Row.Cells[4].Text);
            ObjVendor = ObjVendor.Get_By_id(vendorid);
            e.Row.Cells[4].Text = ObjVendor.Vendorname.ToString();
        }
    }
    protected void grdvwViewAsset_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdvwViewAsset.PageIndex = e.NewPageIndex;
        BindGrid();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string serialno=txtAssets.Text.ToString();
        col = ObjConfigurationmst.Get_All_By_SerialNo(serialno);
        grdvwViewAsset.DataSource = col;
        grdvwViewAsset.DataBind();
        txtAssets.Text = "";
    }
    protected void btnAddAsset_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow gv in grdvwViewAsset.Rows)
        {

            string gvIDs;
            // Declare local variable deleteChkBxItem of Checkbox type to get the Checkbox Instance of Grid Row
            CheckBox deleteChkBxItem = (CheckBox)gv.FindControl("deleteRec");
            // If deleteChkBxItem is Checked then ,mapped Current site to this user
            if (deleteChkBxItem.Checked)
            {
                ListItem item = new ListItem();
                int varSiteid;
                int FlagCheckAsset = 0;
                // Get the Site Id from variable of Label type declare in GridView of grdvwSite 
                gvIDs = ((Label)gv.FindControl("assetid")).Text.ToString();


              
                ObjConfigurationmst = ObjConfigurationmst.Get_By_id(Convert.ToInt16(gvIDs));
                item.Text = ObjConfigurationmst.Serialno;
                item.Value =ObjConfigurationmst.Assetid.ToString();
                

                for (int i = listAsset.Items.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt16(listAsset.Items[i].Value) == ObjConfigurationmst.Assetid)
                    {
                        FlagCheckAsset = 1;

                    }


                }
                if (FlagCheckAsset == 0)
                { listAsset.Items.Add(item); }


            }

        }

    }
    protected void btnAsset_Click(object sender, EventArgs e)
    {
        string varAllAssetId = "";
        for (int i = listAsset.Items.Count - 1; i >= 0; i--)
        {

            varAllAssetId = varAllAssetId + listAsset.Items[i].Value + ",";



        }
        Session["AssetContract"] = varAllAssetId;
        string myScript;
        myScript = "<script language=javascript>javascript:refreshParent(); javascript:window.close();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }

}
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
  
