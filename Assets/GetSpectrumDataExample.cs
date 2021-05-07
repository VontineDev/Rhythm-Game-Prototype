using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpectrumData
{
    public List<float> listSpectrum = new List<float>();
    public float instantaneousEnergy;
    public float averageEnergy;
}

public class GetSpectrumDataExample : MonoBehaviour
{

    AudioSource audioSource;
    public float[] spectrum;
    public float[] maxSpectrum;
    public Dictionary<int, SpectrumData> dicSpectrumData = new Dictionary<int, SpectrumData>();


    public Action SpectrumOperate;

    public static GetSpectrumDataExample Instance
    {
        get;
        set;
    }
    void Awake()
    {
        spectrum = new float[64];
        maxSpectrum = new float[64];
        if (Instance == null)
        {
            Instance = this;
        }

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        int maxSp = spectrum.Length / 4;
        int sp = 0;
        while (sp < maxSp)
        {
            dicSpectrumData.Add(sp, new SpectrumData());
            sp++;
        }


    }

    void Update()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        //audioSource.GetOutputData(spectrum, 0);

        int i = 0;
        while (i < spectrum.Length)
        {
            if (spectrum[i] > maxSpectrum[i])
            {
                maxSpectrum[i] = spectrum[i];
            }
            i++;
        }

        //for (int j = 0; j < 64; j++)
        //{
        //    dicSpectrumData[j / 4].listSpectrum.Add(spectrum[i]);
        //}

        //int i = 1;
        //while (i < spectrum.Length - 1)
        //{
        //    Debug.Log("In While");
        //    Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
        //    Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
        //    i++;
        //}


    }
}
