using QuizBot.UIControllers.BaseClasses;
using UnityEngine;
using UnityEngine.UI;

namespace QuizBot.UIControllers.Reusable
{
    public class ImageController : ContainerController<Image, Sprite>
    {
        protected override void FillContainer(Image container, Sprite data)
        {
            container.sprite = data;
        }
    }
}