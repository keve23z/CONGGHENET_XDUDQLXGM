using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public class KhachHang
    {
        public string SDT_KH { get; set; }
        public string TENKH { get; set; }
        public string DIACHI_KH { get; set; }
        public string MAIL { get; set; }
        public KhachHang(string sdtKH, string tenKH, string diaChiKH, string mail)
        {
            SDT_KH = sdtKH;
            TENKH = tenKH;
            DIACHI_KH = diaChiKH;
            MAIL = mail;
        }
        public KhachHang() { }
    }
}
