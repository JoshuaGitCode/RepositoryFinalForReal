using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project
{
    public partial class Form1 : Form
    {
        string filePath = "order.txt";
        string filePathQ = "Q.txt";
        const int SIZE = 500;
        const double TAX = 0.095;
        private int count = 0;
        private string[] itemsNames = new string[SIZE];
        private int[] itemsQuantity = new int[SIZE];
        private Double[] itemPrice = new double[SIZE];
       
       
        public Form1()
        {
            InitializeComponent();
        }

        private void lblSoda1_Click(object sender, EventArgs e)
        {
            if (cboQntSoda1.Text == "")
                MessageBox.Show("Please Choose Quantity");
            else
                lstItemList.Items.Add(lblTitleSoda1.Text + " \t" + lblPriceSoda1.Text + "\t " + cboQntSoda1.Text);
            // Converts 
            itemPrice[count] = double.Parse(lblPriceSoda1.Text);
            itemsQuantity[count] = int.Parse(cboQntSoda1.Text);
            count++;
        }

        private void lblSoda2_Click(object sender, EventArgs e)
        {
            if (cboQntSoda2.Text == "")
                MessageBox.Show("Please Choose Quantity");
            else
                lstItemList.Items.Add(lblTitleSoda2.Text + " \t" + lblPriceSoda2.Text + "\t " + cboQntSoda2.Text);
            // Converts
            itemPrice[count] = double.Parse(lblPriceSoda2.Text);
            count++;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            
            StreamWriter outFile;
            StreamReader inFile;
            lstPrint.Items.Clear();        
            
            if (lstItemList.Items.Count == 0) // ERROR CHECHS ITEMS
                MessageBox.Show("No items, Please Add Items!!");
            else
            {
                outFile = File.CreateText(filePath); // OPENS FILE
                for (int i = 0; i < lstItemList.Items.Count; i++) // FILLS ARRAY WITH TOTAL LIST ITEMS               
                {
                    outFile.WriteLine(itemPrice[i]); // PRICE ONLY
                    outFile.WriteLine(itemsQuantity[i]);
                }
                outFile.Close();// CLOSES FILE
            }


            
            inFile = new StreamReader(filePath); // READS
           
            while (!inFile.EndOfStream) 
            {
                itemPrice[count] = double.Parse(inFile.ReadLine()); // Converts Price
                itemsQuantity[count] = int.Parse(inFile.ReadLine());
                lstPrint.Items.Add(itemPrice[count]); // Displays for Print
                
                count++;                            
            }
           
            inFile.Close();
            lstPrint.Items.Add(itemPrice[0] * itemsQuantity[0]);





        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstItemList.Items.Clear();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lstItemList.SelectedIndex > -1)
                lstItemList.Items.RemoveAt(lstItemList.SelectedIndex);
        }
    }
}
