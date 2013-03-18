using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    class MainMenuScene : CCScene
    {
        internal MainMenuLayer MainMenuLayer
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal BackgroundLayer BackgroundLayer
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public override void onEnter()
        {
            base.onEnter();

            this.addChild(BackgroundLayer.node("images/background/MainMenu"));
            this.addChild(MainMenuLayer.node());
        }
    }
}
