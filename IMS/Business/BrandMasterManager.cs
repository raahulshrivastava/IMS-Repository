using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IMS.Utilities;
using IMS.DataContext;

namespace IMS.Business
{
    public class BrandMasterManager
    {
        public static List<BrandMaster> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<BrandMaster> model = db.BrandMasters.AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InsertIntoBrandMaster(BrandModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    BrandMaster brd = new BrandMaster();
                    brd.BranchName = model.BranchName;
                    brd.Description = model.Description;
                    brd.CreatedBy = UserSession.Id;
                    brd.CreatedOn = DateTime.Now.Date;
                    if (model.ChkIsActive) { brd.IsActive = "Y"; }
                    else { brd.IsActive = "N"; }
                    db.BrandMasters.Add(brd);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertIntoBrandMaster(List<BrandMaster> brands)
        {
            using (var db = new IMSContext())
            {
                db.BrandMasters.AddRange(brands);
                db.SaveChanges();
            }
        }
        public static void UpdateBrandMaster(BrandModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    BrandMaster exitdata = db.BrandMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();

                    exitdata.BranchName = model.BranchName;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
                    exitdata.ModifiedOn = DateTime.Now.Date;

                    if (model.ChkIsActive)
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

        public static BrandModel GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    BrandModel model = db.BrandMasters.AsNoTracking().Where(a => a.Id == id).Select(a => new BrandModel
                    {
                        BranchName = a.BranchName,
                        Id = a.Id,
                        Description = a.Description,
                        IsActive = a.IsActive,
                        ChkIsActive = a.IsActive == "Y" ? true : false
                    }).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFromBrandMaster(Int64 id)
        {
            using (var db = new IMSContext())
            {
                BrandMaster model = db.BrandMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                model.ModifiedBy = UserSession.Id;
                model.ModifiedOn = DateTime.Now.Date;

                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();


            }
        }

        public static int CheckDuplicateBrandName(string name = "", Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string compare = string.Empty;
                    compare = CommonFunctions.TrimSpaceConvertToUpper(name);
                    if (id > 0) { return db.BrandMasters.AsNoTracking().Where(a => a.BranchName.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.BrandMasters.AsNoTracking().Where(a => a.BranchName.ToUpper() == compare).Count(); }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }


    public class BrandModel
    {
        public Int64 Id { get; set; }
        public string BranchName { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Int64? ModifiedBy { get; set; }
        public bool ChkIsActive { get; set; }
    }
}