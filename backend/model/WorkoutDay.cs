using Data;

namespace Model
{
    internal class WorkoutDay
    {
        private object? _input;
        public object Input
        {
            set { _input = value; }
        }

        private WorkoutDayData _data;

        public string Name
        {
            get { return _data.Name; }
        }

        public List<Exercise> Exercises
        {
            get { return _data.Exercises.Select(e => new Exercise(e)).ToList(); }
        }

        public bool Standart
        {
            get { return _data.Standart; }
            set { _data.Standart = value; }
        }

        public WorkoutDay(WorkoutDayData data)
        {
            _data = data;
        }

        public WorkoutDay(string name, List<Exercise> exercises, bool standart)
        {
            var exercisesData = new List<ExerciseData>();
            foreach (var exercise in exercises)
            {
                exercise.Insert(this);
                exercisesData.Add((_input as ExerciseData)!);
            }
            _input = null;

            _data = new WorkoutDayData()
            {
                Name = name,
                Exercises = exercisesData,
                Standart = standart
            };
        }

        public static bool operator== (WorkoutDay left, WorkoutDay right)
        {
            return left._data.Id == right._data.Id;
        }

        public static bool operator!= (WorkoutDay left, WorkoutDay right)
        {
            return left._data.Id == right._data.Id;
        }

        public void Insert(Split split)
        {
            split.Input = _data;
        }

        public void Insert(CheckInDay day)
        {
            day.Input = _data;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var objU = obj as WorkoutDay;
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