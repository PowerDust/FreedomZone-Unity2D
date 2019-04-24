using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E.Game
{
    public class InteractorController : MonoBehaviour
    {
        [SerializeField] private InteractorData m_InteractorData;
        [SerializeField] private SpriteRenderer m_HealthBar;


        private void Start()
        {
        }
        private void Update()
        {
            CheckHealth();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                UIManager.Singleton.m_UIInteractorInfoController.CurrentInteractorData = m_InteractorData;
            }
        }

        private void CheckHealth()
        {
            //检测死亡
            //if (m_InteractorData.HealthNow <= 0)
            //{
            //    Destroy(gameObject);
            //}
        }
    }
}