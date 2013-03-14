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
        bool changed;

        public override bool init()
        {
            if (!base.init())
                return false;

            CCDirector.sharedDirector().deviceOrientation = ccDeviceOrientation.kCCDeviceOrientationPortrait;

            title = CCLabelTTF.labelWithString("gesture", "Arial", 32);
            title.position = new CCPoint(100, 400);
            this.addChild(title);

            // Enable the gesture.
            TouchPanel.EnabledGestures = GestureType.HorizontalDrag
                                                         | GestureType.VerticalDrag;

            observerList = new List<Observer>();
            
            this.changed = false;
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
            this.changed = false;
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                switch (gesture.GestureType)
                {
                    case GestureType.HorizontalDrag:
                    {
                        // If the changed has not been update to the player snake.
                        if (changed) break;

                        if (gesture.Delta.X > 0)
                        {
                            direction = Direction.Right;
                            title.setString("Right");
                        }
                        else
                        {
                            direction = Direction.Left;
                            title.setString("Left");
                        }
                        changed = true;
                        this.notifyObserver();
                        break;
                    }
                    case GestureType.VerticalDrag:
                    {
                        // If the changed has not been update to the player snake.
                        if (changed) break;

                        if (gesture.Delta.Y > 0)
                        {
                            direction = Direction.Down;
                            title.setString("Down");
                        }
                        else
                        {
                            direction = Direction.Up;
                            title.setString("Up");
                        }
                        changed = true;
                        this.notifyObserver();
                        break;
                    }
                    default:
                    {
                            if(!changed)
                                title.setString("default");
                            break;
                    }
                }
            }
        }

        // Get the direction recognize by the layer.
        public Direction getDirection()
        {
            this.changed = false;
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
