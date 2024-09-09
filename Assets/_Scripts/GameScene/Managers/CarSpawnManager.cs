using System.Collections.Generic;
using UnityEngine;

public class CarSpawnManager : Singleton<CarSpawnManager>
{
    [SerializeField] Vehicles muscle;
    [SerializeField] Vehicles sedan;
    [SerializeField] Vehicles jeep;
    [SerializeField] Vehicles sport;
    [SerializeField] Transform spawnPoint;

    public Vehicles activeCar;

    Dictionary<string, Vehicles> VehicleDictionary = new Dictionary<string, Vehicles>();

    public override void Awake()
    {
        base.Awake();

        VehicleDictionary.Add("Muscle", muscle);
        VehicleDictionary.Add("Sedan", sedan);
        VehicleDictionary.Add("Jeep", jeep);
        VehicleDictionary.Add("Sport", sport);
    }

    // Start is called before the first frame update
    void Start()
    {
       //SelectCar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCar()
    {
        Debug.Log(VehicleDictionary[GameManager.Instance.chosenCar]);
        activeCar = VehicleDictionary[GameManager.Instance.chosenCar];
        activeCar.gameObject.SetActive(true);
        activeCar.transform.position = spawnPoint.position;
        activeCar.transform.rotation = spawnPoint.rotation; 
    }



}
