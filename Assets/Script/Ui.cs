using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public Texture2D maouseCurso;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(maouseCurso, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
