using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC fiels archive")]
public class NPCScriptableObject : ScriptableObject
{
    public string name;
    [TextArea(3,15)]
    public string[] dialogue;
}
