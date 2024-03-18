using DLL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Deployment.Internal;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace BUS
{
    public class DataService
    {
        Model1 db = new Model1();
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            return db.TaiKhoans.ToList();
        }
        public List<LoaiTaiKhoan> GetAllLoaiTaiKhoan()
        {
            return db.LoaiTaiKhoans.ToList();

        }

        public void Addcustommer(KhachHang custommer)
        {
            db.KhachHangs.AddOrUpdate(custommer);
            db.SaveChanges();
        }

        public void addAccount(TaiKhoan tk)
        {
            db.TaiKhoans.AddOrUpdate(tk);
            db.SaveChanges();
        }

        public TaiKhoan FindAccount(string sdt)
        {
            return db.TaiKhoans.FirstOrDefault(p => p.Số_điện_thoại == sdt);
        }

        public TaiKhoan FindAccountID(int id)
        {
            return db.TaiKhoans.FirstOrDefault(p => p.KhachHangId == id);
        }


        public Boolean FindNameAgain(string name)
        {
            return db.KhachHangs.FirstOrDefault(p => p.TenKhachHang == name) == null ? true : false;
        }

        public KhachHang FindCustomer(int id)
        {
            return db.KhachHangs.FirstOrDefault(p => p.KhachHangId == id);
        }
        public TaiKhoan FindAccountIDkh(int id)
        {
            return db.TaiKhoans.FirstOrDefault(p => p.KhachHangId == id);
        }


        public void removeAccount(string phone)
        {

            db.TaiKhoans.Remove(db.TaiKhoans.FirstOrDefault(p => p.Số_điện_thoại == phone));
            db.SaveChanges();
        }
        public void Removecustommer(string Name)
        {
            db.KhachHangs.Remove(db.KhachHangs.FirstOrDefault(p => p.TenKhachHang == Name));
            db.SaveChanges();
        }



        public int GetVaiTroID(String role)
        {
            return db.LoaiTaiKhoans.FirstOrDefault(x => x.LoaiVaiTro == role).VaiTroID;
        }

        public void KeyLogAndOpen(string phoneNumber, int VTID)
        {
            TaiKhoan tk = db.TaiKhoans.FirstOrDefault(p => p.Số_điện_thoại == phoneNumber);
            tk.VaiTroID = VTID;
            db.TaiKhoans.AddOrUpdate(tk);
            db.SaveChanges();
        }

        //form ve
        public List<Ve> GetAllVe()
        {
            return db.Ves.ToList();
        }
        public List<ThongTinVe> GetAllTTve()
        {
            return db.ThongTinVes.ToList();
        }

        public String GetName(int id)
        {
            return db.KhachHangs.FirstOrDefault(p => p.KhachHangId == id).TenKhachHang;
        }

        public void RemoveVe(int id)
        {
            db.Ves.Remove(db.Ves.FirstOrDefault(p => p.VeID == id));
            db.SaveChanges();
        }


        public void RemoThongTinVe(ThongTinVe ttv)
        {

            db.ThongTinVes.Remove(ttv);
            db.SaveChanges();
        }

        public List<ThongTinVe> GetAllThongtinPve(int id)
        {
            return db.ThongTinVes.Where(p => p.VeID == id).ToList();
        }

        public void RemoveListTtv(int id)
        {
            List<ThongTinVe> ListTtv = GetAllTTve().Where(p => p.VeID == id).ToList();
            foreach (var item in ListTtv)
            {
                RemoThongTinVe(item);
            }
        }

        public List<ChiTietDichVu> GetAllChiTietDichVu()
        {
            return db.ChiTietDichVus.ToList();
        }

        public void RemoCtdv(ChiTietDichVu ttv)
        {

            db.ChiTietDichVus.Remove(ttv);
            db.SaveChanges();
        }

        public void RemoveListDv(int id)
        {
            List<ChiTietDichVu> ListCTdv = GetAllChiTietDichVu().Where(p => p.VeID == id).ToList();
            foreach (var item in ListCTdv)
            {
                RemoCtdv(item);
            }
        }

        //form dich vu
        public List<DichVu> GetAllDichVu()
        {
            return db.DichVus.ToList();
        }

        public DichVu FindService(int id)
        {
            return db.DichVus.FirstOrDefault(p => p.DichVuID == id);
        }

        public void AddOrUpdateService(DichVu dv)
        {
            db.DichVus.AddOrUpdate(dv);
            db.SaveChanges();
        }

        public void RemoveServide(int id)
        {
            db.DichVus.Remove(db.DichVus.FirstOrDefault(p => p.DichVuID == id));
            db.SaveChanges();
        }

        public double FindGia(int  id)
        {
            return db.DichVus.FirstOrDefault(p => p.DichVuID == id).Giá;
        }

        //from fim

        public List<ThongtinPhim> GetALLThongTinPhim()
        {
            return db.ThongtinPhims.ToList();
        }
        public List<TheLoaiPhim> GetALLTheloaiPhim()
        {
            return db.TheLoaiPhims.ToList();
        }

        //
        public void AddOrUpdateCTTheLoaiPhim(ChiTIetTheLoaiPhinm CtTlp)
        {
            db.ChiTIetTheLoaiPhinms.AddOrUpdate(CtTlp);
            db.SaveChanges();
        }
        public void AddOrUpdatePhim(ThongtinPhim p)
        {
            db.ThongtinPhims.Add(p);
            db.SaveChanges();
        }
        //public void AddOrUpdateCtDienVien(DienVien dv)
        //{
        //    db.DienViens.AddOrUpdate(dv);
        //    db.SaveChanges();
        //}
        //public void removeCtdienVien(ChiTietDienVien ctdv)
        //{
        //    db.ChiTietDienViens.Remove(ctdv);
        //    db.SaveChanges();
        //}
        //public void removeListCtDienVien(int idPhm)
        //{
        //    var ListData = db.ChiTietDienViens.Where(p => p.PhimID == idPhm);
        //    foreach(var Data in ListData) {
        //        removeCtdienVien(Data);
        //    }       
        //}



        //remove movie
        public ThongtinPhim findThongTinPHim(int id)
        {
            return db.ThongtinPhims.FirstOrDefault(p => p.PhimId == id);
        }
        public void removeMovie(ThongtinPhim movie)
        {
            removeListCtTheLoaiPhim(movie.PhimId);
            db.ThongtinPhims.Remove(movie);
            db.SaveChanges();
        }
        public void removeCtTheLoaiPhim(ChiTIetTheLoaiPhinm cttlp)
        {
            db.ChiTIetTheLoaiPhinms.Remove(cttlp);
            db.SaveChanges();
        }
        public void removeListCtTheLoaiPhim(int idPhm)
        {
            var ListData = db.ChiTIetTheLoaiPhinms.Where(p => p.PhimID == idPhm).ToList();
            if (ListData == null) { return; }
            foreach (var Data in ListData)
            {
                removeCtTheLoaiPhim(Data);
            }
        }



        //end remove




        public Boolean isTlp(int PhimId, int TheLoaiId)
        {
            var result = db.ChiTIetTheLoaiPhinms.Where(p => p.TheLoaiID == TheLoaiId && p.PhimID == PhimId).ToList();
            if (result == null)
            {
                return false;
            }

            return true;
        }

        public List<ChiTIetTheLoaiPhinm> getListTheLoai(int PhimId)
        {
            return db.ChiTIetTheLoaiPhinms.Where(p => p.PhimID == PhimId).ToList();
        }

        public string GetNameTheLoai(int phimID)
        {
            string result = "";
            foreach (var item in getListTheLoai(phimID))
            {
                result = result + item.TheLoaiPhim.Tên_Thể_loại + ",";
            }
            return result;
        }

        //form lich chieu phim
        public List<LichChieuPhim> GetAllLichChieuPhim()
        {
            return db.LichChieuPhims.ToList();
        }

        public void addorUpdateLichChieuPhim(LichChieuPhim lcp)
        {
            db.LichChieuPhims.AddOrUpdate(lcp);
            db.SaveChanges();

        }

        public List<LichChieuPhim> GetLichChieuPhim(int idPhim)
        {
            return db.LichChieuPhims.Where(p=>p.PhimId==idPhim).ToList();
        }

        public LichChieuPhim FindLichChieuPhim(int idLCp)
        {
            return db.LichChieuPhims.FirstOrDefault(p => p.LCPId == idLCp);
        }



        public void removeLichChieuPhim(int Id)
        {

            db.LichChieuPhims.Remove(db.LichChieuPhims.FirstOrDefault(p => p.LCPId == Id));
            db.SaveChanges();
        }

        //public LichChieuPhim findLichChieuPhim()
        //{
        //    re
        //}

        //Phong chieu
        public List<PhongChieu> getALlPhongChieu()
        {
            return db.PhongChieux.ToList();
        }

        public int GetIdPhong(string tenPhong)
        {
            return db.PhongChieux.FirstOrDefault(p => p.Tên_Phòng == tenPhong).PhongChieuID;
        }

        public string GetTheLoai(ThongtinPhim ttp)
        {
            string Result = "";
            var data=db.ChiTIetTheLoaiPhinms.Where(p=>p.PhimID==ttp.PhimId);
            foreach(var item in data)
            {
                Result += item.TheLoaiPhim.Tên_Thể_loại+";";
            }
            return Result;
        }

        public PhongChieu FindPhongChieu(int id)
        {
            return db.PhongChieux.FirstOrDefault(p=>p.PhongChieuID==id);    
        }


        public void AddVe(Ve v)
        {
            db.Ves.Add(v);
            db.SaveChanges();
        }

        public void AddTtv(ThongTinVe ttv)
        {
            db.ThongTinVes.Add(ttv);
            db.SaveChanges();
        }

        public void AddCTDV(ChiTietDichVu Ctdv)
        {
            db.ChiTietDichVus.AddOrUpdate(Ctdv);
            db.SaveChanges();
        }


        public List<Ghe> getAllGhe()
        {
            return db.Ghes.ToList();    
        }

        public void AddChiTietGhe(ChiTietGhe ctg)
        {
            db.ChiTietGhes.AddOrUpdate(ctg);
            db.SaveChanges();
        }

       // public int FindIDLCpFromMovie(thong )

        public string GetPhone(int idKh)
        {
           return db.TaiKhoans.FirstOrDefault(p=>p.KhachHangId==idKh).Số_điện_thoại.ToString();    
        }

        public int countVeIdKh(int idKh)
        {
            return db.Ves.Count(p=>p.KhachHangId==idKh);
        }

        public int CountChar(int iID)
        {
            return db.ChiTietGhes.Where(p=>p.TTGID==1 && p.LCPID== iID).Count(); 
        }

        

    }

}