using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entityframework
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		ProductDal _productDal = new ProductDal();
		private void Form1_Load(object sender, EventArgs e)
		{
			LoadGrid();
		}

		public void LoadGrid()
		{
			dataGridView1.DataSource = _productDal.GetAll();
		}

		public void SearchProduct(string key)
		{
			dataGridView1.DataSource =_productDal.GetByName(key);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Product product = new Product
			{
				Name = textBox1.Text,
				StockAmount = Convert.ToInt32(textBox2.Text),
				UnitPrice = Convert.ToDecimal(textBox3.Text)
			};

			_productDal.Add(product);
			LoadGrid();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			_productDal.Delete(new Product { 
				Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)				
			});
			LoadGrid();
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
			textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
			textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			_productDal.Update(new Product
			{
				Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
				Name = textBox4.Text,
				UnitPrice = Convert.ToDecimal(textBox5.Text),
				StockAmount = Convert.ToInt32(textBox6.Text)
			});

			LoadGrid();
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{
			SearchProduct(textBox7.Text);

		}

		private void button4_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource =_productDal.Order();
		}
	}
}
