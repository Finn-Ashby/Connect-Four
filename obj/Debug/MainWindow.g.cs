﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "84E48926DF7DAD9D8934809927B227912FB427356E424FB757C8C86CDCFFDA4C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Connect_4;
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


namespace Connect_4 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 120 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLb;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSettings;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlay;
        
        #line default
        #line hidden
        
        
        #line 266 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
        #line default
        #line hidden
        
        
        #line 301 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock notepad;
        
        #line default
        #line hidden
        
        
        #line 313 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPlayer1;
        
        #line default
        #line hidden
        
        
        #line 331 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPlayer2;
        
        #line default
        #line hidden
        
        
        #line 342 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cnvBoard;
        
        #line default
        #line hidden
        
        
        #line 440 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sldDifficulty;
        
        #line default
        #line hidden
        
        
        #line 445 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox tckAI;
        
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
            System.Uri resourceLocater = new System.Uri("/Connect 4;component/mainwindow.xaml", System.UriKind.Relative);
            
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
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 133 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\MainWindow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnLb = ((System.Windows.Controls.Button)(target));
            
            #line 179 "..\..\MainWindow.xaml"
            this.btnLb.Click += new System.Windows.RoutedEventHandler(this.btnLb_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSettings = ((System.Windows.Controls.Button)(target));
            
            #line 208 "..\..\MainWindow.xaml"
            this.btnSettings.Click += new System.Windows.RoutedEventHandler(this.btnSettings_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnPlay = ((System.Windows.Controls.Button)(target));
            
            #line 237 "..\..\MainWindow.xaml"
            this.btnPlay.Click += new System.Windows.RoutedEventHandler(this.btnPlay_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnReset = ((System.Windows.Controls.Button)(target));
            
            #line 266 "..\..\MainWindow.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.btnReset_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.notepad = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.txtPlayer1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 311 "..\..\MainWindow.xaml"
            this.txtPlayer1.GotFocus += new System.Windows.RoutedEventHandler(this.txtPlayer_Click);
            
            #line default
            #line hidden
            
            #line 322 "..\..\MainWindow.xaml"
            this.txtPlayer1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtPlayer_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtPlayer2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 328 "..\..\MainWindow.xaml"
            this.txtPlayer2.GotFocus += new System.Windows.RoutedEventHandler(this.txtPlayer_Click);
            
            #line default
            #line hidden
            
            #line 339 "..\..\MainWindow.xaml"
            this.txtPlayer2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtPlayer_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.cnvBoard = ((System.Windows.Controls.Canvas)(target));
            
            #line 342 "..\..\MainWindow.xaml"
            this.cnvBoard.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.cnvBoard_MouseDown);
            
            #line default
            #line hidden
            
            #line 342 "..\..\MainWindow.xaml"
            this.cnvBoard.MouseMove += new System.Windows.Input.MouseEventHandler(this.cnvBoard_MouseOver);
            
            #line default
            #line hidden
            
            #line 342 "..\..\MainWindow.xaml"
            this.cnvBoard.MouseLeave += new System.Windows.Input.MouseEventHandler(this.cnvBoard_MouseLeave);
            
            #line default
            #line hidden
            
            #line 342 "..\..\MainWindow.xaml"
            this.cnvBoard.MouseEnter += new System.Windows.Input.MouseEventHandler(this.cnvBoard_MouseOver);
            
            #line default
            #line hidden
            return;
            case 12:
            this.sldDifficulty = ((System.Windows.Controls.Slider)(target));
            return;
            case 13:
            this.tckAI = ((System.Windows.Controls.CheckBox)(target));
            
            #line 445 "..\..\MainWindow.xaml"
            this.tckAI.Checked += new System.Windows.RoutedEventHandler(this.tckAI_Checked);
            
            #line default
            #line hidden
            
            #line 445 "..\..\MainWindow.xaml"
            this.tckAI.Unchecked += new System.Windows.RoutedEventHandler(this.tckAI_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

