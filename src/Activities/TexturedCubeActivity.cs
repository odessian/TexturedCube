using System;

using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace Mono.Samples.TexturedCube
{
	[Activity (Label = "@string/app_name", Theme="@style/Theme.ActionLight", MainLauncher = true, Icon = "@drawable/Icon",
#if __ANDROID_11__
		HardwareAccelerated=false,
#endif
	ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden, LaunchMode = LaunchMode.SingleTask)]
	public class TexturedCubeActivity : Activity
	{
		PaintingView _glp;
		bool _systemUIVisible = false;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.main);
			_glp = FindViewById<PaintingView> (Resource.Id.paintingview);
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.cube_edit_bar, menu);
			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
				case Resource.Id.menuSwitchTextures:
					_glp.SwitchTexture();
					break;
				case Resource.Id.menuToggleFullScreen:
					if (_systemUIVisible)
					{
						Window.ClearFlags (WindowManagerFlags.Fullscreen);
						_glp.SystemUiVisibility = StatusBarVisibility.Visible;
						ActionBar.Show ();
					}
					else
					{
						Window.SetFlags (0, WindowManagerFlags.Fullscreen);
						_glp.SystemUiVisibility = StatusBarVisibility.Hidden;
						ActionBar.Hide ();
					}
					_systemUIVisible = !_systemUIVisible;
					break;
				default:
					break;
			}
			return true;
		}
	}
}
