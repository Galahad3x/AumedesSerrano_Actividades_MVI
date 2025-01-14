using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth {
    [CreateAssetMenu(menuName = "GameManagerSO")]
    public class GameManagerSO : ScriptableObject {

        public event Action<int> OnPressurePlateActivated;
        public event Action<int> OnPressurePlateDeactivated;

        public void RaisePressurePlateActivated(int pressurePlate) {
            OnPressurePlateActivated?.Invoke(pressurePlate);
        }

        public void RaisePressurePlateDeactivated(int pressurePlate) {
            OnPressurePlateDeactivated?.Invoke(pressurePlate);
        }

        public event Action OnPlayerDeath;

        public void RaisePlayerDeath() {
            OnPlayerDeath?.Invoke();
        }
    }
}