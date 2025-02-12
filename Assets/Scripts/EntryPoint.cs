using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private ConfigManager _configManager;
    [SerializeField] private MarketObjectSpawner _marketObjectSpawner;
    [SerializeField] private DefaultMarketConfig _marketConfig;

    public ObjectWithProductView view;

    public void Awake()
    {
        ServiceLocator.RegisterService<ConfigManager>(_configManager);
    }

    public void Start()
    {
        // var model = new MarketObjectWithProduct(MarketObjectType.Freezer, 1);
        // var presenter = new ObjectWithProductPresenter(model, view);
        // model.AddProduct(4, 4f);
        //view.AddingProductStarted(4f);
        _configManager.SetMarketConfig(_marketConfig);
        _marketObjectSpawner.SpawnMarket();
    }
}
