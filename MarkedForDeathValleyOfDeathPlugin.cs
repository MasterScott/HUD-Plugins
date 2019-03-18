using Turbo.Plugins.Default;
namespace Turbo.Plugins.CB
{

    public class MarkedForDeathValleyOfDeathPlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection MarkedForDeathDecorator { get; set; }
        public WorldDecoratorCollection CaltropsDecorator { get; set; }
        

        public MarkedForDeathValleyOfDeathPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            CaltropsDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(250, 255, 69, 69, 5),
                    Radius = 15,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 30,
                    TextFont = Hud.Render.CreateFont("tahoma", 14, 255, 255, 255, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 30,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(64,0,0,0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160,255,255,255, 0),
                    Radius = 35,
                }
            );
            
            MarkedForDeathDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(250, 255, 69, 69, 5),
                    Radius = 15,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 15,
                    TextFont = Hud.Render.CreateFont("tahoma", 14, 255, 255, 255, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 15,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(64,0,0,0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160,255,255,255, 0),
                    Radius = 35,
                }
            );
        }

        public void PaintWorld(WorldLayer layer)
        {
            var actors = Hud.Game.Actors;
            foreach (var actor in actors)
            {
                switch ((uint)actor.SnoActor.Sno)
                { 
                   case 230674:
                        MarkedForDeathDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                   case 196030:
                        CaltropsDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                }
            }
        }

    }

} //End