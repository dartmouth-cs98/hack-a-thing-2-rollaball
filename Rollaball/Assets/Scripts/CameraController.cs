using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // late update runs after all the other updates are done
    // so camera position won't be set until the player has moved for that frame
    void LateUpdate() 
        // so camera position 
    {
        transform.position = player.transform.position + offset;
    }
}
