﻿#pragma checksum "..\..\..\Properties\InputRecipeWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9C0A9418B12690FB0D6F0C5C476411351A3603F5B953F8980FD286FA3C9E3A80"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace PROG6221_ST10043367_POEPart3 {
    
    
    /// <summary>
    /// InputRecipeWindow
    /// </summary>
    public partial class InputRecipeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Properties\InputRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Properties\InputRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spIngredients;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Properties\InputRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddIngredient;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Properties\InputRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spSteps;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Properties\InputRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddStep;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Properties\InputRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/PROG6221_ST10043367_POEPart3;component/properties/inputrecipewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Properties\InputRecipeWindow.xaml"
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
            this.tbxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.spIngredients = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.btnAddIngredient = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Properties\InputRecipeWindow.xaml"
            this.btnAddIngredient.Click += new System.Windows.RoutedEventHandler(this.btnAddIngredient_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.spSteps = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.btnAddStep = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Properties\InputRecipeWindow.xaml"
            this.btnAddStep.Click += new System.Windows.RoutedEventHandler(this.btnAddStep_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Properties\InputRecipeWindow.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

