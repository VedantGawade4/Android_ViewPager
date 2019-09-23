using Android.App;
using Android.OS;
using ViewPager.Adapters;
using V4 = Android.Support.V4;
using V7 = Android.Support.V7.App;

namespace ViewPager
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : V7.AppCompatActivity
    {
        private ViewPagerAdapter adapter;
        private V4.View.ViewPager viewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            InitializeUIRef();
            SetUpViewPagerAdapter();
        }

        private void InitializeUIRef()
        {
            viewPager = FindViewById<V4.View.ViewPager>(Resource.Id.vp_pager);
        }

        private void SetUpViewPagerAdapter()
        {
            adapter = new ViewPagerAdapter();
            viewPager.Adapter = adapter;

            var paddingDp = 40;
            //var pageMargin = 20;
            int px = DpPxConverter.dpToPx(paddingDp);
            viewPager.SetPadding(px, 0, px, 0);
            viewPager.SetClipToPadding(false);
            viewPager.OffscreenPageLimit = 5;
            //viewPager.PageMargin = DpPxConverter.dpToPx(pageMargin);
            viewPager.SetPageTransformer(false, new CarouselTransformer(this, paddingDp));
        }

    }
}

