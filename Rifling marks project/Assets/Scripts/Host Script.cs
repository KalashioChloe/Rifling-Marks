using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class HostScript : MonoBehaviour
{
    public List<PlayerData> playerData = new();
    public int playerCount;
    ByteConvert Convert;
    PacketSendingScript packetSendingScript;

    public bool isHost;
    // Start is called before the first frame update
    void Start()
    {
        playerCount = playerData.Count;
        Convert = new ByteConvert();
        packetSendingScript = new PacketSendingScript();
        //SendUpdate();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ParseUDP(string data)
    {
        string opcode = "";
        opcode += data[0];
        opcode += data[1];
        switch (opcode)
        {
            case "00":
                
                break;
            case "01":

                break;
            case "02":

                break;
            case "03":
                string ID = "";
                ID += data[2];
                ID += data[3];

                string xNeg = "";
                xNeg += data[4];

                string yNeg = "";
                yNeg += data[10];

                string zNeg = "";
                zNeg += data[16];


                string x = "";
                string y = "";
                string z = "";
                //03 02 00500 00000 00000
                for (int i = 0; i < playerCount; i++)
                {
                    if (playerData[i].playerId == ID)
                    {
                        int incr = 4;
                        
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                if (j == 0)
                                {
                                    x += data[k + incr];
                                }
                                else if (j == 1)
                                {
                                    y += data[k + incr];
                                }
                                else if (j == 2)
                                {
                                    z += data[k + incr];
                                }
                                
                            }
                            incr += 5;

                        }
                        
                        Vector3 vector3 = new Vector3();


                        vector3.x = (float.Parse(x));
                        vector3.x /= 100;
                        vector3.y = (float.Parse(y));
                        vector3.y /= 100;
                        vector3.z = (float.Parse(z));
                        vector3.z /= 100;

                        playerData[i].Position = vector3;
                        break;
                    }
                }
                break;
            default:
                break;
        }
    }
    

    void SendUpdate()
    {
        
        for (int i = 0; i < playerData.Count;)
        {
            List<List<byte>> listB = new List<List<byte>>();

            
            //Debug.Log("Attempting to Convert Name");
            listB.Add(Convert.StringToByte(playerData[i].playerName));
            //Debug.Log("Name Convert Successful");

            //Debug.Log("Attempting to Convert ID");
            listB.Add(Convert.StringToByte(playerData[i].playerId));
            //Debug.Log("ID Convert Successful");

            //Debug.Log("Attempting to Convert Position");
            listB.Add(Convert.StringToByte(playerData[i].Position.ToString()));
            //Debug.Log("Position Convert Successful");

            //Debug.Log("Attempting to Convert Rotation");
            listB.Add(Convert.StringToByte(playerData[i].Rotation.ToString()));
            //Debug.Log("Rotation Convert Successful");
            i++;
            int total = 0;
            for (int j = 0; j < listB.Count; i++)
            {
                for (int k = 0; k < listB[j].Count; k++)
                {
                    
                    total++;
                }
            }
            var Bytes = new byte[total];
            total = 0;
            for (int j = 0; j < listB.Count; i++)
            {
                for (int k = 0; k < listB[j].Count; k++)
                {
                    Bytes[total] = listB[j][k];
                    total++;
                }
            }
            //packetSendingScript.sendBytes = Bytes;
        }
    }
}
