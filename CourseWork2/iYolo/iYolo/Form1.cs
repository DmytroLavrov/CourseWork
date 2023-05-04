using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iYolo
{
    public partial class MainForm : Form
    {
        private Sphere[] _spheres = SphereJsonService.Load().Select(dto => Sphere.From(dto)).ToArray();

        private Sphere _selectedSphere
        {
            get
            {
                string selectedLifeSphere = spheresListBox.SelectedItem.ToString();

                return _spheres.ToList().Find(sphere => sphere.Name == selectedLifeSphere);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            UpdateSpheresLabels();
            UpdateLifeSpheresListBox();
        }

        private void addGoal_Click(object sender, EventArgs e)
        {
            string goal = textBox1.Text;
            textBox1.Text = "";
            _selectedSphere.AddGoal(goal);
            UpdateSelectedGoalsListBox();
        }

        private void completeGoal_Click(object sender, EventArgs e)
        {
            int selectedCount = goalsListBox.SelectedItems.Count;

            if (selectedCount <= 0)
            {
                return;
            }

            var goalIndex = goalsListBox.SelectedIndices[0];
            _selectedSphere.MarkCompleted(goalIndex);
            UpdateSpheresLabels();
            UpdateSelectedGoalsListBox();
        }

        private void deleteGoal_Click(object sender, EventArgs e)
        {
            int selectedCount = goalsListBox.SelectedItems.Count;

            if (selectedCount > 0)
            {
                return;
            }

            _selectedSphere.RemoveGoal(goalsListBox.SelectedIndices[0]);
            UpdateSelectedGoalsListBox();
        }

        private void spheresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedGoalsListBox();
        }
        private void UpdateSelectedGoalsListBox()
        {
            goalsListBox.Items.Clear();
            goalsListBox.Items.AddRange(_selectedSphere.GetGoals().ToArray());

            SaveSpheres();
        }
        private void UpdateSpheresLabels()
        {
            var sphereLabels = GetSphereLabelsList();

            foreach (var sphereLabel in sphereLabels)
            {
                sphereLabel.Render();
            }
        }

        private void UpdateLifeSpheresListBox()
        {
            spheresListBox.Items.AddRange(_spheres.Select(sphere => sphere.Name).ToArray());
            spheresListBox.SelectedIndex = 0;
        }

        private List<SphereLabel> GetSphereLabelsList() {
            var list = new List<SphereLabel>();

            var scoreLabels = new Dictionary<int, System.Windows.Forms.Label> {
                {1, label1},
                {2, label3},
                {3, label5},
                {4, label7},
                {5, label9},
            };

            var levelLabels = new Dictionary<int, System.Windows.Forms.Label> {
                {1, label2},
                {2, label4},
                {3, label6},
                {4, label8},
                {5, label10},
            };

            foreach (var sphere in _spheres)
            {
                list.Add(new SphereLabel(sphere, scoreLabels[sphere.Id], levelLabels[sphere.Id]));
            }

            return list;
        }

        private void SaveSpheres()
        {
            var dtos = _spheres.Select(sphere => sphere.GetDto());

            SphereJsonService.Save(dtos.ToArray());
        }
    }
}
