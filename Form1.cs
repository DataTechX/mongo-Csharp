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
        IMongoDatabase a_Database; //��˹��Ұҹ������
        IMongoCollection<TTTT> a_collection;
        public Form1()
        {

            InitializeComponent();

            var client = new MongoClient("mongodb+srv://localhost:20170/"); //�ԧ��URL MONGODB
            a_Database = client.GetDatabase("TTTT"); //�֧�ҹ������
            a_collection = a_Database.GetCollection<TTTT>("Collection Name");//����Collection
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

                ttt.Name = textBox1.Text; //��������ŷ�����ٻẺ str
                ttt.City = textBox2.Text; //��������ŷ�����ٻẺ str
                ttt.DiscordName = textBox3.Text; //��������ŷ�����ٻẺ str
                ttt.Number = Convert.ToInt32(textBox4.Text); //��������ŷ�����ٻẺ num

                a_collection.InsertOne(ttt); //�觢������

                MessageBox.Show("Save information in database", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Errot", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}