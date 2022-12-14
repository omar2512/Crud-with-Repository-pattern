namespace itilabcrud.Models
{
    public interface IStudent
    {
        
        public IEnumerable<Student> GetAllData();
        public Student GetById(int id);
        public void Insert(Student Std);
        public void Edit(Student std);
        public void Delete(int id);
        public int GetNextID();

    }
}
