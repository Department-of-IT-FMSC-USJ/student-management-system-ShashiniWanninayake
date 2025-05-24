using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Student
    {
        public int IndexNumber { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public int AdmissionYear { get; set; }
        public string NIC { get; set; }

        public override string ToString()
        {
            return $"Index: {IndexNumber} | Name: {Name} | GPA: {GPA:F2} | Admission Year: {AdmissionYear} | NIC: {NIC}";
        }
    }
}
