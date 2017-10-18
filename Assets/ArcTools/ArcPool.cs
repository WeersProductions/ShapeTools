using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeersProductions.ArcTools
{
    public class ShapePool : MonoBehaviour
    {
        private static ShapePool _instance;

        [SerializeField]
        private ArcRenderer _arcPrefab;

        [SerializeField]
        private CircleRenderer _circlePrefab;

        private readonly Queue<ShapeRenderer> _pool = new Queue<ShapeRenderer>();

        private void Awake()
        {
            _instance = this;
        }

        public static T GetShape<T>() where T : ShapeRenderer
        {
            if (_instance._pool.Count > 0)
            {
                ShapeRenderer result;
                while ((result = _instance._pool.Dequeue()) == null)
                {
                    if (_instance._pool.Count <= 0)
                    {
                        return GetShape<T>();
                    }
                }

                result.gameObject.SetActive(true);
                return (T)result;
            }
            else
            {
                return InstantiateShape<T>();
            }
        }

        private static T InstantiateShape<T>() where T : ShapeRenderer
        {
            if (typeof(T) == typeof(ArcRenderer))
            {
                return (T)(object)Instantiate(_instance._arcPrefab);
            }
            if (typeof(T) == typeof(CircleRenderer))
            {
                return (T)(object)Instantiate(_instance._circlePrefab);
            }
            throw new Exception("Unknown type: " + typeof(T));
        }

        public static void RemoveShape<T>(T arc) where T : ShapeRenderer
        {
            _instance._pool.Enqueue(arc);
            arc.gameObject.SetActive(false);
        }
    }
}