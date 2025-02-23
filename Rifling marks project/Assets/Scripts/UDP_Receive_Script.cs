using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
using System.Linq;
using System.Threading;

public class UDP_Receive_Script : MonoBehaviour
{
    public int readDelay = 100;
    int rs = 0;
    public HostScript host;

    UdpClient receivingUdpClient = new UdpClient(0);

    //Creates an IPEndPoint to record the IP Address and port number of the sender.
    // The IPEndPoint will allow you to read datagrams sent from any source.


    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
    bool bacon = true;
    Thread receiveUDP;
    // Start is called before the first frame update
    void Start()
    {

        Thread mainThread = Thread.CurrentThread;
        receiveUDP = new Thread(() => ReceivePackets());
    }

    private void OnDisable()
    {
        bacon = false;
    }

    void StartUDP()
    {
        Debug.Log("Starting UDP Receive");
        receiveUDP.Start();
        Debug.Log("Started UDP Receive");
    }

    void EndUDP()
    {
        Debug.Log("Ending UDP Receive");
        receiveUDP.Abort();
        Debug.Log("Ended UDP Receive");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            StartUDP();
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            EndUDP();
        }
    }

    void ReceivePackets()
    {
        UdpClient receivingUdpClient = new UdpClient(3066);


        //Creates an IPEndPoint to record the IP Address and port number of the sender.
        // The IPEndPoint will allow you to read datagrams sent from any source.
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 3066);
        Debug.Log("Started Receiving packets");
        while (bacon)
        {
            if (rs <= 0)
            {
                try
                {

                    // Blocks until a message returns on this socket from a remote host.
                    Byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);

                    string returnData = Encoding.ASCII.GetString(receiveBytes);
                    host.ParseUDP(returnData);
                    /*
                    Debug.Log("This is the message you received " +
                                              returnData.ToString());
                    Debug.Log("This message was sent from " +
                                                RemoteIpEndPoint.Address.ToString() +
                                                " on their port number " +
                                                RemoteIpEndPoint.Port.ToString());
                    */
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.ToString());
                }
                rs = readDelay;
            }
            else
            {
                rs -= 1;
            }
        }
    }
}
