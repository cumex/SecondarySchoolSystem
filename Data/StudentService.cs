using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolDatabase.Data
{
    public class StudentService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _dbContext.Student.ToListAsync();
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            return await _dbContext.Student.FirstOrDefaultAsync(student => student.StudentId == studentId);
        }

        public async Task<bool> RemoveStudentAsync(int studentId)
        {
            var student = await _dbContext.Student.FirstOrDefaultAsync(student => student.StudentId == studentId);
            _dbContext.Student.Remove(student);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            _dbContext.Student.Update(student);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            await _dbContext.Student.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}