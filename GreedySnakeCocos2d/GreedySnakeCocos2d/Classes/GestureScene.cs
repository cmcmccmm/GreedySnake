using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    /*
     * This is a scene that recognize the gesture.
     * Author: Tan Tian Xiang
     * Date: 2013.3.10
     */
    class GestureScene : CCScene
    {
        

        public GestureScene()
        {
            this.addChild(GestureLayer.node());
        }
    }
}
