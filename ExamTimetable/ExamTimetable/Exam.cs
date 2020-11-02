using System;
using System.Collections.Generic;

namespace ExamTimetableModel
{
    public partial class Exam
    {
        public Exam()
        {
            SubjectModules = new HashSet<SubjectModules>();
        }

        public int ExamId { get; set; }
        public string ExamRoom { get; set; }
        public DateTime? ExamDate { get; set; }

        public virtual SubjectModules ExamNavigation { get; set; }
        public virtual ICollection<SubjectModules> SubjectModules { get; set; }
    }
}
