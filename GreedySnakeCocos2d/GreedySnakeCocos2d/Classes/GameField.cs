using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreedySnakeCocos2d.Classes.Sprite;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    /*
     * This the field where the snakes live on and the food occur.
     * Author: Tan Tian Xiang
     * Date: 2013,3,12
     */
    class GameField
    {
        // The basic setting of the field.
        const int WIDTH = 12;
        const int HEIGHT = 12;

        // The snakes live on the field.
        private PlayerSnake playerSnake;
        private List<Food> foodList;

        public void initializeGame()
        {

        }

        // Update the things in the field when called.
        public void updateGameField()
        {
            playerSnake.move();
        }

        // Check the snake dead or not, return true when the snake is dead.
        private bool checkDead(Snake s)
        {
            if (s.isDead())
                return true;

            // Check whether the snake crash into the wall or not.
            CCPoint headPosition = s.getHeadPosition();

            if (headPosition.x == 0 || headPosition.x == WIDTH
                || headPosition.y == 0 || headPosition.y == HEIGHT)
            {
                s.die();
                return true;
            }

            return false;
        }
    }
}
