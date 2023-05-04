using System.Collections.Generic;
using System.Linq;

namespace iYolo
{
    public class Sphere
    {
        public readonly int Id;
        private string _name;
        private List<string> _goals;
        private int _completedGoalsCount = 0;
        private int _level = 0;

        public string Name
        {
            get { return _name; }
        }

        public Sphere(int id, string name, string[] goals)
        {
            Id = id;
            _name = name;
            _goals = goals.ToList();
        }

        public static Sphere From(SphereInputDTO dto)
        {
            var sphere = new Sphere(dto.id, dto.name, dto.goals);

            sphere.SetScore(dto.score);
            sphere.SetLevel(dto.level);

            return sphere;
        }

        public void AddGoal(string goal)
        {
            if (!string.IsNullOrWhiteSpace(goal))
            {
                _goals.Add(goal);
            }
        }

        public SphereInputDTO GetDto()
        {
            var dto = new SphereInputDTO();

            dto.id = Id;
            dto.name = Name;
            dto.goals = _goals.ToArray();
            dto.score = _completedGoalsCount;
            dto.level = _level;

            return dto;
        }

        public int GetScore()
        {
            return _completedGoalsCount;
        }

        public void SetScore(int score)
        {
            _completedGoalsCount = score;
        }

        public int GetLevel()
        {
            return _level;
        }

        public void SetLevel(int level)
        {
            _completedGoalsCount = level;
        }

        public List<string> GetGoals()
        {
            return _goals;
        }

        public void RemoveGoal(int index)
        {
            _goals.RemoveAt(index);
        }

        public void MarkCompleted(int index)
        {
            RemoveGoal(index);
            IncreaseScore();
        }

        private void IncreaseScore()
        {
            _completedGoalsCount += 1;

            if (_completedGoalsCount == 5)
            {
                _completedGoalsCount = 0;
                _level += 1;
            }
        }
    }
}