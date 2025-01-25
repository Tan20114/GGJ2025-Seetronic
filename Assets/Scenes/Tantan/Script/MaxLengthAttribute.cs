using UnityEngine;

public class MaxLengthAttribute : PropertyAttribute
{
    public int maxLength;

    public MaxLengthAttribute(int maxLength)
    {
        this.maxLength = maxLength;
    }
}
