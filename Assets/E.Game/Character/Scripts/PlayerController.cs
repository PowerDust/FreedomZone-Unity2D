// ========================================================
// 作者：E Star 
// 创建时间：2018-12-21 13:33:17 
// 当前版本：1.0 
// 作用描述：玩家控制器
// 挂载目标：Player
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

namespace E.Game
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerData))]
    public class PlayerController : CharacterController
    {
        [Header("交互相关")]
        [SerializeField, Tooltip("交互模式")] private InteractiveMode m_InteractiveMode = InteractiveMode.普通;

        //[Header("其它")]
        private PlayerData m_PlayerData;


        protected override void Awake()
        {
            base.Awake();
            m_PlayerData = GetComponent<PlayerData>();


            DontDestroyOnLoad(gameObject);
        }
        private void Start()
        {
            InitPlayerModel();
            UIManager.Singleton.m_UIMessageController.ShowMessage("欢迎光临浮泽世界！亲爱的" + m_PlayerData.PlayerName);
        }
        private void Update()
        {
            //记录本次游戏时间
            m_PlayerData.TotalOnline += TimeSpan.FromSeconds(1f / 60);

            if (!Cursor.visible)
            {
                //按键检测
                if (Input.GetKeyUp(KeyCode.Q))
                {
                }
                if (Input.GetKeyUp(KeyCode.E))
                {
                }
                if (Input.GetKeyUp(KeyCode.F))
                {
                    StoryManager.Singleton.SurveyOrDialog();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    if (m_InteractiveMode == InteractiveMode.普通)
                    {
                    }
                    else if (m_InteractiveMode == InteractiveMode.战斗)
                    {
                    }
                    else if (m_InteractiveMode == InteractiveMode.投掷)
                    {
                    }
                }
                if (Input.GetMouseButtonUp(1))
                {
                    if (m_InteractiveMode == InteractiveMode.普通)
                    {
                    }
                    else if (m_InteractiveMode == InteractiveMode.战斗)
                    {
                    }
                    else if (m_InteractiveMode == InteractiveMode.投掷)
                    {
                    }
                }
                if (Input.GetKeyUp(KeyCode.Tab))
                {
                    switch (m_InteractiveMode)
                    {
                        case InteractiveMode.普通:
                            m_InteractiveMode = InteractiveMode.战斗;
                            Debug.Log("准备攻击");
                            break;
                        case InteractiveMode.战斗:
                            m_InteractiveMode = InteractiveMode.投掷;
                            Debug.Log("准备投掷");
                            break;
                        case InteractiveMode.投掷:
                            m_InteractiveMode = InteractiveMode.普通;
                            Debug.Log("准备使用");
                            break;
                    }
                }

                SetAnimation();
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.F) | Input.GetKeyUp(KeyCode.Space) |
                    Input.GetKeyUp(KeyCode.Return) | Input.GetMouseButtonUp(0))
                {
                    StoryManager.Singleton.NextSentence();
                }

            }


            float v = Input.GetAxis("Vertical");  //竖直方向的移动
            m_Rigidbody2D.velocity = transform.forward * speed * v;
            float h = Input.GetAxis("Horizontal");
            //m_Rigidbody2D.angularVelocity = transform.up * angularSpeed * h;
        }


        //移动速度
        public float speed = 1;
        //物体旋转速度
        public float angularSpeed = 1;  


        /// <summary>
        /// 初始化玩家信息
        /// </summary>
        private void InitPlayerModel()
        {
            m_PlayerData.PlayerName = "E";
            m_PlayerData.PlayerID = "000001";
            m_PlayerData.FirstLogin = DateTime.Now;
            m_PlayerData.LastLogin = DateTime.Now;
            m_PlayerData.LastLogout = DateTime.Now;

            m_PlayerData.TotalOnline = TimeSpan.Zero;
            m_PlayerData.Health = 100;
            m_PlayerData.Stamina = 100;
            m_PlayerData.Mentality = 100;
            m_PlayerData.Satiety = 1;
            m_PlayerData.Cleanness = 1;
            m_PlayerData.Strength = 40;
            m_PlayerData.RunSpeed = 5;

            m_PlayerData.CarryingProps = null;
            m_PlayerData.OwnedSkills = null;
        }

        /// <summary>
        /// 设置动画
        /// </summary>
        private void SetAnimation()
        {
        }
        //物品系统
        /// <summary>
        /// 拾取物品
        /// </summary>
        /// <param name="hand"></param>
        private void PickUp(GameObject hand)
        {
        }
        /// <summary>
        /// 使用
        /// </summary>
        /// <param name="hand">使用道具的手</param>
        private void Use(GameObject hand)
        {
            Debug.Log("正在使用由：" + hand.name);
        }
        /// <summary>
        /// 攻击
        /// </summary>
        /// <param name="hand">攻击的手</param>
        private void Attack(GameObject hand)
        {
            Debug.Log("正在攻击由：" + hand.name);
        }
        /// <summary>
        /// 投掷
        /// </summary>
        /// <param name="hand">投掷道具的手</param>
        private void Throw(GameObject hand)
        {
        }
    }
}