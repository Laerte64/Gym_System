using Data;

namespace Model
{
    internal class Manager : User
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private ManagerData _data;

        public List<TimeSlot> WorkDays
        {
            get { return _data.WorkDays.Select(w => new TimeSlot(w)).ToList(); }
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

        public Manager(ManagerData data) : base(data)
        {
            _data = data;
        }

        public Manager(string name, DateTime birthdate, string login, string password) : 
        base(name, birthdate, login, password)
        {
            _data = new ManagerData()
            {
                Name = name,
                BirthDate = birthdate,
                Login = login,
                Password = password,
                WorkDays = new List<TimeSlotData>()
            };
        }
    }
}