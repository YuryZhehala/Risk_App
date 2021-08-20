using System;
using System.Windows;
using ViewModel.Models;

namespace Risk_App.Marks
{
    public partial class Edit_MT : Window
    {
        public int PID = -1;
        public int selectedID = -1;
        decimal dec2;
        public Edit_MT()
        {
            InitializeComponent();
        }
        public Edit_MT(DurationAssessmentViewModel incidentVM)
        {
            InitializeComponent();
            ModelToWindow(incidentVM);
        }
        public DurationAssessmentViewModel WindowToModel()
        {
            DurationAssessmentViewModel incidentVM = new DurationAssessmentViewModel();
            incidentVM.DurationAssessmentName = tb_Name_MT.Text;
            incidentVM.DurationAssessmentId = PID;
            incidentVM.DurationAssessmentValue = Convert.ToDecimal(tb_Value_MT.Text);
            return incidentVM;
        }
        public void ModelToWindow(DurationAssessmentViewModel incidentVM)
        {
            tb_Name_MT.Text = incidentVM.DurationAssessmentName;
            tb_Value_MT.Text = incidentVM.DurationAssessmentValue.ToString();
            selectedID = incidentVM.DurationAssessmentId;
        }
        public void bOk_Click(object sender, RoutedEventArgs e)
        {
            switch (selectedID)
            {
                case 1:
                    if (tb_Name_MT.Text == "")
                    {
                        MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Decimal.TryParse(tb_Value_MT.Text, out dec2) == false)
                    {
                        MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Convert.ToDecimal(tb_Value_MT.Text) < 0 || Convert.ToDecimal(tb_Value_MT.Text) > 1)
                    {
                        MessageBox.Show("Значение параметра должно быть в диапазоне от 0 до 1!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        DialogResult = true;
                    }
                    break;
                case 2:
                    if (tb_Name_MT.Text == "")
                    {
                        MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Decimal.TryParse(tb_Value_MT.Text, out dec2) == false)
                    {
                        MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Convert.ToDecimal(tb_Value_MT.Text) < 1 || Convert.ToDecimal(tb_Value_MT.Text) > 2)
                    {
                        MessageBox.Show("Значение параметра должно быть в диапазоне от 1 до 2!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        DialogResult = true;
                    };
                    break;
                case 3:
                    if (tb_Name_MT.Text == "")
                    {
                        MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Decimal.TryParse(tb_Value_MT.Text, out dec2) == false)
                    {
                        MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Convert.ToDecimal(tb_Value_MT.Text) < 2 || Convert.ToDecimal(tb_Value_MT.Text) > 3)
                    {
                        MessageBox.Show("Значение параметра должно быть в диапазоне от 2 до 3!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        DialogResult = true;
                    };
                    break;
                case 4:
                    if (tb_Name_MT.Text == "")
                    {
                        MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Decimal.TryParse(tb_Value_MT.Text, out dec2) == false)
                    {
                        MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Convert.ToDecimal(tb_Value_MT.Text) < 3 || Convert.ToDecimal(tb_Value_MT.Text) > 4)
                    {
                        MessageBox.Show("Значение параметра должно быть в диапазоне от 3 до 4!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        DialogResult = true;
                    }
                    break;
                case 5:
                    if (tb_Name_MT.Text == "")
                    {
                        MessageBox.Show("Заполните форму", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Decimal.TryParse(tb_Value_MT.Text, out dec2) == false)
                    {
                        MessageBox.Show("Введите число в поле значения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (Convert.ToDecimal(tb_Value_MT.Text) < 4 || Convert.ToDecimal(tb_Value_MT.Text) > 5)
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
    }
}
