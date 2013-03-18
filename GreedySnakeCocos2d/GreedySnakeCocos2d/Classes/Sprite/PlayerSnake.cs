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
    class PlayerSnake : Snake
    {
        public PlayerSnake(Direction direction, int initX, int initY, int length)
            : base(GameData.PlayerSnakeHeadImageFile, GameData.PlayerSnakeBodyImageFile, direction, initX, initY, length)
        {

        }
    }
}
