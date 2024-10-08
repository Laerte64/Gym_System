using Data;

namespace Model
{
    internal class Employee : User
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private EmployeeData _data;

        public List<TimeSlot> WorkDays 
        { 
            get { return _data.WorkDays.Select(t => new TimeSlot(t)).ToList(); }
            set
            {
                _data.WorkDays = new List<TimeSlotData>();
                foreach (var day in value)
                {
                    day.Insert(this);
                    _data.WorkDays.Add((_input as TimeSlotData)!);
                    
                }
                _input = null;
            }
        }

        public List<Payment> Payments
        {
            get { return _data.Payments.Select(p => new Payment(p)).ToList(); }
        }

        public List<CheckInDay> CheckInDays
        {
            get { return _data.CheckInDays.Select(c => new CheckInDay(c)).ToList(); }
        }

        public Employee(EmployeeData data) : base(data)
        {
            _data = data;
        }

        public Employee(string name, DateTime birthdate, string login, string password) : 
        base(name, birthdate, login, password)
        {
            _data = new EmployeeData()
            {
                Name = name,
                BirthDate = birthdate,
                Login = login,
                Password = password,
                WorkDays = new List<TimeSlotData>(),
                Payments = new List<PaymentData>(),
                CheckInDays = new List<CheckInDayData>()
            };
        }

        internal void Insert(CheckInDay checkInDay)
        {
            checkInDay.Input = _data;
        }

        public void Insert(Payment payment)
        {
            payment.Input = _data;
        }
    }
}