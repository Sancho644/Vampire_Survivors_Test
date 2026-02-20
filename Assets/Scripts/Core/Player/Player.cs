using UnityEngine;

namespace Core.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        public Transform PlayerTransform => player.transform;
    }
}