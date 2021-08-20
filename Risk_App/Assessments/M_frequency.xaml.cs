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
    public partial class M_frequency : Window
    {
        ObservableCollection<FrequencyAssessmentViewModel> FrequencyAssessments;
        IFrequencyAssessmentService FrequencyAssessmentService;

        public M_frequency()
        {
            InitializeComponent();
            ShowAll();
        }
        private void ShowAll()
        {
            FrequencyAssessmentService = new FrequencyAssessmentService("TestDbConnection");
            FrequencyAssessments = FrequencyAssessmentService.GetAll();
            my_DataGrid_MF.DataContext = FrequencyAssessments;
        }
        private void Add_Click_MF(object sender, RoutedEventArgs e)
        {
            Edit_MF dialog = new Edit_MF();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                FrequencyAssessmentService = new FrequencyAssessmentService("TestDbConnection");
                FrequencyAssessmentViewModel incident = dialog.WindowToModel();
                FrequencyAssessmentService.CreateFrequencyAssessment(incident);
                dialog.Close();
            }
            ShowAll();
        }
        private void Edit_Click_MF(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid_MF.SelectedItem != null)
            {
                Edit_MF dialog = new Edit_MF((FrequencyAssessmentViewModel)my_DataGrid_MF.SelectedItem);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    FrequencyAssessmentService = new FrequencyAssessmentService("TestDbConnection");
                    FrequencyAssessmentViewModel incident = (FrequencyAssessmentViewModel)my_DataGrid_MF.SelectedItem;
                    incident.FrequencyAssessmentName = dialog.tb_Name_MF.Text;
                    incident.FrequencyAssessmentValue = Convert.ToDecimal(dialog.tb_Value_MF.Text);
                    FrequencyAssessmentService.UpdateFrequencyAssessment(incident);
                    dialog.Close();
                }
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите объект для внесения изменений!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowAll_Click_MF(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
    }
}
