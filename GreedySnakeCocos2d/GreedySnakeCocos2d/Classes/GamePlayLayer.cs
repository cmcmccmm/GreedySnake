using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using GreedySnakeCocos2d.Classes.Sprite;

namespace GreedySnakeCocos2d.Classes
{
    /*
     * This class is the layer of menu items in the main menu scene.
     * Author: Tan Tian Xiang
     * Date: 2013.3.10
     */
    class GamePlayLayer : CCLayer, Observer
    {
        // Basic configure of the game.
        private const int WIDTH = 12;
        private const int HEIGHT = 12;
        private const int UPDATE_INTERVAL = 10;

        // Sprites in the game.
        private List<Wall> walls;
        private PlayerSnake playerSnake;
        private Food food;

        // Configure data in the game.
        private int updateTime;

        public override bool init()
        {
            if (!base.init())
            {
                return false;
            }

            // Set the basic data in the game.
            updateTime = 0;

            // Create walls.
            walls = new List<Wall>();
            
            for (int i = 0; i < GamePlayLayer.HEIGHT; i++)
            {
                walls.Add(new Wall(0, i));
                walls.Add(new Wall(11, i));
            }
            
            for (int i = 0; i < GamePlayLayer.WIDTH - 2; i++)
            {
                walls.Add(new Wall(i + 1, 0));
                walls.Add(new Wall(i + 1, 11));
            }
            
            // Add the wall to the game field.
            foreach(Wall wall in walls)
                this.addChild(wall);

            // Add player snake to the game.
            playerSnake = new PlayerSnake(Direction.Right, 5, 5, 4);

            List<gsSprite> bodyList = playerSnake.getBodySprite();

            foreach (gsSprite body in bodyList)
                this.addChild(body);

            // Add food to the game.
            this.addFood();

            this.schedule(updateTicks);

            return true;
        }

        /*
         * Add the food to the field.
         */
        public void addFood()
        {
            Random rand = new Random();

            int x, y;
            bool occupy = false;

            List<gsSprite> playerSnakeSprite = playerSnake.getBodySprite();

            do
            {
                occupy = false;

                x = rand.Next(GamePlayLayer.WIDTH - 2) + 1;
                y = rand.Next(GamePlayLayer.HEIGHT - 2) + 1;

                foreach (gsSprite body in playerSnakeSprite)
                {
                    if (body.gsX == x && body.gsY == y)
                        occupy = true;
                }
            } while (occupy);

            food = new Food(1, x, y);
            this.addChild(food);
        }
        
        public static new GamePlayLayer node()
        {
            GamePlayLayer layer = new GamePlayLayer();

            if (layer.init())
                return layer;
            else
                return null;
        }

        // This function is updated every tick.
        private void updateTicks(float dt)
        {
            if (this.updateTime < UPDATE_INTERVAL)
            {
                this.updateTime++;
            }
            else
            {
                // Player move.
                playerSnake.move();

                // Check the player crash into the wall or not.
                gsSprite head = playerSnake.getHeadPosition();

                foreach (gsSprite wall in walls)
                {
                    if (wall.gsX == head.gsX && wall.gsY == head.gsY)
                        playerSnake.die();
                }

                if (head.gsX == food.gsX && head.gsY == food.gsY)
                {
                    playerSnake.addPoint(food.getAward());
                    playerSnake.append();
                    this.addChild(playerSnake.getTail());
                    this.removeChild(food, false);
                    this.addFood();
                }
                this.updateTime = 0;
            }

            // If player is dead, end the game.
            if (playerSnake.isDead())
                CCDirector.sharedDirector().replaceScene(new GameOverScene());
        }

        // The implementation of the interface oberserver.
        public void update(object obj)
        {
            playerSnake.setDirection(((GestureLayer)obj).getDirection());
        }
    }
}
