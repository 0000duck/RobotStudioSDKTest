using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ABB.Robotics.RobotStudio.Environment;
using ABB.Robotics.RobotStudio;

namespace AddInMain
{
    /// <summary>
    /// Class containing all of the event handlers needed for the
    /// Add-In's View. This class follows the Singleton pattern.
    /// </summary>
    public class EventManager
    {
        /// <summary>
        /// Test string for when an event is handled
        /// </summary>
        private const string mIntroStr = "Hello, I am a RobotStudio Add-In!";


        /** -------------------------------------------------------------- **/
        /// <summary>
        /// Lambda expression which passes a delegate to the contructor which
        /// calls the singleton constructor.
        /// </summary>
        private static readonly Lazy<EventManager> lazy = new Lazy<EventManager>(
            () => new EventManager());
 
        /// <summary>
        /// 
        /// </summary>
        public static EventManager Instance { get { return lazy.Value; } }
        /** -------------------------------------------------------------- **/

        /// <summary>
        /// Default constructor (private)
        /// </summary>
        private EventManager()
        {
        }



        /// <summary>
        /// Event handler for a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button_ExecuteCommand(object sender, ExecuteCommandEventArgs e)
        {
            //Perform any action like creating paths and targets
            Logger.AddMessage(new LogMessage(mIntroStr));
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button_UpdateCommandUI(object sender, UpdateCommandUIEventArgs e)
        {
            // This enables the button, instead of "button1.Enabled = true".
            e.Enabled = true;
        }

    }
}
