using UnityEngine;

namespace Environment
{
    public class LevelBoundary : MonoBehaviour
    {
        public static readonly float EdgeBorder = 1.5f;
        
        private float _internalLeft;
        private float _internalRight;
        
        void Start()
        {
            _internalLeft = -EdgeBorder;
            _internalRight = EdgeBorder;
        }
    }
}
