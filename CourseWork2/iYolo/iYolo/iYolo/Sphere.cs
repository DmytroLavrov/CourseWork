namespace iYolo
{
    public class Sphere
    {
        public readonly int Id;
        private String _name;
        private List<string> _goals;
        private int _completedGoalsCount = 0;
        private int _level = 0;

        public string Name {
            get {
                return _name;
            }
        }

        public Sphere(int id, string name, string[] goals)
        {
            this.Id = id;
            _name = name;
            _goals = goals;
        }

        public void AddGoal(string goal) {
            if (!string.IsNullOrWhiteSpace(task))
            {
                _goals.Add(goal);
            }
        }

        public int GetScore() {
            return _completedGoalsCount;
        }
        
        public int GetLevel() {
            return _level;
        }

        public List<string> GetGoals(){
            return _goals;
        }

        public void RemoveGoal(int index) {
            _goals.RemoveAt(goalsListBox.SelectedIndices[i]);
        }

        public void MarkCompleted(int index) {
            RemoveGoal(index);
            IncreaseScore();
        }

        private void IncreaseScore(){
            _completedGoalsCount += 1;

            if(_completedGoalsCount == 5){
                _completedGoalsCount = 0;
                _level += 1;
            }
        }
    }
}