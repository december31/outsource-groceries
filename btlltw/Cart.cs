using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace btlltw
{
    public class Cart
    {
        private int idProd,sl;
        private string idMb;

        public string IdMb { get => idMb; set => idMb = value; }
        public int IdProd { get => idProd; set => idProd = value; }
        public int Sl { get => sl; set => sl = value; }

        public Cart()
        {

        }

        public Cart(string _idMb,int _idProd,int _sl = 1)
        {
            this.IdMb = _idMb;
            this.IdProd = _idProd;
            this.Sl = _sl;
        }
    }
}