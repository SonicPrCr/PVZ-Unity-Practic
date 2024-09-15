using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColorManager : MonoBehaviour
{
    private Color temp;
    public List<Color> colors = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color ColorNanager()
    {

        if (colors.Count > 0)
        {
            int col = Random.Range(0, colors.Count);
            temp = colors[col];
            colors.RemoveAt(col);
            
        }
        

        return temp;
    }
}
