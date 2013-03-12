using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    class MainMenuScene : CCScene
    {
        public override void onEnter()
        {
            base.onEnter();

            this.addChild(BackgroundLayer.node());
            this.addChild(MainMenuLayer.node());
        }
    }
}
