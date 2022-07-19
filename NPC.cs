// Decompiled with JetBrains decompiler
// Type: Terraria.NPC
// Assembly: Terraria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2B842C06-302B-4218-9B94-AD87188E4CC4
// Assembly location: C:\Games\Terraria Proto\0.0.0.0\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
    public class NPC
    {
        public static int immuneTime = 20;
        public static int maxAI = 10;
        public static float gravity = 0.3f;
        public static float maxFallSpeed = 10f;
        private static int spawnSpaceX = 4;
        private static int spawnSpaceY = 4;
        private static int spawnRangeX = (int)((double)(Main.screenWidth / 16) * 1.2);
        private static int spawnRangeY = (int)((double)(Main.screenHeight / 16) * 1.2);
        private static int safeRangeX = (int)((double)(Main.screenWidth / 16) * 0.55);
        private static int safeRangeY = (int)((double)(Main.screenHeight / 16) * 0.55);
        private static int activeRangeX = Main.screenWidth * 2;
        private static int activeRangeY = Main.screenHeight * 2;
        private static int activeTime = 1000;
        private static int defaultSpawnRate = 700;
        private static int defaultMaxSpawns = 6;
        private static int spawnRate = NPC.defaultSpawnRate;
        private static int maxSpawns = NPC.defaultMaxSpawns;
        public Vector2 position;
        public Vector2 velocity;
        public int width;
        public int height;
        public bool active;
        public int[] immune = new int[16];
        public int direction = 1;
        public int type;
        public double[] ai = new double[NPC.maxAI];
        public int aiAction = 0;
        public int aiStyle;
        public int timeLeft;
        public int target = -1;
        public int damage;
        public int defense;
        public int soundHit;
        public int soundKilled;
        public int life;
        public int lifeMax;
        public Rectangle targetRect;
        public double frameCounter;
        public Rectangle frame;
        public string name;
        public Color color;
        public int alpha;
        public float scale = 1f;
        public float knockBackResist = 1f;

        public void SetDefaults(int Type)
        {
            this.active = true;
            this.alpha = 0;
            this.color = new Color();
            this.frameCounter = 0.0;
            this.knockBackResist = 1f;
            this.scale = 1f;
            this.soundHit = 0;
            this.soundKilled = 0;
            this.target = -1;
            this.targetRect = new Rectangle();
            this.timeLeft = NPC.activeTime;
            this.type = Type;
            for (int index = 0; index < NPC.maxAI; ++index)
                this.ai[index] = 0.0;
            if (this.type == 1)
            {
                this.name = "Blue Slime";
                this.width = 24;
                this.height = 18;
                this.aiStyle = 1;
                this.damage = 7;
                this.defense = 10;
                this.lifeMax = 30;
                this.soundHit = 1;
                this.soundKilled = 1;
                this.alpha = 175;
                this.color = new Color(0, 80, (int)byte.MaxValue, 100);
            }
            this.frame = new Rectangle(0, 0, Main.npcTexture[this.type].Width, Main.npcTexture[this.type].Height / Main.npcFrameCount[this.type]);
            this.width = (int)((double)this.width * (double)this.scale);
            this.height = (int)((double)this.height * (double)this.scale);
            this.life = this.lifeMax;
            if (!Main.dumbAI)
                return;
            this.aiStyle = 0;
        }

        public void AI()
        {
            if (this.aiStyle == 0)
            {
                this.velocity.X *= 0.93f;
                if ((double)this.velocity.X <= -0.1 || (double)this.velocity.X >= 0.1)
                    return;
                this.velocity.X = 0.0f;
            }
            else
            {
                if (this.aiStyle != 1)
                    return;
                this.aiAction = 0;
                if (this.ai[2] == 0.0)
                {
                    this.ai[0] = -100.0;
                    this.ai[2] = 1.0;
                }
                if ((double)this.velocity.Y == 0.0)
                {
                    this.velocity.X *= 0.8f;
                    if ((double)this.velocity.X > -0.1 && (double)this.velocity.X < 0.1)
                        this.velocity.X = 0.0f;
                    ++this.ai[0];
                    if (this.ai[0] >= 0.0)
                    {
                        this.direction = this.FindTarget();
                        if (this.ai[1] == 2.0)
                        {
                            this.velocity.Y = -8f;
                            this.velocity.X += (float)(3 * this.direction);
                            this.ai[0] = -100.0;
                            this.ai[1] = 0.0;
                        }
                        else
                        {
                            this.velocity.Y = -5.5f;
                            this.velocity.X += (float)(2 * this.direction);
                            this.ai[0] = -60.0;
                            ++this.ai[1];
                        }
                    }
                    else if (this.ai[0] >= -30.0)
                        this.aiAction = 1;
                }
                else if (this.target >= 0 && (this.direction == 1 && (double)this.velocity.X < 3.0 || this.direction == -1 && (double)this.velocity.X > -3.0))
                {
                    if (this.direction == -1 && (double)this.velocity.X < 0.1 || this.direction == 1 && (double)this.velocity.X > -0.1)
                        this.velocity.X += 0.2f * (float)this.direction;
                    else
                        this.velocity.X *= 0.93f;
                }
            }
        }

        public void FindFrame()
        {
            int num1 = Main.npcTexture[this.type].Height / Main.npcFrameCount[this.type];
            int num2 = 0;
            if (this.aiAction == 0)
                num2 = (double)this.velocity.Y >= 0.0 ? ((double)this.velocity.Y <= 0.0 ? ((double)this.velocity.X == 0.0 ? 0 : 1) : 3) : 2;
            else if (this.aiAction == 1)
                num2 = 4;
            if (this.type != 1)
                return;
            ++this.frameCounter;
            if (num2 > 0)
                ++this.frameCounter;
            if (num2 == 4)
                ++this.frameCounter;
            if (this.frameCounter >= 8.0)
            {
                this.frame.Y += num1;
                this.frameCounter = 0.0;
            }
            if (this.frame.Y >= num1 * Main.npcFrameCount[this.type])
                this.frame.Y = 0;
        }

        public int FindTarget()
        {
            if (this.target == -1)
            {
                int num = -1;
                for (int index = 0; index < 16; ++index)
                {
                    if (Main.player[index].active && !Main.player[index].dead && (num == -1 || (double)Math.Abs(Main.player[index].position.X + (float)(Main.player[index].width / 2) - this.position.X + (float)(this.width / 2)) + (double)Math.Abs(Main.player[index].position.Y + (float)(Main.player[index].height / 2) - this.position.Y + (float)(this.height / 2)) < (double)num))
                        this.target = index;
                }
            }
            if (this.target == -1)
                this.target = 0;
            this.targetRect = new Rectangle((int)Main.player[this.target].position.X, (int)Main.player[this.target].position.Y, Main.player[this.target].width, Main.player[this.target].height);
            return (double)(this.targetRect.X + this.targetRect.Width / 2) < (double)this.position.X + (double)(this.width / 2) ? -1 : 1;
        }

        public void CheckActive()
        {
            if (!this.active)
                return;
            bool flag = false;
            Rectangle rectangle1 = new Rectangle((int)((double)this.position.X + (double)(this.width / 2) - (double)NPC.activeRangeX), (int)((double)this.position.Y + (double)(this.height / 2) - (double)NPC.activeRangeY), NPC.activeRangeX * 2, NPC.activeRangeY * 2);
            Rectangle rectangle2 = new Rectangle((int)((double)this.position.X + (double)(this.width / 2) - (double)Main.screenWidth * 0.5 - (double)this.width), (int)((double)this.position.Y + (double)(this.height / 2) - (double)Main.screenHeight * 0.5 - (double)this.height), Main.screenWidth + this.width * 2, Main.screenHeight + this.height * 2);
            for (int index = 0; index < 16; ++index)
            {
                if (Main.player[index].active)
                {
                    if (rectangle1.Intersects(new Rectangle((int)Main.player[index].position.X, (int)Main.player[index].position.Y, Main.player[index].width, Main.player[index].height)))
                    {
                        flag = true;
                        ++Main.player[index].activeNPCs;
                    }
                    if (rectangle2.Intersects(new Rectangle((int)Main.player[index].position.X, (int)Main.player[index].position.Y, Main.player[index].width, Main.player[index].height)))
                        this.timeLeft = NPC.activeTime;
                }
            }
            --this.timeLeft;
            if (this.timeLeft <= 0)
                flag = false;
            if (!flag)
                this.active = false;
        }

        public static void SpawnNPC()
        {
            bool flag = false;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            for (int index1 = 0; index1 < 16; ++index1)
            {
                NPC.spawnRate = NPC.defaultSpawnRate;
                NPC.maxSpawns = NPC.defaultMaxSpawns;
                if (!Main.dayTime)
                {
                    NPC.spawnRate = (int)((double)NPC.spawnRate * 1.8);
                    NPC.maxSpawns = (int)((double)NPC.maxSpawns * 1.79999995231628);
                }
                if ((double)Main.player[index1].position.Y > Main.worldSurface * 16.0 + (double)Main.screenHeight)
                {
                    NPC.spawnRate = (int)((double)NPC.spawnRate * 1.2);
                    NPC.maxSpawns = (int)((double)NPC.maxSpawns * 1.20000004768372);
                }
                if (Main.player[index1].active && !Main.player[index1].dead && Main.player[index1].activeNPCs < NPC.maxSpawns && Main.rand.Next(NPC.spawnRate) == 0)
                {
                    int minValue1 = (int)((double)Main.player[index1].position.X / 16.0) - NPC.spawnRangeX;
                    int maxValue1 = (int)((double)Main.player[index1].position.X / 16.0) + NPC.spawnRangeX;
                    int minValue2 = (int)((double)Main.player[index1].position.Y / 16.0) - NPC.spawnRangeY;
                    int maxValue2 = (int)((double)Main.player[index1].position.Y / 16.0) + NPC.spawnRangeY;
                    int num4 = (int)((double)Main.player[index1].position.X / 16.0) - NPC.safeRangeX;
                    int num5 = (int)((double)Main.player[index1].position.X / 16.0) + NPC.safeRangeX;
                    int num6 = (int)((double)Main.player[index1].position.Y / 16.0) - NPC.safeRangeY;
                    int num7 = (int)((double)Main.player[index1].position.Y / 16.0) + NPC.safeRangeY;
                    if (minValue1 < 0)
                        minValue1 = 0;
                    if (maxValue1 > 5001)
                        maxValue1 = 5001;
                    if (minValue2 < 0)
                        minValue2 = 0;
                    if (maxValue2 > 2501)
                        maxValue2 = 2501;
                    for (int index2 = 0; index2 < NPC.spawnRate; ++index2)
                    {
                        int index3 = Main.rand.Next(minValue1, maxValue1);
                        int index4 = Main.rand.Next(minValue2, maxValue2);
                        if (!Main.tile[index3, index4].active || !Main.tileSolid[(int)Main.tile[index3, index4].type])
                        {
                            if (Main.tile[index3, index4].wall != (byte)1)
                            {
                                for (int index5 = index4; index5 < 2501; ++index5)
                                {
                                    if (Main.tile[index3, index5].active && Main.tileSolid[(int)Main.tile[index3, index5].type])
                                    {
                                        if (index3 < num4 || index3 > num5 || index5 < num6 || index5 > num7)
                                        {
                                            num3 = (int)Main.tile[index3, index5].type;
                                            num1 = index3;
                                            num2 = index5;
                                            flag = true;
                                            break;
                                        }
                                        break;
                                    }
                                }
                                if (flag)
                                {
                                    int num8 = num1 - NPC.spawnSpaceX / 2;
                                    int num9 = num1 + NPC.spawnSpaceX / 2;
                                    int num10 = num2 - NPC.spawnSpaceY;
                                    int num11 = num2;
                                    if (num8 < 0)
                                        flag = false;
                                    if (num9 > 5001)
                                        flag = false;
                                    if (num10 < 0)
                                        flag = false;
                                    if (num11 > 2501)
                                        flag = false;
                                    if (flag)
                                    {
                                        for (int index6 = num8; index6 < num9; ++index6)
                                        {
                                            for (int index7 = num10; index7 < num11; ++index7)
                                            {
                                                if (Main.tile[index6, index7].active && Main.tileSolid[(int)Main.tile[index6, index7].type])
                                                {
                                                    flag = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                                continue;
                        }
                        if (flag || flag)
                            break;
                    }
                }
                if (flag)
                {
                    if ((double)num2 <= Main.worldSurface)
                    {
                        if (Main.dayTime)
                        {
                            int index8 = NPC.NewNPC(num1 * 16 + 8, num2 * 16, 1);
                            if (Main.rand.Next(3) != 0)
                                break;
                            Main.npc[index8].name = "Green Slime";
                            Main.npc[index8].scale = 0.9f;
                            Main.npc[index8].damage = 8;
                            Main.npc[index8].defense = 7;
                            Main.npc[index8].life = 25;
                            Main.npc[index8].knockBackResist = 1.2f;
                            Main.npc[index8].lifeMax = Main.npc[index8].life;
                            Main.npc[index8].color = new Color(0, (int)byte.MaxValue, 30, 100);
                            break;
                        }
                        int index9 = NPC.NewNPC(num1 * 16 + 8, num2 * 16, 1);
                        if (Main.rand.Next(2) == 0)
                        {
                            Main.npc[index9].name = "Purple Slime";
                            Main.npc[index9].scale = 1.2f;
                            Main.npc[index9].damage = 13;
                            Main.npc[index9].defense = 15;
                            Main.npc[index9].life = 45;
                            Main.npc[index9].knockBackResist = 0.9f;
                            Main.npc[index9].lifeMax = Main.npc[index9].life;
                            Main.npc[index9].color = new Color(200, 0, (int)byte.MaxValue, 150);
                        }
                        break;
                    }
                    if (Main.dayTime)
                    {
                        int index10 = NPC.NewNPC(num1 * 16 + 8, num2 * 16, 1);
                        Main.npc[index10].name = "Red Slime";
                        Main.npc[index10].damage = 12;
                        Main.npc[index10].defense = 10;
                        Main.npc[index10].life = 40;
                        Main.npc[index10].lifeMax = Main.npc[index10].life;
                        Main.npc[index10].color = new Color((int)byte.MaxValue, 30, 0, 100);
                    }
                    else
                    {
                        int index11 = NPC.NewNPC(num1 * 16 + 8, num2 * 16, 1);
                        Main.npc[index11].name = "Yellow Slime";
                        Main.npc[index11].scale = 1.2f;
                        Main.npc[index11].damage = 15;
                        Main.npc[index11].defense = 15;
                        Main.npc[index11].life = 50;
                        Main.npc[index11].lifeMax = Main.npc[index11].life;
                        Main.npc[index11].color = new Color((int)byte.MaxValue, 200, 0, 100);
                    }
                    break;
                }
            }
        }

        public static int NewNPC(int X, int Y, int Type)
        {
            int index1 = -1;
            for (int index2 = 0; index2 < 1000; ++index2)
            {
                if (!Main.npc[index2].active)
                {
                    index1 = index2;
                    break;
                }
            }
            if (index1 < 0)
                return 1001;
            Main.npc[index1] = new NPC();
            Main.npc[index1].SetDefaults(Type);
            Main.npc[index1].position.X = (float)(X - Main.npc[index1].width / 2);
            Main.npc[index1].position.Y = (float)(Y - Main.npc[index1].height);
            Main.npc[index1].active = true;
            Main.npc[index1].timeLeft = NPC.activeTime;
            return index1;
        }

        public double StrikeNPC(int Damage, float knockBack, int hitDirection)
        {
            double damage = Main.CalculateDamage(Damage, this.defense);
            if (damage < 1.0)
                return 0.0;
            this.life -= (int)damage;
            if ((double)knockBack > 0.0)
            {
                this.velocity.Y = (float)(-(double)knockBack * 0.75) * this.knockBackResist;
                this.velocity.X = knockBack * (float)hitDirection * this.knockBackResist;
            }
            this.HitEffect(hitDirection, damage);
            if (this.soundHit > 0)
                Main.soundInstanceNPCHit[this.soundHit].Play();
            if (this.life <= 0)
            {
                if (this.soundKilled > 0)
                    Main.soundInstanceNPCKilled[this.soundKilled].Play();
                this.NPCLoot();
                this.active = false;
            }
            return damage;
        }

        public void NPCLoot()
        {
            int Type = 0;
            if (this.type == 1 && Main.rand.Next(3) <= 1)
                Type = 23;
            if (Type <= 0)
                return;
            int index = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Type);
            if (this.type == 1 && Type == 23)
            {
                Main.item[index].color = this.color;
                Main.item[index].alpha = this.alpha;
            }
        }

        public void HitEffect(int hitDirection = 0, double dmg = 10.0)
        {
            if (this.type != 1)
                return;
            if (this.life > 0)
            {
                for (int index = 0; (double)index < dmg / (double)this.lifeMax * 100.0; ++index)
                    Dust.NewDust(this.position, this.width, this.height, 4, (float)hitDirection, -1f, this.alpha, this.color);
            }
            else
            {
                for (int index = 0; index < 50; ++index)
                    Dust.NewDust(this.position, this.width, this.height, 4, (float)(2 * hitDirection), -2f, this.alpha, this.color);
            }
        }

        public void UpdateNPC(int i)
        {
            if (!this.active)
                return;
            this.AI();
            for (int index = 0; index < 16; ++index)
            {
                if (this.immune[index] > 0)
                    --this.immune[index];
            }
            this.velocity.Y += NPC.gravity;
            if ((double)this.velocity.Y > (double)NPC.maxFallSpeed)
                this.velocity.Y = NPC.maxFallSpeed;
            if ((double)this.velocity.X < 0.1 && (double)this.velocity.X > -0.1)
                this.velocity.X = 0.0f;
            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height);
            this.position += this.velocity;
            this.FindFrame();
            this.CheckActive();
        }

        public Color GetAlpha(Color newColor)
        {
            int r = (int)newColor.R - this.alpha;
            int g = (int)newColor.G - this.alpha;
            int b = (int)newColor.B - this.alpha;
            int a = (int)newColor.A - this.alpha;
            if (a < 0)
                a = 0;
            if (a > (int)byte.MaxValue)
                a = (int)byte.MaxValue;
            return new Color(r, g, b, a);
        }

        public Color GetColor(Color newColor)
        {
            int r = (int)this.color.R - ((int)byte.MaxValue - (int)newColor.R);
            int g = (int)this.color.G - ((int)byte.MaxValue - (int)newColor.G);
            int b = (int)this.color.B - ((int)byte.MaxValue - (int)newColor.B);
            int a = (int)this.color.A - ((int)byte.MaxValue - (int)newColor.A);
            if (r < 0)
                r = 0;
            if (r > (int)byte.MaxValue)
                r = (int)byte.MaxValue;
            if (g < 0)
                g = 0;
            if (g > (int)byte.MaxValue)
                g = (int)byte.MaxValue;
            if (b < 0)
                b = 0;
            if (b > (int)byte.MaxValue)
                b = (int)byte.MaxValue;
            if (a < 0)
                a = 0;
            if (a > (int)byte.MaxValue)
                a = (int)byte.MaxValue;
            return new Color(r, g, b, a);
        }
    }
}