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
    public partial class M_time : Window
    {
        ObservableCollection<DurationAssessmentViewModel> DurationAssessments;
        IDurationAssessmentService DurationAssessmentService;

        public M_time()
        {
            InitializeComponent();
            ShowAll();
        }
        private void ShowAll()
        {
            DurationAssessmentService = new DurationAssessmentService("TestDbConnection");
            DurationAssessments = DurationAssessmentService.GetAll();
            my_DataGrid_MT.DataContext = DurationAssessments;
        }
        private void Add_Click_MT(object sender, RoutedEventArgs e)
        {
            Edit_MT dialog = new Edit_MT();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                DurationAssessmentService = new DurationAssessmentService("TestDbConnection");
                DurationAssessmentViewModel incident = dialog.WindowToModel();
                DurationAssessmentService.CreateDurationAssessment(incident);
                dialog.Close();
            }
            ShowAll();
        }
        private void Edit_Click_MT(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid_MT.SelectedItem != null)
            {
                Edit_MT dialog = new Edit_MT((DurationAssessmentViewModel)my_DataGrid_MT.SelectedItem);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    DurationAssessmentService = new DurationAssessmentService("TestDbConnection");
                    DurationAssessmentViewModel incident = (DurationAssessmentViewModel)my_DataGrid_MT.SelectedItem;
                    incident.DurationAssessmentName = dialog.tb_Name_MT.Text;
                    incident.DurationAssessmentValue = Convert.ToDecimal(dialog.tb_Value_MT.Text);
                    DurationAssessmentService.UpdateDurationAssessment(incident);
                    dialog.Close();
                }
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите объект для внесения изменений!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowAll_Click_MT(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
    }
}
