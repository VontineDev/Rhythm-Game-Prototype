using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InstantiateCube : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    public GameObject sampleTextPrefab;
    GameObject[] sampleCube;
    GameObject[] sampleText;

    public float maxSacle;

    private GetSpectrumDataExample getSpectrum;
    // Start is called before the first frame update
    void Start()
    {
        getSpectrum = GetSpectrumDataExample.Instance;

        var length = getSpectrum.spectrum.Length;

        sampleCube = new GameObject[length];
        sampleText = new GameObject[length];

        for (int i = 0; i < length; i++)
        {
            GameObject instanceSampleCube = Instantiate(sampleCubePrefab);
            instanceSampleCube.transform.position = this.transform.position;
            instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, (360f / length) * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 100;
            sampleCube[i] = instanceSampleCube;

            //GameObject instanceSampleText = Instantiate(sampleTextPrefab);
            //instanceSampleText.transform.position = this.transform.position;
            //instanceSampleText.transform.SetParent(this.transform);
            //instanceSampleText.name = "SampleText" + i;
            //this.transform.eulerAngles = new Vector3(0, -1.40625f * i, 0);
            //instanceSampleText.transform.position = Vector3.forward * 95;
            //sampleText[i] = instanceSampleText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < getSpectrum.spectrum.Length; i++)
        {
            if (sampleCube != null)
            {
                sampleCube[i].transform.localScale = new Vector3(10, (getSpectrum.spectrum[i] * maxSacle) + 2, 10);
                //sampleText[i].transform.position
                //sampleText[i].GetComponent<TextMeshPro>().text = getSpectrum.spectrum[i].ToString();
            }
        }
    }
}
