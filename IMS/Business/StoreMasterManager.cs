using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Business
{
    public class StoreMasterManager
    {
        public static List<StoreMaster> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<StoreMaster> model = db.StoreMasters.AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InsertIntoStoreMaster(StoreMaster model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    model.CreatedBy = UserSession.Id;
                    model.CreatedOn = DateTime.Now.Date;
                    db.StoreMasters.Add(model);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoStoreMaster(List<StoreMaster> stores)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.StoreMasters.AddRange(stores);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateStoreMaster(StoreMaster model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    StoreMaster exitdata = db.StoreMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();

                    exitdata.StoreName = model.StoreName;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
                    exitdata.ModifiedOn = DateTime.Now.Date;
                    exitdata.Address = model.Address;
                    exitdata.ContactNumber1 = model.ContactNumber1;
                    exitdata.EmailId1 = model.EmailId1;
                    exitdata.ContactNumber2 = model.ContactNumber2;
                    exitdata.EmailId2 = model.EmailId2;
                    exitdata.Website = model.Website;
                    exitdata.OwnerName = model.OwnerName;
                    exitdata.Address = model.Address;
                    exitdata.State = model.State;
                    exitdata.City = model.City;
                    exitdata.GSTINNumber = model.GSTINNumber;
                    exitdata.DLNumber = model.DLNumber;
                    exitdata.TINNumber = model.TINNumber;
                    exitdata.STNumber = model.STNumber;
                    exitdata.StoreType = model.StoreType;
                    exitdata.PaymentType = model.PaymentType;

                    db.Entry(exitdata).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static StoreMaster GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    StoreMaster model = db.StoreMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFromStoreMaster(Int64 id)
        {
            using (var db = new IMSContext())
            {
                StoreMaster model = db.StoreMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                model.ModifiedBy = UserSession.Id;
                model.ModifiedOn = DateTime.Now.Date;

                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();


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
                    if (id > 0) { return db.StoreMasters.AsNoTracking().Where(a => a.OwnerName.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.StoreMasters.AsNoTracking().Where(a => a.OwnerName == compare).Count(); }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}