﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneyPickup : MonoBehaviour
{
	public bool isCoin = false; //false is bag, true is coin
	private GameObject gameController;
    public int bagCost = 150;
    public int coinCost = 25;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    	if (collision.gameObject.tag == "Player")
        {
            int reducedPrice = bagCost;
            if(isCoin) reducedPrice = coinCost;
            gameController.GetComponent<Money>().CollectMoney(reducedPrice);
            Destroy(this.gameObject);
        }
    }

    public void spawnCoins(int amount, Vector3 pos) {
        int numBags = amount/bagCost;
        int numCoins = (amount - (numBags*bagCost))/coinCost;
        
        GameObject coin = Resources.Load<GameObject>("coin");
        GameObject moneyBag = Resources.Load<GameObject>("moneyBag");

        for(int i = 0; i < numCoins; i++){
            GameObject coins = Instantiate(coin);
            coins.transform.position = pos;
            coins.GetComponent<MoneyPickup>().isCoin = true;
        }
        for(int i = 0; i < numBags; i++){
            GameObject bagged = Instantiate(moneyBag);
            bagged.transform.position = pos;
            bagged.GetComponent<MoneyPickup>().isCoin = false;
        }
    }
}
