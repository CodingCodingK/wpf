using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using wApp;

namespace progressbar
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public const int max = 100;
		public int val = 1;


		public MainWindow()
		{
			InitializeComponent();
			Download();
		}

		public async void Download()
		{
			while (val < max)
			{
				var progress = await UpdateProgress();
				TaskbarManager.SetProgressValue(progress, max);
			}
			
		}

		private Task<int> UpdateProgress()
		{
			return Task.Run<int>(() => { return GetProgressVal(); });
		}

		private int GetProgressVal()
		{
			Task.Delay(1000).Wait();
			val++;
			Console.WriteLine($"当前线程Id为：{Thread.CurrentThread.ManagedThreadId}");
			return val;
		}








		//private void trackBar_ValueChanged(object sender, EventArgs e)
		//{
		//	TaskbarManager.SetProgressValue(trackBar.Value, trackBar.Maximum);
		//}

		//private void btnNoProgress_Click(object sender, EventArgs e)
		//{
		//	TaskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
		//}

		//private void btnIndeterminate_Click(object sender, EventArgs e)
		//{
		//	TaskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate);
		//}

		//private void btnNormal_Click(object sender, EventArgs e)
		//{
		//	TaskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
		//	TaskbarManager.SetProgressValue(trackBar.Value, trackBar.Maximum);
		//}

		//private void btn_Click(object sender, EventArgs e)
		//{
		//	TaskbarManager.SetProgressState(TaskbarProgressBarState.Error);
		//	TaskbarManager.SetProgressValue(trackBar.Value, trackBar.Maximum);
		//}

		//private void btnPaused_Click(object sender, EventArgs e)
		//{
		//	TaskbarManager.SetProgressState(TaskbarProgressBarState.Paused);
		//	TaskbarManager.SetProgressValue(trackBar.Value, trackBar.Maximum);
		//}
	}
}
