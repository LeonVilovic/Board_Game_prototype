using UnityEngine;

public class PlayerStone : MonoBehaviour
{

    DiceRoller TheDiceRoller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TheDiceRoller = GameObject.FindFirstObjectByType<DiceRoller>();
    }

    public Tile StartingTile;
    Tile currentTile;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        Debug.Log("Click");

        if (TheDiceRoller.IsDoneRolling == false) {
            return;
        }

        int spacesToMove = TheDiceRoller.DiceTotal;


        Tile finalTile = null;

        for (int i = 0; i < spacesToMove; i++)
        {
            if (currentTile == null)
            {
                finalTile = StartingTile;
            }
            else {
                finalTile = finalTile.NextTiles[0];
            }
        }

        if (finalTile == null) {

            return;
        }

        this.transform.position = finalTile.transform.position;

    }
}
