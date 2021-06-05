using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using IMS.DataContext;
using System.Web.Mvc;

namespace IMS.Business
{
    public class AttributeMasterManager
    {
        public static List<AttributeMaster> GetAllDataFromAttributeMaster()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<AttributeMaster> attr = new List<AttributeMaster>();
                    attr = db.AttributeMasters.AsNoTracking().ToList();
                    return attr;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static AttributeModel GetDataById(Int64 id)
        {
            using (var db = new IMSContext())
            {
                AttributeModel attr = new AttributeModel();
                attr = (from a in db.AttributeMasters.AsNoTracking()
                        where a.Id == id
                        select new AttributeModel
                        {
                            Id = a.Id,
                            AttributeName = a.AttributeName,
                            Description = a.Description,
                            IsAcive = a.IsActive,
                            ChkIsActive = a.IsActive == "Y" ? true : false
                        }).FirstOrDefault();
                return attr;
            }
        }
        public static bool InserIntoAttributeMaster(AttributeModel master)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    AttributeMaster attr = new AttributeMaster();
                    attr.CreatedBy = UserSession.Id;
                    attr.CreatedOn = DateTime.Now.Date;
                    attr.AttributeName = master.AttributeName;
                    attr.Description = master.Description;
                    if (master.ChkIsActive)
                    { attr.IsActive = "Y"; }
                    else { attr.IsActive = "N"; }
                    db.AttributeMasters.Add(attr);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InserIntoAttributeMaster(List<AttributeMaster> attributeMasters)
        {
            using (var db = new IMSContext())
            {
                db.AttributeMasters.AddRange(attributeMasters);
                db.SaveChanges();
            }
        }

        public static void InserIntoAttributeDetailMaster(List<AttributeDetailMaster> attributeDetailMasters)
        {
            using (var db = new IMSContext())
            {
                db.AttributeDetailMasters.AddRange(attributeDetailMasters);
                db.SaveChanges();
            }
        }
        public static bool EditAttributeMasterById(AttributeModel master)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    AttributeMaster data = db.AttributeMasters.AsNoTracking().Where(a => a.Id == master.Id).FirstOrDefault();
                    data.Description = master.Description;
                    data.AttributeName = master.AttributeName;
                    if (master.ChkIsActive) { data.IsActive = "Y"; } else { data.IsActive = "N"; }
                    data.ModifiedOn = DateTime.Now.Date;
                    data.ModifiedBy = UserSession.Id;
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteAttributeMasterById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    AttributeMaster master = db.AttributeMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    master.ModifiedOn = DateTime.Now.Date;
                    master.ModifiedBy = UserSession.Id;
                    db.Entry(master).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return true;
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
                    if (id > 0) { return db.AttributeMasters.AsNoTracking().Where(a => a.AttributeName.ToUpper() == compare && a.Id != id).Count(); }
                    else { return db.AttributeMasters.AsNoTracking().Where(a => a.AttributeName == compare).Count(); }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<AttributeModel> GetAllDetail()
        {
            using (var db = new IMSContext())
            {
                List<AttributeModel> attr = new List<AttributeModel>();
                attr = (from det in db.AttributeDetailMasters.AsNoTracking()
                        join att in db.AttributeMasters.AsNoTracking()
                        on det.AttributeId equals att.Id
                        select new AttributeModel
                        {
                            AttributeId = att.Id,
                            AttributeName = att.AttributeName,
                            Id = det.Id,
                            IsAcive = det.IsAcive,
                            Description = det.Description,
                            DetailName = det.DetailName
                        }).ToList();

                return attr;
            }
        }

        public static void InsertIntoAttributeDetailMaster(AttributeModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    AttributeDetailMaster e = new AttributeDetailMaster();
                    e.AttributeId = model.AttributeId;
                    e.Description = model.Description;
                    e.DetailName = model.DetailName;
                    e.IsAcive = model.ChkIsActive == true ? "Y" : "No";
                    e.CreatedBy = UserSession.Id;
                    e.CreatedOn = DateTime.Now.Date;
                    if (model.ChkIsActive) { model.IsAcive = "Y"; }
                    else { model.IsAcive = "N"; }
                    db.AttributeDetailMasters.Add(e);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateAttributeDetailMaster(AttributeModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    AttributeDetailMaster exitdata = db.AttributeDetailMasters.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();

                    exitdata.DetailName = model.DetailName;
                    exitdata.AttributeId = model.AttributeId;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
                    exitdata.ModifiedOn = DateTime.Now.Date;
                    if (model.ChkIsActive)
                    { exitdata.IsAcive = "Y"; }
                    else { exitdata.IsAcive = "N"; }

                    db.Entry(exitdata).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AttributeModel GetAttrDetailMasterDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var T = (from att in db.AttributeDetailMasters.AsNoTracking()
                             where att.Id == id
                             select new AttributeModel
                             {
                                 Id = att.Id,
                                 DetailName = att.DetailName,
                                 Description = att.Description,
                                 IsAcive = att.IsAcive,
                                 AttributeId = (long)att.AttributeId,
                                 ChkIsActive = att.IsAcive == "Y" ? true : false
                             }).FirstOrDefault();
                    return T;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFromAttributeDetailMaster(Int64 id, out string message, out int messageType)
        {
            using (var db = new IMSContext())
            {
                message = "";
                messageType = (int)Utilities.Enums.Message.Success;
                var result = db.ProductMasterDetails.Any(a => a.AttributeDetailId == id);
                if (!result)
                {
                    AttributeDetailMaster model = db.AttributeDetailMasters.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    model.ModifiedBy = UserSession.Id;
                    model.ModifiedOn = DateTime.Now.Date;

                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    message = "Record Deleted Successfully.";
                    messageType = (int)Utilities.Enums.Message.Success;
                }
                else
                {
                    message = "Cannot delete this record becuase it has been used in inventory.";
                    messageType = (int)Utilities.Enums.Message.Alert;
                }

            }
        }





        public static int CountDuplicateAttributeName(string name, Int64 id = 0)
        {
            using (var db = new IMSContext())
            {
                string compare = string.Empty;
                compare = CommonFunctions.TrimSpaceConvertToUpper(name);
                if (id > 0)
                {
                    return db.AttributeDetailMasters.AsNoTracking().Where(a => a.DetailName.ToUpper() == compare && a.Id != id).Count();
                }
                else
                {
                    return db.AttributeDetailMasters.AsNoTracking().Where(a => a.DetailName.ToUpper() == compare).Count();
                }
            }
        }

        public static SelectList BindAttributeDropDown(string sqlval = "")
        {
            using (var db = new IMSContext())
            {
                return new SelectList(db.AttributeMasters.AsNoTracking().ToList(), "Id", "AttributeName", sqlval);
            }
        }
    }

    public class AttributeModel
    {
        public Int64 Id { get; set; }
        public string DetailName { get; set; }
        public string IsAcive { get; set; }
        public string Description { get; set; }
        public string AttributeName { get; set; }
        public Int64 AttributeId { get; set; }
        public bool ChkIsActive { get; set; }
        public SelectList DdlAttribute { get; set; }
  
        public string AttributeNameDescription { get; set; }
        public Int32 UsedCount { get; set; }

    }
}