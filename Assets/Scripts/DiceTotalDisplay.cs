using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceTotalDisplay : MonoBehaviour
{
    DiceRoller theDiceRoller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theDiceRoller = GameObject.FindFirstObjectByType<DiceRoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theDiceRoller.IsDoneRolling == false)
        {
            GetComponent<TextMeshProUGUI>().text = "= ?";
        }
        else 
        { 
        GetComponent<TextMeshProUGUI>().text = "= " + theDiceRoller.DiceTotal;        
        }
    }
}
