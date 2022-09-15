using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOPSystem
{
    public class SubjectClass : InterOp
    {
        public static List<SubjectClass> SubjectList = new List<SubjectClass>();

		private string subjectname;

		public string SubjectName
		{
			get { return subjectname; }
			set { subjectname = value; }
		}

		private int subjectcode;

		public int SubjectCode
		{
			get { return subjectcode; }
			set { subjectcode = value; }
		}

		public void FileRead()
		{
			FileStream fs = new FileStream("SubjectData.txt",FileMode.Open,FileAccess.Read);
			StreamReader sr = null;

            try
            {
                sr = new StreamReader(fs);
                bool LastLine = false;
                while (!LastLine)
                {
                    SubjectClass s = new SubjectClass();
                    String temp = sr.ReadLine();
                    if (temp == null)
                    {
                        Console.WriteLine("Last Data reached...");
                        break;
                    }
                    s.SubjectName = temp.Split('-')[0];
                    s.SubjectCode = Convert.ToInt32(temp.Split('-')[1]);
                    SubjectClass.SubjectList.Add(s);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message = " + ex.Message);

            }
            finally
            {
                sr.Close();
                fs.Close();

            }
        }

        public void FileWrite()
        {
            FileStream fs1 = new FileStream("SubjectData.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(fs1);
                Console.WriteLine("Enter Subject Name :");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Subject Code :");
                string Class = Console.ReadLine();
                sw.WriteLine(name + "," + Class);
            }
            finally
            {
                sw.Close();
                fs1.Close();

            }

        }

        public void PrintData()
        {
            foreach (var item in SubjectList)
            {
                Console.WriteLine("Subject Name : " + item.SubjectName + " Subject Code :" + item.SubjectCode);
            }
            Console.WriteLine("-----------------------------");
        }

        public void SearchSubject()
        {
            Console.WriteLine("enter subject name: ");
            string name = Console.ReadLine();

            var Details = File.ReadLines("SubjectData.txt").OrderBy((line => (line.Split(',')[1]))).ToList();
            bool found = false;

            foreach (var item in Details)
            {
                if (item.Contains(name))
                {
                    Console.WriteLine($"Name: {item.Split('-')[0]} \n subject code  : {item.Split('-')[1]} ");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("subject not found. enter a valid name.");
            }

        }


    }
}
