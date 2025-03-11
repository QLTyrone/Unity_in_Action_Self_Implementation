using UnityEngine;

public class MouthLook : MonoBehaviour
{
    public enum RotationAxes {
        MouthXAndY = 0,
        MouthX = 1,
        MouthY = 2
    }
    public RotationAxes axes = RotationAxes.MouthXAndY;
    public float sensitivityHor = 9.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouthX) {
            transform.Rotate(0, Input.GetAxis("Mouth X")*sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouthY) {
            // vertical rotation here
        }
        else {
            // both horizontal and vertical rotation here
        }
    }
}
