using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoJawSync : MonoBehaviour
{

    public AudioSource AudioSource;
    public GameObject jaw;
    [Range(1, 50)]
    public float JawSensitivity;
    public float ClosedJawMax;
    public float OpenJawMax;
    float loud;
    float lastLoud;
    float smoothedLoudness;
    float clampedJawFloat;
    [Header("For debugging")]
    public Quaternion LiveJawRotationOutput;
    [Space]
    [Header("Fires an event when talking starts")]
    public UnityEvent FireOnStartedTalking;

    void Update()
    {     
            SyncUpdate();
    }

    public void SyncUpdate()
    {
        if (AudioSource == null)
        {
            lastLoud = 0f;
            return;
        }

        if (AudioSource.isPlaying)
        {
            ProcessAudio();
        }
        else
        {
            lastLoud = 0f;
        }
    }

    void ProcessAudio()
    {
        loud = GetAveragedVolume() * JawSensitivity;

        if (loud >= 0.91f && lastLoud <= 0.9f)
        {
            FireOnStartedTalking.Invoke();
        }

        smoothedLoudness = lowPassFilter(loud, ref smoothedLoudness, 0.8f, false);

        Vector3 NewJawRotationAsEuler = new Vector3(DoFloatRemap(), 0, 0);
        //LiveJawRotationOutput = Quaternion.Euler(NewJawRotationAsEuler);

        //Debug.Log("w = " + LiveJawRotationOutput.w);
        //Debug.Log("x = " + LiveJawRotationOutput.x);
        //Debug.Log("y = " + LiveJawRotationOutput.y);
        //Debug.Log("z = " + LiveJawRotationOutput.z);

        jaw.transform.localEulerAngles = NewJawRotationAsEuler;
        lastLoud = loud;
    }

    float DoFloatRemap()
    {
        return map(smoothedLoudness, 0, 4, ClosedJawMax, OpenJawMax);
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        AudioSource.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

    float lowPassFilter(float targetValue, ref float intermediateValueBuf, float factor, bool init)
    {

        float intermediateValue;

        //intermediateValue needs to be initialized at the first usage.
        if (init)
        {
            intermediateValueBuf = targetValue;
        }

        intermediateValue = (targetValue * factor) + (intermediateValueBuf * (1.0f - factor));


        intermediateValueBuf = intermediateValue;

        return intermediateValue;
    }
}