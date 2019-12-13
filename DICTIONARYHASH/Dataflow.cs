using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;


namespace DICTIONARYHASH
{
    class Dataflow
    {
        //Khởi tạo danh sách hashtable
        public Hashtable ds = new Hashtable();
        //Tên của file
        public string fileName = "";

        //Lớp khởi tạo mặc định
        public Dataflow()
        {
        }
        //Lớp khởi tạo truyền vào tên file
        public Dataflow(string tenfile)
        {
            fileName = tenfile;
        }
        //Lấy một từ từ mã hash trong ds
        public Word this[int cs]
        {
            get { return (Word)ds[cs]; }
        }
        //Thêm một từ bao gồm khóa và và từ
        public void AddWord(string key, Word data)
        {
            ds.Add(key, data);
        }

        //Thêm một từ bao gồm đầy đủ thông tin
        public void AddWord(string key, string tuloai, string phatam, string nghia)
        {
            Word a = new Word(key, tuloai, phatam, nghia);
            ds.Add(key, a);
        }


       //Thao tác với file txt
        //Hàm write file
        public void WriteFile()					
        {
            if (File.Exists(fileName)) File.Delete(fileName);
            FileStream myFile = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(myFile);
            Word w;
            //string s =  w.tuloai + w.phatam  + w.nghia;

            foreach (DictionaryEntry a in ds)
            {
                w = (Word)a.Value;
                sw.WriteLine(w.Key + "-" + w.Tuloai + "-" + w.Phatam + "-" + w.Nghia);
                sw.Flush();
            }
            sw.Close();
            myFile.Close();
        }

        //Xóa dữ liệu trong 1 trang
        //Xóa bằng cách truyền chuỗi rỗng vào file mới
        public void xoatrang()
        {

            //Nếu file tồn tại thì xóa file đó.
            if (File.Exists(fileName)) File.Delete(fileName);
            //Tạo một file mới
            FileStream myFile = new FileStream(fileName, FileMode.Create);
            //Viết lại file
            StreamWriter sw = new StreamWriter(myFile);
            //Khởi tạo một từ để chuẩn bị viết vào
            Word w = new Word();
            //Chuẩn bị một chuỗi rỗng
            string s = "";

            foreach (DictionaryEntry a in ds)
            {
                sw.WriteLine(s);
                sw.Flush();
            }

            sw.Close();
            myFile.Close();
        }
        //Đọc file
        public void ReadFile()
        {
            string text;
            string[] tam;
            FileStream myFile;
            if (File.Exists(fileName))
            {
                myFile = new FileStream(fileName, FileMode.Open);
                StreamReader sr = new StreamReader(myFile);
                for (; (text = sr.ReadLine()) != null;)
                {
                    tam = text.Split('-');
                    AddWord(tam[0], tam[1], tam[2], tam[3]);
                }
                sr.Close();
                myFile.Close();
            }
            else myFile = new FileStream(fileName, FileMode.Create);
        }



        //Tìm kiếm từ trong file bằng một chuỗi string
        public string SearchWord(string key)
        {
            string s = "";
            ICollection c = ds.Keys; //Danh sách từ
            foreach (string item in c) //Vòng lâp qua từng từ
            {
                //Tìm các từ giống với chuỗi nhập vào
                if (item == key)
                {
                    s = item + " :  " + "\n" + ds[item].ToString();

                    break;
                }

            }
            //Trả về chuỗi tìm được
            return s;
        }

        //Hàm in kết quả ra màn hình
        public override string ToString()
        {
            string kq = "";

            //Tạo một từ điển enumerator để lấy dữ liệu từ dánh sách
            IDictionaryEnumerator enumerator = ds.GetEnumerator();
            while (enumerator.MoveNext()) // xuất tất cả kết quả tìm được
            {
                kq = enumerator.Key + " : " + enumerator.Value.ToString();
            }
            return kq;

        }

        // Hàm xóa 
        public Boolean xoa(string key)
        {
            if (ds.ContainsKey(key))
            {
                ds.Remove(key);
                return true;
            }
            else
                return false;

        }

        //Hàm tìm kiếm
        public Boolean timkiem(string key)
        {
            if (ds.ContainsKey(key))
                return true;
            else return false;
        }
        //
        public string intoanbo()
        {
            string s = "";
            ICollection c = ds.Keys;
            foreach (string item in c)
            {
                s = s + item + "\n";
            }
            return s;
        }



        //
        public void inkey(ref string[] s)
        {
            int i = 0;
            s = new string[ds.Keys.Count];
            ICollection c = ds.Keys;
            foreach (string item in c)
            {
                s[i] = item;
                ++i;
            }
        }
        //Hàm search filter
        public void hienthitucolienquan(string key, ref string[] keys, out int dem)
        {
            dem = 0;
            int i = 0;
            ICollection c = ds.Keys;
            foreach (string item in c)
            {
                if (item.Contains(key))
                {
                    keys[i] = item;
                    i++;
                    dem++;
                }

            }


        }
    }
}
