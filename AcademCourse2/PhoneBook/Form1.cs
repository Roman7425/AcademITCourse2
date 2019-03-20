using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using List;


namespace PhoneBook
{
    public partial class Form1 : Form
    {

        SinglyList<People> Peoples = new SinglyList<People>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            People newPeople = new People();
            newPeople.Name = textBox1.Text;
            newPeople.Number = textBox2.Text;
            Peoples.Add(newPeople);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class People
    {
        public string Name { get; set; }
        public string Number { get; set; }

        
    }
}
