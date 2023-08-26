using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public new string _name;
    public float _cooldownTime;
    public float _activeTime;
    
    public virtual void Activate(GameObject parent)
    {
        
    }
}
