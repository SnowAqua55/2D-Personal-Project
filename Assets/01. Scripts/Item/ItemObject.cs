using UnityEngine;

public interface IGetItem
{
    public string GetItemInfo();
    public void OnInteraction();
}

public class ItemObject : MonoBehaviour, IGetItem
{
    public ItemData data;

    public string GetItemInfo()
    {
        string str = $"{data.displayName}\n{data.displayDesc}";
        return "";
    }

    public void OnInteraction()
    {
        // CharacterManager.Instance.Player.itemData = data;
        // CharacterManager.Instance.Player.GetItem?.Invoke();
    }
    
    
}