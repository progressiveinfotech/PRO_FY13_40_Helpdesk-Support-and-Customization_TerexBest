using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



/// <summary>
/// Summary description for Site_mst
/// </summary>
public class AreaManager_mst
{
    #region Private Fields
    private int _Siteid;
    private string _AreaManagerName;
    private string _Email;
    #endregion

    #region Public Fields
   
     public int Siteid
    {
        get { return _Siteid; }
        set { _Siteid= value; }
    }
    public string AreaManagerName
    {
        get { return _AreaManagerName; }
        set { _AreaManagerName = value; }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
   
    #endregion
    #region Constructors
    public AreaManager_mst()
    {
    }
    public AreaManager_mst(int Siteid, string AreaManagerName, string Email)
    {
        _Siteid = Siteid;
        _AreaManagerName = AreaManagerName;
        _Email = Email;
    }
    #endregion
    #region Public Methods
    public int Insert()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Insert_AreaManager_mst(this);

    }
    public int Update()
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.Update_AreaManager_mst_By_id(this);
    }
    //public int Delete(int siteid)
    //{
    //    SqlDataProvider db = new SqlDataProvider();
    //    return db.Delete_AreaManager_mst_By_id(siteid);
    //}
   

  
    //public BLLCollection<Site_mst> Get_All()
    //{
    //    SqlDataProvider db = new SqlDataProvider();
    //    return db.Get_AreaManager_mst_All();
    //}
    public AreaManager_mst Get_By_id(int Siteid)
    {
        SqlDataProvider db = new SqlDataProvider();
        return db.AreaManager_mst_Get_By_id(Siteid);
    }
    //public BLLCollection<Site_mst> Get_All_By_RegionId(int regionid)
    //{
    //    SqlDataProvider db = new SqlDataProvider();
    //    return db.Get_AreaManager_mst_All_By_RegionId(regionid);
    //}

   

    #endregion

}


