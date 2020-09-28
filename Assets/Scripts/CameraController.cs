using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private Transform cameraController;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = GetComponent<Transform>();
        slider.onValueChanged.AddListener(CameraRotation);
    }

    private void CameraRotation(float value)
    {
        cameraController.rotation = new Quaternion(value/130f, 
                                                   cameraController.rotation.y, 
                                                   cameraController.rotation.z, 
                                                   cameraController.rotation.w);
    }
}
