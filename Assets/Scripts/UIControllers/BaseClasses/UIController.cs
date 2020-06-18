using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizBot.UIControllers.BaseClasses
{
    public abstract class UIController<T> : MonoBehaviour
    {
        public abstract void Refresh(T data);
    }
}