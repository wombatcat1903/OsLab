using System;
using System.Security.Authentication;
using Newtonsoft.Json;

namespace ex3
{
	class Program
	{
		public struct Student
		{
			public Student(String name, String lname, int height, int age, DateOnly dob)
			{

				Name = name;
				LastName = lname;
				Height = height;
				Age = age;
				DateOfBirth = dob;

			}
			public String Name { get; init; }
			public String LastName { get; init; }
			public int Height { get; init; }
			public int Age { get; init; } = 0;
			public DateOnly DateOfBirth { get; init; } = DateOnly.MinValue;
		}

		public static void Main(string[] args)
		{
            Console.WriteLine("what would you like to do?please select 1 or 2\n1.give infor and make a json\n2.give a file and get the info");
            int choice = Int32.Parse(Console.ReadLine());
			switch (choice)
			{
				case 1:
                    List<Student> students = new List<Student>();
                    for (int i = 0; i < 2; i++)
                    {
                        //Student student = new Student();
                        Console.WriteLine("student information?\n(name,lastname,height,age,date of birth[month day year])\n please use , to seperate each one.");
                        String input = Console.ReadLine();
                        try
                        {
                            String[] vals = input.Split(',');
                            String name = vals[0];
                            String lname = vals[1];
                            int height = Int32.Parse(vals[2]);
                            int age = Int32.Parse(vals[3]);
                            DateTime d= DateTime.Parse(vals[4]);
                            DateOnly dob = DateOnly.FromDateTime(d);
                            Student student = new Student(name, lname, height, age, dob);
                            students.Add(student);
                            Console.WriteLine("student " + i + 1 + " was added successfully.");
                        }
                        catch (Exception e)
                        {
                            Console.Write(e.ToString());
                        }

                    }
                    string json = JsonConvert.SerializeObject(students);
                    File.WriteAllText(@"C:\Users\A\Downloads\Foo.json", json);
                    break;
                case 2:
                    Console.WriteLine("please enter the path of the file:");
                    String path= Console.ReadLine();
                    string result = System.IO.File.ReadAllText(path);
                    List<Student> students2 = JsonConvert.DeserializeObject<List<Student>>(result);
                    for (int i = 0; i < students2.Count; i++)
                    {
                        Console.WriteLine("Student "+ i+1 +":\nname: "+students2[i].Name + "\nlastname: " +students2[i].LastName +
                            "\nage: "+ students2[i].Age+ "\nheight: " + students2[i].Height+ "\ndate of birth: "+ students2[i].DateOfBirth);
                    }

                    break;

            }

            

		}
	}
}