
namespace Student_Management_System
{
    class Student(int id, string name, int age)
    {
        public int studentId = id;
        public string name = name;
        public int age = age;
        List<Course> courses = [];
        public bool Enroll(Course course)
        {
            foreach (var i in courses)
                if (i.courseId == course.courseId)
                    return false;

            courses.Add(course);
            return true;

        }
        public string PrintDetails()
        {
            String result = $"Id: {studentId}, Name: {name}, Age: {age} Courses";
            foreach (var i in courses)
            {
                result += i.Title;
            }
            return result;

        }
    }
    public class Instructor(int instructorId, string name, string specialization)
    {
        public int instructorId = instructorId;
        public string name = name;
        public string specialization = specialization;

        public string PrintDetails()
        {
            string result = $"Id: {instructorId}, Name: {name}, Specialization: {specialization}";
            return result;
        }
    }
    public class Course(int id, string title, Instructor instructor)
    {
        public int courseId = id;
        public string Title = title;
        Instructor instructor = instructor;
        public string PrintDetails()
        {
            string result = $"Id: {courseId}, Title: {title}, Instructor: {instructor.name}";
            return result;
        }

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
        public Student FindStudent(int studentId)
        {
            foreach (var i in students)
            {
                if (i.studentId == studentId)
                {
                    return i;
                }
            }
            return null;
        }
        public Course FindCourse(int courseId)
        {
            foreach (var i in courses)
            {
                if (i.courseId == courseId)
                {
                    return i;
                }
            }
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            foreach (var i in instructors)
            {
                if (i.instructorId == instructorId) return i;

            }
            return null;

        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (studentId == null)
            {
                return false;
            }
            return student.Enroll(course);

        }

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
                    case 4:
                        {
                            Console.Write("Enter Student Id: ");
                            int studentId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Course Id: ");
                            int courseId = Convert.ToInt32(Console.ReadLine());

                            if (manager.EnrollStudentInCourse(studentId, courseId))
                            {
                                Console.WriteLine("Student enrolled successfully");

                            }
                            else Console.WriteLine("Student not found");

                        }
                        break;
                    case 5:
                        {
                            foreach(var s in manager.students)
                            {
                                Console.WriteLine(s.PrintDetails());
                            }
                        }
                        break;
                    case 6:
                        {
                            foreach(var c in manager.courses)
                            {
                                Console.WriteLine(c.PrintDetails());
                            }
                        }
                        break;
                    case 7:
                        {
                            foreach(var i in manager.instructors)
                            {
                                Console.WriteLine(i.PrintDetails());
                            }
                        }
                        break;
                }
            }
            while (true);
        }
    }
}
