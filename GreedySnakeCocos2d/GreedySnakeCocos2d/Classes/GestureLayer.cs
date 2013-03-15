using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input.Touch;
using cocos2d;
using GreedySnakeCocos2d.Classes.Sprite;

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

        // The list of the observer.
        List<Observer> observerList;

        // The direction that the layer recognize.
        Direction direction;

        public override bool init()
        {
            if (!base.init())
                return false;

            CCDirector.sharedDirector().deviceOrientation = ccDeviceOrientation.kCCDeviceOrientationPortrait;

            title = CCLabelTTF.labelWithString("gesture", "Arial", 32);
            title.position = new CCPoint(100, 400);
            this.addChild(title);

            // Enable the gesture.
            TouchPanel.EnabledGestures = GestureType.VerticalDrag
                                                        | GestureType.HorizontalDrag;

            observerList = new List<Observer>();

            this.direction = Direction.Down;

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
                        if (gesture.Delta.X > 0)
                        {
                            direction = Direction.Right;
                            title.setString("Right");
                        }
                        else if (gesture.Delta.X < 0)
                        {
                            direction = Direction.Left;
                            title.setString("Left");
                        }
                        
                        this.notifyObserver();
                        break;
                    }
                    case GestureType.VerticalDrag:
                    {
                        if (gesture.Delta.Y > 0)
                        {
                            direction = Direction.Down;
                            title.setString("Down");
                        }
                        else if (gesture.Delta.Y < 0)
                        {
                            direction = Direction.Up;
                            title.setString("Up");
                        }

                        this.notifyObserver();
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

        // Get the direction recognize by the layer.
        public Direction getDirection()
        {
            return this.direction;
        }

        public void addObserver(Observer o)
        {
            observerList.Add(o);
        }

        public void deleteObserver(Observer o)
        {
            observerList.Remove(o);
        }

        public void notifyObserver()
        {
            foreach (Observer o in observerList)
                o.update(this);
        }
    }
}
