﻿#pragma checksum "..\..\..\..\ActionUser\ClientInfoOrder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5007154A4951FE6F23D357FB0D30CDFFB193D650"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseWorkSUBD.ActionUser;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace CourseWorkSUBD.ActionUser {
    
    
    /// <summary>
    /// ClientInfoOrder
    /// </summary>
    public partial class ClientInfoOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock clientNameMaster;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock clientInfoAutoMarka;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock clientInfoAutoGosnom;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock clientInfoAutoTypeEngine;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock clientDataOrder;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock clientInfoWork;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butPayment;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CourseWorkSUBD;V1.0.0.0;component/actionuser/clientinfoorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.clientNameMaster = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.clientInfoAutoMarka = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.clientInfoAutoGosnom = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.clientInfoAutoTypeEngine = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.clientDataOrder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.clientInfoWork = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.butPayment = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
            this.butPayment.Click += new System.Windows.RoutedEventHandler(this.butPayment_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.butClose = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\ActionUser\ClientInfoOrder.xaml"
            this.butClose.Click += new System.Windows.RoutedEventHandler(this.butClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

