using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private CinemachineComposer composer;

    [SerializeField]
    private float sensitivity;

    void Start () {

        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();

	}
	
	void Update () {

        float vertical = Input.GetAxis("Mouse Y") * sensitivity;
        composer.m_TrackedObjectOffset.y += vertical;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, 0, 8);
		
	}
}
