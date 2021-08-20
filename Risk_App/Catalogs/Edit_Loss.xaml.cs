using System.Windows;
using ViewModel.Models;

namespace Risk_App
{
    public partial class Edit_LossType : Window
    {
        public int PID = -1;
        public Edit_LossType()
        {
            InitializeComponent();
        }
        public Edit_LossType(LossTypeViewModel incidentVM)
        {
            InitializeComponent();
            ModelToWindow(incidentVM);
        }
        public LossTypeViewModel WindowToModel()
        {
            LossTypeViewModel incidentVM = new LossTypeViewModel();
            incidentVM.LossTypeName = tb_Name_LossType.Text;
            incidentVM.LossTypeId = PID;
            return incidentVM;
        }
        public void ModelToWindow(LossTypeViewModel incidentVM)
        {
            tb_Name_LossType.Text = incidentVM.LossTypeName;
        }
        public void bOk_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name_LossType.Text == "")
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
