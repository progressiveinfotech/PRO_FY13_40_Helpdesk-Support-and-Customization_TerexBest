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
/// Summary description for UserToAssetMapping
/// </summary>
public class UserToAssetMapping
{
	#region Private Fields
		private int _userid;
		private int _assetid;
		#endregion

		#region Public Fields
		public int Userid
		{
			 get{ return _userid; }
			 set{ _userid = value; }
		}
		public int Assetid
		{
			 get{ return _assetid; }
			 set{ _assetid = value; }
		}
		#endregion

		#region Constructors
		public UserToAssetMapping()		{
		}
        public UserToAssetMapping(int userid, int assetid)
        {
			_userid = userid;
			_assetid = assetid;
		}
		#endregion

        #region Public Methods
        public int Insert(int userid, int assetid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Insert_UserToAssetMapping(userid, assetid);

        }

        public int Update()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_UserToAssetMapping_By_id(this);
        }

        public int Update_Assetid(int oldassetid, int assetid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Update_Assetid_By_id(oldassetid, assetid);
        }

        public int Delete(int assetProductInfoId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Delete_UserToAssetMapping_By_id(assetProductInfoId);
        }

        public BLLCollection<UserToAssetMapping> Get_All()
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.Get_UserToAssetMapping_All();
        }

        public UserToAssetMapping Get_By_id(int assetProductInfoId)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.UserToAssetMapping_Get_By_assetid(assetProductInfoId);
        }

        public int Get_AssetId_From_UserToAssetMap(int assetid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.AssetId_From_UserToAssetMap(assetid);
        }

        public int Get_UserId_From_UserToAssetMap(int userid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.UserId_From_UserToAssetMap(userid);
        }

        public int Get_AssetId_By_UserId(int userid)
        {
            SqlDataProvider db = new SqlDataProvider();
            return db.AssetId_By_UserId(userid);
        }

        #endregion
}
