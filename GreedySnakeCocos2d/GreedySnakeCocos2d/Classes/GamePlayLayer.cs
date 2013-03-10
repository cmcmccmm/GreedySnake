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
