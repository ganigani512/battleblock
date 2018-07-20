using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreater : MonoBehaviour
{
    [SerializeField] GameObject wallPre;
    [SerializeField] GameObject roadPre;
    int[,] map = new int[,]
    {
        {0,0,0,1,0,0,0,0},
        {0,1,0,0,1,0,0,1},
        {0,0,1,0,0,0,0,0},
        {0,0,1,1,1,0,1,0},
        {0,1,0,0,0,1,0,0},
        {0,0,0,0,1,0,1,1},
    };
    int[,] heightmap = new int[,]
   {
        {1,0,0,1,0,0,2,1},
        {2,1,0,0,1,3,2,1},
        {3,1,1,0,0,4,2,3},
        {4,2,1,1,1,4,3,4},
        {3,2,1,0,0,5,6,5},
        {2,2,1,0,1,0,5,4},
   };
    GameObject GetPreBlock(int num)
    {
        GameObject block = null;
        switch (num)
        {
            case 0:
                block = roadPre;
                break;
            case 1:
                block = wallPre;
                break;
        }
        return block;
    }
    BattleStage battleStage;
    void CreateBlock(GameObject pre_obj,Point2 block_point,int map_height)
    {
       
        for (int h=0;h<=map_height;h++)
        {
            GameObject block = Instantiate(pre_obj);
            block.GetComponentInChildren<BlockPointGetter>().point = block_point;
            block.transform.position = new Vector3(block_point.x,h, block_point.y);
            if (h==map_height)
            {
                battleStage.AddBlock(block_point, new BattleBlock(map_height,block.transform));
            }
        }
    }
    public void CreateStage()
    {
        battleStage= CompornentUtility.FindCompornentOnScene<BattleStage>();
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                int mapType = map[x, y];
                int mapHeight = heightmap[x, y];
                GameObject blockPre = GetPreBlock(mapType);
                Point2 blockPoint = new Point2(x, y);
                CreateBlock(blockPre,blockPoint,mapHeight);
            }
        }
    }
}
