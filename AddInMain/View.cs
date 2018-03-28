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
    /// Class that represent the view of our add-in
    /// </summary>
    class AddInMainView
    {
        /// <summary>
        /// The views ribbon tab
        /// </summary>
        private RibbonTab mRibTab;

        /// <summary>
        /// List to hold all of our buttons.
        /// MAY NOT NEED THIS HERE
        /// </summary>
        //private List<CommandBarButton> mButnList;


        private const string introStr = "Hello, I am a RobotStudio Add-In!";


        /// <summary>
        /// Default Constructor
        /// </summary>
        public AddInMainView()
        {
            mRibTab = new RibbonTab("test","test");
        }

        /// <summary>
        /// Responsible for drawing the components of the view
        /// </summary>
        public void DrawAddIn()
        {
            // Begin UndoStep
            Project.UndoContext.BeginUndoStep("Add Buttons");

            try
            {
                // Create a new tab.
                RibbonTab ribbonTab = new RibbonTab("MyTab", "MyTab");
                // Make tab as active tab
                UIEnvironment.ActiveRibbonTab = ribbonTab;

                // Create a group for buttons
                RibbonGroup ribbonGroup = new RibbonGroup("MyButtons", "MyButton");

                // Create first small button
                CommandBarButton buttonFirst = new CommandBarButton("MyFirstButton", "MyFirstButton");
                buttonFirst.HelpText = "Help text for small button";
                // buttonFirst.Image = Image.FromFile(@"../....); // Set the image for the button
                buttonFirst.DefaultEnabled = true;
                ribbonGroup.Controls.Add(buttonFirst);

                // Include Seperator between buttons
                CommandBarSeparator separator = new CommandBarSeparator();
                ribbonGroup.Controls.Add(separator);

                // Create second button. The largeness of the button is determined by RibbonControlLayout
                CommandBarButton buttonSecond = new CommandBarButton("MySecondButton", "MySecondButton");
                buttonSecond.HelpText = "Help text for large button";

                // Set the image of the button.
                //buttonSecond.Image = Image.FromFile...
                buttonSecond.DefaultEnabled = true;
                ribbonGroup.Controls.Add(buttonSecond);

                // Set the size of the buttons
                RibbonControlLayout[] ribbonControlLayout = { RibbonControlLayout.Small, RibbonControlLayout.Large };
                ribbonGroup.SetControlLayout(buttonFirst, ribbonControlLayout[0]);
                ribbonGroup.SetControlLayout(buttonSecond, ribbonControlLayout[1]);

                // Add ribbon group to ribbon tab
                ribbonTab.Groups.Add(ribbonGroup);

                // Add an event handler
                buttonFirst.UpdateCommandUI += new UpdateCommandUIEventHandler(button_UpdateCommandUI);
                // Add an event handler for pressing the button
                buttonFirst.ExecuteCommand += new ExecuteCommandEventHandler(button_ExecuteCommand);
            }
            catch (Exception ex)
            {
                Project.UndoContext.CancelUndoStep(CancelUndoStepType.Rollback);
                Logger.AddMessage(new LogMessage(ex.Message.ToString()));
            }
            finally
            {
                Project.UndoContext.EndUndoStep();
            }
        }


        /// <summary>
        /// Event handler for a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ExecuteCommand(object sender, ExecuteCommandEventArgs e)
        {
            //Perform any action like creating paths and targets
            Logger.AddMessage(new LogMessage(introStr));
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_UpdateCommandUI(object sender, UpdateCommandUIEventArgs e)
        {
            // This enables the button, instead of "button1.Enabled = true".
            e.Enabled = true;
        }

    }
}
