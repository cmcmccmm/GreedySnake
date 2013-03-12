using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedySnakeCocos2d.Classes
{
    /*
     * These interface is designed as the observer pattern and used
     * when the new gesture is detected in the gesture layer.
     * Author: Tan Tian Xiang
     * Date: 2013.3.12
     */
    public interface Observer
    {
        public void update();
    }

    public interface Observerable
    {
        public void addObserver(Observer o);
        public void deleteObserver(Observer o);
        public void notifyObserver();
    }
}
