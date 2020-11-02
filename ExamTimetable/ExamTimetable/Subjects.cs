using System;
using System.Collections.Generic;

namespace ExamTimetableModel
{
    public partial class Subjects
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public virtual SubjectModules Subject { get; set; }
    }
}
