
using System.Text.Json;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
}


public class StudentManager
{
    
    public List<Student> students;

    public StudentManager()
    {
        students = new List<Student>();
    }

    // Add a student to the list
    public void AddStudent(Student student)
    {
        students.Add(student);
    }

     // Filter students by id
     public IEnumerable<Student> FilterStudentsById(int id)
    {
        return students.Where(s => s.Id.Equals(id));
    }



    // Save students to a JSON file
    public void SaveToFile(List<Student> students, string fileName)
    {
        string filePath = $@"\\DESKTOP-328MO15\Users\Win10\Desktop\{fileName}";
        string jsonData = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });

        try
        {
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Students data saved to {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }
}


class Program
{
    static void Main()
    {
        StudentManager studentManager = new StudentManager();

        // Add students
        studentManager.AddStudent(new Student(id : 0, name : "mamad", age : 0));
        studentManager.AddStudent(new Student(id : 1, name : "asgar", age : 1));
        studentManager.AddStudent(new Student(id : 2, name : "jafar", age : 2));

        // Filter Student
       Console.WriteLine("Do u want find a specefic user?(YES/No)");
       var findByIdInput = Convert.ToString(Console.ReadLine());
       

        if (findByIdInput.Equals("yes", StringComparison.OrdinalIgnoreCase))

        {
            Console.WriteLine("INSERT student Id:");
            var selectedId = Convert.ToInt32( Console.ReadLine());
            var filteredStudents = studentManager.FilterStudentsById(selectedId).ToList();
            Console.WriteLine(filteredStudents.Count());
            if (filteredStudents.Count()>0)
            {
                studentManager.SaveToFile(filteredStudents, "students.json");
            } else
            {
                Console.WriteLine("No students found with the selected Id.");
            }
        } else
        {
        // Save to file
        studentManager.SaveToFile(studentManager.students, "students.json");

        }
    }
}