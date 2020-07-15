using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private PlayerData activePlayerData;

    [SerializeField] private int activeIndex;
    [SerializeField] private PlayerData[] playersData;

    public PlayerData ActivePlayerData { get { return activePlayerData; } }
    public PlayerData[] PlayersData { get { return playersData; } }

    public void UpdateType()
    {
        activePlayerData = playersData[activeIndex];
        Debug.Log("Aku sekarang "+ playersData[activeIndex].characterName);
    }

    public void GetNextType()
    {
        activeIndex++;

        if (activeIndex >= playersData.Length) activeIndex = 0;

        UpdateType();
    }
}

[System.Serializable]
public class PlayerData
{
    public enum Type { CHILD = 0, TEEN = 1, ELDER = 2 };

    public Type type;
    public string characterName;
    public float movementSpeed;
    public float jumpPower;
    public int starCollects;
}
