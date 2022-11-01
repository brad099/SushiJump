using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class ClickerManager : MonoBehaviour
{
    public ClickerManager instance;
    [SerializeField] int Speed;
    [SerializeField] int SushiPrice;
    [SerializeField] int SeatCounter;
    [SerializeField] Transform SpawnTransform;
    [SerializeField] List<Transform> Seats;
    [SerializeField] float AnimSpeed = 1;
    [SerializeField] List<GameObject> Sushies;
    [SerializeField] int SushiIndex = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Create
            GameObject sushi = Instantiate(Sushies[SushiIndex]);
            //GetSpline Follower
            SplineFollower sushiFollower = sushi.GetComponent<SplineFollower>();
            //Get SplineComputer
            sushiFollower.spline = GameObject.FindGameObjectWithTag("SC").GetComponent<SplineComputer>();
            sushiFollower.follow = true;
            sushiFollower.followSpeed = Speed;
        }
    }
}
