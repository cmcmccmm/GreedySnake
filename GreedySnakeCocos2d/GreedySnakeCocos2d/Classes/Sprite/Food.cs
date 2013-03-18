using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes.Sprite
{
    class Food : gsSprite
    {
        // The score the snake will get when eat the food.
        protected int award;

        public Food(int award, int initX, int initY)
            : base(GameData.FoodImageFile, initX, initY)
        {
            this.award = award;
        }

        public int getAward()
        {
            return award;
        }
    }
}
