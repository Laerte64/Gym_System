using Data;

namespace Model
{
    internal class TimeSlot
    {
        private TimeSlotData _data;

        public DayOfWeek Day 
        {
            get { return _data.Day; }
        }

        public TimeSpan Start
        {
            get { return _data.Start; }
        }

        public TimeSpan End
        {
            get { return _data.End; }
        }

        public TimeSlot(TimeSlotData data)
        {
            _data = data;
        }

        public TimeSlot(DayOfWeek day, TimeSpan start, TimeSpan end)
        {
            _data = new TimeSlotData
            {
                Day = day,
                Start = start,
                End = end
            };
        }

        public static bool operator== (TimeSlot left, TimeSlot right)
        {
            return left._data.Id == right._data.Id;
        }

        public static bool operator!= (TimeSlot left, TimeSlot right)
        {
           return left._data.Id != right._data.Id;
        }

        public void Insert(Manager manager)
        {
            manager.Input = _data;
        }

        public void Insert(Schedule schedule)
        {
            schedule.Input = _data;
        }

        public void Insert(Employee employee)
        {
            employee.Input = _data;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var objU = obj as TimeSlot;
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