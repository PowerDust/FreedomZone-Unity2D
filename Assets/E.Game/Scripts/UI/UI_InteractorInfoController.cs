// ========================================================
// 作者：E Star
// 创建时间：2019-04-24 00:20:57
// 当前版本：1.0
// 作用描述：
// 挂载目标：
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using E.Utility;
using E.Tool;

namespace E.Game
{
    public class UI_InteractorInfoController : MonoBehaviour
    {
        [SerializeField] private Image m_ImgIcon;
        [SerializeField] private Text m_TxtInteractorName;
        [SerializeField] private Text m_TxtDescribe;

        [SerializeField] private InteractorData m_CurrentInteractorData;
        public InteractorData CurrentInteractorData { get => m_CurrentInteractorData; set => m_CurrentInteractorData = value; }


        private void Update()
        {
            if (m_CurrentInteractorData != null)
            {
                ShowInteractorInfo();
            }
        }
        private void ShowInteractorInfo()
        {
            m_ImgIcon.sprite = m_CurrentInteractorData.Icon;
            m_TxtInteractorName.text = m_CurrentInteractorData.InteractorName;
            m_TxtDescribe.text = m_CurrentInteractorData.Describe;
        }
    }
}
