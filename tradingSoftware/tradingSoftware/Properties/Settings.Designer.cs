﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tradingSoftware.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SHAILESHKALSARI\\SQLEXPRESS;Initial Catalog=TRADE.MDF;Integrated Secur" +
            "ity=True")]
        public string TradeConnectionString {
            get {
                return ((string)(this["TradeConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Database\\Trade.mdf;Inte" +
            "grated Security=True;Connect Timeout=30;User Instance=True")]
        public string EarlierConnectionString {
            get {
                return ((string)(this["EarlierConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shailesh Kalsariya\\Dropbox\\VI " +
            "Sem Project- Trading Software\\Database\\Trade.mdf;Integrated Security=True;User I" +
            "nstance=True")]
        public string ShaConStr {
            get {
                return ((string)(this["ShaConStr"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shailesh Kalsariya\\Dropbox\\VI " +
            "Sem Project- Trading Software\\Database\\Trade.mdf;Integrated Security=True;User I" +
            "nstance=True")]
        public string VJConStr {
            get {
                return ((string)(this["VJConStr"]));
            }
        }
    }
}
