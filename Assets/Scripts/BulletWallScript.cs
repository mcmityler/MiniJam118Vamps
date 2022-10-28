/*
* Creator : Tyler McMillan
* Description: Wall that destroys any bullets that get past the game screen
*/
using UnityEngine;

public class BulletWallScript : MonoBehaviour
{
     void OnCollisionEnter2D(Collision2D col) //destroy any bullets that get past the vampires
    {
        if(col.gameObject.tag == "BloodBullet"){
            Destroy(col.gameObject);
        }
    }
}
