using System.Collections.Generic;
using UnityEngine;

namespace QuizBot.UIControllers.BaseClasses
{
    /// <summary>
    /// Allows easy updating of a set of UI components with a set of data.
    /// </summary>
    /// <typeparam name="T">Container/view</typeparam>
    /// <typeparam name="U">Data type consumed by the container.</typeparam>
    public abstract class ContainerController<T, U> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField]
        protected List<T> _containers = null;

        /// <summary>
        /// Fills all available containers with data.
        /// </summary>
        /// <param name="data"></param>
        public void Refresh(params U[] data)
        {
            var maxLength = Mathf.Max(_containers.Count, data.Length);

            for (int i = 0; i < maxLength; ++i)
            {
                if (i < _containers.Count && i < data.Length)
                {
                    FillContainer(_containers[i], data[i]);
                }
                else
                {
                    // TODO: Deactivate empty containers? 
                    // Allow deactivation as a configurable option?
                    break;
                }
            }

        }

        /// <summary>
        /// Override to determine how to insert data into the container.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="data"></param>
        protected abstract void FillContainer(T container, U data);
    }
}