using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDB_Forms
{
    public partial class Form1 : Form
    {
        IMongoDatabase a_Database; //กำหนดหาฐานข้อมูล
        IMongoCollection<TTTT> a_collection;
        public Form1()
        {

            InitializeComponent();

            var client = new MongoClient("mongodb+srv://localhost:20170/"); //ลิงค์URL MONGODB
            a_Database = client.GetDatabase("TTTT"); //ดึงฐานข้อมูล
            a_collection = a_Database.GetCollection<TTTT>("Collection Name");//ชื่อCollection
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("yah!!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TTTT ttt = new TTTT();

                ttt.Name = textBox1.Text; //พิมข้อมูลที่เป็นรูปแบบ str
                ttt.City = textBox2.Text; //พิมข้อมูลที่เป็นรูปแบบ str
                ttt.DiscordName = textBox3.Text; //พิมข้อมูลที่เป็นรูปแบบ str
                ttt.Number = Convert.ToInt32(textBox4.Text); //พิมข้อมูลที่เป็นรูปแบบ num

                a_collection.InsertOne(ttt); //ส่งข้อมูลไป

                MessageBox.Show("Save information in database", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Errot", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}