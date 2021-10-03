using UnityEngine;

public static class ScaleToVolumeConverter
{
    public static float VolumeFromXScaleValue(float xScaleValue)
    {
        if (xScaleValue <= 0.2f)
        {
            return 2f;
        }
        else if (xScaleValue <= 0.5f)
        {
            return 3.5f;
        }
        else if (xScaleValue <= 0.8f)
        {
            return 5f;
        }
        else if (xScaleValue <= 1.1f)
        {
            return 6.5f;
        }
        else if (xScaleValue <= 1.4f)
        {
            return 8f;
        }
        else if (xScaleValue <= 1.7f)
        {
            return 9.5f;
        }
        else if (xScaleValue <= 2f)
        {
            return 11f;
        }
        else if (xScaleValue <= 2.3f)
        {
            return 12.5f;
        }

        return 0;
    }
}
