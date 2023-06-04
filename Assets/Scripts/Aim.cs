using Cinemachine;
using UnityEngine;

public class Aim : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera aimVCam;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            aimVCam.gameObject.SetActive(true);
        }
        else
        {
            aimVCam.gameObject.SetActive(false);
        }
    }
}
