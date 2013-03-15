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
        private List<CCSprite> walls;
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
            walls = new List<CCSprite>();

            for (int i = 0; i < GamePlayLayer.HEIGHT; i++)
            {
                walls.Add(WallFactory.createWall(new CCPoint(20, 180 + 40 * i)));
                walls.Add(WallFactory.createWall(new CCPoint(460, 180 + 40 * i)));
            }

            for (int i = 0; i < GamePlayLayer.WIDTH - 2; i++)
            {
                walls.Add(WallFactory.createWall(new CCPoint(60 + 40 * i, 180)));
                walls.Add(WallFactory.createWall(new CCPoint(60 + 40 * i, 620)));
            }

            // Add the wall to the game field.
            foreach(CCSprite wall in walls)
                this.addChild(wall);

            // Add player snake to the game.
            playerSnake = new PlayerSnake("images/Sprite/PlayerSnakeHead", "images/Sprite/PlayerSnakeBody",
                Direction.Right, new CCPoint(220, 380), 5, 40);

            List<CCSprite> bodyList = playerSnake.getBodySprite();

            foreach (CCSprite body in bodyList)
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

            do
            {
                occupy = false;

                x = rand.Next(GamePlayLayer.WIDTH - 2) * 40 + 60;
                y = rand.Next(GamePlayLayer.HEIGHT - 2) * 40 + 220;

                foreach (CCPoint body in playerSnake.getPositions())
                {
                    if (body.x == x && body.y == y)
                        occupy = true;
                }
            } while (occupy);

            food = new Food(1, new CCPoint(x, y));
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
                CCPoint head = playerSnake.getHeadPosition();
                foreach (CCSprite wall in walls)
                {
                    if (wall.position.x == head.x && wall.position.y == head.y)
                        playerSnake.die();
                }

                if (head.x == food.position.x && head.y == food.position.y)
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
