using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppTS.Models;
namespace AppTS.Areas.Admin.Models.DAO
{
    public class XuLyDAO
    {
        public static dbQL_NTTDataContext db = new dbQL_NTTDataContext();
        public bool DeleteChuyenNganh(int id)
        {
            try
            {
                var nganh = db.Table_ChuyenNganhs.SingleOrDefault(m=>m.ID_CHUYENNGANH == id);
                db.Table_ChuyenNganhs.DeleteOnSubmit(nganh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}