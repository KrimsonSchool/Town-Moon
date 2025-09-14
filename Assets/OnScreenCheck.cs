using Unity.VisualScripting;
using UnityEngine;

public class OnScreenCheck : MonoBehaviour
{
    //private bool isVisible;
    public GameObject associatedObj;

    void OnBecameVisible()
    {
        //isVisible = true;
        print("OnBecameVisible");
        associatedObj.SetActive(true);
    }
    void OnBecameInvisible()
    {
        //isVisible = false;
        print("OnBecameInvisible");
        associatedObj.SetActive(false);
    }
}
