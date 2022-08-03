using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TestRichTextBoxAddCommand
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void RichTextBlock_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            var richTextBlock = (RichTextBlock)sender;
            var flyout = richTextBlock.ContextFlyout as TextCommandBarFlyout;
            var newAppBarButton = new AppBarButton();
            newAppBarButton.Label = "New Test Cmd";
            newAppBarButton.Icon = new SymbolIcon(Symbol.Find);
            var testCmd = new StandardUICommand(StandardUICommandKind.Play);
            testCmd.ExecuteRequested += TestCmd_ExecuteRequested;
            newAppBarButton.Command = testCmd;

            //newAppBarButton.Command = new RelayCommand(RelayCmdAppBarButton);
            newAppBarButton.Click += testAppBarButton_Click;
            flyout.SecondaryCommands.Add(newAppBarButton); // <---- PROBLEM - Adding secondardy cmd either clears current ones or adds it and does nothing

            var sc = flyout.SecondaryCommands.ToArray();
            if (sc.Any())
            {
                var scFirst = sc[0]; // Debugging only
            }
        }

        private void TestCmd_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void RelayCmdAppBarButton()
        {
            throw new NotImplementedException();
        }

        private void testAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
