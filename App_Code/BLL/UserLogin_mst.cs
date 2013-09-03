using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for UserLogin_mst
/// </summary>
public class UserLogin_mst
{
    #region Private Fields
    private string _username;
    private int _userid;
    private int _roleid;
    private string _password;
    private int _orgid;
    private bool _enable;
    private String  _createdatetime;
    private bool _adenable;
    private string _domainname;
    #endregion

    #region Public Fields
    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }
    public int Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    public int Roleid
    {
        get { return _roleid; }
        set { _roleid = value; }
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
    public int Orgid
    {
        get { return _orgid; }
        set { _orgid = value; }
    }
    public bool Enable
    {
        get { return _enable; }
        set { _enable = value; }
    }
    public String  Createdatetime
    {
        get { return _createdatetime; }
        set { _createdatetime = value; }
    }
    public bool ADEnable
    {
        get { return _adenable; }
        set { _adenable = value; }
    }
    public string DomainName
    {
        get { return _domainname; }
        set { _domainname = value; }
    }
    #endregion

    #region Constructors
    public UserLogin_mst()
    {
    }
    public UserLogin_mst(string username, int userid, int roleid, string password, int orgid, bool enable, String createdatetime, bool adenable, string _domainname)
    {
        _username = username;
        _userid = userid;
        _roleid = roleid;
        _password = password;
        _orgid = orgid;
        _enable = enable;
        _createdatetime = createdatetime;
        _adenable = ADEnable;
        _domainname = DomainName;
    }
    #endregion


    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_UserLogin_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_UserLogin_mst_By_id(this);
    }
    public int Delete(int userid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Delete_UserLogin_mst_By_id(userid);
    }
    public int Get_By_UserName(string UserName,int orgid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_UserId_mst_Get_By_UserName(UserName, orgid);
    }
    public UserLogin_mst Get_UserLogin_By_UserName(string UserName, int orgid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_UserLogin_mst_By_UserName(UserName, orgid);
    }
    public BLLCollection<UserLogin_mst> Get_All()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_UserLogin_mst_All();
    }
    //added by lalit 02nov2011 to 
    public BLLCollection<UserLogin_mst> Get_SDETechAdmin()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_UserLogin_mst_AdminTechSDE();
    }

    public UserLogin_mst Get_UserLogin_By_UserName_Like(string UserName)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_UserLogin_mst_By_UserName_Like(UserName);
    }
    public UserLogin_mst Get_By_id(int userid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.UserLogin_mst_Get_By_userid(userid);
    }
    public BLLCollection<UserLogin_mst> Get_By_comandname(string commandname)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Get_User_Info_By_commandname(commandname);
    }
    public BLLCollection<UserLogin_mst> Get_All_By_Role_Site(int roleid,int siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.UserLogin_mst_Get_By_Role_Site(roleid, siteid);
    }
    public BLLCollection<UserLogin_mst> Get_All_By_Role(int roleid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.UserLogin_mst_Get_By_Roleid(roleid);
    }


    #endregion
}
