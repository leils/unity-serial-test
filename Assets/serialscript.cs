using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class serialscript : MonoBehaviour
{

  public int incomingData;
  SerialPort sp = new SerialPort("/dev/tty.usbmodem141201", 9600);
  public GameObject cube;
  private Vector3 smallScale, bigScale;
    // Start is called before the first frame update
    void Start()
    {
      cube = GameObject.Find("Cube");
      sp.Open();
      sp.ReadTimeout = 1;
      smallScale = new Vector3(1, 1, 1);
      bigScale = new Vector3(2, 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
      try {
        incomingData = int.Parse(sp.ReadLine());
        Debug.Log(incomingData);

        int scale = incomingData / 100;

        cube.transform.localScale = bigScale * scale;

        // if (incomingData >= 50) {
        //   cube.transform.localScale = bigScale;
        // } else {
        //   cube.transform.localScale = smallScale;
        // }
      }
      catch (System.Exception)
      {

      }
    }
}
