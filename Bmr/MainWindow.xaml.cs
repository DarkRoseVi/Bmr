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

namespace Bmr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       public static double BMP;
        public static double IEEP;
        public static double weight;
        public static double year;
        public static double height;

        private void yearTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text,0))
            {
                e.Handled = true;
            }
      
        }

        private void heightTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void weightTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void BMRBt_Click(object sender, RoutedEventArgs e)
        {
            if (heightTb.Text.Length > 0 && yearTb.Text.Length > 0 && weightTb.Text.Length > 0 && NameTb.Text.Length > 0)
            {
                height = double.Parse(heightTb.Text.Trim());
                year = int.Parse(yearTb.Text.Trim());
                weight = double.Parse(weightTb.Text.Trim());
      
                if ((year > 1990 && year < 2023) && (height > 140 && height < 200) && weight > 0 && floorCb.Text != "")
                {
                    if ((floorCb.SelectedItem as ComboBoxItem).Tag == "Woman")
                    {
                        bmrTb.Text = (65.5 + (9.6 * weight) + (1.8 * height) - (4.7 * (2023 - year))).ToString();
                    }
                    else
                    {
                        bmrTb.Text = (66 + (13.7 * weight) + (5 * height) - (6.8 * (2023 - year))).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректные данные");
                }


            }
            else
            {
                MessageBox.Show("Введите данные");
            }

        }

        private void TDEEBt_Click(object sender, RoutedEventArgs e)
        {
            if (bmrTb.Text != ""  && ActivCb.Text != "")
            {
                    double bm = double.Parse(bmrTb.Text.Trim());
                    switch ((ActivCb.SelectedItem as ComboBoxItem).Tag)
                    {
                        case "1":
                            TdeeTb.Text = (bm * 1.2).ToString();
                            break;
                        case "2":
                            TdeeTb.Text = (bm * 1.375).ToString();
                            break;
                        case "3":
                            TdeeTb.Text = (bm * 1.55).ToString();
                            break;
                        case "4":
                            TdeeTb.Text = (bm * 1.725).ToString();
                            break;
                        case "5":
                            TdeeTb.Text = (bm * 1.9).ToString();
                            break;


                        default:
                            break;
                    }
            }
             else MessageBox.Show("выберите статус");
          
        }

        //private void clear_Click(object sender, RoutedEventArgs e)
        //{
        //    yearTb.Text = " ";
        //    TdeeTb.Text = " ";
        //    bmrTb.Text = " ";
        //    heightTb.Text = " ";
        //}
    }
}
