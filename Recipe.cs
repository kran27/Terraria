// Decompiled with JetBrains decompiler
// Type: Terraria.Recipe
// Assembly: Terraria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2B842C06-302B-4218-9B94-AD87188E4CC4
// Assembly location: C:\Games\Terraria Proto\0.0.0.0\Terraria.exe

namespace Terraria
{
    public class Recipe
    {
        public static int maxRequirements = 10;
        public static int maxRecipes = 100;
        public static int numRecipes = 0;
        private static Recipe newRecipe = new Recipe();
        public Item createItem = new Item();
        public Item[] requiredItem = new Item[Recipe.maxRecipes];

        public Recipe()
        {
            for (int index = 0; index < Recipe.maxRequirements; ++index)
                this.requiredItem[index] = new Item();
        }

        public void Create()
        {
            for (int index1 = 0; index1 < Recipe.maxRequirements && this.requiredItem[index1].type != 0; ++index1)
            {
                int num = this.requiredItem[index1].stack;
                for (int index2 = 0; index2 < 40; ++index2)
                {
                    if (Main.player[Main.myPlayer].inventory[index2].IsTheSameAs(this.requiredItem[index1]))
                    {
                        if (Main.player[Main.myPlayer].inventory[index2].stack > num)
                        {
                            Main.player[Main.myPlayer].inventory[index2].stack -= num;
                            num = 0;
                        }
                        else
                        {
                            num -= Main.player[Main.myPlayer].inventory[index2].stack;
                            Main.player[Main.myPlayer].inventory[index2] = new Item();
                        }
                    }
                    if (num <= 0)
                        break;
                }
            }
            Recipe.FindRecipes();
        }

        public static void FindRecipes()
        {
            int num1 = Main.availableRecipe[Main.focusRecipe];
            float num2 = Main.availableRecipeY[Main.focusRecipe];
            for (int index = 0; index < Recipe.maxRecipes; ++index)
                Main.availableRecipe[index] = 0;
            Main.numAvailableRecipes = 0;
            for (int index1 = 0; index1 < Recipe.maxRecipes && Main.recipe[index1].createItem.type != 0; ++index1)
            {
                bool flag = true;
                for (int index2 = 0; index2 < Recipe.maxRequirements && Main.recipe[index1].requiredItem[index2].type != 0; ++index2)
                {
                    int stack = Main.recipe[index1].requiredItem[index2].stack;
                    for (int index3 = 0; index3 < 40; ++index3)
                    {
                        if (Main.player[Main.myPlayer].inventory[index3].IsTheSameAs(Main.recipe[index1].requiredItem[index2]))
                            stack -= Main.player[Main.myPlayer].inventory[index3].stack;
                        if (stack <= 0)
                            break;
                    }
                    if (stack > 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Main.availableRecipe[Main.numAvailableRecipes] = index1;
                    ++Main.numAvailableRecipes;
                }
            }
            for (int index = 0; index < Main.numAvailableRecipes; ++index)
            {
                if (num1 == Main.availableRecipe[index])
                {
                    Main.focusRecipe = index;
                    break;
                }
            }
            if (Main.focusRecipe >= Main.numAvailableRecipes)
                Main.focusRecipe = Main.numAvailableRecipes - 1;
            if (Main.focusRecipe < 0)
                Main.focusRecipe = 0;
            float num3 = Main.availableRecipeY[Main.focusRecipe] - num2;
            for (int index = 0; index < Recipe.maxRecipes; ++index)
                Main.availableRecipeY[index] -= num3;
        }

        public static void SetupRecipes()
        {
            Recipe.newRecipe.createItem.SetDefaults(8);
            Recipe.newRecipe.createItem.stack = 3;
            Recipe.newRecipe.requiredItem[0].SetDefaults(23);
            Recipe.newRecipe.requiredItem[0].stack = 2;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(26);
            Recipe.newRecipe.createItem.stack = 4;
            Recipe.newRecipe.requiredItem[0].SetDefaults(3);
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(25);
            Recipe.newRecipe.requiredItem[0].SetDefaults(9);
            Recipe.newRecipe.requiredItem[0].stack = 5;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(24);
            Recipe.newRecipe.requiredItem[0].SetDefaults(9);
            Recipe.newRecipe.requiredItem[0].stack = 7;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(20);
            Recipe.newRecipe.requiredItem[0].SetDefaults(12);
            Recipe.newRecipe.requiredItem[0].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Copper Pickaxe");
            Recipe.newRecipe.requiredItem[0].SetDefaults(20);
            Recipe.newRecipe.requiredItem[0].stack = 12;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 4;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Copper Axe");
            Recipe.newRecipe.requiredItem[0].SetDefaults(20);
            Recipe.newRecipe.requiredItem[0].stack = 9;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Copper Hammer");
            Recipe.newRecipe.requiredItem[0].SetDefaults(20);
            Recipe.newRecipe.requiredItem[0].stack = 10;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Copper Broadsword");
            Recipe.newRecipe.requiredItem[0].SetDefaults(20);
            Recipe.newRecipe.requiredItem[0].stack = 8;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Copper Shortsword");
            Recipe.newRecipe.requiredItem[0].SetDefaults(20);
            Recipe.newRecipe.requiredItem[0].stack = 7;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(19);
            Recipe.newRecipe.requiredItem[0].SetDefaults(13);
            Recipe.newRecipe.requiredItem[0].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Gold Pickaxe");
            Recipe.newRecipe.requiredItem[0].SetDefaults(19);
            Recipe.newRecipe.requiredItem[0].stack = 12;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 4;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Gold Axe");
            Recipe.newRecipe.requiredItem[0].SetDefaults(19);
            Recipe.newRecipe.requiredItem[0].stack = 9;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Gold Hammer");
            Recipe.newRecipe.requiredItem[0].SetDefaults(19);
            Recipe.newRecipe.requiredItem[0].stack = 10;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Gold Broadsword");
            Recipe.newRecipe.requiredItem[0].SetDefaults(19);
            Recipe.newRecipe.requiredItem[0].stack = 8;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Gold Shortsword");
            Recipe.newRecipe.requiredItem[0].SetDefaults(19);
            Recipe.newRecipe.requiredItem[0].stack = 7;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(22);
            Recipe.newRecipe.requiredItem[0].SetDefaults(11);
            Recipe.newRecipe.requiredItem[0].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(1);
            Recipe.newRecipe.requiredItem[0].SetDefaults(22);
            Recipe.newRecipe.requiredItem[0].stack = 12;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(10);
            Recipe.newRecipe.requiredItem[0].SetDefaults(22);
            Recipe.newRecipe.requiredItem[0].stack = 9;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(7);
            Recipe.newRecipe.requiredItem[0].SetDefaults(22);
            Recipe.newRecipe.requiredItem[0].stack = 10;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(4);
            Recipe.newRecipe.requiredItem[0].SetDefaults(22);
            Recipe.newRecipe.requiredItem[0].stack = 8;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(6);
            Recipe.newRecipe.requiredItem[0].SetDefaults(22);
            Recipe.newRecipe.requiredItem[0].stack = 7;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults(21);
            Recipe.newRecipe.requiredItem[0].SetDefaults(14);
            Recipe.newRecipe.requiredItem[0].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Silver Pickaxe");
            Recipe.newRecipe.requiredItem[0].SetDefaults(21);
            Recipe.newRecipe.requiredItem[0].stack = 12;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 4;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Silver Axe");
            Recipe.newRecipe.requiredItem[0].SetDefaults(21);
            Recipe.newRecipe.requiredItem[0].stack = 9;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Silver Hammer");
            Recipe.newRecipe.requiredItem[0].SetDefaults(21);
            Recipe.newRecipe.requiredItem[0].stack = 10;
            Recipe.newRecipe.requiredItem[1].SetDefaults(9);
            Recipe.newRecipe.requiredItem[1].stack = 3;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Silver Broadsword");
            Recipe.newRecipe.requiredItem[0].SetDefaults(21);
            Recipe.newRecipe.requiredItem[0].stack = 8;
            Recipe.addRecipe();
            Recipe.newRecipe.createItem.SetDefaults("Silver Shortsword");
            Recipe.newRecipe.requiredItem[0].SetDefaults(21);
            Recipe.newRecipe.requiredItem[0].stack = 7;
            Recipe.addRecipe();
        }

        private static void addRecipe()
        {
            Main.recipe[Recipe.numRecipes] = Recipe.newRecipe;
            Recipe.newRecipe = new Recipe();
            ++Recipe.numRecipes;
        }
    }
}