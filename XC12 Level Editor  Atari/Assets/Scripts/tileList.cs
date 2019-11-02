using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tileList : MonoBehaviour {
    void Start () {
        Tilemap tilemap = GetComponent<Tilemap>();

        StreamWriter level = new StreamWriter("level.txt",true);
        var tileList = new List<int>();
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        Debug.Log("x size :" + bounds.size.x);
        Debug.Log("y size :" + bounds.size.y);
        //for (int y = 0; y < bounds.size.y; y++) {
        for (int y = 7; y >= 4; y--) {    
            for (int x = 0; x < bounds.size.x; x++) {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null) {
                    //Debug.Log("x:" + x + " y:" + y + " tile:" + (Int32.Parse(tile.name.Remove(0,10))+1));
                    //Debug.Log((Int32.Parse(tile.name.Remove(0,10))+1));
                    level.Write((Int32.Parse(tile.name.Remove(0,10))+1));
                    level.Write(',');
                    tileList.Add((Int32.Parse(tile.name.Remove(0,10))+1)); 
                } else {
                    //Debug.Log(0);
                    level.Write(0);
                    level.Write(',');
                    tileList.Add(0);
                }
            }
            level.Write('\n');
            level.Write('\n');
        } 
        /*foreach (int item in tileList)
        {
            level.Write(item);    
        }*/
        int arrayMax = bounds.size.x-1;
        int len = tileList.Count+1;
        int start=0;
        int end = len/4;
        
        for (int lvlNum=1;lvlNum<=4;lvlNum++){
            level.Write("level1_"+lvlNum+": Array [0.."+arrayMax+"] of byte =");
            level.Write("\n("); 
            level.Write(tileList[start++]);
            
            for (int i=start;i<end;i++) {
                level.Write(',');     
                level.Write(tileList[i]);
                if (i%10==0) level.Write('\n');
            }
            level.Write(");");
            level.Write('\n');
            level.Write('\n');

            start+=len/4-1;         //sub 1, cause start++ in next iteration level.Write(tileList[start++]);
            end+=len/4;

        }
        
        level.Close();
        Debug.Log("Done!!!");       
    }   
}
