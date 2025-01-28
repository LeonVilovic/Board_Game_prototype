using UnityEngine;

public class PlayerStone : MonoBehaviour
{

    DiceRoller TheDiceRoller;

    public Tile StartingTile;

    Tile currentTile;

    Tile[] moveQueue;

    Vector3 targetPosition;
    Vector3 velocity;
    float smoothTime = 0.25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TheDiceRoller = GameObject.FindFirstObjectByType<DiceRoller>();

        targetPosition = this.transform.position;
    }



    // Update is called once per frame
    void Update()
    {

        if (this.transform.position != targetPosition)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, smoothTime);

        }
    }

    void SetNewTargetPosition(Vector3 pos) 
    {
        targetPosition = pos;
        velocity = Vector3.zero;
    }


    private void OnMouseUp()
    {
        Debug.Log("Click");

        if (TheDiceRoller.IsDoneRolling == false) {
            return;
        }

        int spacesToMove = TheDiceRoller.DiceTotal;

        if (spacesToMove == 0) 
        { 
        return;
        }


        moveQueue = new Tile[spacesToMove];
        Tile finalTile = currentTile;

        for (int i = 0; i < spacesToMove; i++)
        {
            if (finalTile == null)
            {
                finalTile = StartingTile;
            }
            else {
                if (finalTile.NextTiles == null || finalTile.NextTiles.Length == 0)
                {
                    Debug.Log("SCORE");
                    Destroy(gameObject);
                    return;
                }
                else if (finalTile.NextTiles.Length > 1 ) 
                {
                    //TODO branch based on player
                    finalTile = finalTile.NextTiles[0];
                }
                else
                {
                finalTile = finalTile.NextTiles[0];
                }
            }
        }

        if (finalTile == null) {

            return;
        }

        //this.transform.position = finalTile.transform.position + new Vector3(0, 0.6f, 0);
        SetNewTargetPosition(finalTile.transform.position + new Vector3(0, 0.6f, 0));
        currentTile = finalTile;

    }
}
