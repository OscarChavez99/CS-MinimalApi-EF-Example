
using CS_MinimalApi_EF_Example.Application.Data;
using CS_MinimalApi_EF_Example.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CS_MinimalApi_EF_Example.Application
{
    public class StudentsHandler
    {
        private readonly DataContext dataContext;

        public StudentsHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IResult> GetStudents()
        {
            List<Student> students = await dataContext.Students.ToListAsync();
            
            return Results.Ok(students);
        }

        public async Task<IResult> InsertStudent(Student student)
        {
            await dataContext.Students.AddAsync(student);
            await dataContext.SaveChangesAsync();

            return Results.Ok(student);
        }

        public async Task<IResult> UpdateStudent(Student student)
        {
            dataContext.Students.Update(student);
            await dataContext.SaveChangesAsync();

            return Results.Ok(student);
        }

        public async Task<IResult> DeleteStudent(int id)
        {
            Student? student = await dataContext.Students.FindAsync(id);

            if (student == null)
                return Results.NotFound();

            dataContext.Students.Remove(student);
            await dataContext.SaveChangesAsync();

            return Results.Ok(student);
        }
    }
}
