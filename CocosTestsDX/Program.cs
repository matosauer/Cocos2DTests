using CocosSharp;
using System;

namespace CocosTestsDX
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CCApplication application = new CCApplication(false, new CCSize(600, 400));
            application.ApplicationDelegate = new AppDelegate();

            application.StartGame();
        }
    }


}

