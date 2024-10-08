using Data;

namespace Model
{
    internal class Coach : User
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private CoachData _data;

        public List<Member> Members
        {
            get { return _data.Members.Select(m => new Member(m)).ToList(); }
        }

        public Schedule Schedule
        {
            get { return new Schedule(_data.Schedule); }
            set
            {

            }
        }

        public List<ProgressCheck> ProgressChecks
        {
            get { return _data.ProgressChecks.Select(p => new ProgressCheck(p)).ToList(); }
        }

        public Coach(CoachData data) : base(data)
        {
            _data = data;
        }

        public Coach(string name, DateTime birthdate, string login, string password) : 
        base(name, birthdate, login, password)
        {
            var schedule = new Schedule(0, new List<TimeSlot>());
            schedule.Insert(this);
            var scheduleData = (_input as ScheduleData)!;

            _data = new CoachData()
            {
                Name = name,
                BirthDate = birthdate,
                Login = login,
                Password = password,
                Members = new List<MemberData>(),
                Schedule = scheduleData,
                ProgressChecks = new List<ProgressCheckData>()
            };
        }

        public void Insert(ProgressCheck check)
        {
            check.Input = _data;
        }

        public void Insert(Member member)
        {
            member.Input = _data;
        }
    }
}