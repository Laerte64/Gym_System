using Data;

namespace Model
{
    internal class Payment
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private PaymentData _data;

        public Member Member
        {
            get { return new Member(_data.Member); }
        }

        public Employee Employee
        {
            get { return new Employee(_data.Employee); }
        }

        public Schedule Schedule
        {
            get { return new Schedule(_data.Schedule); }
        }
        
        public decimal Value
        {
            get { return _data.Value;}
        }

        public DateTime Date
        {
            get { return _data.Date;}
        }

        public Payment(PaymentData data)
        {
            _data = data;
        }

        public Payment(Member member, Employee employee, Schedule schedule, decimal value)
        {
            member.Insert(this);
            var memberData = (_input as MemberData)!;
            employee.Insert(this);
            var employeeData = (_input as EmployeeData)!;
            schedule.Insert(this);
            var scheduleData = (_input as ScheduleData)!;
            _input = null;

            _data = new PaymentData() {
                Member = memberData,
                Employee = employeeData,
                Schedule = scheduleData,
                Value = value,
                Date = DateTime.Now
            };
        }

        public static bool operator== (Payment left, Payment right)
        {
            return left._data.Id == right._data.Id;
        }

        public static bool operator!= (Payment left, Payment right)
        {
            return left._data.Id != right._data.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var objU = obj as Payment;
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