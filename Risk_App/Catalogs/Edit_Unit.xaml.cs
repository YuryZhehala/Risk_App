using System.Windows;
using ViewModel.Models;

namespace Risk_App
{
    public partial class Edit_Unit : Window
    {
        public int PID = -1;
        public Edit_Unit()
        {
            InitializeComponent();
        }
        public Edit_Unit(UnitViewModel incidentVM)
        {
            InitializeComponent();
            ModelToWindow(incidentVM);
        }
        public UnitViewModel WindowToModel()
        {
            UnitViewModel incidentVM = new UnitViewModel();
            incidentVM.UnitName = tb_Name_Unit.Text;
            incidentVM.UnitId = PID;
            return incidentVM;
        }
        public void ModelToWindow(UnitViewModel incidentVM)
        {
            tb_Name_Unit.Text = incidentVM.UnitName;
        }
        public void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name_Unit.Text == "")
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
