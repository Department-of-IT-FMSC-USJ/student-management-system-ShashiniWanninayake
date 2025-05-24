using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Node
    {
        public Student Data { get => Data; set => Data = value; }
        public Node Next { get=> Next; set=>Next = value; }

        public Node(Student student)
        {
            Data = student;
            Next = null;
        }
    }





}
