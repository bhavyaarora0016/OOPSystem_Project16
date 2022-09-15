using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSystem
{
    public class StudentClass : InterOp
    {
		private string sname;

		public string StudentName
		{
			get { return sname; }
			set { sname = value; }
		}

        private int _Class;

        public int Class
        {
            get { return _Class; }
            set { _Class = value; }
        }

        public static List<StudentClass> StudentList = new List<StudentClass>();

        public void PrintData()
        {
            foreach (var item in StudentList)
            {
                Console.WriteLine("Student name: " + item.StudentName);
                Console.WriteLine("class: " + item.Class);
            }

            Console.WriteLine("--------------------");
        }

        public void FileWrite()
        {
            FileStream fs = new FileStream("StudentData.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(fs);
                Console.WriteLine("enter student name: ");
                string name = Console.ReadLine();

                Console.WriteLine("enter class: ");
                string Class = Console.ReadLine();

                sw.WriteLine(name + "," + Class);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        public void FileRead()
        {
            FileStream fs1 = new FileStream("StudentData.txt",FileMode.Open,FileAccess.Read);
            StreamReader sw1 = null;

            try
            {
                sw1 = new StreamReader(fs1);
                bool LastLine = false;
                while (!LastLine)
                {
                    StudentClass s = new StudentClass();
                    String temp = sw1.ReadLine();

                    if (temp == null)
                    {
                        Console.WriteLine("last data reached");
                        break;
                    }
                    s.StudentName = temp.Split('-')[0];
                    s.Class = Convert.ToInt32(temp.Split('-')[1]);
                    StudentClass.StudentList.Add(s);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("error message: " + ex.Message);
            }
            finally
            {
                sw1.Close();
                fs1.Close();
            }
        }

        public void SearchStudent()
        {
            Console.WriteLine("enter student name: ");
            string name = Console.ReadLine();

            var Details = File.ReadLines("StudentData.txt").OrderBy((line => (line.Split(',')[1]))).ToList();

            bool found = false;

            foreach (var item in Details)
            {
                if (item.Contains(name))
                {
                    Console.WriteLine($"Name: {item.Split('-')[0]} \n Class Room  : {item.Split('-')[1]} ");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("student not found. enter a valid name.");
            }
        }







    }
}
