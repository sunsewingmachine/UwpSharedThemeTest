using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Shared_Themes.Common
{
    public static class Extensions
    {
        public static void StartAnimationFloating(this UIElement control, double scaleX = 1.04, double scaleY = 1.09)
        {
            int m = 0;
            // Create the transform
            //TranslateTransform moveTransform = new TranslateTransform();
            ScaleTransform moveTransform = new ScaleTransform();
            moveTransform.ScaleX = 1;
            moveTransform.ScaleY = 1;
            //moveTransform.CenterX = 0.5;
            //moveTransform.CenterY = 0.5;
            //moveTransform.TransformPoint(new Windows.Foundation.Point(0.5, 0.5));

            control.RenderTransformOrigin = new Point(0.5, 0.5);

            //control = BtnStoryCheck;               
            control.RenderTransform = moveTransform;

            Duration duration = new Duration(TimeSpan.FromMilliseconds(450));
            // Create two DoubleAnimations and set their properties.
            DoubleAnimation myDoubleAnimationX = new DoubleAnimation();
            DoubleAnimation myDoubleAnimationY = new DoubleAnimation();
            myDoubleAnimationX.Duration = duration;
            myDoubleAnimationY.Duration = duration;
            Storyboard sb = new Storyboard();
            sb.Duration = duration;
            sb.Children.Add(myDoubleAnimationX);
            sb.Children.Add(myDoubleAnimationY);
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.AutoReverse = true;
            Storyboard.SetTarget(myDoubleAnimationX, moveTransform);
            Storyboard.SetTarget(myDoubleAnimationY, moveTransform);

            // Set the X and Y properties of the Transform to be the target properties
            // of the two respective DoubleAnimations.
            Storyboard.SetTargetProperty(myDoubleAnimationX, "ScaleX");
            Storyboard.SetTargetProperty(myDoubleAnimationY, "ScaleY");
            myDoubleAnimationX.To = scaleX;
            myDoubleAnimationY.To = scaleY;
            // Make the Storyboard a resource.
            ((FrameworkElement)control).Resources.Add("justintimeStoryboard" + (++m).ToString(), sb);
            // Begin the animation.
            sb.Begin();
        }

    }
}