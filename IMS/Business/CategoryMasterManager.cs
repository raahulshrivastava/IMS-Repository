
using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMS.Business
{
    public class CategoryMasterManager
    {
        public static List<CategoryMaster> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<CategoryMaster> model = db.CategoryMasters.AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InsertIntoCategoryMaster(CategoryModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    CategoryMaster m = new CategoryMaster();
                    m.CategoryName = model.CategoryName; ;
                    m.Description = model.Description;

                    m.CreatedBy = UserSession.Id;
                    m.CreatedOn = DateTime.Now.Date;
                    if (model.CheckIsActive)
                    { m.IsActive = "Y"; }
                    else { m.IsActive = "N"; }
                    db.CategoryMasters.Add(m);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoCategoryMaster(List<CategoryMaster> category)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.CategoryMasters.AddRange(category);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateCategoryMaster(CategoryModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    CategoryMaster exitdata = db.CategoryMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();

                    exitdata.CategoryName = model.CategoryName;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
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

        public static CategoryMaster GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    CategoryMaster model = db.CategoryMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFromCategoryMaster(Int64 id)
        {
            using (var db = new IMSContext())
            {
                CategoryMaster model = db.CategoryMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
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
                    if (id > 0) { return db.CategoryMasters.AsNoTracking().Where(a => a.CategoryName.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.CategoryMasters.AsNoTracking().Where(a => a.CategoryName.ToUpper() == compare).Count(); }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public partial class CategoryModel
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }

        public bool CheckIsActive { get; set; }
    }
}