using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input.Touch;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    /*
     * This is a layer that recognize the gesture.
     * Author: Tan Tian Xiang
     * Date: 2013.3.10
     */
    class GestureLayer : CCLayer, Observerable
    {
        CCLabelTTF title;

        public override bool init()
        {
            if (!base.init())
                return false;

            CCDirector.sharedDirector().deviceOrientation = ccDeviceOrientation.kCCDeviceOrientationPortrait;

            title = CCLabelTTF.labelWithString("gesture", "Arial", 32);
            title.position = new CCPoint(400, 400);
            this.addChild(title);

            // Enable the gesture.
            TouchPanel.EnabledGestures = GestureType.HorizontalDrag
                                                         | GestureType.VerticalDrag;

            this.schedule(gestureRecognize);
            return true;
        }

        public static new GestureLayer node()
        {
            GestureLayer layer = new GestureLayer();

            if (!layer.init())
            {
                layer = null;
            }

            return layer;
        }

        void gestureRecognize(float dt)
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                switch (gesture.GestureType)
                {
                    
                    case GestureType.HorizontalDrag:
                        {
                            title.setString("HorizontalDrag");
                            break;
                        }
                    case GestureType.VerticalDrag:
                        {
                            title.setString("VerticalDrag");
                            break;
                        }
                    default:
                        {
                            title.setString("default");
                            break;
                        }
                }
            }
        }
    }
}
