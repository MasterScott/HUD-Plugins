using Turbo.Plugins.Default;

namespace Turbo.Plugins.CB
{

    public class MyCustomizerPlugin : BasePlugin, ICustomizer
    {
		public float OffsetX { get; set; } //Need to customize GoblinPlugin
		public float OffsetY { get; set; } //Need to customize GoblinPlugin

        public MyCustomizerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        // "Customize" methods are automatically executed after every plugin is loaded.
        // So these methods can use Hud.GetPlugin<class> to access the plugin instances' public properties (like decorators, Enabled flag, parameters, etc)
        // Make sure you test the return value against null!
        
		public void Customize()
		
        {
			// Default PLUGIN CUSTOMIZATION:
			Hud.GetPlugin<InventoryAndStashPlugin>().NotGoodDisplayEnabled = false; //Убираем пометку вещей для продажи серым // turn off sell darkening
			Hud.TogglePlugin<DamageBonusPlugin>(false); //Убираем полоску с типами урона под сферой жизней
			Hud.TogglePlugin<TopMonsterHealthBarPlugin>(false); //disable big green line at top ?
			Hud.TogglePlugin<AttributeLabelListPlugin>(false); //убираем полосу над скиллами
			Hud.TogglePlugin<PlayerBottomBuffListPlugin>(false); //убираем прок колец под персом
			Hud.TogglePlugin<MiniMapLeftBuffListPlugin>(false); //відключаємо шрайни біля мапи зліва
			//Hud.TogglePlugin<OtherPlayersPlugin>(false); //відключаєм імена гравців в мультиплеєрі бо юзаю свій OtherPlayersPluginCustom
			Hud.GetPlugin<OriginalSkillBarPlugin>().SkillPainter.EnableSkillDpsBar = false; // disable dps on skill bar
			Hud.GetPlugin<OriginalSkillBarPlugin>().SkillPainter.EnableDetailedDpsHint = false; // disable dps on skill bar
			//Hud.TogglePlugin<ConventionOfElementsBuffListPlugin>(false); //убираем отображение кольца стихий   
			Hud.TogglePlugin<MultiplayerExperienceRangePlugin>(true); // if you want to enable this plugin then change 'false' to 'true' or just comment out the entire line, because all plugins are enabled by default
			//Hud.GetPlugin<InventoryAndStashPlugin>().CanCubedEnabled = false; //Убираем отметку о возможности поместить в куб
			Hud.TogglePlugin<StashPreviewPlugin>(false); //Убираем предпросмотр в сундуке
			Hud.TogglePlugin<ResourceOverGlobePlugin>(false); //Убираем значения на сферах ресурсов
			Hud.TogglePlugin<SkillRangeHelperPlugin>(false); //Убираем отображение радиуса скиллов
			//Hud.TogglePlugin<GameInfoPlugin>(false); //Убираем отображение времени и ip сервера
			//Hud.TogglePlugin<NetworkLatencyPlugin>(false); //Убираем цифровое отображение качества сетевого соединения
			//Hud.TogglePlugin<NotifyAtRiftPercentagePlugin>(false); //Убираем отображение процентов рифта по центру экрана
			//Hud.TogglePlugin<ExperienceOverBarPlugin>(false); //Убираем отображение опыта на полоске
			Hud.TogglePlugin<PortraitBottomStatsPlugin>(false); //Убираем отображение числа под портретами
			//Hud.TogglePlugin<EliteMonsterAffixPlugin>(false); //Убираем описание уникальных монстров
			//Hud.TogglePlugin<DangerousMonsterPlugin>(false); //Убираем описание опасных монстров
			//Hud.GetPlugin<ShrinePlugin>().HealingWellDecorator.Enabled = false; //Убираем отображение колодцев жизней
			//Hud.GetPlugin<ItemsPlugin>().NormalKeepDecorator.Enabled = false; //Gray items decorator disable (on the map?)
			//Hud.GetPlugin<ItemsPlugin>().MagicKeepDecorator.Enabled = false; //Blue items decorator disable (on the map?)
			//Hud.GetPlugin<ItemsPlugin>().RareKeepDecorator.Enabled = false; //Yellow items decorator disable (on the map?)
			//Hud.GetPlugin<ItemsPlugin>().BookDecorator.Enabled = false; //Bookdecorator disable
			//Hud.TogglePlugin<PickupRangePlugin>(false); //disable pickup range
			//Hud.TogglePlugin<GoblinPlugin>(false); //disable default GoblinPlugin
			Hud.TogglePlugin<BloodShardPlugin>(false); //Викл. Кровав осколк
			Hud.TogglePlugin<InventoryFreeSpacePlugin>(false); //Викл. вільне місце в сумці
			Hud.GetPlugin<GameInfoPlugin>().ServerIpAddressDecorator.Enabled = true;
			Hud.GetPlugin<GameInfoPlugin>().GameClockDecorator.TextFont = Hud.Render.CreateFont("Calibri", 9.5f, 200, 255, 234, 137, false, false, true);
			Hud.GetPlugin<InventoryAndStashPlugin>().NotGoodDisplayEnabled = false;
			
			// [v7.1] [ENGLISH] [Gigi] EliteBarPlugin CUSTOMIZATION http://turbohud.freeforums.net/post/32610/thread
			Hud.GetPlugin<Gigi.EliteBarPlugin>().ShowRareMinions = false;
			Hud.GetPlugin<Gigi.EliteBarPlugin>().ShowDebuffAndCC = false;
			Hud.GetPlugin<Gigi.EliteBarPlugin>().MissingHighlight = true;
			Hud.GetPlugin<Gigi.EliteBarPlugin>().JuggernautHighlight = false;
			Hud.GetPlugin<Gigi.EliteBarPlugin>().CircleNonIllusion = false;
			Hud.GetPlugin<Gigi.EliteBarPlugin>().ShowBossHitBox = false;
			Hud.RunOnPlugin<Gigi.EliteBarPlugin>(plugin => {
                //plugin.BossBrush = Hud.Render.CreateBrush(255, 100, 100, 100, 0); //different color on boss bar
                plugin.XPos = Hud.Window.Size.Width * 0.150f;                       //set EliteBar to XPos	
                plugin.YPos = Hud.Window.Size.Height * 0.0010f;                     //set EliteBar to YPos
				plugin.DisplayAffix.Add(MonsterAffix.Illusionist, "Ілюзіоніст");
                plugin.DisplayAffix.Add(MonsterAffix.Juggernaut, "Джагернаут");
                plugin.DisplayAffix.Add(MonsterAffix.Arcane, "Аркана");
                plugin.DisplayAffix.Add(MonsterAffix.Teleporter, "Телепорт");
				plugin.DisplayAffix.Add(MonsterAffix.Shielding, "Щит");
				plugin.DisplayAffix.Add(MonsterAffix.FireChains, "Ланцюги");
            });
            
            // [v7.1] [INTERNATIONAL] [Jack] DoorsPlugin CUSTOMIZATION http://turbohud.freeforums.net/post/31619/thread
            Hud.RunOnPlugin<Jack.Actors.DoorsPlugin>(plugin => {
                plugin.DoorsDecorators.ToggleDecorators<GroundLabelDecorator>(false);
                plugin.BreakablesDoorsDecorators.ToggleDecorators<GroundLabelDecorator>(false);
                plugin.BridgesDecorators.ToggleDecorators<GroundLabelDecorator>(false);
            });
			
			// All Shrines Decorator  не вкористовується, оскільки тепер тема від Styckz
			/* Hud.RunOnPlugin<ShrinePlugin>(plugin =>   
            {
                plugin.AllShrineDecorator.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 8f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                });
            }); */  
			
            
            // Default PLUGIN CUSTOMIZATION: BannerPlugin
			var bannerPlugin = Hud.GetPlugin<BannerPlugin>(); 
				if (bannerPlugin != null) 
					{ 
						bannerPlugin.Decorator.Add(new GroundCircleDecorator(Hud)
							{ 
								Brush = Hud.Render.CreateBrush(178, 255, 255, 255, 8),
								Radius = 30,
								RadiusTransformator = new StandardPingRadiusTransformator(Hud, 300),
							});
						
						bannerPlugin.Decorator.Add(new MapShapeDecorator(Hud)
							{
								Brush = Hud.Render.CreateBrush(178, 0, 255, 0, 3),
								ShapePainter = new CircleShapePainter(Hud),
								Radius = 8, 
								RadiusTransformator = new StandardPingRadiusTransformator(Hud, 250),
							}); 
					}
			// Default PLUGIN CUSTOMIZATION: BannerPlugin with Jack Decorator		
			Hud.RunOnPlugin<BannerPlugin>(plugin => {  
                plugin.Decorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 8f, 255, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    TextFunc = () => "ПРАПОР",
                });
            });
			
			//Example of gobs customization
			/* Hud.RunOnPlugin<GoblinPlugin>(plugin =>  
            {
                plugin.AllGoblinDecorators().ForEach(decorators =>
                {
                    decorators.ToggleDecorators<MapLabelDecorator>(false);
                    decorators.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
                    {
                        LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                        TextFunc = () => "Custom Text",
                    });
                });
            }); */
			
			//MapCustomLabelDecorator customization to GoblinPlugin with Jack Decorator (disable due to too much info on minimap)
           /* Hud.RunOnPlugin<GoblinPlugin>(plugin => {  
				plugin.AllGoblinDecorators().ForEach(decorators => decorators.ToggleDecorators<GroundLabelDecorator>(false));
                plugin.MalevolentTormentorDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
                	{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "ЛЕГЕНДАРКИ",
					});
					plugin.BloodThiefDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 155, 0, 255, true, false, true),
						TextFunc = () => "КРИВАВІ УЛАМКИ",
					});
					plugin.OdiousCollectorDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 0, 255, 0, true, false, true),
						TextFunc = () => "ЗБИРАЧ МАТЕРІАЛІВ",
					});
					plugin.GemHoarderDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 255, 255, 255, true, false, true),
						TextFunc = () => "ЗБИРАЧ САМОЦВІТІВ",
					});
					plugin.GelatinousDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 0, 0, 255, true, false, true),
						TextFunc = () => "СТУДЕНЬ",
					});
					plugin.GildedBaronDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 255, 240, 0, true, false, true),
						TextFunc = () => "ГОЛДА",
					});
					plugin.InsufferableMiscreantDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 255, 50, 50, true, false, true),
						TextFunc = () => "ЗЛИДЕНЬ",
					});
					plugin.DefaultGoblinDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 150, 150, 150, true, false, true),
						TextFunc = () => "ЖАДІБНИЙ",
					});
					plugin.RainbowGoblinDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "РАЙДУЖНИЙ",
					});
					plugin.MenageristGoblinDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "ДРЕСЕРУВАЛЬНИК",
					});
					plugin.TreasureFiendGoblinDecorator.Add(new Jack.Decorators.MapCustomLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 4, 255, 255, 163, 15, true, false, true),
						TextFunc = () => "ЕКСТРА-ГОБЛІН",
					});
					
				});*/
				
			//GroundLabelDecorator customization to GoblinPlugin with Jack Decorator	
			Hud.RunOnPlugin<GoblinPlugin>(plugin => {  
				plugin.AllGoblinDecorators().ForEach(decorators => decorators.ToggleDecorators<GroundLabelDecorator>(false));
                plugin.MalevolentTormentorDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
                	{
						BackgroundBrush = Hud.Render.CreateBrush(180, 255, 255, 0, 0),
						BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, true, false, true),
						TextFunc = () => "ЛЕГЕНДАРКИ",
						OffsetX = 0f,
						OffsetY = 30f,
					});
				plugin.BloodThiefDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(180, 155, 0, 255, 0),
						BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "КРИВАВІ УЛАМКИ",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					plugin.OdiousCollectorDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(180, 0, 255, 0, 0),
						BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "ЗБИРАЧ МАТЕРІАЛІВ",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					plugin.GemHoarderDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(180, 255, 255, 255, 0),
						BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 247, 131, 7, true, false, true),
						TextFunc = () => "ЗБИРАЧ САМОЦВІТІВ",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					plugin.GelatinousDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(180, 0, 0, 255, 0),
						BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "СТУДЕНЬ",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					plugin.GildedBaronDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(180, 255, 240, 0, 0),
                        BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, true, false, true),
						TextFunc = () => "ГОЛДА",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					plugin.InsufferableMiscreantDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(180, 255, 50, 50, 0),
                        BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "ЗЛИДЕНЬ",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					plugin.DefaultGoblinDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(200, 150, 150, 150, 0),
                        BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "ЖАДІБНИЙ",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					plugin.RainbowGoblinDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(180, 255, 255, 0, 0),
                        BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "РАЙДУЖНИЙ",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					plugin.MenageristGoblinDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(180, 255, 255, 0, 0),
                        BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "ДРЕСЕРУВАЛЬНИК",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					plugin.TreasureFiendGoblinDecorator.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
					{
						BackgroundBrush = Hud.Render.CreateBrush(180, 255, 163, 15, 0),
                        BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
						TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, true),
						TextFunc = () => "ЕКСТРА-ГОБЛІН",
						OffsetX = 0f,
						OffsetY = 30f,
					});
					
				});
				
			//OLD map label for all goblins (color coded) \plugins\Jack\Monsters\GoblinPlugin.cs (now disabled due to new GoblinPlugin)
			/* Hud.RunOnPlugin<Jack.Monsters.GoblinPlugin>(plugin =>    
				{
					plugin.MalevolentTormentorDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 0, true, false, true)
					});
					plugin.BloodThiefDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 155, 0, 255, true, false, true)
					});
					plugin.OdiousCollectorDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 0, 255, 0, true, false, true)
					});
					plugin.GemHoarderDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, true, false, true)
					});
					plugin.GelatinousDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 0, 0, 255, true, false, true)
					});
					plugin.GildedBaronDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 240, 0, true, false, true)
					});
					plugin.InsufferableMiscreantDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 50, 50, true, false, true)
					});
					plugin.TreasureGoblinDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 250, 150, 150, true, false, true)
					});
					plugin.RainbowGoblinDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 0, true, false, true)
					});
					plugin.MenageristGoblinDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 0, true, false, true)
					});
					plugin.TreasureFiendGoblinDecorators.Decorators.Add(new MapLabelDecorator(Hud)
					{
						LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 163, 15, true, false, true)
					});
				}); */
				
				
			// Default PLUGIN CUSTOMIZATION: TopLeftBuffListPlugin
			Hud.RunOnPlugin<TopLeftBuffListPlugin>(plugin => {
				
				plugin.PositionX = 0.30f; // Change this to adjust buffbar left or right 
				plugin.PositionY = 0.01f; // Change this to adjust buffbar up or down
    

				plugin.BuffPainter = new BuffPainter(Hud, true)
				{
                Opacity = 1.00f,
                ShowTimeLeftNumbers = true,
                ShowTooltips = false,
				
                TimeLeftFont = Hud.Render.CreateFont("tahoma", 15, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true), // 12 size default Timeleft font, you can adjust it
                StackFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true), // 9 size default Stacks font, you can adjust it
				};
				
				plugin.RuleCalculator.SizeMultiplier = 1.20f;

				plugin.RuleCalculator.Rules.Add(new BuffRule(403471) { IconIndex = null, MinimumIconCount = 1, ShowStacks = true, ShowTimeLeft = true, DisableName = true}); // Taeguk
				plugin.RuleCalculator.Rules.Add(new BuffRule(359583) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true}); // Focus
				plugin.RuleCalculator.Rules.Add(new BuffRule(359583) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true}); // Restraint
				plugin.RuleCalculator.Rules.Add(new BuffRule(312736) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true}); // MONK Dashing Strike Buff
				plugin.RuleCalculator.Rules.Add(new BuffRule(97110) { IconIndex = 4, MinimumIconCount = 1, ShowStacks = true, ShowTimeLeft = true, DisableName = true}); // MONK Assimilation stacks
				plugin.RuleCalculator.Rules.Add(new BuffRule(208594) { IconIndex = 1, MinimumIconCount = 1, ShowStacks = true, ShowTimeLeft = true, DisableName = true}); // WD Gruesome Feast
				plugin.RuleCalculator.Rules.Add(new BuffRule(437711) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true}); // WD 6p Helltooth damage buff
				plugin.RuleCalculator.Rules.Add(new BuffRule(223473) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true}); // Monk Cyclone Strike
            });
			
			
			// Default PLUGIN CUSTOMIZATION: TopRightBuffListPlugin
			Hud.RunOnPlugin<TopRightBuffListPlugin>(plugin => {
				
				plugin.PositionX = 0.62f; // Change this to adjust buffbar left or right
				plugin.PositionY = 0.01f; // Change this to adjust buffbar up or down
    

				plugin.BuffPainter = new BuffPainter(Hud, true)
				{
                Opacity = 1.00f,
                ShowTimeLeftNumbers = true,
                ShowTooltips = false,
				
                TimeLeftFont = Hud.Render.CreateFont("tahoma", 15, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true), // 12 size default Timeleft font, you can adjust it
                StackFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true), // 9 size default Stacks font, you can adjust it
				};
				
				plugin.RuleCalculator.SizeMultiplier = 1.20f;

				plugin.RuleCalculator.Rules.Add(new BuffRule(79528) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // BARB Ignore Pain
				plugin.RuleCalculator.Rules.Add(new BuffRule(402458) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Ingeom
				plugin.RuleCalculator.Rules.Add(new BuffRule(263029) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Conduit
				plugin.RuleCalculator.Rules.Add(new BuffRule(403404) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Conduit in tiered rift
				plugin.RuleCalculator.Rules.Add(new BuffRule(278269) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Enlightened
				plugin.RuleCalculator.Rules.Add(new BuffRule(030477) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Enlightened
				plugin.RuleCalculator.Rules.Add(new BuffRule(278271) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Frenzied
				plugin.RuleCalculator.Rules.Add(new BuffRule(030479) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Frenzied
				plugin.RuleCalculator.Rules.Add(new BuffRule(278270) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Fortune
				plugin.RuleCalculator.Rules.Add(new BuffRule(030478) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Fortune
				plugin.RuleCalculator.Rules.Add(new BuffRule(278268) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Blessed
				plugin.RuleCalculator.Rules.Add(new BuffRule(030476) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Blessed
				plugin.RuleCalculator.Rules.Add(new BuffRule(266258) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Channeling
				plugin.RuleCalculator.Rules.Add(new BuffRule(266254) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Shield
				plugin.RuleCalculator.Rules.Add(new BuffRule(262935) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Power
				plugin.RuleCalculator.Rules.Add(new BuffRule(266271) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Speed
				plugin.RuleCalculator.Rules.Add(new BuffRule(260349) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Empowered
				plugin.RuleCalculator.Rules.Add(new BuffRule(260348) { IconIndex = null, MinimumIconCount = 1, ShowStacks = false, ShowTimeLeft = true, DisableName = true }); // Fleeting
            });
			
			// [v7.1] [INTERNATIONAL] [Xenthalon] SweepingWindStackWarningP CUSTOMIZATION http://turbohud.freeforums.net/post/31626/thread
			Hud.RunOnPlugin<Xenthalon.SweepingWindStackWarningPlugin>(plugin => 
			{
				plugin.EnableInTown = false; // also shows warnings when in town
				plugin.PlayerWarningLabel.Enabled = true;
				plugin.PlayerWarningLabelText = "СТАКИ";
				plugin.RechargeWarningCircle = new WorldDecoratorCollection(
					new GroundCircleDecorator(Hud)
					{
						Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 4.0f),
						Radius = 3,
						RadiusTransformator = new StandardPingRadiusTransformator(Hud, 400)
					}
				);
				plugin.DrainedWarningCircle = new WorldDecoratorCollection(
					new GroundCircleDecorator(Hud)
					{
						Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 4.0f),
						Radius = 3,
						RadiusTransformator = new StandardPingRadiusTransformator(Hud, 400)
					}
				);
			});
			
        } //End of Customize

    } //End of class

} //End of namespace