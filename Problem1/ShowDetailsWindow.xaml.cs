using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Problem1
{
    /// <summary>
    /// Interaction logic for ShowDetailsWindow.xaml
    /// </summary>
    public partial class ShowDetailsWindow : Window
    {
        public ShowDetailsWindow()
        {
            InitializeComponent();
        }

        public void SetupWindow(TVShow show)
        {
            imgPoster.Source = new BitmapImage(new Uri(show.Poster));
            tblPlot.Text = show.Plot;
            
            this.Title = show.Title;
        }
    }
}
