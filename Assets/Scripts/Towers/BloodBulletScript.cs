/*
* Creator : Tyler McMillan
* Description: Script that controls bullet that is shot
*/
using UnityEngine;

public class BloodBulletScript : MonoBehaviour
{
    private float _moveSpeed = 1f; //how fast bullet moves
    [SerializeField] Vector3 _shootDirection = new Vector3(1, 0, 0); //direction for the bullet to travel
    void Awake()
    {
        if (FindObjectOfType<AudioManager>().GetSoundMuted() == false) //make sure game isnt muted
        {
            this.gameObject.GetComponent<AudioSource>().Play(); //play bullet shoot sound
        }
    }
    void Update()
    {
        //move bullet position by movement speed
        transform.position = transform.position + (_shootDirection * _moveSpeed * Time.deltaTime);
    }

    public void SetSpeed(float m_moveSpeed)
    {
        _moveSpeed = m_moveSpeed;
    }
    public float GetSpeed()
    {
        return _moveSpeed;
    }
}
