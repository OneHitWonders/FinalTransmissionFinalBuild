using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : MonoBehaviour {

   
    public string SurvivorName;
    public string SurvivorAge;
    public int SurvivorID;

    [HideInInspector]
    public SurvivorStats Stats;
    public List<Trait> SurvivorTraits = new List<Trait>();


    public float Health = 100;
    public float Stamina = 100;
    public float Strength = 100;
    public float Accuracy = 100;
    public float FoodConsumptionAmount = 10;



    // Use this for initialization
    void Awake()
    {
        //Stats.Traits = SurvivorTraits;
        NewSurvivorGenerated();
    }
    
    //Used to determine stats and traits

    public void NewSurvivorGenerated()
    {
        double test = Random.Range(0, 1);

        if (test > 0.5)
        {
            Debug.Log("Has traits"); // place trait generation here
        }

        //Stats.GenerateStats();
    }

}//end class
public class SurvivorStats : MonoBehaviour
{
    public float Health = 100;
    public float Stamina = 100;
    public float Strength = 100;
    public float Accuracy = 100;
    public float FoodConsumptionAmount = 10;

    public List<Trait> Traits = new List<Trait>();

    public void GenerateStats()
    {
        foreach (Trait trait in Traits)
        {
            string tempName = trait.traitname.ToString();
            switch (tempName)
            {
                case "Health":
                    Health = CalculateStat(Health, trait);
                    break;

                case "Stamina":
                    Stamina = CalculateStat(Stamina, trait);
                    break;

                case "Strength":
                    Strength = CalculateStat(Strength, trait);
                    break;

                case "Accuracy":
                    Accuracy = CalculateStat(Accuracy, trait);
                    break;

                case "FoodConsumptionAmount":
                    FoodConsumptionAmount = CalculateStat(FoodConsumptionAmount, trait);
                    break;


            }

        }

    }

    public float CalculateStat(float statToChange, Trait checkTrait)
    {
        float tempFloat = statToChange - checkTrait.traitEffectAmount;


        return tempFloat;
    }

}// end SurvivorStats

public class Trait : MonoBehaviour
{
    public string traitName;
    public float traitEffectAmount;

    public enum TraitName { Gluttonous, Blind, Weak };
    public enum StatName { Health, Stamina, Accuracy, Strength, FoodConsumptionAmount };

    public TraitName traitname;
    public StatName statName;

    //private string healthName = "Health";
    //private string staminaName = "Stamina";
    //private string accuracyName = "Accuracy";
    //private string strengthName = "Strength";
    //private string consumptionName = "FoodConsumptionAmount";
    public void EffectedStat()
    {
        string statToAlter = traitName.ToString();
    }

    public Trait(TraitName name)
    {

    }


}
