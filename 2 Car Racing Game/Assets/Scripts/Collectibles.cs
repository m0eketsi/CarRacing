using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private int _value = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("player"))    
        {
            Debug.Log("I was hit by the player!");
            
            if(this.gameObject.CompareTag("coin"))
            {
                LevelManager.Instance.UpdateLevelCoinCount(_value);
            }

            if(this.gameObject.CompareTag("gas"))
            {
                LevelManager.Instance.UpdateGasAmount(_value);
                LevelManager.Instance.SetGasFillAmount(_value);
            }

            Destroy(this.gameObject);
        }
    }
}