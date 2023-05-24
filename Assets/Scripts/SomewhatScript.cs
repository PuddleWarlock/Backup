using UnityEngine;

public class SomewhatScript : MonoBehaviour
{
    [SerializeField] private Transform triggerTransform;

    private void Update()
    {
        var rotation = triggerTransform.rotation;
        transform.rotation = Quaternion.Euler(new Vector3(0, rotation.eulerAngles.y, 0));
    }
}