using UnityEngine;

public class Example : MonoBehaviour
{
    [ForceInterface(typeof(IWeapon))] 
    public Object weapon;
}
