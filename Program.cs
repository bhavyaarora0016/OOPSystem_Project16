using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region CreateFile

            File.Create("StudentData.txt");
            File.Create("TeacherData.txt");
            File.Create("SubjectData.txt");

            #endregion

            StudentClass s = new StudentClass();
            s.FileWrite();
            s.FileRead();
            s.PrintData();

            TeacherClass t = new TeacherClass();
            t.FileWrite();
            t.FileRead();
            t.PrintData();

            SubjectClass sub = new SubjectClass();
            sub.FileWrite();
            sub.FileRead();
            sub.PrintData();

            bool con;

            do
            {
                Console.WriteLine("1. Add  2. Print  3. Search");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1. Student  2. Teacher  3. Subject");
                        int ch1 = Convert.ToInt32(Console.ReadLine());

                        switch (ch1)
                        {
                            case 1:
                                StudentClass s1 = new StudentClass();
                                s1.FileWrite();
                                break;
                            case 2:
                                TeacherClass t1 = new TeacherClass();
                                t1.FileWrite();
                                break;
                            case 3:
                                SubjectClass sub1 = new SubjectClass();
                                sub1.FileWrite();
                                break;
                            default:
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("1. Student  2. Teacher  3. Subject");
                        int ch2 = Convert.ToInt32(Console.ReadLine());

                        switch (ch2)
                        {
                            case 1:
                                StudentClass s2 = new StudentClass();
                                s2.FileWrite();
                                break;
                            case 2:
                                TeacherClass t2 = new TeacherClass();
                                t2.FileWrite();
                                break;
                            case 3:
                                SubjectClass sub2 = new SubjectClass();
                                sub2.FileWrite();
                                break;
                            default:
                                break;
                        }
                        break;

                    case 3:
                        Console.WriteLine("1. Student  2. Teacher  3. Subject");
                        int ch3 = Convert.ToInt32(Console.ReadLine());

                        switch (ch3)
                        {
                            case 1:
                                StudentClass s3 = new StudentClass();
                                s3.FileWrite();
                                break;
                            case 2:
                                TeacherClass t3 = new TeacherClass();
                                t3.FileWrite();
                                break;
                            case 3:
                                SubjectClass sub3 = new SubjectClass();
                                sub3.FileWrite();
                                break;
                            default:
                                break;
                        }
                        break;

                        default :
                        break;
                }
                Console.WriteLine("continue? (y/n)");
                string ans = Console.ReadLine();

                if (ans == "y" || ans == "Y")
                {
                    con = true;
                }
                else
                {
                    con = false;
                }


            } while (con);
        }
    }
}
