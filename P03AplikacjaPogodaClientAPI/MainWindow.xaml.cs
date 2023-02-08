﻿using P03AplikacjaPogodaClientAPI.Models;
using P03AplikacjaPogodaClientAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P03AplikacjaPogodaClientAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //double screenHeight = SystemParameters.PrimaryScreenHeight;
        }

        public static double WindowWidth => WindowWidth;
        public static double WindowHeighth => WindowHeighth;

        public static void ShowText(string text)
        {
            MessageBox.Show(text);
        }

        public static void ShowShopWindow()
        {
            new ShopWindow().Show();
        }
    }
}
