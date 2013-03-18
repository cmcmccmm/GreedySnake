using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeCocos2d.Classes
{
    /*
     * This is the data used in the game.
     * Author: Tan Tian Xiang.
     * Date: 2013.3.18
     */
    class GameData
    {
        /*
         * Get the grid location x in the game.
         * Return the actual location X on the phone.
         * Author: Tan Tian Xiang.
         * Date: 2013.3.18
         */
        public static int setSpriteX(int x)
        {
            return 20 + 40 * x;
        }

        /*
         * Get the grid location y in the game.
         * Return the actual location Y on the phone.
         * Author: Tan Tian Xiang.
         * Date: 2013.3.18
         */
        public static int setSpriteY(int y)
        {
            return 180 + 40 * y;
        }

        /* The following is the image file name used in the game. */
        public static string wallImageFile = "images/Sprite/Wall";
        public static string PlayerSnakeHeadImageFile = "images/Sprite/PlayerSnakeHead";
        public static string PlayerSnakeBodyImageFile = "images/Sprite/PlayerSnakeBody";
        public static string FoodImageFile = "images/Sprite/Food";
    }
}
