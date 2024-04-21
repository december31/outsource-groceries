using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace btlltw
{
    public class Product
    {
        public Product(int id, string tensp, string urlImg, double gia, double giamgia)
        {
            this.id = id;
            this.tensp = tensp;
            url_img = urlImg;
            this.gia = gia;
            this.giamgia = giamgia;
        }

        public Product()
        {
        }

        int id;
        string tensp;
        string url_img;
        double gia;
        double giamgia;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Tensp
        {
            get => tensp;
            set => tensp = value;
        }

        public double Gia
        {
            get => gia;
            set => gia = value;
        }

        public string Url_img
        {
            get => url_img;
            set => url_img = value;
        }

        public double Giamgia
        {
            get => giamgia;
            set => giamgia = value;
        }
    }
}
