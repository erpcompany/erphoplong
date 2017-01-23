using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using SYSTEM_MANAGEMENT.Models;
using SYSTEM_MANAGEMENT.Models.BussinessModel;

namespace SYSTEM_MANAGEMENT.Controllers.Import_File
{
    [AuthorizeBussiness]
    public class ImportBangChamCongController : Controller
    {
        int so_dong_thanh_cong;
        SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();
        // GET: ImportBangChamCong
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                DataSet ds = new DataSet();
                if (Request.Files["file"].ContentLength > 0)
                {
                    string fileExtension =
                                         System.IO.Path.GetExtension(Request.Files["file"].FileName);

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {

                            System.IO.File.Delete(fileLocation);
                        }
                        Request.Files["file"].SaveAs(fileLocation);
                        string excelConnectionString = string.Empty;
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        //connection String for xls file format.
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {

                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        }
                        //Create Connection to Excel work book and add oledb namespace
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        DataTable dt = new DataTable();

                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dt == null)
                        {
                            return null;
                        }

                        String[] excelSheets = new String[dt.Rows.Count];
                        int t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                        string query = string.Format("Select * from [{0}]", excelSheets[0]);
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                        {
                            dataAdapter.Fill(ds);
                        }
                    }
                    if (fileExtension.ToString().ToLower().Equals(".xml"))
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {
                            System.IO.File.Delete(fileLocation);
                        }

                        Request.Files["FileUpload"].SaveAs(fileLocation);
                        XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                        // DataSet ds = new DataSet();
                        ds.ReadXml(xmlreader);
                        xmlreader.Close();
                    }
                    so_dong_thanh_cong = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        
                        String username = ds.Tables[0].Rows[i][2].ToString();
                        var query = (from u in db.USERS
                                     where u.USERNAME == username
                                     select u).FirstOrDefault();
                        int id = query.USER_ID;
                        BANG_CHAM_CONG BCC = new BANG_CHAM_CONG();
                        BCC.USER_ID = id;
                        BCC.NGAY_CHUAN = ds.Tables[0].Rows[i][3].ToString();
                        BCC.GIO_DI_MUON = ds.Tables[0].Rows[i][4].ToString();
                        BCC.GIO_VE_SOM = ds.Tables[0].Rows[i][5].ToString();
                        BCC.TANG_CA_NGAY_THUONG = ds.Tables[0].Rows[i][6].ToString();
                        BCC.TANG_CA_NGAY_LE = ds.Tables[0].Rows[i][7].ToString();
                        BCC.SO_LAN_QUEN_CHAM = ds.Tables[0].Rows[i][8].ToString();
                        BCC.SO_NGAY_NGHI = ds.Tables[0].Rows[i][9].ToString();
                        BCC.CONG_THUC_TE = ds.Tables[0].Rows[i][10].ToString();
                        BCC.UNG_LUONG = ds.Tables[0].Rows[i][11].ToString();
                        BCC.GHI_CHU = ds.Tables[0].Rows[i][12].ToString();
                        BCC.THANG_CHAM_CONG = ds.Tables[0].Rows[i][13].ToString();

                        db.BANG_CHAM_CONG.Add(BCC);

                        db.SaveChanges();
                        so_dong_thanh_cong++;
                    }
                
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. "+Environment.NewLine+ " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(HttpPostedFileBase file)
        {
            try
            {
                DataSet ds = new DataSet();
                if (Request.Files["file"].ContentLength > 0)
                {
                    string fileExtension =
                                         System.IO.Path.GetExtension(Request.Files["file"].FileName);

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {

                            System.IO.File.Delete(fileLocation);
                        }
                        Request.Files["file"].SaveAs(fileLocation);
                        string excelConnectionString = string.Empty;
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        //connection String for xls file format.
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {

                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        }
                        //Create Connection to Excel work book and add oledb namespace
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        DataTable dt = new DataTable();

                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dt == null)
                        {
                            return null;
                        }

                        String[] excelSheets = new String[dt.Rows.Count];
                        int t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                        string query = string.Format("Select * from [{0}]", excelSheets[0]);
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                        {
                            dataAdapter.Fill(ds);
                        }
                    }
                    if (fileExtension.ToString().ToLower().Equals(".xml"))
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {
                            System.IO.File.Delete(fileLocation);
                        }

                        Request.Files["FileUpload"].SaveAs(fileLocation);
                        XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                        // DataSet ds = new DataSet();
                        ds.ReadXml(xmlreader);
                        xmlreader.Close();
                    }
                    so_dong_thanh_cong = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        String username = ds.Tables[0].Rows[i][2].ToString();
                        var query1 = (from u in db.USERS
                                     where u.USERNAME == username
                                     select u).FirstOrDefault();
                        int id = query1.USER_ID;
                        string thang = ds.Tables[0].Rows[i][13].ToString();
                        var query = (from u in db.BANG_CHAM_CONG
                                     where u.USER_ID== id && u.THANG_CHAM_CONG == thang
                                     select u).FirstOrDefault();
                        //BANG_CHAM_CONG BCC = new BANG_CHAM_CONG();
                       // BCC.USER_ID = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                        query.NGAY_CHUAN = ds.Tables[0].Rows[i][3].ToString();
                        query.GIO_DI_MUON = ds.Tables[0].Rows[i][4].ToString();
                        query.GIO_VE_SOM = ds.Tables[0].Rows[i][5].ToString();
                        query.TANG_CA_NGAY_THUONG = ds.Tables[0].Rows[i][6].ToString();
                        query.TANG_CA_NGAY_LE = ds.Tables[0].Rows[i][7].ToString();
                        query.SO_LAN_QUEN_CHAM = ds.Tables[0].Rows[i][8].ToString();
                        query.SO_NGAY_NGHI = ds.Tables[0].Rows[i][9].ToString();
                        query.CONG_THUC_TE = ds.Tables[0].Rows[i][10].ToString();
                        query.UNG_LUONG = ds.Tables[0].Rows[i][11].ToString();
                        query.GHI_CHU = ds.Tables[0].Rows[i][12].ToString();
                        //query.THANG_CHAM_CONG = ds.Tables[0].Rows[i][13].ToString();
                        db.SaveChanges();
                        so_dong_thanh_cong++;
                    }

                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
            }
            finally
            {
                ViewBag.Message = "Đã cập nhật thành công " + so_dong_thanh_cong + " dòng";
            }
            return View();
        }

    }
}