using Unity.XR.CoreUtils;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    private XROrigin _xrOrigin;
    private GameObject _capsule;
    // Start is called before the first frame update
    void Start()
    {
        _xrOrigin = FindObjectOfType<XROrigin>();
        _capsule = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _capsule.transform.rotation = _xrOrigin.transform.rotation;
    }
}
