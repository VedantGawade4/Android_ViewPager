using System;
using Android.Runtime;
using V4 = Android.Support.V4;
using Android.Views;
using Java.Lang;
using Android.Widget;

namespace ViewPager.Adapters
{
    public class ViewPagerAdapter : V4.View.PagerAdapter
    {
        public ViewPagerAdapter()
        {
        }

        public override int Count
        {
            get { return 10; }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            var view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.ViewPagerCellLayout, null, false);
            view.Tag = position;

            TextView pageTitle = view.FindViewById<TextView>(Resource.Id.tv_pageTitle);
            pageTitle.Text = "This is page " + position.ToString();

            var viewPager = container.JavaCast<V4.View.ViewPager>();
            viewPager.AddView(view);

            return view;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            var viewPager = container.JavaCast<V4.View.ViewPager>();
            viewPager.RemoveView(@object as View);
        }
    }
}
