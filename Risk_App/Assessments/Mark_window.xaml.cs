using System;
using System.Windows;
using System.Collections.ObjectModel;

namespace Risk_App
{
    public partial class Mark_window : Window
    {
        ObservableCollection<String> LossType = new ObservableCollection<String>() {"Прямые потери не зафиксированы", "Потери зафиксированы от 1 до 1 000 руб.", "Потери зафиксированы от 1 000 до 20 000 руб.", "Потери зафиксированы от 20 000 руб."};
        ObservableCollection<String> frequency = new ObservableCollection<String>() {"Инцидент произошел впервые", "Инцидент происходил в течение года", "Инцидент происходил в течение года от 2 до 4 раз", "Инцидент происходил в течение года от 5 раз и чаще" };
        ObservableCollection<String> quantity = new ObservableCollection<String>() {"Инцидент затронул 1 подразделение", "Инцидент затронул 2 подразделения", "Инцидент затронул от 3 до 5 подразделений", "Инцидент затронул более 5 подразделений"};
        ObservableCollection<String> time = new ObservableCollection<String>() {"Инцидент длился до 5 минут", "Инцидент длился от 5 до 30 минут", "Инцидент длился от 30 минут до 1 часа", "Инцидент длился свыше 1 часа"};
        int LossType_, frequency_, quantity_, time_;
        decimal total;
        public Mark_window()
        {
            InitializeComponent();
            cb_LossType.DataContext = LossType;
            cb_Frequency.DataContext = frequency;
            cb_Quantity.DataContext = quantity;
            cb_Time.DataContext = time;            
        }
        public void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void bCount_Click(object sender, RoutedEventArgs e)
        {
            switch (cb_LossType.SelectedIndex)
            {
                case 0:
                    LossType_ = 1;
                    break;
                case 1:
                    LossType_ = 2;
                    break;
                case 2:
                    LossType_ = 4;
                    break;
                case 3:
                    LossType_ = 5;
                    break;
            }
            switch (cb_Frequency.SelectedIndex)
            {
                case 0:
                    frequency_ = 1;
                    break;
                case 1:
                    frequency_ = 2;
                    break;
                case 2:
                    frequency_ = 4;
                    break;
                case 3:
                    frequency_ = 5;
                    break;
            }
            switch (cb_Quantity.SelectedIndex)
            {
                case 0:
                    quantity_ = 1;
                    break;
                case 1:
                    quantity_ = 2;
                    break;
                case 2:
                    quantity_ = 4;
                    break;
                case 3:
                    quantity_ = 5;
                    break;
            }
            switch (cb_Time.SelectedIndex)
            {
                case 0:
                    time_ = 1;
                    break;
                case 1:
                    time_ = 2;
                    break;
                case 2:
                    time_ = 4;
                    break;
                case 3:
                    time_ = 5;
                    break;
            }
            total = (LossType_ + frequency_ + quantity_ + time_) / 4;
            lbl_Mark_Total.Content = Math.Round(total,0,0);
        }
        public void bSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
