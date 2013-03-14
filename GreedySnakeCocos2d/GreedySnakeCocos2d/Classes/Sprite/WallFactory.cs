using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes.Sprite
{
    /*
     * This is a factory pattern which is used to create wall.
     * Author: Tan Tian Xiang
     * Date: 2013.3.14
     */
    class WallFactory
    {
        public static CCSprite createWall(CCPoint point)
        {
            CCSprite wall = CCSprite.spriteWithFile("images/Sprite/Wall");
            wall.position = point;
            return wall;
        }
    }
}
