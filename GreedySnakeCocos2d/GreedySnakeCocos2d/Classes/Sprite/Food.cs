using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes.Sprite
{
    class Food : CCSprite
    {
        // The score the snake will get when eat the food.
        protected int award;

        public Food(int award, CCPoint position)
        {
            this.award = award;
            this.initWithFile("images/Sprite/Food");
            this.position = position;
        }

        public int getAward()
        {
            return award;
        }
    }
}
