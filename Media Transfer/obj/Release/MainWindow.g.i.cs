﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "614249976D70806D806B25C3F27C78C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Media_Transfer {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_SourceFolder;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_SourceFolder;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_TargetFolder;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_TargetFolder;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_StartTransfer;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbx_FormatImages;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbx_FormatVideo;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbx_DateFormat;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbx_separator;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progBar;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbx_reWriteFiles;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbx_subFolders;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Media Transfer;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txbx_SourceFolder = ((System.Windows.Controls.TextBox)(target));
            
            #line 8 "..\..\MainWindow.xaml"
            this.txbx_SourceFolder.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbx_SourceFolder_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_SourceFolder = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\MainWindow.xaml"
            this.btn_SourceFolder.Click += new System.Windows.RoutedEventHandler(this.btn_SourceFolder_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txbx_TargetFolder = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\MainWindow.xaml"
            this.txbx_TargetFolder.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbx_TargetFolder_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_TargetFolder = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\MainWindow.xaml"
            this.btn_TargetFolder.Click += new System.Windows.RoutedEventHandler(this.btn_TargetFolder_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_StartTransfer = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\MainWindow.xaml"
            this.btn_StartTransfer.Click += new System.Windows.RoutedEventHandler(this.btn_StartTransfer_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.chbx_FormatImages = ((System.Windows.Controls.CheckBox)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.chbx_FormatImages.Checked += new System.Windows.RoutedEventHandler(this.chbx_FormatImages_Checked);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.chbx_FormatImages.Unchecked += new System.Windows.RoutedEventHandler(this.chbx_FormatImages_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.chbx_FormatVideo = ((System.Windows.Controls.CheckBox)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.chbx_FormatVideo.Checked += new System.Windows.RoutedEventHandler(this.chbx_FormatVideo_Checked);
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.chbx_FormatVideo.Unchecked += new System.Windows.RoutedEventHandler(this.chbx_FormatVideo_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cmbx_DateFormat = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.txbx_separator = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\MainWindow.xaml"
            this.txbx_separator.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbx_separator_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.progBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 11:
            this.chbx_reWriteFiles = ((System.Windows.Controls.CheckBox)(target));
            
            #line 31 "..\..\MainWindow.xaml"
            this.chbx_reWriteFiles.Checked += new System.Windows.RoutedEventHandler(this.chbx_reWriteFiles_Checked);
            
            #line default
            #line hidden
            
            #line 31 "..\..\MainWindow.xaml"
            this.chbx_reWriteFiles.Unchecked += new System.Windows.RoutedEventHandler(this.chbx_reWriteFiles_Unchecked);
            
            #line default
            #line hidden
            return;
            case 12:
            this.chbx_subFolders = ((System.Windows.Controls.CheckBox)(target));
            
            #line 32 "..\..\MainWindow.xaml"
            this.chbx_subFolders.Checked += new System.Windows.RoutedEventHandler(this.chbx_subFolders_Checked);
            
            #line default
            #line hidden
            
            #line 32 "..\..\MainWindow.xaml"
            this.chbx_subFolders.Unchecked += new System.Windows.RoutedEventHandler(this.chbx_subFolders_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
