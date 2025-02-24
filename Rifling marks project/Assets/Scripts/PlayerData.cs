using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string playerIP;
    public string playerName;
    public string playerId;
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;
}

//UDP Packet Structure for the game
/* Player IP Byte0, Byte1, Byte2, Byte3 \0ss
 * playerName playernames should go to a maximum of 16 characters and then will have an additional two slots for the \0 indicator
 * playerID ends with \0 
 * (Include a byte to refer to length) Position X
 * (Include a byte to refer to length) Position Y
 * (Include a byte to refer to length) Position Z
 * (Include a byte to refer to length) Rotation X
 * (Include a byte to refer to length) Rotation Y
 * (Include a byte to refer to length) Rotation Z
 * (Include a byte to refer to length) Scale X
 * (Include a byte to refer to length) Scale Y
 * (Include a byte to refer to length) Scale Z
 */

//The end of string indicator is \0 which in Bytes is 92 48