using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public class HoaDonNhap
    {
        public string MAHD_NHAP { get; set; }
        public string MA_NCC { get; set; }
        public string MA_NV { get; set; }
        public decimal TONGBILL_NHAP { get; set; }
        public string NGAYNHAP { get; set; }
        public HoaDonNhap(string MAHD_NHAP, string MA_NCC, string MA_NV, decimal TONGBILL_NHAP, string NGAYNHAP)
        {
            this.MAHD_NHAP = MAHD_NHAP;
            this.MA_NCC = MA_NCC;
            this.MA_NV = MA_NV;
            this.TONGBILL_NHAP = TONGBILL_NHAP;
            this.NGAYNHAP = NGAYNHAP;
        }
        public HoaDonNhap() { }
    }
}
