using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : ScriptableObjectcSingleton<MasterManager>
{
    [SerializeField] private GameSettings _gameSettings;
    public static GameSettings GameSettings { get { return Instance._gameSettings; } }

}
