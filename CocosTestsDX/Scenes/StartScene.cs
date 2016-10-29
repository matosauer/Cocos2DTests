using CocosSharp;

namespace CocosTestsDX.Scenes
{
    public class StartScene : CCScene
    {
        public StartScene(CCWindow mainWindow)
            : base(mainWindow)
        {
            this.AddChild(new StartLayer());
        } 
    }
}
