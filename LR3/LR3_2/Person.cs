using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LR3_2
{
    [Serializable]
    class Person : IDataErrorInfo
    {
        public Person()
        {
            adres = new Adress();
        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {              
                salary = value;
            }
        }

        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public string Street
        {
            get
            {
                return adres.Street;
            }
            set
            {
                adres.Street = value;
            }
        }

        public string Sity
        {
            get
            {
                return adres.Sity;
            }
            set
            {
                adres.Sity = value;
            }
        }

        public string House
        {
            get
            {
                return adres.House;
            }
            set
            {
                adres.House = value;
            }
        }

        public string Error 
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (!Regex.Match(Name + "S", "^[А-ЯA-Z][а-яА-Яa-zA-Z]*$").Success)
                        {
                            error = "Неверный формат (Начинается с заглавной и только буквы русского и латинского алфавита)!";
                        }

                            break;
                    case "Salary":                       

                        if ((Salary <= 0) || (Salary > 10000))
                        {
                            error = "Зарплата должена быть больше 0 и меньше 10000";
                        }
                        break;
                    case "Position":
                        if (!Regex.Match(Position + "s", "^[а-яa-z]*$").Success)
                        {
                            error = "Неверный формат (только прописные буквы русского и латинского алфавита)!";
                        }
                        break;
                    case "Street":
                        if (!Regex.Match(Street + "S", "^[А-ЯA-Z][0-9а-яА-Яa-zA-Z]*$").Success)
                        {
                            error = "Неверный формат (Первая заглавная, остальные буквы русского и латинского алфавита и цифры)!";
                        }
                        break;
                    case "Sity":
                        if (!Regex.Match(Sity + "S", "^[А-ЯA-Z][а-яА-Яa-zA-Z]*$").Success)
                        {
                            error = "Неверный формат (Начинается с заглавной и только буквы русского и латинского алфавита)!";
                        }
                        break;
                    case "House":
                        if (!Regex.Match(House + "1", "^[1-9][0-9а-яА-Яa-zA-Z]*$").Success)
                        {
                            error = "Неверный формат (Начинается с цифры + буквы русского и латинского алфавита и цифры )!";
                        }
                        break;                 
                }
                return error;
            }

        }

        public override string ToString()
        {            
            return Name + "; ЗП: " + Salary + "; Должность: " + Position + "; " + adres.ToString();
        }

        private string name;
        private decimal salary;
        private string position;
        private Adress adres;
    }
}
