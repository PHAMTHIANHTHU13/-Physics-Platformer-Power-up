using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Powerup", menuName = "Powerup Data")]
public class PowerupData : ScriptableObject
{
   [SerializeField] string powerupType;
   [SerializeField] float valueChange;
   [SerializeField] float Time;

   // Getter methods

   public string GetPowerupType()
    {
        return powerupType;
    }

    public float GetvalueChange()
    {
        return valueChange;
    }

    public float GetTime()
    {
        return Time;
    }
}
