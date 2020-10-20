using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iiCarDesign
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDesignCar_Clicked(object sender, EventArgs e)
        {
            // Variables for make, color, condition, and price
            string make = "", color = "", condition = "";
            decimal price = 0m;

            // Pass make by reference into validaiton method to extend scope
            if (MakeIsValid(ref make))
            {
                if (ColorIsValid(ref color))
                {
                    price = GetValidPrice();

                    // If price is greater than -1, we know it is valid
                    if (price > -1)
                    {
                        condition = SetCondition();

                        DisplayCar(make, color, price, condition);
                    }
                }
            }
        
        }


        /// <summary>
        ///  Display the car
        /// </summary>
        /// <param name="make"></param>
        /// <param name="color"></param>
        /// <param name="price"></param>
        /// <param name="condition"></param>
        private void DisplayCar(string make, string color, decimal price, string condition)
        {
            // concatinate the response
            LblResults.Text = $"{condition} {color} {make} for {price.ToString("c")}.";
        }



        /// <summary>
        ///     Set the condition
        /// </summary>
        /// <returns>a string,  "New" or "Used" </returns>
        private string SetCondition()
        {
            // If the switch is turned "on", return new, else return used
            return SwtchCondition.IsToggled ?  "New" : "Used";
        }

        /// <summary>
        ///     Validate the price decimal
        /// </summary>
        /// <returns>Eitehr price or -1</returns>
        private decimal GetValidPrice()
        {
            //  Check if price is a decimal and greater than or equal to zero
            if (decimal.TryParse(EntryPrice.Text, out decimal price) && price >= 0)
            {
                // Return the value of price
                return price;
            }

            else
            {
                // Alert the user that the input is invalid
                DisplayAlert("Invalid Input", "Please enter a positive price for the car", "Close");

                // Return false
                return -1;
            }
        }

        /// <summary>
        ///  Validate the picker "make" string
        /// </summary>
        /// <param name="m"> Set m as user input for car make</param>
        /// <returns>Return true if valid</returns>
        private bool MakeIsValid(ref string m)
        {
            // Check picker input
            if (PckMake.SelectedIndex > -1)
            {
                // Reference extends the scope of the string
                m = PckMake.SelectedItem.ToString();
                return true;
            }

            else
            {
                // Display an alert because make is required
                DisplayAlert("Invalid Input", "Please select a make", "Close");
                // If the input is invalid, return false
                return false;
            }
        }

        /// <summary>
        ///  Validate the picker "color" string
        /// </summary>
        /// <param name="m"> Set m as user input for car color</param>
        /// <returns>Return true if valid</returns>
        private bool ColorIsValid(ref string c)
        {
            // Check picker input
            if (PckColor.SelectedIndex > -1)
            {
                // Reference extends the scope of the string
                c = PckColor.SelectedItem.ToString();
                return true;
            }

            else
            {
                // Display an alert because color is required
                DisplayAlert("Invalid Input", "Please select a color", "Close");
                // If the input is invalid, return false
                return false;
            }
        }

        

    }
}
