using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    class MainMenuLayer : CCLayer
    {
    
        public override bool init()
        {
            if (!base.init())
                return false;

            float width = CCDirector.sharedDirector().getWinSize().width;
            float height = CCDirector.sharedDirector().getWinSize().height;

            // List the menu item in the menu.
            CCMenuItemImage startItem = CCMenuItemImage.itemFromNormalImage(@"images/menuItem/startItem", @"images/menuItem/startItem", this, startCallBack);
            CCMenuItemImage exitItem = CCMenuItemImage.itemFromNormalImage(@"images/menuItem/exitItem", @"images/menuItem/exitItem", this, exitCallBack);

            // Compose the menu items into  menu, and set the main menu.
            CCMenu mainMenu = CCMenu.menuWithItems(startItem, exitItem);
            mainMenu.alignItemsVerticallyWithPadding(20f);
            mainMenu.position = new CCPoint(width / 2, height / 2 - 150);
            this.addChild(mainMenu);

            return true;
        }

        public static new CCLayer node()
        {
            MainMenuLayer mm = new MainMenuLayer();

            if (!mm.init())
            {
                mm = null;
            }

            return mm;
        }

        // Start the game when start item is selected.
        void startCallBack(object sender)
        {
            GamePlayScene playScene = new GamePlayScene();
            CCDirector.sharedDirector().replaceScene(playScene);
        }

        // Exit the game when exit item is selected.
        void exitCallBack(object sender)
        {
            CCDirector.sharedDirector().end();
            CCApplication.sharedApplication().Game.Exit();
        }
    }
}
