using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [Header("Resources")]

    [Space(8)]

    public int maxWood;
    int wood = 0;

    public int maxStone;
    int stone = 0;

    public int maxPremiumC;
    int premiumC = 0;

    public int maxStandardC;
    int standardC = 0;

    public static ResourceManager Instance;

    public bool debugBool = false;

    public int Wood { get => wood; set => wood = value; }
    public int Stone { get => stone; set => stone = value; }
    public int PremiumC { get => premiumC; set => premiumC = value; }
    public int StandardC { get => standardC; set => standardC = value; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (debugBool)
        {
            PrintCurrentResources();
        }
    }

    public bool AddWood(int amount)
    {

        if ((wood + amount) <= maxWood)
        {
            wood += amount;
            UIManager.Instance.UpdateWoodUI(wood, maxWood);
            return true;
        }
        else
        {
            return false;
        }


    }

    public bool AddStone(int amount)
    {
        if ((stone + amount) <= maxStone)
        {
            stone += amount;
            UIManager.Instance.UpdateStoneUI(stone, maxStone);
            return true;
        }
        else
        {
            return false;
        }
    }
       

    public bool AddPremiumC(int amount)
    {
        if ((premiumC + amount) <= maxPremiumC)
        {
            premiumC += amount;
            UIManager.Instance.UpdatePremiumCUI(premiumC, maxPremiumC);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddStandardC(int amount)
    {
        if ((standardC + amount) <= maxStandardC)
        {
            standardC += amount;
            UIManager.Instance.UpdateStandardCUI(standardC, maxPremiumC);
            return true;
        }
        else
        {
            return false;
        } 
    }

    void PrintCurrentResources()
    {
        Debug.Log(wood);
        Debug.Log(stone);
        Debug.Log(standardC);
        Debug.Log(premiumC);
    }

}
