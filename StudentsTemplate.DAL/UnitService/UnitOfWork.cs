using StudentsTemplate.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTemplate.DAL.UnitService
{
    public class UnitOfWork : IDisposable
    {
        private UniversityContext _contextUniver = new UniversityContext();
        // implementation of the pattern
        // apply repository
        private StudentRepository studentRepository;
        public StudentRepository Students
        {
            get
            {
                if (studentRepository == null)
                { studentRepository = new StudentRepository(_contextUniver); }
                return studentRepository;
            }
        }

        public void Save() { _contextUniver.SaveChanges(); }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contextUniver.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
