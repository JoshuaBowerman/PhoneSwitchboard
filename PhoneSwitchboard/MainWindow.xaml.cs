using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace PhoneSwitchboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        private static System.Timers.Timer aTimer;


        public MainWindow()
        {


            InitializeComponent();

            // Create a timer with a 100 ms interval.
            aTimer = new System.Timers.Timer(100);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += TimerEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            Data_dial1.Text = "";
            Data_dial2.Text = "";
            Data_dial3.Text = "";
        }

        /* Interperites a string coming from the microcontroller
         * and updates the ui accordingly
         * 
         *  ### DOES NOT DO ANYTHING IN RESPONSE ###
         *  ### ALL LOGIC IS DONE IN BoardInterface ###
         *  
         * message arguments are seperated by the "|" symbol
         * 
         * INCOMING:
         * 
         * layout of a message
         *  Command * v1      * v2     *  v3        * Description
         * ****************************************************
         *  OH      * Circuit *        *            * Received when a circuit is taken off the hook
         *  H       * Circuit *        *            * Circuit closed, phone back on hook
         *  C       * Line    * Number *            * A handset on "Line" is dialing a number "Number" but is not yet complete
         *  NC      * Line    * Number *            * A handset on "Line" has dialed a number "Number"
         *  RL      * Circuit * Circuit* Line       * Response to the line query command, returns circuit numbers of both connected circuits or 0 is unconnected
         *  RT      * Seconds * Line   *            * Response to the time query command, returns time active in seconds of a particular line
         *  
         *  Example:
         *  
         *  RL|5|2|1     ===>    is a response to a previous querry, says line 1 is connected to circuit 5, and circuit 2
         *  C|2|12345    ===>    line 2 is dialing 12345, it is not done dialing
         *  NC|3|1234567 ===>    line 3 has dialed 1234567, it has completed dialing
         */
        public void input(string input)
        {

        }


        public static void TimerEvent(Object source, ElapsedEventArgs e)
        {

        }


    }
}
