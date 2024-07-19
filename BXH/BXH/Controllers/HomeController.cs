using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using BXH.Models;


namespace BXH.Controllers
{
    public class HomeController : Controller
    {

        BXHEntities db = new BXHEntities();
        
        //lấy ra tất cả các thời gian trong bxh
        public ActionResult Index()
        {
           
            ViewBag.lstThoiGian = db.BXH.Select(x => x.THOIGIAN).Distinct().ToList();
            return View();
        }

        //viết hàm lấy ra ds người chơi xếp hạng theo 1 tháng cụ thể
        
        public ActionResult BangXepHang(string thoiGian)
        {

            var lstNguoiChoi = db.NGUOICHOI
                                .Where(nguoiChoi => nguoiChoi.BXH.Any(bxh => bxh.THOIGIAN == thoiGian))
                                .ToList();

            ViewBag.lstNguoiChoiTheothang = lstNguoiChoi;
            return View(lstNguoiChoi);
        }

    }
}