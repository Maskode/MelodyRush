using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

    public static void SetSound(bool value)
    {
        PlayerPrefs.SetString("sound", value.ToString());
    }
    public static bool GetSound()
    {
        return bool.Parse(PlayerPrefs.GetString("sound", "true"));
    }
    public static void SetLevelComplete(string levelName,bool value)
    {
        PlayerPrefs.SetString(levelName, value.ToString());
    }
    public static bool GetLevelComplete(string levelName, int arrayIndex)
    {
        if (arrayIndex < 10)
            levelName = "lvl0" + arrayIndex;
        else
            levelName = "lvl" + arrayIndex;
        return bool.Parse(PlayerPrefs.GetString(levelName, "true"));
    }
}
