using Data;

namespace Model
{
    internal class Schedule
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private ScheduleData _data;

        public List<TimeSlot> TimeSlots
        {
            get { return _data.TimeSlots.Select(t => new TimeSlot(t)).ToList(); }
            set 
            {
                _data.TimeSlots = new List<TimeSlotData>();
                foreach (var slot in value)
                {
                    slot.Insert(this);
                    _data.TimeSlots.Add((_input as TimeSlotData)!);
                }
                _input = null;
            }
        }

        public decimal MonthlyFee
        {
            get { return _data.MonthlyFee; }
            set { _data.MonthlyFee = value; }
        }

        public List<Member> Members
        {
            get { return _data.Members.Select(m => new Member(m)).ToList(); }
        }

        public List<Coach> Coaches
        {
            get { return _data.Coaches.Select(c => new Coach(c)).ToList(); }
        }

        public Schedule(ScheduleData data)
        {
            _data = data;
        }

        public Schedule(decimal monthlyFee, List<TimeSlot> time)
        {
            var slots = new List<TimeSlotData>();
            foreach (var slot in time)
            {
                slot.Insert(this);
                slots.Add((_input as TimeSlotData)!);
            }
            _input = null;

            _data = new ScheduleData()
            {
                TimeSlots = slots,
                MonthlyFee = monthlyFee,
                Members = new List<MemberData>(),
                Coaches = new List<CoachData>()
            };
        }

        public static bool operator== (Schedule left, Schedule right)
        {
            return left._data.Id == right._data.Id;
        }

        public static bool operator!= (Schedule left, Schedule right)
        {
            return left._data.Id != right._data.Id;
        }

        public void Insert(Payment payment)
        {
            payment.Input = _data;
        }

        public void Insert(Member member)
        {
            member.Input = _data;
        }

        public void Insert(Coach coach)
        {
            coach.Input = _data;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var objU = obj as Schedule;
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