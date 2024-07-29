using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EASTEREGGLIGHT : MonoBehaviour
{
    // Start is called before the first frame update
    float duration = 0.5f;
    Color color0 = Color.red;
    Color color1 = Color.yellow;
    Color color2 = Color.magenta;
    Color color3 = Color.green;
    Color color4 = Color.white;

    Light lt;
    int i = 0;

    void Start()
    {
        lt = GetComponent<Light>();
        InvokeRepeating("LightChange", 0f, 0.3f);
    }

    private void LightChange() {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        switch(i) {
            case 0: lt.color = Color.Lerp(color0, color1, t); break;
            case 1: lt.color = Color.Lerp(color1, color2, t); break;
            case 2: lt.color = Color.Lerp(color2, color3, t); break;
            case 3: lt.color = Color.Lerp(color3, color4, t); break;
            case 4: lt.color = Color.Lerp(color4, color1, t); break;
        }
        if (i !>= 4 ) { i++; } else { i = 0;};
    }
}
