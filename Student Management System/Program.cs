
using System.Transactions;

namespace Student_Management_System
{
    class Student(int id, string name, int age, List<Course> courses )
    {
        int studentId = id;
        string name = name;
        int age = age;
        List<Course> courses=courses;
        public bool Enroll(Course course)
        {
            foreach (var i in courses)
                if (i.CourseId == course.CourseId)
                    return false;

            courses.Add(course);
            return true;

        }
        string PrintDetails();
    }
    class Instructor
    {
        public int InstructorId;
        public string Name;
        public string Specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        string PrintDetails();
    }
    public class Course(int id, string title, Instructor instructor)
    {
        public int CourseId = id;
        public string Title = title;
        public Instructor Instructor = instructor;
        string PrintDetails();

    }

    class StudentManager
    {
        public List<Student> students;
        public List<Course> courses;
        public List<Instructor> instructors;

        public bool AddStudent(Student student)
        {
            students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            instructors.Add(instructor);
            return true;
        }
        Student FindStudent(int studentId);
        Course FindCourse(int courseId);
        public Instructor FindInstructor(int instructorId)
        {
            foreach (var i in instructors)
            {
                if (i.InstructorId == instructorId) return i;

            }
            return null;

        }
        bool EnrollStudentInCourse(int studentId, int courseId);

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            do
            {
                Console.WriteLine("========Welcome========");
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Add Instructor");
                Console.WriteLine("3.Add Course");
                Console.WriteLine("4.Enroll Student in Course");
                Console.WriteLine("5.Show All Students");
                Console.WriteLine("6.Show All Coursess");
                Console.WriteLine("7.Show All Instructors");
                Console.WriteLine("8.Find the student by id or name");
                Console.WriteLine("9.Fine the course by id or name");
                Console.WriteLine("10. Exit");
                Console.WriteLine("Please Enter Your Selection!");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Your ID");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Your Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Your age");
                            int age = Convert.ToInt32(Console.ReadLine());
                            manager.AddStudent(new Student(id, name, age));
                            Console.WriteLine("Student added successfully");

                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter Your ID");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Your Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Your Specialization");
                            string Specialization = Console.ReadLine();
                            manager.AddInstructor(new Instructor(id, name, Specialization));
                            Console.WriteLine("Instructor added successfully");

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter Course ID");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Course Title");
                            string title = Console.ReadLine();

                            Console.WriteLine("Enter Instructor Id");
                            int instructorId = Convert.ToInt32(Console.ReadLine());
                            Instructor instructor = manager.FindInstructor(instructorId);

                            if (instructor == null)
                            {
                                Console.WriteLine("Instructor not found");
                                break;
                            }

                            manager.AddCourse(new Course(id, title, instructor));
                            Console.WriteLine("Course added successfully");
                        }
                        break;
                    case 4: {

                        } break; 
                }
            }
            while (true);
        }
    }
}
