﻿#pragma checksum "..\..\Taxsetup.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "061BD7AD8D56F1BA14CED0CDA2F8478D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace tradingSoftware {
    
    
    /// <summary>
    /// Taxsetup
    /// </summary>
    public partial class Taxsetup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Taxsetup.xaml"
        internal System.Windows.Controls.Label label5;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Taxsetup.xaml"
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Taxsetup.xaml"
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Taxsetup.xaml"
        internal System.Windows.Controls.Button button3;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Taxsetup.xaml"
        internal Microsoft.Windows.Controls.DataGrid dataGrid1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/tradingSoftware;component/taxsetup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Taxsetup.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\Taxsetup.xaml"
            ((tradingSoftware.Taxsetup)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.label5 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.button1 = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.button2 = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.button3 = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.dataGrid1 = ((Microsoft.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
