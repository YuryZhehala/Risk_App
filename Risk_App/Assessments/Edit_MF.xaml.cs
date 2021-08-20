﻿using System;
using System.Windows;
using ViewModel.Models;

namespace Risk_App.Marks
{
    public partial class Edit_MF : Window
    {
        public int PID = -1;
        public int selectedID=-1;
        decimal dec2;
        public Edit_MF()
        {
            InitializeComponent();
        }
        public Edit_MF(FrequencyAssessmentViewModel incidentVM)
        {
            InitializeComponent();
            ModelToWindow(incidentVM);
        }
        public FrequencyAssessmentViewModel WindowToModel()
        {
            FrequencyAssessmentViewModel incidentVM = new FrequencyAssessmentViewModel();
            incidentVM.FrequencyAssessmentName = tb_Name_MF.Text;
            incidentVM.FrequencyAssessmentId = PID;
            incidentVM.FrequencyAssessmentValue = Convert.ToDecimal(tb_Value_MF.Text);
            return incidentVM;
        }
        public void ModelToWindow(FrequencyAssessmentViewModel incidentVM)
        {
            tb_Name_MF.Text = incidentVM.FrequencyAssessmentName;
            tb_Value_MF.Text = incidentVM.FrequencyAssessmentValue.ToString();
            selectedID = incidentVM.FrequencyAssessmentId;
        }
        public void bOk_Click(object sender, RoutedEventArgs e)
        {           
                switch (selectedID)
                {
                    case 1:
                        if (tb_Name_MF.Text == "")
                        {
                            MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Decimal.TryParse(tb_Value_MF.Text, out dec2) == false)
                        {
                            MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Convert.ToDecimal(tb_Value_MF.Text) < 0 || Convert.ToDecimal(tb_Value_MF.Text) > 1)
                        {
                            MessageBox.Show("Значение параметра должно быть в диапазоне от 0 до 1!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            DialogResult = true;
                        }
                        break;
                    case 2:
                        if (tb_Name_MF.Text == "")
                        {
                            MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Decimal.TryParse(tb_Value_MF.Text, out dec2) == false)
                        {
                            MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Convert.ToDecimal(tb_Value_MF.Text) < 1 || Convert.ToDecimal(tb_Value_MF.Text) > 2)
                        {
                            MessageBox.Show("Значение параметра должно быть в диапазоне от 1 до 2!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            DialogResult = true;
                        };
                        break;
                    case 3:
                        if (tb_Name_MF.Text == "")
                        {
                            MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Decimal.TryParse(tb_Value_MF.Text, out dec2) == false)
                        {
                            MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Convert.ToDecimal(tb_Value_MF.Text) < 2 || Convert.ToDecimal(tb_Value_MF.Text) > 3)
                        {
                            MessageBox.Show("Значение параметра должно быть в диапазоне от 2 до 3!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            DialogResult = true;
                        };
                        break;
                    case 4:
                        if (tb_Name_MF.Text == "")
                        {
                            MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Decimal.TryParse(tb_Value_MF.Text, out dec2) == false)
                        {
                            MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Convert.ToDecimal(tb_Value_MF.Text) < 3 || Convert.ToDecimal(tb_Value_MF.Text) > 4)
                        {
                            MessageBox.Show("Значение параметра должно быть в диапазоне от 3 до 4!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            DialogResult = true;
                        }
                        break;
                    case 5:
                        if (tb_Name_MF.Text == "")
                        {
                            MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Decimal.TryParse(tb_Value_MF.Text, out dec2) == false)
                        {
                            MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (Convert.ToDecimal(tb_Value_MF.Text) < 4 || Convert.ToDecimal(tb_Value_MF.Text) > 5)
                        {
                            MessageBox.Show("Значение параметра должно быть в диапазоне от 4 до 5!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            DialogResult = true;
                        }
                        break;
                
            }



            
        }
        public void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tb_Value_MF_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
