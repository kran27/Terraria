// Decompiled with JetBrains decompiler
// Type: Terraria.Main
// Assembly: Terraria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2B842C06-302B-4218-9B94-AD87188E4CC4
// Assembly location: C:\Games\Terraria Proto\0.0.0.0\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Terraria
{
    public class Main : Game
    {

        public static float fps;
        public static bool releaseUncap;

        public const float leftWorld = 0.0f;
        public const float rightWorld = 80000f;
        public const float topWorld = 0.0f;
        public const float bottomWorld = 40000f;
        public const int maxTilesX = 5001;
        public const int maxTilesY = 2501;
        public const int maxTileSets = 12;
        public const int maxWallTypes = 2;
        public const int maxBackgrounds = 3;
        public const int maxDust = 1000;
        public const int maxPlayers = 16;
        public const int maxItemTypes = 27;
        public const int maxItems = 1000;
        public const int maxNPCTypes = 2;
        public const int maxNPCs = 1000;
        public const int maxInventory = 40;
        public const int maxItemSounds = 2;
        public const int maxNPCHitSounds = 1;
        public const int maxNPCKilledSounds = 1;
        public const double dayLength = 40000.0;
        public const double nightLength = 30000.0;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static MouseState mouseState = Mouse.GetState();
        public static MouseState oldMouseState = Mouse.GetState();
        public static KeyboardState keyState = Keyboard.GetState();
        public static bool cheats = false;
        public static bool debugMode = false;
        public static bool godMode = false;
        public static bool dumbAI = false;
        public static bool infiniteReach;
        public static bool releaseDebug;
        public static bool releaseLighting;
        public static bool releaseGodMode;
        public static bool releaseDumbAI;
        public static bool releaseCheats;
        public static bool releaseMovement;
        public static bool releaseInfinite;
        public static bool lastLighting;
        public static bool lastDumbAI;
        public static bool lastGodMode;
        public static bool lastDebug;
        public static bool lastMovement;
        public static bool lastInfinite;
        public static int background = 0;
        public static Color tileColor;
        public static double worldSurface = 10;
        public static bool dayTime = true;
        public static double time = 10000.0;
        public static int moonPhase = 0;
        public static Random rand = new Random();
        public static Texture2D playerHeadTexture;
        public static Texture2D playerBodyTexture;
        public static Texture2D playerLegTexture;
        public static Texture2D[] itemTexture = new Texture2D[27];
        public static Texture2D[] npcTexture = new Texture2D[2];
        public static Texture2D hotbarTexture;
        public static Texture2D cursorTexture;
        public static Texture2D dustTexture;
        public static Texture2D sunTexture;
        public static Texture2D moonTexture;
        public static Texture2D[] tileTexture = new Texture2D[12];
        public static Texture2D blackTileTexture;
        public static Texture2D[] wallTexture = new Texture2D[2];
        public static Texture2D[] backgroundTexture = new Texture2D[3];
        public static Texture2D heartTexture;
        public static Texture2D treeTopTexture;
        public static Texture2D treeBranchTexture;
        public static Texture2D inventoryBackTexture;
        public static SoundEffect[] soundDig = new SoundEffect[3];
        public static SoundEffectInstance[] soundInstanceDig = new SoundEffectInstance[3];
        public static SoundEffect[] soundPlayerHit = new SoundEffect[3];
        public static SoundEffectInstance[] soundInstancePlayerHit = new SoundEffectInstance[3];
        public static SoundEffect soundPlayerKilled;
        public static SoundEffectInstance soundInstancePlayerKilled;
        public static SoundEffect soundGrass;
        public static SoundEffectInstance soundInstanceGrass;
        public static SoundEffect soundGrab;
        public static SoundEffectInstance soundInstanceGrab;
        public static SoundEffect[] soundItem = new SoundEffect[3];
        public static SoundEffectInstance[] soundInstanceItem = new SoundEffectInstance[3];
        public static SoundEffect[] soundNPCHit = new SoundEffect[2];
        public static SoundEffectInstance[] soundInstanceNPCHit = new SoundEffectInstance[2];
        public static SoundEffect[] soundNPCKilled = new SoundEffect[2];
        public static SoundEffectInstance[] soundInstanceNPCKilled = new SoundEffectInstance[2];
        public static SoundEffect soundDoorOpen;
        public static SoundEffectInstance soundInstanceDoorOpen;
        public static SoundEffect soundDoorClosed;
        public static SoundEffectInstance soundInstanceDoorClosed;
        public static SoundEffect soundMenuOpen;
        public static SoundEffect soundMenuClose;
        public static SoundEffect soundMenuTick;
        public static SoundEffectInstance soundInstanceMenuTick;
        public static SpriteFont fontItemStack;
        public static SpriteFont fontMouseText;
        public static SpriteFont fontDeathText;
        public static bool[] tileSolid = new bool[12];
        public static bool[] tileNoFail = new bool[12];
        public static int[] backgroundWidth = new int[3];
        public static int[] backgroundHeight = new int[3];
        public static Tile[,] tile = new Tile[5001, 2501];
        public static Dust[] dust = new Dust[1000];
        public static Item[] item = new Item[1000];
        public static NPC[] npc = new NPC[1001];
        public static Vector2 screenPosition;
        public static int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        public static int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

        public static float[] hotbarScale = new float[10]
        {
      1f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f
        };

        public static byte mouseTextColor = 0;
        public static int mouseTextColorChange = 1;
        public static bool mouseLeftRelease = false;
        public static bool playerInventory = false;
        public static Item mouseItem = new Item();
        private static float inventoryScale = 1f;
        public static Recipe[] recipe = new Recipe[Recipe.maxRecipes];
        public static int[] availableRecipe = new int[Recipe.maxRecipes];
        public static float[] availableRecipeY = new float[Recipe.maxRecipes];
        public static int numAvailableRecipes;
        public static int focusRecipe;
        public static int myPlayer = 0;
        public static Player[] player = new Player[16];
        public static int spawnTileX;
        public static int spawnTileY;
        public bool toggleFullscreen;
        public static int[] npcFrameCount = new int[2] { 1, 2 };

        public Main()
        {
            this.graphics = new GraphicsDeviceManager((Game)this);
            this.Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IntPtr hWnd = this.Window.Handle;
            var control = System.Windows.Forms.Control.FromHandle(hWnd);
            var form = control.FindForm();
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Window.Title = "Terraria: Dig Peon, Dig!";
            for (int index1 = 0; index1 < 5001; ++index1)
            {
                for (int index2 = 0; index2 < 2501; ++index2)
                    Main.tile[index1, index2] = new Tile();
            }
            Main.tileSolid[0] = true; // dirt
            Main.tileSolid[1] = true; // stone
            Main.tileSolid[2] = true; // grass
            Main.tileSolid[3] = false; // detail grass
            Main.tileNoFail[3] = true;
            Main.tileSolid[4] = false; // torch
            Main.tileNoFail[4] = true;
            Main.tileSolid[5] = false; // tree
            Main.tileSolid[6] = true; // iron ore
            Main.tileSolid[7] = true; // copper ore
            Main.tileSolid[8] = true; // gold ore
            Main.tileSolid[9] = true; // silver ore
            Main.tileSolid[10] = true; // door
            Main.tileSolid[11] = false; // bugged (open?) door
            for (int index = 0; index < 1000; ++index)
                Main.dust[index] = new Dust();
            for (int index = 0; index < 1000; ++index)
                Main.item[index] = new Item();
            for (int index = 0; index < 1000; ++index)
                Main.npc[index] = new NPC();
            Player.SetupPlayers();
            for (int index = 0; index < Recipe.maxRecipes; ++index)
            {
                Main.recipe[index] = new Recipe();
                Main.availableRecipeY[index] = (float)(65 * index);
            }
            Recipe.SetupRecipes();
            this.graphics.PreferredBackBufferWidth = Main.screenWidth;
            this.graphics.PreferredBackBufferHeight = Main.screenHeight;
            this.graphics.ApplyChanges();
            WorldGen.generateWorld();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            for (int index = 0; index < 12; ++index)
                Main.tileTexture[index] = this.Content.Load<Texture2D>("Images\\Tiles_" + (object)index);
            for (int index = 1; index < 2; ++index)
                Main.wallTexture[index] = this.Content.Load<Texture2D>("Images\\Wall_" + (object)index);
            for (int index = 0; index < 3; ++index)
            {
                Main.backgroundTexture[index] = this.Content.Load<Texture2D>("Images\\Background_" + (object)index);
                Main.backgroundWidth[index] = Main.backgroundTexture[index].Width;
                Main.backgroundHeight[index] = index == 0 ? screenHeight : Main.backgroundTexture[index].Height;
            }
            for (int index = 0; index < 27; ++index)
                Main.itemTexture[index] = this.Content.Load<Texture2D>("Images\\Item_" + (object)index);
            for (int index = 0; index < 2; ++index)
                Main.npcTexture[index] = this.Content.Load<Texture2D>("Images\\NPC_" + (object)index);
            Main.hotbarTexture = this.Content.Load<Texture2D>("Images\\Hotbar");
            Main.dustTexture = this.Content.Load<Texture2D>("Images\\Dust");
            Main.sunTexture = this.Content.Load<Texture2D>("Images\\Sun");
            Main.moonTexture = this.Content.Load<Texture2D>("Images\\Moon");
            Main.blackTileTexture = this.Content.Load<Texture2D>("Images\\Black_Tile");
            Main.heartTexture = this.Content.Load<Texture2D>("Images\\Heart");
            Main.cursorTexture = this.Content.Load<Texture2D>("Images\\Cursor");
            Main.treeTopTexture = this.Content.Load<Texture2D>("Images\\Tree_Tops");
            Main.treeBranchTexture = this.Content.Load<Texture2D>("Images\\Tree_Branches");
            Main.inventoryBackTexture = this.Content.Load<Texture2D>("Images\\Inventory_Back");
            Main.playerHeadTexture = this.Content.Load<Texture2D>("Images\\Character_Heads");
            Main.playerBodyTexture = this.Content.Load<Texture2D>("Images\\Character_Bodies");
            Main.playerLegTexture = this.Content.Load<Texture2D>("Images\\Character_Legs");
            Main.soundGrab = this.Content.Load<SoundEffect>("Sounds\\Grab");
            Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
            Main.soundDig[0] = this.Content.Load<SoundEffect>("Sounds\\Dig_0");
            Main.soundInstanceDig[0] = Main.soundDig[0].CreateInstance();
            Main.soundDig[1] = this.Content.Load<SoundEffect>("Sounds\\Dig_1");
            Main.soundInstanceDig[1] = Main.soundDig[1].CreateInstance();
            Main.soundDig[2] = this.Content.Load<SoundEffect>("Sounds\\Dig_2");
            Main.soundInstanceDig[2] = Main.soundDig[2].CreateInstance();
            Main.soundPlayerHit[0] = this.Content.Load<SoundEffect>("Sounds\\Player_Hit_0");
            Main.soundInstancePlayerHit[0] = Main.soundPlayerHit[0].CreateInstance();
            Main.soundPlayerHit[1] = this.Content.Load<SoundEffect>("Sounds\\Player_Hit_1");
            Main.soundInstancePlayerHit[1] = Main.soundPlayerHit[1].CreateInstance();
            Main.soundPlayerHit[2] = this.Content.Load<SoundEffect>("Sounds\\Player_Hit_2");
            Main.soundInstancePlayerHit[2] = Main.soundPlayerHit[2].CreateInstance();
            Main.soundPlayerKilled = this.Content.Load<SoundEffect>("Sounds\\Player_Killed");
            Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
            Main.soundGrass = this.Content.Load<SoundEffect>("Sounds\\Grass");
            Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
            Main.soundDoorOpen = this.Content.Load<SoundEffect>("Sounds\\Door_Opened");
            Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
            Main.soundDoorClosed = this.Content.Load<SoundEffect>("Sounds\\Door_Closed");
            Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
            Main.soundMenuTick = this.Content.Load<SoundEffect>("Sounds\\Menu_Tick");
            Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
            Main.soundMenuOpen = this.Content.Load<SoundEffect>("Sounds\\Menu_Open");
            Main.soundMenuClose = this.Content.Load<SoundEffect>("Sounds\\Menu_Close");
            for (int index = 1; index < 3; ++index)
            {
                Main.soundItem[index] = this.Content.Load<SoundEffect>("Sounds\\Item_" + (object)index);
                Main.soundInstanceItem[index] = Main.soundItem[index].CreateInstance();
            }
            for (int index = 1; index < 2; ++index)
            {
                Main.soundNPCHit[index] = this.Content.Load<SoundEffect>("Sounds\\NPC_Hit_" + (object)index);
                Main.soundInstanceNPCHit[index] = Main.soundNPCHit[index].CreateInstance();
            }
            for (int index = 1; index < 2; ++index)
            {
                Main.soundNPCKilled[index] = this.Content.Load<SoundEffect>("Sounds\\NPC_Killed_" + (object)index);
                Main.soundInstanceNPCKilled[index] = Main.soundNPCKilled[index].CreateInstance();
            }
            Main.fontItemStack = this.Content.Load<SpriteFont>("Fonts\\Item_Stack");
            Main.fontMouseText = this.Content.Load<SpriteFont>("Fonts\\Mouse_Text");
            Main.fontDeathText = this.Content.Load<SpriteFont>("Fonts\\Death_Text");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (!this.IsActive)
            {
                this.IsMouseVisible = true;
                Main.player[Main.myPlayer].delayUseItem = true;
                Main.mouseLeftRelease = false;
            }
            else
            {
                this.IsMouseVisible = false;
                if ((Main.keyState.IsKeyDown(Keys.LeftControl) || Main.keyState.IsKeyDown(Keys.RightControl)) && Main.keyState.IsKeyDown(Keys.Z))
                {
                    if (releaseCheats)
                    {
                        if (cheats)
                        {
                            lastDebug = debugMode;
                            debugMode = false;
                            lastDumbAI = dumbAI;
                            dumbAI = false;
                            lastGodMode = godMode;
                            godMode = false;
                            lastLighting = Lighting.disableLighting;
                            Lighting.disableLighting = false;
                            cheats = false;
                            lastMovement = player[0].superMovement;
                            player[0].superMovement = false;
                            lastInfinite = infiniteReach;
                            infiniteReach = false;
                        }
                        else
                        {
                            debugMode = lastDebug;
                            dumbAI = lastDumbAI;
                            godMode = lastGodMode;
                            Lighting.disableLighting = lastLighting;
                            player[0].superMovement = lastMovement;
                            infiniteReach = lastInfinite;
                            cheats = true;
                        }
                    }
                    releaseCheats = false;
                }
                else
                    releaseCheats = true;
                if ((Main.keyState.IsKeyDown(Keys.LeftControl) || Main.keyState.IsKeyDown(Keys.RightControl)) && Main.keyState.IsKeyDown(Keys.U))
                {
                    if (releaseUncap)
                    {
                        this.IsFixedTimeStep = !this.IsFixedTimeStep;
                    }
                    releaseUncap = false;
                }
                else
                    releaseUncap = true;
                if ((Main.keyState.IsKeyDown(Keys.LeftAlt) || Main.keyState.IsKeyDown(Keys.RightAlt)) && Main.keyState.IsKeyDown(Keys.Enter))
                {
                    if (this.toggleFullscreen)
                        this.graphics.ToggleFullScreen();
                    this.toggleFullscreen = false;
                }
                else
                    this.toggleFullscreen = true;
                Main.oldMouseState = Main.mouseState;
                Main.mouseState = Mouse.GetState();
                Main.keyState = Keyboard.GetState();
                if (cheats)
                    Main.UpdateCheats();
                if (Main.debugMode)
                    Main.UpdateDebug();
                if (infiniteReach)
                    Main.UpdateInfinite();
                for (int i = 0; i < 16; ++i)
                    Main.player[i].UpdatePlayer(i);
                NPC.SpawnNPC();
                for (int index = 0; index < 16; ++index)
                    Main.player[index].activeNPCs = 0;
                for (int i = 0; i < 1000; ++i)
                    Main.npc[i].UpdateNPC(i);
                for (int i = 0; i < 1000; ++i)
                    Main.item[i].UpdateItem(i);
                Dust.UpdateDust();
                Main.UpdateTime();
                WorldGen.UpdateWorld();
                
                if (gameTime.ElapsedGameTime.Milliseconds != 0)
                fps = (float)(1000 / (gameTime.ElapsedGameTime.Milliseconds));

                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            Main.player[Main.myPlayer].mouseInterface = false;
            if (!this.IsActive)
                return;
            bool flag = false;
            if (!Main.debugMode)
            {
                int num1 = Main.mouseState.X;
                int num2 = Main.mouseState.Y;
                if (num1 < 0)
                    num1 = 0;
                if (num1 > Main.screenWidth)
                {
                    int screenWidth = Main.screenWidth;
                }
                if (num2 < 0)
                    num2 = 0;
                if (num2 > Main.screenHeight)
                {
                    int screenHeight = Main.screenHeight;
                }
                Main.screenPosition.X = (float)((double)Main.player[Main.myPlayer].position.X + (double)Main.player[Main.myPlayer].width * 0.5 - (double)Main.screenWidth * 0.5);
                Main.screenPosition.Y = (float)((double)Main.player[Main.myPlayer].position.Y + (double)Main.player[Main.myPlayer].height * 0.5 - (double)Main.screenHeight * 0.5);
            }
            Main.screenPosition.X = (float)(int)Main.screenPosition.X;
            Main.screenPosition.Y = (float)(int)Main.screenPosition.Y;
            if ((double)Main.screenPosition.X < 0.0)
                Main.screenPosition.X = 0.0f;
            else if ((double)Main.screenPosition.X + (double)Main.screenWidth > 80000.0)
                Main.screenPosition.X = 80000f - (float)Main.screenWidth;
            if ((double)Main.screenPosition.Y < 0.0)
                Main.screenPosition.Y = 0.0f;
            else if ((double)Main.screenPosition.Y + (double)Main.screenHeight > 40000.0)
                Main.screenPosition.Y = 40000f - (float)Main.screenHeight;
            this.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
            this.spriteBatch.Begin();
            double num3 = 0.5;
            int num4 = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * num3, (double)Main.backgroundWidth[Main.background]) - (double)(Main.backgroundWidth[Main.background] / 2));
            int num5 = Main.screenWidth / Main.backgroundWidth[Main.background] + 2;
            int y1 = (int)(-(double)Main.screenPosition.Y / (Main.worldSurface * 16.0 - (double)Main.screenHeight) * (double)(Main.backgroundHeight[Main.background] - Main.screenHeight));
            Color white1 = Color.White;
            int x1 = (int)(Main.time / 40000.0 * (double)(Main.screenWidth + Main.sunTexture.Width * 2)) - Main.sunTexture.Width;
            int y2 = 0;
            Color white2 = Color.White;
            float scale1 = 1f;
            float rotation1 = (float)(Main.time / 40000.0 * 2.0 - 7.30000019073486);
            int x2 = (int)(Main.time / 30000.0 * (double)(Main.screenWidth + Main.moonTexture.Width * 2)) - Main.moonTexture.Width;
            int y3 = 0;
            Color white3 = Color.White;
            float scale2 = 1f;
            float rotation2 = (float)(Main.time / 30000.0 * 2.0 - 7.30000019073486);
            if (Main.dayTime)
            {
                double num6;
                if (Main.time < 20000.0)
                {
                    num6 = Math.Pow(1.0 - Main.time / 40000.0 * 2.0, 2.0);
                    y2 = (int)((double)y1 + num6 * 250.0 + 180.0);
                }
                else
                {
                    num6 = Math.Pow((Main.time / 40000.0 - 0.5) * 2.0, 2.0);
                    y2 = (int)((double)y1 + num6 * 250.0 + 180.0);
                }
                scale1 = (float)(1.2 - num6 * 0.4);
            }
            else
            {
                double num7;
                if (Main.time < 15000.0)
                {
                    num7 = Math.Pow(1.0 - Main.time / 30000.0 * 2.0, 2.0);
                    y3 = (int)((double)y1 + num7 * 250.0 + 180.0);
                }
                else
                {
                    num7 = Math.Pow((Main.time / 30000.0 - 0.5) * 2.0, 2.0);
                    y3 = (int)((double)y1 + num7 * 250.0 + 180.0);
                }
                scale2 = (float)(1.2 - num7 * 0.4);
            }
            if (Main.dayTime)
            {
                if (Main.time < 10000.0)
                {
                    float num8 = (float)(Main.time / 10000.0);
                    white2.R = (byte)((double)num8 * 200.0 + 55.0);
                    white2.G = (byte)((double)num8 * 180.0 + 75.0);
                    white2.B = (byte)((double)num8 * 250.0 + 5.0);
                    white1.R = (byte)((double)num8 * 200.0 + 55.0);
                    white1.G = (byte)((double)num8 * 200.0 + 55.0);
                    white1.B = (byte)((double)num8 * 200.0 + 55.0);
                }
                if (Main.time > 34000.0)
                {
                    float num9 = (float)(1.0 - (Main.time / 40000.0 - 0.85) * (20.0 / 3.0));
                    white2.R = (byte)((double)num9 * 120.0 + 55.0);
                    white2.G = (byte)((double)num9 * 100.0 + 25.0);
                    white2.B = (byte)((double)num9 * 120.0 + 55.0);
                    white1.R = (byte)((double)num9 * 200.0 + 55.0);
                    white1.G = (byte)((double)num9 * 85.0 + 55.0);
                    white1.B = (byte)((double)num9 * 135.0 + 55.0);
                }
                else if (Main.time > 28000.0)
                {
                    float num10 = (float)(1.0 - (Main.time / 40000.0 - 0.7) * (20.0 / 3.0));
                    white2.R = (byte)((double)num10 * 80.0 + 175.0);
                    white2.G = (byte)((double)num10 * 130.0 + 125.0);
                    white2.B = (byte)((double)num10 * 100.0 + 155.0);
                    white1.R = (byte)((double)num10 * 0.0 + (double)byte.MaxValue);
                    white1.G = (byte)((double)num10 * 115.0 + 140.0);
                    white1.B = (byte)((double)num10 * 75.0 + 180.0);
                }
            }
            if (!Main.dayTime)
            {
                if (Main.time < 15000.0)
                {
                    float num11 = (float)(1.0 - Main.time / 15000.0);
                    white3.R = (byte)((double)num11 * 10.0 + 205.0);
                    white3.G = (byte)((double)num11 * 70.0 + 155.0);
                    white3.B = (byte)((double)num11 * 100.0 + 155.0);
                    white1.R = (byte)((double)num11 * 40.0 + 15.0);
                    white1.G = (byte)((double)num11 * 40.0 + 15.0);
                    white1.B = (byte)((double)num11 * 40.0 + 15.0);
                }
                else if (Main.time >= 15000.0)
                {
                    float num12 = (float)((Main.time / 30000.0 - 0.5) * 2.0);
                    white3.R = (byte)((double)num12 * 50.0 + 205.0);
                    white3.G = (byte)((double)num12 * 100.0 + 155.0);
                    white3.B = (byte)((double)num12 * 100.0 + 155.0);
                    white1.R = (byte)((double)num12 * 40.0 + 15.0);
                    white1.G = (byte)((double)num12 * 40.0 + 15.0);
                    white1.B = (byte)((double)num12 * 40.0 + 15.0);
                }
            }
            Main.tileColor.A = byte.MaxValue;
            Main.tileColor.R = (byte)(((int)white1.R + (int)white1.B + (int)white1.G) / 3);
            Main.tileColor.G = (byte)(((int)white1.R + (int)white1.B + (int)white1.G) / 3);
            Main.tileColor.B = (byte)(((int)white1.R + (int)white1.B + (int)white1.G) / 3);
            for (int index = 0; index < num5; ++index)
                this.spriteBatch.Draw(Main.backgroundTexture[Main.background], new Rectangle(num4 + Main.backgroundWidth[Main.background] * index, y1, Main.backgroundWidth[Main.background], Main.backgroundHeight[Main.background]), white1);
            if (Main.dayTime)
                this.spriteBatch.Draw(Main.sunTexture, new Vector2((float)x1, (float)y2), new Rectangle?(new Rectangle(0, 0, Main.sunTexture.Width, Main.sunTexture.Height)), white2, rotation1, new Vector2((float)(Main.sunTexture.Width / 2), (float)(Main.sunTexture.Height / 2)), scale1, SpriteEffects.None, 0.0f);
            if (!Main.dayTime)
                this.spriteBatch.Draw(Main.moonTexture, new Vector2((float)x2, (float)y3), new Rectangle?(new Rectangle(0, Main.moonTexture.Width * Main.moonPhase, Main.moonTexture.Width, Main.moonTexture.Width)), white3, rotation2, new Vector2((float)(Main.moonTexture.Width / 2), (float)(Main.moonTexture.Width / 2)), scale2, SpriteEffects.None, 0.0f);
            int firstX = (int)((double)Main.screenPosition.X / 16.0 - 1.0);
            int lastX = (int)(((double)Main.screenPosition.X + (double)Main.screenWidth) / 16.0) + 2;
            int firstY = (int)((double)Main.screenPosition.Y / 16.0 - 1.0);
            int lastY = (int)(((double)Main.screenPosition.Y + (double)Main.screenHeight) / 16.0) + 2;
            if (firstX < 0)
                firstX = 0;
            if (lastX > 5001)
                lastX = 5001;
            if (firstY < 0)
                firstY = 0;
            if (lastY > 2501)
                lastY = 2501;
            Lighting.LightTiles(firstX, lastX, firstY, lastY);
            Color white4 = Color.White;
            double num13 = 1.0;
            int num14 = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * num13, (double)Main.backgroundWidth[1]) - (double)(Main.backgroundWidth[1] / 2));
            int num15 = Main.screenWidth / Main.backgroundWidth[1] + 2;
            int y4 = (int)((double)((int)Main.worldSurface * 16 - Main.backgroundHeight[1]) - (double)Main.screenPosition.Y + 16.0);
            for (int index1 = 0; index1 < num15; ++index1)
            {
                for (int index2 = 0; index2 < 6; ++index2)
                {
                    int index3 = (int)(((double)(num14 + Main.backgroundWidth[1] * index1) + (double)Main.screenPosition.X + (double)(index2 * 16)) / 16.0 - (double)firstX + 21.0);
                    int index4 = (int)(((double)y4 + (double)Main.screenPosition.Y) / 16.0 - (double)firstY + 21.0);
                    if (index3 < 0)
                        index3 = 0;
                    if (index3 >= Main.screenWidth / 16 + 42 + 10)
                        index3 = Main.screenWidth / 16 + 42 + 10 - 1;
                    if (index4 < 0)
                        index4 = 0;
                    if (index4 >= Main.screenHeight / 16 + 42 + 10)
                        index4 = Main.screenHeight / 16 + 42 + 10 - 1;
                    Color color = Lighting.color[index3, index4];
                    this.spriteBatch.Draw(Main.backgroundTexture[1], new Vector2((float)(num14 + Main.backgroundWidth[1] * index1 + 16 * index2), (float)y4), new Rectangle?(new Rectangle(16 * index2, 0, 16, 16)), color);
                }
            }
            int x3 = (int)((double)((int)Main.worldSurface * 16) - (double)Main.screenPosition.Y + 16.0);
            if (Main.worldSurface * 16.0 <= (double)Main.screenPosition.Y + (double)Main.screenHeight)
            {
                double num16 = 1.0;
                int num17 = (int)(-Math.IEEERemainder(100.0 + (double)Main.screenPosition.X * num16, (double)Main.backgroundWidth[2]) - (double)(Main.backgroundWidth[2] / 2));
                int num18 = Main.screenWidth / Main.backgroundWidth[2] + 2;
                int num19;
                int num20;
                if (Main.worldSurface * 16.0 < (double)Main.screenPosition.Y)
                {
                    num19 = (int)(Math.IEEERemainder((double)x3, (double)Main.backgroundHeight[2]) - (double)Main.backgroundHeight[2]);
                    num20 = Main.screenHeight / Main.backgroundHeight[2] + 2;
                }
                else
                {
                    num19 = x3;
                    num20 = (Main.screenHeight - x3) / Main.backgroundHeight[2] + 1;
                }
                for (int index5 = 0; index5 < num18; ++index5)
                {
                    for (int index6 = 0; index6 < num20; ++index6)
                        this.spriteBatch.Draw(Main.backgroundTexture[2], new Rectangle(num17 + Main.backgroundWidth[2] * index5, num19 + Main.backgroundHeight[2] * index6, Main.backgroundWidth[2], Main.backgroundHeight[2]), Color.White);
                }
            }
            for (int index7 = firstY; index7 < lastY + 4; ++index7)
            {
                for (int index8 = firstX - 2; index8 < lastX + 2; ++index8)
                {
                    if ((int)Lighting.color[index8 - firstX + 21, index7 - firstY + 21].R < (int)Main.tileColor.R - 10 || (double)index7 > Main.worldSurface)
                    {
                        int num21 = (int)byte.MaxValue - (int)Lighting.color[index8 - firstX + 21, index7 - firstY + 21].R;
                        if (num21 < 0)
                            num21 = 0;
                        if (num21 > (int)byte.MaxValue)
                            num21 = (int)byte.MaxValue;
                        white4.A = (byte)num21;
                        this.spriteBatch.Draw(Main.blackTileTexture, new Vector2((float)(index8 * 16 - (int)Main.screenPosition.X), (float)(index7 * 16 - (int)Main.screenPosition.Y)), new Rectangle?(new Rectangle((int)Main.tile[index8, index7].frameX, (int)Main.tile[index8, index7].frameY, 16, 16)), white4, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                    }
                    if (Main.tile[index8, index7].wall > (byte)0)
                        this.spriteBatch.Draw(Main.wallTexture[(int)Main.tile[index8, index7].wall], new Vector2((float)(index8 * 16 - (int)Main.screenPosition.X - 8), (float)(index7 * 16 - (int)Main.screenPosition.Y - 8)), new Rectangle?(new Rectangle((int)Main.tile[index8, index7].wallFrameX * 2, (int)Main.tile[index8, index7].wallFrameY * 2, 32, 32)), Lighting.color[index8 - firstX + 21, index7 - firstY + 21], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
            }
            for (int index9 = firstY; index9 < lastY + 4; ++index9)
            {
                for (int index10 = firstX - 2; index10 < lastX + 2; ++index10)
                {
                    if (Main.tile[index10, index9].active)
                    {
                        int height = Main.tile[index10, index9].type != (byte)3 && Main.tile[index10, index9].type != (byte)4 && Main.tile[index10, index9].type != (byte)5 ? 16 : 20;
                        int width = Main.tile[index10, index9].type != (byte)4 && Main.tile[index10, index9].type != (byte)5 ? 16 : 20;
                        if (Main.tile[index10, index9].type == (byte)4 && Main.rand.Next(40) == 0)
                        {
                            if (Main.tile[index10, index9].frameX == (short)22)
                                Dust.NewDust(new Vector2((float)(index10 * 16 + 6), (float)(index9 * 16)), 4, 4, 6, Alpha: 100);
                            if (Main.tile[index10, index9].frameX == (short)44)
                                Dust.NewDust(new Vector2((float)(index10 * 16 + 2), (float)(index9 * 16)), 4, 4, 6, Alpha: 100);
                            else
                                Dust.NewDust(new Vector2((float)(index10 * 16 + 4), (float)(index9 * 16)), 4, 4, 6, Alpha: 100);
                        }
                        if (Main.tile[index10, index9].type == (byte)5 && Main.tile[index10, index9].frameY >= (short)198 && Main.tile[index10, index9].frameX >= (short)22)
                        {
                            int num22 = 0;
                            if (Main.tile[index10, index9].frameX == (short)22)
                            {
                                if (Main.tile[index10, index9].frameY == (short)220)
                                    num22 = 1;
                                else if (Main.tile[index10, index9].frameY == (short)242)
                                    num22 = 2;
                                this.spriteBatch.Draw(Main.treeTopTexture, new Vector2((float)(index10 * 16 - (int)Main.screenPosition.X - 32), (float)(index9 * 16 - (int)Main.screenPosition.Y - 64)), new Rectangle?(new Rectangle(num22 * 82, 0, 80, 80)), Lighting.color[index10 - firstX + 21, index9 - firstY + 21], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                            }
                            else if (Main.tile[index10, index9].frameX == (short)44)
                            {
                                if (Main.tile[index10, index9].frameY == (short)220)
                                    num22 = 1;
                                else if (Main.tile[index10, index9].frameY == (short)242)
                                    num22 = 2;
                                this.spriteBatch.Draw(Main.treeBranchTexture, new Vector2((float)(index10 * 16 - (int)Main.screenPosition.X - 24), (float)(index9 * 16 - (int)Main.screenPosition.Y - 12)), new Rectangle?(new Rectangle(0, num22 * 42, 40, 40)), Lighting.color[index10 - firstX + 21, index9 - firstY + 21], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                            }
                            else if (Main.tile[index10, index9].frameX == (short)66)
                            {
                                if (Main.tile[index10, index9].frameY == (short)220)
                                    num22 = 1;
                                else if (Main.tile[index10, index9].frameY == (short)242)
                                    num22 = 2;
                                this.spriteBatch.Draw(Main.treeBranchTexture, new Vector2((float)(index10 * 16 - (int)Main.screenPosition.X), (float)(index9 * 16 - (int)Main.screenPosition.Y - 12)), new Rectangle?(new Rectangle(42, num22 * 42, 40, 40)), Lighting.color[index10 - firstX + 21, index9 - firstY + 21], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                            }
                        }
                        this.spriteBatch.Draw(Main.tileTexture[(int)Main.tile[index10, index9].type], new Vector2((float)(index10 * 16 - (int)Main.screenPosition.X) - (float)(((double)width - 16.0) / 2.0), (float)(index9 * 16 - (int)Main.screenPosition.Y)), new Rectangle?(new Rectangle((int)Main.tile[index10, index9].frameX, (int)Main.tile[index10, index9].frameY, width, height)), Lighting.color[index10 - firstX + 21, index9 - firstY + 21], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                    }
                }
            }
            for (int index = 0; index < 16; ++index)
            {
                if (Main.player[index].active)
                {
                    SpriteEffects effects = Main.player[index].direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                    Color newColor1 = Lighting.color[Lighting.LightingX((int)((double)Main.player[index].position.X + (double)Main.player[index].width * 0.5) / 16 - firstX + 21), Lighting.LightingY((int)((double)Main.player[index].position.Y + (double)Main.player[index].height * 0.25) / 16 - firstY + 21)];
                    this.spriteBatch.Draw(Main.playerHeadTexture, new Vector2((float)(int)((double)Main.player[index].position.X - (double)Main.screenPosition.X - (double)(Main.player[index].headFrame.Width / 2) + (double)(Main.player[index].width / 2)), (float)(int)((double)Main.player[index].position.Y - (double)Main.screenPosition.Y + (double)Main.player[index].height - (double)Main.player[index].headFrame.Height + 2.0)) + Main.player[index].headPosition + new Vector2(16f, 14f), new Rectangle?(Main.player[index].headFrame), Main.player[index].GetImmuneAlpha(newColor1), Main.player[index].headRotation, new Vector2(16f, 14f), 1f, effects, 0.0f);
                    Color newColor2 = Lighting.color[Lighting.LightingX((int)((double)Main.player[index].position.X + (double)Main.player[index].width * 0.5) / 16 - firstX + 21), Lighting.LightingY((int)((double)Main.player[index].position.Y + (double)Main.player[index].height * 0.5) / 16 - firstY + 21)];
                    if ((Main.player[index].itemAnimation > 0 || Main.player[index].inventory[Main.player[index].selectedItem].holdStyle > 0) && Main.player[index].inventory[Main.player[index].selectedItem].type > 0)
                    {
                        this.spriteBatch.Draw(Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type], new Vector2((float)(int)((double)Main.player[index].itemLocation.X - (double)Main.screenPosition.X), (float)(int)((double)Main.player[index].itemLocation.Y - (double)Main.screenPosition.Y)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Width, Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Height)), Main.player[index].inventory[Main.player[index].selectedItem].GetAlpha(newColor2), Main.player[index].itemRotation, new Vector2((float)((double)Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Width * 0.5 - (double)Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Width * 0.5 * (double)Main.player[index].direction), (float)Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Height), Main.player[index].inventory[Main.player[index].selectedItem].scale, effects, 0.0f);
                        if (Main.player[index].inventory[Main.player[index].selectedItem].color != new Color())
                            this.spriteBatch.Draw(Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type], new Vector2((float)(int)((double)Main.player[index].itemLocation.X - (double)Main.screenPosition.X), (float)(int)((double)Main.player[index].itemLocation.Y - (double)Main.screenPosition.Y)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Width, Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Height)), Main.player[index].inventory[Main.player[index].selectedItem].GetColor(newColor2), Main.player[index].itemRotation, new Vector2((float)((double)Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Width * 0.5 - (double)Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Width * 0.5 * (double)Main.player[index].direction), (float)Main.itemTexture[Main.player[index].inventory[Main.player[index].selectedItem].type].Height), Main.player[index].inventory[Main.player[index].selectedItem].scale, effects, 0.0f);
                    }
                    this.spriteBatch.Draw(Main.playerBodyTexture, new Vector2((float)(int)((double)Main.player[index].position.X - (double)Main.screenPosition.X - (double)(Main.player[index].bodyFrame.Width / 2) + (double)(Main.player[index].width / 2)), (float)(int)((double)Main.player[index].position.Y - (double)Main.screenPosition.Y + (double)Main.player[index].height - (double)Main.player[index].bodyFrame.Height + 2.0)) + Main.player[index].bodyPosition + new Vector2(16f, 28f), new Rectangle?(Main.player[index].bodyFrame), Main.player[index].GetImmuneAlpha(newColor2), Main.player[index].bodyRotation, new Vector2(16f, 28f), 1f, effects, 0.0f);
                    Color newColor3 = Lighting.color[Lighting.LightingX((int)((double)Main.player[index].position.X + (double)Main.player[index].width * 0.5) / 16 - firstX + 21), Lighting.LightingY((int)((double)Main.player[index].position.Y + (double)Main.player[index].height * 0.75) / 16 - firstY + 21)];
                    this.spriteBatch.Draw(Main.playerLegTexture, new Vector2((float)(int)((double)Main.player[index].position.X - (double)Main.screenPosition.X - (double)(Main.player[index].legFrame.Width / 2) + (double)(Main.player[index].width / 2)), (float)(int)((double)Main.player[index].position.Y - (double)Main.screenPosition.Y + (double)Main.player[index].height - (double)Main.player[index].legFrame.Height + 2.0)) + Main.player[index].legPosition + new Vector2(16f, 40f), new Rectangle?(Main.player[index].legFrame), Main.player[index].GetImmuneAlpha(newColor3), Main.player[index].legRotation, new Vector2(16f, 40f), 1f, effects, 0.0f);
                }
            }
            Rectangle rectangle1 = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            for (int index = 0; index < 1000; ++index)
            {
                if (rectangle1.Intersects(new Rectangle((int)Main.npc[index].position.X, (int)Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height)))
                {
                    Color newColor = Lighting.color[(int)((double)Main.npc[index].position.X + (double)Main.npc[index].width * 0.5) / 16 - firstX + 21, (int)((double)Main.npc[index].position.Y + (double)Main.npc[index].height * 0.5) / 16 - firstY + 21];
                    if (Main.npc[index].active && Main.npc[index].type > 0)
                    {
                        this.spriteBatch.Draw(Main.npcTexture[Main.npc[index].type], new Vector2((float)((double)Main.npc[index].position.X - (double)Main.screenPosition.X + (double)(Main.npc[index].width / 2) - (double)Main.npcTexture[Main.npc[index].type].Width * (double)Main.npc[index].scale / 2.0), (float)((double)Main.npc[index].position.Y - (double)Main.screenPosition.Y + (double)Main.npc[index].height - (double)Main.npcTexture[Main.npc[index].type].Height * (double)Main.npc[index].scale / (double)Main.npcFrameCount[Main.npc[index].type] + 4.0)), new Rectangle?(Main.npc[index].frame), Main.npc[index].GetAlpha(newColor), 0.0f, new Vector2(), Main.npc[index].scale, SpriteEffects.None, 0.0f);
                        if (Main.npc[index].color != new Color())
                            this.spriteBatch.Draw(Main.npcTexture[Main.npc[index].type], new Vector2((float)((double)Main.npc[index].position.X - (double)Main.screenPosition.X + (double)(Main.npc[index].width / 2) - (double)Main.npcTexture[Main.npc[index].type].Width * (double)Main.npc[index].scale / 2.0), (float)((double)Main.npc[index].position.Y - (double)Main.screenPosition.Y + (double)Main.npc[index].height - (double)Main.npcTexture[Main.npc[index].type].Height * (double)Main.npc[index].scale / (double)Main.npcFrameCount[Main.npc[index].type] + 4.0)), new Rectangle?(Main.npc[index].frame), Main.npc[index].GetColor(newColor), 0.0f, new Vector2(), Main.npc[index].scale, SpriteEffects.None, 0.0f);
                    }
                }
            }
            for (int index = 0; index < 1000; ++index)
            {
                if (Main.item[index].active && Main.item[index].type > 0)
                {
                    int lightX = (int)((double)Main.item[index].position.X + (double)Main.item[index].width * 0.5) / 16 - firstX + 21;
                    int lightY = (int)((double)Main.item[index].position.Y + (double)Main.item[index].height * 0.5) / 16 - firstY + 21;
                    Color newColor = Lighting.color[Lighting.LightingX(lightX), Lighting.LightingY(lightY)];
                    this.spriteBatch.Draw(Main.itemTexture[Main.item[index].type], new Vector2(Main.item[index].position.X - Main.screenPosition.X + (float)(Main.item[index].width / 2) - (float)(Main.itemTexture[Main.item[index].type].Width / 2), Main.item[index].position.Y - Main.screenPosition.Y + (float)(Main.item[index].height / 2) - (float)(Main.itemTexture[Main.item[index].type].Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.item[index].type].Width, Main.itemTexture[Main.item[index].type].Height)), Main.item[index].GetAlpha(newColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                    if (Main.item[index].color != new Color())
                        this.spriteBatch.Draw(Main.itemTexture[Main.item[index].type], new Vector2(Main.item[index].position.X - Main.screenPosition.X + (float)(Main.item[index].width / 2) - (float)(Main.itemTexture[Main.item[index].type].Width / 2), Main.item[index].position.Y - Main.screenPosition.Y + (float)(Main.item[index].height / 2) - (float)(Main.itemTexture[Main.item[index].type].Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.item[index].type].Width, Main.itemTexture[Main.item[index].type].Height)), Main.item[index].GetColor(newColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
            }
            for (int index = 0; index < 1000; ++index)
            {
                if (Main.dust[index].active)
                {
                    Color white5 = Lighting.color[Lighting.LightingX((int)((double)Main.dust[index].position.X + 4.0) / 16 - firstX + 21), Lighting.LightingY((int)((double)Main.dust[index].position.Y + 4.0) / 16 - firstY + 21)];
                    if (Main.dust[index].type == 6)
                        white5 = Color.White;
                    this.spriteBatch.Draw(Main.dustTexture, Main.dust[index].position - Main.screenPosition, new Rectangle?(Main.dust[index].frame), Main.dust[index].GetAlpha(white5), Main.dust[index].rotation, new Vector2(4f, 4f), Main.dust[index].scale, SpriteEffects.None, 0.0f);
                    if (Main.dust[index].color != new Color())
                        this.spriteBatch.Draw(Main.dustTexture, Main.dust[index].position - Main.screenPosition, new Rectangle?(Main.dust[index].frame), Main.dust[index].GetColor(white5), Main.dust[index].rotation, new Vector2(4f, 4f), Main.dust[index].scale, SpriteEffects.None, 0.0f);
                }
            }
            int num23 = 20;
            for (int index = 1; index < Main.player[Main.myPlayer].statLifeMax / num23 + 1; ++index)
            {
                float scale3 = 1f;
                int num24;
                if (Main.player[Main.myPlayer].statLife >= index * num23)
                {
                    num24 = (int)byte.MaxValue;
                }
                else
                {
                    float num25 = (float)(Main.player[Main.myPlayer].statLife - (index - 1) * num23) / (float)num23;
                    num24 = (int)(30.0 + 225.0 * (double)num25);
                    if (num24 < 30)
                        num24 = 30;
                    scale3 = (float)((double)num25 / 4.0 + 0.75);
                    if ((double)scale3 < 0.75)
                        scale3 = 0.75f;
                }
                int num26 = 0;
                int num27 = 0;
                if (index > 10)
                {
                    num26 -= 260;
                    num27 += 26;
                }
                this.spriteBatch.Draw(Main.heartTexture, new Vector2((float)(screenWidth - 158 + 26 * (index - 1) + num26), (float)(32.0 + ((double)Main.heartTexture.Height - (double)Main.heartTexture.Height * (double)scale3) / 2.0) + (float)num27), new Rectangle?(new Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Color(num24, num24, num24, num24), 0.0f, new Vector2(), scale3, SpriteEffects.None, 0.0f);
            }
            string text1 = "";
            if (Main.playerInventory)
            {
                Main.inventoryScale = 1f;
                Color color;
                for (int index11 = 0; index11 < 10; ++index11)
                {
                    for (int index12 = 0; index12 < 4; ++index12)
                    {
                        int x4 = (int)(20.0 + (double)(index11 * 56) * (double)Main.inventoryScale);
                        int y5 = (int)(20.0 + (double)(index12 * 56) * (double)Main.inventoryScale);
                        int index13 = index11 + index12 * 10;
                        color = new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                        if (Main.mouseState.X >= x4 && (double)Main.mouseState.X <= (double)x4 + (double)Main.hotbarTexture.Width * (double)Main.inventoryScale && Main.mouseState.Y >= y5 && (double)Main.mouseState.Y <= (double)y5 + (double)Main.hotbarTexture.Height * (double)Main.inventoryScale)
                        {
                            Main.player[Main.myPlayer].mouseInterface = true;
                            if (Main.mouseLeftRelease && Main.mouseState.LeftButton == ButtonState.Pressed && (Main.player[Main.myPlayer].selectedItem != index13 || Main.player[Main.myPlayer].itemAnimation <= 0))
                            {
                                Item mouseItem = Main.mouseItem;
                                Main.mouseItem = Main.player[Main.myPlayer].inventory[index13];
                                Main.player[Main.myPlayer].inventory[index13] = mouseItem;
                                if (Main.player[Main.myPlayer].inventory[index13].type == 0 || Main.player[Main.myPlayer].inventory[index13].stack < 1)
                                    Main.player[Main.myPlayer].inventory[index13] = new Item();
                                if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[index13]) && Main.player[Main.myPlayer].inventory[index13].stack != Main.player[Main.myPlayer].inventory[index13].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                                {
                                    if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[index13].stack <= Main.mouseItem.maxStack)
                                    {
                                        Main.player[Main.myPlayer].inventory[index13].stack += Main.mouseItem.stack;
                                        Main.mouseItem.stack = 0;
                                    }
                                    else
                                    {
                                        int num28 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[index13].stack;
                                        Main.player[Main.myPlayer].inventory[index13].stack += num28;
                                        Main.mouseItem.stack -= num28;
                                    }
                                }
                                if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                                    Main.mouseItem = new Item();
                                if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[index13].type > 0)
                                {
                                    Recipe.FindRecipes();
                                    Main.soundInstanceGrab.Stop();
                                    Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
                                    Main.soundInstanceGrab.Play();
                                }
                            }
                            text1 = Main.player[Main.myPlayer].inventory[index13].name;
                            if (Main.player[Main.myPlayer].inventory[index13].stack > 1)
                                text1 = text1 + " (" + (object)Main.player[Main.myPlayer].inventory[index13].stack + ")";
                        }
                        this.spriteBatch.Draw(Main.hotbarTexture, new Vector2((float)x4, (float)y5), new Rectangle?(new Rectangle(0, 0, Main.hotbarTexture.Width, Main.hotbarTexture.Height)), color, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                        this.spriteBatch.Draw(Main.inventoryBackTexture, new Vector2((float)x4, (float)y5), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), new Color(200, 200, 200, 200), 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                        color = Color.White;
                        if (Main.player[Main.myPlayer].inventory[index13].type > 0 && Main.player[Main.myPlayer].inventory[index13].stack > 0)
                        {
                            float num29 = 1f;
                            if (Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Height > 32)
                                num29 = Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Height ? 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Height : 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Width;
                            float scale4 = num29 * Main.inventoryScale;
                            this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type], new Vector2((float)((double)x4 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Width * 0.5 * (double)scale4), (float)((double)y5 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Height * 0.5 * (double)scale4)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Height)), Main.player[Main.myPlayer].inventory[index13].GetAlpha(color), 0.0f, new Vector2(), scale4, SpriteEffects.None, 0.0f);
                            if (Main.player[Main.myPlayer].inventory[index13].color != new Color())
                                this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type], new Vector2((float)((double)x4 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Width * 0.5 * (double)scale4), (float)((double)y5 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Height * 0.5 * (double)scale4)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index13].type].Height)), Main.player[Main.myPlayer].inventory[index13].GetColor(color), 0.0f, new Vector2(), scale4, SpriteEffects.None, 0.0f);
                            if (Main.player[Main.myPlayer].inventory[index13].stack > 1)
                                this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object)Main.player[Main.myPlayer].inventory[index13].stack), new Vector2((float)x4 + 10f * Main.inventoryScale, (float)y5 + 26f * Main.inventoryScale), color, 0.0f, new Vector2(), scale4, SpriteEffects.None, 0.0f);
                        }
                    }
                }
                for (int index = 0; index < 3; ++index)
                {
                    int x5 = 330;
                    int y6 = (int)(238.0 + (double)(index * 56) * (double)Main.inventoryScale);
                    color = new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    if (Main.mouseState.X >= x5 && (double)Main.mouseState.X <= (double)x5 + (double)Main.hotbarTexture.Width * (double)Main.inventoryScale && Main.mouseState.Y >= y6 && (double)Main.mouseState.Y <= (double)y6 + (double)Main.hotbarTexture.Height * (double)Main.inventoryScale)
                    {
                        Main.player[Main.myPlayer].mouseInterface = true;
                        if (Main.mouseLeftRelease && Main.mouseState.LeftButton == ButtonState.Pressed && (Main.mouseItem.type == 0 || Main.mouseItem.headSlot > 0 && index == 0 || Main.mouseItem.bodySlot > 0 && index == 1 || Main.mouseItem.legSlot > 0 && index == 2))
                        {
                            Item mouseItem = Main.mouseItem;
                            Main.mouseItem = Main.player[Main.myPlayer].armor[index];
                            Main.player[Main.myPlayer].armor[index] = mouseItem;
                            if (Main.player[Main.myPlayer].armor[index].type == 0 || Main.player[Main.myPlayer].armor[index].stack < 1)
                                Main.player[Main.myPlayer].armor[index] = new Item();
                            if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                                Main.mouseItem = new Item();
                            if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].armor[index].type > 0)
                            {
                                Recipe.FindRecipes();
                                Main.soundInstanceGrab.Stop();
                                Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
                                Main.soundInstanceGrab.Play();
                            }
                        }
                        text1 = Main.player[Main.myPlayer].armor[index].name;
                        if (Main.player[Main.myPlayer].armor[index].stack > 1)
                            text1 = text1 + " (" + (object)Main.player[Main.myPlayer].armor[index].stack + ")";
                    }
                    this.spriteBatch.Draw(Main.hotbarTexture, new Vector2((float)x5, (float)y6), new Rectangle?(new Rectangle(0, 0, Main.hotbarTexture.Width, Main.hotbarTexture.Height)), color, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                    this.spriteBatch.Draw(Main.inventoryBackTexture, new Vector2((float)x5, (float)y6), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), new Color(200, 200, 200, 200), 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                    color = Color.White;
                    if (Main.player[Main.myPlayer].armor[index].type > 0 && Main.player[Main.myPlayer].armor[index].stack > 0)
                    {
                        float num30 = 1f;
                        if (Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Height > 32)
                            num30 = Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Height ? 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Height : 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Width;
                        float scale5 = num30 * Main.inventoryScale;
                        this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].armor[index].type], new Vector2((float)((double)x5 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Width * 0.5 * (double)scale5), (float)((double)y6 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Height * 0.5 * (double)scale5)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Height)), Main.player[Main.myPlayer].armor[index].GetAlpha(color), 0.0f, new Vector2(), scale5, SpriteEffects.None, 0.0f);
                        if (Main.player[Main.myPlayer].armor[index].color != new Color())
                            this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].armor[index].type], new Vector2((float)((double)x5 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Width * 0.5 * (double)scale5), (float)((double)y6 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Height * 0.5 * (double)scale5)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[index].type].Height)), Main.player[Main.myPlayer].armor[index].GetColor(color), 0.0f, new Vector2(), scale5, SpriteEffects.None, 0.0f);
                        if (Main.player[Main.myPlayer].armor[index].stack > 1)
                            this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object)Main.player[Main.myPlayer].armor[index].stack), new Vector2((float)x5 + 10f * Main.inventoryScale, (float)y6 + 26f * Main.inventoryScale), color, 0.0f, new Vector2(), scale5, SpriteEffects.None, 0.0f);
                    }
                }
                Color white6;
                for (int index = 0; index < Recipe.maxRecipes; ++index)
                {
                    Main.inventoryScale = (float)(100.0 / ((double)Math.Abs(Main.availableRecipeY[index]) + 100.0));
                    if ((double)Main.inventoryScale < 1)
                        Main.inventoryScale = 1;
                    if ((double)Main.availableRecipeY[index] < (double)((index - Main.focusRecipe) * 65))
                    {
                        if ((double)Main.availableRecipeY[index] == 0.0)
                            Main.soundInstanceMenuTick.Play();
                        Main.availableRecipeY[index] += 6.5f;
                    }
                    else if ((double)Main.availableRecipeY[index] > (double)((index - Main.focusRecipe) * 65))
                    {
                        if ((double)Main.availableRecipeY[index] == 0.0)
                            Main.soundInstanceMenuTick.Play();
                        Main.availableRecipeY[index] -= 6.5f;
                    }
                    if (index < Main.numAvailableRecipes && (double)Math.Abs(Main.availableRecipeY[index]) <= 250.0)
                    {
                        int x6 = (int)(46.0 - 26.0 * (double)Main.inventoryScale);
                        int y7 = (int)(400.0 + (double)Main.availableRecipeY[index] * (double)Main.inventoryScale - 30.0 * (double)Main.inventoryScale);
                        double num31 = (double)byte.MaxValue;
                        if ((double)Math.Abs(Main.availableRecipeY[index]) > 150.0)
                            num31 = (double)byte.MaxValue * (100.0 - ((double)Math.Abs(Main.availableRecipeY[index]) - 150.0)) * 0.01;
                        white6 = Color.White with
                        {
                            R = (byte)num31,
                            G = (byte)num31,
                            B = (byte)num31,
                            A = (byte)num31
                        };
                        if (Main.mouseState.X >= x6 && (double)Main.mouseState.X <= (double)x6 + (double)Main.hotbarTexture.Width * (double)Main.inventoryScale && Main.mouseState.Y >= y7 && (double)Main.mouseState.Y <= (double)y7 + (double)Main.hotbarTexture.Height * (double)Main.inventoryScale)
                        {
                            Main.player[Main.myPlayer].mouseInterface = true;
                            if (Main.mouseLeftRelease && Main.mouseState.LeftButton == ButtonState.Pressed)
                            {
                                if (Main.focusRecipe == index)
                                {
                                    if (Main.mouseItem.type == 0 || Main.mouseItem.IsTheSameAs(Main.recipe[Main.availableRecipe[index]].createItem) && Main.mouseItem.stack + Main.recipe[Main.availableRecipe[index]].createItem.stack <= Main.mouseItem.maxStack)
                                    {
                                        int stack = Main.mouseItem.stack;
                                        Main.mouseItem = (Item)Main.recipe[Main.availableRecipe[index]].createItem.Clone();
                                        Main.mouseItem.stack += stack;
                                        Main.recipe[Main.availableRecipe[index]].Create();
                                        if (Main.mouseItem.type > 0 || Main.recipe[Main.availableRecipe[index]].createItem.type > 0)
                                        {
                                            Main.soundInstanceGrab.Stop();
                                            Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
                                            Main.soundInstanceGrab.Play();
                                        }
                                    }
                                }
                                else
                                    Main.focusRecipe = index;
                            }
                            text1 = Main.recipe[Main.availableRecipe[index]].createItem.name;
                            if (Main.recipe[Main.availableRecipe[index]].createItem.stack > 1)
                                text1 = text1 + " (" + (object)Main.recipe[Main.availableRecipe[index]].createItem.stack + ")";
                        }
                        this.spriteBatch.Draw(Main.hotbarTexture, new Vector2((float)x6, (float)y7), new Rectangle?(new Rectangle(0, 0, Main.hotbarTexture.Width, Main.hotbarTexture.Height)), white6, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                        double num32 = num31 - 50.0;
                        if (num32 < 0.0)
                            num32 = 0.0;
                        this.spriteBatch.Draw(Main.inventoryBackTexture, new Vector2((float)x6, (float)y7), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), new Color((int)(byte)num32, (int)(byte)num32, (int)(byte)num32, (int)(byte)num32), 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                        if (Main.recipe[Main.availableRecipe[index]].createItem.type > 0 && Main.recipe[Main.availableRecipe[index]].createItem.stack > 0)
                        {
                            float num33 = 1f;
                            if (Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Width > 32 || Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Height > 32)
                                num33 = Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Width <= Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Height ? 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Height : 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Width;
                            float scale6 = num33 * Main.inventoryScale;
                            this.spriteBatch.Draw(Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type], new Vector2((float)((double)x6 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Width * 0.5 * (double)scale6), (float)((double)y7 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Height * 0.5 * (double)scale6)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Height)), Main.recipe[Main.availableRecipe[index]].createItem.GetAlpha(white6), 0.0f, new Vector2(), scale6, SpriteEffects.None, 0.0f);
                            if (Main.recipe[Main.availableRecipe[index]].createItem.color != new Color())
                                this.spriteBatch.Draw(Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type], new Vector2((float)((double)x6 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Width * 0.5 * (double)scale6), (float)((double)y7 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Height * 0.5 * (double)scale6)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[index]].createItem.type].Height)), Main.recipe[Main.availableRecipe[index]].createItem.GetColor(white6), 0.0f, new Vector2(), scale6, SpriteEffects.None, 0.0f);
                            if (Main.recipe[Main.availableRecipe[index]].createItem.stack > 1)
                                this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object)Main.recipe[Main.availableRecipe[index]].createItem.stack), new Vector2((float)x6 + 10f * Main.inventoryScale, (float)y7 + 26f * Main.inventoryScale), white6, 0.0f, new Vector2(), scale6, SpriteEffects.None, 0.0f);
                        }
                    }
                }
                if (Main.numAvailableRecipes > 0)
                {
                    for (int index = 0; index < Recipe.maxRequirements && Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type != 0; ++index)
                    {
                        int x7 = 80 + index * 40;
                        int y8 = 380;
                        white6 = Color.White;
                        double num34 = (double)byte.MaxValue - (double)Math.Abs(Main.availableRecipeY[Main.focusRecipe]) * 3.0;
                        if (num34 < 0.0)
                            num34 = 0.0;
                        white6.R = (byte)num34;
                        white6.G = (byte)num34;
                        white6.B = (byte)num34;
                        white6.A = (byte)num34;
                        Main.inventoryScale = 0.6f;
                        if (num34 != 0.0)
                        {
                            if (Main.mouseState.X >= x7 && (double)Main.mouseState.X <= (double)x7 + (double)Main.hotbarTexture.Width * (double)Main.inventoryScale && Main.mouseState.Y >= y8 && (double)Main.mouseState.Y <= (double)y8 + (double)Main.hotbarTexture.Height * (double)Main.inventoryScale)
                            {
                                Main.player[Main.myPlayer].mouseInterface = true;
                                text1 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].name;
                                if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].stack > 1)
                                    text1 = text1 + " (" + (object)Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].stack + ")";
                            }
                            this.spriteBatch.Draw(Main.hotbarTexture, new Vector2((float)x7, (float)y8), new Rectangle?(new Rectangle(0, 0, Main.hotbarTexture.Width, Main.hotbarTexture.Height)), white6, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                            double num35 = num34 - 50.0;
                            if (num35 < 0.0)
                                num35 = 0.0;
                            this.spriteBatch.Draw(Main.inventoryBackTexture, new Vector2((float)x7, (float)y8), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), new Color((int)(byte)num35, (int)(byte)num35, (int)(byte)num35, (int)(byte)num35), 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                            if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type > 0 && Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].stack > 0)
                            {
                                float num36 = 1f;
                                if (Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Width > 32 || Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Height > 32)
                                    num36 = Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Width <= Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Height ? 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Height : 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Width;
                                float scale7 = num36 * Main.inventoryScale;
                                this.spriteBatch.Draw(Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type], new Vector2((float)((double)x7 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Width * 0.5 * (double)scale7), (float)((double)y8 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Height * 0.5 * (double)scale7)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Height)), Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].GetAlpha(white6), 0.0f, new Vector2(), scale7, SpriteEffects.None, 0.0f);
                                if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].color != new Color())
                                    this.spriteBatch.Draw(Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type], new Vector2((float)((double)x7 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Width * 0.5 * (double)scale7), (float)((double)y8 + 26.0 * (double)Main.inventoryScale - (double)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Height * 0.5 * (double)scale7)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].type].Height)), Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].GetColor(white6), 0.0f, new Vector2(), scale7, SpriteEffects.None, 0.0f);
                                if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].stack > 1)
                                    this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object)Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index].stack), new Vector2((float)x7 + 10f * Main.inventoryScale, (float)y8 + 26f * Main.inventoryScale), white6, 0.0f, new Vector2(), scale7, SpriteEffects.None, 0.0f);
                            }
                        }
                        else
                            break;
                    }
                }
            }
            if (!Main.playerInventory)
            {
                int x8 = 20;
                for (int index = 0; index < 10; ++index)
                {
                    if (index == Main.player[Main.myPlayer].selectedItem)
                    {
                        if ((double)Main.hotbarScale[index] < 1.0)
                            Main.hotbarScale[index] += 0.05f;
                    }
                    else if ((double)Main.hotbarScale[index] > 0.75)
                        Main.hotbarScale[index] -= 0.05f;
                    int y9 = (int)(20.0 + 22.0 * (1.0 - (double)Main.hotbarScale[index]));
                    Color color = new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)(75.0 + 150.0 * (double)Main.hotbarScale[index]));
                    this.spriteBatch.Draw(Main.hotbarTexture, new Vector2((float)x8, (float)y9), new Rectangle?(new Rectangle(0, 0, Main.hotbarTexture.Width, Main.hotbarTexture.Height)), color, 0.0f, new Vector2(), Main.hotbarScale[index], SpriteEffects.None, 0.0f);
                    if (Main.mouseState.X >= x8 && (double)Main.mouseState.X <= (double)x8 + (double)Main.hotbarTexture.Width * (double)Main.hotbarScale[index] && Main.mouseState.Y >= y9 && (double)Main.mouseState.Y <= (double)y9 + (double)Main.hotbarTexture.Height * (double)Main.hotbarScale[index])
                    {
                        Main.player[Main.myPlayer].mouseInterface = true;
                        if (Main.mouseState.LeftButton == ButtonState.Pressed)
                            Main.player[Main.myPlayer].changeItem = index;
                        Main.player[Main.myPlayer].showItemIcon = false;
                        text1 = Main.player[Main.myPlayer].inventory[index].name;
                        if (Main.player[Main.myPlayer].inventory[index].stack > 1)
                            text1 = text1 + " (" + (object)Main.player[Main.myPlayer].inventory[index].stack + ")";
                    }
                    if (Main.player[Main.myPlayer].inventory[index].type > 0 && Main.player[Main.myPlayer].inventory[index].stack > 0)
                    {
                        float num37 = 1f;
                        if (Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Height > 32)
                            num37 = Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Height ? 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Height : 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Width;
                        float scale8 = num37 * Main.hotbarScale[index];
                        this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type], new Vector2((float)((double)x8 + 26.0 * (double)Main.hotbarScale[index] - (double)Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Width * 0.5 * (double)scale8), (float)((double)y9 + 26.0 * (double)Main.hotbarScale[index] - (double)Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Height * 0.5 * (double)scale8)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Height)), Main.player[Main.myPlayer].inventory[index].GetAlpha(color), 0.0f, new Vector2(), scale8, SpriteEffects.None, 0.0f);
                        if (Main.player[Main.myPlayer].inventory[index].color != new Color())
                            this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type], new Vector2((float)((double)x8 + 26.0 * (double)Main.hotbarScale[index] - (double)Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Width * 0.5 * (double)scale8), (float)((double)y9 + 26.0 * (double)Main.hotbarScale[index] - (double)Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Height * 0.5 * (double)scale8)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index].type].Height)), Main.player[Main.myPlayer].inventory[index].GetColor(color), 0.0f, new Vector2(), scale8, SpriteEffects.None, 0.0f);
                        if (Main.player[Main.myPlayer].inventory[index].stack > 1)
                            this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object)Main.player[Main.myPlayer].inventory[index].stack), new Vector2((float)x8 + 10f * Main.hotbarScale[index], (float)y9 + 26f * Main.hotbarScale[index]), color, 0.0f, new Vector2(), scale8, SpriteEffects.None, 0.0f);
                    }
                    x8 += (int)((double)Main.hotbarTexture.Width * (double)Main.hotbarScale[index]) + 4;
                }
            }
            if (text1 != null && text1 != "" && Main.mouseItem.type == 0)
            {
                Main.player[Main.myPlayer].showItemIcon = false;
                this.spriteBatch.DrawString(Main.fontMouseText, text1, new Vector2((float)(Main.mouseState.X + 10), (float)(Main.mouseState.Y + 10)), new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                flag = true;
            }
            if (Main.player[Main.myPlayer].dead)
            {
                string text2 = Main.player[Main.myPlayer].name + " was slain...";
                this.spriteBatch.DrawString(Main.fontDeathText, text2, new Vector2((float)(Main.screenWidth / 2 - text2.Length * 10), (float)(Main.screenHeight / 2 - 20)), Main.player[Main.myPlayer].GetDeathAlpha(new Color(0, 0, 0, 0)), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
            this.spriteBatch.Draw(Main.cursorTexture, new Vector2((float)Main.mouseState.X, (float)Main.mouseState.Y), new Rectangle?(new Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height)), Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
            {
                Main.player[Main.myPlayer].showItemIcon = false;
                Main.player[Main.myPlayer].showItemIcon2 = 0;
                flag = true;
                float num38 = 1f;
                if (Main.itemTexture[Main.mouseItem.type].Width > 32 || Main.itemTexture[Main.mouseItem.type].Height > 32)
                    num38 = Main.itemTexture[Main.mouseItem.type].Width <= Main.itemTexture[Main.mouseItem.type].Height ? 32f / (float)Main.itemTexture[Main.mouseItem.type].Height : 32f / (float)Main.itemTexture[Main.mouseItem.type].Width;
                float num39 = 1f;
                Color white7 = Color.White;
                float scale9 = num38 * num39;
                this.spriteBatch.Draw(Main.itemTexture[Main.mouseItem.type], new Vector2((float)((double)Main.mouseState.X + 26.0 * (double)num39 - (double)Main.itemTexture[Main.mouseItem.type].Width * 0.5 * (double)scale9), (float)((double)Main.mouseState.Y + 26.0 * (double)num39 - (double)Main.itemTexture[Main.mouseItem.type].Height * 0.5 * (double)scale9)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.mouseItem.type].Width, Main.itemTexture[Main.mouseItem.type].Height)), Main.mouseItem.GetAlpha(white7), 0.0f, new Vector2(), scale9, SpriteEffects.None, 0.0f);
                if (Main.mouseItem.color != new Color())
                    this.spriteBatch.Draw(Main.itemTexture[Main.mouseItem.type], new Vector2((float)((double)Main.mouseState.X + 26.0 * (double)num39 - (double)Main.itemTexture[Main.mouseItem.type].Width * 0.5 * (double)scale9), (float)((double)Main.mouseState.Y + 26.0 * (double)num39 - (double)Main.itemTexture[Main.mouseItem.type].Height * 0.5 * (double)scale9)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.mouseItem.type].Width, Main.itemTexture[Main.mouseItem.type].Height)), Main.mouseItem.GetColor(white7), 0.0f, new Vector2(), scale9, SpriteEffects.None, 0.0f);
                if (Main.mouseItem.stack > 1)
                    this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object)Main.mouseItem.stack), new Vector2((float)Main.mouseState.X + 10f * num39, (float)Main.mouseState.Y + 26f * num39), white7, 0.0f, new Vector2(), scale9, SpriteEffects.None, 0.0f);
            }
            Rectangle rectangle2 = new Rectangle((int)((double)Main.mouseState.X + (double)Main.screenPosition.X), (int)((double)Main.mouseState.Y + (double)Main.screenPosition.Y), 1, 1);
            Main.mouseTextColor += (byte)Main.mouseTextColorChange;
            if (Main.mouseTextColor >= (byte)250)
                Main.mouseTextColorChange = -4;
            if (Main.mouseTextColor <= (byte)175)
                Main.mouseTextColorChange = 4;
            if (!flag)
            {
                int num40 = 26 * Main.player[Main.myPlayer].statLifeMax / num23;
                int num41 = 0;
                if (Main.player[Main.myPlayer].statLifeMax > 200)
                {
                    num40 -= 260;
                    num41 += 26;
                }
                if (Main.mouseState.X > screenWidth - 158 && Main.mouseState.X < screenWidth - 158 + num40 && Main.mouseState.Y > 32 && Main.mouseState.Y < 32 + Main.heartTexture.Height + num41)
                {
                    Main.player[Main.myPlayer].showItemIcon = false;
                    string text3 = "Life: " + (object)Main.player[Main.myPlayer].statLife + "/" + (object)Main.player[Main.myPlayer].statLifeMax;
                    this.spriteBatch.DrawString(Main.fontMouseText, text3, new Vector2(Main.mouseState.X >= screenWidth - 109 ? screenWidth - 99 : (float)(Main.mouseState.X + 10), (float)(Main.mouseState.Y + 10)), new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                    flag = true;
                }
            }
            if (!flag)
            {
                for (int index = 0; index < 1000; ++index)
                {
                    if (Main.item[index].active)
                    {
                        Rectangle rectangle3 = new Rectangle((int)((double)Main.item[index].position.X + (double)Main.item[index].width * 0.5 - (double)Main.itemTexture[Main.item[index].type].Width * 0.5), (int)((double)Main.item[index].position.Y + (double)Main.item[index].height - (double)Main.itemTexture[Main.item[index].type].Height), Main.itemTexture[Main.item[index].type].Width, Main.itemTexture[Main.item[index].type].Height);
                        if (rectangle2.Intersects(rectangle3))
                        {
                            Main.player[Main.myPlayer].showItemIcon = false;
                            string text4 = Main.item[index].name;
                            if (Main.item[index].stack > 1)
                                text4 = text4 + " (" + (object)Main.item[index].stack + ")";
                            this.spriteBatch.DrawString(Main.fontMouseText, text4, new Vector2((float)(Main.mouseState.X + 10), (float)(Main.mouseState.Y + 10)), new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                            flag = true;
                            break;
                        }
                    }
                }
            }
            if (!flag)
            {
                for (int index = 0; index < 1000; ++index)
                {
                    if (Main.npc[index].active)
                    {
                        Rectangle rectangle4 = new Rectangle((int)((double)Main.npc[index].position.X + (double)Main.npc[index].width * 0.5 - (double)Main.npcTexture[Main.npc[index].type].Width * 0.5), (int)((double)Main.npc[index].position.Y + (double)Main.npc[index].height - (double)(Main.npcTexture[Main.npc[index].type].Height / Main.npcFrameCount[Main.npc[index].type])), Main.npcTexture[Main.npc[index].type].Width, Main.npcTexture[Main.npc[index].type].Height / Main.npcFrameCount[Main.npc[index].type]);
                        if (rectangle2.Intersects(rectangle4))
                        {
                            Main.player[Main.myPlayer].showItemIcon = false;
                            string text5 = Main.npc[index].name + ": " + (object)Main.npc[index].life + "/" + (object)Main.npc[index].lifeMax;
                            this.spriteBatch.DrawString(Main.fontMouseText, text5, new Vector2((float)(Main.mouseState.X + 10), (float)(Main.mouseState.Y + 10)), new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                            break;
                        }
                    }
                }
            }
            int pos = 1;
            this.spriteBatch.DrawString(Main.fontMouseText, this.IsFixedTimeStep ? $"{fps}fps (capped)" : $"{fps}fps", new Vector2(32, screenHeight - 32 - 23 * pos), Color.White);
            pos++;
            if (cheats)
            {
                this.spriteBatch.DrawString(Main.fontMouseText, "Cheats Enabled", new Vector2(32, screenHeight - 32 - 23 * pos), Color.White);
                pos++;
            }
            if (dumbAI)
            { 
            this.spriteBatch.DrawString(Main.fontMouseText, "Dumb AI Enabled", new Vector2(32, screenHeight - 32 - 23 * pos), Color.White);
                pos++;
            }
            if (debugMode)
            {
                this.spriteBatch.DrawString(Main.fontMouseText, "Freecam Enabled", new Vector2(32, screenHeight - 32 - 23 * pos), Color.White);
                pos++;
            }
            if (godMode)
            {
                this.spriteBatch.DrawString(Main.fontMouseText, "God Mode Enabled", new Vector2(32, screenHeight - 32 - 23 * pos), Color.White);
                pos++;
            }
            if (infiniteReach)
            {
                this.spriteBatch.DrawString(Main.fontMouseText, "Infinite Reach Enabled", new Vector2(32, screenHeight - 32 - 23 * pos), Color.White);
                pos++;
            }            
            if (Lighting.disableLighting)
            {
                this.spriteBatch.DrawString(Main.fontMouseText, "Lighting Disabled", new Vector2(32, screenHeight - 32 - 23 * pos), Color.White);
                pos++;
            }
            if (player[0].superMovement)
            {
                this.spriteBatch.DrawString(Main.fontMouseText, "Super Movement Enabled", new Vector2(32, screenHeight - 32 - 23 * pos), Color.White);
                pos++;
            }
            if (Main.player[Main.myPlayer].showItemIcon && (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type > 0 || Main.player[Main.myPlayer].showItemIcon2 > 0))
            {
                int index = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type;
                Color color1 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].GetAlpha(Color.White);
                Color color2 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].GetColor(Color.White);
                if (Main.player[Main.myPlayer].showItemIcon2 > 0)
                {
                    index = Main.player[Main.myPlayer].showItemIcon2;
                    color1 = Color.White;
                    color2 = new Color();
                }
                this.spriteBatch.Draw(Main.itemTexture[index], new Vector2((float)(Main.mouseState.X + 10), (float)(Main.mouseState.Y + 10)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[index].Width, Main.itemTexture[index].Height)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                if (Main.player[Main.myPlayer].showItemIcon2 == 0 && Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].color != new Color())
                    this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type], new Vector2((float)(Main.mouseState.X + 10), (float)(Main.mouseState.Y + 10)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type].Height)), color2, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
            Main.player[Main.myPlayer].showItemIcon = false;
            Main.player[Main.myPlayer].showItemIcon2 = 0;
            this.spriteBatch.End();
            if (Main.mouseState.LeftButton == ButtonState.Pressed)
                Main.mouseLeftRelease = false;
            else
                Main.mouseLeftRelease = true;
        }

        private static void UpdateTime()
        {
            ++Main.time;
            if (!Main.dayTime)
            {
                if (Main.time <= 30000.0)
                    return;
                Main.time = 0.0;
                Main.dayTime = true;
                ++Main.moonPhase;
                if (Main.moonPhase >= 8)
                    Main.moonPhase = 0;
            }
            else if (Main.time > 40000.0)
            {
                Main.time = 0.0;
                Main.dayTime = false;
            }
        }

        public static double CalculateDamage(int Damage, int Defense) => (double)Damage / ((double)Defense * 0.1);
        private static void UpdateCheats()
        {
            if ((Main.keyState.IsKeyDown(Keys.LeftControl) || Main.keyState.IsKeyDown(Keys.RightControl)) && Main.keyState.IsKeyDown(Keys.X))
            {
                if (releaseDebug)
                {
                    debugMode = !debugMode;
                }
                releaseDebug = false;
            }
            else
                releaseDebug = true;
            if ((Main.keyState.IsKeyDown(Keys.LeftControl) || Main.keyState.IsKeyDown(Keys.RightControl)) && Main.keyState.IsKeyDown(Keys.C))
            {
                if (releaseDumbAI)
                {
                    dumbAI = !dumbAI;
                }
                releaseDumbAI = false;
            }
            else
                releaseDumbAI = true;
            if ((Main.keyState.IsKeyDown(Keys.LeftControl) || Main.keyState.IsKeyDown(Keys.RightControl)) && Main.keyState.IsKeyDown(Keys.V))
            {
                if (releaseGodMode)
                {
                    godMode = !godMode;
                }
                releaseGodMode = false;
            }
            else
                releaseGodMode = true;
            if ((Main.keyState.IsKeyDown(Keys.LeftControl) || Main.keyState.IsKeyDown(Keys.RightControl)) && Main.keyState.IsKeyDown(Keys.B))
            {
                if (releaseInfinite)
                {
                    if (infiniteReach)
                    {
                        player[0].pItemGrabRange = 32;
                        player[0].pItemGrabSpeed = 0.4f;
                        player[0].pItemGrabSpeedMax = 4f;
                    }
                    else
                    {
                        player[0].pItemGrabRange = 3200;
                        player[0].pItemGrabSpeed = 4f;
                        player[0].pItemGrabSpeedMax = 40f;
                    }
                    infiniteReach = !infiniteReach;
                }
                releaseInfinite = false;
            }
            else
                releaseInfinite = true;
            if ((Main.keyState.IsKeyDown(Keys.LeftControl) || Main.keyState.IsKeyDown(Keys.RightControl)) && Main.keyState.IsKeyDown(Keys.N))
            {
                if (releaseLighting)
                {
                    Lighting.disableLighting = !Lighting.disableLighting;
                }
                releaseLighting = false;
            }
            else
                releaseLighting = true;
            if ((Main.keyState.IsKeyDown(Keys.LeftControl) || Main.keyState.IsKeyDown(Keys.RightControl)) && Main.keyState.IsKeyDown(Keys.M))
            {
                if (releaseMovement)
                {
                    player[0].superMovement = !player[0].superMovement;
                }
                releaseMovement = false;
            }
            else
                releaseMovement = true;
            int i = (int)(((double)Main.mouseState.X + (double)Main.screenPosition.X) / 16.0);
            int j = (int)(((double)Main.mouseState.Y + (double)Main.screenPosition.Y) / 16.0);
            if (Main.mouseState.X >= Main.screenWidth || Main.mouseState.Y >= Main.screenHeight || i < 0 || j < 0 || i >= 5001 || j >= 2501)
                return;
            if (Main.mouseState.X >= Main.screenWidth || Main.mouseState.Y >= Main.screenHeight || i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY)
                return;
            Lighting.addLight(i, j, 0xFF);
        }
        private static void UpdateInfinite()
        {
            int i = (int)(((double)Main.mouseState.X + (double)Main.screenPosition.X) / 16.0);
            int j = (int)(((double)Main.mouseState.Y + (double)Main.screenPosition.Y) / 16.0);
            if (Main.mouseState.X >= Main.screenWidth || Main.mouseState.Y >= Main.screenHeight || i < 0 || j < 0 || i >= 5001 || j >= 2501)
                return;
            if (Main.mouseState.X >= Main.screenWidth || Main.mouseState.Y >= Main.screenHeight || i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY)
                return;
            else if (Main.mouseState.LeftButton == ButtonState.Pressed)
            {
                WorldGen.KillTile(i, j);
                WorldGen.KillWall(i, j);
            }
            else if (Main.mouseState.RightButton == ButtonState.Pressed)
            {
                Item Selected = Main.player[0].inventory[Main.player[0].selectedItem];
                bool Tile = Selected.createTile != -1;
                bool Wall = Selected.createWall != -1;
                if (Tile)
                {
                    WorldGen.PlaceTile(i, j, Selected.createTile);
                }
                else if (Wall)
                {
                    WorldGen.PlaceWall(i, j, Selected.createWall);
                }
                else
                {
                    WorldGen.PlaceTile(i, j, 2);
                }
            }
        }
        private static void UpdateDebug()
        {
            if (Main.keyState.IsKeyDown(Keys.Left))
                Main.screenPosition.X -= 8f;
            if (Main.keyState.IsKeyDown(Keys.Right))
                Main.screenPosition.X += 8f;
            if (Main.keyState.IsKeyDown(Keys.Up))
                Main.screenPosition.Y -= 8f;
            if (Main.keyState.IsKeyDown(Keys.Down))
                Main.screenPosition.Y += 8f;
            int i = (int)(((double)Main.mouseState.X + (double)Main.screenPosition.X) / 16.0);
            int j = (int)(((double)Main.mouseState.Y + (double)Main.screenPosition.Y) / 16.0);
            if (Main.mouseState.X >= Main.screenWidth || Main.mouseState.Y >= Main.screenHeight || i < 0 || j < 0 || i >= 5001 || j >= 2501)
                return;
            if (Main.mouseState.X >= Main.screenWidth || Main.mouseState.Y >= Main.screenHeight || i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY)
                return;
            if (Main.mouseState.MiddleButton == ButtonState.Pressed)
            {
                Main.player[0].position.X = (float)(i * 16);
                Main.player[0].position.Y = (float)(j * 16);
            }
            // spawn slime function
            // if (Main.mouseState.RightButton == ButtonState.Pressed && Main.mouseState.LeftButton == ButtonState.Pressed)
            // {
            //     if (Main.player[Main.myPlayer].releaseUseItem)
            //     {
            //         int index = NPC.NewNPC((int)((double)Main.mouseState.X + (double)Main.screenPosition.X), (int)((double)Main.mouseState.Y + (double)Main.screenPosition.Y), 1);
            //         Main.dayTime = true;
            //         Main.npc[index].name = "Yellow Slime";
            //         Main.npc[index].scale = 1.2f;
            //         Main.npc[index].damage = 15;
            //         Main.npc[index].defense = 15;
            //         Main.npc[index].life = 50;
            //         Main.npc[index].lifeMax = Main.npc[index].life;
            //         Main.npc[index].color = new Color((int)byte.MaxValue, 200, 0, 100);
            //     }
            // }
            // original Debug Right-Click function
            // else if (Main.mouseState.RightButton == ButtonState.Pressed)
            // {
            //     if (!Main.tile[i, j].active)
            //         WorldGen.PlaceTile(i, j, 4);
            // }

        }
    }
}