using Albertos.Behaviors.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Albertos.Behaviors
{
    class CardImageBehavior : BindableBehavior<Image>
    {
        public static readonly BindableProperty AttachBehaviorProperty =
           BindableProperty.CreateAttached(
           "AttachBehavior",
           typeof(bool),
           typeof(CardImageBehavior),
           false,
           propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var img = view as Image;
            if (img == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
            }
            else
            {
            }
        }
    }
}
