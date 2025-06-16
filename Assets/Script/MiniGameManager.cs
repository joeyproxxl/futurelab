using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] public bool collorCombineGame;
    [SerializeField] public bool GammaGame;
    [SerializeField] public bool lol;

    [SerializeField] public GameObject done;

    private bool BoolCheck()
    {
        if (collorCombineGame && GammaGame && lol) { return true; }
        else return false;
    }

    private void FixedUpdate()
    {
        if(BoolCheck()){ done.SetActive(true); this.enabled = false; }
    }
}
