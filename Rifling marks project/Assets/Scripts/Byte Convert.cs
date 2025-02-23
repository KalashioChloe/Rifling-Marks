using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByteConvert : MonoBehaviour
{
    public List<byte> StringToByte(string str)
    {
        
        List<Byte> bytes = new();
        for (int i = 0; i < str.Length; i++)
        {
            //Debug.Log(str[i].ToString());
            Byte theByte = Convert.ToByte(str[i]);
            bytes.Add(theByte);
            //Debug.Log(theByte.ToString());
            //Debug.Log("Converting String to Byte: " + (i+1).ToString() + " of " + str.Length.ToString());
        }
        return bytes;
    }
}
