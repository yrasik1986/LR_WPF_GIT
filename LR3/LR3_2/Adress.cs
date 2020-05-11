using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3_2
{
    [Serializable]
    class Adress
    {
        public string Sity
        {
            get
            {
                return sity;
            }
            set
            {
                sity = value;
            }
        }

        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }

        public string House
        {
            get
            {
                return house;
            }
            set
            {
                house = value;
            }
        }

        public override string ToString()
        {
            return " Адрес: " + "г." + Sity + ", ул. " + Street + ", д. " + House;
        }

        private string sity;
        private string street;
        private string house;
    }
}
