using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransformationScript : MonoBehaviour
{
    public GameObject canvasTransformation;  // Canvas qui contient les InputFields pour les transformations
    public GameObject cube;                  // Référence au cube à modifier
    public TMP_InputField inputX;            // Input pour les valeurs des transformations sur l'axe X
    public TMP_InputField inputY;            // Input pour les valeurs des transformations sur l'axe Y
    public TMP_InputField inputZ;            // Input pour les valeurs des transformations sur l'axe Z
    public Button applyButton;               // Bouton pour appliquer la transformation
    public Button translationButton;         // Bouton pour activer la translation
    public Button scalingButton;             // Bouton pour activer la mise à l'échelle
    public Button rotationButton;            // Bouton pour activer la rotation
    public Button reflectionButton;          // Bouton pour activer la réflexion
    public Button projectionButton;          // Bouton pour activer la projection


    private enum TransformationType
    {
        Translation,
        Scaling,
        Rotation,
        Reflection,
        Projection
    }

    private TransformationType currentTransformation;

    void Start()
    {
        canvasTransformation.SetActive(false);

        translationButton.onClick.AddListener(() => SetTransformation(TransformationType.Translation));
        scalingButton.onClick.AddListener(() => SetTransformation(TransformationType.Scaling));
        rotationButton.onClick.AddListener(() => SetTransformation(TransformationType.Rotation));
        reflectionButton.onClick.AddListener(() => SetTransformation(TransformationType.Reflection));
        projectionButton.onClick.AddListener(() => SetTransformation(TransformationType.Projection));

        applyButton.onClick.AddListener(ApplyTransformation);
    }

    void SetTransformation(TransformationType transformationType)
    {
        currentTransformation = transformationType;
        canvasTransformation.SetActive(true);
    }

    void ApplyTransformation()
    {
        float x = float.Parse(inputX.text);
        float y = float.Parse(inputY.text);
        float z = float.Parse(inputZ.text);

        if (Mathf.Abs(x) > 50 || Mathf.Abs(y) > 50 || Mathf.Abs(z) > 50)
        {
            Debug.Log("Les valeurs ne doivent pas dépasser 50 ou -50.");
            return;
        }

        switch (currentTransformation)
        {
            case TransformationType.Translation:
                ApplyTranslation(x, y, z);
                break;
            case TransformationType.Scaling:
                ApplyScaling(x, y, z);
                break;
            case TransformationType.Rotation:
                ApplyRotation(x, y, z);
                break;
            case TransformationType.Reflection:
                ApplyReflection(x, y, z);
                break;
            case TransformationType.Projection:
                ApplyProjection(x, y, z);
                break;
        }

        canvasTransformation.SetActive(false);
    }

    // Méthode pour appliquer la translation
    void ApplyTranslation(float x, float y, float z)
    {
        cube.transform.position += new Vector3(x, y, z); 
    }

    // Méthode pour appliquer la mise à l'échelle
    void ApplyScaling(float x, float y, float z)
    {
        cube.transform.localScale = new Vector3(x, y, z);
    }

    // Méthode pour appliquer la rotation
    void ApplyRotation(float x, float y, float z)
    {
        cube.transform.Rotate(new Vector3(x, y, z));
    }

    // Méthode pour appliquer la réflexion
    void ApplyReflection(float x, float y, float z)
    { 
        Vector3 currentPosition = cube.transform.position; 

        if (x != 0)
        {
            currentPosition.x = -currentPosition.x;
            Debug.Log($"Reflected on X: {currentPosition.x}");
        }
        if (y != 0)
        {
            currentPosition.y = -currentPosition.y;
            Debug.Log($"Reflected on Y: {currentPosition.y}");
        }
        if (z != 0)
        {
            currentPosition.z = -currentPosition.z;
            Debug.Log($"Reflected on Z: {currentPosition.z}");
        } 

        cube.transform.position = currentPosition;
        Debug.Log($"New Cube Position: {currentPosition}");
    }

    // Méthode pour appliquer la projection
    void ApplyProjection(float x, float y, float z)
    {
        // Projeter le cube sur un plan (par exemple, projeter sur XY)
        cube.transform.position = new Vector3(x, y, 0);  // Projection sur le plan XY (z = 0)
    }
}
