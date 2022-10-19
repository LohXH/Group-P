using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S : MonoBehaviour
{
    public static int n = 8;
    public GameObject D;
    public static GameObject[,] g = new GameObject[n, n];

    void Start()
    {
        Vector2 cs = transform.gameObject.GetComponent<RectTransform>().sizeDelta, size = D.GetComponent<RectTransform>().sizeDelta;
        cs.x /= 2;
        cs.y /= 2;
        float left = (cs.x - size.x) * -1, top = (cs.y - size.y);
        Color[] colors = new Color[] { Color.white, Color.black };
        Image drt = D.GetComponent<Image>();
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                colors[0] = Color.black;
                colors[1] = Color.white;
            }
            else
            {
                colors[0] = Color.white;
                colors[1] = Color.black;
            }
            for (int j = 0; j < n; j++)
            {
                drt.color = colors[(((j % 2) == 0) ? 0 : 1)];
                g[i, j] = Instantiate(D);
                g[i, j].transform.SetParent(transform.Find("Panel1"));
                g[i, j].transform.localPosition = new Vector3(left, top);
                g[i, j].transform.name = i + "&" + j;
                left += size.x;
            }
            left = (cs.x - size.x) * -1;
            top -= size.y;
        }
    }
}
