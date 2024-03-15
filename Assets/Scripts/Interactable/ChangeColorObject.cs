using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorObject : Interactable
{
    MeshRenderer mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    protected override void Interact()
    {
        if(mesh != null)
            mesh.material.color = mesh.material.color == Color.red ? Color.blue : Color.red;
    }
}
