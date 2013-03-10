using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    class MainMenu : CCLayer
    {
        public override bool init()
        {
            if (!base.init())
                return false;

            // Set the orientation of the phone.
            CCDirector.sharedDirector().deviceOrientation = ccDeviceOrientation.kCCDeviceOrientationPortrait;

            this.m_bIsTouchEnabled = true;
            
            // Get the width and the height of the phone.
            float width = CCDirector.sharedDirector().getWinSize().width;
            float height = CCDirector.sharedDirector().getWinSize().height;

            // Set the background of the screen.
            CCSprite background = CCSprite.spriteWithFile(@"images/background/MainMenu");
            background.position = new CCPoint(width / 2, height / 2);
            this.addChild(background);

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
            MainMenu mm = new MainMenu();

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
            CCDirector.sharedDirector().pushScene(playScene);
        }

        // Exit the game when exit item is selected.
        void exitCallBack(object sender)
        {
            CCDirector.sharedDirector().end();
            CCApplication.sharedApplication().Game.Exit();
        }
    }
}
