using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneSwitchboard
{   

    

    class BoardInterface
    {


        //The Lines of the switchboard
        public static Line[] BoardLines;

        
        public static Queue<String> toProcess;

        /*
         * Called to initialize the Lines and setup the communication with the microcontroller
         * Called from MainWindow
         */
         public static void setup()
        {
            //Initialize the lines
            BoardLines = new Line[3];

            //Initialize the UI Process queue
            //Setup microcontroller communication

        }


        /*
         * Called by the main window, every 200 ms
         */
         public static void tick()
        {
            //read from queue

            //Call process on each line
        }

        /*
         * Takes a integer and formats it for diplay
         * if it has less than 4 digits it returns the number unformatted
         * if it has more than 4 it tries to format it like a standard phone number
         * 
         * Example:
         * 
         * 123        ==>    123
         * 1234       ==>    1234
         * 12345      ==>    (123) 45
         * 1234567890 ==>    (123) 456 - 7890
         */
        public static string formatNumber(int value)
        {
            int digits = value.ToString().Length;

            if(digits > 4)
            {
                string result = "(";
                result += value.ToString().Substring(0, 3);
                result += ") ";


                for(int i = 3; i <= 5; i++)
                {
                    if(value.ToString().Length <= i)
                    {
                        //Reached the end of the number
                        return result;
                    }
                    result += value.ToString().Substring(i, 1);
                }
                if (value.ToString().Length <= 6)
                {
                    //Reached the end of the number
                    return result;
                }
                result += " - ";
                for(int i = 6; i <= 9; i++)
                {
                    if (value.ToString().Length <= i)
                    {
                        //Reached the end of the number
                        return result;
                    }
                    result += value.ToString().Substring(i, 1);
                }
                return result;
                
            }
            else
            {
                return value.ToString();
            }
        }

        /*
         * Send a command to the microcontroller
         * 
         * message arguments are seperated by the "|" symbol
         * 
         * layout of a message
         *  Command * v1      * v2     *  v3        * Description
         *  *****************************************************
         *  CON     * Line    * A OR B * Circuit    * connects a circuit to a line, as either a or b
         *  CL      * Line    *        *            * Disconnects everything from a line
         *  RN      * Circuit * Line   *            * Starts ringing a circuit, will return a OH when awnsered, Line is optional, will cause ringing tone on line, stopping on OH
         *  TI      * Line    *        *            * querry time active on Line, returns RT
         *  LQ      * Line    *        *            * querry line, returns RL
         *  CF      * Circuit *        *            * adds circuit to "lines full" line and disconnects automatically after 15 seconds or H. This is how you would hear "All Circuits Busy"
         *  CCD     * Line    *        *            * Plays Call Cannot Be Completed As Dialed to selected Line. This adds Computer output to line as b and tells pc to play CCD sound, will close circuit after 15 seconds
         */
        public static void command(string command)
        {


        }


        /*
         *Processes a line coming from the microcontroller,
         * Checks Lines and does anything needed
         * 
         *          * layout of a message
         *  Command * v1      * v2     *  v3        * Description
         * ****************************************************
         *  OH      * Circuit *        *            * Received when a circuit is taken off the hook
         *  H       * Circuit *        *            * Circuit closed, phone back on hook
         *  C       * Line    * Number *            * A handset on "Line" is dialing a number "Number" but is not yet complete
         *  NC      * Line    * Number *            * A handset on "Line" has dialed a number "Number"
         *  RL      * Circuit * Circuit* Line       * Response to the line query command, returns circuit numbers of both connected circuits or 0 is unconnected
         *  RT      * Seconds * Line   *            * Response to the time query command, returns time active in seconds of a particular line
         */
        public static void Process(string line)
        {
            //Get the command code from the line
            string commandCode = line.Split('|')[0];


            //Call the appropriate handler
            switch (commandCode)
            {
                case "OH":
                    OH(line);
                    break;
                case "H":
                    H(line);
                    break;
                case "C":
                    C(line);
                    break;
                case "NC":
                    NC(line);
                    break;
                case "RL":
                    RL(line);
                    break;
                case "RT":
                    RT(line);
                    break;
                default:
                    Console.Error.WriteLine("Unknown Command: " + commandCode + ", Line: " + line);
                    break;
            }

            



        }

        public static void OH(string line)
        {

        }
        public static void H(string line)
        {

        }
        public static void C(string line)
        {

        }
        public static void NC(string line)
        {

        }
        public static void RL(string line)
        {

        }
        public static void RT(string line)
        {

        }
    }
}
