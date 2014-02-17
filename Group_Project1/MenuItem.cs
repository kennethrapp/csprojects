using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Group_Project1
{
    class MenuItem
    {
       
        private string _name;
        private decimal _cost;
        private string _size;
        private decimal _quantity = 1;
        private string _signature;

        private List<String> _toppings = new List<String>();

        /* using the md5 of the data as a signature. */
        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public void SetToppings(List<String> toppings)
        {
            _toppings = toppings;
        }

        public List<String> GetToppings()
        {
            return _toppings;
        }

        public int getNumToppings()
        {
            return _toppings.Count();
        }



        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

        public decimal Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        // with toppings
        public MenuItem(decimal q, string s, string n, decimal c, List<String> t)
        {
            Quantity = q;
            Size = s;
            Name = n;
            Cost = c;
            _toppings = t;

            ReHash();
        }

        // without toppings
        public MenuItem(decimal q, string s, string n, decimal c)
        {
            Quantity = q;
            Size = s;
            Name = n;
            Cost = c;

            ReHash();
        }

        public string Signature
        {
            get
            {
                return _signature;
            }

        }

        // rebuild the md5 hash (the signature is the name, size and toppings)
        public void ReHash() 
        {
            
            String st = "";
            
            st += Name + Size;

            if (getNumToppings() > 0) {
               
                foreach (String ss in GetToppings())
                {
                    st += ss;
                }
            }

            _signature = CalculateMD5Hash(st);
        }
    }
}
