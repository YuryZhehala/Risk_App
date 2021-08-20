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
    public partial class M_LossType : Window
    {
        ObservableCollection<LossAssessmentViewModel> LossAssessments;
        ILossAssessmentservice LossAssessmentservice;

        public M_LossType()
        {
            InitializeComponent();
            ShowAll();
        }
        private void ShowAll()
        {
            LossAssessmentservice = new LossAssessmentservice("TestDbConnection");
            LossAssessments = LossAssessmentservice.GetAll();
            my_DataGrid_ML.DataContext = LossAssessments;
        }
        private void Add_Click_ML(object sender, RoutedEventArgs e)
        {
            Edit_ML dialog = new Edit_ML();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                LossAssessmentservice = new LossAssessmentservice("TestDbConnection");
                LossAssessmentViewModel incident = dialog.WindowToModel();
                LossAssessmentservice.CreateLossAssessment(incident);
                dialog.Close();
            }
            ShowAll();
        }
        private void Edit_Click_ML(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid_ML.SelectedItem != null)
            {
                Edit_ML dialog = new Edit_ML((LossAssessmentViewModel)my_DataGrid_ML.SelectedItem);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    LossAssessmentservice = new LossAssessmentservice("TestDbConnection");
                    LossAssessmentViewModel incident = (LossAssessmentViewModel)my_DataGrid_ML.SelectedItem;
                    incident.LossAssessmentName = dialog.tb_Name_ML.Text;
                    incident.LossAssessmentValue = Convert.ToDecimal(dialog.tb_Value_ML.Text);
                    LossAssessmentservice.UpdateLossAssessment(incident);
                    dialog.Close();
                }
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите объект для внесения изменений!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowAll_Click_ML(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
    }
}
