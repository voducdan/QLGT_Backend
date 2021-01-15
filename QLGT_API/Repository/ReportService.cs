using QLGT_API.Data;
using QLGT_API.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLGT_API.Repository;
namespace QLGT_API.Repository
{
    public class ReportService:BaseService
    {
        private readonly BienBangService bienBangService;
        public ReportService(QLGTDBContext context, BienBangService bienBangService) :base(context)
        {
            this.bienBangService = bienBangService;
        }

        public List<LoiViPhamReportView> BienBangReport()
        {
            var data = context.DANH_SACH_LOI_VI_PHAM.Join(context.BIEN_BANG, ds => ds.MA_BIEN_BANG, bb => bb.MA_BIEN_BANG, (ds, bb) =>
            new
            {
                MA_LOI_VI_PHAM = ds.MA_LOI_VI_PHAM,
                NGAY_LAP = bb.NGAY_LAP.Day
            }).GroupBy(a => a.NGAY_LAP).Select(gr => new LoiViPhamReportView
            {
                day = gr.Key,
                count = gr.Count()
            }).ToList();
            return data;
        }
        public List<DanhSachLoiViPhamView> DanhSachLoiViPham()
        {
            var list = new List<DanhSachLoiViPhamView>();
            var data = context.BIEN_BANG.Select(a => a.MA_BIEN_BANG).ToList();
            foreach (var item in data)
            {
                list.AddRange(bienBangService.GetDanhSachLoiViPham(item));
            }
            return list;
        }
    }
}
