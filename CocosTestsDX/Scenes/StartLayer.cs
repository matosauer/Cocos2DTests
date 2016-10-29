using CocosSharp;

namespace CocosTestsDX.Scenes
{
    public class StartLayer : CCLayer
	{
        CCParticleSystem part;

        public StartLayer()
            : base()
        {
            
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            InitializeListeners();

            var label = new CCLabel("Tap", "Arial", 32, CCLabelFormat.SystemFont)
            {
                Position = new CCPoint(50, VisibleBoundsWorldspace.Size.Height - 50),
                Color = new CCColor3B(new CCColor4B(0.208f, 0.435f, 0.588f, 1.0f)),
                HorizontalAlignment = CCTextAlignment.Left,
                VerticalAlignment = CCVerticalTextAlignment.Center,
                AnchorPoint = CCPoint.AnchorMiddle
            };

            AddChild(label);

            AddSun();
            p1();
            p2();
        }

        private void InitializeListeners()
        {
            InitializeTouchListener();
            InitializeKbdListener();
        }

        void InitializeKbdListener()
        {
            var kbdListener = new CCEventListenerKeyboard();

            kbdListener.OnKeyPressed = (keyboardEvent) =>
            {
                if (keyboardEvent.Keys == CCKeys.Escape)
                {
                   this.Window.Application.Game.Exit();
                }
            };

            AddEventListener(kbdListener, this);
        }

        void InitializeTouchListener()
        {
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = (touches, ccevent) =>
                {
                    if (touches.Count > 0)
                    {
                        CCPoint pos = touches[0].Location;

                        Explode(pos);

                    }

                };

            AddEventListener(touchListener, this);
        }

        void Explode(CCPoint pt)
        {
            var explosion = new CCParticleExplosion(pt);
            explosion.TotalParticles = 10;
            explosion.AutoRemoveOnFinish = true;
            AddChild(explosion);
        }

        void AddSun()
        {
            var pos = VisibleBoundsWorldspace.Center;

            //var circleNode = new CCDrawNode();
            //circleNode.DrawSolidCircle(pos, 30.0f, CCColor4B.Yellow);
            //AddChild(circleNode);

            var sun = new CCParticleSun(pos);
            sun.StartColor = new CCColor4F(CCColor3B.Blue);
            sun.EndColor = new CCColor4F(CCColor3B.Yellow);
            AddChild(sun);
        }

        void p1()
        {
            var p = new CCPoint(100,100);

            var s = new CCParticleSmoke(p);

            AddChild(s);
        }

        void p2()
        {
            //http://particle2dx.com/

            //motion:
            // emissionRate : 20 ili 10
            // posVar : 50 ; 50

            //template
            // damage1

             var p = new CCPoint(200,100);

             var s = new CCParticleSystemQuad("particle_texture.plist");
             s.Position = p;

            AddChild(s);
        }
    }
}
