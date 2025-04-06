using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Start()
    {
        GetComponent<AudioSource>().Play();

    }
}
