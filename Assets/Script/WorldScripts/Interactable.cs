using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius); 
    }
}
