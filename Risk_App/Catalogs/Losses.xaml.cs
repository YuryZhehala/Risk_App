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
    public partial class LossTypes : Window
    {
        ObservableCollection<LossTypeViewModel> LossTypes1;
        ILossTypeService LossTypeService;

        public LossTypes()
        {
            InitializeComponent();
            ShowAll();
        }
        private void ShowAll()
        {
            LossTypeService = new LossTypeService("TestDbConnection");
            LossTypes1 = LossTypeService.GetAll();
            my_DataGrid_LossType.DataContext = LossTypes1;
        }
        private void Add_Click_LossType(object sender, RoutedEventArgs e)
        {
            Edit_LossType dialog = new Edit_LossType();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                LossTypeService = new LossTypeService("TestDbConnection");
                LossTypeViewModel incident = dialog.WindowToModel();
                LossTypeService.CreateLossType(incident);
                dialog.Close();
            }
            ShowAll();
        }
        private void Edit_Click_LossType(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid_LossType.SelectedItem != null)
            {
                Edit_LossType dialog = new Edit_LossType((LossTypeViewModel)my_DataGrid_LossType.SelectedItem);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    LossTypeService = new LossTypeService("TestDbConnection");
                    LossTypeViewModel incident = (LossTypeViewModel)my_DataGrid_LossType.SelectedItem;
                    incident.LossTypeName = dialog.tb_Name_LossType.Text;
                    LossTypeService.UpdateLossType(incident);
                    dialog.Close();
                }
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите тип потерь для внесения изменений!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ShowAll_Click_LossType(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
    }
}
