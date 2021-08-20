using System;
using System.Windows;
using System.Collections.ObjectModel;
using ViewModel.Models;
using ViewModel.Interfaces;
using ViewModel.Services;

namespace Risk_App
{
    public partial class Mark_window2 : Window
    {
        decimal LossType_, frequency_, quantity_, time_;
        decimal total;
        int w;
        public Mark_window2()
        {
            InitializeComponent();
            ModelToWindow2();
        }
        public Mark_window2(IncidentViewModel incidentVM)
        {
            InitializeComponent();
            ModelToWindow(incidentVM);
        }

        public void ModelToWindow(IncidentViewModel incidentVM)
        {
            ObservableCollection<FrequencyAssessmentViewModel> FrequencyAssessments;
            ObservableCollection<LossAssessmentViewModel> LossAssessments;
            ObservableCollection<QuantityAssessmentViewModel> QuantityAssessments;
            ObservableCollection<DurationAssessmentViewModel> DurationAssessments;
            IFrequencyAssessmentService FrequencyAssessmentService = new FrequencyAssessmentService("TestDbConnection");
            ILossAssessmentservice LossAssessmentservice = new LossAssessmentservice("TestDbConnection");
            IQuantityAssessmentService QuantityAssessmentService = new QuantityAssessmentService("TestDbConnection");
            IDurationAssessmentService DurationAssessmentService = new DurationAssessmentService("TestDbConnection");
            FrequencyAssessments = FrequencyAssessmentService.GetAll();
            LossAssessments = LossAssessmentservice.GetAll();
            QuantityAssessments = QuantityAssessmentService.GetAll();
            DurationAssessments = DurationAssessmentService.GetAll();
            cb_LossType.DataContext = LossAssessments;
            cb_Frequency.DataContext = FrequencyAssessments;
            cb_Quantity.DataContext = QuantityAssessments;
            cb_Time.DataContext = DurationAssessments;           
            int a = 0, b = 0, c = 0, d = 0;
            foreach (var i in LossAssessments)
            {
                if (i.LossAssessmentId == incidentVM.LossAssessmentId)
                { cb_LossType.SelectedIndex = a; }
                a++;
            }
            foreach (var i in FrequencyAssessments)
            {
                if (i.FrequencyAssessmentId == incidentVM.FrequencyAssessmentId)
                { cb_Frequency.SelectedIndex = b; }
                b++;
            }
            foreach (var i in DurationAssessments)
            {
                if (i.DurationAssessmentId == incidentVM.DurationAssessmentId)
                { cb_Time.SelectedIndex = c; }
                c++;
            }
            foreach (var i in QuantityAssessments)
            {
                if (i.QuantityAssessmentId == incidentVM.QuantityAssessmentId)
                { cb_Quantity.SelectedIndex = d; }
                d++;
            }         
        }

        public void ModelToWindow2()
        {
            ObservableCollection<FrequencyAssessmentViewModel> FrequencyAssessments;
            ObservableCollection<LossAssessmentViewModel> LossAssessments;
            ObservableCollection<QuantityAssessmentViewModel> QuantityAssessments;
            ObservableCollection<DurationAssessmentViewModel> DurationAssessments;
            IFrequencyAssessmentService FrequencyAssessmentService = new FrequencyAssessmentService("TestDbConnection");
            ILossAssessmentservice LossAssessmentservice = new LossAssessmentservice("TestDbConnection");
            IQuantityAssessmentService QuantityAssessmentService = new QuantityAssessmentService("TestDbConnection");
            IDurationAssessmentService DurationAssessmentService = new DurationAssessmentService("TestDbConnection");
            FrequencyAssessments = FrequencyAssessmentService.GetAll();
            LossAssessments = LossAssessmentservice.GetAll();
            QuantityAssessments = QuantityAssessmentService.GetAll();
            DurationAssessments = DurationAssessmentService.GetAll();
            cb_LossType.DataContext = LossAssessments;
            cb_Frequency.DataContext = FrequencyAssessments;
            cb_Quantity.DataContext = QuantityAssessments;
            cb_Time.DataContext = DurationAssessments;
            cb_LossType.SelectedIndex = 0;           
            cb_Frequency.SelectedIndex = 0;
            cb_Time.SelectedIndex = 0;
            cb_Quantity.SelectedIndex = 0;
        }

        public void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void count()
        {
            ObservableCollection<FrequencyAssessmentViewModel> FrequencyAssessments;
            ObservableCollection<LossAssessmentViewModel> LossAssessments;
            ObservableCollection<QuantityAssessmentViewModel> QuantityAssessments;
            ObservableCollection<DurationAssessmentViewModel> DurationAssessments;
            IFrequencyAssessmentService FrequencyAssessmentService = new FrequencyAssessmentService("TestDbConnection");
            ILossAssessmentservice LossAssessmentservice = new LossAssessmentservice("TestDbConnection");
            IQuantityAssessmentService QuantityAssessmentService = new QuantityAssessmentService("TestDbConnection");
            IDurationAssessmentService DurationAssessmentService = new DurationAssessmentService("TestDbConnection");
            FrequencyAssessments = FrequencyAssessmentService.GetAll();
            LossAssessments = LossAssessmentservice.GetAll();
            QuantityAssessments = QuantityAssessmentService.GetAll();
            DurationAssessments = DurationAssessmentService.GetAll();

            switch (cb_LossType.SelectedIndex)
            {
                case 0:
                    LossType_ = LossAssessments[0].LossAssessmentValue;
                    break;
                case 1:
                    LossType_ = LossAssessments[1].LossAssessmentValue;
                    break;
                case 2:
                    LossType_ = LossAssessments[2].LossAssessmentValue;
                    break;
                case 3:
                    LossType_ = LossAssessments[3].LossAssessmentValue;
                    break;
                case 4:
                    LossType_ = LossAssessments[4].LossAssessmentValue;
                    break;
            }
            switch (cb_Frequency.SelectedIndex)
            {
                case 0:
                    frequency_ = FrequencyAssessments[0].FrequencyAssessmentValue;
                    break;
                case 1:
                    frequency_ = FrequencyAssessments[1].FrequencyAssessmentValue;
                    break;
                case 2:
                    frequency_ = FrequencyAssessments[2].FrequencyAssessmentValue;
                    break;
                case 3:
                    frequency_ = FrequencyAssessments[3].FrequencyAssessmentValue;
                    break;
                case 4:
                    frequency_ = FrequencyAssessments[4].FrequencyAssessmentValue;
                    break;
            }
            switch (cb_Quantity.SelectedIndex)
            {
                case 0:
                    quantity_ = QuantityAssessments[0].QuantityAssessmentValue;
                    break;
                case 1:
                    quantity_ = QuantityAssessments[1].QuantityAssessmentValue;
                    break;
                case 2:
                    quantity_ = QuantityAssessments[2].QuantityAssessmentValue;
                    break;
                case 3:
                    quantity_ = QuantityAssessments[3].QuantityAssessmentValue;
                    break;
                case 4:
                    quantity_ = QuantityAssessments[4].QuantityAssessmentValue;
                    break;
            }
            switch (cb_Time.SelectedIndex)
            {
                case 0:
                    time_ = DurationAssessments[0].DurationAssessmentValue;
                    break;
                case 1:
                    time_ = DurationAssessments[1].DurationAssessmentValue;
                    break;
                case 2:
                    time_ = DurationAssessments[2].DurationAssessmentValue;
                    break;
                case 3:
                    time_ = DurationAssessments[3].DurationAssessmentValue;
                    break;
                case 4:
                    time_ = DurationAssessments[4].DurationAssessmentValue;
                    break;
            }
            total = (LossType_ + frequency_ + quantity_ + time_) / 4;
            lbl_Mark_Total.Content = Math.Round(total, 0, 0);
        }

        public void bCount_Click(object sender, RoutedEventArgs e)
        {
            count();
        }
        public void bSave_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(lbl_Mark_Total.Content.ToString(), out w) == false)
            {
                MessageBox.Show("Для сохранения оценки тяжести ее необходимо рассчитать!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                count();
                DialogResult = true;
            }          
        }
    }
}
