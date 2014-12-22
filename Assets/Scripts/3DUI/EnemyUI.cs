using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts._3DUI
{
    class EnemyUI
    {
        private GameObject _enemy;
        private RectTransform _canvas;
        private IDamageable _enemyHealth;
        private Vector3 defaultUIPosition;
        private Quaternion defaultUIRotation;

        public EnemyUI(GameObject enemy, RectTransform canvas)
        {
            _canvas = canvas;
            _enemy = enemy;
            _enemyHealth = _enemy.GetComponent<EnemyAI>() as IDamageable;
            defaultUIPosition = _canvas.localPosition;
            defaultUIRotation = Quaternion.identity;
        }

        public void update()
        {
            // Fix the position and rotation above the enemy
            _canvas.position = _enemy.transform.position + defaultUIPosition;
            _canvas.rotation = defaultUIRotation;

            // Shrink it depending on its health
            float missingHealth = getHealthInPercent() / 100f;
            Vector3 scale = _canvas.localScale;
            scale.x = missingHealth;
            _canvas.localScale = scale;

            // Adjust position accordingly
            Vector3 position = _canvas.position;
            position.x = position.x - (1 - missingHealth)/2;
            _canvas.position = position;
        }

        private float getHealthInPercent()
        {
            return _enemyHealth.Health * 100 / _enemyHealth.MaxHealth;
        }
    }
}
