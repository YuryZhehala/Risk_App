using System.Windows;
using ViewModel.Models;

namespace Risk_App
{
    public partial class Edit_OR : Window
    {
        public int PID = -1;
        public Edit_OR()
        {
            InitializeComponent();
        }
        public Edit_OR(RiskObjectViewModel incidentVM)
        {
            InitializeComponent();
            ModelToWindow(incidentVM);
        }
        public RiskObjectViewModel WindowToModel()
        {
            RiskObjectViewModel incidentVM = new RiskObjectViewModel();
            incidentVM.RiskObjectName = tb_Name_OR.Text;
            incidentVM.RiskObjectId = PID;
            return incidentVM;
        }
        public void ModelToWindow(RiskObjectViewModel incidentVM)
        {
            tb_Name_OR.Text = incidentVM.RiskObjectName;
        }
        public void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name_OR.Text == "")
            {
                MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DialogResult = true;
            }
        }
        public void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
