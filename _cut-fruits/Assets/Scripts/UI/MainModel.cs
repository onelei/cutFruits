using UnityEngine;
using System.Collections.Generic;

namespace cutFruits
{
    public class MainModel
    {
        private static MainModel _instance=null;
        public static MainModel Instance
        {
            get
            {
                if(_instance==null)
                {
                    _instance = new MainModel();
                }
                return _instance;
            }
        }

        public List<OneFruit> mFruitsList;
        public MainModel()
        {
            mFruitsList = new List<OneFruit>();
        }

        public void AddFruits(OneFruit fruit)
        {
            mFruitsList.Add(fruit);
        }
    }
}
