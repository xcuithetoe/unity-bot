using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class TalonSRXWSInterface : MonoBehaviour {

    public WebSocketInterface ws;
    public int Id;

    // Talon SRX[]
    // <percentOutput
    // <>velocity
    // <>busVoltage
    // <>supplyCurrent
    // <>motorCurrent

    // Talon SRX[]/Analog In
    // <>voltage

    // Talon SRX[]/Encoder
    // <>position
    // <>velocity

    // Talon SRX[]/DutyCycleInput
    // <>position

    public MotorBehavior motor ;
    public TalonSRXWSInterface followerMotorController ;
    public EncoderBehavior encoder ;
    public bool sensorPhase ;


    public float percentOutput = 0.0f ;
    public double velocity = 0.0 ;
    public double busVoltage = 0.0 ;
    public double supplyCurrent = 0.0 ;
    public double motorCurrent = 0.0 ;

    public double analogInVoltage = 0.0 ;

    public double encoderPosition = 0.0 ;
    public double encoderVelocity = 0.0 ;

    private int lastEncoderValue = 0 ;


    public double dutyCycleInputPosition = 0.0 ;

    // sent
    //{"type":"SimDevices","device":"Talon SRX[1]","data":{"<>supplyCurrent":678.9}}
    //{"type": "SimDevices", "device": "Talon SRX[1]", "data": {"<>supplyCurrent": 678.88} }



    //received
    // {"data": {"<>supplyCurrent": 678.88}, "device": "Talon SRX[1]","type": "SimDevices"}



    private void ProcessMain(JToken data) {
        // what is this velocity vieeld and how does it compare to encoder velocity

        // Debug.Log("main message received") ;
        // if ( data.ToString().Contains("<percent")) {
        //     Debug.Log($"Message contains percentOutput {data.ToString()}") ;
        // }


        if ( data.ToString().Contains("velocity")) {
            Debug.Log($"data is {data.ToString()} ") ;
        }
        if (data.SelectToken("<percentOutput") != null) {
            percentOutput = data.Value<float>("<percentOutput");
            //Debug.Log($"percentOutput is {percentOutput}");
        }

        if (data.SelectToken("<>supplyCurrent") != null) {

            //supplyCurrent = data.Value<float>("<>supplyCurrent");
        }
        if (data.SelectToken("<>busVoltage") != null) {
            //busVoltage = data.Value<float>("<>busVoltage");
        }
        if (data.SelectToken("<>motorCurrent") != null) {
            motorCurrent = data.Value<float>("<>motorCurrent");
        }
    }

    private void ProcessDutyCycleInput(JToken data) {
        dutyCycleInputPosition = data.Value<double>("<>position");
    }

    private void ProcessEncoder(JToken data) {
        if (data.SelectToken("<>position") != null ) {
            //encoderPosition = data.Value<double>("<>position");
        }
        if (data.SelectToken("<>velocity") != null) {
            //encoderVelocity = data.Value<double>("<>velocity");
        }
    }

    private void ProcessAnalogIn( JToken data) {
        if (data.SelectToken("<>voltage") != null) {
            analogInVoltage = data.Value<double>("<>voltage");
        }
    }


    // Start is called before the first frame update
    void Start() {
        if (ws != null) {
            // ws.RegisterPort("SimDevices", $"Talon SRX[{Id}]"  , ProcessMain);
            // ws.RegisterPort("SimDevices", $"Talon SRX[{Id}]/DutyCycleInput", ProcessDutyCycleInput);
            // ws.RegisterPort("SimDevices", $"Talon SRX[{Id}]/Analog In", ProcessAnalogIn);
            // ws.RegisterPort("SimDevices", $"Talon SRX[{Id}]/Encoder", ProcessEncoder);

            ws.RegisterPort("SimDevice", $"Talon SRX[{Id}]", ProcessMain);
            ws.RegisterPort("SimDevice", $"Talon SRX[{Id}]/DutyCycleInput", ProcessDutyCycleInput);
            ws.RegisterPort("SimDevice", $"Talon SRX[{Id}]/Analog In", ProcessAnalogIn);
            ws.RegisterPort("SimDevice", $"Talon SRX[{Id}]/Encoder", ProcessEncoder);
        }
    }



    // Update is called once per frame
    void Update() {
        if (encoder) {
            // compute velocity.Position already figured by encoder.
            encoderPosition = encoder.Counts;
            // Compute velocity as change in position. Delta ticks /time in seconds / 10 to get time per 100 mSec
            //encoderVelocity = ((encoder.Counts - lastEncoderValue)) / (Time.deltaTime) / 10.0f;
        }
//        supplyCurrent = 678.9;
//        supplyCurrent = Mathf.Abs((float)percentOutput) * 30 * Random.Range(0.95f, 1.05f);
//        busVoltage = 12.0 - (percentOutput * percentOutput) * 0.75 * Random.Range(0.95f, 1.05f);
        // // Debug.Log($"percentOutput is {percentOutput}, busVoltage is {busVoltage}") ;

        // Send encoder data
        Newtonsoft.Json.Linq.JObject jo = new JObject();
//        jo.Add(new JProperty("type", "SimDevices"));
        jo.Add(new JProperty("type", "SimDevice"));
        jo.Add(new JProperty("device", $"Talon SRX[{Id}]/Encoder"));
        Newtonsoft.Json.Linq.JObject dataObject = new JObject();
        //dataObject.Add(new JProperty("<>velocity", encoderVelocity));
        dataObject.Add(new JProperty("<>position", encoderPosition));
        jo.Add("data", dataObject);
        string message = JsonConvert.SerializeObject(jo);
        ws.Send(message);
        Debug.Log($"talon encoder data sent is {message}");

        jo = new JObject();
//        jo.Add(new JProperty("type", "SimDevices"));
        jo.Add(new JProperty("type", "SimDevice"));
        jo.Add(new JProperty("device", $"Talon SRX[{Id}]"));
        dataObject = new JObject();
        dataObject.Add(new JProperty("<>busVoltage", busVoltage));
        //dataObject.Add(new JProperty("<>supplyCurrent", supplyCurrent));
        // dataObject.Add(new JProperty("<>motorCurrent", velocity));
        jo.Add("data", dataObject);
        message = JsonConvert.SerializeObject(jo);
//        ws.Send(message);
//        Debug.Log($"talon data sent is {message}") ;
    }
}
