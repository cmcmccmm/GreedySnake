using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace GreedySnakeCocos2d.Classes
{
    /*
     * A enum of game state.
     */
    enum GameState
    {
        Playing,
        Win,
        Lose,
        Draw
    }

    /*
     * This is the scene of the menu at the very beginning of game.
     * Author: Tan Tian Xiang
     * Date: 2013.3.10
     */
    class GamePlayScene : CCScene
    {
        // When the scene is loaded, execute the following code.
        public override void onEnter()
        {
            base.onEnter();
            CCLayerColor colorLayer = CCLayerColor.layerWithColor(new ccColor4B(181, 230, 29, 255));
            this.addChild(colorLayer);
            this.addChild(GamePlayLayer.node());
        }
    }
}
