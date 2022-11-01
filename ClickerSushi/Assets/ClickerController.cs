using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class ClickerController : MonoBehaviour
{

    public static ClickerController instance;
    [SerializeField] List<GameObject> Sushies;
    [SerializeField] int SushiPrice = 5;
    [SerializeField] Transform SushiDetection;
    [SerializeField] float RayLenght;
    [SerializeField] bool isDetected = false;
    [SerializeField] int SushiIndex = 0;
    [SerializeField] float SushiSpeed = 2f;
    [SerializeField] List<Transform> Seats;
    [SerializeField] int SeatCounter = 1;
    [SerializeField] List<Transform> OpenSeats;
    [SerializeField]List <GameObject> Customers;
    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        OpenSeat();
        StartCoroutine(Spawner());
    }

    void Update()
    {
            RaycastHit hit;
            if (Physics.Raycast(SushiDetection.position,transform.forward,out hit, RayLenght))
            {
                Debug.DrawRay(SushiDetection.position,transform.forward*RayLenght,Color.green);
                Debug.Log(hit.transform.name);
                isDetected = true;
            }
            else
            {
                isDetected = false;   
            }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            MoneyManager.instance.AddMoney(500);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoneyManager.instance.SpendMoney(200);
        }
        if (Input.GetMouseButtonDown(0)&& !isDetected)
        {
            GameObject sushi = Instantiate(Sushies[SushiIndex]);
            SplineFollower sushiFollower = sushi.GetComponent<SplineFollower>();
            sushiFollower.spline = GameObject.FindGameObjectWithTag("SC").GetComponent<SplineComputer>();
            sushiFollower.follow = true;
            sushiFollower.followSpeed = SushiSpeed;
        }
    }

    public void SpeedUP()
    {

    }
    public void PriceUP()
    {
        SushiPrice += 10;
    }
    public void AddSeat()
    {
        SeatCounter++;
        OpenSeat();
       
    }
    void OpenSeat()
    {
         for (int i = 0; i < SeatCounter; i++)
        {
            if (!Seats[i].gameObject.activeInHierarchy)
            {
                Seats[i].gameObject.SetActive(true);
                OpenSeats.Add(Seats[i]);
            }
        }
    }

    public IEnumerator Spawner()
    {
            while (true)
            {
            yield return new WaitForSeconds(1);
            Transform _seat = OpenSeats[Random.Range(0,OpenSeats.Count)];
            Chair c = _seat.GetComponent<Chair>();

            GameObject _customer = Customers[Random.Range(0,Customers.Count)];
            if (!c.isAvailable)
            {
                continue;
            }
            GameObject newCustomer = Instantiate(_customer,_seat.position, Quaternion.Euler(0,-180,0));

            c.Customer = newCustomer;
            c.isAvailable = false;
            }
    }
}

