using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        public DbSet<Club> Clubs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseAssignment>().HasKey(c => new { c.CourseID, c.InstructorID });
            modelBuilder.Entity<CourseAssignment>().HasOne(x => x.Course).WithMany(x => x.CourseAssignments).HasForeignKey(p => p.CourseID);
            modelBuilder.Entity<CourseAssignment>().HasOne(x => x.Instructor).WithMany(x => x.CourseAssignments).HasForeignKey(o => o.InstructorID);

            modelBuilder.Entity<Enrollment>().HasKey(c => new { c.CourseID, c.StudentID });
            modelBuilder.Entity<Enrollment>().HasOne(x => x.Course).WithMany(x => x.Enrollments).HasForeignKey(p => p.CourseID);
            modelBuilder.Entity<Enrollment>().HasOne(x => x.Student).WithMany(x => x.Enrollments).HasForeignKey(o => o.StudentID);

            #region Clubs

            var cityzen = new Club
            {
                Serial = "C",
                Entitle = "Cityzen"
            };

            var germanium = new Club
            {
                Serial = "G",
                Entitle = "Germanium"
            };

            var devilArt = new Club
            {
                Serial = "D",
                Entitle = "Devil Art"
            };

            var huskar = new Club
            {
                Serial = "H",
                Entitle = "Huskar"
            };

            var myolia = new Club
            {
                Serial = "M",
                Entitle = "Mylioanic"
            };

            #endregion

            #region Students

            var traxex = new Student
            {
                ID = 1,
                Name = "Traxex Diablo",
                EnrollmentDate = DateTime.Parse("2020-05-10"),
                ClubID = "C"
            };

            var johan = new Student
            {
                ID = 2,
                Name = "Johan Sundestein",
                EnrollmentDate = DateTime.Parse("2021-09-01"),
                ClubID = "M"
            };

            var anathan = new Student
            {
                ID = 3,
                Name = "Anathan Stone",
                EnrollmentDate = DateTime.Parse("2020-10-25"),
                ClubID = "D"
            };

            var tommy = new Student
            {
                ID = 4,
                Name = "Tommy Vercitty",
                EnrollmentDate = DateTime.Parse("2021-12-15"),
                ClubID = "H"
            };

            var anthony = new Student
            {
                ID = 5,
                Name = "Anthony Martial",
                EnrollmentDate = DateTime.Parse("2022-09-12"),
                ClubID = "D"
            };

            var marcus = new Student
            {
                ID = 6,
                Name = "Marcus Rashford",
                EnrollmentDate = DateTime.Parse("2020-05-10"),
                ClubID = "H"
            };

            var diaz = new Student
            {
                ID = 7,
                Name = "Diaz Antony",
                EnrollmentDate = DateTime.Parse("2022-06-05"),
                ClubID = "G"
            };

            var prophet = new Student
            {
                ID = 8,
                Name = "Prophet Heir",
                EnrollmentDate = DateTime.Parse("2021-03-03"),
                ClubID = "M"
            };

            #endregion

            #region Instructors

            var joe = new Instructor
            {
                ID = 1,
                Name = "Joe Root"
            };

            var eoin = new Instructor
            {
                ID = 2,
                Name = "Eoin Morgan"
            };

            var jos = new Instructor
            {
                ID = 3,
                Name = "Jos Buttler"
            };

            var jonny = new Instructor
            {
                ID = 4,
                Name = "Jonny Bairstow"
            };

            var ben = new Instructor
            {
                ID = 5,
                Name = "Ben Stokes"
            };

            #endregion

            #region Faculties

            var computing = new Faculty
            {
                ID = 1,
                Name = "Computing",
                SupervisorID = 4
            };

            var multimedia = new Faculty
            {
                ID = 2,
                Name = "Multimedia",
                SupervisorID = 2
            };

            var networking = new Faculty
            {
                ID = 3,
                Name = "Networking",
            };

            #endregion

            #region Courses

            var programming = new Course
            {
                ID = 1,
                Title = "Programming",
                Credits = 15,
                FacultyID = 1
            };

            var emerging = new Course
            {
                ID = 2,
                Title = "Emerging Platforms and Technologies",
                Credits = 20,
                FacultyID = 1
            };

            var database = new Course
            {
                ID = 3,
                Title = "Advanced Databases",
                Credits = 25,
                FacultyID = 1
            };

            var ai = new Course
            {
                ID = 4,
                Title = "Introduction to Artificial Intelligence",
                Credits = 30,
                FacultyID = 1
            };

            var application = new Course
            {
                ID = 5,
                Title = "Application Development",
                Credits = 15,
                FacultyID = 1
            };

            var security = new Course
            {
                ID = 6,
                Title = "Networking and Advanced Security",
                Credits = 30,
                FacultyID = 2
            };

            var linux = new Course
            {
                ID = 7,
                Title = "Linux: Commands and Tools",
                Credits = 45,
                FacultyID = 2
            };

            var uiux = new Course
            {
                ID = 8,
                Title = "Introduction to UI/UX",
                Credits = 45,
                FacultyID = 3
            };

            #endregion

            #region Course Assignments

            var courseAssignments = new List<CourseAssignment>()
            {
                new CourseAssignment
                {
                    InstructorID = 1,
                    CourseID = 1,
                },
                new CourseAssignment
                {
                    InstructorID = 1,
                    CourseID = 2,
                },
                new CourseAssignment
                {
                    InstructorID = 1,
                    CourseID = 3,
                },
                new CourseAssignment
                {
                    InstructorID = 1,
                    CourseID = 4,
                },
                new CourseAssignment
                {
                    InstructorID = 1,
                    CourseID = 8,
                },
                new CourseAssignment
                {
                    InstructorID = 2,
                    CourseID = 1,
                },
                new CourseAssignment
                {
                    InstructorID = 2,
                    CourseID = 5,
                },
                new CourseAssignment
                {
                    InstructorID = 2,
                    CourseID = 6,
                },
                new CourseAssignment
                {
                    InstructorID = 3,
                    CourseID = 1,
                },
                new CourseAssignment
                {
                    InstructorID = 3,
                    CourseID = 6,
                },
                new CourseAssignment
                {
                    InstructorID = 3,
                    CourseID = 2,
                },
                new CourseAssignment
                {
                    InstructorID = 3,
                    CourseID = 8,
                },
                new CourseAssignment
                {
                    InstructorID = 3,
                    CourseID = 7,
                },
                new CourseAssignment
                {
                    InstructorID = 4,
                    CourseID = 1,
                },
                new CourseAssignment
                {
                    InstructorID = 5,
                    CourseID = 3,
                },
                new CourseAssignment
                {
                    InstructorID = 5,
                    CourseID = 4,
                }
            };

            #endregion

            #region Enrollments

            var enrollments = new List<Enrollment>()
            {
                new Enrollment
                {
                    ID = 1001,
                    StudentID = 1,
                    CourseID = 1,
                    Marks = 90
                },
                new Enrollment
                {
                    ID = 1002,
                    StudentID = 1,
                    CourseID = 2,
                    Marks = 56
                },
                new Enrollment
                {
                    ID = 1003,
                    StudentID = 2,
                    CourseID = 2,
                    Marks = 78
                },
                new Enrollment
                {
                    ID = 1004,
                    StudentID = 2,
                    CourseID = 3,
                    Marks = 45
                },
                new Enrollment
                {
                    ID = 1005,
                    StudentID = 2,
                    CourseID = 1,
                    Marks = 32
                },
                new Enrollment
                {
                    ID = 1006,
                    StudentID = 3,
                    CourseID = 2,
                    Marks = 88
                },
                new Enrollment
                {
                    ID = 1007,
                    StudentID = 3,
                    CourseID = 4,
                },
                new Enrollment
                {
                    ID = 1008,
                    StudentID = 4,
                    CourseID = 1,
                },
                new Enrollment
                {
                    ID = 1009,
                    StudentID = 4,
                    CourseID = 2,
                    Marks = 70
                },
                new Enrollment
                {
                    ID = 1010,
                    StudentID = 4,
                    CourseID = 5,
                    Marks = 75
                },
                new Enrollment
                {
                    ID = 1011,
                    StudentID = 4,
                    CourseID = 8,
                    Marks = 90
                },
                new Enrollment
                {
                    ID = 1012,
                    StudentID = 5,
                    CourseID = 6,
                    Marks = 67
                },
                new Enrollment
                {
                    ID = 1013,
                    StudentID = 5,
                    CourseID = 8,
                },
                new Enrollment
                {
                    ID = 1014,
                    StudentID = 6,
                    CourseID = 1,
                },
                new Enrollment
                {
                    ID = 1015,
                    StudentID = 7,
                    CourseID = 1,
                    Marks = 54
                },
                new Enrollment
                {
                    ID = 1016,
                    StudentID = 7,
                    CourseID = 6,
                    Marks = 55
                },
                new Enrollment
                {
                    ID = 1017,
                    StudentID = 8,
                    CourseID = 7,
                },
                new Enrollment
                {
                    ID = 1018,
                    StudentID = 8,
                    CourseID = 2,
                    Marks = 78
                },
            };

            #endregion

            modelBuilder.Entity<Club>().HasData(new Club[]
            {
                cityzen, germanium, devilArt, huskar, myolia
            });

            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                traxex, johan, anathan, tommy, anthony, marcus, diaz, prophet
            });

            modelBuilder.Entity<Instructor>().HasData(new Instructor[]
            {
                joe, eoin, jos, jonny, ben
            });

            modelBuilder.Entity<Faculty>().HasData(new Faculty[]
            {
                computing, multimedia, networking
            });

            modelBuilder.Entity<Course>().HasData(new Course[]
            {
                programming, emerging, database, ai, application, security, linux, uiux
            });

            modelBuilder.Entity<Enrollment>().HasData(enrollments);

            modelBuilder.Entity<CourseAssignment>().HasData(courseAssignments);

        }
    }
}
