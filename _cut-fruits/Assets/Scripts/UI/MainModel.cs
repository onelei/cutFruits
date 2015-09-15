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

        public List<FruitItemOne> mFruitsOneList;

        public MainModel()
        {
            mFruitsOneList = new List<FruitItemOne>();
        }

        public void AddFruitsOne(FruitItemOne item)
        {
            mFruitsOneList.Add(item);
        }
    }
}
