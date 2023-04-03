using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int _coinCount = 0;
    [SerializeField] private float _bestDistance = 0;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoinCount(int amount)
    {
        _coinCount += amount;
    }

    public int GetCoinCoint()
    {
        return _coinCount;
    }

    public void SetBestDistanceTraveled(float amount)
    {
        if(_bestDistance < amount)
        {
            _bestDistance = amount;
        }
    }

    public float GetBestDistanceTraveled()
    {
        return _bestDistance;
    }
}