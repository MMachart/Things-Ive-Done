// File:            Form1.cs
// Programmer :     Mason Machart


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcChangeBtn_Click(object sender, EventArgs e)
        {
            decimal total, tender;
            bool totalIsDec, tenderIsDec, totalIsMoney, tenderIsMoney, allPositive;
            
            // Try to convert the string input to decimal. Store its success in a variable. 
            totalIsDec = Decimal.TryParse(totalTextBox.Text, out total);
            tenderIsDec = Decimal.TryParse(tenderTextBox.Text, out tender);
            allPositive = (total >= 0) && (tender >= total);    // check if both inputs are positive
            totalIsMoney = (total % .01m == 0);                 // Check if both inputs have a max of 2 decimal places
            tenderIsMoney = (tender % .01m == 0);

            // If inputs are decimal and postive
            if (totalIsDec && tenderIsDec && allPositive && totalIsMoney && tenderIsMoney)  
            {
               calcChange(total, tender);                       // Call method with logic in it
            } 
            else
            {
                // Simple 'error handling'
                // If an entry is not a deciaml advise the user to correct the entry
                MessageBox.Show("Please review your entries and make sure to enter a valid monetary " + 
                                "value\n(all values entered are of type x.xx) and that the amount " +
                                "tendered \nis greater than the total.");
            }
        }

        private void calcChange(decimal total, decimal tender)
        {
            decimal change, changeTotal;
            int bills, quarters, dimes, nickels, pennies;

            changeTotal = tender - total;     // Simple change calculation
            change = changeTotal;             // Store change value in variable that can be modified

            // Determine number of bills needed and subtract from the running change total    
            bills = Decimal.ToInt16(Decimal.Divide(change, 1m));
            change -= bills;
            
            // Determine the number of quarters needed and subtract from the leftover change
            quarters = Decimal.ToInt16(Decimal.Divide(change, .25m));
            change -= (decimal)quarters * .25m;
            
            // Determine the number of dimes needed and subtract from the leftover change
            dimes = Decimal.ToInt16(Decimal.Divide(change, .10m));
            change -= (decimal)dimes * .10m;
            
            // Determine the number of nickels needed and subtract from the leftover change
            nickels = Decimal.ToInt16(Decimal.Divide(change, .05m));
            change -= (decimal)nickels * .05m;
            
            // Multiple the leftover change to ge the number of pennies needed
            pennies = Decimal.ToInt16(change * 100m);



            // Output section
            changeTextBox.Text  = "$" + changeTotal.ToString("0.00");  // Output simple change '$x.xx'
            billsTextBox.Text   = bills.ToString();     // Output numbers of bills needed
            quartersTextBox.Text= quarters.ToString();  // Output number of quarters needed
            dimesTextBox.Text   = dimes.ToString();     // Output number of dimes needed
            nickelsTextBox.Text = nickels.ToString();   // Output number of nickels needed
            penniesTextBox.Text = pennies.ToString();   // Output number of pennies needed
        }
    }
}
