using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes.Sprite
{
    class gsSprite : CCSprite
    {
        // The abstract location x in the game field.
        private int gsx;
        public int gsX
        {
            get
            {
                return gsx;
            }
            set
            {
                gsx = value;
                CCPoint tempPoint = new CCPoint(this.position.x, this.position.y);
                tempPoint.x = (float) GameData.setSpriteX(gsx);
                this.position = tempPoint;
            }
        }

        // The abstract location y in the game field.
        private int gsy;
        public int gsY
        {
            get
            {
                return gsy;
            }
            set
            {
                gsy = value;
                CCPoint tempPoint = new CCPoint(this.position.x, this.position.y);
                tempPoint.y = (float)GameData.setSpriteY(gsy);
                this.position = tempPoint;
            }
        }

        public gsSprite(string fileName, int x, int y)
        {
            this.initWithFile(fileName);
            this.gsX = x;
            this.gsY = y;
        }
    }
}
