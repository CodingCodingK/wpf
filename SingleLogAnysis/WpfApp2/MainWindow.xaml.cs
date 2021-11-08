using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> selectLogsList = new List<string>();

        public int resultTIMES = 0;
        public int resultMS = 0;
        public int errorTIMES = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        public static string Search_string(string s, string s1, string s2)
        {
            int n1, n2;
            n1 = s.IndexOf(s1, 0) + s1.Length;
            n2 = s.IndexOf(s2, n1);
            return s.Substring(n1, n2 - n1);
        }

        private async Task ButtonBase_OnClickAsync()
        {
            var path = PathBox.Text;
            var keyword = KeywordBox.Text;
            var pathAP1 = path + "\\ap1";
            var pathAP2 = path + "\\ap2";

            resultTIMES = 0;
            resultMS = 0;

            var files = Directory.GetFiles(path, "*.log");
            if (files.Length > 0)
            {
                await analysis(path, keyword);
            }
            else
            {
                await analysis(pathAP1, keyword);
                await analysis(pathAP2, keyword);
            }

            Console.WriteLine(resultTIMES);
            Console.WriteLine(resultMS);
            Console.WriteLine(errorTIMES);
            TimesBox.Text = resultTIMES.ToString();
            TimingBox.Text = resultMS.ToString();

            OutputSelectedLogs(path,keyword,"TEST",selectLogsList);
        }

        private async Task analysis(string path,string keyword)
        {
            var files = Directory.GetFiles(path, "*.log");
            foreach (var file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(keyword) && line.Contains("■ REST API Server ■"))
                        {
                            selectLogsList.Add(line);

                            if (line.Contains("END"))
                            {
                                var minTimingString = "07:00:00";
                                var minTiming = Convert.ToDateTime(minTimingString);
                                var maxTimingString = "20:00:00";
                                var maxTiming = Convert.ToDateTime(maxTimingString);
                                var timingString = line.Substring(11, 8);
                                var timing = Convert.ToDateTime(timingString);
                                if (timing < maxTiming && timing > minTiming)
                                {
                                    var ms = Convert.ToInt16(Search_string(line, "Duration=[", "ms]"));
                                    if (ms < 1) errorTIMES++;
                                    resultMS = resultMS + ms;
                                    resultTIMES++;
                                }
                            }
                        }
                    }
                }
            }

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            ButtonBase_OnClickAsync();
        }

        private void OutputSelectedLogs(string path,string keyword,string index,List<string> logs)
        {
            using (StreamWriter sw = new StreamWriter(path + "\\" + keyword + index +".txt"))
            {
                foreach (var log in logs)
                {
                    sw.WriteLine(log);
                }
            }
            selectLogsList.Clear();
        }

    }

}
