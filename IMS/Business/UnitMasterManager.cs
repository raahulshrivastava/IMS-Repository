using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Business
{
    public class UnitMasterManager
    {
        public static List<UnitMaster> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<UnitMaster> model = db.UnitMasters.AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InsertIntoUnitMaster(UnitModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    UnitMaster e = new UnitMaster();
                    e.ConversionQuantity = model.ConversionQuantity;
                    e.ConversionUnit = model.ConversionUnit;
                    e.Description = model.Description;
                    e.IsActive = model.CheckIsActive == true ? "Y" : "N";
                    e.UnitName = model.UnitName;
                    e.CreatedBy = UserSession.Id;
                    e.CreatedOn = DateTime.Now.Date;
                    if (model.CheckIsActive) { e.IsActive = "Y"; }
                    else { e.IsActive = "N"; }

                    db.UnitMasters.Add(e);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoUnitMaster(List<UnitMaster> model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.UnitMasters.AddRange(model);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateUnitMaster(UnitModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    UnitMaster exitdata = db.UnitMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();
                    exitdata.UnitName = model.UnitName;
                    exitdata.ConversionUnit = model.ConversionUnit;
                    exitdata.ConversionQuantity = model.ConversionQuantity;

                    exitdata.Description = model.Description;
                    exitdata.MdifiedBy = UserSession.Id;
                    exitdata.ModifiedOn = DateTime.Now.Date;

                    if (model.CheckIsActive)
                    { exitdata.IsActive = "Y"; }
                    else { exitdata.IsActive = "N"; }

                    db.Entry(exitdata).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UnitMaster GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    UnitMaster model = db.UnitMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFromUnitMaster(Int64 id)
        {
            using (var db = new IMSContext())
            {
                UnitMaster model = db.UnitMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                model.MdifiedBy = UserSession.Id;
                model.ModifiedOn = DateTime.Now.Date;

                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();


            }
        }

        public static SelectList BindConversionUnitDDl()
        {
            using (var db = new IMSContext())
            {
                return new SelectList(db.UnitMasters.AsNoTracking().ToList(), "Id", "UnitName");
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
                    if (id > 0) { return db.UnitMasters.AsNoTracking().Where(a => a.UnitName.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.UnitMasters.AsNoTracking().Where(a => a.UnitName.ToUpper() == compare).Count(); }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class UnitModel
    {
        public long Id { get; set; }
        public string UnitName { get; set; }
        public Int64 ConversionUnit { get; set; }
        public string ConversionUnitName { get; set; }
        public int ConversionQuantity { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public SelectList DdlConversionUnit { get; set; }
        public bool CheckIsActive { get; set; }
    }
}