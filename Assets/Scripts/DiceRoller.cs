using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DiceValues = new int[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] DiceValues;
    public int DiceTotal;

    public bool IsDoneRolling = false;
    public Sprite[] DiceImageOne;
    public Sprite[] DiceImageZero;

    public void newTurn()
    {
        Debug.Log("newTurn() triggerd");
        IsDoneRolling = false;

    }

    public void RollTheDice()
    {
        Debug.Log("RollTheDice() triggerd");
        // In UR you Roll 4 dice (tetraheadron tradicionally) which have half face values as 1 and half faces of value 0

        DiceTotal = 0;
        for (int i = 0; i < DiceValues.Length; i++) 
        { 
            DiceValues[i] = Random.Range( 0 , 2 );
            DiceTotal += DiceValues[i];

            if (DiceValues[i] == 0)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageZero[Random.Range(0, DiceImageZero.Length)];

            }
            else {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageOne[Random.Range(0, DiceImageOne.Length)];
            }

            IsDoneRolling = true;
        }
        Debug.Log( "Rolled: " + DiceValues  + "("+ DiceTotal + ")");
    }

}
