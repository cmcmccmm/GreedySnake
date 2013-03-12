using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    class BackgroundLayer : CCLayer
    {
        public override bool init()
        {
            if (!base.init())
                return false;

            // Set the orientation of the phone.
            CCDirector.sharedDirector().deviceOrientation = ccDeviceOrientation.kCCDeviceOrientationPortrait;

            this.m_bIsTouchEnabled = true;

            // Get the width and the height of the phone.
            float width = CCDirector.sharedDirector().getWinSize().width;
            float height = CCDirector.sharedDirector().getWinSize().height;

            // Set the background of the screen.
            CCSprite background = CCSprite.spriteWithFile(@"images/background/MainMenu");
            background.position = new CCPoint(width / 2, height / 2);
            this.addChild(background);

            return true;
        }

        public static new CCLayer node()
        {
           BackgroundLayer mm = new BackgroundLayer();

            if (!mm.init())
            {
                mm = null;
            }

            return mm;
        }
    }
}
