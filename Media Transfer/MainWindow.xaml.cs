using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using WPF = System.Windows;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Media_Transfer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sourceFolder;
        string targetFolder;
        string separator;
        string[] photoFormats;
        string[] videoFormat;
        bool photosMove;
        bool videoMove;
        bool allFiles;
        bool reWriteFiles;
        bool subFolders;
        string finishDate;

        public MainWindow()
        {
            InitializeComponent();
            photosMove = false;
            videoMove = false;
            allFiles = false;
            subFolders = false;
            txbx_separator.MaxLength = 1;
            txbx_separator.MaxLines = 1;
            separator = txbx_separator.Text;
            chbx_reWriteFiles.IsChecked = false;
            finishDate = "";

            #region Инициализация форматов
            photoFormats = new string[]
            {
                ".jpg", ".jpeg", ".nef"
            };  
            //, ".bmp", ".tiff", ".gif",  ".png", ".ico", ".wmp"

            videoFormat = new string[]
            {
                ".avi", ".mov", ".mp4", ".3gp", ".flv", ".mpeg", ".wmv", ".qt"
            };
            #endregion
        }
        private string FolderSelect()
        {
            string _str = null;
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select folder or drive";
                fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
                fbd.ShowNewFolderButton = true;
                fbd.ShowDialog();
                _str = fbd.SelectedPath;
            }
            return _str;
        }
        private void btn_SourceFolder_Click(object sender, RoutedEventArgs e)
        {
            txbx_SourceFolder.Text = sourceFolder = FolderSelect();
        }
        private void btn_TargetFolder_Click(object sender, RoutedEventArgs e)
        {
            txbx_TargetFolder.Text = targetFolder = FolderSelect();
        }
        private async void btn_StartTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(sourceFolder))
            {
                WPF.MessageBox.Show("Source folder not found!", "Information", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (!Directory.Exists(targetFolder))
            {
                WPF.MessageBox.Show("Target folder not found!", "Information", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (!allFiles & !photosMove & !videoMove)
            {
                WPF.MessageBox.Show("You must check files extension before start!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            btn_StartTransfer.IsEnabled = false;
            progBar.IsIndeterminate = true;

            //folderClear(targetFolder);

            await Task.Factory.StartNew(() => FilesMove(new DirectoryInfo(sourceFolder)));

            progBar.IsIndeterminate = false;
            btn_StartTransfer.IsEnabled = true;
        }
        private void FilesMove(DirectoryInfo di)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                FileInfo[] fi = di.GetFiles("*", (subFolders) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                
                string currentFormat;
                int i = 0;

                foreach (var _file in fi)
                {
                    currentFormat = "any";

                    if (!allFiles)
                        if (!FormatChecker(_file.Extension, out currentFormat))
                            continue;

                    this.Dispatcher.Invoke(new Action(() => DateChecker(currentFormat, _file, cmbx_DateFormat.SelectedIndex)));


                    if (!Directory.Exists(targetFolder + "\\" + finishDate))
                        Directory.CreateDirectory(targetFolder + "\\" + finishDate);
                    _file.CopyTo(String.Format("{0}\\{1}\\{2}", targetFolder, finishDate, _file.Name), reWriteFiles);

                    i++;
                }
                
                sw.Stop();
                WPF.MessageBox.Show(String.Format("Total processed files - {0}.\nTotal transfer time - {1}sec.", i.ToString(), sw.Elapsed.Seconds.ToString()),
                    "Complete!", WPF.MessageBoxButton.OK, WPF.MessageBoxImage.Information);
            }

            catch (IOException ex) { WPF.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }//return false; }
            catch (Exception ex) { WPF.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }//return false; }
        }
        private void DateChecker(string _currentFormat, FileInfo _file, int index)
        {
            ReadExifInfo rexi;

            if (_currentFormat == "photo")
            {
                rexi = new ReadExifInfo(_file.FullName, _file);

                if ((rexi.CreateTime > Convert.ToDateTime("01.01.1900")) && (_file.CreationTime > rexi.CreateTime))
                    finishDate = DateFormatBuilder(rexi.CreateTime.Day.ToString(), rexi.CreateTime.Month.ToString(), rexi.CreateTime.Year.ToString(), index);
                else
                    finishDate = DateFormatBuilder(_file.CreationTime.Day.ToString(), _file.CreationTime.Month.ToString(), _file.CreationTime.Year.ToString(), index);
            }
            else if (_currentFormat == "video")
            {
                if (_file.CreationTime > _file.LastWriteTime)
                    finishDate = DateFormatBuilder(_file.LastWriteTime.Day.ToString(), _file.LastWriteTime.Month.ToString(), _file.LastWriteTime.Year.ToString(), index);
                else
                    finishDate = DateFormatBuilder(_file.CreationTime.Day.ToString(), _file.CreationTime.Month.ToString(), _file.CreationTime.Year.ToString(), index);
            }
            else
            {
                finishDate = DateFormatBuilder(_file.CreationTime.Day.ToString(), _file.CreationTime.Month.ToString(), _file.CreationTime.Year.ToString(), index);
            }
        }
        private bool FormatChecker(string format, out string currentFormat)
        {
            foreach (string _format in photoFormats)
            {
                if (_format.Equals(format, StringComparison.OrdinalIgnoreCase))
                {
                    currentFormat = "photo";
                    return true;
                }
            }
            foreach (string _format in videoFormat)
            {
                if (_format.Equals(format, StringComparison.OrdinalIgnoreCase))
                {
                    currentFormat = "video";
                    return true;
                }
            }
            currentFormat = "any";
            return false;
        }
        private string DateFormatBuilder(string day, string month, string year, int index)
        {
            day = day.PadLeft(2, '0');
            month = month.PadLeft(2, '0');
            year = year.PadLeft(2, '0');

            switch (index)
            {
                case 1: return String.Format("{0}{1}{2}{3}{4}", month, separator, day, separator, year);
                case 2: return String.Format("{0}{1}{2}{3}{4}", year, separator, month, separator, day);
                default: return String.Format("{0}{1}{2}{3}{4}", day, separator, month, separator, year);
            }
            
        }
        private void chbx_FormatAllFiles_Checked(object sender, RoutedEventArgs e)
        {
            chbx_FormatImages.IsEnabled = false;
            chbx_FormatImages.IsChecked = false;
            chbx_FormatVideo.IsEnabled = false;
            chbx_FormatVideo.IsChecked = false;
            allFiles = true;
        }
        private void chbx_FormatAllFiles_Unchecked(object sender, RoutedEventArgs e)
        {
            chbx_FormatImages.IsEnabled = true;
            chbx_FormatVideo.IsEnabled = true;
            allFiles = false;
        }
        private void chbx_FormatImages_Checked(object sender, RoutedEventArgs e)
        {
            photosMove = true;
        }
        private void chbx_FormatImages_Unchecked(object sender, RoutedEventArgs e)
        {
            photosMove = false;
        }
        private void chbx_FormatVideo_Checked(object sender, RoutedEventArgs e)
        {
            videoMove = true;
        }
        private void chbx_FormatVideo_Unchecked(object sender, RoutedEventArgs e)
        {
            videoMove = false;
        }
        private void txbx_SourceFolder_TextChanged(object sender, TextChangedEventArgs e)
        {
            sourceFolder = txbx_SourceFolder.Text;
        }
        private void txbx_TargetFolder_TextChanged(object sender, TextChangedEventArgs e)
        {
            targetFolder = txbx_TargetFolder.Text;
        }
        private void txbx_separator_TextChanged(object sender, TextChangedEventArgs e)
        {
            string path = @"c:\" + txbx_separator.Text;

            try
            {
                if (!((txbx_separator.Text == " ") || (txbx_separator.Text == "")))
                {
                    Directory.CreateDirectory(path);
                    Directory.Delete(path);
                }
                separator = txbx_separator.Text;
            }
            catch (Exception)
            {
                WPF.MessageBox.Show("Incorrect char!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                separator = txbx_separator.Text = "_";
            }
        }
        private void chbx_reWriteFiles_Checked(object sender, RoutedEventArgs e)
        {
            reWriteFiles = true;
        }
        private void chbx_reWriteFiles_Unchecked(object sender, RoutedEventArgs e)
        {
            reWriteFiles = false;
        }
        private void chbx_subFolders_Checked(object sender, RoutedEventArgs e)
        {
            subFolders = true;
        }
        private void chbx_subFolders_Unchecked(object sender, RoutedEventArgs e)
        {
            subFolders = false;
        }

        //private void folderClear(string folderPath)
        //{
        //    foreach (var qwe in Directory.GetDirectories(folderPath))
        //        Directory.Delete(qwe, true);
        //    foreach (var qwe in Directory.GetFiles(folderPath))
        //        File.Delete(qwe);
        //}
    }
    class ReadExifInfo
    {    //для чтения EXIF информации из файла
        private DateTime creationTime;
        private FileStream foto;
        private BitmapMetadata bm;

        public ReadExifInfo(string fileName, FileInfo file)
        {
            try
            {
                using (foto = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    JpegBitmapDecoder jpegdecoder;
                    PngBitmapDecoder pngdecoder;
                    BmpBitmapDecoder bmpdecoder;
                    GifBitmapDecoder gifdecoder;
                    IconBitmapDecoder icondecoder;
                    TiffBitmapDecoder tiffdecoder;
                    WmpBitmapDecoder wmpdecoder;
                        
                    switch(file.Extension.ToLower())
                    {
                        case ".jpg":
                            jpegdecoder = new JpegBitmapDecoder(foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                            bm = (BitmapMetadata)jpegdecoder.Frames[0].Metadata.Clone();
                            break;
                        case ".jpeg":
                            jpegdecoder = new JpegBitmapDecoder(foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                            bm = (BitmapMetadata)jpegdecoder.Frames[0].Metadata.Clone();
                            break;
                        case ".png":
                            pngdecoder = new PngBitmapDecoder(foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                            bm = (BitmapMetadata)pngdecoder.Frames[0].Metadata.Clone();
                            break;
                        case ".bmp":
                            bmpdecoder = new BmpBitmapDecoder(foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                            bm = (BitmapMetadata)bmpdecoder.Frames[0].Metadata.Clone();
                            break;
                        case ".gif":
                            gifdecoder = new GifBitmapDecoder(foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                            bm = (BitmapMetadata)gifdecoder.Frames[0].Metadata.Clone();
                            break;
                        case ".ico":
                            icondecoder = new IconBitmapDecoder(foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                            bm = (BitmapMetadata)icondecoder.Frames[0].Metadata.Clone();
                            break;
                        case ".tiff":
                            tiffdecoder = new TiffBitmapDecoder(foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                            bm = (BitmapMetadata)tiffdecoder.Frames[0].Metadata.Clone();
                            break;
                        case ".wmp":
                            wmpdecoder = new WmpBitmapDecoder(foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                            bm = (BitmapMetadata)wmpdecoder.Frames[0].Metadata.Clone();
                            break;
                    }
                    creationTime = Convert.ToDateTime(bm.DateTaken);
                }
            }
            catch (Exception ex) { WPF.MessageBox.Show(fileName + "\n" + ex.Message, "Decoder Exception"); }
        }
        public DateTime CreateTime
        {
            get { return creationTime; }
        }
    }
}
