using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Business
{
    public class UserMasterManager
    {
        public static List<UserModel> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var T = (from u in db.UserMasters.AsNoTracking()
                             select new UserModel
                             {
                                 Id = u.Id,
                                 EmployeeName = u.EmployeeName,
                                 UserType = u.UserType,
                                 UserName = u.UserName,
                                 Password = u.Password,
                                 IsActive = u.IsActive,
                                 Description = u.Description
                             }).ToList();

                    foreach (var i in T)
                    {
                        i.UserTypeDescription = System.Enum.GetName(typeof(Utilities.Enums.UserType), (int)i.UserType);
                    }
                    return T;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void InsertIntoUserMaster(UserModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    UserMaster m = new UserMaster();

                    m.CreatedBy = UserSession.Id;
                    m.CreatedOn = DateTime.Now.Date;
                    m.Description = model.Description;
                    m.EmployeeName = model.EmployeeName;
                    m.IsActive = model.CheckIsActive == true ? "Y" : "N";
                    m.Password = model.Password;
                    m.UserName = model.UserName;
                    m.UserType = model.UserType;

                    db.UserMasters.Add(m);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoUserMaster(List<UserMaster> users)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.UserMasters.AddRange(users);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateUserMaster(UserModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    UserMaster exitdata = db.UserMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();
                    exitdata.EmployeeName = model.EmployeeName;
                    exitdata.Password = model.Password;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
                    exitdata.ModifiedOn = DateTime.Now.Date;

                    exitdata.UserName = model.UserName;
                    exitdata.UserType = model.UserType;
                    exitdata.IsActive = model.CheckIsActive == true ? "Y" : "N";

                    db.Entry(exitdata).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UserMaster GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    UserMaster model = db.UserMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFromUserMaster(Int64 id)
        {
            using (var db = new IMSContext())
            {
                UserMaster model = db.UserMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
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
                    if (id > 0) { return db.UserMasters.AsNoTracking().Where(a => a.UserName.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.UserMasters.AsNoTracking().Where(a => a.UserName.ToUpper() == compare).Count(); }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static UserMaster GetCustomer(string username)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    UserMaster user = new UserMaster();
                    user = db.UserMasters.AsNoTracking().Where(a => a.UserName == username).FirstOrDefault();
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

    public class UserModel
    {
        public long Id { get; set; }
        public string EmployeeName { get; set; }
        public int UserType { get; set; }
        public SelectList UserTypeDdl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public SelectList BindFinYear { get; set; }
        public SelectList BindStore { get; set; }
        public int StoreId { get; set; }
        public string FinYear { get; set; }
        public string UserTypeDescription { get; set; }
        public bool CheckIsActive { get; set; }
        public int StoreType { get; set; }
        public int PaymentType { get; set; }
    }
}