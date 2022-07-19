// Decompiled with JetBrains decompiler
// Type: Terraria.Player
// Assembly: Terraria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2B842C06-302B-4218-9B94-AD87188E4CC4
// Assembly location: C:\Games\Terraria Proto\0.0.0.0\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Terraria
{
    public class Player
    {
        public bool superMovement;
        public Vector2 position;
        public Vector2 velocity;
        public double headFrameCounter;
        public double bodyFrameCounter;
        public double legFrameCounter;
        public bool immune;
        public int immuneTime;
        public int immuneAlphaDirection;
        public int immuneAlpha;
        public int activeNPCs;
        public bool mouseInterface;
        public int changeItem = -1;
        public int selectedItem = 0;
        public Item[] armor = new Item[3];
        public int itemAnimation;
        public int itemAnimationMax;
        public int itemTime;
        public float itemRotation;
        public int itemWidth;
        public int itemHeight;
        public Vector2 itemLocation;
        public Item[] inventory = new Item[40];
        public float headRotation;
        public float bodyRotation;
        public float legRotation;
        public Vector2 headPosition;
        public Vector2 bodyPosition;
        public Vector2 legPosition;
        public Vector2 headVelocity;
        public Vector2 bodyVelocity;
        public Vector2 legVelocity;
        public bool dead = false;
        public int respawnTimer;
        public string name = "";
        public int hitTile;
        public int hitTileX;
        public int hitTileY;
        public int jump;
        public int head = Main.rand.Next(2);
        public int body = 0;
        public int legs = 0;
        public Rectangle headFrame;
        public Rectangle bodyFrame;
        public Rectangle legFrame;
        public bool controlLeft;
        public bool controlRight;
        public bool controlUp;
        public bool controlDown;
        public bool controlJump;
        public bool controlUseItem;
        public bool controlUseTile;
        public bool releaseJump;
        public bool releaseUseItem;
        public bool releaseUseTile;
        public bool releaseInventory;
        public bool delayUseItem;
        public bool active;
        public int width = 20;
        public int height = 42;
        public int direction = 1;
        public bool showItemIcon = false;
        public int showItemIcon2 = 0;
        public int statDefense = 10;
        public int statAttack = 0;
        public int statLifeMax = 100;
        public int statLife = 100;
        private static int tileRangeX = 5;
        private static int tileRangeY = 4;
        private static int tileTargetX;
        private static int tileTargetY;
        private static float maxRunSpeed = 3f;
        private static float runAcceleration = 0.08f;
        private static float runSlowdown = 0.2f;
        private static int jumpHeight = 15;
        private static float jumpSpeed = 5.01f;
        private static float gravity = 0.4f;
        private static float maxFallSpeed = 10f;
        public int pItemGrabRange { get { return itemGrabRange; } set { itemGrabRange = value; } }
        public float pItemGrabSpeed { get { return itemGrabSpeed; } set { itemGrabSpeed = value; } }
        public float pItemGrabSpeedMax { get { return itemGrabSpeedMax; } set { itemGrabSpeedMax = value; } }
        private static int itemGrabRange = 32;
        private static float itemGrabSpeed = 0.4f;
        private static float itemGrabSpeedMax = 4f;

        public void UpdatePlayer(int i)
        {
            if (!this.active)
                return;
            if (this.dead)
            {
                this.changeItem = -1;
                this.itemAnimation = 0;
                this.immuneAlpha += 2;
                if (this.immuneAlpha > (int)byte.MaxValue)
                    this.immuneAlpha = (int)byte.MaxValue;
                --this.respawnTimer;
                this.headPosition += this.headVelocity;
                this.bodyPosition += this.bodyVelocity;
                this.legPosition += this.legVelocity;
                this.headRotation += this.headVelocity.X * 0.1f;
                this.bodyRotation += this.bodyVelocity.X * 0.1f;
                this.legRotation += this.legVelocity.X * 0.1f;
                this.headVelocity.Y += 0.1f;
                this.bodyVelocity.Y += 0.1f;
                this.legVelocity.Y += 0.1f;
                this.headVelocity.X *= 0.99f;
                this.bodyVelocity.X *= 0.99f;
                this.legVelocity.X *= 0.99f;
                if (this.respawnTimer <= 0)
                    this.Spawn();
            }
            else
            {
                if (i == Main.myPlayer)
                {
                    if(superMovement)
                    {
                        maxRunSpeed = 30f;
                        runAcceleration = 0.8f;
                        runSlowdown = 1f;
                        jumpHeight = 1000;
                        jumpSpeed = 15f;
                    }
                    else
                    {
                        maxRunSpeed = 3f;
                        runAcceleration = 0.08f;
                        runSlowdown = 0.2f;
                        jumpHeight = 15;
                        jumpSpeed = 5.01f;
                    }
                    this.controlUp = false;
                    this.controlLeft = false;
                    this.controlDown = false;
                    this.controlRight = false;
                    this.controlJump = false;
                    this.controlUseItem = false;
                    this.controlUseTile = false;
                    if (Main.keyState.IsKeyDown(Keys.W))
                        this.controlUp = true;
                    if (Main.keyState.IsKeyDown(Keys.A))
                        this.controlLeft = true;
                    if (Main.keyState.IsKeyDown(Keys.S))
                        this.controlDown = true;
                    if (Main.keyState.IsKeyDown(Keys.D))
                        this.controlRight = true;
                    if (Main.keyState.IsKeyDown(Keys.Space))
                        this.controlJump = true;
                    if (Main.mouseState.LeftButton == ButtonState.Pressed && !this.mouseInterface)
                        this.controlUseItem = true;
                    if (Main.mouseState.RightButton == ButtonState.Pressed && !this.mouseInterface)
                        this.controlUseTile = true;
                    if (Main.keyState.IsKeyDown(Keys.Escape))
                    {
                        if (this.releaseInventory)
                        {
                            if (!Main.playerInventory)
                            {
                                Recipe.FindRecipes();
                                Main.playerInventory = true;
                                Main.soundMenuOpen.Play();
                            }
                            else
                            {
                                Main.playerInventory = false;
                                Main.soundMenuClose.Play();
                            }
                        }
                        this.releaseInventory = false;
                    }
                    else
                        this.releaseInventory = true;
                    if (this.delayUseItem)
                    {
                        if (!this.controlUseItem)
                            this.delayUseItem = false;
                        this.controlUseItem = false;
                    }
                    if (this.itemAnimation == 0 && this.itemTime == 0)
                    {
                        if (Main.keyState.IsKeyDown(Keys.Q) && this.inventory[this.selectedItem].type > 0 || (Main.mouseState.LeftButton == ButtonState.Pressed && !this.mouseInterface && Main.mouseLeftRelease || !Main.playerInventory) && Main.mouseItem.type > 0)
                        {
                            Item obj = new Item();
                            bool flag = false;
                            if ((Main.mouseState.LeftButton == ButtonState.Pressed && !this.mouseInterface && Main.mouseLeftRelease || !Main.playerInventory) && Main.mouseItem.type > 0)
                            {
                                obj = this.inventory[this.selectedItem];
                                this.inventory[this.selectedItem] = Main.mouseItem;
                                this.delayUseItem = true;
                                this.controlUseItem = false;
                                flag = true;
                            }
                            int index = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[this.selectedItem].type);
                            if (!flag && this.inventory[this.selectedItem].type == 8 && this.inventory[this.selectedItem].stack > 1)
                            {
                                --this.inventory[this.selectedItem].stack;
                            }
                            else
                            {
                                this.inventory[this.selectedItem].position = Main.item[index].position;
                                Main.item[index] = this.inventory[this.selectedItem];
                                this.inventory[this.selectedItem] = new Item();
                            }
                            Main.item[index].noGrabDelay = 100;
                            Main.item[index].velocity.Y = -2f;
                            Main.item[index].velocity.X = (float)(4 * this.direction) + this.velocity.X;
                            if ((Main.mouseState.LeftButton == ButtonState.Pressed && !this.mouseInterface || !Main.playerInventory) && Main.mouseItem.type > 0)
                            {
                                this.inventory[this.selectedItem] = obj;
                                Main.mouseItem = new Item();
                            }
                            else
                            {
                                this.itemAnimation = 10;
                                this.itemAnimationMax = 10;
                            }
                            Recipe.FindRecipes();
                        }
                        if (!Main.playerInventory)
                        {
                            int selectedItem = this.selectedItem;
                            if (Main.keyState.IsKeyDown(Keys.D1))
                                this.selectedItem = 0;
                            if (Main.keyState.IsKeyDown(Keys.D2))
                                this.selectedItem = 1;
                            if (Main.keyState.IsKeyDown(Keys.D3))
                                this.selectedItem = 2;
                            if (Main.keyState.IsKeyDown(Keys.D4))
                                this.selectedItem = 3;
                            if (Main.keyState.IsKeyDown(Keys.D5))
                                this.selectedItem = 4;
                            if (Main.keyState.IsKeyDown(Keys.D6))
                                this.selectedItem = 5;
                            if (Main.keyState.IsKeyDown(Keys.D7))
                                this.selectedItem = 6;
                            if (Main.keyState.IsKeyDown(Keys.D8))
                                this.selectedItem = 7;
                            if (Main.keyState.IsKeyDown(Keys.D9))
                                this.selectedItem = 8;
                            if (Main.keyState.IsKeyDown(Keys.D0))
                                this.selectedItem = 9;
                            if (selectedItem != this.selectedItem)
                                Main.soundInstanceMenuTick.Play();
                            int num = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
                            while (num > 9)
                                num -= 10;
                            while (num < 0)
                                num += 10;
                            this.selectedItem -= num;
                            if (num != 0)
                                Main.soundInstanceMenuTick.Play();
                            if (this.changeItem >= 0)
                            {
                                if (this.selectedItem != this.changeItem)
                                    Main.soundInstanceMenuTick.Play();
                                this.selectedItem = this.changeItem;
                                this.changeItem = -1;
                            }
                            while (this.selectedItem > 9)
                                this.selectedItem -= 10;
                            while (this.selectedItem < 0)
                                this.selectedItem += 10;
                        }
                        else
                        {
                            int num = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
                            Main.focusRecipe += num;
                            if (Main.focusRecipe > Main.numAvailableRecipes - 1)
                                Main.focusRecipe = Main.numAvailableRecipes - 1;
                            if (Main.focusRecipe < 0)
                                Main.focusRecipe = 0;
                        }
                    }
                }
                if (this.mouseInterface)
                    this.delayUseItem = true;
                Player.tileTargetX = (int)(((double)Main.mouseState.X + (double)Main.screenPosition.X) / 16.0);
                Player.tileTargetY = (int)(((double)Main.mouseState.Y + (double)Main.screenPosition.Y) / 16.0);
                if (this.immune)
                {
                    --this.immuneTime;
                    if (this.immuneTime <= 0)
                        this.immune = false;
                    this.immuneAlpha += this.immuneAlphaDirection * 50;
                    if (this.immuneAlpha <= 50)
                        this.immuneAlphaDirection = 1;
                    else if (this.immuneAlpha >= 205)
                        this.immuneAlphaDirection = -1;
                }
                else
                    this.immuneAlpha = 0;
                this.statDefense = 10;
                for (int index = 0; index < 3; ++index)
                    this.statDefense += this.armor[index].defense;
                this.body = this.armor[1].bodySlot;
                this.legs = this.armor[2].legSlot;
                this.headFrame.Width = 32;
                this.headFrame.Height = 48;
                this.bodyFrame.Width = 32;
                this.bodyFrame.Height = 48;
                this.legFrame.Width = 32;
                this.legFrame.Height = 48;
                if (this.controlLeft && (double)this.velocity.X > -(double)Player.maxRunSpeed)
                {
                    if ((double)this.velocity.X > (double)Player.runSlowdown)
                        this.velocity.X -= Player.runSlowdown;
                    this.velocity.X -= Player.runAcceleration;
                    if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
                        this.direction = -1;
                }
                else if (this.controlRight && (double)this.velocity.X < (double)Player.maxRunSpeed)
                {
                    if ((double)this.velocity.X < -(double)Player.runSlowdown)
                        this.velocity.X += Player.runSlowdown;
                    this.velocity.X += Player.runAcceleration;
                    if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
                        this.direction = 1;
                }
                else if ((double)this.velocity.Y == 0.0)
                {
                    if ((double)this.velocity.X > (double)Player.runSlowdown)
                        this.velocity.X -= Player.runSlowdown;
                    else if ((double)this.velocity.X < -(double)Player.runSlowdown)
                        this.velocity.X += Player.runSlowdown;
                    else
                        this.velocity.X = 0.0f;
                }
                else if ((double)this.velocity.X > (double)Player.runSlowdown * 0.5)
                    this.velocity.X -= Player.runSlowdown * 0.5f;
                else if ((double)this.velocity.X < -(double)Player.runSlowdown * 0.5)
                    this.velocity.X += Player.runSlowdown * 0.5f;
                else
                    this.velocity.X = 0.0f;
                if (this.controlJump)
                {
                    if (this.jump > 0)
                    {
                        if ((double)this.velocity.Y > -(double)Player.jumpSpeed + (double)Player.gravity * 2.0)
                        {
                            this.jump = 0;
                        }
                        else
                        {
                            this.velocity.Y = -Player.jumpSpeed;
                            --this.jump;
                        }
                    }
                    else if ((double)this.velocity.Y == 0.0 && this.releaseJump)
                    {
                        this.velocity.Y = -Player.jumpSpeed;
                        this.jump = Player.jumpHeight;
                    }
                    this.releaseJump = false;
                }
                else
                {
                    this.jump = 0;
                    this.releaseJump = true;
                }
                this.velocity.Y += Player.gravity;
                if ((double)this.velocity.Y > (double)Player.maxFallSpeed)
                    this.velocity.Y = Player.maxFallSpeed;
                for (int index = 0; index < 1000; ++index)
                {
                    if (Main.item[index].active && Main.item[index].noGrabDelay == 0)
                    {
                        Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
                        if (rectangle.Intersects(new Rectangle((int)Main.item[index].position.X, (int)Main.item[index].position.Y, Main.item[index].width, Main.item[index].height)))
                        {
                            if (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0)
                                Main.item[index] = this.GetItem(i, Main.item[index]);
                        }
                        else
                        {
                            rectangle = new Rectangle((int)this.position.X - Player.itemGrabRange, (int)this.position.Y - Player.itemGrabRange, this.width + Player.itemGrabRange * 2, this.height + Player.itemGrabRange * 2);
                            if (rectangle.Intersects(new Rectangle((int)Main.item[index].position.X, (int)Main.item[index].position.Y, Main.item[index].width, Main.item[index].height)) && this.ItemSpace(Main.item[index]))
                            {
                                Main.item[index].beingGrabbed = true;
                                if ((double)this.position.X + (double)this.width * 0.5 > (double)Main.item[index].position.X + (double)Main.item[index].width * 0.5)
                                {
                                    if ((double)Main.item[index].velocity.X < (double)Player.itemGrabSpeedMax + (double)this.velocity.X)
                                        Main.item[index].velocity.X += Player.itemGrabSpeed;
                                    if ((double)Main.item[index].velocity.X < 0.0)
                                        Main.item[index].velocity.X += Player.itemGrabSpeed * 0.75f;
                                }
                                else
                                {
                                    if ((double)Main.item[index].velocity.X > -(double)Player.itemGrabSpeedMax + (double)this.velocity.X)
                                        Main.item[index].velocity.X -= Player.itemGrabSpeed;
                                    if ((double)Main.item[index].velocity.X > 0.0)
                                        Main.item[index].velocity.X -= Player.itemGrabSpeed * 0.75f;
                                }
                                if ((double)this.position.Y + (double)this.height * 0.5 > (double)Main.item[index].position.Y + (double)Main.item[index].height * 0.5)
                                {
                                    if ((double)Main.item[index].velocity.Y < (double)Player.itemGrabSpeedMax)
                                        Main.item[index].velocity.Y += Player.itemGrabSpeed;
                                    if ((double)Main.item[index].velocity.Y < 0.0)
                                        Main.item[index].velocity.Y += Player.itemGrabSpeed * 0.75f;
                                }
                                else
                                {
                                    if ((double)Main.item[index].velocity.Y > -(double)Player.itemGrabSpeedMax)
                                        Main.item[index].velocity.Y -= Player.itemGrabSpeed;
                                    if ((double)Main.item[index].velocity.Y > 0.0)
                                        Main.item[index].velocity.Y -= Player.itemGrabSpeed * 0.75f;
                                }
                            }
                        }
                    }
                }
                if ((double)this.position.X / 16.0 - (double)Player.tileRangeX <= (double)Player.tileTargetX && ((double)this.position.X + (double)this.width) / 16.0 + (double)Player.tileRangeX - 1.0 >= (double)Player.tileTargetX && (double)this.position.Y / 16.0 - (double)Player.tileRangeY <= (double)Player.tileTargetY && ((double)this.position.Y + (double)this.height) / 16.0 + (double)Player.tileRangeY - 2.0 >= (double)Player.tileTargetY && Main.tile[Player.tileTargetX, Player.tileTargetY].active)
                {
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte)4)
                    {
                        this.showItemIcon = true;
                        this.showItemIcon2 = 8;
                    }
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte)10 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte)11)
                    {
                        this.showItemIcon = true;
                        this.showItemIcon2 = 25;
                    }
                    if (this.controlUseTile)
                    {
                        if (this.releaseUseTile)
                        {
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte)4)
                                WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY);
                            else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte)10)
                                WorldGen.OpenDoor(Player.tileTargetX, Player.tileTargetY, this.direction);
                            else if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte)11)
                                WorldGen.CloseDoor(Player.tileTargetX, Player.tileTargetY);
                        }
                        this.releaseUseTile = false;
                    }
                    else
                        this.releaseUseTile = true;
                }
                Rectangle rectangle1 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
                for (int index = 0; index < 1000; ++index)
                {
                    if (Main.npc[index].active && rectangle1.Intersects(new Rectangle((int)Main.npc[index].position.X, (int)Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height)))
                    {
                        int hitDirection = -1;
                        if ((double)Main.npc[index].position.X + (double)(Main.npc[index].width / 2) < (double)this.position.X + (double)(this.width / 2))
                            hitDirection = 1;
                        this.Hurt(Main.npc[index].damage, hitDirection);
                    }
                }
                this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height);
                this.position += this.velocity;
                this.ItemCheck(i);
                this.PlayerFrame();
                if (this.statLife > this.statLifeMax)
                    this.statLife = this.statLifeMax;
            }
        }

        private void PlayerFrame()
        {
            this.headFrame.X = 34 * this.head;
            this.bodyFrame.X = 34 * this.body;
            this.legFrame.X = 34 * this.legs;
            this.headFrame.Y = 0;
            if (this.itemAnimation > 0)
            {
                if (this.inventory[this.selectedItem].useStyle == 1 || this.inventory[this.selectedItem].type == 0)
                    this.bodyFrame.Y = (double)this.itemAnimation >= (double)this.itemAnimationMax * 0.333 ? ((double)this.itemAnimation >= (double)this.itemAnimationMax * 0.666 ? 100 : 150) : 200;
                else if (this.inventory[this.selectedItem].useStyle == 2)
                    this.bodyFrame.Y = (double)this.itemAnimation >= (double)this.itemAnimationMax * 0.5 ? 200 : 150;
                else if (this.inventory[this.selectedItem].useStyle == 3)
                    this.bodyFrame.Y = (double)this.itemAnimation <= (double)this.itemAnimationMax * 0.666 ? 200 : 100;
            }
            else
                this.bodyFrame.Y = this.inventory[this.selectedItem].holdStyle != 1 ? ((double)this.velocity.Y >= 0.0 ? ((double)this.velocity.Y <= 0.0 ? 0 : 50) : 50) : 200;
            if ((double)this.velocity.Y < 0.0)
                this.legFrame.Y = 100;
            else if ((double)this.velocity.Y > 0.0)
                this.legFrame.Y = 100;
            else if ((double)this.velocity.X != 0.0)
            {
                if (this.direction < 0 && (double)this.velocity.X > 0.0 || this.direction > 0 && (double)this.velocity.X < 0.0)
                    this.legFrameCounter = 12.0;
                this.legFrameCounter += 0.4 + Math.Abs((double)this.velocity.X * 0.4);
                if (this.legFrameCounter < 6.0)
                    this.legFrame.Y = 0;
                else if (this.legFrameCounter < 12.0)
                    this.legFrame.Y = 50;
                else if (this.legFrameCounter < 18.0)
                    this.legFrame.Y = 100;
                else if (this.legFrameCounter < 24.0)
                {
                    this.legFrame.Y = 50;
                }
                else
                {
                    this.legFrame.Y = 0;
                    this.legFrameCounter = 0.0;
                }
            }
            else
            {
                this.legFrameCounter = 6.0;
                this.legFrame.Y = 0;
            }
        }

        public void Spawn()
        {
            this.headPosition = new Vector2();
            this.bodyPosition = new Vector2();
            this.legPosition = new Vector2();
            this.headRotation = 0.0f;
            this.bodyRotation = 0.0f;
            this.legRotation = 0.0f;
            this.statLife = this.statLifeMax;
            this.immune = true;
            this.dead = false;
            this.immuneTime = 0;
            this.active = true;
            this.position.X = (float)(Main.spawnTileX * 16 + 8 - this.width / 2);
            this.position.Y = (float)(Main.spawnTileY * 16 - this.height);
            this.velocity.X = 0.0f;
            this.velocity.Y = 0.0f;
            for (int i = Main.spawnTileX - 1; i < Main.spawnTileX + 2; ++i)
            {
                for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; ++j)
                {
                    if (Main.tileSolid[(int)Main.tile[i, j].type])
                    {
                        Main.tile[i, j].active = false;
                        Main.tile[i, j].type = (byte)0;
                        WorldGen.SquareTileFrame(i, j);
                    }
                }
            }
            Main.screenPosition.X = this.position.X + (float)(this.width / 2) - (float)(Main.screenWidth / 2);
            Main.screenPosition.Y = this.position.Y + (float)(this.height / 2) - (float)(Main.screenHeight / 2);
        }

        public void Hurt(int Damage, int hitDirection)
        {
            if (this.immune || Main.godMode)
                return;
            double damage = Main.CalculateDamage(Damage, this.statDefense);
            if (damage >= 1.0)
            {
                this.statLife -= (int)damage;
                this.immune = true;
                this.immuneTime = 40;
                this.velocity.X = 4.5f * (float)hitDirection;
                this.velocity.Y = -3.5f;
                int index1 = Main.rand.Next(3);
                Main.soundInstancePlayerHit[index1].Stop();
                Main.soundInstancePlayerHit[index1] = Main.soundPlayerHit[index1].CreateInstance();
                Main.soundInstancePlayerHit[index1].Play();
                if (this.statLife > 0)
                {
                    for (int index2 = 0; (double)index2 < damage / (double)this.statLifeMax * 100.0; ++index2)
                        Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f);
                }
                else
                {
                    this.DropItems();
                    Main.soundPlayerKilled.Play();
                    this.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    this.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    this.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    this.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
                    this.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
                    this.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
                    for (int index3 = 0; (double)index3 < 20.0 + damage / (double)this.statLifeMax * 100.0; ++index3)
                        Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f);
                    this.dead = true;
                    this.respawnTimer = 300;
                    this.immuneAlpha = 0;
                }
            }
        }

        public bool ItemSpace(Item newItem)
        {
            for (int index = 0; index < 40; ++index)
            {
                if (this.inventory[index].type == 0)
                    return true;
            }
            for (int index = 0; index < 40; ++index)
            {
                if (this.inventory[index].type > 0 && this.inventory[index].stack < this.inventory[index].maxStack && newItem.IsTheSameAs(this.inventory[index]))
                    return true;
            }
            return false;
        }

        public Item GetItem(int plr, Item newItem)
        {
            Item obj = newItem;
            if (newItem.noGrabDelay > 0)
                return obj;
            for (int index = 0; index < 40; ++index)
            {
                if (this.inventory[index].type > 0 && this.inventory[index].stack < this.inventory[index].maxStack && obj.IsTheSameAs(this.inventory[index]))
                {
                    Main.soundInstanceGrab.Stop();
                    Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
                    Main.soundInstanceGrab.Play();
                    if (obj.stack + this.inventory[index].stack <= this.inventory[index].maxStack)
                    {
                        this.inventory[index].stack += obj.stack;
                        if (plr == Main.myPlayer)
                            Recipe.FindRecipes();
                        return new Item();
                    }
                    obj.stack -= this.inventory[index].maxStack - this.inventory[index].stack;
                    this.inventory[index].stack = this.inventory[index].maxStack;
                    if (plr == Main.myPlayer)
                        Recipe.FindRecipes();
                }
            }
            for (int index = 0; index < 40; ++index)
            {
                if (this.inventory[index].type == 0)
                {
                    this.inventory[index] = obj;
                    Main.soundInstanceGrab.Stop();
                    Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
                    Main.soundInstanceGrab.Play();
                    if (plr == Main.myPlayer)
                        Recipe.FindRecipes();
                    return new Item();
                }
            }
            return obj;
        }

        public void ItemCheck(int i)
        {
            if (this.inventory[this.selectedItem].autoReuse)
                this.releaseUseItem = true;
            if (this.controlUseItem && this.itemAnimation == 0 && this.releaseUseItem && this.inventory[this.selectedItem].useStyle > 0)
            {
                this.itemAnimation = this.inventory[this.selectedItem].useAnimation;
                this.itemAnimationMax = this.itemAnimation;
                if (this.inventory[this.selectedItem].useSound > 0)
                    Main.soundInstanceItem[this.inventory[this.selectedItem].useSound].Play();
            }
            if (this.itemAnimation > 0)
            {
                this.itemHeight = Main.itemTexture[this.inventory[this.selectedItem].type].Height;
                this.itemWidth = Main.itemTexture[this.inventory[this.selectedItem].type].Width;
                --this.itemAnimation;
                if (this.inventory[this.selectedItem].useStyle == 1)
                {
                    if ((double)this.itemAnimation < (double)this.inventory[this.selectedItem].useAnimation * 0.333)
                    {
                        this.itemLocation.X = (float)((double)this.position.X + (double)this.width * 0.5 + ((double)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 4.0) * (double)this.direction);
                        this.itemLocation.Y = this.position.Y + 24f;
                    }
                    else if ((double)this.itemAnimation < (double)this.inventory[this.selectedItem].useAnimation * 0.666)
                    {
                        this.itemLocation.X = (float)((double)this.position.X + (double)this.width * 0.5 + ((double)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 10.0) * (double)this.direction);
                        this.itemLocation.Y = this.position.Y + 10f;
                    }
                    else
                    {
                        this.itemLocation.X = (float)((double)this.position.X + (double)this.width * 0.5 - ((double)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 4.0) * (double)this.direction);
                        this.itemLocation.Y = this.position.Y + 6f;
                    }
                    this.itemRotation = (float)(((double)this.itemAnimation / (double)this.inventory[this.selectedItem].useAnimation - 0.5) * (double)-this.direction * 3.5 - (double)this.direction * 0.300000011920929);
                }
                else if (this.inventory[this.selectedItem].useStyle == 2)
                {
                    this.itemRotation = (float)((double)this.itemAnimation / (double)this.inventory[this.selectedItem].useAnimation * (double)this.direction * 2.0 + -1.39999997615814 * (double)this.direction);
                    if ((double)this.itemAnimation < (double)this.inventory[this.selectedItem].useAnimation * 0.5)
                    {
                        this.itemLocation.X = (float)((double)this.position.X + (double)this.width * 0.5 + ((double)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 9.0 - (double)this.itemRotation * 12.0 * (double)this.direction) * (double)this.direction);
                        this.itemLocation.Y = (float)((double)this.position.Y + 38.0 + (double)this.itemRotation * (double)this.direction * 4.0);
                    }
                    else
                    {
                        this.itemLocation.X = (float)((double)this.position.X + (double)this.width * 0.5 + ((double)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 9.0 - (double)this.itemRotation * 16.0 * (double)this.direction) * (double)this.direction);
                        this.itemLocation.Y = (float)((double)this.position.Y + 38.0 + (double)this.itemRotation * (double)this.direction);
                    }
                }
                else if (this.inventory[this.selectedItem].useStyle == 3)
                {
                    if ((double)this.itemAnimation > (double)this.inventory[this.selectedItem].useAnimation * 0.666)
                    {
                        this.itemLocation.X = -1000f;
                        this.itemLocation.Y = -1000f;
                        this.itemRotation = -1.3f * (float)this.direction;
                    }
                    else
                    {
                        this.itemLocation.X = (float)((double)this.position.X + (double)this.width * 0.5 + ((double)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 - 4.0) * (double)this.direction);
                        this.itemLocation.Y = this.position.Y + 24f;
                        float num = (float)((double)this.itemAnimation / (double)this.inventory[this.selectedItem].useAnimation * (double)Main.itemTexture[this.inventory[this.selectedItem].type].Width * (double)this.direction * (double)this.inventory[this.selectedItem].scale * 1.20000004768372) - (float)(10 * this.direction);
                        if ((double)num > -4.0 && this.direction == -1)
                            num = -4f;
                        if ((double)num < 4.0 && this.direction == 1)
                            num = 4f;
                        this.itemLocation.X -= num;
                        this.itemRotation = 0.8f * (float)this.direction;
                    }
                }
            }
            else if (this.inventory[this.selectedItem].holdStyle == 1)
            {
                this.itemLocation.X = (float)((double)this.position.X + (double)this.width * 0.5 + ((double)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5 + 4.0) * (double)this.direction);
                this.itemLocation.Y = this.position.Y + 24f;
                this.itemRotation = 0.0f;
            }
            if (this.inventory[this.selectedItem].type == 8)
            {
                int maxValue = 20;
                if (this.itemAnimation > 0)
                    maxValue = 7;
                if (this.direction == -1)
                {
                    if (Main.rand.Next(maxValue) == 0)
                        Dust.NewDust(new Vector2(this.itemLocation.X - 16f, this.itemLocation.Y - 14f), 4, 4, 6, Alpha: 100);
                    Lighting.addLight((int)(((double)this.itemLocation.X - 16.0 + (double)this.velocity.X) / 16.0), (int)(((double)this.itemLocation.Y - 14.0) / 16.0), byte.MaxValue);
                }
                else
                {
                    Main.screenPosition.X = (float)((double)this.position.X + (double)this.width * 0.5 - (double)Main.screenWidth * 0.5);
                    Main.screenPosition.Y = (float)((double)this.position.Y + (double)this.height * 0.5 - (double)Main.screenHeight * 0.5);
                    if (Main.rand.Next(maxValue) == 0)
                        Dust.NewDust(new Vector2(this.itemLocation.X + 6f, this.itemLocation.Y - 14f), 4, 4, 6, Alpha: 100);
                    Lighting.addLight((int)(((double)this.itemLocation.X + 6.0 + (double)this.velocity.X) / 16.0), (int)(((double)this.itemLocation.Y - 14.0) / 16.0), byte.MaxValue);
                }
            }
            this.releaseUseItem = !this.controlUseItem;
            if (this.itemTime > 0)
                --this.itemTime;
            if (i != Main.myPlayer)
                return;
            if ((this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0) && (double)this.position.X / 16.0 - (double)Player.tileRangeX - (double)this.inventory[this.selectedItem].tileBoost <= (double)Player.tileTargetX && ((double)this.position.X + (double)this.width) / 16.0 + (double)Player.tileRangeX + (double)this.inventory[this.selectedItem].tileBoost - 1.0 >= (double)Player.tileTargetX && (double)this.position.Y / 16.0 - (double)Player.tileRangeY - (double)this.inventory[this.selectedItem].tileBoost <= (double)Player.tileTargetY && ((double)this.position.Y + (double)this.height) / 16.0 + (double)Player.tileRangeY + (double)this.inventory[this.selectedItem].tileBoost - 2.0 >= (double)Player.tileTargetY)
            {
                this.showItemIcon = true;
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
                {
                    if (this.hitTileX != Player.tileTargetX || this.hitTileY != Player.tileTargetY)
                    {
                        this.hitTile = 0;
                        this.hitTileX = Player.tileTargetX;
                        this.hitTileY = Player.tileTargetY;
                    }
                    if (Main.tileNoFail[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                        this.hitTile = 100;
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte)5 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte)10 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == (byte)11)
                    {
                        this.hitTile += this.inventory[this.selectedItem].axe;
                        if (this.inventory[this.selectedItem].axe > 0)
                        {
                            if (this.hitTile >= 100)
                            {
                                this.hitTile = 0;
                                WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY);
                            }
                            else
                                WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true);
                            this.itemTime = this.inventory[this.selectedItem].useTime;
                        }
                    }
                    else if (this.inventory[this.selectedItem].pick > 0)
                    {
                        this.hitTile += this.inventory[this.selectedItem].pick;
                        if (this.hitTile >= 100)
                        {
                            this.hitTile = 0;
                            WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY);
                        }
                        else
                            WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true);
                        this.itemTime = this.inventory[this.selectedItem].useTime;
                    }
                }
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall > (byte)0 && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem && this.inventory[this.selectedItem].hammer > 0)
                {
                    if (this.hitTileX != Player.tileTargetX || this.hitTileY != Player.tileTargetY)
                    {
                        this.hitTile = 0;
                        this.hitTileX = Player.tileTargetX;
                        this.hitTileY = Player.tileTargetY;
                    }
                    this.hitTile += this.inventory[this.selectedItem].hammer;
                    if (this.hitTile >= 100)
                    {
                        this.hitTile = 0;
                        WorldGen.KillWall(Player.tileTargetX, Player.tileTargetY);
                    }
                    else
                        WorldGen.KillWall(Player.tileTargetX, Player.tileTargetY, true);
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                }
            }
            if (this.inventory[this.selectedItem].createTile >= 0)
            {
                Player.tileTargetX = (int)(((double)Main.mouseState.X + (double)Main.screenPosition.X) / 16.0);
                Player.tileTargetY = (int)(((double)Main.mouseState.Y + (double)Main.screenPosition.Y) / 16.0);
                if ((double)this.position.X / 16.0 - (double)Player.tileRangeX - (double)this.inventory[this.selectedItem].tileBoost <= (double)Player.tileTargetX && ((double)this.position.X + (double)this.width) / 16.0 + (double)Player.tileRangeX + (double)this.inventory[this.selectedItem].tileBoost - 1.0 >= (double)Player.tileTargetX && (double)this.position.Y / 16.0 - (double)Player.tileRangeY - (double)this.inventory[this.selectedItem].tileBoost <= (double)Player.tileTargetY && ((double)this.position.Y + (double)this.height) / 16.0 + (double)Player.tileRangeY + (double)this.inventory[this.selectedItem].tileBoost - 2.0 >= (double)Player.tileTargetY)
                {
                    this.showItemIcon = true;
                    if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > (byte)0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > (byte)0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > (byte)0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > (byte)0))
                    {
                        WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile);
                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].active)
                            this.itemTime = this.inventory[this.selectedItem].useTime;
                    }
                }
            }
            if (this.inventory[this.selectedItem].createWall >= 0)
            {
                Player.tileTargetX = (int)(((double)Main.mouseState.X + (double)Main.screenPosition.X) / 16.0);
                Player.tileTargetY = (int)(((double)Main.mouseState.Y + (double)Main.screenPosition.Y) / 16.0);
                if ((double)this.position.X / 16.0 - (double)Player.tileRangeX - (double)this.inventory[this.selectedItem].tileBoost <= (double)Player.tileTargetX && ((double)this.position.X + (double)this.width) / 16.0 + (double)Player.tileRangeX + (double)this.inventory[this.selectedItem].tileBoost - 1.0 >= (double)Player.tileTargetX && (double)this.position.Y / 16.0 - (double)Player.tileRangeY - (double)this.inventory[this.selectedItem].tileBoost <= (double)Player.tileTargetY && ((double)this.position.Y + (double)this.height) / 16.0 + (double)Player.tileRangeY + (double)this.inventory[this.selectedItem].tileBoost - 2.0 >= (double)Player.tileTargetY)
                {
                    this.showItemIcon = true;
                    if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > (byte)0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > (byte)0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > (byte)0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > (byte)0) && (int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall != this.inventory[this.selectedItem].createWall)
                    {
                        WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createWall);
                        if ((int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall == this.inventory[this.selectedItem].createWall)
                            this.itemTime = this.inventory[this.selectedItem].useTime;
                    }
                }
            }
            if (this.inventory[this.selectedItem].damage >= 0 && this.inventory[this.selectedItem].type > 0 && this.itemAnimation > 0)
            {
                bool flag = false;
                Rectangle rectangle1 = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, Main.itemTexture[this.inventory[this.selectedItem].type].Width, Main.itemTexture[this.inventory[this.selectedItem].type].Height);
                rectangle1.Width = (int)((double)rectangle1.Width * (double)this.inventory[this.selectedItem].scale);
                rectangle1.Height = (int)((double)rectangle1.Height * (double)this.inventory[this.selectedItem].scale);
                if (this.direction == -1)
                    rectangle1.X -= rectangle1.Width;
                rectangle1.Y -= rectangle1.Height;
                if (this.inventory[this.selectedItem].useStyle == 1)
                {
                    if ((double)this.itemAnimation < (double)this.inventory[this.selectedItem].useAnimation * 0.333)
                    {
                        if (this.direction == -1)
                            rectangle1.X -= (int)((double)rectangle1.Width * 1.4 - (double)rectangle1.Width);
                        rectangle1.Width = (int)((double)rectangle1.Width * 1.4);
                        rectangle1.Y += (int)((double)rectangle1.Height * 0.5);
                        rectangle1.Height = (int)((double)rectangle1.Height * 1.1);
                    }
                    else if ((double)this.itemAnimation >= (double)this.inventory[this.selectedItem].useAnimation * 0.666)
                    {
                        if (this.direction == 1)
                            rectangle1.X -= rectangle1.Width * 2;
                        rectangle1.Width *= 2;
                        rectangle1.Y -= (int)((double)rectangle1.Height * 1.4 - (double)rectangle1.Height);
                        rectangle1.Height = (int)((double)rectangle1.Height * 1.4);
                    }
                }
                else if (this.inventory[this.selectedItem].useStyle == 3)
                {
                    if ((double)this.itemAnimation > (double)this.inventory[this.selectedItem].useAnimation * 0.666)
                    {
                        flag = true;
                    }
                    else
                    {
                        if (this.direction == -1)
                            rectangle1.X -= (int)((double)rectangle1.Width * 1.4 - (double)rectangle1.Width);
                        rectangle1.Width = (int)((double)rectangle1.Width * 1.4);
                        rectangle1.Y += (int)((double)rectangle1.Height * 0.6);
                        rectangle1.Height = (int)((double)rectangle1.Height * 0.6);
                    }
                }
                if (!flag)
                {
                    int num1 = rectangle1.X / 16;
                    int num2 = (rectangle1.X + rectangle1.Width) / 16 + 1;
                    int num3 = rectangle1.Y / 16;
                    int num4 = (rectangle1.Y + rectangle1.Height) / 16 + 1;
                    for (int i1 = num1; i1 < num2; ++i1)
                    {
                        for (int j = num3; j < num4; ++j)
                        {
                            if (Main.tile[i1, j].type == (byte)3)
                                WorldGen.KillTile(i1, j);
                        }
                    }
                    for (int index = 0; index < 1000; ++index)
                    {
                        if (Main.npc[index].active && Main.npc[index].immune[i] == 0)
                        {
                            Rectangle rectangle2 = new Rectangle((int)Main.npc[index].position.X, (int)Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
                            if (rectangle1.Intersects(rectangle2))
                            {
                                Main.npc[index].StrikeNPC(this.inventory[this.selectedItem].damage, this.inventory[this.selectedItem].knockBack, this.direction);
                                Main.npc[index].immune[i] = this.itemAnimation;
                            }
                        }
                    }
                }
            }
            if (this.itemTime == 0 && this.inventory[this.selectedItem].healLife > 0 && this.itemAnimation > 0)
            {
                this.statLife += this.inventory[this.selectedItem].healLife;
                this.itemTime = this.inventory[this.selectedItem].useTime;
            }
            if (this.itemTime == this.inventory[this.selectedItem].useTime && this.inventory[this.selectedItem].consumable)
            {
                --this.inventory[this.selectedItem].stack;
                if (this.inventory[this.selectedItem].stack <= 0)
                    this.itemTime = this.itemAnimation;
            }
            if (this.inventory[this.selectedItem].stack <= 0 && this.itemAnimation == 0)
                this.inventory[this.selectedItem] = new Item();
        }

        public Color GetImmuneAlpha(Color newColor)
        {
            int r = (int)newColor.R - this.immuneAlpha;
            int g = (int)newColor.G - this.immuneAlpha;
            int b = (int)newColor.B - this.immuneAlpha;
            int a = (int)newColor.A - this.immuneAlpha;
            if (a < 0)
                a = 0;
            if (a > (int)byte.MaxValue)
                a = (int)byte.MaxValue;
            return new Color(r, g, b, a);
        }

        public Color GetDeathAlpha(Color newColor)
        {
            int r = (int)newColor.R + (int)((double)this.immuneAlpha * 0.9);
            int g = (int)newColor.G + (int)((double)this.immuneAlpha * 0.5);
            int b = (int)newColor.B + (int)((double)this.immuneAlpha * 0.5);
            int a = (int)newColor.A + (int)((double)this.immuneAlpha * 0.4);
            if (a < 0)
                a = 0;
            if (a > (int)byte.MaxValue)
                a = (int)byte.MaxValue;
            return new Color(r, g, b, a);
        }

        public void DropItems()
        {
            for (int index1 = 10; index1 < 40; ++index1)
            {
                int index2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[index1].type);
                this.inventory[index1].position = Main.item[index2].position;
                Main.item[index2] = this.inventory[index1];
                this.inventory[index1] = new Item();
                this.selectedItem = 0;
                Main.item[index2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.1f;
                Main.item[index2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.1f;
                Main.item[index2].noGrabDelay = 100;
            }
        }

        public static void SetupPlayers()
        {
            for (int index1 = 0; index1 < 16; ++index1)
            {
                Main.player[index1] = new Player();
                Main.player[index1].name = "Player";
                Main.player[index1].armor[0] = new Item();
                Main.player[index1].armor[1] = new Item();
                Main.player[index1].armor[2] = new Item();
                for (int index2 = 0; index2 < 40; ++index2)
                    Main.player[index1].inventory[index2] = new Item();
                Main.player[index1].inventory[0].SetDefaults("Gold Broadsword");
                Main.player[index1].inventory[1].SetDefaults("Gold Pickaxe");
                Main.player[index1].inventory[2].SetDefaults("Gold Axe");
                Main.player[index1].inventory[3].SetDefaults("Gold Hammer");
                Main.player[index1].inventory[4].SetDefaults("Gold Shortsword");
                Main.player[index1].inventory[30].SetDefaults(16);
                Main.player[index1].inventory[31].SetDefaults(18);
                Main.player[index1].armor[1].SetDefaults(15);
                Main.player[index1].armor[2].SetDefaults(17);
            }
        }
    }
}