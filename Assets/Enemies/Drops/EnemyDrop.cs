using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {
    [SerializeField] private GameObject NormalDrop;
    [SerializeField] private GameObject RareDrop;
    [SerializeField] private float percentageOfRareDrop = 10;
    void Start() {
        float chance = Random.Range(0, 100);

        if (chance < percentageOfRareDrop) {
            Instantiate(RareDrop, transform.position, Quaternion.identity);
        }
        else {
            Instantiate(NormalDrop, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }

}
