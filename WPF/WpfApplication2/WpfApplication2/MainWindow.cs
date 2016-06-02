using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApplication2
{
    public partial class MainWindow : Window
    {
        Person person = new Person { Name = "Salman", Age = 26 };

        //public MainWindow()
        //{
        //    InitializeComponent();
        //    this.DataContext = person;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = person.Name + " is " + person.Age;
            MessageBox.Show(message);
        }
    }

    public class Person 
    { 
	    private string nameValue;
		
        public string Name 
        { 
            get { return nameValue; } 
            set { nameValue = value; } 
        } 
		
        private double ageValue; 
		
        public double Age 
        { 
            get { return ageValue; } 
				
            set 
            { 
                if (value != ageValue) 
                { 
                    ageValue = value; 
                } 
            } 
        }		
    } 
} 

