using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class StudentLinkedList
    {
        private Node head;s

        public bool Insert(Student student)
        {
            Node newNode = new Node(student);

            if (head == null || head.Data.IndexNumber > student.IndexNumber)
            {
                if (head != null && head.Data.IndexNumber == student.IndexNumber) return false;
                newNode.Next = head;
                head = newNode;
                return true;
            }

            Node current = head;
            while (current.Next != null && current.Next.Data.IndexNumber < student.IndexNumber)
            {
                current = current.Next;
            }

            if (current.Next != null && current.Next.Data.IndexNumber == student.IndexNumber)
            {
                return false; // Duplicate index
            }

            newNode.Next = current.Next;
            current.Next = newNode;
            return true;
        }

        public Student Search(int indexNumber)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.IndexNumber == indexNumber)
                    return current.Data;
                if (current.Data.IndexNumber > indexNumber)
                    break;
                current = current.Next;
            }
            return null;
        }

        public bool Remove(int indexNumber)
        {
            if (head == null)
                return false;

            if (head.Data.IndexNumber == indexNumber)
            {
                head = head.Next;
                return true;
            }

            Node current = head;
            while (current.Next != null && current.Next.Data.IndexNumber != indexNumber)
            {
                current = current.Next;
            }

            if (current.Next == null)
                return false;

            current.Next = current.Next.Next;
            return true;
        }

        public void PrintAll()
        {
            if (head == null)
            {
                Console.WriteLine("No students in the list.");
                return;
            }

            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            StudentLinkedList list = new StudentLinkedList();
            string choice;

            do
            {
                Console.WriteLine("\n--- Student Management Menu ---");
                Console.WriteLine("1. Insert student");
                Console.WriteLine("2. Delete student");
                Console.WriteLine("3. Search student");
                Console.WriteLine("4. Print all students");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("Enter Index Number: ");
                            int index = int.Parse(Console.ReadLine());
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter GPA: ");
                            double gpa = double.Parse(Console.ReadLine());
                            Console.Write("Enter Admission Year: ");
                            int year = int.Parse(Console.ReadLine());
                            Console.Write("Enter NIC: ");
                            string nic = Console.ReadLine();

                            Student s = new Student { IndexNumber = index, Name = name, GPA = gpa, AdmissionYear = year, NIC = nic };
                            if (list.Insert(s))
                                Console.WriteLine("Student inserted successfully.");
                            else
                                Console.WriteLine("Error: Duplicate index number.");
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter Index Number to remove: ");
                        int indexToRemove = int.Parse(Console.ReadLine());
                        if (list.Remove(indexToRemove))
                            Console.WriteLine("Student removed successfully.");
                        else
                            Console.WriteLine("Student not found.");
                        break;

                    case "3":
                        Console.Write("Enter Index Number to search: ");
                        int indexToSearch = int.Parse(Console.ReadLine());
                        Student found = list.Search(indexToSearch);
                        if (found != null)
                            Console.WriteLine(found);
                        else
                            Console.WriteLine("Student not found.");
                        break;

                    case "4":
                        Console.WriteLine("\n--- All Students ---");
                        list.PrintAll();
                        break;

                    case "5":
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (choice != "5");
        }
    }

}
}
