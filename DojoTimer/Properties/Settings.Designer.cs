﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DojoTimer.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("7")]
        public int TimerMinutes {
            get {
                return ((int)(this["TimerMinutes"]));
            }
            set {
                this["TimerMinutes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60000")]
        public int CompileIntervalMilliseconds {
            get {
                return ((int)(this["CompileIntervalMilliseconds"]));
            }
            set {
                this["CompileIntervalMilliseconds"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool CleanupAfterCompile {
            get {
                return ((bool)(this["CleanupAfterCompile"]));
            }
            set {
                this["CleanupAfterCompile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseCoverage {
            get {
                return ((bool)(this["UseCoverage"]));
            }
            set {
                this["UseCoverage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\DOJO OUT")]
        public string BaseCompilePath {
            get {
                return ((string)(this["BaseCompilePath"]));
            }
            set {
                this["BaseCompilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\WINDOWS\\Microsoft.NET\\Framework\\v4.0.30319\\msbuild.exe")]
        public string MSBuildPath {
            get {
                return ((string)(this["MSBuildPath"]));
            }
            set {
                this["MSBuildPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files\\Microsoft Visual Studio 10.0\\Common7\\IDE\\MStest.exe")]
        public string MSTestPath {
            get {
                return ((string)(this["MSTestPath"]));
            }
            set {
                this["MSTestPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files\\PartCover\\PartCover .NET 4.0\\partcover.exe")]
        public string PartCoverPath {
            get {
                return ((string)(this["PartCoverPath"]));
            }
            set {
                this["PartCoverPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("+[Continuous*]*")]
        public string CoverageReportingAssembliesRegEx {
            get {
                return ((string)(this["CoverageReportingAssembliesRegEx"]));
            }
            set {
                this["CoverageReportingAssembliesRegEx"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\ReferenceMaterial\\06 Programming Projects\\DojoTimer\\DojoTimer.sln")]
        public string SolutionPath {
            get {
                return ((string)(this["SolutionPath"]));
            }
            set {
                this["SolutionPath"] = value;
            }
        }
    }
}
