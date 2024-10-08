using Data;

namespace Model
{
    internal class CheckInDay
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private CheckInDayData _data;

        public Member Member
        {
            get { return new Member(_data.Member); }
        }

        public Employee Employee
        {
            get { return new Employee(_data.Employee); }
        }

        public WorkoutDay WorkoutDay
        {
            get { return new WorkoutDay(_data.WorkoutDay); }
        }

        public DateTime Date 
        {
            get { return _data.Date; }
        }

        public CheckInDay(CheckInDayData data)
        {
            _data = data;
        }

        public CheckInDay(Member member, Employee employee, WorkoutDay day, DateTime date)
        {
            member.Insert(this);
            var memberData = (_input as MemberData)!;
            employee.Insert(this);
            var employeeData = (_input as EmployeeData)!;
            day.Insert(this);
            var dayData = (_input as WorkoutDayData)!;
            _input = null;

            _data = new CheckInDayData()
            {
                Member = memberData,
                Employee = employeeData,
                WorkoutDay = dayData,
                Date = date
            };
        }

        public static bool operator== (CheckInDay left, CheckInDay right)
        {
            return left._data.Id == right._data.Id;
        }

        public static bool operator!= (CheckInDay left, CheckInDay right)
        {
            return left._data.Id != right._data.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var objU = obj as CheckInDay;
            if (objU is not null)
                return this == objU;
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}