using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static T Choice<T>(params T[] choices) => choices[Random.Range(0, choices.Length)];
    public static T Choice<T>(List<T> choices) => choices[Random.Range(0, choices.Count)];
    public static T Choice<T>(List<T> choices, params T[] excepts)
    {
        choices = new List<T>(choices);
        List<T> exceptVals = new List<T>(excepts);
        T choice = Choice(choices);
        while (exceptVals.Contains(choice))
        {
            choices.Remove(choice);
            choice = Choice(choices);
        }
        return choice;
    }
    public static int RandomSign() => RandomBool() ? -1 : 1;
    public static bool RandomBool(float truePossibility = 0.5f) => Random.value <= truePossibility;
    public static LayerMask LayerOf(string layerName) => 1 << LayerMask.NameToLayer(layerName);
    public static bool IsInRange(float value, Vector2 range, bool includeMin = true, bool includeMax = true)
    {
        if (includeMin && includeMax)
        {
            return range.x <= value && value <= range.y;
        }
        if (includeMin)
        {
            return range.x <= value && value < range.y;
        }
        if (includeMax)
        {
            return range.x <= value && value <= range.y;
        }
        return range.x < value && value < range.y;
    }
    public class Enum
    {
        public static E Choice<E>() where E : System.Enum => Util.Choice(ToList<E>());
        public static E Choice<E>(params E[] excepts) where E : System.Enum => Util.Choice(ToList<E>(), excepts);
        public static List<E> ToList<E>() => System.Enum.GetValues(typeof(E)).Cast<E>().ToList();
        public static int EnumSize<E>() => System.Enum.GetNames(typeof(E)).Length;
    }
}
