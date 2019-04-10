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
    public partial class PhoneBook : Form
    {

        SinglyList<People> Peoples = new SinglyList<People>();
        StringBuilder sb = new StringBuilder();

        public PhoneBook()
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
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Поля должны быть заполненны!");
            }
            else
            {
                listBox1.Items.Clear();
                People newPeople = new People();
                newPeople.Name = textBox1.Text;
                newPeople.Number = textBox2.Text;
                Peoples.Add(newPeople);

                for (int i = 0; i < Peoples.Count; i++)
                {
                    listBox1.Items.Insert(i, Peoples.GetValue(i).Name + "  -  " + Peoples.GetValue(i).Number);
                }
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            Peoples.DeleteNode(index);
            listBox1.Items.Clear();
            for (int i = 0; i < Peoples.Count; i++)
            {
                listBox1.Items.Insert(i, Peoples.GetValue(i).Name + "  -  " + Peoples.GetValue(i).Number);
            }
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    SortedDictionary<string, string> keyValues = new SortedDictionary<string, string>();
        //    for (int i = 0; i < Peoples.Count; i++)
        //    {
        //        keyValues.Add(Peoples.GetValue(i).Name, Peoples.GetValue(i).Number);
        //    }
        //    sb.Clear();
        //    foreach (KeyValuePair<string,string> kv in keyValues)
        //    {
        //        sb.Append(kv.Key + " - " + kv.Value);
        //        sb.AppendLine();
        //    }
        //}

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, string> keyValues = new SortedDictionary<string, string>();
            for (int i = 0; i < Peoples.Count; i++)
            {
                keyValues.Add(Peoples.GetValue(i).Name, Peoples.GetValue(i).Number);
            }

            int n = 0;
            foreach (KeyValuePair<string, string> kv in keyValues)
            {
                Peoples.GetValue(n).Name = kv.Key;
                Peoples.GetValue(n).Number = kv.Value;
                n++;
            }

            listBox1.Items.Clear();

            for (int i = 0; i < Peoples.Count; i++)
            {
                listBox1.Items.Insert(i, Peoples.GetValue(i).Name + "  -  " + Peoples.GetValue(i).Number);
            }
            //int k = 0;
            //foreach (KeyValuePair<string, string> kv in keyValues)
            //{
            //    listBox1.Items.Insert(k, kv.Key + "  -  " + kv.Value);
            //    k++;
            //}

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, string> keyValues = new SortedDictionary<string, string>();
            for (int i = 0; i < Peoples.Count; i++)
            {
                keyValues.Add(Peoples.GetValue(i).Name, Peoples.GetValue(i).Number);
            }

            int n = 0;
            foreach (KeyValuePair<string, string> kv in keyValues)
            {
                Peoples.GetValue(n).Name = kv.Key;
                Peoples.GetValue(n).Number = kv.Value;
                n++;
            }

            Peoples.Turn();

            listBox1.Items.Clear();

            for (int i = 0; i < Peoples.Count; i++)
            {
                listBox1.Items.Insert(i, Peoples.GetValue(i).Name + "  -  " + Peoples.GetValue(i).Number);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int index = 0;

            for (Node<People> p = Peoples.GetNode(0); ; p = p.Next)
            {
                if (Equals(text, p.Data.Name))
                {
                    listBox1.SelectionMode = SelectionMode.MultiSimple;
                    listBox1.SetSelected(index, true);
                }

                if (p.Next == null)
                {
                    index = -1;
                    break;
                }
                index++;
            }

            //if (index == -1)
            //{
            //    MessageBox.Show("Контакт не найден!");
            //}
            //else
            //{
            //    listBox1.SetSelected(index,true);
            //}
        }
    }

    public class People
    {
        public string Name { get; set; }
        public string Number { get; set; }

        
    }
}
