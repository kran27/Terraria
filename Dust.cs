// Decompiled with JetBrains decompiler
// Type: Terraria.Dust
// Assembly: Terraria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2B842C06-302B-4218-9B94-AD87188E4CC4
// Assembly location: C:\Games\Terraria Proto\0.0.0.0\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
    public class Dust
    {
        public Vector2 position;
        public Vector2 velocity;
        public float scale;
        public float rotation;
        public bool active = false;
        public int type = 0;
        public Color color;
        public int alpha;
        public Rectangle frame;

        public static void NewDust(
          Vector2 Position,
          int Width,
          int Height,
          int Type,
          float SpeedX = 0.0f,
          float SpeedY = 0.0f,
          int Alpha = 0,
          Color newColor = default(Color))
        {
            for (int index = 0; index < 1000; ++index)
            {
                if (!Main.dust[index].active)
                {
                    Main.dust[index].active = true;
                    Main.dust[index].type = Type;
                    Main.dust[index].color = newColor;
                    Main.dust[index].alpha = Alpha;
                    Main.dust[index].position.X = (float)((double)Position.X + (double)Main.rand.Next(Width - 4) + 4.0);
                    Main.dust[index].position.Y = (float)((double)Position.Y + (double)Main.rand.Next(Height - 4) + 4.0);
                    Main.dust[index].velocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + SpeedX;
                    Main.dust[index].velocity.Y = (float)Main.rand.Next(-20, 21) * 0.1f + SpeedY;
                    Main.dust[index].frame.X = 10 * Type;
                    Main.dust[index].frame.Y = 10 * Main.rand.Next(3);
                    Main.dust[index].frame.Width = 8;
                    Main.dust[index].frame.Height = 8;
                    Main.dust[index].rotation = 0.0f;
                    Main.dust[index].scale = (float)(1.0 + (double)Main.rand.Next(-20, 21) * 0.00999999977648258);
                    if (Main.dust[index].type != 6)
                        break;
                    Main.dust[index].velocity.Y = (float)Main.rand.Next(-10, 6) * 0.1f;
                    Main.dust[index].velocity.X *= 0.3f;
                    Main.dust[index].scale *= 0.7f;
                    break;
                }
            }
        }

        public static void UpdateDust()
        {
            for (int index = 0; index < 1000; ++index)
            {
                if (Main.dust[index].active)
                {
                    Main.dust[index].position += Main.dust[index].velocity;
                    if (Main.dust[index].type == 6)
                        Main.dust[index].velocity.Y += 0.05f;
                    else
                        Main.dust[index].velocity.Y += 0.1f;
                    Main.dust[index].velocity.X *= 0.99f;
                    Main.dust[index].rotation += Main.dust[index].velocity.X * 0.5f;
                    Main.dust[index].scale -= 0.01f;
                    if ((double)Main.dust[index].position.Y > (double)Main.screenPosition.Y + (double)Main.screenHeight)
                        Main.dust[index].active = false;
                    if ((double)Main.dust[index].scale < 0.1)
                        Main.dust[index].active = false;
                }
            }
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