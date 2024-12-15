using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public class SanPham
    {
        public string MA_SP { get; set; }
        public string TEN_SP { get; set;}
        public string MOTA_SP { get; set; }
        public int SOLUONG_SP { get; set; }
        public decimal GIA_BAN { get; set; }
        public decimal GIA_NHAP { get; set; }
        public int TGBAOHANH { get; set; }
        public string ANH_SP { get; set; }
        public string MA_LOAI { get; set; }
        public int Tongtt => (int)(SOLUONG_SP * GIA_BAN);
    }
}
