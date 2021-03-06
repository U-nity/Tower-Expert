﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickDeck : Singleton<BrickDeck> 
{

    public Material[] Materials;
    public List<Brick> bricks;
    public GameObject[] brickPrefabs;

    private int YellowBrickNum = 10;
    private int BlueBrickNum = 10;
    private int RedBrickNum = 10;
    private int TotalNum;

    public Brick OnDraw(Vector3 position)
    {
        int index = Random.Range(0, bricks.Count);
        Brick brick = bricks[index];
        bricks.RemoveAt(index);

        if (GameManager.Instance.CurrentGameState != GameState.Initial)
        {
            position -= Vector3.up * 0.5f;
        }

        //switch (brick.color) {
        //    case BrickColor.Red:
        //        GameObject.Instantiate(brickPrefabs[0], position, transform.rotation).transform.parent = PlayerManager.Instance.playerHand.transform;
        //        break;
        //    case BrickColor.Yellow:
        //        GameObject.Instantiate(brickPrefabs[1], position, transform.rotation).transform.parent = PlayerManager.Instance.playerHand.transform;
        //        break;
        //    case BrickColor.Blue:
        //        GameObject.Instantiate(brickPrefabs[2], position, transform.rotation).transform.parent = PlayerManager.Instance.playerHand.transform;
        //        break;
        //}

        brick.transform.position = position;
        brick.transform.parent = PlayerManager.Instance.playerHand.transform;

        return brick;
    }

    public void InitDeck()
    {
        TotalNum = YellowBrickNum + RedBrickNum + RedBrickNum;
        for (int i = 0; i < YellowBrickNum; i++)
        {
            Brick brick = GameObject.Instantiate(brickPrefabs[1], Vector3.forward * 100, transform.rotation).GetComponent<Brick>();
            bricks.Add(brick);
            brick.SetBrickColor(2);
        }
        for (int i = 0; i < BlueBrickNum; i++)
        {
            Brick brick = GameObject.Instantiate(brickPrefabs[2], Vector3.forward * 100, transform.rotation).GetComponent<Brick>();
            bricks.Add(brick);
            brick.SetBrickColor(0);
        }
        for (int i = 0; i < RedBrickNum; i++)
        {
            Brick brick = GameObject.Instantiate(brickPrefabs[0], Vector3.forward * 100, transform.rotation).GetComponent<Brick>();
            bricks.Add(brick);
            brick.SetBrickColor(1);
        }

    }


}


//randomBrickColor = Random.Range(0, 3);
//        Bricks[0].SetColor(randomBrickColor);
//MeshRenderer brickRenderer = Bricks[0].gameObject.GetComponent<MeshRenderer>();
//brickRenderer.material = Materials[randomBrickColor];

//        randomBrickColor = Random.Range(0, 3);
//        Bricks[1].SetColor(randomBrickColor);
//brickRenderer = Bricks[1].gameObject.GetComponent<MeshRenderer>();
//        brickRenderer.material = Materials[randomBrickColor];

//        randomBrickColor = Random.Range(0, 3);
//        Bricks[2].SetColor(randomBrickColor);
//brickRenderer = Bricks[2].gameObject.GetComponent<MeshRenderer>();
//        brickRenderer.material = Materials[randomBrickColor];