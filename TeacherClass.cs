using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSystem
{
    public class TeacherClass : InterOp
    {
		private string teachername;

		public string TeacherName
		{
			get { return teachername; }
			set { teachername = value; }
		}

		private int teacherclass;

		public int Class
		{
			get { return teacherclass; }
			set { teacherclass = value; }
		}

		private string tsubject;

		public string Subject
		{
			get { return tsubject; }
			set { tsubject = value; }
		}

		public static List<TeacherClass> TeacherList = new List<TeacherClass>();

		public void FileWrite()
		{
			FileStream fs = new FileStream("TeacherData.txt", FileMode.Append, FileAccess.Write);
			StreamWriter sw = null;

			try
			{
				sw = new StreamWriter(fs);
				Console.WriteLine("enter teacher name: ");
				string name = Console.ReadLine();

				Console.WriteLine("enter class: ");
				string Class = Console.ReadLine();

				Console.WriteLine("enter subject: ");
				string SubjectName = Console.ReadLine();

				sw.WriteLine(name + "," + Class + "," + SubjectName);
			}
			finally
			{
				sw.Close();
				fs.Close();
			}
		}

		public void FileRead()
		{
			FileStream fs1 = new FileStream("TeacherData.txt", FileMode.Open, FileAccess.Read);
			StreamReader sr = null;

			try
			{
				sr = new StreamReader(fs1);
				bool LastLine = false;

				while (!LastLine)
				{
					TeacherClass t = new TeacherClass();
					String temp = sr.ReadLine();

					if (temp == null)
					{
						Console.WriteLine("last data reached");
						break;
					}

					var tempfile = temp.Split('-');
					t.TeacherName = tempfile[0];
					t.Class = Convert.ToInt32(tempfile[1]);
					t.Subject = tempfile[2];

					TeacherClass.TeacherList.Add(t);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("error message from teacher: " + ex.Message);
			}
			finally
			{
				sr.Close();
				fs1.Close();
			}
		}

		public void PrintData()
		{
			foreach (var item in TeacherList)
			{
				Console.WriteLine("teacher name: " + item.TeacherName);
				Console.WriteLine("teacher subject: " + item.Subject);
			}
			Console.WriteLine("------------------------");
		}

		public void SearchTeacher()
		{
			Console.WriteLine("enter teacher's name: ");
			string name = Console.ReadLine();

            var Details = File.ReadLines("TeacherData.txt").OrderBy((line => (line.Split(',')[1]))).ToList();
			bool found = false;

            foreach (var item in Details)
            {
                if (item.Contains(name))
                {
                    Console.WriteLine($"Name: {item.Split('-')[0]} \n Class Room  : {item.Split('-')[1]} \n Subject : {item.Split('-')[2]} ");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("teacher not found. enter a valid name.");
            }

        }



    }
}
