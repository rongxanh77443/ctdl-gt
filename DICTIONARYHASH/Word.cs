using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DICTIONARYHASH
{
    // Lớp đối tượng từ
    class Word
    {

        private string key;
        //get set 
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        //Mỗi từ bao gồm ba thành phần: từ loại, phát âm và nghĩa
        public string tuloai;
        public string phatam;
        public string nghia;

        //Khởi tạo từ loại
        public string Tuloai
        {
            get { return tuloai; }
            set { tuloai = value; }
        }
        //Khởi tạo phát âm
        public string Phatam
        {
            get { return phatam; }
            set { phatam = value; }
        }
        //Khởi tạo nghĩa
        public string Nghia
        {
            get { return nghia; }
            set { nghia = value; }
        }
        //Hàm khởi tạo mặc định
        public Word()
        {
        }
        //Hàm khởi tạo một từ mới, key chính là mã hash
        public Word(string k, string tl, string pa, string ngh)
        {
            key = k;
            tuloai = tl;
            phatam = pa;
            nghia = ngh;
        }
        //Hàm khởi tạo với key string
        public Word(string k)
        {
            key = k;
        }
        //int ra
        //Hàm nối chuỗi xuất kết quả đầy đủ của một từ
        public override string ToString()
        {
            string s = "";
            s = tuloai + phatam + nghia;
            return s;


        }
    }
}
