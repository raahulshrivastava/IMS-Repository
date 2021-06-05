
using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Business
{
    public class CustomerMasterManager
    {
        public static List<CustomerMaster> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<CustomerMaster> model = db.CustomerMasters.AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InsertIntoCustomerMaster(CustomerModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    CustomerMaster m = new CustomerMaster();

                    m.Address = model.Address;
                    m.ContactNumber = model.ContactNumber;
                    m.CustomerName = model.CustomerName;
                    m.Description = model.Description;
                    m.EmailId = model.EmailId;
                    m.Id = model.Id;
                    m.OpeningBalance = model.OpeningBalance;
                    m.PanNumber = model.PanNumber;
                    m.IsActive = model.CheckIsActive == true ? "Y" : "N";

                    m.CreatedBy = UserSession.Id;
                    m.CreatedOn = DateTime.Now.Date;

                    db.CustomerMasters.Add(m);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoCustomerMaster(List<CustomerMaster> customers)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.CustomerMasters.AddRange(customers);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateCustomerMaster(CustomerModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    CustomerMaster exitdata = db.CustomerMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();

                    exitdata.CustomerName = model.CustomerName;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
                    exitdata.ModifiedOn = DateTime.Now.Date;

                    if (model.CheckIsActive)
                    { exitdata.IsActive = "Y"; }
                    else { exitdata.IsActive = "N"; }

                    exitdata.Address = model.Address;
                    exitdata.ContactNumber = model.ContactNumber;
                    exitdata.EmailId = model.EmailId;
                    exitdata.PanNumber = model.PanNumber;
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

        public static CustomerMaster GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    CustomerMaster model = db.CustomerMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFromCustomerMaster(Int64 id)
        {
            using (var db = new IMSContext())
            {
                CustomerMaster model = db.CustomerMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
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
                    if (id > 0) { return db.CustomerMasters.AsNoTracking().Where(a => a.EmailId.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.CustomerMasters.AsNoTracking().Where(a => a.EmailId.ToUpper() == compare).Count(); }
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
                    if (id > 0) { return db.CustomerMasters.AsNoTracking().Where(a => a.ContactNumber.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.CustomerMasters.AsNoTracking().Where(a => a.ContactNumber.ToUpper() == compare).Count(); }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class CustomerModel
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string PanNumber { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public bool CheckIsActive { get; set; }
        public decimal? OpeningBalance { get; set; }
    }
}