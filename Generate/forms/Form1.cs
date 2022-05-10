using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Reflection;

namespace Generate
{
    public partial class Form1 : Form
    {
        //https://www.codeproject.com/Articles/59193/Localizing-a-Windows-Application-with-Satellite-As
        private ResourceManager resourceManger = null;

        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string address = string.Empty;
        private string city = string.Empty;
        private string county = string.Empty;
        private string zipCode = string.Empty;
        private string country = "Greece";
        private string phoneNumber = string.Empty;

        public Form1()
        {
            InitializeComponent();

            resourceManger = new ResourceManager("Generate.resources.Form1", Assembly.GetExecutingAssembly());
            UpdateUIControls("en-US");
        }

        private void UpdateUIControls(string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);

            Text = resourceManger.GetString("Form1.Text");

            button1.Text = resourceManger.GetString("button1.Text");
            button2.Text = resourceManger.GetString("button2.Text");
            button3.Text = resourceManger.GetString("button3.Text");

            label1.Text = resourceManger.GetString("label1.Text");
            label2.Text = resourceManger.GetString("label2.Text");
            label3.Text = resourceManger.GetString("label3.Text");
            label4.Text = resourceManger.GetString("label4.Text");
            label5.Text = resourceManger.GetString("label5.Text");
            label6.Text = resourceManger.GetString("label6.Text");
            label7.Text = resourceManger.GetString("label7.Text");
            label8.Text = resourceManger.GetString("label8.Text");
            label17.Text = resourceManger.GetString("label17.Text");
            label18.Text = resourceManger.GetString("label18.Text");

            linkLabel1.Text = resourceManger.GetString("linkLabel1.Text");

            groupBox1.Text = resourceManger.GetString("groupBox1.Text");
            groupBox2.Text = resourceManger.GetString("groupBox2.Text");
            groupBox3.Text = resourceManger.GetString("groupBox3.Text");

            radioButton1.Text = resourceManger.GetString("radioButton1.Text");
            radioButton2.Text = resourceManger.GetString("radioButton2.Text");
            radioButton3.Text = resourceManger.GetString("radioButton3.Text");
            radioButton4.Text = resourceManger.GetString("radioButton4.Text");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generateFirstName();
            generateLastName();
            generateAddress();
            generateCity();
            generateCounty();
            generateZipCode();
            generatePhoneNumber();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Format(
                "First name - {0}" + Environment.NewLine +
                "Last name - {1}" + Environment.NewLine +
                "Address - {2}" + Environment.NewLine +
                "City - {3}" + Environment.NewLine +
                "County - {4}" + Environment.NewLine +
                "ZIP - {5}" + Environment.NewLine +
                "Country - {6}" + Environment.NewLine +
                "Phone number - {7}",
                firstName,
                lastName,
                address,
                city,
                county,
                zipCode,
                country,
                phoneNumber);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox3.Text);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com/maps");
        }





        private void button7_Click(object sender, EventArgs e)
        {
            generateFirstName();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            generateLastName();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            generateAddress();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            generateCity();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            generateCounty();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            generateZipCode();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            generatePhoneNumber();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UpdateUIControls("ru-RU");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UpdateUIControls("en-US");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            UpdateUIControls("el-GR");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void generateFirstName()
        {
            string gender = radioButton1.Checked ? "m" : "w";
            string receiver = radioButton3.Checked ? "ru" : "gr";
            
            firstName = Generator.generateFirstName(gender, receiver);
            label9.Text = firstName;
        }

        private void generateLastName()
        {
            string gender = radioButton1.Checked ? "m" : "w";
            string receiver = radioButton3.Checked ? "ru" : "gr";
            
            lastName = Generator.generateLastName(gender, receiver);
            label10.Text = lastName;
        }

        private void generateAddress()
        {
            address = Generator.generateAddress(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            label11.Text = address;
        }

        private void generateCity()
        {
            city = Generator.generateCity();
            label12.Text = city;
        }

        private void generateCounty()
        {
            county = Generator.generateCounty();
            label13.Text = county;
        }

        private void generateZipCode()
        {
            zipCode = Generator.generateZipCode();
            label14.Text = zipCode;
        }

        private void generatePhoneNumber()
        {
            phoneNumber = Generator.generatePhoneNumber();
            label16.Text = phoneNumber;
        }
    }
}
