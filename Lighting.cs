// Decompiled with JetBrains decompiler
// Type: Terraria.Lighting
// Assembly: Terraria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2B842C06-302B-4218-9B94-AD87188E4CC4
// Assembly location: C:\Games\Terraria Proto\0.0.0.0\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
    public static class Lighting
    {
        public static bool disableLighting = false;
        public const int offScreenTiles = 21;
        private static Color lightColor = Color.Black;
        private static int firstTileX;
        private static int lastTileX;
        private static int firstTileY;
        private static int lastTileY;
        public static Color[,] color = new Color[Main.screenWidth / 16 + 42 + 10, Main.screenHeight / 16 + 42 + 10];
        private static int maxTempLights = 100;
        private static int[] tempLightX = new int[Lighting.maxTempLights];
        private static int[] tempLightY = new int[Lighting.maxTempLights];
        private static int[] tempLight = new int[Lighting.maxTempLights];
        private static int tempLightCount;
        private static int firstToLightX;
        private static int firstToLightY;
        private static int lastToLightX;
        private static int lastToLightY;

        public static void LightTiles(int firstX, int lastX, int firstY, int lastY)
        {
            Lighting.firstTileX = firstX;
            Lighting.lastTileX = lastX;
            Lighting.firstTileY = firstY;
            Lighting.lastTileY = lastY;
            Lighting.firstToLightX = Lighting.firstTileX - 21;
            Lighting.firstToLightY = Lighting.firstTileY - 21;
            Lighting.lastToLightX = Lighting.lastTileX + 21;
            Lighting.lastToLightY = Lighting.lastTileY + 21;
            for (int index1 = 0; index1 < Main.screenWidth / 16 + 42 + 10; ++index1)
            {
                for (int index2 = 0; index2 < Main.screenHeight / 16 + 42 + 10; ++index2)
                    // Darkest Color of the lighting
                    Lighting.color[index1, index2] = disableLighting ? Color.White : Color.Black;
            }
            for (int index = 0; index < Lighting.tempLightCount; ++index)
            {
                if (Lighting.tempLightX[index] - Lighting.firstTileX + 21 >= 0 && Lighting.tempLightX[index] - Lighting.firstTileX + 21 < Main.screenWidth / 16 + 42 + 10 && Lighting.tempLightY[index] - Lighting.firstTileY + 21 >= 0 && Lighting.tempLightY[index] - Lighting.firstTileY + 21 < Main.screenHeight / 16 + 42 + 10)
                    Lighting.color[Lighting.tempLightX[index] - Lighting.firstTileX + 21, Lighting.tempLightY[index] - Lighting.firstTileY + 21] = new Color(Lighting.tempLight[index], Lighting.tempLight[index], Lighting.tempLight[index], Lighting.tempLight[index]);
            }
            Lighting.tempLightCount = 0;
            for (int firstToLightX = Lighting.firstToLightX; firstToLightX < Lighting.lastToLightX; ++firstToLightX)
            {
                for (int firstToLightY = Lighting.firstToLightY; firstToLightY < Lighting.lastToLightY; ++firstToLightY)
                {
                    if (firstToLightX >= 0 && firstToLightX < 5001 && firstToLightY >= 0 && firstToLightY < 2501 && (!Main.tile[firstToLightX, firstToLightY].active || !Main.tileSolid[(int)Main.tile[firstToLightX, firstToLightY].type]) && (Main.tile[firstToLightX, firstToLightY].lighted || Main.tile[firstToLightX, firstToLightY].type == (byte)4))
                    {
                        if ((int)Lighting.color[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY].R < (int)Main.tileColor.R && (int)Main.tileColor.R > (int)Lighting.color[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY].R && Main.tile[firstToLightX, firstToLightY].wall == (byte)0)
                            Lighting.color[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY] = Main.tileColor;
                        if (Main.tile[firstToLightX, firstToLightY].type == (byte)4)
                            Lighting.color[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY] = Color.White;
                    }
                }
            }
            for (int index = 0; index < 2; ++index)
            {
                for (int firstToLightX = Lighting.firstToLightX; firstToLightX < Lighting.lastToLightX; ++firstToLightX)
                {
                    Lighting.lightColor = Color.Black;
                    for (int firstToLightY = Lighting.firstToLightY; firstToLightY < Lighting.lastToLightY; ++firstToLightY)
                        Lighting.LightColor(firstToLightX, firstToLightY);
                }
                for (int firstToLightX = Lighting.firstToLightX; firstToLightX < Lighting.lastToLightX; ++firstToLightX)
                {
                    Lighting.lightColor = Color.Black;
                    for (int lastToLightY = Lighting.lastToLightY; lastToLightY >= Lighting.firstToLightY; --lastToLightY)
                        Lighting.LightColor(firstToLightX, lastToLightY);
                }
                for (int firstToLightY = Lighting.firstToLightY; firstToLightY < Lighting.lastToLightY; ++firstToLightY)
                {
                    Lighting.lightColor = Color.Black;
                    for (int firstToLightX = Lighting.firstToLightX; firstToLightX < Lighting.lastToLightX; ++firstToLightX)
                        Lighting.LightColor(firstToLightX, firstToLightY);
                }
                for (int firstToLightY = Lighting.firstToLightY; firstToLightY < Lighting.lastToLightY; ++firstToLightY)
                {
                    Lighting.lightColor = Color.Black;
                    for (int lastToLightX = Lighting.lastToLightX; lastToLightX >= Lighting.firstToLightX; --lastToLightX)
                        Lighting.LightColor(lastToLightX, firstToLightY);
                }
            }
        }

        public static void addLight(int i, int j, byte Lightness)
        {
            if (Lighting.tempLightCount == Lighting.maxTempLights || i - Lighting.firstTileX + 21 < 0 || i - Lighting.firstTileX + 21 >= Main.screenWidth / 16 + 42 + 10 || j - Lighting.firstTileY + 21 < 0 || j - Lighting.firstTileY + 21 >= Main.screenHeight / 16 + 42 + 10)
                return;
            Lighting.tempLightX[Lighting.tempLightCount] = i;
            Lighting.tempLightY[Lighting.tempLightCount] = j;
            Lighting.tempLight[Lighting.tempLightCount] = (int)Lightness;
            ++Lighting.tempLightCount;
        }

        private static void LightColor(int i, int j)
        {
            int index1 = i - Lighting.firstToLightX;
            int index2 = j - Lighting.firstToLightY;
            try
            {
                if ((int)Lighting.color[index1, index2].R > (int)Lighting.lightColor.R)
                    Lighting.lightColor = Lighting.color[index1, index2];
                else
                    Lighting.color[index1, index2] = Lighting.lightColor;
                int num1 = Main.tile[i, j].active && Main.tileSolid[(int)Main.tile[i, j].type] ? 40 : 10;
                int num2 = (int)Lighting.lightColor.R - num1;
                if (num2 < 0)
                    num2 = 0;
                if (num2 > (int)byte.MaxValue)
                    num2 = (int)byte.MaxValue;
                Lighting.lightColor.R = (byte)num2;
                Lighting.lightColor.B = Lighting.lightColor.R;
                Lighting.lightColor.G = Lighting.lightColor.R;
                if (Lighting.lightColor.R <= (byte)0 || Main.tile[i, j].active && Main.tileSolid[(int)Main.tile[i, j].type] || (double)j >= Main.worldSurface)
                    return;
                Main.tile[i, j].lighted = true;
            }
            catch
            {
            }
        }

        public static int LightingX(int lightX)
        {
            if (lightX < 0)
                return 0;
            return lightX >= Main.screenWidth / 16 + 42 + 10 ? Main.screenWidth / 16 + 42 + 10 - 1 : lightX;
        }

        public static int LightingY(int lightY)
        {
            if (lightY < 0)
                return 0;
            return lightY >= Main.screenHeight / 16 + 42 + 10 ? Main.screenHeight / 16 + 42 + 10 - 1 : lightY;
        }
    }
}