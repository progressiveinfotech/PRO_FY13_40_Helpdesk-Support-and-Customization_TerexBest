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

public partial class Incident_SelectAsset : System.Web.UI.Page
{
    UserToAssetMapping objusertoasset = new UserToAssetMapping();
    Asset_mst ObjAsset = new Asset_mst();
    BLLCollection<Asset_mst> col = new BLLCollection<Asset_mst>();
    UserLogin_mst objUser = new UserLogin_mst();
    int userid, assetcount, usercount;

    protected void Page_Load(object sender, EventArgs e)
    {
        string username = (string)(Session["Username"]);
        int flag1 = 0;
        
        if (username == null)
        {
            lblusername.Text = "";
            
        }
        else
        {
            lblusername.Text = username.ToString();
        }
        //lblErrorMsg.Text = "";
        if (!IsPostBack)
        {
                col = ObjAsset.Get_NotAssign_By_comandname("");
                grdvwViewAsset.DataSource = col;
                grdvwViewAsset.DataBind();
                ViewState["commandname"] = "";
        }
    }
    protected void btnMapped_Click(object sender, EventArgs e)
    {
        //lblErrorMsg.Text = "";
        int flag = 0;
        int tempuser;
        tempuser=Convert.ToInt16(Session["tempuser"]);

        foreach (GridViewRow gv in grdvwViewAsset.Rows)
        {
            string gvIDs;
            RadioButton selectonebutton = (RadioButton)gv.FindControl("selectone");
            if (selectonebutton.Checked)
            {
                flag = 1;
                int assetid;
                gvIDs = ((Label)gv.FindControl("lblAssetID")).Text.ToString();
                assetid = Convert.ToInt16(gvIDs);
                string Username = lblusername.Text.ToString().Trim();
                objUser = objUser.Get_UserLogin_By_UserName_Like(Username);
                userid = objUser.Userid;
                if (lblusername.Text == "")
                {

                    //lblErrorMsg.Text = "Enter the user name for mapped a particular Asset";
                    break;
                }

                else if (tempuser == 1)
                {
                    assetcount = objusertoasset.Get_AssetId_From_UserToAssetMap(assetid);
                    int tempuser1 = 0;
                    if (assetcount == 0)
                    {
                        int flag1 = 1;
                        ObjAsset = ObjAsset.Get_By_id(assetid);
                        string compname = ObjAsset.Computername.ToString();
                        string username = lblusername.Text.ToString();
                        Session["compname"] = compname;
                        Session["flag"] = flag1;
                        Session["username"] = username;
                        Session["assetid"] = assetid;
                        Session["userid"] = userid;
                        tempuser1 = 1;
                        Session["tempuser1"] = tempuser1;
                        Session["flag1"] = flag1;
                        break;
                    }
                    else
                    {
                        //lblErrorMsg.Text = "Asset already mapped";
                        break;
                    }
                }
                else if (userid == 0)
                {
                    //lblErrorMsg.Text = "User Name doen not exist";
                    break;
                }
                else
                {
                    assetcount = objusertoasset.Get_AssetId_From_UserToAssetMap(assetid);
                    usercount = objusertoasset.Get_UserId_From_UserToAssetMap(userid);
                    if (assetcount == 0)
                    {
                        if (usercount == 0)
                        {
                            int flag1 = 1;
                            objusertoasset.Insert(userid, assetid);
                            //lblErrorMsg.Text = "Mapped Succussfully";
                            ObjAsset = ObjAsset.Get_By_id(assetid);
                            string compname = ObjAsset.Computername.ToString();
                            string username = lblusername.Text.ToString();
                            Session["compname"] = compname;
                            Session["flag"] = flag1;
                            Session["username"] = username;
                            Session["assetid"] = assetid;
                            Session["userid"] = userid;
                            Session["flag1"] = flag1;
                            break;

                        }
                        else  //Update Asset id from UserToAsset table.
                        {
                            int flag1 = 1;
                            int oldassetid = Convert.ToInt16(Session["assignassetid"]);
                            objusertoasset.Update_Assetid(oldassetid, assetid);
                            ObjAsset = ObjAsset.Get_By_id(assetid);
                            string compname = ObjAsset.Computername.ToString();
                            string username = lblusername.Text.ToString();
                            Session["compname"] = compname;
                            Session["flag"] = flag1;
                            Session["username"] = username;
                            Session["assetid"] = assetid;
                            Session["userid"] = userid;
                            Session["flag1"] = flag1;
                            break;
                        }
                    }
                    else
                    {
                        //lblErrorMsg.Text = "Asset already mapped";
                        break;
                    }
                }
            }

        }
        if (flag == 0)
        {
            //lblErrorMsg.Text = "Select Asset for mapping";
        }

        string myScript;
        myScript = "<script language=javascript>javascript:refreshParent(); javascript:window.close();</script>";
        Page.RegisterClientScriptBlock("MyScript", myScript);
    }

    protected void grdvwViewAsset_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //lblErrorMsg.Text = "";
        grdvwViewAsset.PageIndex = e.NewPageIndex;
        BindGrid1();
    }

    public void BindGrid()
    {
        //lblErrorMsg.Text = "";
        col = ObjAsset.Get_By_comandname("A");
        grdvwViewAsset.DataSource = col;
        grdvwViewAsset.DataBind();
        ViewState["commandname"] = "a";
    }

    protected void BindGrid1()
    {
        //lblErrorMsg.Text = "";
        string commandname;
        commandname = ViewState["commandname"].ToString();
        col = ObjAsset.Get_NotAssign_By_comandname(commandname);
        if (col.Count != 0)
        {
            grdvwViewAsset.DataSource = col;
            grdvwViewAsset.DataBind();
            
        }
    }

    protected void grdvwViewAsset_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //lblErrorMsg.Text = "";
        if (e.CommandName.Equals("AlphaPaging"))
        {
            string commandname = e.CommandArgument.ToString();
            ViewState["commandname"] = e.CommandArgument.ToString();
            col = ObjAsset.Get_By_comandname(commandname);
            if (col.Count != 0)
            {
                grdvwViewAsset.DataSource = col;
                grdvwViewAsset.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("assetid");
                dt.Columns.Add("computername");
                dt.Columns.Add("domain");
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                grdvwViewAsset.DataSource = dt;
                grdvwViewAsset.DataBind();
            }
        }
    }

    protected void grdvwViewAsset_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //lblErrorMsg.Text = "";
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TableCell cell = e.Row.Cells[0];
            cell.ColumnSpan = 6;
            for (int i = 65; i <= (65 + 25); i++)
            {
                LinkButton lb = new LinkButton();
                lb.Text = Char.ConvertFromUtf32(i) + "&nbsp;&nbsp;&nbsp;";
                lb.CommandArgument = Char.ConvertFromUtf32(i);
                lb.CommandName = "AlphaPaging";
                lb.Font.Size = FontUnit.Large;
                cell.Controls.Add(lb);
            }
        }
    }
}
