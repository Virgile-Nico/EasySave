﻿#pragma checksum "..\..\..\Save_screen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2720F20675D12C581961A923CBA9BBE06C9A5158"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using App_Easy_Save;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace App_Easy_Save {
    
    
    /// <summary>
    /// Save_screen
    /// </summary>
    public partial class Save_screen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Save_screen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Single_save_combo;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Save_screen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Single_save;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Save_screen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Scope_first;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Save_screen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Scope_last;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Save_screen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Scope_save;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Save_screen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button All_save;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Save_screen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox encrypt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/App_Easy_Save;component/save_screen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Save_screen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Single_save_combo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.Single_save = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Save_screen.xaml"
            this.Single_save.Click += new System.Windows.RoutedEventHandler(this.Single_save_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Scope_first = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Scope_last = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Scope_save = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Save_screen.xaml"
            this.Scope_save.Click += new System.Windows.RoutedEventHandler(this.Scope_save_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.All_save = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Save_screen.xaml"
            this.All_save.Click += new System.Windows.RoutedEventHandler(this.All_save_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.encrypt = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

