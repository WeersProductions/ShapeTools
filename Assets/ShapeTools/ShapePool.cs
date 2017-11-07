using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeersProductions.ShapeTools
{
    /// <summary>
    /// A simple class that allows to pool the different shapes.
    /// Does not yet support multiple shapes at the same time and will result in unexpected results.
    /// TODO: make it support different shapes at the same time.
    /// </summary>
    public class ShapePool : MonoBehaviour
    {
        /// <summary>
        /// A singleton reference.
        /// </summary>
        private static ShapePool _instance;

        /// <summary>
        /// The pool.
        /// TODO: this is what should change to support multiple shapes at the same time.
        /// </summary>
        private readonly Queue<LineRenderer> _pool = new Queue<LineRenderer>();

        private void Awake()
        {
            _instance = this;
        }

        /// <summary>
        /// Gets a shape of a certain type. 
        /// Will internally use the pool or instantiate a new one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetShape<T>() where T : ShapeRenderer
        {
            if (_instance._pool.Count > 0)
            {
                LineRenderer result;
                while ((result = _instance._pool.Dequeue()) == null)
                {
                    if (_instance._pool.Count <= 0)
                    {
                        return GetShape<T>();
                    }
                }

                result.gameObject.SetActive(true);
                return result.gameObject.AddComponent<T>();
            }
            else
            {
                return InstantiateShape<T>();
            }
        }

        /// <summary>
        /// Instantiate a new shape.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T InstantiateShape<T>() where T : ShapeRenderer
        {
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<LineRenderer>();
            return gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Remove a shape and add it to the pool again to be reused.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arc"></param>
        public static void RemoveShape<T>(T arc) where T : ShapeRenderer
        {
            _instance._pool.Enqueue(arc.GetComponent<LineRenderer>());
            arc.gameObject.SetActive(false);
        }
    }
}