using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Business
{
    public class TaxMasterManager
    {
        public static List<TaxMaster> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<TaxMaster> model = db.TaxMasters.AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InsertIntoTaxMaster(TaxModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    TaxMaster e = new TaxMaster();
                    e.CreatedBy = UserSession.Id;
                    e.CreatedOn = DateTime.Now.Date;
                    e.TotalValue = model.SGSTValue + model.CGSTValue;
                    e.TaxName = model.TaxName;
                    e.SGSTValue = model.SGSTValue;
                    e.Description = model.Description;
                    e.CGSTValue = model.CGSTValue;
                    e.AppliedOn = model.AppliedOn;
                    if (model.CheckIsActive) { model.IsActive = "Y"; }
                    else { model.IsActive = "N"; }

                    db.TaxMasters.Add(e);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoTaxMaster(List<TaxMaster> model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.TaxMasters.AddRange(model);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateTaxMaster(TaxModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    TaxMaster exitdata = db.TaxMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();

                    exitdata.TaxName = model.TaxName;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
                    exitdata.MdifiedOn = DateTime.Now.Date;
                    exitdata.TotalValue = model.CGSTValue + model.SGSTValue;
                    exitdata.CGSTValue = model.CGSTValue;
                    exitdata.SGSTValue = model.SGSTValue;
                    exitdata.AppliedOn = model.AppliedOn;

                    if (model.CheckIsActive) { exitdata.IsActive = "Y"; }
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

        public static TaxMaster GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    TaxMaster model = db.TaxMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFromTaxMaster(Int64 id)
        {
            using (var db = new IMSContext())
            {
                TaxMaster model = db.TaxMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                model.ModifiedBy = UserSession.Id;
                model.MdifiedOn = DateTime.Now.Date;

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
                    if (id > 0) { return db.TaxMasters.AsNoTracking().Where(a => a.TaxName.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.TaxMasters.AsNoTracking().Where(a => a.TaxName.ToUpper() == compare).Count(); }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class TaxModel
    {
        public long Id { get; set; }
        public string TaxName { get; set; }
        public string AppliedOn { get; set; }
        public decimal TotalValue { get; set; }
        public decimal CGSTValue { get; set; }
        public decimal SGSTValue { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public bool CheckIsActive { get; set; }
    }
}