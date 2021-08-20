using LiveCharts;
using Microsoft.Win32;
using NLog;
using Risk_App.Marks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using ViewModel.Interfaces;
using ViewModel.Models;
using ViewModel.Services;

namespace Risk_App
{
    public partial class TabSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            TabControl tabControl = values[0] as TabControl;
            double width = tabControl.ActualWidth / tabControl.Items.Count;
            //Subtract 1, otherwise we could overflow to two rows.
            return (width <= 1) ? 0 : (width - 1.5);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public partial class MainWindow : Window
    {
        ObservableCollection<IncidentViewModel> riskSources;
        IIncidentService riskSourceService;
        Logger logger = LogManager.GetCurrentClassLogger();
        public List<string> st = new List<string> { "Урегулирован", "Не урегулирован" };

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += open;
            this.Closed += close;
            ShowAll();        
        }

        private void ShowAll()
        {
            decimal sum = 0, sum1=0;
            List<int> assessment = new List<int> {1,2,3,4,5};
            List<string> so = new List<string> { "Все" };
            List<string> so1 = new List<string> { "Все", "Урегулирован", "Не урегулирован" };
            List<DateTime> mydate=new List<DateTime> { };
            riskSourceService = new IncidentService("TestDbConnection");
            IRiskSourceService sr = new RiskSourceService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            ObservableCollection<RiskSourceViewModel> srs = sr.GetAll();
            my_DataGrid.DataContext = riskSources;
            foreach (var a in riskSources)
            {
                sum += a.DirectLossType;
                sum1 += a.PotentialLossType;
            }
            var culture = new CultureInfo("ru-RU") { NumberFormat = { NumberGroupSeparator = " " }, };
            lb_TotalA.Text = sum.ToString("#0,0.0#", culture);
            lb_TotalQ.Content = sum1.ToString("#0,0.0#", culture);
            foreach (var a in riskSources)
            {
                mydate.Add( a.DateOfIncident);
            }
            foreach (var a in srs)
            {
                so.Add(a.RiskSourceId.ToString()+' '+a.RiskSourceName);
            }
            dp_begin_gr.Text = mydate.Min().ToString();
            dp_end_gr.Text = DateTime.Now.ToString();
            dp_begin.Text= mydate.Min().ToString();
            dp_end.Text = DateTime.Now.ToString();
            tb_SR.DataContext = so;
            tb_Status.DataContext = so1;
            //tb_Mark_start.Text = "1";
            //tb_Mark_end.Text = "5";
            tb_Mark_start.DataContext = assessment;
            tb_Mark_end.DataContext = assessment;
            tb_Mark_start.SelectedIndex = 0;
            tb_Mark_end.SelectedIndex = 4;
            tb_SR.SelectedIndex = 0;
            tb_Status.SelectedIndex = 0;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<RiskObjectViewModel> RiskObjects;
            ObservableCollection<RiskSourceViewModel> RiskSources;
            ObservableCollection<UnitViewModel> Units;
            ObservableCollection<LossTypeViewModel> LossTypes;
            ObservableCollection<FrequencyAssessmentViewModel> FrequencyAssessments;
            ObservableCollection<LossAssessmentViewModel> LossAssessments;
            ObservableCollection<QuantityAssessmentViewModel> QuantityAssessments;
            ObservableCollection<DurationAssessmentViewModel> DurationAssessments;
            IRiskObjectService RiskObjectService = new RiskObjectService("TestDbConnection");
            IRiskSourceService RiskSourceService = new RiskSourceService("TestDbConnection");
            IUnitService UnitService = new UnitService("TestDbConnection");
            ILossTypeService LossTypeService = new LossTypeService("TestDbConnection");
            IFrequencyAssessmentService FrequencyAssessmentService = new FrequencyAssessmentService("TestDbConnection");
            ILossAssessmentservice LossAssessmentservice = new LossAssessmentservice("TestDbConnection");
            IQuantityAssessmentService QuantityAssessmentService = new QuantityAssessmentService("TestDbConnection");
            IDurationAssessmentService DurationAssessmentService = new DurationAssessmentService("TestDbConnection");
            RiskObjects = RiskObjectService.GetAll();
            RiskSources = RiskSourceService.GetAll();
            Units = UnitService.GetAll();
            LossTypes = LossTypeService.GetAll();
            FrequencyAssessments = FrequencyAssessmentService.GetAll();
            LossAssessments = LossAssessmentservice.GetAll();
            QuantityAssessments = QuantityAssessmentService.GetAll();
            DurationAssessments = DurationAssessmentService.GetAll();
            AddIncident dialog = new AddIncident();
            dialog.cb_OR.DataContext = RiskObjects;
            dialog.cb_SR.DataContext = RiskSources;
            dialog.cb_LossType.DataContext = LossTypes;
            dialog.cb_Unit.DataContext = Units;
            dialog.cb_Status.DataContext = st;
            dialog.cb_SR.SelectedIndex = 0;
            dialog.cb_OR.SelectedIndex = 0;
            dialog.cb_LossType.SelectedIndex = 0;
            dialog.cb_Unit.SelectedIndex = 0;
            dialog.cb_Status.SelectedIndex = 0;
            dialog.dp_Date.Text = DateTime.Today.ToString();
            var result = dialog.ShowDialog();
            if (result == true)
            {
                IIncidentService incidentService = new IncidentService("TestDbConnection");
                IncidentViewModel incident = dialog.WindowToModel();
                incident.RiskObjectId = RiskObjects[dialog.cb_OR.SelectedIndex].RiskObjectId;
                incident.RiskSourceId = RiskSources[dialog.cb_SR.SelectedIndex].RiskSourceId;
                incident.UnitId = Units[dialog.cb_Unit.SelectedIndex].UnitId;
                incident.LossTypeId = LossTypes[dialog.cb_LossType.SelectedIndex].LossTypeId;
                incident.FrequencyAssessmentId = FrequencyAssessments[dialog.incidentVM3.FrequencyAssessmentId].FrequencyAssessmentId;
                incident.LossAssessmentId = LossAssessments[dialog.incidentVM3.LossAssessmentId].LossAssessmentId;
                incident.QuantityAssessmentId = QuantityAssessments[dialog.incidentVM3.QuantityAssessmentId].QuantityAssessmentId;
                incident.DurationAssessmentId = DurationAssessments[dialog.incidentVM3.DurationAssessmentId].DurationAssessmentId;
                incident.IncidentId = 4;
                incidentService.CreateIncident(incident);
                dialog.Close();
            }
            ShowAll();
        }
        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            dp_begin.Text = "";
            dp_end.Text = "";
            tb_SR.SelectedIndex = 0;
            tb_Mark_start.SelectedIndex = 0;
            tb_Mark_end.SelectedIndex = 4;
            ShowAll();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid.SelectedItem != null)
            {
                AddIncident dialog = new AddIncident((IncidentViewModel)my_DataGrid.SelectedItem);
                var result = dialog.ShowDialog();
                if (result == true)
                {
                    IIncidentService incidentService = new IncidentService("TestDbConnection");
                    ObservableCollection<RiskObjectViewModel> RiskObjects;
                    ObservableCollection<RiskSourceViewModel> RiskSources;
                    ObservableCollection<UnitViewModel> Units;
                    ObservableCollection<LossTypeViewModel> LossTypes;
                    ObservableCollection<FrequencyAssessmentViewModel> FrequencyAssessments;
                    ObservableCollection<LossAssessmentViewModel> LossAssessments;
                    ObservableCollection<QuantityAssessmentViewModel> QuantityAssessments;
                    ObservableCollection<DurationAssessmentViewModel> DurationAssessments;
                    IRiskObjectService RiskObjectService = new RiskObjectService("TestDbConnection");
                    IRiskSourceService RiskSourceService = new RiskSourceService("TestDbConnection");
                    IUnitService UnitService = new UnitService("TestDbConnection");
                    ILossTypeService LossTypeService = new LossTypeService("TestDbConnection");
                    IFrequencyAssessmentService FrequencyAssessmentService = new FrequencyAssessmentService("TestDbConnection");
                    ILossAssessmentservice LossAssessmentservice = new LossAssessmentservice("TestDbConnection");
                    IQuantityAssessmentService QuantityAssessmentService = new QuantityAssessmentService("TestDbConnection");
                    IDurationAssessmentService DurationAssessmentService = new DurationAssessmentService("TestDbConnection");
                    RiskObjects = RiskObjectService.GetAll();
                    RiskSources = RiskSourceService.GetAll();
                    Units = UnitService.GetAll();
                    LossTypes = LossTypeService.GetAll();
                    FrequencyAssessments = FrequencyAssessmentService.GetAll();
                    LossAssessments = LossAssessmentservice.GetAll();
                    QuantityAssessments = QuantityAssessmentService.GetAll();
                    DurationAssessments = DurationAssessmentService.GetAll();
                    IncidentViewModel incident = (IncidentViewModel)my_DataGrid.SelectedItem;
                    incident.Description = dialog.tb_Description.Text;
                    incident.DirectLossType = Convert.ToDecimal(dialog.tb_DirectLossTypes.Text);
                    incident.DateOfIncident = Convert.ToDateTime(dialog.dp_Date.Text);
                    incident.PotentialLossType = Convert.ToDecimal(dialog.tb_PotentialLossTypes.Text);
                    incident.RiskObjectId = RiskObjects[dialog.cb_OR.SelectedIndex].RiskObjectId;
                    incident.RiskSourceId = RiskSources[dialog.cb_SR.SelectedIndex].RiskSourceId;
                    incident.UnitId = Units[dialog.cb_Unit.SelectedIndex].UnitId;
                    incident.LossTypeId = LossTypes[dialog.cb_LossType.SelectedIndex].LossTypeId;
                    incident.Assessment = Convert.ToInt32(dialog.lb_Mark.Content);
                    incident.Measures = dialog.tb_Measures.Text;
                    incident.Status = dialog.cb_Status.SelectedItem.ToString();
                    incidentService.UpdateIncident(incident);
                    dialog.Close();
                }
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите инцидент для внесения изменений!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (my_DataGrid.SelectedItem != null)
            {
                riskSourceService = new IncidentService("TestDbConnection");
                riskSourceService.DeleteIncident(((IncidentViewModel)my_DataGrid.SelectedItem).IncidentId);
                ShowAll();
            }
            else
            {
                MessageBox.Show("Выберите инцидент для удаления!", "Обратите внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void Sources_Click(object sender, RoutedEventArgs e)
        {
            Sources dialog = new Sources();
            dialog.ShowDialog();
            ShowAll();
        }
        private void Objects_Click(object sender, RoutedEventArgs e)
        {
            Objects dialog = new Objects();
            dialog.ShowDialog();
        }
        private void LossTypes_Click(object sender, RoutedEventArgs e)
        {
            LossTypes dialog = new LossTypes();
            dialog.ShowDialog();
        }
        private void Units_Click(object sender, RoutedEventArgs e)
        {
            Units dialog = new Units();
            dialog.ShowDialog();
        }
        private void FrequencyAssessment_Click(object sender, RoutedEventArgs e)
        {
            M_frequency dialog = new M_frequency();
            dialog.ShowDialog();
        }
        private void LossAssessment_Click(object sender, RoutedEventArgs e)
        {
            M_LossType dialog = new M_LossType();
            dialog.ShowDialog();
        }
        private void QuantityAssessment_Click(object sender, RoutedEventArgs e)
        {
            M_quantity dialog = new M_quantity();
            dialog.ShowDialog();
        }
        private void DurationAssessment_Click(object sender, RoutedEventArgs e)
        {
            M_time dialog = new M_time();
            dialog.ShowDialog();
        }

        private void Filter1_Click(object sender, RoutedEventArgs e)
        {
            decimal sum = 0, sum1=0;
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            var RiskSources1 = from c in riskSources where c.Assessment >= Convert.ToInt32(tb_Mark_start.Text) && c.RiskSourceId == Convert.ToInt32(tb_SR.SelectedItem) select c;
            foreach (var car in RiskSources1) { }
            my_DataGrid.DataContext = RiskSources1;
            foreach (var a in RiskSources1)
            {
                sum += a.DirectLossType;
                sum1 += a.PotentialLossType;
            }
            var culture = new CultureInfo("ru-RU") { NumberFormat = { NumberGroupSeparator = " " }, };
            lb_TotalA.Text = sum.ToString("#0,0.0#", culture);
            lb_TotalQ.Content = sum1.ToString("#0,0.0#", culture);
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            bool true_SR = true;
            bool true_Status = true;
            decimal sum = 0,sum1=0;
            DateTime dt1, dt2;
            int i1, i2, i3;
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            if (dp_begin.Text == "" || DateTime.TryParse(dp_begin.Text, out dt1) == false)
            {
                MessageBox.Show("Значение начальной даты является некорректным! По умолчанию выбрано значение 01.01.2000", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin.Text = "01.01.2000";
            }
            if (dp_end.Text == "" || DateTime.TryParse(dp_end.Text, out dt2) == false)
            {
                MessageBox.Show("Значение конечной даты является некорректным! По умолчанию выбрано значение текущей даты", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_end.Text = DateTime.Today.ToString();
            }
            if (Convert.ToDateTime(dp_begin.Text) > Convert.ToDateTime(dp_end.Text))
            {
                MessageBox.Show("Начальная дата должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin.Text = dp_end.Text;
            }

            if (tb_Mark_start.Text == "" || Int32.TryParse(tb_Mark_start.Text, out i1) == false)
            {
                MessageBox.Show("Значение начальной оценки тяжести является некорректным! По умолчанию выбрано значение 1", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                tb_Mark_start.Text = "1";
            }
            if (tb_Mark_end.Text == "" || Int32.TryParse(tb_Mark_end.Text, out i2) == false)
            {
                MessageBox.Show("Значение конечной оценки тяжести является некорректным! По умолчанию выбрано значение 5", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                tb_Mark_end.Text = "5";
            }
            if (Convert.ToInt32(tb_Mark_start.SelectedItem) > Convert.ToInt32(tb_Mark_end.SelectedItem))
            {
                MessageBox.Show("Начальная оценка тяжести должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                tb_Mark_start.SelectedIndex = tb_Mark_end.SelectedIndex;
            }
            if (tb_SR.SelectedIndex == 0 || Int32.TryParse(tb_SR.Text[0].ToString(), out i3) == false)
            {
                //MessageBox.Show("Значение Id источника риска является некорректным! По умолчанию будет осуществлена фильтрация по всем источнам риска.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                true_SR = false;
                tb_SR.SelectedIndex = 0;
            }
            if (tb_Status.SelectedIndex == 0)
            {
                //MessageBox.Show("Значение Id источника риска является некорректным! По умолчанию будет осуществлена фильтрация по всем источнам риска.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                true_Status = false;
                tb_Status.SelectedIndex = 0;
            }
            if (true_SR)
            {
                if (true_Status) 
                {
                    var RiskSources2 = from c in riskSources
                                       where c.Assessment >= Convert.ToInt32(tb_Mark_start.SelectedItem) 
                                       && c.Assessment <= Convert.ToInt32(tb_Mark_end.SelectedItem) 
                                       && c.DateOfIncident >= Convert.ToDateTime(dp_begin.Text) 
                                       && c.DateOfIncident <= Convert.ToDateTime(dp_end.Text) 
                                       && c.RiskSourceId == Convert.ToInt32(tb_SR.Text[0].ToString())
                                       && c.Status == tb_Status.SelectedItem.ToString() select c;
                    foreach (var car in RiskSources2) { }
                    my_DataGrid.DataContext = RiskSources2;
                    foreach (var a in RiskSources2)
                    {
                        sum += a.DirectLossType;
                        sum1 += a.PotentialLossType;
                    }
                    var culture = new CultureInfo("ru-RU") { NumberFormat = { NumberGroupSeparator = " " }, };
                    lb_TotalA.Text = sum.ToString("#0,0.0#", culture);
                    lb_TotalQ.Content = sum1.ToString("#0,0.0#", culture);
                }
                
                else
                {
                    var RiskSources2 = from c in riskSources
                                       where c.Assessment >= Convert.ToInt32(tb_Mark_start.SelectedItem) 
                                       && c.Assessment <= Convert.ToInt32(tb_Mark_end.SelectedItem) 
                                       && c.DateOfIncident >= Convert.ToDateTime(dp_begin.Text) 
                                       && c.DateOfIncident <= Convert.ToDateTime(dp_end.Text) 
                                       && c.RiskSourceId == Convert.ToInt32(tb_SR.Text[0].ToString()) select c;
                    foreach (var car in RiskSources2) { }
                    my_DataGrid.DataContext = RiskSources2;
                    foreach (var a in RiskSources2)
                    {
                        sum += a.DirectLossType;
                        sum1 += a.PotentialLossType;
                    }
                    var culture = new CultureInfo("ru-RU") { NumberFormat = { NumberGroupSeparator = " " }, };
                    lb_TotalA.Text = sum.ToString("#0,0.0#", culture);
                    lb_TotalQ.Content = sum1.ToString("#0,0.0#", culture);
                }
            }
            else
            {
                if (true_Status) 
                {
                    var RiskSources3 = from c in riskSources
                                       where c.Assessment >= Convert.ToInt32(tb_Mark_start.SelectedItem) 
                                       && c.Assessment <= Convert.ToInt32(tb_Mark_end.SelectedItem) 
                                       && c.DateOfIncident >= Convert.ToDateTime(dp_begin.Text) 
                                       && c.DateOfIncident <= Convert.ToDateTime(dp_end.Text)
                                       && c.Status == tb_Status.SelectedItem.ToString() select c;
                    foreach (var car in RiskSources3) { }
                    my_DataGrid.DataContext = RiskSources3;
                    foreach (var a in RiskSources3)
                    {
                        sum += a.DirectLossType;
                        sum1 += a.PotentialLossType;
                    }
                    var culture = new CultureInfo("ru-RU") { NumberFormat = { NumberGroupSeparator = " " }, };
                    lb_TotalA.Text = sum.ToString("#0,0.0#", culture);
                    lb_TotalQ.Content = sum1.ToString("#0,0.0#", culture);
                }
                
                else {
                    var RiskSources3 = from c in riskSources
                                       where c.Assessment >= Convert.ToInt32(tb_Mark_start.SelectedItem) 
                                       && c.Assessment <= Convert.ToInt32(tb_Mark_end.SelectedItem) 
                                       && c.DateOfIncident >= Convert.ToDateTime(dp_begin.Text) 
                                       && c.DateOfIncident <= Convert.ToDateTime(dp_end.Text) select c;
                    foreach (var car in RiskSources3) { }
                    my_DataGrid.DataContext = RiskSources3;
                    foreach (var a in RiskSources3)
                    {
                        sum += a.DirectLossType;
                        sum1 += a.PotentialLossType;
                    }
                    var culture = new CultureInfo("ru-RU") { NumberFormat = { NumberGroupSeparator = " " }, };
                    lb_TotalA.Text = sum.ToString("#0,0.0#", culture);
                    lb_TotalQ.Content = sum1.ToString("#0,0.0#", culture);
                }
            }
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            About dialog = new About();
            dialog.ShowDialog();
        }
        private void close(object sender, EventArgs e)
        {
            logger.Info("Программа закрыта");
        }
        private void open(object sender, RoutedEventArgs e)
        {
            logger.Info("Программа открыта");
        }
        private void Log_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("C:\\Windows\\System32\\notepad.exe", "Application.log");
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("Help.docx");
        }

        public ChartValues<decimal> abc()
        {
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            var RiskSources3 = from c in riskSources group c by c.RiskSourceId into abc select new { RiskSourceId = abc.Key, total = abc.Sum(x => x.DirectLossType) };
            foreach (var car in RiskSources3) { }
            ChartValues<decimal> bbb = new ChartValues<decimal> { 1, 2 };
            foreach (var s in RiskSources3){}           
            return bbb;
        }

        public void Graph_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<RiskSourceViewModel> RiskSources;
            IRiskSourceService RiskSourceService = new RiskSourceService("TestDbConnection");
            riskSourceService = new IncidentService("TestDbConnection");
            RiskSources = RiskSourceService.GetAll();
            RiskSources = RiskSourceService.GetAll();
            DateTime dt3, dt4;
            if (dp_begin_gr.Text == "" || DateTime.TryParse(dp_begin_gr.Text, out dt3) == false)
            {
                MessageBox.Show("Значение начальной даты является некорректным! По умолчанию выбрано значение 01.01.2000", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = "01.01.2000";
            }
            if (dp_end_gr.Text == "" || DateTime.TryParse(dp_end_gr.Text, out dt4) == false)
            {
                MessageBox.Show("Значение конечной даты является некорректным! По умолчанию выбрано значение текущей даты", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_end_gr.Text = DateTime.Today.ToString();
            }
            if (Convert.ToDateTime(dp_begin_gr.Text) > Convert.ToDateTime(dp_end_gr.Text))
            {
                MessageBox.Show("Начальная дата должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = dp_end_gr.Text;
            }
            else
            {
                var riskSources3 = from c in riskSources where c.DateOfIncident >= Convert.ToDateTime(dp_begin_gr.Text) && c.DateOfIncident <= Convert.ToDateTime(dp_end_gr.Text) group c by c.RiskSourceId into abc select new { RiskSourceId = abc.Key, total = abc.Sum(x => x.DirectLossType), total1 = abc.Sum(x => x.PotentialLossType) };
                ObservableCollection<int> aaa = new ObservableCollection<int> { };
                ChartValues<decimal> bbb = new ChartValues<decimal> { };
                ChartValues<decimal> ddd = new ChartValues<decimal> { };
                List<string> ccc = new List<string> { };
                foreach (var s in riskSources3)
                {
                    foreach (var j in RiskSources)
                    {
                        if (s.RiskSourceId == j.RiskSourceId)
                        {
                            ccc.Add(j.RiskSourceName);
                        }
                    }
                    aaa.Add(s.RiskSourceId);
                    ddd.Add(s.total1);
                    bbb.Add(s.total);
                }
                Graph dialog = new Graph(bbb, ccc, ddd, Convert.ToDateTime(dp_begin_gr.Text), Convert.ToDateTime(dp_end_gr.Text));
                var result = dialog.ShowDialog();
                if (result == true){}
            }
        }

        public void Graph_Click_OR(object sender, RoutedEventArgs e)
        {
            ObservableCollection<RiskObjectViewModel> RiskObjects;
            IRiskObjectService RiskObjectService = new RiskObjectService("TestDbConnection");
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            RiskObjects = RiskObjectService.GetAll();
            DateTime dt3, dt4;
            if (dp_begin_gr.Text == "" || DateTime.TryParse(dp_begin_gr.Text, out dt3) == false)
            {
                MessageBox.Show("Значение начальной даты является некорректным! По умолчанию выбрано значение 01.01.2000", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = "01.01.2000";
            }
            if (dp_end_gr.Text == "" || DateTime.TryParse(dp_end_gr.Text, out dt4) == false)
            {
                MessageBox.Show("Значение конечной даты является некорректным! По умолчанию выбрано значение текущей даты", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_end_gr.Text = DateTime.Today.ToString();
            }
            if (Convert.ToDateTime(dp_begin_gr.Text) > Convert.ToDateTime(dp_end_gr.Text))
            {
                MessageBox.Show("Начальная дата должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = dp_end_gr.Text;
            }
            else
            {
                var RiskObjects3 = from c in riskSources where c.DateOfIncident >= Convert.ToDateTime(dp_begin_gr.Text) && c.DateOfIncident <= Convert.ToDateTime(dp_end_gr.Text) group c by c.RiskObjectId into abc select new { RiskObjectId = abc.Key, total = abc.Sum(x => x.DirectLossType), total1 = abc.Sum(x => x.PotentialLossType) };
                ObservableCollection<int> aaa = new ObservableCollection<int> { };
                ChartValues<decimal> bbb = new ChartValues<decimal> { };
                ChartValues<decimal> ddd = new ChartValues<decimal> { };
                List<string> ccc = new List<string> { };
                foreach (var s in RiskObjects3)
                {
                    foreach (var j in RiskObjects)
                    {
                        if (s.RiskObjectId == j.RiskObjectId)
                        {
                            ccc.Add(j.RiskObjectName);
                        }
                    }
                    aaa.Add(s.RiskObjectId);
                    ddd.Add(s.total1);
                    bbb.Add(s.total);
                }
                Graph_OR dialog = new Graph_OR(bbb, ccc, ddd, Convert.ToDateTime(dp_begin_gr.Text), Convert.ToDateTime(dp_end_gr.Text));
                var result = dialog.ShowDialog();
                if (result == true){ }
            }
        }

        public void Graph_Click_LossType(object sender, RoutedEventArgs e)
        {
            ObservableCollection<LossTypeViewModel> LossTypes;
            ILossTypeService LossTypeService = new LossTypeService("TestDbConnection");
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            LossTypes = LossTypeService.GetAll();
            DateTime dt3, dt4;
            if (dp_begin_gr.Text == "" || DateTime.TryParse(dp_begin_gr.Text, out dt3) == false)
            {
                MessageBox.Show("Значение начальной даты является некорректным! По умолчанию выбрано значение 01.01.2000", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = "01.01.2000";
            }
            if (dp_end_gr.Text == "" || DateTime.TryParse(dp_end_gr.Text, out dt4) == false)
            {
                MessageBox.Show("Значение конечной даты является некорректным! По умолчанию выбрано значение текущей даты", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_end_gr.Text = DateTime.Today.ToString();
            }
            if (Convert.ToDateTime(dp_begin_gr.Text) > Convert.ToDateTime(dp_end_gr.Text))
            {
                MessageBox.Show("Начальная дата должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = dp_end_gr.Text;
            }
            else
            {
                var LossTypes3 = from c in riskSources where c.DateOfIncident >= Convert.ToDateTime(dp_begin_gr.Text) && c.DateOfIncident <= Convert.ToDateTime(dp_end_gr.Text) group c by c.LossTypeId into abc select new { LossTypeId = abc.Key, total = abc.Sum(x => x.DirectLossType), total1 = abc.Sum(x => x.PotentialLossType) };
                ObservableCollection<int> aaa = new ObservableCollection<int> { };
                ChartValues<decimal> bbb = new ChartValues<decimal> { };
                ChartValues<decimal> ddd = new ChartValues<decimal> { };
                List<string> ccc = new List<string> { };
                foreach (var s in LossTypes3)
                {
                    foreach (var j in LossTypes)
                    {
                        if (s.LossTypeId == j.LossTypeId)
                        {
                            ccc.Add(j.LossTypeName);
                        }
                    }
                    aaa.Add(s.LossTypeId);
                    ddd.Add(s.total1);
                    bbb.Add(s.total);
                }
                Graph_Loss dialog = new Graph_Loss(bbb, ccc, ddd, Convert.ToDateTime(dp_begin_gr.Text), Convert.ToDateTime(dp_end_gr.Text));
                var result = dialog.ShowDialog();
                if (result == true){}
            }
        }
        public void Graph_Click_Unit(object sender, RoutedEventArgs e)
        {
            ObservableCollection<UnitViewModel> Units;
            IUnitService UnitService = new UnitService("TestDbConnection");
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            Units = UnitService.GetAll();
            DateTime dt3, dt4;
            if (dp_begin_gr.Text == "" || DateTime.TryParse(dp_begin_gr.Text, out dt3) == false)
            {
                MessageBox.Show("Значение начальной даты является некорректным! По умолчанию выбрано значение 01.01.2000", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = "01.01.2000";
            }
            if (dp_end_gr.Text == "" || DateTime.TryParse(dp_end_gr.Text, out dt4) == false)
            {
                MessageBox.Show("Значение конечной даты является некорректным! По умолчанию выбрано значение текущей даты", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_end_gr.Text = DateTime.Today.ToString();
            }
            if (Convert.ToDateTime(dp_begin_gr.Text) > Convert.ToDateTime(dp_end_gr.Text))
            {
                MessageBox.Show("Начальная дата должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = dp_end_gr.Text;
            }
            else
            {
                var Units3 = from c in riskSources where c.DateOfIncident >= Convert.ToDateTime(dp_begin_gr.Text) && c.DateOfIncident <= Convert.ToDateTime(dp_end_gr.Text) group c by c.UnitId into abc select new { UnitId = abc.Key, total = abc.Sum(x => x.DirectLossType), total1 = abc.Sum(x => x.PotentialLossType) };
                ObservableCollection<int> aaa = new ObservableCollection<int> { };
                ChartValues<decimal> bbb = new ChartValues<decimal> { };
                ChartValues<decimal> ddd = new ChartValues<decimal> { };
                List<string> ccc = new List<string> { };
                foreach (var s in Units3)
                {
                    foreach (var j in Units)
                    {
                        if (s.UnitId == j.UnitId)
                        {
                            ccc.Add(j.UnitName);
                        }
                    }
                    aaa.Add(s.UnitId);
                    ddd.Add(s.total1);
                    bbb.Add(s.total);
                }
                Graph_Unit dialog = new Graph_Unit(bbb, ccc, ddd, Convert.ToDateTime(dp_begin_gr.Text), Convert.ToDateTime(dp_end_gr.Text));
                var result = dialog.ShowDialog();
                if (result == true){}
            }
        }

        public void Chart_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<RiskObjectViewModel> RiskObjects;
            IRiskObjectService RiskObjectService = new RiskObjectService("TestDbConnection");
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            RiskObjects = RiskObjectService.GetAll();
            DateTime dt3, dt4;
            if (dp_begin_gr.Text == "" || DateTime.TryParse(dp_begin_gr.Text, out dt3) == false)
            {
                MessageBox.Show("Значение начальной даты является некорректным! По умолчанию выбрано значение 01.01.2000", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = "01.01.2000";
            }
            if (dp_end_gr.Text == "" || DateTime.TryParse(dp_end_gr.Text, out dt4) == false)
            {
                MessageBox.Show("Значение конечной даты является некорректным! По умолчанию выбрано значение текущей даты", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_end_gr.Text = DateTime.Today.ToString();
            }
            if (Convert.ToDateTime(dp_begin_gr.Text) > Convert.ToDateTime(dp_end_gr.Text))
            {
                MessageBox.Show("Начальная дата должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = dp_end_gr.Text;
            }
            else
            {
                var RiskObjects3 = from c in riskSources where c.DateOfIncident >= Convert.ToDateTime(dp_begin_gr.Text) && c.DateOfIncident <= Convert.ToDateTime(dp_end_gr.Text) group c by c.RiskObjectId into abc select new { RiskObjectId = abc.Key, total = abc.Count() };
                ObservableCollection<int> aaa = new ObservableCollection<int> { };
                ChartValues<decimal> bbb = new ChartValues<decimal> { };
                ChartValues<decimal> ddd = new ChartValues<decimal> { };
                List<string> ccc = new List<string> { };
                foreach (var s in RiskObjects3)
                {
                    foreach (var j in RiskObjects)
                    {
                        if (s.RiskObjectId == j.RiskObjectId)
                        {
                            ccc.Add(j.RiskObjectName);
                        }
                    }
                    aaa.Add(s.RiskObjectId);
                    bbb.Add(s.total);
                }

                Chart dialog = new Chart(bbb, ccc, Convert.ToDateTime(dp_begin_gr.Text), Convert.ToDateTime(dp_end_gr.Text));
                var result = dialog.ShowDialog();
                if (result == true){}
            }
        }

        public void Chart_SR_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<RiskSourceViewModel> RiskSources;
            IRiskSourceService RiskSourceService = new RiskSourceService("TestDbConnection");
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            RiskSources = RiskSourceService.GetAll();
            DateTime dt3, dt4;
            if (dp_begin_gr.Text == "" || DateTime.TryParse(dp_begin_gr.Text, out dt3) == false)
            {
                MessageBox.Show("Значение начальной даты является некорректным! По умолчанию выбрано значение 01.01.2000", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = "01.01.2000";
            }
            if (dp_end_gr.Text == "" || DateTime.TryParse(dp_end_gr.Text, out dt4) == false)
            {
                MessageBox.Show("Значение конечной даты является некорректным! По умолчанию выбрано значение текущей даты", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_end_gr.Text = DateTime.Today.ToString();
            }
            if (Convert.ToDateTime(dp_begin_gr.Text) > Convert.ToDateTime(dp_end_gr.Text))
            {
                MessageBox.Show("Начальная дата должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = dp_end_gr.Text;
            }
            else
            {
                var RiskObjects3 = from c in riskSources where c.DateOfIncident >= Convert.ToDateTime(dp_begin_gr.Text) && c.DateOfIncident <= Convert.ToDateTime(dp_end_gr.Text) group c by c.RiskSourceId into abc select new { RiskSourceId = abc.Key, total = abc.Count() };
                ObservableCollection<int> aaa = new ObservableCollection<int> { };
                ChartValues<decimal> bbb = new ChartValues<decimal> { };
                ChartValues<decimal> ddd = new ChartValues<decimal> { };
                List<string> ccc = new List<string> { };
                foreach (var s in RiskObjects3)
                {
                    foreach (var j in RiskSources)
                    {
                        if (s.RiskSourceId == j.RiskSourceId)
                        {
                            ccc.Add(j.RiskSourceName);
                        }
                    }
                    aaa.Add(s.RiskSourceId);
                    bbb.Add(s.total);
                }

                Chart_SR dialog = new Chart_SR(bbb, ccc, Convert.ToDateTime(dp_begin_gr.Text), Convert.ToDateTime(dp_end_gr.Text));
                var result = dialog.ShowDialog();
                if (result == true){}
            }
        }

        public void Chart_LossType_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<LossTypeViewModel> LossTypes;
            ILossTypeService LossTypeService = new LossTypeService("TestDbConnection");
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            LossTypes = LossTypeService.GetAll();
            DateTime dt3, dt4;
            if (dp_begin_gr.Text == "" || DateTime.TryParse(dp_begin_gr.Text, out dt3) == false)
            {
                MessageBox.Show("Значение начальной даты является некорректным! По умолчанию выбрано значение 01.01.2000", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = "01.01.2000";
            }
            if (dp_end_gr.Text == "" || DateTime.TryParse(dp_end_gr.Text, out dt4) == false)
            {
                MessageBox.Show("Значение конечной даты является некорректным! По умолчанию выбрано значение текущей даты", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_end_gr.Text = DateTime.Today.ToString();
            }
            if (Convert.ToDateTime(dp_begin_gr.Text) > Convert.ToDateTime(dp_end_gr.Text))
            {
                MessageBox.Show("Начальная дата должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = dp_end_gr.Text;
            }
            else
            {
                var LossTypes3 = from c in riskSources where c.DateOfIncident >= Convert.ToDateTime(dp_begin_gr.Text) && c.DateOfIncident <= Convert.ToDateTime(dp_end_gr.Text) group c by c.LossTypeId into abc select new { LossTypeId = abc.Key, total = abc.Count() };
                ObservableCollection<int> aaa = new ObservableCollection<int> { };
                ChartValues<decimal> bbb = new ChartValues<decimal> { };
                ChartValues<decimal> ddd = new ChartValues<decimal> { };
                List<string> ccc = new List<string> { };
                foreach (var s in LossTypes3)
                {
                    foreach (var j in LossTypes)
                    {
                        if (s.LossTypeId == j.LossTypeId)
                        {
                            ccc.Add(j.LossTypeName);
                        }
                    }
                    aaa.Add(s.LossTypeId);
                    bbb.Add(s.total);
                }
                Chart_LossType dialog = new Chart_LossType(bbb, ccc, Convert.ToDateTime(dp_begin_gr.Text), Convert.ToDateTime(dp_end_gr.Text));
                var result = dialog.ShowDialog();
                if (result == true){ }
            }
        }

        public void Chart_Unit_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<UnitViewModel> Units;
            IUnitService UnitService = new UnitService("TestDbConnection");
            riskSourceService = new IncidentService("TestDbConnection");
            riskSources = riskSourceService.GetAll();
            Units = UnitService.GetAll();
            DateTime dt3, dt4;
            if (dp_begin_gr.Text == "" || DateTime.TryParse(dp_begin_gr.Text, out dt3) == false)
            {
                MessageBox.Show("Значение начальной даты является некорректным! По умолчанию выбрано значение 01.01.2000", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = "01.01.2000";
            }
            if (dp_end_gr.Text == "" || DateTime.TryParse(dp_end_gr.Text, out dt4) == false)
            {
                MessageBox.Show("Значение конечной даты является некорректным! По умолчанию выбрано значение текущей даты", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_end_gr.Text = DateTime.Today.ToString();
            }
            if (Convert.ToDateTime(dp_begin_gr.Text) > Convert.ToDateTime(dp_end_gr.Text))
            {
                MessageBox.Show("Начальная дата должна быть больше либо равна конечной!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                dp_begin_gr.Text = dp_end_gr.Text;
            }
            else
            {
                var Units3 = from c in riskSources where c.DateOfIncident >= Convert.ToDateTime(dp_begin_gr.Text) && c.DateOfIncident <= Convert.ToDateTime(dp_end_gr.Text) group c by c.UnitId into abc select new { UnitId = abc.Key, total = abc.Count() };
                ObservableCollection<int> aaa = new ObservableCollection<int> { };
                ChartValues<decimal> bbb = new ChartValues<decimal> { };
                ChartValues<decimal> ddd = new ChartValues<decimal> { };
                List<string> ccc = new List<string> { };
                foreach (var s in Units3)
                {
                    foreach (var j in Units)
                    {
                        if (s.UnitId == j.UnitId)
                        {
                            ccc.Add(j.UnitName);
                        }
                    }
                    aaa.Add(s.UnitId);
                    bbb.Add(s.total);
                }
                Chart_Unit dialog = new Chart_Unit(bbb, ccc, Convert.ToDateTime(dp_begin_gr.Text), Convert.ToDateTime(dp_end_gr.Text));
                var result = dialog.ShowDialog();
                if (result == true){}
            }
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFD = new SaveFileDialog();
            SaveFD.InitialDirectory = "C:\\";
            SaveFD.Filter = "Книга Excel (*.xls)|*.xls|All files (*.*)|*.*";
            SaveFD.OverwritePrompt = true;
            SaveFD.Title = "Сохранить в файл";
            SaveFD.FileName = "Операционные инциденты";
            SaveFD.FileOk += SaveFD_FileOk;
            SaveFD.ShowDialog();
            if (string.IsNullOrEmpty(SaveFD.FileName) == false)
            {               
                my_DataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                my_DataGrid.SelectAllCells();
                ApplicationCommands.Copy.Execute(null, my_DataGrid);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(SaveFD.FileName, false, Encoding.UTF32);
                file1.WriteLine(result.Replace(',', ','));
                file1.Close();
            }
            ShowAll();
        }
        private void SaveFD_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.MessageBox.Show("Список операционных инцидентов успешно сохранен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void my_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tb_Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
