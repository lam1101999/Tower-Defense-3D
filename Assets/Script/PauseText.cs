
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseText : MonoBehaviour
{


    public void Toggle(){
       gameObject.SetActive(!gameObject.activeSelf);

       
    }
}
