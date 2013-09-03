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

public partial class Contract_RenewContract : System.Web.UI.Page
{
    Vendor_mst objVendor = new Vendor_mst();
    BLLCollection<Vendor_mst> colVendor = new BLLCollection<Vendor_mst>();
    BLLCollection<EscalateEmail_mst> colEscalateEmail = new BLLCollection<EscalateEmail_mst>();
    EscalateEmail_mst objEscalateEmail = new EscalateEmail_mst();
    Contract_mst objContract = new Contract_mst();
    ContractToAssetMapping objContractToAsset = new ContractToAssetMapping();
    ContractNotification objContractNotfy = new ContractNotification();
    BLLCollection<ContractToAssetMapping> colContractToAssetMapping = new BLLCollection<ContractToAssetMapping>();
    BLLCollection<Asset_mst> colAsset = new BLLCollection<Asset_mst>();

    ContractRenewed objContractRenewed = new ContractRenewed();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            string varAsset = "";
            if (Session["AssetContract"] != null)
            {
                varAsset = Session["AssetContract"].ToString();
            }


            BindEmailListbox();
            BindVendor();
            BindContractData();
            if (varAsset != "")
            {
                BindListBox();
            }
        }
    }

    protected void BindVendor()
    {
        colVendor = objVendor.Get_All();
        drpVendor.DataTextField = "vendorname";
        drpVendor.DataValueField = "vendorid";

        drpVendor.DataSource = colVendor;
        drpVendor.DataBind();
        ListItem item = new ListItem();
        item.Text = "-------Select Vendor------";
        item.Value = "0";
        drpVendor.Items.Add(item);
        drpVendor.SelectedValue = "0";

    }
    protected void BindEmailListbox()
    {
        colEscalateEmail = objEscalateEmail.Get_All();
        listLevel1.DataTextField = "email";
        listLevel1.DataValueField = "id";

        listLevel1.DataSource = colEscalateEmail;
        listLevel1.DataBind();

    }

    protected void BindContractData()
    {

        int contractid = Convert.ToInt16(Request.QueryString[0]);
        objContract = objContract.Get_By_id(contractid);
        if (objContract != null)
        {
            txtContractName.Text = objContract.Contractname + " " + "Renewed";
            txtdesc.Text = objContract.Description;
                    
            drpVendor.SelectedValue = Convert.ToString(objContract.Vendorid);

            colContractToAssetMapping = objContractToAsset.Get_All_By_contractid(objContract.Contractid);
            foreach (ContractToAssetMapping obj in colContractToAssetMapping)
            {
                Asset_mst objA = new Asset_mst();
                objA = objA.Get_By_id(obj.Assetid);
                colAsset.Add(objA);
            }
            ListAsset.DataTextField = "computername";
            ListAsset.DataValueField = "Assetid";
            ListAsset.DataSource = colAsset;
            ListAsset.DataBind();
        }

        objContractNotfy = objContractNotfy.Get_By_id(contractid);
        if (objContractNotfy.Contractid != 0)
        {
            EscalateEmail_mst objEscalateEmail = new EscalateEmail_mst();
            chkLevel1.Checked = true;
            txtBeforeDays.Text = objContractNotfy.Beforedays.ToString();
            string varEmail = objContractNotfy.Sentto;
            string[] arrEmail = varEmail.Split((",").ToCharArray());
            for (int i = 0; i < arrEmail.Length - 1; i++)
            {
                if (arrEmail[i] != "," && arrEmail[i] != " ")
                {
                    objEscalateEmail = objEscalateEmail.Get_By_Emailid(arrEmail[i]);
                    for (int j = listLevel1.Items.Count - 1; j >= 0; j--)
                    {
                        if (Convert.ToInt16(listLevel1.Items[j].Value) == objEscalateEmail.Id)
                        {
                            listLevel1.Items[j].Selected = true;
                        }
                    }

                }


            }


        }


    }

    protected void lnkRemove_Click(object sender, EventArgs e)
    {

        for (int i = ListAsset.Items.Count - 1; i >= 0; i--)
        {
            if (ListAsset.Items[i].Selected == true)
            {
                int assetid = Convert.ToInt16(ListAsset.Items[i].Value);
                 ListItem item = new ListItem();
                item.Value = ListAsset.Items[i].Value;
                item.Text = ListAsset.Items[i].Text;
                ListAsset.Items.Remove(item);
               

            }
        }

    }


    protected void BindListBox()
    {
        int contractid = Convert.ToInt16(Request.QueryString[0]);
        Asset_mst ObjAsset = new Asset_mst();
        BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
        string varAsset = Session["AssetContract"].ToString();
        string[] arrAsset = varAsset.Split(',');
        int FlagCount = arrAsset.Length;
        for (int i = 0; i < FlagCount; i++)
        {
            if (arrAsset[i] != "," && arrAsset[i] != "")
            {
                ContractToAssetMapping objCoAsset = new ContractToAssetMapping();
                ListItem item = new ListItem();
                int flagcount;
                Asset_mst obj = new Asset_mst();
                obj = ObjAsset.Get_By_id(Convert.ToInt16(arrAsset[i].ToString()));
                flagcount = objCoAsset.Get_by_Contractid_Assetid(contractid, Convert.ToInt16(arrAsset[i].ToString()));
                if (flagcount == 0)
                {
                    item.Text = obj.Computername;
                    item.Value = Convert.ToString(obj.Assetid);
                    ListAsset.Items.Add(item);

                }
            }

        }


    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
         int Oldcontractid = Convert.ToInt16(Request.QueryString[0]);
        string vardateFrom;
        string vardateTo;
        string varemail = "";
        int FlagCount = 0;
        int contractid;
        FlagCount = objContract.Get_By_Contractname(txtContractName.Text);
        if (FlagCount == 0)
        {
            string[] tempdate = txtActiveFrom.Text.ToString().Split(("/").ToCharArray());
            vardateFrom = tempdate[2] + "-" + tempdate[1] + "-" + tempdate[0];

            string[] tempdate1 = txtActiveTo.Text.ToString().Split(("/").ToCharArray());
            vardateTo = tempdate1[2] + "-" + tempdate1[1] + "-" + tempdate1[0];


            objContract.Activefrom = vardateFrom;
            objContract.Activeto = vardateTo;
            objContract.Contractname = txtContractName.Text;
            objContract.Description = txtdesc.Text;
            objContract.Vendorid = Convert.ToInt16(drpVendor.SelectedValue);
            objContract.Insert();
            contractid = objContract.Get_TopContractId();
            objContractRenewed.Contractid = Oldcontractid ;
            objContractRenewed.Renewedcontractid = contractid;
            objContractRenewed.Insert();
            for (int i = ListAsset.Items.Count - 1; i >= 0; i--)
            {
               
                    objContractToAsset.Assetid = Convert.ToInt16(ListAsset.Items[i].Value);
                    objContractToAsset.Contractid = contractid;
                    objContractToAsset.Insert();

               
            }
            if (chkLevel1.Checked == true)
            {
                for (int i = listLevel1.Items.Count - 1; i >= 0; i--)
                {
                    if (listLevel1.Items[i].Selected == true)
                    {
                        varemail = varemail + listLevel1.Items[i].Text + ",";
                    }
                }

                objContractNotfy.Contractid = contractid;
                objContractNotfy.Sendnotification = false;
                objContractNotfy.Sentto = varemail;
                objContractNotfy.Beforedays = Convert.ToInt16(txtBeforeDays.Text);
                objContractNotfy.Insert();


            }
            ClearControl();
            Response.Redirect("~/Contract/ViewContract.aspx?" + contractid + "");
        }
        else
        {
            lblErrorMsg.Text = "Contract of this name already exist";
        }
    }

    protected void ClearControl()
    {

        txtContractName.Text = "";
        txtdesc.Text = "";
        txtActiveFrom.Text = "";
        txtActiveTo.Text = "";
        drpVendor.SelectedValue = "0";
        lblErrorMsg.Text = "";
        txtBeforeDays.Text = "";


        chkLevel1.Checked = false;

        for (int i = listLevel1.Items.Count - 1; i >= 0; i--)
        {
            if (listLevel1.Items[i].Selected == true)
            {
                listLevel1.Items[i].Selected = false;
            }
        }

        for (int i = ListAsset.Items.Count - 1; i >= 0; i--)
        {
            if (ListAsset.Items[i].Selected == true)
            {
                ListAsset.Items[i].Selected = false;
            }
        }

    }
    protected void lnkAddAsset_Click(object sender, EventArgs e)
    {
        Session["contractname"] = txtContractName.Text;
        Session["description"] = txtdesc.Text;
        Session["vendorid"] = drpVendor.SelectedValue;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript:window.open('AddAsset.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');", "javascript:window.open('AddAsset.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');", true);
        string myScript;
        myScript = "<script language=javascript>javascript:window.open('AddAsset.aspx','popupwindow','width=990,height=590,left=230,top=300,Scrollbars=yes');</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }
    protected void lnkAddVendor_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript:window.open('AddVendor.aspx','popupwindow','width=500,height=240,left=500,top=300,Scrollbars=yes');", "javascript:window.open('AddVendor.aspx','popupwindow','width=500,height=240,left=500,top=300,Scrollbars=yes');", true);
        string myScript;
        myScript = "<script language=javascript>javascript:window.open('AddVendor.aspx','popupwindow','width=500,height=240,left=500,top=300,Scrollbars=yes');</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Contract/DisplayAllContract.aspx");
    }
}
