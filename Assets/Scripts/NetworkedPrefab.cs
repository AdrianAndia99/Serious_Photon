using UnityEngine;


[System.Serializable]
public class NetworkedPrefab : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public string Path;

    public NetworkedPrefab(GameObject obj, string path)
    {
        prefabToInstantiate = obj;
        Path = path;
    }

    private string ReturnPrefabPathModified(string path)
    {
        int extensionLenght = System.IO.Path.GetExtension(path).Length;
        int additionalLenght = 10;
        int startIndex = path.ToLower().IndexOf("Prefabs");

        if (startIndex == -1)
            return string.Empty;
        else
            return path.Substring(startIndex + additionalLenght, path.Length - (additionalLenght + startIndex - extensionLenght));
    }
}