using System;
using System.Collections.Generic;
using System.Text;

//using ABB.Robotics.Math;
//using ABB.Robotics.RobotStudio;
//using ABB.Robotics.RobotStudio.Environment;
//using ABB.Robotics.RobotStudio.Stations;

//	To activate this Add-in you have to copy AddInMain.rsaddin to the Add-In directory,
//  typically C:\Program Files (x86)\Common Files\ABB Industrial IT\Robotics IT\RobotStudio\AddIns

namespace AddInMain
{
    public class EntryPoint
    {
        private const string introStr = "Hello, I am a RobotStudio Add-In!";


        // This is the entry point which will be called when the Add-in is loaded
        public static void AddinMain()
        {
            ABB.Robotics.RobotStudio.Logger.AddMessage(new ABB.Robotics.RobotStudio.LogMessage(introStr));
        }
    }
}