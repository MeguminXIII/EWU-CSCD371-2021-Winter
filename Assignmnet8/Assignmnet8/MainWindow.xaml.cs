using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;


namespace Assignmnet8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _DispatcherTimer = new();
        private DateTime _TimeAtStart = DateTime.Now;
        private int Loop = 1;
        private string _Details;
        private bool _StartStop = true;

        public MainWindow()
        {
            InitializeComponent();

            _DispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            _DispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimerBlock.Text = (DateTime.Now - _TimeAtStart).ToString(@"hh\:mm\:ss");
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if(_StartStop == true)
            {
                _StartStop = false;
                StartButton.Content = "Stop";
                _TimeAtStart = DateTime.Now;
                _DispatcherTimer.Start();
            }
            else
            {
                _DispatcherTimer.Stop();
                _StartStop = true;
                StartButton.Content = "Start";
                DetailsBlock.Text = "Loop " + Loop + " " + TimerBlock.Text;
                SaveBox.Items.Add($"{_Details}\t\tEnd of a Run");
            }
        }

        private void DetailsBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Details = DetailsBlock.Text;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_StartStop && TimerBlock.Text != "00:00:00")
            {
                Loop++;
                DetailsBlock.Text = "";
                SaveBox.Items.Add($"Time: {TimerBlock.Text}\t{_Details}");
                TimerBlock.Text = "00:00:00";
            }
        }

        private void SaveBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                SaveBox.Items.Remove(SaveBox.SelectedItem);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
               foreach(var i in SaveBox.Items)
                {
                    sb.AppendLine(i.ToString());
                }
            }
                File.WriteAllText(saveFileDialog.FileName, sb.ToString());
        }

        private void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "";
            OpenFileDialog loadFile = new();
            if(loadFile.ShowDialog() == true)
            {
                fileName = loadFile.FileName;
                var txtLines = File.ReadAllLines(fileName);
                foreach (string s in txtLines)
                    SaveBox.Items.Add(s);
            }
           
           

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SaveBox.Items.Clear();
        }
    }
}
