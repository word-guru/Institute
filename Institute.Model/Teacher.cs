using System;
using System.Collections.Generic;

#nullable disable

namespace Institute.Model
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Person Person { get; set; }
    }
}
