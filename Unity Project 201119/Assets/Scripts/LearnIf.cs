
using UnityEngine;

public class LearnIf : MonoBehaviour
{
    public bool openDoor;

    private void Start()
    {
        if (openDoor)
        {
            print("開門啊~");
        }
        else
        {
            print("關門囉!");
        }
    }
}
