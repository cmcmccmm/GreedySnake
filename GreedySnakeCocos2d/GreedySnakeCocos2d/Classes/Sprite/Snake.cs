using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreedySnakeCocos2d.Classes;
using cocos2d;

namespace GreedySnakeCocos2d.Classes.Sprite
{
    // List the direction that a snake might face to
    enum Direction 
    {
        Up = 0,
        Right,
        Down,
        Left,
        None
    }

    /*
     * This is the base class for all the snakes occur in the game.
     * Author: Tan Tian Xiang
     * Date: 2013.3.12
     */
    class Snake
    {
        // The list record the body of the snake.
        protected List<gsSprite> bodyList;

        // The string record the head image file and the body image file.
        protected string headImageFile;
        protected string bodyImageFile;

        // The direction that the snake face to.
        Direction direction;

        // Record the score the snake get.
        protected int score;

        // Judge the snake dead or not.
        protected bool dead;

        // Record the tail position before the move.
        protected int tailPositionX;
        protected int tailPositionY;

        // A full constructor.
        public Snake(string headImageFile, string bodyImageFile, Direction direction, int initX, int initY, int length)
        {
            this.headImageFile = headImageFile;
            this.bodyImageFile = bodyImageFile;
            this.direction = direction;
            this.dead = false;
            this.score = 0;
            this.bodyList = new List<gsSprite>();

            gsSprite bodySprite = new gsSprite(headImageFile, initX, initY); 
            bodyList.Add(bodySprite);

            int tempPositionX, tempPositionY;
            tempPositionX = initX;
            tempPositionY = initY;

            for (int i = 1; i < length; i++)
            {
                if (direction == Direction.Up)
                    tempPositionY -=  1;
                else if (direction == Direction.Down)
                    tempPositionY += 1;
                else if (direction == Direction.Left)
                    tempPositionX += 1;
                else if (direction == Direction.Right)
                    tempPositionX -= 1;

                bodySprite = new gsSprite(bodyImageFile, tempPositionX, tempPositionY);

                bodyList.Add(bodySprite);
            }

            this.tailPositionX = bodyList[bodyList.Count - 1].gsX;
            this.tailPositionY = bodyList[bodyList.Count - 1].gsY;
        }

        // Get the sprite of the snake.
        public List<gsSprite> getBodySprite()
        {
            return bodyList;
        }

        // Get the head sprite.
        public gsSprite getHeadPosition()
        {
            return bodyList[0];
        }

        // Get the tail position.
        public gsSprite getTail()
        {
            return bodyList[bodyList.Count - 1];
        }

        // Set the direction of the snake.
        public void setDirection(Direction d)
        {
            if ((direction == Direction.Up && d == Direction.Down)
                || (direction == Direction.Down && d == Direction.Up)
                || (direction == Direction.Left && d == Direction.Right)
                || (direction == Direction.Right && d == Direction.Left))
            {
                // Won't change the direction.
            }
            else
            {
                direction = d;
            }
        }
        
        // Move the snake to the direction it face to.
        public void move()
        {
            // Record the tail position
            this.tailPositionX = bodyList[bodyList.Count - 1].gsX;
            this.tailPositionY = bodyList[bodyList.Count - 1].gsY;

            // Move the body of the snake except for the head.
            for (int i = bodyList.Count - 1; i > 0; i--)
            {
                bodyList[i].gsX = bodyList[i - 1].gsX;
                bodyList[i].gsY = bodyList[i - 1].gsY;
            }

            // Move the head.
            if (direction == Direction.Up)
                bodyList[0].gsY += 1;
            else if (direction == Direction.Down)
                bodyList[0].gsY -= 1;
            else if (direction == Direction.Right)
                bodyList[0].gsX += 1;
            else if (direction == Direction.Left)
                bodyList[0].gsX -= 1;

            this.checkBiteItself();
        }

        // Append the snake.
        public void append()
        {
            bodyList.Add(new gsSprite(bodyImageFile, tailPositionX, tailPositionY));

            // Check the snake bite its tail or not.
            this.checkBiteItself();
        }

        // Judge the snake die or not.
        public bool isDead()
        {
            return dead;
        }

        // The snake is dead for some reason.
        public void die()
        {
            dead = true;
        }

        public void addPoint(int a)
        {
            this.score += a;
        }

        // Check the snake bite it self or not.
        protected bool checkBiteItself()
        {
            for (int i = 1; i < bodyList.Count; i++)
            {
                if (bodyList[0].gsX == bodyList[i].gsX
                    && bodyList[0].gsY == bodyList[i].gsY)
                {
                    this.die();
                    return true;
                }
            }

            return false;
        }
    }
}
