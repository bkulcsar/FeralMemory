using UnityEngine;
using System.Collections;

public class LevelStructure
{
    public int CurrentLevel { get; private set; }
    public int AnimalsToOrderCount { get; private set; }
    public float FloatingSec { get; private set; }
    public float WaitSec { get; private set; }
    public ThemeEnum Theme { get; private set; }
    
       
    public LevelStructure()
    {
        CurrentLevel = ApplicationModel.CurrentLevel;
        
        switch (CurrentLevel)
        {
//Farm
            case 1:
                AnimalsToOrderCount = 3;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Farm;
                break;
            case 2:
                AnimalsToOrderCount = 3;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Farm;
                break;
            case 3:
                AnimalsToOrderCount = 3;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Farm;
                break;
            case 4:
                AnimalsToOrderCount = 4;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Farm;
                break;
            case 5:
                AnimalsToOrderCount = 4;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Farm;
                break;
            case 6:
                AnimalsToOrderCount = 4;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Farm;
                break;
//Forest
            case 7:
                AnimalsToOrderCount = 5;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Forest;
                break;
            case 8:
                AnimalsToOrderCount = 5;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Forest;
                break;
            case 9:
                AnimalsToOrderCount = 5;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Forest;
                break;
            case 10:
                AnimalsToOrderCount = 6;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Forest;
                break;
            case 11:
                AnimalsToOrderCount = 6;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Forest;
                break;
            case 12:
                AnimalsToOrderCount = 6;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Forest;
                break;
//Water
            case 13:
                AnimalsToOrderCount = 7;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Water;
                break;
            case 14:
                AnimalsToOrderCount = 7;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Water;
                break;
            case 15:
                AnimalsToOrderCount = 7;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Water;
                break;
            case 16:
                AnimalsToOrderCount = 8;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Water;
                break;
            case 17:
                AnimalsToOrderCount = 8;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Water;
                break;
            case 18:
                AnimalsToOrderCount = 8;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Water;
                break;
//Mountain
            case 19:
                AnimalsToOrderCount = 9;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Mountain;
                break;
            case 20:
                AnimalsToOrderCount = 9;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Mountain;
                break;
            case 21:
                AnimalsToOrderCount = 9;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Mountain;
                break;
            case 22:
                AnimalsToOrderCount = 10;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Mountain;
                break;
            case 23:
                AnimalsToOrderCount = 10;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Mountain;
                break;
            case 24:
                AnimalsToOrderCount = 10;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Mountain;
                break;
//Safari
            case 25:
                AnimalsToOrderCount = 11;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Safari;
                break;
            case 26:
                AnimalsToOrderCount = 11;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Safari;
                break;
            case 27:
                AnimalsToOrderCount = 11;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Safari;
                break;
            case 28:
                AnimalsToOrderCount = 12;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Safari;
                break;
            case 29:
                AnimalsToOrderCount = 12;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Safari;
                break;
            case 30:
                AnimalsToOrderCount = 12;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Safari;
                break;
//Jungle
            case 31:
                AnimalsToOrderCount = 13;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Jungle;
                break;
            case 32:
                AnimalsToOrderCount = 13;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Jungle;
                break;
            case 33:
                AnimalsToOrderCount = 13;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Jungle;
                break;
            case 34:
                AnimalsToOrderCount = 14;
                FloatingSec = FloatSecLvl.Lvl1;
                WaitSec = WaitSecLvl.Lvl1;
                Theme = ThemeEnum.Jungle;
                break;
            case 35:
                AnimalsToOrderCount = 14;
                FloatingSec = FloatSecLvl.Lvl2;
                WaitSec = WaitSecLvl.Lvl2;
                Theme = ThemeEnum.Jungle;
                break;
            case 36:
                AnimalsToOrderCount = 14;
                FloatingSec = FloatSecLvl.Lvl3;
                WaitSec = WaitSecLvl.Lvl3;
                Theme = ThemeEnum.Jungle;
                break;
            default:
                break;
        }
    }

    private static class FloatSecLvl
    {
        public const float Lvl1 = 1;
        public const float Lvl2 = 0.7F;
        public const float Lvl3 = 0.4F;
    }

    private static class WaitSecLvl
    {
        public const float Lvl1 = 0.5F;
        public const float Lvl2 = 0.3F;
        public const float Lvl3 = 0.2F;
    }
}
public enum ThemeEnum
{
    Jungle,
    Forest,
    Farm,
    Water,
    Safari,
    Mountain,
}