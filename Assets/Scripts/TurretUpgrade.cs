using UnityEngine;
using UnityEngine.UI;

public class TurretUpgrade : MonoBehaviour
{
    [SerializeField] private TileCheck target;
    [SerializeField] private GameObject UI;

    [SerializeField] private Button _sell;
    [SerializeField] private Button _upgrade;

    void Awake()
    {
        _sell.onClick.AddListener(Sell);
        _upgrade.onClick.AddListener(Upgrade);
    }

    public void SetTarget(TileCheck _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition() + new Vector3(0, 0.3f, 0);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void Sell()
    {
        //Add $ and destroy tower
        PlayerStats.Instance.AddMoney(5);
    }

    void Upgrade()
    {
        //Upgrade cost
        //Deduct from money PlayerStats.Instance.DeductMoeny()
        //Access the right turret and tell it, it has been upgraded
    }
}
