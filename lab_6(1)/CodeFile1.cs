using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6_1_
{
    partial class PrintEdition
    {
        //public string NameOfEdition { get; set; }
        //public int HashCode { get; set; }
        //public PrintEdition(string name)
        //{
        //    NameOfEdition = name;
        //    HashCode = GetHashCode();
        //}
        public override string ToString()
        {
            return NameOfEdition + "(hash code: " + HashCode + ")";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            PrintEdition print = (PrintEdition)obj;
            return (this.NameOfEdition == print.NameOfEdition);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //Get type переписать нельзя
    }
}