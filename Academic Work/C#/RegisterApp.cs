// File:            RegisterChangeCalculatorApp.cs
// Programmer :     Mason Machart


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG5
{
    static class ChangeCalculatorApp
    {
        /* The logic in this app lives within the form class. The purpose of
         * this app is to provide a 'user friendly' GUI that will tell the user
         * how to break down the change for a customer in a cash transaction.
         * The user inputs the transaction total and the amount tendered and 
         * the app returns the smalles nummber of one-dollar bills and coins
         * needed to make the change for the customer
         */
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
