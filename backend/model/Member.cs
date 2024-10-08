using Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Model
{
    internal class Member : User
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private MemberData _data;

        public List<Coach> Coaches 
        { 
            get { return _data.Coaches.Select(c => new Coach(c)).ToList(); }
        }

        public List<Payment> Payments 
        { 
            get { return _data.Payments.Select(p => new Payment(p)).ToList(); }
        }

        public Schedule Schedule
        {
            get { return new Schedule(_data.Schedule); }
            set 
            {
                value.Insert(this);
                _data.Schedule = (_input as ScheduleData)!;
                _input = null;
            }
        }

        public List<CheckInDay> CheckInDays 
        { 
            get { return _data.CheckInDays.Select(c => new CheckInDay(c)).ToList(); }
        }

        public List<ProgressCheck> ProgressChecks 
        { 
            get { return _data.ProgressChecks.Select(p => new ProgressCheck(p)).ToList(); }
        }

        public Split Split 
        { 
            get { return new Split(_data.Split); }
            set
            {
                value.Insert(this);
                _data.Split = (_input as SplitData)!;
                _input = null;
            }
        }

        public Member(MemberData data) : base(data)
        {
            _data = data;
        }

        public Member(string name, DateTime birthDate, string login, string password) : 
        base(name, birthDate, login, password)
        {
            var schedule = new Schedule(0, new List<TimeSlot>());
            schedule.Insert(this);
            var scheduleData = (_input as ScheduleData)!;
            var split = new Split("", new List<WorkoutDay>(), false);
            split.Insert(this);
            var splitData = (_input as SplitData)!;
            _input = null;

            _data = new MemberData()
            {
                Name = name,
                BirthDate = birthDate,
                Login = login,
                Password = password,
                Coaches = new List<CoachData>(),
                Payments = new List<PaymentData>(),
                Schedule = scheduleData,
                CheckInDays = new List<CheckInDayData>(),
                ProgressChecks = new List<ProgressCheckData>(),
                Split = splitData,
            };
        }

        public void AddCoach(Coach coach)
        {
            coach.Insert(this);
            _data.Coaches.Add((_input as CoachData)!);
            _input = null;
        }

        public void Insert(CheckInDay day)
        {
            day.Input = _data;
        }

        public void Insert(ProgressCheck day)
        {
            day.Input = _data;
        }

        public void Insert(Payment payment)
        {
            payment.Input = _data;
        }
    }
}