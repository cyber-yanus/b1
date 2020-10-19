using System;
using Cubes;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;



namespace DefaultNamespace
{
    public class Hero : MonoBehaviour
    {
        private HeroCollisionCheck _heroCollisionCheck;
        private int _connectCheck;
        
        
        private void Awake()
        {
            _heroCollisionCheck = GetComponent<HeroCollisionCheck>();
        }

        private void FixedUpdate()
        {
            bool isGrounded = _heroCollisionCheck.isEnterGround;
        }

        public int AddCubeCount => transform.childCount - 1;
    }
    
}