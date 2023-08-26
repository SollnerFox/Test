using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity = 10f;
    public override void Activate(GameObject parent)
    {
        Vector3 dashDirection = parent.transform.forward;
        CharacterController controller = parent.GetComponent<CharacterController>();
        controller.Move(dashDirection * dashVelocity * Time.deltaTime);
    }
}
