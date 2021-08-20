using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel.Interfaces;
using ViewModel.Models;
using ViewModel.Services;
using System.Collections.ObjectModel;

namespace Risk_App.Marks
{
    public partial class M_quantity : Window
    {
        ObservableCollection<QuantityAssessmentViewModel> QuantityAssessments;
        IQuantityAssessmentService QuantityAssessmentService;

        public M_quantity()
        {
            InitializeComponent();
            ShowAll();
        }
        private void ShowAll()
        {
            QuantityAssessmentService = new QuantityAssessmentService("TestDbConnection");
            QuantityAssessments = QuantityAssessmentService.GetAll();
            my_DataGrid_MQ.DataContext = QuantityAssessments;
        }
        private void Add_Click_MQ(object sender, RoutedEventArgs e)
        {
            Edit_MQ dialog = new Edit_MQ();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                QuantityAssessmentService = new QuantityAssessmentService("TestDbConnection");
                QuantityAssessmentViewModel incident = dialog.WindowToModel();
                QuantityAssessmentService.CreateQuantityAssessment(incident);
                dialog.Close();
            }
            ShowAll();
        }
        private void Edit_Click_MQ(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid_MQ.SelectedItem != null)
            {
                Edit_MQ dialog = new Edit_MQ((QuantityAssessmentViewModel)my_DataGrid_MQ.SelectedItem);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    QuantityAssessmentService = new QuantityAssessmentService("TestDbConnection");
                    QuantityAssessmentViewModel incident = (QuantityAssessmentViewModel)my_DataGrid_MQ.SelectedItem;
                    incident.QuantityAssessmentName = dialog.tb_Name_MQ.Text;
                    incident.QuantityAssessmentValue = Convert.ToDecimal(dialog.tb_Value_MQ.Text);
                    QuantityAssessmentService.UpdateQuantityAssessment(incident);
                    dialog.Close();
                }
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите объект для внесения изменений!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowAll_Click_MQ(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
    }
}
