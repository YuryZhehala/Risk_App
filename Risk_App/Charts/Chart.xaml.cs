using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms;
using System.IO;
using LiveCharts.Defaults;

namespace Risk_App
{
    public partial class Chart : Window
    {
        public Chart()
        {
            InitializeComponent();
        }
        public Chart(ChartValues<decimal> bbb, List<string> ccc, DateTime dp_begin_gr, DateTime dp_end_gr) :this ()
        {
            this.bbb = bbb;
            this.ccc = ccc;
            int j = 0;
            SeriesCollection = new SeriesCollection { };
            foreach (var i in bbb)
            {
                SeriesCollection.Add(new PieSeries
                {
                    Title = ccc[j],
                    Values = new ChartValues<ObservableValue> { new ObservableValue((double)bbb[j]) },
                    DataLabels = true,
                    FontSize = 20,
                    LabelPoint = chartPoint =>
                  string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation)
                });
                j++;
            }
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation.ToString());
            gr_label.Text = "Структура операционных инцидентов в разрезе объектов риска с " + dp_begin_gr.ToString("dd.MM.yyyy") + " по " + dp_end_gr.ToString("dd.MM.yyyy");
            filename = "Структура инцидентов в разрезе объектов риска с " + dp_begin_gr.ToString("dd.MM.yyyy") + " по " + dp_end_gr.ToString("dd.MM.yyyy");
            DataContext = this;
        }
        public Func<ChartPoint, string> PointLabel { get; set; }
        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;
            int i = 0;
            foreach (PieSeries series in chart.Series)           
                series.PushOut = 0;
            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 15;          
        }
        string filename;
        public List<string> Labels { get; set; }
        public ChartValues<decimal> bbb = new ChartValues<decimal> { };
        public ChartValues<decimal> ddd = new ChartValues<decimal> { };
        public ObservableCollection<int> aaa = new ObservableCollection<int> { };
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels1 { get; set; }
        public Func<double, string> Formatter { get; set; }
        public List<string> ccc = new List<string> { };
        public void Add_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFD = new SaveFileDialog();
            SaveFD.InitialDirectory = "E:\\";
            SaveFD.Filter = "Книга Excel (*.png)|*.png|All files (*.*)|*.*";
            SaveFD.OverwritePrompt = true;
            SaveFD.Title = "Сохранить в файл";
            SaveFD.FileName = filename;
            SaveFD.FileOk += SaveFD_FileOk;
            SaveFD.ShowDialog();
            if (string.IsNullOrEmpty(SaveFD.FileName) == false)
            {
                SaveToPng(mygrid, SaveFD.FileName);
            }
        }

        private void SaveFD_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.MessageBox.Show("Диаграмма успешно сохранена!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            EncodeVisual(visual, fileName, encoder);
        }

        private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 80, 80, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName)) encoder.Save(stream);
        }
    }
}
