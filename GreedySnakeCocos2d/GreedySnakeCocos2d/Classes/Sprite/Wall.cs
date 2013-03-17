using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes.Sprite
{
    /*
     * This is a wall class.
     * Author: Tan Tian Xiang
     * Date: 2013.3.14
     */
    class Wall : CCSprite
    {
        public Wall(CCPoint point)
        {
            this.initWithFile("images/Sprite/Wall");
            this.position = point;
        }
    }
}
