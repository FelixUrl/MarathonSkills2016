﻿#pragma checksum "..\..\..\AdminController\EditCharity.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8ED4B88EAC6D57E4D687CC395E02FEC16E5D1465607FB8BF639FBD2881E0B673"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MarathonSkills.AdminController;
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


namespace MarathonSkills.AdminController {
    
    
    /// <summary>
    /// EditCharity
    /// </summary>
    public partial class EditCharity : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\AdminController\EditCharity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbName;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\AdminController\EditCharity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbFile;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\AdminController\EditCharity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbDisc;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\AdminController\EditCharity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Reg;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\AdminController\EditCharity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancel;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\AdminController\EditCharity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShow;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\AdminController\EditCharity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgLogo;
        
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
            System.Uri resourceLocater = new System.Uri("/MarathonSkills;component/admincontroller/editcharity.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminController\EditCharity.xaml"
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
            this.txbName = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\AdminController\EditCharity.xaml"
            this.txbName.GotFocus += new System.Windows.RoutedEventHandler(this.txbName_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbFile = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbDisc = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\AdminController\EditCharity.xaml"
            this.txbDisc.GotFocus += new System.Windows.RoutedEventHandler(this.txbDisc_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Reg = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\AdminController\EditCharity.xaml"
            this.btn_Reg.Click += new System.Windows.RoutedEventHandler(this.btn_Reg_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\AdminController\EditCharity.xaml"
            this.btn_cancel.Click += new System.Windows.RoutedEventHandler(this.btn_cancel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnShow = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\AdminController\EditCharity.xaml"
            this.btnShow.Click += new System.Windows.RoutedEventHandler(this.btnShow_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.imgLogo = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

