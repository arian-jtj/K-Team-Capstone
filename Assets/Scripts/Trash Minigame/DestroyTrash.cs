using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrash : MonoBehaviour
{
    public CheckTrash checkTrash;

    // Start is called before the first frame update
    void Start()
    {
        checkTrash = GameObject.FindGameObjectWithTag("CheckTrash").GetComponent<CheckTrash>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        checkTrash.addCounter();
        Destroy(gameObject);
    }
}
