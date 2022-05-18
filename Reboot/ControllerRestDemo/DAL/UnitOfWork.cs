namespace ControllerRestDemo.DAL
{
    public class UnitOfWork : IDisposable
    {
        private StudentContext _studentContext;


        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository is null)
                {
                    _studentRepository = new StudentRepository(_studentContext);
                }

                return _studentRepository;
            }
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                if (_courseRepository is null)
                {
                    _courseRepository = new CourseRepository(_studentContext);
                }

                return _courseRepository;
            }
        }

        public UnitOfWork(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }



        public void Save()
        {
            _studentContext.SaveChanges();

        }

        public void Dispose()
        {
            _studentContext.Dispose();
            _studentRepository.Dispose();
            _courseRepository.Dispose();
        }
    }
}
