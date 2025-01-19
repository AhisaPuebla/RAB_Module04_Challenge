using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RAB_Module04_Challenge_Starter
{
	internal class App : IExternalApplication
	{
		public Result OnStartup(UIControlledApplication app)
		{
			// 1. Create tab and panel 
			string tabName1 = "Revit Add-in Bootcamp";


            try // - safe version
            {
				app.CreateRibbonTab(tabName1);
			}
			catch (Exception error)
			{
				Debug.Print("Tab already exists. Using existing panel.");
				Debug.Print(error.Message);
			}

			// 2. Create panel
			string PanelName1 = "Scavenger Hunt";
			//RibbonPanel panel1 = app.CreateRibbonPanel(tabName, PanelName1);

            RibbonPanel panel = CreateGetPanel(app, tabName1, PanelName1); // - safe method 

			// 3. Create button data
			PushButtonData buttonData1 = new PushButtonData(
				"Tool 1",
				"Command 1",
				Assembly.GetExecutingAssembly().Location, 
				"RAB_Module04_Challenge_Starter.cmd1"
                );

            PushButtonData buttonData2 = new PushButtonData(
                "Tool 2",
                "Command 2",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd2"
                );

            PushButtonData buttonData3 = new PushButtonData(
                 "Tool 3",
                 "Command 3",
                 Assembly.GetExecutingAssembly().Location,
                 "RAB_Module04_Challenge_Starter.cmd3"
                 );

            PushButtonData buttonData4 = new PushButtonData(
                "Tool 4",
                "Command 4",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd4"
                );

            PushButtonData buttonData5 = new PushButtonData(
                "Tool 5",
                "Command 5",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd5"
                );

            PushButtonData buttonData6 = new PushButtonData(
                "Tool 6",
                "Command 6",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd6"
                );

            PushButtonData buttonData7 = new PushButtonData(
                "Tool 7",
                "Command 7",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd7"
                );

            PushButtonData buttonData8 = new PushButtonData(
                "Tool 8",
                "Command 8",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd8"
                );

            PushButtonData buttonData9 = new PushButtonData(
                "Tool 9",
                "Command 9",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd9"
                );

            PushButtonData buttonData10 = new PushButtonData(
                "Tool 10",
                "Command 10",
                Assembly.GetExecutingAssembly().Location,
                "RAB_Module04_Challenge_Starter.cmd10"
                );


            //a - push buttons
            PushButton button1 = panel.AddItem(buttonData1) as PushButton;
            PushButton button2 = panel.AddItem(buttonData2) as PushButton;
            // images
            buttonData1.LargeImage = ConvertToImageSource(Properties.Resources._1_32x32);
            buttonData2.LargeImage = ConvertToImageSource(Properties.Resources._2_32x32); // ??


            //b - stacked row
            panel.AddStackedItems(buttonData3, buttonData4, buttonData5);
            // images 
            buttonData3.Image = ConvertToImageSource(Properties.Resources._3_16x16);
            buttonData4.Image = ConvertToImageSource(Properties.Resources._4_16x16);
            buttonData5.Image = ConvertToImageSource(Properties.Resources._5_16x16);

            //c - split button
            SplitButtonData splitButtonData = new SplitButtonData("SplitButton", "Split\rButton");
            SplitButton splitButton = panel.AddItem(splitButtonData) as SplitButton;
            splitButton.AddPushButton(buttonData6);
            splitButton.AddPushButton(buttonData7);
            // images
            buttonData6.Image = ConvertToImageSource(Properties.Resources._6_32x32);
            buttonData7.Image = ConvertToImageSource(Properties.Resources._7_32x32);

            //d - pull down button
            PulldownButtonData pulldownButtonData = new PulldownButtonData("More tools", "Pulldown\rButton");
            PulldownButton pulldownButton = panel.AddItem(pulldownButtonData) as PulldownButton;
            pulldownButton.AddPushButton(buttonData8);
            pulldownButton.AddPushButton(buttonData9);
            pulldownButton.AddPushButton(buttonData10);
            // images
            pulldownButtonData.LargeImage = ConvertToImageSource(Properties.Resources._8_32x32);





            return Result.Succeeded;
		}

        private RibbonPanel CreateGetPanel(UIControlledApplication app, string tabName1, string panelName1)
        {
            //look for panel in tab
            foreach (RibbonPanel panel in app.GetRibbonPanels(tabName1))
            {
                if (panel.Name == panelName1)
                {
                    return panel;
                }

            }
            // panel not found, create it
            //RibbonPanel returnPanel = app.CreateRibbonPanel(tabName1, panelName1);
            //return returnPanel;

            return app.CreateRibbonPanel(tabName1, panelName1);
        }

        public BitmapImage ConvertToImageSource(byte[] imageData)
        {
            using (MemoryStream mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                BitmapImage bmi = new BitmapImage();
                bmi.BeginInit();
                bmi.StreamSource = mem;
                bmi.CacheOption = BitmapCacheOption.OnLoad;
                bmi.EndInit();

                return bmi;
            }
        }

        public Result OnShutdown(UIControlledApplication a)
		{
			return Result.Succeeded;
		}
	}

}
