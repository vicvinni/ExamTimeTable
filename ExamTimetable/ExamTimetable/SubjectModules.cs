using System;
using System.Collections.Generic;

namespace ExamTimetableModel
{
    public partial class SubjectModules
    {
        public int ModuleId { get; set; }
        public int? SubjectName { get; set; }
        public string ModeuleName { get; set; }
        public int? ExamId { get; set; }
        public int? StudentId { get; set; }

        public virtual Exam ExamNavigation { get; set; }
        public virtual Student Student { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
