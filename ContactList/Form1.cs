using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactList
{
    public partial class Form1 : Form
    {
        //global
        private Contact[] phoneBook = new Contact[1];

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            Display();
        }
        private void Write(Contact obj)
        {
            
            StreamWriter sw = new StreamWriter("Contacts.txt");
            sw.WriteLine(phoneBook.Length + 1);
            sw.WriteLine(obj.FirstName);
            sw.WriteLine(obj.LastName);
            sw.WriteLine(obj.Phone);

            for(int x = 0; x < phoneBook.Length; x++)
            {
                sw.WriteLine(phoneBook[x].FirstName);
                sw.WriteLine(phoneBook[x].LastName);
                sw.WriteLine(phoneBook[x].Phone);
            }

            sw.Close();
        }

        private void Read()
        {
            StreamReader sr = new StreamReader("Contacts.txt");
            phoneBook = new Contact[Convert.ToInt32(sr.ReadLine())];

            for(int x = 0;x < phoneBook.Length; x++)
            {
                phoneBook[x] = new Contact();
                phoneBook[x].FirstName = sr.ReadLine();
                phoneBook[x].LastName = sr.ReadLine();
                phoneBook[x].Phone = sr.ReadLine();
            }

            sr.Close();
        }

        private void Display()
        {
            lstContacts.Items.Clear();

            for(int x =0; x < phoneBook.Length; x++)
            {
                //string item = "FN:"+phoneBook[x].FirstName.ToString() +" LN:"+ phoneBook[x].LastName.ToString() +" Ph:"+ phoneBook[x].Phone.ToString();
                lstContacts.Items.Add(phoneBook[x].ListFormat());
            }
        }

        private void ClearForm()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;  
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Contact obj = new Contact();
            obj.FirstName = txtFirstName.Text;
            obj.LastName = txtLastName.Text;
            obj.Phone = txtPhone.Text;

           Write(obj);
           Read();
           Display();
           ClearForm();
        }

        
        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}