/* Group Project 1 ITSE 1302
 * Micah Ellet
 * Kenneth Rapp
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Group_Project1
{
    public partial class Form1 : Form
    {

        // current order
        private List<MenuItem> Order = new List<MenuItem>();

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbT_Type.SelectedIndex = 0;
            cbG_Type.SelectedIndex = 0;
            cbB_Type.SelectedIndex = 0;
            radT_Whole.Checked = true;
            radG_Whole.Checked = true;


        }

        private void radT_Whole_CheckedChanged(object sender, EventArgs e)
        {
            lblT_2.Visible = true;
            numT_2.Visible = true;
            lblT_1.Text = "Medium";
            numT_1.Value = 0;
            numT_2.Value = 0;
        }

        private void radT_BySlice_CheckedChanged(object sender, EventArgs e)
        {
            lblT_2.Visible = false;
            numT_2.Visible = false;
            lblT_1.Text = "Slices";
            numT_1.Value = 0;
            numT_2.Value = 0;
        }

        private void radG_Whole_CheckedChanged(object sender, EventArgs e)
        {
            lblG_2.Visible = true;
            numG_2.Visible = true;
            lblG_1.Text = "Medium";
            numG_1.Value = 0;
            numG_2.Value = 0;
        }

        private void radG_BySlice_CheckedChanged(object sender, EventArgs e)
        {
            lblG_2.Visible = false;
            numG_2.Visible = false;
            lblG_1.Text = "Slices";
            numG_1.Value = 0;
            numG_2.Value = 0;
        }

        private void pricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Prices = new Form2();
            Prices.ShowDialog();
        }


        // add traditional
        private void btnT_Add_Click(object sender, EventArgs e)
        {

            // get toppings
            List<String> Toppings = new List<String>();

            for (int i = 0; i < chkListToppings.Items.Count; i++) {
                if (chkListToppings.GetItemCheckState(i) == CheckState.Checked)
                {
                    Toppings.Add(chkListToppings.Items[i].ToString());
                }
            }

            Toppings.Sort();

            if (radT_Whole.Checked) 
            {

                if (numT_1.Value == 0 && numT_2.Value == 0)
                    MessageBox.Show("Oops, you did not tell us how many you wanted!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (numT_1.Value > 0)
                    {
 
                        decimal Price = 0.00M;

                        if (cbT_Type.Text == "Plain")
                        {
                            Price = 8.00M;
                        }
                        else if (cbT_Type.Text == "White Pizza"){
                            Price = 9.00M;
                        }
                        else if (cbT_Type.Text == "Lion's Roar Specialty")
                        {
                            Price = 9.00M;
                        }

                        AddNewOrderItem(new MenuItem(numT_1.Value, "Medium", cbT_Type.Text, Price, Toppings));
                        DisplayList(Order, lbOrder);
                        
                    }
                    if (numT_2.Value > 0)
                    {
                          decimal Price = 0.00M;

                        if (cbT_Type.Text == "Plain")
                        {
                            Price = 10.00M;
                        }
                        else if (cbT_Type.Text == "White Pizza")
                        {
                            Price = 12.00M;
                        }
                        else if (cbT_Type.Text == "Lion's Roar Specialty")
                        {
                            Price = 12.00M;
                        }

                        AddNewOrderItem(new MenuItem(numT_2.Value, "Large", cbT_Type.Text, Price, Toppings));
                        DisplayList(Order, lbOrder);
                        
                    }
                }
            } 
            else
            {
                if (numT_1.Value == 0)
                    MessageBox.Show("Oops, you did not tell us how many you wanted!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
 
                    decimal Price = 0.00M;

                    if (cbT_Type.Text == "Plain")
                    {
                        Price = 1.50M;
                    }
                    else if (cbT_Type.Text == "White Pizza")
                    {
                        Price = 1.75M;
                    }
                    else if (cbT_Type.Text == "Lion's Roar Specialty")
                    {
                        Price = 2.00M;
                    }

                    AddNewOrderItem(new MenuItem(numT_1.Value, "Slice", cbT_Type.Text, Price, Toppings));
                    DisplayList(Order, lbOrder);
                    
                }
            } 

        }

        // add gourmet
        private void btnG_Add_Click(object sender, EventArgs e)
        {
            // get toppings
            List<String> Toppings = new List<String>();

            for (int i = 0; i < chkListToppings.Items.Count; i++)
            {
                if (chkListToppings.GetItemCheckState(i) == CheckState.Checked)
                {
                    Toppings.Add(chkListToppings.Items[i].ToString());
                }
            }

            Toppings.Sort();

            if (radG_Whole.Checked)
            {
                if (numG_1.Value == 0 && numG_2.Value == 0)
                    MessageBox.Show("Oops, you did not tell us how many you wanted!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (numG_1.Value > 0)
                    {
                        decimal Price = 0.00M;
                        
                        if (cbG_Type.Text == "BBQ Chicken")
                        {
                            Price = 8.00M;
                        }
                        else if (cbG_Type.Text == "Cheeseburger Pizza")
                        {
                            Price = 8.00M;
                        }
                        else if (cbG_Type.Text == "Buffalo Chicken")
                        {
                            Price = 8.00M;
                        }
                        else if (cbG_Type.Text == "The Works")
                        {
                            Price = 8.00M;
                        }

                        AddNewOrderItem(new MenuItem(numG_1.Value, "Medium", cbG_Type.Text, Price, Toppings));
                        DisplayList(Order, lbOrder);
                        
                    }
                    if (numG_2.Value > 0)
                    {
                         decimal Price = 0.00M;

                        if (cbG_Type.Text == "BBQ Chicken")
                        {
                            Price = 12.00M;
                        }
                        else if (cbG_Type.Text == "Cheeseburger Pizza")
                        {
                            Price = 12.00M;
                        }
                        else if (cbG_Type.Text == "Buffalo Chicken")
                        {
                            Price = 12.00M;
                        }
                        else if (cbG_Type.Text == "The Works")
                        {
                            Price = 13.00M;
                        }

                        AddNewOrderItem(new MenuItem(numG_2.Value, "Large", cbG_Type.Text, Price, Toppings));
                        DisplayList(Order, lbOrder);
                        
                    }
                }
            }
            else
            {
                if (numG_1.Value == 0)
                    MessageBox.Show("Oops, you did not tell us how many you wanted!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                     decimal Price = 0.00M;

                    if (cbG_Type.Text == "BBQ Chicken")
                    {
                        Price = 2.00M;
                    }
                    else if (cbG_Type.Text == "Cheeseburger Pizza")
                    {
                        Price = 2.00M;
                    }
                    else if (cbG_Type.Text == "Buffalo Chicken")
                    {
                        Price = 2.00M;
                    }
                    else if (cbG_Type.Text == "The Works")
                    {
                        Price = 2.50M;
                    }

                    AddNewOrderItem(new MenuItem(numG_1.Value, "Slice", cbG_Type.Text, Price, Toppings));
                    DisplayList(Order, lbOrder);
                   
                }
            } 

        }

        // add beverages
        private void btnB_Add_Click(object sender, EventArgs e)
        {
    
            if (numBev.Value == 0)
                MessageBox.Show("Oops, you did not tell us how many you wanted!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
   
                decimal Price = 0.00M;
                string Size = "Regular";

                if (cbB_Type.Text == "Water") {
                    Price = 0.00M;
                }
                else if (cbB_Type.Text == "Fountain Soda (S)")
                {
                    Price = 0.75M;
                    Size = "Small";
                }
                else if (cbB_Type.Text == "Fountain Soda (M)")
                {
                    Price = 1.25M;
                    Size = "Medium";
                }
                else if (cbB_Type.Text == "Fountain Soda (L)")
                {
                    Price = 2.00M;
                    Size = "Large";

                }
                else if (cbB_Type.Text == "Bottled Soda")
                {
                    Price = 1.75M;
                    Size = "Regular";
                }
                else if ((cbB_Type.Text == "Iced Tea (S)") || (cbB_Type.Text == "Lemonade (S)") || (cbB_Type.Text == "Juice (S)"))
                {
                    Price = 1.00M;
                    Size = "Small";
                }
                else if ((cbB_Type.Text == "Iced Tea (M)") || (cbB_Type.Text == "Lemonade (M)") || (cbB_Type.Text == "Juice (M)"))
                {
                    Price = 1.50M;
                    Size = "Medium";
                }
                else if (( cbB_Type.Text == "Iced Tea (L)") || (cbB_Type.Text == "Lemonade (L)") || (cbB_Type.Text == "Juice (L)"))
                {
                    Price = 2.00M;
                    Size = "Large";
                }

                AddNewOrderItem(new MenuItem(numBev.Value, Size, cbB_Type.Text, Price));
                DisplayList(Order, lbOrder);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbOrder.SelectedIndex > -1)
            {
                
                //Remove something
                RemoveOrderItem();
                DisplayList(Order, lbOrder);
            }
        }

        private void clearOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            lbOrder.Items.Clear();
            numT_1.Value = 0;
            numT_2.Value = 0;
            numG_1.Value = 0;
            numG_2.Value = 0;
            numBev.Value = 0;
            cbT_Type.SelectedIndex = 0;
            cbG_Type.SelectedIndex = 0;
            cbB_Type.SelectedIndex = 0;
            
            //Clear all data
            Order.Clear();
        }

        private void completeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show complete order + total price, etc.

            if (Order.Count() > 0)
            {

                DialogResult Result = MessageBox.Show(CurrentOrderTotal(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    //Complete order
                    MessageBox.Show("Thank you for your order!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("You haven't ordered anything... ");
            }
        }

        // get the checked toppings items from the checklist
        // as a list of strings.
        private List<String> GetToppingsAsList()
        {
            List<String> Toppings = new List<String>();

            for (int i = 0; i <= chkListToppings.Items.Count - 1; i++)
            {
                if (chkListToppings.GetItemCheckState(i) == CheckState.Checked)
                {
                    Toppings.Add(chkListToppings.Items[i].ToString());
                }
            }
            
            return Toppings;
        }

        // display the contents of a menu list in a list box
        private void DisplayList(List<MenuItem> M, System.Windows.Forms.ListBox B)
        {
            B.Items.Clear();

            for (int i = 0; i < M.Count(); i++)
            {
                string MenuLine =  M[i].Name;
                MenuLine += " x " +M[i].Quantity.ToString();
                MenuLine += " - " +M[i].Size;
                MenuLine += " "   +M[i].Cost.ToString("c");
                
                if (M[i].getNumToppings() > 0)
                {
                    MenuLine += " with :";

                    foreach (string t in M[i].GetToppings())
                    {
                        MenuLine += t + ", ";
                    }
                }

                B.Items.Add(MenuLine);
            }
        }

        
        /* returns order pricing information as a string */
        private string CurrentOrderTotal() {
            
            decimal cost = 0;
            decimal delivery = 0;
            decimal student_discount = 0;
            decimal sales_tax_applied = 0;
            decimal cost_toppings = 0;
            
            for (int i = 0; i < Order.Count(); i++) {
                
                cost += (Order[i].Cost * Order[i].Quantity);
               
                // apply toppings
               
                 if (Order[i].getNumToppings() > 0)
                {
                    cost_toppings += (0.25M * Order[i].getNumToppings() * Order[i].Quantity);
                    cost += cost_toppings;
                }
            }

            // apply delivery cost (pre-tax)
            if (cost <= 10.00M)
            {
                delivery = 3.00M;
            }
            else if (cost <= 30.00M)
            {
                delivery = 2.00M;
            }
            
            // if student, apply .10 discount
            if (cbDiscount.Checked == true)
            {
                student_discount = (cost * 0.10M);
                cost -= student_discount;
            }

            // add .06 sales tax
            sales_tax_applied = (cost * 0.06M);

            string total = "Pre-Tax: "+ (cost + delivery).ToString("c");

            if (cost_toppings > 0M)
            {
                total += "\n Toppings " + cost_toppings.ToString("c");
            }

            if (delivery > 0M)
            {
                total += "\n Delivery: " + delivery.ToString("c");
            }
            if (student_discount > 0M)
            {
                total += "\n Discount: " + student_discount.ToString("c");
            }

            total += "\n Sales Tax: " + sales_tax_applied.ToString("c");
            total += "\n Your Final Cost: " + (cost + delivery + sales_tax_applied ).ToString("c");
            return total;
        }

        // add a new item to the order list
        private void AddNewOrderItem(MenuItem Item) {
            
            // iterate each Order item to find a match
            for(int i=0; i<Order.Count(); i++){

                // match the md5 hashes for each order. 
                if (Item.Signature == Order[i].Signature) { 
                    // they're the same - increment and return
                    Order[i].Quantity += Item.Quantity;
                    Order[i].ReHash(); // rebuild the md5 signature
                    return;
                }
            } 
            
            Order.Add(Item); // add the item as a new row
        }

        // remove an item from the order list 
        private void RemoveOrderItem() {
            if (lbOrder.SelectedIndex != -1)
            {
                // decrement if more than one ordered
                if (Order[lbOrder.SelectedIndex].Quantity > 1)
                {
                    Order[lbOrder.SelectedIndex].Quantity--;
                }
                else
                {
                    Order.RemoveAt(lbOrder.SelectedIndex); // or remove all
                }
            }
        }

        // remove all of a single selected item
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (lbOrder.SelectedIndex != -1)
            {
                Order.RemoveAt(lbOrder.SelectedIndex);
                DisplayList(Order, lbOrder);
            }
        }

        // uncheck all the items on the toppings menu
        private void btnClearToppings_Click(object sender, EventArgs e)
        {
            foreach (int i in chkListToppings.CheckedIndices)
            {
                chkListToppings.SetItemCheckState(i, CheckState.Unchecked);
            }

            // clear toppings for selected item
            if (lbOrder.SelectedIndex != -1) {
                Order[lbOrder.SelectedIndex].SetToppings(GetToppingsAsList());
                Order[lbOrder.SelectedIndex].ReHash();
                DisplayList(Order, lbOrder);
            }

        }

        // reapply the selected toppings to the current selected order item
        private void btnResetToppings_Click(object sender, EventArgs e)
        {
            if (lbOrder.SelectedIndex != -1)
            {
                Order[lbOrder.SelectedIndex].SetToppings(GetToppingsAsList());
                Order[lbOrder.SelectedIndex].ReHash();
                DisplayList(Order, lbOrder);
            }
            else
            {
                MessageBox.Show("please select an order item to update the toppings");
            }
        }

        // add one more of the selected item 
        private void btnAddOne_Click(object sender, EventArgs e)
        {
            if (lbOrder.SelectedIndex != -1)
            {
                Order[lbOrder.SelectedIndex].Quantity++;
                DisplayList(Order, lbOrder);
            }
        }


    }
}
