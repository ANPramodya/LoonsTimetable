using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoonsTimetable.Model;

namespace LoonsTimetable.Data
{
    public class LoonsTimetableContext : DbContext
    {
        public LoonsTimetableContext (DbContextOptions<LoonsTimetableContext> options)
            : base(options)
        {
        }

        public DbSet<LoonsTimetable.Model.Exam> Exam { get; set; } = default!;

        public DbSet<LoonsTimetable.Model.ExamSchedule>? ExamSchedule { get; set; }
    }
}
