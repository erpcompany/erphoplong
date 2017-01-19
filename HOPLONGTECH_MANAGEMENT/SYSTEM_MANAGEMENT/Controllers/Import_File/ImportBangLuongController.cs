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
    public class ImportBangLuongController : Controller
    {
        int so_dong_thanh_cong;

        SYSTEM_DATABASEEntities db = new SYSTEM_DATABASEEntities();
        // GET: ImportBangLuong
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
                        BANG_LUONG BL = new BANG_LUONG();
                        String username = ds.Tables[0].Rows[i][0].ToString();
                        var query = (from u in db.USERS
                                     where u.USERNAME == username
                                     select u).FirstOrDefault();

                        BL.USER_ID = query.USER_ID;
                        BL.LUONG_CO_BAN = ds.Tables[0].Rows[i][3].ToString();
                        BL.LUONG_BAO_HIEM = ds.Tables[0].Rows[i][4].ToString();
                        BL.PHU_CAP_AN_TRUA = ds.Tables[0].Rows[i][5].ToString();
                        BL.PHU_CAP_DI_LAI_DIEN_THOAI = ds.Tables[0].Rows[i][6].ToString();
                        BL.PHU_CAP_THUONG_DOANH_SO = ds.Tables[0].Rows[i][7].ToString();
                        BL.PHU_CAP_TRACH_NHIEM = ds.Tables[0].Rows[i][8].ToString();
                        BL.CONG_CO_BAN = ds.Tables[0].Rows[i][9].ToString();
                        BL.CONG_CO_BAN_NGAY = ds.Tables[0].Rows[i][10].ToString();
                        BL.CONG_CO_BAN_GIO = ds.Tables[0].Rows[i][11].ToString();
                        BL.BAO_HIEM_CONG_TY = ds.Tables[0].Rows[i][12].ToString();
                        BL.BAO_HIEM_NHAN_VIEN = ds.Tables[0].Rows[i][13].ToString();

                        BL.LUONG_THUC_TE_CONG_LAM_THUC = ds.Tables[0].Rows[i][14].ToString();
                        BL.LUONG_THUC_TE_SO_TIEN = ds.Tables[0].Rows[i][15].ToString();
                        BL.LUONG_LAM_THEM_CONG_NGAY_THUONG = ds.Tables[0].Rows[i][16].ToString();
                        BL.LUONG_LAM_THEM_TIEN_CONG_NGAY_THUONG = ds.Tables[0].Rows[i][17].ToString();
                        BL.LUONG_LAM_THEM_CONG_NGAY_NGHI = ds.Tables[0].Rows[i][18].ToString();
                        BL.LUONG_LAM_THEM_TIEN_CONG_NGAY_NGHI = ds.Tables[0].Rows[i][19].ToString();
                        BL.LUONG_LAM_THEM_CONG_NGAY_LE = ds.Tables[0].Rows[i][20].ToString();
                        BL.LUONG_LAM_THEM_TIEN_CONG_NGAY_LE = ds.Tables[0].Rows[i][21].ToString();
                        BL.TONG_TIEN_CONG = ds.Tables[0].Rows[i][22].ToString();
                        BL.TAM_UNG = ds.Tables[0].Rows[i][23].ToString();
                        BL.GIO_DI_TRE = ds.Tables[0].Rows[i][24].ToString();

                        BL.PHAT_DI_TRE = ds.Tables[0].Rows[i][25].ToString();
                        BL.CONG_DOAN = ds.Tables[0].Rows[i][26].ToString();
                        BL.LUONG_LAO_CONG = ds.Tables[0].Rows[i][27].ToString();
                        BL.THUC_LINH = ds.Tables[0].Rows[i][28].ToString();
                        BL.THANG_LINH_LUONG = ds.Tables[0].Rows[i][29].ToString();
                        db.BANG_LUONG.Add(BL);

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
                        int id = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                        string thang = ds.Tables[0].Rows[i][29].ToString();
                        var query = (from u in db.BANG_LUONG
                                     where u.USER_ID == id && u.THANG_LINH_LUONG == thang
                                     select u).FirstOrDefault();
                        //BANG_LUONG BL = new BANG_LUONG();
                        //BL.USER_ID = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                        query.LUONG_CO_BAN = ds.Tables[0].Rows[i][3].ToString();
                        query.LUONG_BAO_HIEM = ds.Tables[0].Rows[i][4].ToString();
                        query.PHU_CAP_AN_TRUA = ds.Tables[0].Rows[i][5].ToString();
                        query.PHU_CAP_DI_LAI_DIEN_THOAI = ds.Tables[0].Rows[i][6].ToString();
                        query.PHU_CAP_THUONG_DOANH_SO = ds.Tables[0].Rows[i][7].ToString();
                        query.PHU_CAP_TRACH_NHIEM = ds.Tables[0].Rows[i][8].ToString();
                        query.CONG_CO_BAN = ds.Tables[0].Rows[i][9].ToString();
                        query.CONG_CO_BAN_NGAY = ds.Tables[0].Rows[i][10].ToString();
                        query.CONG_CO_BAN_GIO = ds.Tables[0].Rows[i][11].ToString();
                        query.BAO_HIEM_CONG_TY = ds.Tables[0].Rows[i][12].ToString();
                        query.BAO_HIEM_NHAN_VIEN = ds.Tables[0].Rows[i][13].ToString();

                        query.LUONG_THUC_TE_CONG_LAM_THUC = ds.Tables[0].Rows[i][14].ToString();
                        query.LUONG_THUC_TE_SO_TIEN = ds.Tables[0].Rows[i][15].ToString();
                        query.LUONG_LAM_THEM_CONG_NGAY_THUONG = ds.Tables[0].Rows[i][16].ToString();
                        query.LUONG_LAM_THEM_TIEN_CONG_NGAY_THUONG = ds.Tables[0].Rows[i][17].ToString();
                        query.LUONG_LAM_THEM_CONG_NGAY_NGHI = ds.Tables[0].Rows[i][18].ToString();
                        query.LUONG_LAM_THEM_TIEN_CONG_NGAY_NGHI = ds.Tables[0].Rows[i][19].ToString();
                        query.LUONG_LAM_THEM_CONG_NGAY_LE = ds.Tables[0].Rows[i][20].ToString();
                        query.LUONG_LAM_THEM_TIEN_CONG_NGAY_LE = ds.Tables[0].Rows[i][21].ToString();
                        query.TONG_TIEN_CONG = ds.Tables[0].Rows[i][22].ToString();
                        query.TAM_UNG = ds.Tables[0].Rows[i][23].ToString();
                        query.GIO_DI_TRE = ds.Tables[0].Rows[i][24].ToString();

                        query.PHAT_DI_TRE = ds.Tables[0].Rows[i][25].ToString();
                        query.CONG_DOAN = ds.Tables[0].Rows[i][26].ToString();
                        query.LUONG_LAO_CONG = ds.Tables[0].Rows[i][27].ToString();
                        query.THUC_LINH = ds.Tables[0].Rows[i][28].ToString();
                        query.THANG_LINH_LUONG = ds.Tables[0].Rows[i][29].ToString();
                       // db.BANG_LUONG.Add(BL);

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
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View();
        }
    }
}