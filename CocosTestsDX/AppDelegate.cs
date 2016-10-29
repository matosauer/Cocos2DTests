using CocosSharp;
using CocosTestsDX.Scenes;

namespace CocosTestsDX
{
    public class AppDelegate : CCApplicationDelegate
    {

        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {
            application.ContentRootDirectory = "Content";
            var windowSize = mainWindow.WindowSizeInPixels;

            //new:
            mainWindow.DisplayStats = true;
            mainWindow.StatsScale = 1;

            // This will set the world bounds to be (0,0, w, h)
            // CCSceneResolutionPolicy.ShowAll will ensure that the aspect ratio is preserved
            CCScene.SetDefaultDesignResolution(600, 400, CCSceneResolutionPolicy.NoBorder); //ShowAll, NoBorder

            // Determine whether to use the high or low def versions of our images
            // Make sure the default texel to content size ratio is set correctly
            // Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
            if (600 < windowSize.Width)
            {
                application.ContentSearchPaths.Add("hd");
                CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
            }
            else
            {
                application.ContentSearchPaths.Add("ld");
                CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
            }

            var startScene = new StartScene(mainWindow);

            mainWindow.RunWithScene(startScene);
        }

        public override void ApplicationDidEnterBackground(CCApplication application)
        {
            application.Paused = true;
        }

        public override void ApplicationWillEnterForeground(CCApplication application)
        {
            application.Paused = false;
        }
    }
}