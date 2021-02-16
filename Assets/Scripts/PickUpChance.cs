using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpChance : MonoBehaviour
{
    [System.Serializable]
    public class PickUpDetails
    {
        public string pickUpName;
        public GameObject pickUp;
        public int pickUpRarity;
    }
    //public PickUpDetails[] PickUpList;
    public List<PickUpDetails> PickUpList = new List<PickUpDetails>();
    public int totalDropChance;
    //public int indexPickUp;
    

    public void CalculateChance()
    {
        int calculateDropChance = Random.Range(0, 101);
        if (calculateDropChance > totalDropChance)
        {
            return;
        }
        if (calculateDropChance <= totalDropChance)
        {
            int itemWeight = 0;
            for (int i = 0; i < PickUpList.Count; i++)
            {
                itemWeight += PickUpList[i].pickUpRarity; //454
            }

            int randomValue = Random.Range(0, itemWeight);
            Debug.Log("Random weight " + randomValue);
            for (int j = 0; j < PickUpList.Count; j++)
            {
                if (randomValue <= PickUpList[j].pickUpRarity)
                {
                    //indexPickUp = j;
                    Instantiate(PickUpList[j].pickUp, transform.position, Quaternion.identity);
                   
                    return;
                }
            }
        }
    }
}

