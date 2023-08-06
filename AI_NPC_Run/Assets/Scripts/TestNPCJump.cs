using UnityEngine;

public class AutoJumpNPC : MonoBehaviour {
    public Transform target; // The target to jump towards.
    public float maxJumpHeight = 3f; // Maximum height of the jump.
    public float gravity = 9.81f; // Magnitude of gravity.

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        Jump();
    }

    private void Jump() {
        // Calculate the horizontal distance to the target.
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Calculate the time of flight.
        float timeOfFlight = distanceToTarget / Mathf.Sqrt(2 * maxJumpHeight / gravity);

        // Calculate the initial velocity.
        float initialVelocity = distanceToTarget / timeOfFlight;

        // Calculate the launch angle.
        float launchAngleRadians = Mathf.Atan(maxJumpHeight / distanceToTarget);
        float launchAngleDegrees = launchAngleRadians * Mathf.Rad2Deg;

        // Calculate the horizontal and vertical components of the velocity.
        float horizontalVelocity = initialVelocity * Mathf.Cos(launchAngleRadians);
        float verticalVelocity = initialVelocity * Mathf.Sin(launchAngleRadians);

        // Calculate the direction to the target.
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        // Apply the force with the calculated velocity components and direction.
        Vector3 jumpVelocity = (directionToTarget * horizontalVelocity) + (Vector3.up * verticalVelocity);
        rb.AddForce(jumpVelocity, ForceMode.VelocityChange);
    }
}