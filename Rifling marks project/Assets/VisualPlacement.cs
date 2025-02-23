using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPlacement : MonoBehaviour
{
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerData.Position;
        transform.rotation = playerData.Rotation;
        transform.localScale = playerData.Scale;
    }
}
