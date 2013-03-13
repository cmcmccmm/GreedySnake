using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes.Sprite
{
    /*
     * This is the snake which is controlled by the player.
     * Author: Tan Tian Xiang
     * Date: 2013.3.12
     */
    class PlayerSnake : Snake, Observer
    {
        public PlayerSnake(string headImageFile, string bodyImageFile, Direction direction, CCPoint initPosition, int length, int stepLength)
            : base(headImageFile, bodyImageFile, direction, initPosition, length, stepLength)
        {

        }

        // Update when the subject notify the snake.
        public void update(object obj)
        {

        }
    }
}
