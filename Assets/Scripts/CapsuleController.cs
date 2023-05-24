using Unity.XR.CoreUtils;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private GameObject _capsule;
    private Vector3 _cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        _cameraPos = new Vector3(_camera.transform.position.x,_camera.transform.position.y -.3f,_camera.transform.position.z);
        _capsule = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _capsule.transform.position = _cameraPos;
    }
}
