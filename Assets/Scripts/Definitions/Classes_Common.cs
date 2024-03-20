using UnityEngine;

[System.Serializable]
public class Config_Rigidbody
{
    public float mass;
    public float drag;
    public float angularDrag;
    public bool automaticInertiaTensor;
    public bool useGravity;
    public bool isKinematic;
    public Config_Rigidbody(
        float mass = 1,
        float drag = 0,
        float angularDrag = .05f,
        bool automaticInertiaTensor = true,
        bool useGravity = true,
        bool isKinematic = false
    )
    {
        this.mass = mass;
        this.drag = drag;
        this.angularDrag = angularDrag;
        this.automaticInertiaTensor = automaticInertiaTensor;
        this.useGravity = useGravity;
        this.isKinematic = isKinematic;
    }
    public void Apply(Rigidbody rb)
    {
        rb.mass = this.mass;
        rb.drag = this.drag;
        rb.angularDrag = this.angularDrag;
        rb.automaticInertiaTensor = this.automaticInertiaTensor;
        rb.useGravity = this.useGravity;
        rb.isKinematic = this.isKinematic;
    }
}