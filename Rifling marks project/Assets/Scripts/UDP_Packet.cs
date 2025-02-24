using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDP_Packet : MonoBehaviour
{
    //DATA
    public Vector3 position;
    public Quaternion rotation;
    public byte playerID;
    public Vector3 velocity;
    public byte actionState;

    //Footer
    public byte CheckSum = 0xa5;
    public byte packEnd = 0xff;
}

/* What should be including
 * Player Position
 * Player Rotation
 * Target Player ID
 * Velocity of player
 * Action State
 * 
 * Checksum
 * Packet Ender
 */