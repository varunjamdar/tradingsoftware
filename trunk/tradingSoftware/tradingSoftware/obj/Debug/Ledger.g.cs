﻿#pragma checksum "..\..\Ledger.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "79866BEB4DC409DC13768DD6333F2C9B"
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
    /// Ledger
    /// </summary>
    public partial class Ledger : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\Ledger.xaml"
        internal System.Windows.Controls.Grid GridLedgerMain;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\Ledger.xaml"
        internal System.Windows.Controls.TabControl tabControlLedger;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\Ledger.xaml"
        internal System.Windows.Controls.TabItem TabItemLedger;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\Ledger.xaml"
        internal System.Windows.Controls.Grid GridLedger;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Ledger.xaml"
        internal System.Windows.Controls.ComboBox comboBoxLedger;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Ledger.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Ledger.xaml"
        internal Microsoft.Windows.Controls.DataGrid dataGridLedger;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Ledger.xaml"
        internal System.Windows.Controls.TextBox textBox1;
        
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
            System.Uri resourceLocater = new System.Uri("/tradingSoftware;component/ledger.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Ledger.xaml"
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
            this.GridLedgerMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.tabControlLedger = ((System.Windows.Controls.TabControl)(target));
            return;
            case 3:
            this.TabItemLedger = ((System.Windows.Controls.TabItem)(target));
            return;
            case 4:
            this.GridLedger = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.comboBoxLedger = ((System.Windows.Controls.ComboBox)(target));
            
            #line 9 "..\..\Ledger.xaml"
            this.comboBoxLedger.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBoxLedger_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.dataGridLedger = ((Microsoft.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.textBox1 = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
