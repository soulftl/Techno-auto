﻿#pragma checksum "..\..\AddEditVehicle.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F809E90300F53F11F7E249898C26E1F475A2A284B0E3BD5A791C33791201A76B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FleetEquipment;
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


namespace FleetEquipment {
    
    
    /// <summary>
    /// AddEditVehicle
    /// </summary>
    public partial class AddEditVehicle : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AddEditVehicle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Execute;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AddEditVehicle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Transmission;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AddEditVehicle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BodyType;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddEditVehicle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InStock;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddEditVehicle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AddEditVehicle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ManufacturerComboBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddEditVehicle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ColorComboBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AddEditVehicle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TechnicComboBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AddEditVehicle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BackButtonVehicle;
        
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
            System.Uri resourceLocater = new System.Uri("/FleetEquipment;component/addeditvehicle.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddEditVehicle.xaml"
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
            this.Execute = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\AddEditVehicle.xaml"
            this.Execute.Click += new System.Windows.RoutedEventHandler(this.Execute_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Transmission = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.BodyType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.InStock = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ManufacturerComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.ColorComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.TechnicComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.BackButtonVehicle = ((System.Windows.Controls.Image)(target));
            
            #line 48 "..\..\AddEditVehicle.xaml"
            this.BackButtonVehicle.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.BackButtonVehicle_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
