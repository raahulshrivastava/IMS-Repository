using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Business
{
    public class SupplierMasterManager
    {
        public static List<SupplierMaster> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<SupplierMaster> model = db.SupplierMasters.AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InsertIntoSupplierMaster(SupplierModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    SupplierMaster m = new SupplierMaster();
                    m.Address = model.Address;
                    m.City = model.City;
                    m.ContactNumber = model.ContactNumber;
                    m.ContactPerson = model.ContactPerson;
                    m.Description = model.Description;
                    m.Email = model.Email;
                    m.GSTNumber = model.GSTNumber;
                    m.IsActive = model.IsActive;
                    m.OpeningBalance = model.OpeningBalance;
                    m.PANNumber = model.PANNumber;
                    m.SupplierName = model.SupplierName;

                    m.CreatedBy = UserSession.Id;
                    m.CreatedOn = DateTime.Now.Date;
                    if (model.CheckIsActive)
                    { m.IsActive = "Y"; }
                    else { m.IsActive = "N"; }

                    db.SupplierMasters.Add(m);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoSupplierMaster(List<SupplierMaster> suppliers)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.SupplierMasters.AddRange(suppliers);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateSupplierMaster(SupplierModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    SupplierMaster exitdata = db.SupplierMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();
                    exitdata.ContactPerson = model.ContactPerson;
                    exitdata.ContactNumber = model.ContactNumber;
                    exitdata.SupplierName = model.SupplierName;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
                    exitdata.ModifiedOn = DateTime.Now.Date;

                    if (model.CheckIsActive)
                    { exitdata.IsActive = "Y"; }
                    else { exitdata.IsActive = "N"; }

                    exitdata.Address = model.Address;
                    exitdata.ContactNumber = model.ContactNumber;
                    exitdata.Email = model.Email;
                    exitdata.PANNumber = model.PANNumber;
                    exitdata.GSTNumber = model.GSTNumber;
                    exitdata.City = model.City;

                    exitdata.OpeningBalance = model.OpeningBalance;
                    db.Entry(exitdata).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SupplierMaster GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    SupplierMaster model = db.SupplierMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFromSupplierMaster(Int64 id)
        {
            using (var db = new IMSContext())
            {
                SupplierMaster model = db.SupplierMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                model.ModifiedBy = UserSession.Id;
                model.ModifiedOn = DateTime.Now.Date;

                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();


            }
        }

        public static int CheckDuplicationEmail(string email, Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string compare = string.Empty;
                    compare = CommonFunctions.TrimSpaceConvertToUpper(email);
                    if (id > 0) { return db.SupplierMasters.AsNoTracking().Where(a => a.Email.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.SupplierMasters.AsNoTracking().Where(a => a.Email.ToUpper() == compare).Count(); }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int CheckDuplicationContactNo(string contactNo, Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string compare = string.Empty;
                    compare = CommonFunctions.TrimSpaceConvertToUpper(contactNo);
                    if (id > 0) { return db.SupplierMasters.AsNoTracking().Where(a => a.ContactNumber.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.SupplierMasters.AsNoTracking().Where(a => a.ContactNumber.ToUpper() == compare).Count(); }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class SupplierModel
    {
        public long Id { get; set; }
        public string SupplierName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string GSTNumber { get; set; }
        public string PANNumber { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public bool CheckIsActive { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
    }
}