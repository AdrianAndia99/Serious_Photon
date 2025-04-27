using UnityEngine;

public class InstantiateExample : MonoBehaviour
{
    [SerializeField] private GameObject prefabToInstantiate;

    public void Awake()
    {
        MasterManager.NetworkInstantiate(prefabToInstantiate, transform.position, Quaternion.identity);
    }
}
