using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CanvasAnimationTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            RootCanvasLayout.PointerPressed += new PointerEventHandler(Pointer_Pressed);
        }

        private void Pointer_Pressed(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Input.PointerPoint currentPoint = e.GetCurrentPoint(RootCanvasLayout);
            CreateAnimation(currentPoint);
        }
        void CreateAnimation(PointerPoint point)
        {  var duration = new Duration(TimeSpan.FromMilliseconds(1000));
            DoubleAnimation doubleAnimationX = new DoubleAnimation();
            DoubleAnimation doubleAnimationY = new DoubleAnimation();
            doubleAnimationX.To = point.Position.X-Pic.ActualWidth/2;
            doubleAnimationX.Duration = duration;
            doubleAnimationY.To = point.Position.Y-Pic.ActualHeight/2;
            doubleAnimationY.Duration = duration;
            var conStoryboard = new Storyboard();
            conStoryboard.Children.Add(doubleAnimationX);
            conStoryboard.Children.Add(doubleAnimationY);
            Storyboard.SetTarget(doubleAnimationX, Pic);
            Storyboard.SetTarget(doubleAnimationY, Pic);
            Storyboard.SetTargetProperty(doubleAnimationX, "(Canvas.Left)");
            Storyboard.SetTargetProperty(doubleAnimationY, "(Canvas.Top)");
            conStoryboard.Begin();
        }
    }
}
