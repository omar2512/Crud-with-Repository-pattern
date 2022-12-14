using System.Security.Cryptography.X509Certificates;

namespace itilabcrud.Models
{
    public class StdActions:IStudent
    {
        //public static List<Student> students { get; set; } = new List<Student>()
        public  List<Student> students { get; set; } = new List<Student>()
        {
            new Student(){Id=1,Name="omar",Age=26,Stgimg="1.jpg"} ,
            new Student(){Id=2,Name="salah",Age=28,Stgimg="2.jpg"},
        };  
        
        public IEnumerable<Student> GetAllData()
        {
            return students;    
        }
        public Student GetById(int id)
        {
            return students.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Student Std)
        {
            students.Add(Std);  
        }
        public void Edit(Student std)
        {
           Student studnts = students.FirstOrDefault(d => d.Id == std.Id);
            studnts.Name = std.Name;
            studnts.Age = std.Age;
        }
        public void Delete(int id)
        {

            students.Remove(GetById(id));
        }
        public int GetNextID()
        {
            return students.Max(x=>x.Id)+1;
        }
    }
}
