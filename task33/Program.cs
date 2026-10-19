

namespace Task3
{
    class Student
    {
        public int StudentId;
        public string Name;
        public int Age;
        public List<Course> Courses;

        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Courses = new List<Course>();
        }

        public bool Enroll(Course course)
        {
            if (course == null)
            {
                return false;
            }

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }

            Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            string text = "Student ID: " + StudentId + ", Name: " + Name + ", Age: " + Age + ", Courses: ";

            for (int i = 0; i < Courses.Count; i++)
            {
                text = text + Courses[i].Title + " ";
            }

            return text;
        }
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

        public string PrintDetails()
        {
            return "Instructor ID: " + InstructorId + ", Name: " + Name + ", Specialization: " + Specialization;
        }
    }

    class Course
    {
        public int CourseId;
        public string Title;
        public Instructor Instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }

        public string PrintDetails()
        {
            return "Course ID: " + CourseId + ", Title: " + Title + ", Instructor: " + Instructor.Name;
        }
    }

    class StudentManager
    {
        public List<Student> Students = new List<Student>();
        public List<Course> Courses = new List<Course>();
        public List<Instructor> Instructors = new List<Instructor>();

        public bool AddStudent(Student student)
        {
            if (student == null)
            {
                return false;
            }
            else if (FindStudent(student.StudentId) != null)
            {
                return false;
            }
            Students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            if (course == null)
            {
                return false;
            }
            if (FindCourse(course.CourseId) != null)
            {
                return false;
            }
            Courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null)
            {
                return false;
            }
            if (FindInstructor(instructor.InstructorId) != null)
            {
                return false;
            }
            Instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }
            return null;
        }

        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }
            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
            {
                return false;
            }

            return student.Enroll(course);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            int choice=0;

            while (choice != 10)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the student by id or name");
                Console.WriteLine("9. Find the course by id or name");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter student id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter student age: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Student student = new Student(id, name, age);
                    bool added = manager.AddStudent(student);
                    if (added == true)
                    {
                        Console.WriteLine("Student added.");
                    }
                    else
                    {
                        Console.WriteLine("This id already exists.");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter instructor id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter instructor name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter specialization: ");
                    string specialization = Console.ReadLine();

                    Instructor instructor = new Instructor(id, name, specialization);
                    bool added = manager.AddInstructor(instructor);
                    if (added == true)
                    {
                        Console.WriteLine("Instructor added.");
                    }
                    else
                    {
                        Console.WriteLine("This id already exists.");
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter course id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter course title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter instructor id: ");
                    int instructorId = Convert.ToInt32(Console.ReadLine());

                    Instructor instructor = manager.FindInstructor(instructorId);
                    if (instructor == null)
                    {
                        Console.WriteLine("Instructor not found.");
                    }
                    else
                    {
                        Course course = new Course(id, title, instructor);
                        bool added = manager.AddCourse(course);
                        if (added == true)
                        {
                            Console.WriteLine("Course added.");
                        }
                        else
                        {
                            Console.WriteLine("This id already exists.");
                        }
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter student id: ");
                    int studentId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter course id: ");
                    int courseId = Convert.ToInt32(Console.ReadLine());

                    bool done = manager.EnrollStudentInCourse(studentId, courseId);
                    if (done == true)
                    {
                        Console.WriteLine("Student enrolled.");
                    }
                    else
                    {
                        Console.WriteLine("Could not enroll the student.");
                    }
                }
                else if (choice == 5)
                {
                    for (int i = 0; i < manager.Students.Count; i++)
                    {
                        Console.WriteLine(manager.Students[i].PrintDetails());
                    }
                }
                else if (choice == 6)
                {
                    for (int i = 0; i < manager.Courses.Count; i++)
                    {
                        Console.WriteLine(manager.Courses[i].PrintDetails());
                    }
                }
                else if (choice == 7)
                {
                    for (int i = 0; i < manager.Instructors.Count; i++)
                    {
                        Console.WriteLine(manager.Instructors[i].PrintDetails());
                    }
                }
                else if (choice == 8)
                {
                    Console.Write("Enter student id or name: ");
                    string input = Console.ReadLine();
                    bool found = false;

                    for (int i = 0; i < manager.Students.Count; i++)
                    {
                        if (manager.Students[i].StudentId.ToString() == input || manager.Students[i].Name == input)
                        {
                            Console.WriteLine(manager.Students[i].PrintDetails());
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                else if (choice == 9)
                {
                    Console.Write("Enter course id or title: ");
                    string input = Console.ReadLine();
                    bool found = false;

                    for (int i = 0; i < manager.Courses.Count; i++)
                    {
                        if (manager.Courses[i].CourseId.ToString() == input || manager.Courses[i].Title == input)
                        {
                            Console.WriteLine(manager.Courses[i].PrintDetails());
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        Console.WriteLine("Course not found.");
                    }
                }
                else if (choice == 10)
                {
                    Console.WriteLine("Bye!");
                }
                else
                {
                    Console.WriteLine("Wrong choice.");
                }
            }
        }
    }
}