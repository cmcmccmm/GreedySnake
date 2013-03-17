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
        protected List<CCSprite> bodyList;

        // The string record the head image file and the body image file.
        protected string headImageFile;
        protected string bodyImageFile;

        // The direction that the snake face to.
        Direction direction;
        
        // The length that the snake step in one turn.
        protected int stepLength;

        // Record the score the snake get.
        protected int score;

        // Judge the snake dead or not.
        protected bool dead;

        // Record the tail position before the move.
        protected CCPoint tailPosition;

        // A full constructor.
        public Snake(string headImageFile, string bodyImageFile, Direction direction, CCPoint initPosition, int length, int stepLength)
        {
            this.headImageFile = headImageFile;
            this.bodyImageFile = bodyImageFile;
            this.direction = direction;
            this.stepLength = stepLength;
            this.dead = false;
            this.score = 0;
            this.bodyList = new List<CCSprite>();

            CCSprite bodySprite = CCSprite.spriteWithFile(headImageFile);
            bodySprite.position = initPosition;
            bodyList.Add(bodySprite);

            CCPoint tempPosition;
            for (int i = 1; i < length; i++)
            {
                bodySprite = CCSprite.spriteWithFile(bodyImageFile);
                tempPosition = new CCPoint(initPosition.x, initPosition.y);

                if (direction == Direction.Up)
                    tempPosition.y -= stepLength * i;
                else if (direction == Direction.Down)
                    tempPosition.y += stepLength * i;
                else if (direction == Direction.Left)
                    tempPosition.x += stepLength * i;
                else if (direction == Direction.Right)
                    tempPosition.x -= stepLength * i;

                bodySprite.position = tempPosition;

                bodyList.Add(bodySprite);
            }

            this.tailPosition = new CCPoint(bodyList[bodyList.Count - 1].position.x, 
                bodyList[bodyList.Count - 1].position.y);
        }

        // Get the sprite of the snake.
        public List<CCSprite> getBodySprite()
        {
            return bodyList;
        }

        // Get the positions of the body.
        public List<CCPoint> getPositions()
        {
            List<CCPoint> positions = new List<CCPoint>();

            for (int i = 0; i < bodyList.Count; i++)
            {
                positions.Add((bodyList[i].position));
            }

            return positions;
        }

        // Get the head position.
        public CCPoint getHeadPosition()
        {
            return bodyList[0].position;
        }

        // Get the tail position.
        public CCSprite getTail()
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
            this.tailPosition = new CCPoint(bodyList[bodyList.Count - 1].position.x,
                bodyList[bodyList.Count - 1].position.y);

            // Move the body of the snake except for the head.
            int length = bodyList.Count;
            CCPoint prevPosition = bodyList[0].position;
            CCPoint tempPosition;

            for (int i = 1; i < length; i++ )
            {
                tempPosition = bodyList[i].position;
                bodyList[i].position = prevPosition;
                prevPosition = tempPosition;
            }

            // Move the snake.
            tempPosition = new CCPoint(bodyList[0].position.x, bodyList[0].position.y);

            if (direction == Direction.Up)
                tempPosition.y += stepLength;
            else if (direction == Direction.Down)
                tempPosition.y -= stepLength;
            else if (direction == Direction.Right)
                tempPosition.x += stepLength;
            else if (direction == Direction.Left)
                tempPosition.x -= stepLength;

            bodyList[0].position = tempPosition;
            this.checkBiteItself();
        }

        // Append the snake.
        public void append()
        {
            CCSprite newTail = CCSprite.spriteWithFile(bodyImageFile);
            newTail.position = tailPosition;
            bodyList.Add(newTail);

            // Check the snake bite its tail or not.
            CCPoint headPosition = bodyList[0].position;

            if (headPosition.x == tailPosition.x 
                && headPosition.y == tailPosition.y)
            {
                this.die();
            }
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
            CCPoint head = bodyList[0].position;

            for (int i = 1; i < bodyList.Count; i++)
            {
                if (head.x == bodyList[i].position.x
                    && head.y == bodyList[i].position.y)
                {
                    this.die();
                    return true;
                }
            }

            return false;
        }
    }
}
