using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Business
{
    public class PrefixMasterManager
    {

        public static List<PrefixMaster> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<PrefixMaster> model = db.PrefixMasters.AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InsertIntoPrefixMaster(PrefixMaster model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    model.CreatedBy = UserSession.Id;
                    model.CreatedOn = DateTime.Now.Date;
                    db.PrefixMasters.Add(model);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoPrefixMaster(List<PrefixMaster> prefixes)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.PrefixMasters.AddRange(prefixes);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdatePrefixMaster(PrefixMaster model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    PrefixMaster exitdata = db.PrefixMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();
                    exitdata.PrefixName = model.PrefixName;
                    exitdata.StartingFrom = model.StartingFrom;
                    exitdata.PageNumber = model.PageNumber;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
                    exitdata.ModifiedOn = DateTime.Now.Date;

                    db.Entry(exitdata).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PrefixMaster GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    PrefixMaster model = db.PrefixMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CheckDuplicationName(string name, Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string compare = string.Empty;
                    compare = CommonFunctions.TrimSpaceConvertToUpper(name);
                    if (id > 0) { return db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName.ToUpper() == compare).Count(); }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void DeleteFromPrefix(Int64 id)
        {
            using (var db = new IMSContext())
            {
                PrefixMaster model = db.PrefixMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                model.ModifiedBy = UserSession.Id;
                model.ModifiedOn = DateTime.Now.Date;

                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();


            }
        }

    }
}