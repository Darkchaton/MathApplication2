using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScalingScript : MonoBehaviour
{
    public GameObject canvasXYZ;
    public GameObject cube;
    public TMP_InputField inputX;
    public TMP_InputField inputY;
    public TMP_InputField inputZ;
    public Button applyButton;
    public Button scalingButton;

    void Start()
    {
        canvasXYZ.SetActive(false);
        scalingButton.onClick.AddListener(ShowScalingUI);
        applyButton.onClick.AddListener(ApplyScaling);
    }
     
    void ShowScalingUI()
    {
        canvasXYZ.SetActive(true);
    }

    void ApplyScaling()
    {
        float x = float.Parse(inputX.text);
        float y = float.Parse(inputY.text);
        float z = float.Parse(inputZ.text);

        cube.transform.localScale = new Vector3(x, y, z); //Relativement le même code, mais ici on appelle localScale pour rescaler au lieu de translate
        canvasXYZ.SetActive(false);
    } 
}
