using System;
using Android.App;
using V4 = Android.Support.V4;
using Android.Views;

namespace ViewPager
{
    public class CarouselTransformer : Java.Lang.Object, V4.View.ViewPager.IPageTransformer
    {
        public CarouselTransformer(Activity context, float paddingToPage)
        {
            Context = context;
            this.offset = (DpPxConverter.dpToPx(paddingToPage) / (float)Context.Resources.DisplayMetrics.WidthPixels); 
        }

        private Activity Context;
        private float MinScale = 0.9f; // Minimum scale value
        private float MinAlpha = 0.5f; //Minimum alpha value
        private float offset;          //Center offset

        public void TransformPage(View view, float position)
        {
            position -= offset; //Adjust center offset

            if (position<-1 || position>1) // If the view is offscreen, make it invisible or leave as it is.
            {
                  view.Alpha = 0; 
            }
           
            if(position<=1 || position>=-1) // If screen is Left(-1) or Center(0) or Right(1)
            {

                var pos = Math.Abs(position);

                //Scale the Alpha
                var alphaScale = MinAlpha + (1 - pos) * (1 - MinAlpha);
                view.Alpha = alphaScale;

                // Scale the View.
                var scale = MinScale + (1 - pos) * (1 - MinScale);
                view.ScaleX = scale;
                view.ScaleY = scale;

                // Set the X Translation to keep the views close together.
                float xMargin = (view.Width) * (1 - scale) / 2;

                if (position < 0)
                {
                    view.TranslationX = xMargin / 2;
                }
                else
                {
                    view.TranslationX = (-xMargin / 2) ;

                }
            }
        }
    }
}
