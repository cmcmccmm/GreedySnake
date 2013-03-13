using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    /*
     * This class is the layer of menu items in the main menu scene.
     * Author: Tan Tian Xiang
     * Date: 2013.3.10
     */
    class GamePlayLayer : CCLayer
    {
        public override bool init()
        {
            if (!base.init())
            {
                return false;
            }

            // Add the wall to the game field.
            CCSprite wall;

            for (int i = 0; i < 12; i++)
            {
                wall = CCSprite.spriteWithFile("images/Sprite/Wall");
                wall.position = new CCPoint(20 + i * 40, 180);
                this.addChild(wall);

                if (i == 0) continue;

                wall = CCSprite.spriteWithFile("images/Sprite/Wall");
                wall.position = new CCPoint(20, 180 + i * 40);
                this.addChild(wall);
            }

            for (int i = 0; i < 11; i++)
            {
                wall = CCSprite.spriteWithFile("images/Sprite/Wall");
                wall.position = new CCPoint(460 - i * 40, 620);
                this.addChild(wall);

                if (i == 0) continue;

                wall = CCSprite.spriteWithFile("images/Sprite/Wall");
                wall.position = new CCPoint(460, 620 - i * 40);
                this.addChild(wall);
            }

            return true;
        }

        public static new CCLayer node()
        {
            GamePlayLayer layer = new GamePlayLayer();

            if (layer.init())
                return layer;
            else
                return null;
        }
    }
}
