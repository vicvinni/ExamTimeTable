using System;
using System.Collections.Generic;

namespace ExamTimetableModel
{
    public partial class Student
    {
        public Student()
        {
            SubjectModules = new HashSet<SubjectModules>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? SchoolYear { get; set; }
        public int? Class { get; set; }
        public string City { get; set; }

        public virtual ICollection<SubjectModules> SubjectModules { get; set; }
    }
}
