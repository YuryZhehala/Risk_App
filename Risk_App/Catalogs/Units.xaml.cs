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
    public partial class Units : Window
    {
        ObservableCollection<UnitViewModel> Units1;
        IUnitService UnitService;

        public Units()
        {
            InitializeComponent();
            ShowAll();
        }
        private void ShowAll()
        {
            UnitService = new UnitService("TestDbConnection");
            Units1 = UnitService.GetAll();
            my_DataGrid_Unit.DataContext = Units1;
        }
        private void Add_Click_Unit(object sender, RoutedEventArgs e)
        {
            Edit_Unit dialog = new Edit_Unit();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                UnitService = new UnitService("TestDbConnection");
                UnitViewModel incident = dialog.WindowToModel();
                UnitService.CreateUnit(incident);
                dialog.Close();
            }
            ShowAll();
        }
        private void Edit_Click_Unit(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid_Unit.SelectedItem != null)
            {
                Edit_Unit dialog = new Edit_Unit((UnitViewModel)my_DataGrid_Unit.SelectedItem);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    UnitService = new UnitService("TestDbConnection");
                    UnitViewModel incident = (UnitViewModel)my_DataGrid_Unit.SelectedItem;
                    incident.UnitName = dialog.tb_Name_Unit.Text;
                    UnitService.UpdateUnit(incident);
                    dialog.Close();
                }
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите подразделение для внесения изменений!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowAll_Click_Unit(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
    }
}
