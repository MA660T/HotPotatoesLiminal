using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Object : MonoBehaviour
{
    public UnityEvent ObjectJuggle;

    private void Start()
    {
        ObjectJuggle.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AddScore);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IPlayer>() != null)
        {
            ObjectJuggle.Invoke();
        }
    }

    public void TestMethod()
    {
        print("Working");
    }
}
