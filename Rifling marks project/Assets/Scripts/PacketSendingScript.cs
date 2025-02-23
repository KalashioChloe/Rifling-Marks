using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class PacketSendingScript : MonoBehaviour
{
    int port = 0;
    public int SentPacks = 0;
    public int SR = 100000;
    int CSR = 0;
    UdpClient udpClient = new UdpClient("192.168.0.24", 0);
    Byte[] sendBytes = Encoding.ASCII.GetBytes("0302005000011800000");
    //1.18


    void Start()
    {
        Thread sendUDP = new Thread(() => SendPacketsFunc());
        SentPacks = 0;
        Connect();
        sendUDP.Start();
    }

    void Connect()
    {
        Debug.Log("Connecting...");
        udpClient.Connect("192.168.0.24", 3066);
        Debug.Log("Connected!");
    }

    void SendPacketsFunc()
    {
        Debug.Log("Sending Packets...");
        void SendPackets(byte[] bytes)
        {
            ;
            try
            {
                udpClient.Send(bytes, bytes.Length);
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }

        

        while (true)
        {
            if (CSR <= 0)
            {
                Console.Clear();
                Console.WriteLine("Packets Sent: " + SentPacks);
                CSR += SR;
                SendPackets(sendBytes);
                SentPacks += 1;
            }
            else
            {
                CSR--;
            }
        }
    }
}
