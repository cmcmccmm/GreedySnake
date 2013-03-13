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
        Left
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

        // A full constructor.
        public Snake(string headImageFile, string bodyImageFile, Direction direction, CCPoint initPosition, int length, int stepLength)
        {
            this.headImageFile = headImageFile;
            this.bodyImageFile = bodyImageFile;
            this.direction = direction;
            this.stepLength = stepLength;
            this.dead = false;
            this.score = 0;

            CCSprite bodySprite = CCSprite.spriteWithFile(headImageFile);
            bodySprite.position = initPosition;
            bodyList.Add(bodySprite);

            bodySprite = CCSprite.spriteWithFile(bodyImageFile);
            for (int i = 1; i < length; i++)
            {
                if (direction == Direction.Up)
                    initPosition.y -= stepLength;
                else if (direction == Direction.Down)
                    initPosition.y += stepLength;
                else if (direction == Direction.Left)
                    initPosition.x += stepLength;
                else
                    initPosition.x -= stepLength;
                bodySprite.position = initPosition;

                bodyList.Add(bodySprite);
            }
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

        // Set the direction of the snake.
        public void setDirection(Direction d)
        {
            direction = d;
        }

        // Move the snake to the direction it face to.
        public void move()
        {
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
            if (direction == Direction.Up)
                bodyList[0].position.y += stepLength;
            else if (direction == Direction.Down)
                bodyList[0].position.y -= stepLength;
            else if (direction == Direction.Right)
                bodyList[0].position.x += stepLength;
            else
                bodyList[0].position.x -= stepLength;

            this.checkBiteItself();
        }

        // Append the snake.
        public void append()
        {
            // Record the tail position.
            CCPoint tailPosition = bodyList[bodyList.Count - 1].position;
            
            this.move();
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
