/*
 * Created by SharpDevelop.
 * User: f.alonzi
 * Date: 18/10/2019
 * Time: 10:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace griglia_con_paginazione
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		List<Student> studentList;

        const int Num = 12; 
		public Window1()
		{
			InitializeComponent();
			Binding(Num, 1);
		}
		
		  private void Binding(int number, int currentPage)
        {
            studentList = new List<Student>();
            int i = 0;
            do
            {
                studentList.Add(new Student(i++, "Name" + i, 18, "Male", "123456@outlook.com"));
            } while (studentList.Count < 100);
            int count = studentList.Count;          
            int pageSize = 0;           
            if (count % number == 0)
            {
                pageSize = count / number;
            }
            else
            {
                pageSize = count / number + 1;
            }

            tbkTotal.Text = pageSize.ToString();

            tbkCurrentsize.Text = currentPage.ToString();
            studentList = studentList.Take(number * currentPage).Skip(number * (currentPage - 1)).ToList();   
            dataGrid1.ItemsSource = studentList;       
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Binding(Num, 1);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            int total = int.Parse(tbkTotal.Text);
            Binding(Num, total);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            int total = int.Parse(tbkTotal.Text); 
            int currentPage = int.Parse(tbkCurrentsize.Text); 
            if (currentPage > 1)
            {
                Binding(Num, currentPage - 1); 
            }
        }
        
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int total = int.Parse(tbkTotal.Text); 
            int currentPage = int.Parse(tbkCurrentsize.Text); 
            if (currentPage < total)
            {
                Binding(Num, currentPage + 1); 
            }
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            int pageGoNum;
            if (tbxPageNum.Text != null&& int.TryParse(tbxPageNum.Text,out pageGoNum))
            {
                int pageNum = int.Parse(tbxPageNum.Text);
                int total = int.Parse(tbkTotal.Text); 
                if (pageNum >= 1 && pageNum <= total)
                {
                    Binding(Num, pageNum); 
                }
            }
          
        }

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string Email { get; set; }
            public Student(int id, string name, int age, string gender, string email)
            {
                this.ID = id;
                this.Name = name;
                this.Age = age;
                this.Gender = gender;
                this.Email = email;
            }
        }
	}
}
