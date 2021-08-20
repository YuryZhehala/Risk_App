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

namespace Risk_App
{
    public partial class Graph_OR : Window
    {
        public Graph_OR() { InitializeComponent(); }
        public Graph_OR(ChartValues<decimal> bbb, List<string> ccc, ChartValues<decimal> ddd, DateTime dp_begin_gr, DateTime dp_end_gr) : this()
        {
            this.bbb = bbb;
            this.ccc = ccc;
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Прямые потери",
                    Values = bbb,
                    MaxColumnWidth = 50
                }
            };
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Потенциальные потери",
                MaxColumnWidth = 50,
                Values = ddd
            });

            Labels = this.ccc;
            Formatter = value => value.ToString("N");
            gr_label.Text = "Структура прямых и потенциальных потерь от операционных инцидентов в разрезе объектов риска с " + dp_begin_gr.ToString("dd.MM.yyyy") + " по " + dp_end_gr.ToString("dd.MM.yyyy");
            filename = "Структура потерь в разрезе объектов риска с " + dp_begin_gr.ToString("dd.MM.yyyy") + " по " + dp_end_gr.ToString("dd.MM.yyyy");
            DataContext = this;
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
            System.Windows.MessageBox.Show("График успешно сохранен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
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