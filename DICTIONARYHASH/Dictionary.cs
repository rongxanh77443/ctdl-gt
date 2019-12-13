using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DICTIONARYHASH
{
    class Dictionary
    {
        // Khai báo 1 mảng dataflow gồm 26 ô ứng với 26 ký tự trong bảng alphabet
        public Dataflow[] ds = new Dataflow[26];
        // Khai báo 1 mảng chứa tên file chưa dữ liệu ứng với từng ký tự
        private string[] dsFileName = new string[26];

        //Khởi tạo bộ từ điển từ tất cả các file hiện lên trên list từ
        public Dictionary()			
        {
            dsFileName[0] = "a.txt"; dsFileName[1] = "b.txt"; dsFileName[2] = "c.txt"; dsFileName[3] = "d.txt";
            dsFileName[4] = "e.txt"; dsFileName[5] = "f.txt"; dsFileName[6] = "g.txt"; dsFileName[7] = "h.txt";
            dsFileName[8] = "i.txt"; dsFileName[9] = "j.txt"; dsFileName[10] = "k.txt"; dsFileName[11] = "l.txt";
            dsFileName[12] = "m.txt"; dsFileName[13] = "n.txt"; dsFileName[14] = "o.txt"; dsFileName[15] = "p.txt";
            dsFileName[16] = "q.txt"; dsFileName[17] = "r.txt"; dsFileName[18] = "s.txt"; dsFileName[19] = "t.txt";
            dsFileName[20] = "u.txt"; dsFileName[21] = "v.txt"; dsFileName[22] = "w.txt"; dsFileName[23] = "x.txt";
            dsFileName[24] = "y.txt"; dsFileName[25] = "z.txt";
            for (int i = 0; i < 26; i++)
            {
                ds[i] = new Dataflow(dsFileName[i]);
            }
        }
        // Khởi tạo một dataflow từ một số hash được.
        public Dataflow this[int index]
        {
            get { return (Dataflow)ds[index]; }
        }
        // Thao tác dữ liệu trên file
        // Truyền dữ liệu vào file
        public void WriteToData()
        {
            foreach (Dataflow a in ds)
                a.WriteFile();
        }
        //Xóa dữ liệu
        public void xoadata()
        {
            foreach (Dataflow a in ds)
                a.xoatrang();
        }
        //Đọc dữ liệu
        public void ReadFromData()
        {
            foreach (Dataflow a in ds)
                a.ReadFile();
        }


        // Hàm hash: Do bảng chữ cái có 26 ký tự, bắt đầu từ các ký tự a....z, theo bảng ascii ứng với 97...122
        public int hashkey(string key)
        {
            return ((int)key[0])%97;
        }
        //Lấy kết quả từ mã hash trong ds
        public string writedata(string key)
        {
            string kq = "";
            int i = hashkey(key);
            //Ứng với danh sách mã hash rồi search từ đó bằng key
            kq = ds[i].SearchWord(key);
            return kq;
        }
        //Hàm search filter, truyền một chuỗi string và trả về một mảng chưa từ khóa đó
        public void HienThiTuLienQuan(string key, ref string[] mangchuakey)
        {
            int i = hashkey(key);
            string[] keys = new string[50];
            int dem;
            ds[i].hienthitucolienquan(key, ref keys, out dem);
            for (int j = 0; j < dem; j++)
            {
                mangchuakey[j] = keys[j];
            }
        }
        //Xóa từ
        public bool delete(string key)
        {
            //Hash lấy số thứ tự của ds
            int i = hashkey(key);
            //Nếu tìm thấy từ thì sẽ xóa
            if (ds[i].timkiem(key) == true)
            {
                ds[i].xoa(key);

                return true;

            }
            //Nếu không tìm thấy trả về null
            else return false;

        }
        //Thêm từ vào danh sách
        public bool themtu(string key, string tuloai, string phatam, string nghia)
        {
            //Lấy mã hash
            int i = hashkey(key);
            if (ds[i].timkiem(key) == false)
            {
                ds[i].AddWord(key, tuloai, phatam, nghia);
                return true;
            }
            else return false;

        }
    }
}
