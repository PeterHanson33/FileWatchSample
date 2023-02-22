using System;
using System.IO;

namespace WpfApp1
{
    public partial class MainWindow
    {
        private readonly FileSystemWatcher _watcher;

        public MainWindow()
        {
            InitializeComponent();

            var filePath = "D:/file.txt";

            string directoryName = Path.GetDirectoryName(filePath);
            
            _watcher = new FileSystemWatcher
            {
                Path = directoryName!,
                Filter = Path.GetFileName(filePath)!,
                NotifyFilter = NotifyFilters.Attributes
                               | NotifyFilters.CreationTime
                               | NotifyFilters.FileName
                               | NotifyFilters.LastAccess
                               | NotifyFilters.LastWrite
                               | NotifyFilters.Security
                               | NotifyFilters.Size
            };
            _watcher.Error += WatcherOnError;
            _watcher.Changed += OnWatcherOnChanged;
            _watcher.EnableRaisingEvents = true;
        }

        private void OnWatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            Box.Dispatcher.Invoke(() =>
            {
                Box.Text = DateTime.Now.ToString("HH:mm:ss.fff") + "-" + e.ChangeType + "-" + e.Name + "-" +
                           e.ChangeType + Environment.NewLine + Box.Text;
            });
        }

        private void WatcherOnError(object sender, ErrorEventArgs e)
        {
            Box.Dispatcher.Invoke(() =>
            {
                Box.Text = DateTime.Now.ToString("HH:mm:ss.fff") + "ERROR" + "-" + e.GetException() + Box.Text;
            });
        }
    }
}