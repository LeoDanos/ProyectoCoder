using UnityEngine;

public class Ultrasonic : MonoBehaviour
{
    public float range = 100f;
    public GameObject ultraSonicModule;
    public AudioSource beep;
    private float playPitch = 1;
    public float distance = 10;

    void FixedUpdate()
    {
        Detector();
    }

    void Detector()
    {
        RaycastHit hit;
        if(Physics.Raycast(ultraSonicModule.transform.position, ultraSonicModule.transform.forward, out hit, range))
        {
            if((hit.transform.tag == "Enemy" || hit.transform.tag == "Wall" || hit.transform.tag == "Obstacle") && hit.distance <= distance ) 
            {
                if (hit.distance <= 10 && hit.distance >= 1)
                {
                    playPitch = 3 / hit.distance;
                }
                beep.pitch = playPitch;
                beep.volume = 1;
            }
            else
            {
                beep.volume = 0;
            }
        }
        else
        {
            beep.volume = 0;
        }
    }
}