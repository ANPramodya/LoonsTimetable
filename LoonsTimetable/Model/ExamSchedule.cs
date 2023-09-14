namespace LoonsTimetable.Model
{
    public class ExamSchedule
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int HallNo { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
