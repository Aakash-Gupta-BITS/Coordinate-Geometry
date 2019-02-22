using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Co_ordinate_Geometry
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Calculator_frame.Navigate(typeof(Calculator));
            Straight_Triangle.Navigate(typeof(Straight_Lines.Triangle));
            Straight_Trigonometry.Navigate(typeof(Straight_Lines.Trigonometry));
            Straight_2_Points.Navigate(typeof(Straight_Lines._2_Points));
            Straight_Intersection.Navigate(typeof(Straight_Lines.Find_Intersection));
            Straight_Convert_Equation.Navigate(typeof(Straight_Lines.Convert_Equation));
            Straight_Point_Distance.Navigate(typeof(Straight_Lines.Dstance_From_Line));
            Circle_Equation.Navigate(typeof(Circle.Equation));
            Circle_3_Points.Navigate(typeof(Circle._3_Points));
            Circle_Diameter.Navigate(typeof(Circle.Diameter_Points));
            Circle_Centre_Point.Navigate(typeof(Circle.Center_and_Point));
            Circle_Find_Point.Navigate(typeof(Circle.Find_Points));
            Circle_Point_Line.Navigate(typeof(Circle._2_Point_and_line));
            Parabola_1.Navigate(typeof(Parabola.Right_Left_Parabola));
            Parabola_Focus_Directrix.Navigate(typeof(Parabola.Focus_And_Directrix));
            Parabola_2.Navigate(typeof(Parabola.Up_Down_Parabola));
            Ellipse_Info.Navigate(typeof(Ellipse.Info));
            Ellipse_General.Navigate(typeof(Ellipse.Axis));
        }
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Menu_Open.IsSelected) { MySplitView.IsPaneOpen = false; }
            if (Menu_Straight_Lines.IsSelected) { MySplitView.IsPaneOpen = false; Hide_pivot(); Window_Straight_Lines.Visibility = Visibility.Visible; }
            if (Menu_Circle.IsSelected) { MySplitView.IsPaneOpen = false; Hide_pivot(); Window_Circle.Visibility = Visibility.Visible; }
            if (Menu_Parabola.IsSelected) { MySplitView.IsPaneOpen = false; Hide_pivot(); Window_Parabola.Visibility = Visibility.Visible; }
            if (Menu_Ellipse.IsSelected) { MySplitView.IsPaneOpen = false; Hide_pivot(); Window_Ellipse.Visibility = Visibility.Visible; }
        }
        private void Hide_pivot()
        {
            Window_Straight_Lines.Visibility = Visibility.Collapsed;
            Window_Circle.Visibility = Visibility.Collapsed;
            Window_Parabola.Visibility = Visibility.Collapsed;
            Window_Ellipse.Visibility = Visibility.Collapsed;
        }
        private void Show_Hide_Calc_Click(object sender, RoutedEventArgs e)
        {
            if (Show_Hide_Calc.Content.ToString() == "Show Calculator") { Show_Hide_Calc.Content = "Hide Calculator"; Calculator.Visibility = Visibility.Visible; Grid.SetColumn(Calculator, 1); Grid.SetColumn(Window_Straight_Lines, 0); Grid.SetColumnSpan(Window_Straight_Lines, 1); }
            else { Show_Hide_Calc.Content = "Show Calculator"; Calculator.Visibility = Visibility.Collapsed; Grid.SetColumn(Calculator, 2); Grid.SetColumn(Window_Straight_Lines, 0); Grid.SetColumnSpan(Window_Straight_Lines, 2); }
        }
    }
}
