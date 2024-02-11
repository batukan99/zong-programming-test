using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zong.UI
{
    public class UIManager : Singleton<MonoBehaviour>
    {
        #region Unity Properties
        [SerializeField]
        private MainPanel mainPanel;
        [SerializeField]
        private WeaponsPanel weaponsPanel;
        [SerializeField]
        private InstrumentsPanel instrumentsPanel;
        #endregion

        #region Unity Methods
        void Start()
        {
            mainPanel.SetActiveImmediately(false);
            weaponsPanel.SetActiveImmediately(false);
            instrumentsPanel.SetActiveImmediately(false);
        }
        #endregion 
        
        #region  Public Methods
        public void EnableMainPanel()
        {
            mainPanel.SetActiveSmooth(true);
            weaponsPanel.SetActiveImmediately(false);
            instrumentsPanel.SetActiveImmediately(false);
        }
        public void EnableWeaponsPanel()
        {
            weaponsPanel.SetActiveSmooth(true);
            mainPanel.SetActiveSmooth(false);
        }
        public void EnableInstrumentsPanel()
        {
            instrumentsPanel.SetActiveSmooth(true);
            mainPanel.SetActiveSmooth(false);
        }
        #endregion
    }
}

