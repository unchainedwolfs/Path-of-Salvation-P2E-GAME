using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("References")]

    [Space(8)]

    public StandardUIRefenence woodUI;
    public StandardUIRefenence stoneUI;
    public StandardUIRefenence standardCUI;
    public StandardUIRefenence premiumCUI;


    public static UIManager Instance;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateAll();
    }


    public void UpdateWoodUI(int currentAmount,  int maxAmount)
    {
        woodUI.currentUI.text = currentAmount.ToString();
        woodUI.maxUI.text = "MAX: "+ maxAmount.ToString();

        woodUI.Slider.maxValue = maxAmount;
        woodUI.Slider.value = currentAmount;
    }

    public void UpdatePremiumCUI(int currentAmount, int maxAmount)
    {
        premiumCUI.currentUI.text = currentAmount.ToString();
        premiumCUI.maxUI.text = "MAX: " + maxAmount.ToString();

        premiumCUI.Slider.maxValue = maxAmount;
        premiumCUI.Slider.value = currentAmount;

    }

    public void UpdateStoneUI(int currentAmount, int maxAmount)
    {
        stoneUI.currentUI.text = currentAmount.ToString();
        stoneUI.maxUI.text = "MAX: " + maxAmount.ToString(); ;

        stoneUI.Slider.maxValue = maxAmount;
        stoneUI.Slider.value = currentAmount;

    }

    public void UpdateStandardCUI(int currentAmount, int maxAmount)
    {
        standardCUI.currentUI.text = currentAmount.ToString();
        standardCUI.maxUI.text = "MAX: " + maxAmount.ToString();

        standardCUI.Slider.maxValue = maxAmount;
        standardCUI.Slider.value = currentAmount;

    }

    void UpdateAll()
    {
        UpdateStoneUI(ResourceManager.Instance.Stone, ResourceManager.Instance.maxStone);
        UpdateWoodUI(ResourceManager.Instance.Wood, ResourceManager.Instance.maxWood);
        UpdateStandardCUI(ResourceManager.Instance.StandardC, ResourceManager.Instance.maxStandardC);
        UpdatePremiumCUI(ResourceManager.Instance.PremiumC, ResourceManager.Instance.maxPremiumC);
    }
}

[System.Serializable]
public class StandardUIRefenence
{
    public Slider Slider;
    public Text maxUI;
    public Text currentUI;
}
