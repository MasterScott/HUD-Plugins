using Turbo.Plugins.Default;
 
namespace Turbo.Plugins.CB
{
    public class IndicateMyselfPlugin : BasePlugin, IInGameWorldPainter
    {
		public WorldDecoratorCollection IndicateMyselfDecorator { get; set; }
		
        public IndicateMyselfPlugin()
        {
            Enabled = true;        
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
			
			IndicateMyselfDecorator = new WorldDecoratorCollection(
				new GroundCircleDecorator(Hud) {
                    Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 6.0f),
                    Radius = 0.3f	
                },
				new GroundCircleDecorator(Hud) {
                    Brush = Hud.Render.CreateBrush(255,255,255, 255, 4.0f),
                    Radius = 0.7f	
                }
			);
        }
 
        public void PaintWorld(WorldLayer layer)
        {
            if (Hud.Game.IsInTown) return;

            var me = Hud.Game.Me;
            IndicateMyselfDecorator.Paint(layer, me, me.FloorCoordinate, null);        
        }       
    } //Сlass
}