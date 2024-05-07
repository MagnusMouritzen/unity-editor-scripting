using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  // RequireComponent
public class Example : MonoBehaviour
{
    // TextArea
    [TextArea(10, 20)]
    public string description;
    
    // SerializeField and HideInInspector
    [SerializeField] private int privateVar;
    [HideInInspector] public int publicVar;

    [field: SerializeField] public int MyProperty { get; set; }  // This was a mistake in the video; it does work with this syntax.
    
    // Range
    [Range(0, 359)] 
    public int degrees;
    
    // Header, Space, and Tooltip
    [Header("Setup")] 
    public Rigidbody rb;
    public Collider playerCollider;
    
    [Header("Movement")]
    public float maxSpeed;
    public float acceleration;
    [Space]
    public float jumpHeight;
    [Tooltip("Gravity is the acceleration applied to the character.")]
    public float gravity;
    
    // Serializable
    public Ingredient ingredient;
}

[Serializable]
public class Ingredient
{
    public string name;
    public int amount;
}
