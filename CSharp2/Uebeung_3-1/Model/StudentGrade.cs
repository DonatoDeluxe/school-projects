//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uebeung_3_1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentGrade
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Nullable<decimal> Grade { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
