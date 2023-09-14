using LoonsTimetable.Model;

namespace LoonsTimetable.Services
{

    public interface IExamScheduleService 
    {
        List<ExamSchedule> GenerateExamSchedule(DateTime examDate, List<Exam> exams);
    }

    public class ExamScheduleService : IExamScheduleService
    {
        public List<ExamSchedule> GenerateExamSchedule(DateTime examStartDate,List<Exam> exams)
        {
            int currentHall = 1;
            int iteration = 1;
            TimeSpan startTime = TimeSpan.FromHours(8);
            TimeSpan timeGap = TimeSpan.FromHours(1);

            var examSchedules = new List<ExamSchedule>();

            foreach (var exam in exams)
            {
             
                DateTime examDate = examStartDate;

                int hallNumber = currentHall;
                

                TimeSpan endTime = startTime.Add(TimeSpan.FromMinutes(exam.Duration));

                if(endTime > TimeSpan.FromHours(17)) 
                {
                    examDate = examDate.AddDays(1);
                    startTime = TimeSpan.FromHours(8);
                    endTime = startTime.Add(TimeSpan.FromMinutes(exam.Duration));

                }

                var examShedule = new ExamSchedule
                {
                    ExamId = exam.Id,
                    HallNo = hallNumber,
                    Date = examDate,
                    StartTime = startTime,
                    EndTime = endTime,
                };
                examSchedules.Add(examShedule);



                currentHall++;
                iteration++;
                //startTime = endTime.Add(timeGap);

                if (iteration > 5)
                {

                    if (currentHall > 5)
                    {
                    
                        currentHall = 1;
                       // startTime = examSchedules[iteration%6].EndTime.Add(timeGap);
                    
                    }
                    else
                    {
                        startTime = TimeSpan.FromHours(8); 

                    }
                    startTime = examSchedules[iteration % 6].EndTime.Add(timeGap);
                }

                
                

            }
            return examSchedules;
        }
    }
}
