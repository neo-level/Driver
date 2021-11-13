using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float offset = -10; 
    private void LateUpdate()
    {
        transform.position = Player.transform.position + new Vector3(0,0, offset);
    }
}
