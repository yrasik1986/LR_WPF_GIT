using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LR3
{
    class Values
    {
        public double XStart
        {
            get
            {
                return xStart;
            }
            set
            {
                
                xStart = value;
            }
        }

        public double XStop
        {
            get
            {
                return xStop;
            }
            set
            {
                xStop = value;
            }
        }

        public double Step
        {
            get
            {
                return step;
            }
            set
            {              
                step = value;
            }
        }

        public double N
        {
            get
            {
                return n;
            }
            set
            {            
                if (value <= 5)
                {
                    throw new ArgumentException("Значение N должно быть больше 5");
                }
                n = value;                           
            }
        }

        private double xStart;
        private double xStop;
        private double step;
        private double n;
    }
}
