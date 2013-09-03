﻿using System;
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

public partial class admin_AddConfigurableitems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropCategory();
        }
    }
    Category_mst objCategory = new Category_mst();
    ConfigurableItems_mst Objconfigurableitems = new ConfigurableItems_mst();
    BLLCollection<Category_mst> colCategory = new BLLCollection<Category_mst>();
    int id;
    #region Bind the Items
    protected void BindDropCategory()
    {
        colCategory = objCategory.Get_All();
        drpitem.DataTextField = "categoryname";
        drpitem.DataValueField = "categoryid";
        drpitem.DataSource = colCategory;
        drpitem.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Item------";
        item.Value = "0";
        drpitem.Items.Add(item);
        drpitem.SelectedValue = "0";


    }



   
    #endregion
    #region  Saving the parameters value
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt16(drpitem.SelectedValue);
        Objconfigurableitems = Objconfigurableitems.Get_By_id(25);
        if (Objconfigurableitems.Itemid != 0)
        {
            lblmessage.Visible = true;
            lblmessage.Text = "You have already configured this item.";
        }
        else
        {
            Objconfigurableitems.Itemid = Convert.ToInt16(drpitem.SelectedValue);
            Objconfigurableitems.Param1 = txtparam1.Text.ToString();
            Objconfigurableitems.Param2 = txtparam2.Text.ToString();
            Objconfigurableitems.Param3 = txtparam3.Text.ToString();
            Objconfigurableitems.Param4 = txtparam4.Text.ToString();
            Objconfigurableitems.Param5 = txtparam5.Text.ToString();
            Objconfigurableitems.Param6 = txtparam6.Text.ToString();
            Objconfigurableitems.Param7 = txtparam7.Text.ToString();
            Objconfigurableitems.Param8 = txtparam8.Text.ToString();
            Objconfigurableitems.Param9 = txtparam9.Text.ToString();
            Objconfigurableitems.Param10 = txtparam10.Text.ToString();
            Objconfigurableitems.Param11 = "";
            Objconfigurableitems.Param12 = "";
            Objconfigurableitems.Param13 = "";
            Objconfigurableitems.Param14 = "";
            Objconfigurableitems.Param15 = "";
            Objconfigurableitems.Insert();
            int itemid = Convert.ToInt16(drpitem.SelectedValue);
            Response.Redirect("~/cmdb/EditCI.aspx?" + itemid + " ");
        }

    }
    protected void drpitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtparam1.Text = "";
        txtparam2.Text = "";
        txtparam3.Text = "";
        txtparam4.Text = "";
        txtparam5.Text = "";
        txtparam6.Text = "";
        txtparam7.Text = "";
        txtparam8.Text = "";
        txtparam9.Text = "";
        txtparam10.Text = "";
        lblmessage.Visible = false;
        id = Convert.ToInt16(drpitem.SelectedValue);
        Objconfigurableitems = Objconfigurableitems.Get_By_id(id);
        if (Objconfigurableitems.Itemid != 0)
        {
            lblmessage.Visible = true;
            lblmessage.Text = "You have already configured this item.";
        }
    }
   
    #endregion
    
    
}