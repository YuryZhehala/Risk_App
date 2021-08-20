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
    public partial class Objects : Window
    {
        ObservableCollection<RiskObjectViewModel> RiskObjects;
        IRiskObjectService RiskObjectService;

        public Objects()
        {
            InitializeComponent();
            ShowAll();
        }
        private void ShowAll()
        {
            RiskObjectService = new RiskObjectService("TestDbConnection");
            RiskObjects = RiskObjectService.GetAll();
            my_DataGrid_OR.DataContext = RiskObjects;
        }
        private void Add_Click_OR(object sender, RoutedEventArgs e)
        {
            Edit_OR dialog = new Edit_OR();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                RiskObjectService = new RiskObjectService("TestDbConnection");
                RiskObjectViewModel incident = dialog.WindowToModel();
                RiskObjectService.CreateRiskObject(incident);
                dialog.Close();
            }
            ShowAll();
        }
        private void Edit_Click_OR(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid_OR.SelectedItem != null)
            {
                Edit_OR dialog = new Edit_OR((RiskObjectViewModel)my_DataGrid_OR.SelectedItem);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    RiskObjectService = new RiskObjectService("TestDbConnection");
                    RiskObjectViewModel incident = (RiskObjectViewModel)my_DataGrid_OR.SelectedItem;
                    incident.RiskObjectName = dialog.tb_Name_OR.Text;
                    RiskObjectService.UpdateRiskObject(incident);
                    dialog.Close();
                }
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите объект риска для внесения изменений!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowAll_Click_OR(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
    }
}
