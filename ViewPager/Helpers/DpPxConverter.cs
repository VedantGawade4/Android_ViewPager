using Android.App;

namespace ViewPager
{
    public static class DpPxConverter
    {
        public static int dpToPx (float dp)
        {
            return (int)(dp * Application.Context.Resources.DisplayMetrics.Density);
        }
        public static int pxToDp(Activity context, int px)
        {
            return (int)(px / Application.Context.Resources.DisplayMetrics.Density);
        }
    }
}
