using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrollbar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Monster;
    public Camera CM;
    private void Update()
    {
        float monsterSize = Monster.GetComponent<SpriteRenderer>().size.y * 2;
        transform.position = CM.WorldToScreenPoint(new Vector2(Monster.transform.position.x, Monster.transform.position.y + monsterSize));

    }
}
