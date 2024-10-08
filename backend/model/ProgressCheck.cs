using Data;

namespace Model
{
    internal class ProgressCheck
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private ProgressCheckData _data;

        public Member Member
        {
            get { return new Member(_data.Member); }
        }

        public Coach Coach
        {
            get { return new Coach(_data.Coach); }
        }

        public DateTime Date
        {
            get { return _data.Date; }
        }

        public decimal Height
        {
            get { return _data.Height; }
        }

        public decimal Mass
        {
            get { return _data.Mass; }
        }

        public decimal Fat
        {
            get { return _data.Fat; }
        }

        public ProgressCheck(ProgressCheckData data)
        {
            _data = data;
        }

        public ProgressCheck(Member member, Coach coach, decimal height, decimal mass, decimal fat)
        {
            member.Insert(this);
            var memberData = (_input as MemberData)!;
            coach.Insert(this);
            var coachData = (_input as CoachData)!;
            _input = null;

            _data = new ProgressCheckData()
            {
                Member = memberData,
                Coach = coachData,
                Date = DateTime.Now,
                Height = height,
                Mass = mass,
                Fat = fat
            };
        }

        public static bool operator== (ProgressCheck left, ProgressCheck right)
        {
            return left._data.Id == right._data.Id;
        }

        public static bool operator!= (ProgressCheck left, ProgressCheck right)
        {
            return left._data.Id != right._data.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var objU = obj as ProgressCheck;
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