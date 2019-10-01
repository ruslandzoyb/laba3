using System;
using System.Collections.Generic;
using System.Threading;
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
using System.ComponentModel;

namespace laba3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ProgressBar[] progressBars;
        RadioButton[] buttons ;
        Thread[] threads= new Thread[4];


        System.Windows.Threading.DispatcherTimer timer;
        Recs[] recs= new Recs[4];
        public MainWindow()
        {
            InitializeComponent();

            progressBars = new ProgressBar[] { rec1, rec2, rec3, rec4 };
            buttons = new RadioButton[] { radioButton, radioButton3, radioButton5, radioButton7 };

            SolidColorBrush[] brushes = { Brushes.Red, Brushes.Yellow, Brushes.Silver, Brushes.Black };
            for (int i = 0; i < progressBars.Length; i++)
            {
                progressBars[i].Foreground = brushes[i];
                progressBars[i].Value = 5;
                
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Do);
            }
                          
                      
            

        }
        
           private void Do(object bar)
        {
            ProgressBar progressBar = (ProgressBar)bar;

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                progressBar.Value += i;
            }
        }  
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
            
           
            
            
        
      
        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {

          
            threads[0].Start(progressBars[0]);
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            threads[0].Abort();
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
           
           // threads[1].Start(progressBars[1]);
        }

        private void RadioButton4_Checked(object sender, RoutedEventArgs e)
        {
            
            threads[2].Start(progressBars[2]);
        }

        private void RadioButton6_Checked(object sender, RoutedEventArgs e)
        {
            
            threads[3].Start(progressBars[3]);
        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
          //  threads[1].Abort();
        }

        private void RadioButton5_Checked(object sender, RoutedEventArgs e)
        {
         //   threads[2].Abort();
        }

        private void RadioButton7_Checked(object sender, RoutedEventArgs e)
        {
          //  threads[3].Abort();
        }
    }
    class Recs
    {
        public int Num { get; set; }
        public ProgressBar Bar { get; set; }
    }
    }

