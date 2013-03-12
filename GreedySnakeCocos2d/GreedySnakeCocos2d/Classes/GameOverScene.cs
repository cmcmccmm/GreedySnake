using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    /* This is a scene displayed when the game is over.
     * Author: Tan Tian Xiang
     * Date: 2013.3.10
     */
    class GameOverScene : CCScene
    {
        public override void onEnter()
        {
            base.onEnter();

            CCLayerColor layerColor = CCLayerColor.layerWithColor(new ccColor4B(255, 0, 0, 255));
            this.addChild(layerColor);
        }
    }
}
