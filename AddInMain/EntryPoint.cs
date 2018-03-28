using System;
using System.Collections.Generic;
using System.Text;


//	To activate this Add-in you have to copy AddInMain.rsaddin to the Add-In directory,
//  typically C:\Program Files (x86)\Common Files\ABB Industrial IT\Robotics IT\RobotStudio\AddIns

namespace AddInMain
{
    public class EntryPoint
    {
        // This is the entry point which will be called when the Add-in is loaded
        public static void AddinMain()
        {
            // Create the view object
            AddInMainView view = new AddInMainView();

            // Draw the UI
            view.DrawAddIn();
        }
    }
}