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

namespace Risk_App
{
    public partial class Sources : Window
    {
        ObservableCollection<RiskSourceViewModel> RiskSources;
        IRiskSourceService RiskSourceService;
        
        public Sources()
        {
            InitializeComponent();
            ShowAll();
        }
        private void ShowAll()
        {
            RiskSourceService = new RiskSourceService("TestDbConnection");
            RiskSources = RiskSourceService.GetAll();
            my_DataGrid_SR.DataContext = RiskSources;
        }
        private void Add_Click_SR(object sender, RoutedEventArgs e)
        {
            Edit_SR dialog = new Edit_SR();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                RiskSourceService = new RiskSourceService("TestDbConnection");
                RiskSourceViewModel incident = dialog.WindowToModel();
                RiskSourceService.CreateRiskSource(incident);
                dialog.Close();
            }
            ShowAll();
        }
        private void Edit_Click_SR(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid_SR.SelectedItem != null)
            {
                Edit_SR dialog = new Edit_SR((RiskSourceViewModel)my_DataGrid_SR.SelectedItem);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    RiskSourceService = new RiskSourceService("TestDbConnection");
                    RiskSourceViewModel incident = (RiskSourceViewModel)my_DataGrid_SR.SelectedItem;
                    incident.RiskSourceName = dialog.tb_Name_SR.Text;
                    RiskSourceService.UpdateRiskSource(incident);
                    dialog.Close();
                }
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите источник риска для внесения изменений!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowAll_Click_SR(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
    }
}
