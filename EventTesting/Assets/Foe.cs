using UnityEngine;
using System.Collections;

public class Foe : MonoBehaviour
{
    public int health;
    private float time = 0.5f;
    private float timer = 0.5f;

    private void OnEnable()
    {
        EventManager.Instance.Begin_Listening_To ( name + "_Drain", Drain_Health );
    }

    private void OnDisable()
    {
        EventManager.Instance.Stop_Listening_To ( name + "_Drain" );
    }

    private void Update()
    {
        if ( timer < 0 )
        {
            timer = time;
        }

        timer -= Time.deltaTime;
    }

    public void Drain_Health()
    {
        if ( timer <= 0 )
        {
            health -= 1;
        }
    }
}
