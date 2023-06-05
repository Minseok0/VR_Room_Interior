using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    
    GameObject objToSpawn;
    GameObject newInstanceofSpawn;
    [SerializeField] meshUIControl meshUIControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save()
    {
        GameObject objectWantToCopy = meshUIControl.target;
        objToSpawn = objectWantToCopy;
        newInstanceofSpawn = Instantiate(objToSpawn);
        Destroy(objectWantToCopy);
    }

    public void Load()
    {
        Instantiate(objToSpawn);
    }

}
