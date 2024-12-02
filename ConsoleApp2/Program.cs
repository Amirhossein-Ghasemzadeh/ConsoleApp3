
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
    private List<Student> students;

    public StudentManager()
    {
        students = new List<Student>();
    }

    // Add a student to the list
    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    // Save students to a JSON file
    public void SaveToFile(string fileName)
    {
        string jsonData = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, jsonData);
        Console.WriteLine($"Students data saved to {fileName}");
    }
}


class Program
{
    static void Main()
    {
        StudentManager studentManager = new StudentManager();

        // Add students
        studentManager.AddStudent(new Student(id : 1, name : "Alice", age : 20));

        // Save to file
        studentManager.SaveToFile("students.json");
    }
}