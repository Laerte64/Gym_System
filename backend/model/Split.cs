using Data;

namespace Model
{
    internal class Split
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private SplitData _data;

        public string Name 
        {
            get { return _data.Name; }
        }

        public List<WorkoutDay> Days
        {
            get { return _data.Days.Select(d => new WorkoutDay(d)).ToList(); }
        }

        public bool Standart
        {
            get { return _data.Standart; }
            set { _data.Standart = value; }
        }

        public Split(SplitData data)
        {
            _data = data;
        }

        public Split(string name, List<WorkoutDay> days, bool standart)
        {
            var daysData = new List<WorkoutDayData>();
            foreach (var day in days)
            {
                day.Insert(this);
                daysData.Add((_input as WorkoutDayData)!);
                
            }
            _input = null;

            _data = new SplitData()
            {
                Name = name,
                Days = daysData,
                Standart = standart
            };
        }

        public static bool operator== (Split left, Split right)
        {
            return left._data.Id == right._data.Id;
        }

        public static bool operator!= (Split left, Split right)
        {
            return left._data.Id != right._data.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var objU = obj as Split;
            if (objU is not null)
                return this == objU;
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public void Insert(Member member)
        {
            member.Input = _data;
        }
    }
}