using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TranslationScript : MonoBehaviour
{
    public GameObject canvasTranslation;
    public GameObject cube;
    public TMP_InputField inputX;
    public TMP_InputField inputY;
    public TMP_InputField inputZ;
    public Button applyButton;
    public Button translationButton;

    void Start()
    {
        canvasTranslation.SetActive(false);
        translationButton.onClick.AddListener(ShowTranslationUI);
        applyButton.onClick.AddListener(ApplyTranslation);
    }
    void ShowTranslationUI()
    {
        canvasTranslation.SetActive(true);
    }
    void ApplyTranslation()
    {
        // Convertir les valeurs entrées en float
        float x = float.Parse(inputX.text);
        float y = float.Parse(inputY.text);
        float z = float.Parse(inputZ.text);

        // Appliquer la translation
        cube.transform.position += new Vector3(x, y, z);
        canvasTranslation.SetActive(false);
    }
}
 
