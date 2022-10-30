/*
* Creator : Tyler McMillan
* Description: Wall that destroys any bullets that get past the game screen
*/
using UnityEngine;

public class BulletWallScript : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D col) //destroy any bullets that get past the vampires
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject.tag == "BloodBullet"){
            Destroy(col.gameObject);
            Debug.Log("destroyed object");
        }
    }
}
