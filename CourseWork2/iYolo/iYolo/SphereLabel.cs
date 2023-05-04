namespace iYolo
{
    public class SphereLabel
    {
        private Sphere _sphere;
        private System.Windows.Forms.Label _scoreLabel;
        private System.Windows.Forms.Label _levelLabel;

        public SphereLabel(Sphere sphere, System.Windows.Forms.Label scoreLabel, System.Windows.Forms.Label levelLabel)
        {
            _sphere = sphere;
            _scoreLabel = scoreLabel;
            _levelLabel = levelLabel;
        }

        public void Render()
        {
            _scoreLabel.Text = $"Бали: {_sphere.GetScore()}";
            _levelLabel.Text = $"Рівень: {_sphere.GetLevel()}";
        }
    }
}