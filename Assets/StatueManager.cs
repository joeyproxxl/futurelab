using UnityEngine;

public class StatueManager : MonoBehaviour
{
    public GameObject[] statues;

    public Transform[] statueLoc;

    public bool[] state = new bool[3];

    public MiniGameManager manager;

    void FixedUpdate()
    {
        for (int i = 0; i < statues.Length; i++)
        {
            if (Vector3.Distance(statues[i].transform.position, statueLoc[i].transform.position) < .3f)
            {
                statues[i].transform.position = statueLoc[i].position;
                statues[i].transform.rotation = statueLoc[i].rotation;
                statues[i].isStatic = true;
                statues[i].GetComponent<Rigidbody>().isKinematic = true;
                state[i] = true;
            }
        }

        if (state[0] && state[1] && state[2]) manager.lol = true;
    }
}
