using Data;

namespace Model
{
    internal class Exercise
    {
        private ExerciseData _data;

        public string Name
        {
            get { return _data.Name; }
        }

        public string Equipment
        {
            get { return _data.Equipment;}
        }

        public Exercise(ExerciseData data)
        {
            _data = data;
        }

        public Exercise(string name, string equipment)
        {
            _data = new ExerciseData()
            {
                Name = name,
                Equipment = equipment
            };
        }

        public static bool operator== (Exercise left, Exercise right)
        {
            return left._data.Id == right._data.Id;
        }

        public static bool operator!= (Exercise left, Exercise right)
        {
            return left._data.Id != right._data.Id;
        }

        public void Insert(WorkoutDay day)
        {
            day.Input = _data;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var objU = obj as Exercise;
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