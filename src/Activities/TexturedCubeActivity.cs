using System;

using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using Android.Gestures;

namespace Mono.Samples.TexturedCube
{
	[Activity (Label = "@string/app_name", Theme="@style/Theme.ActionLight", MainLauncher = true, Icon = "@drawable/Icon",
#if __ANDROID_11__
		HardwareAccelerated=false,
#endif
	ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden, LaunchMode = LaunchMode.SingleTask)]
	public class TexturedCubeActivity : Activity, GestureDetector.IOnGestureListener, GestureDetector.IOnDoubleTapListener
	{
		PaintingView _glp;
		bool _actionBarVisible = true;

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
				default:
					break;
			}
			return true;
		}

		public override bool OnTouchEvent (MotionEvent e)
		{
			return base.OnTouchEvent (e);
		}
		
		public bool OnDown (MotionEvent e)
		{ 
			return true;
		}

		public bool OnFling (MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{ 
			return true;
		}

		public void OnLongPress (MotionEvent e)
		{  }

		public bool OnScroll (MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{ 
			return true;
		}

		public void OnShowPress (MotionEvent e)
		{  }

		public bool OnSingleTapUp (MotionEvent e)
		{
			return true;
		}

		public bool OnDoubleTap (MotionEvent e)
		{
			if (_actionBarVisible)
			{
				Window.SetFlags (0, WindowManagerFlags.Fullscreen);
				_glp.SystemUiVisibility = StatusBarVisibility.Hidden;
				ActionBar.Hide ();
			}
			else
			{
				Window.ClearFlags (WindowManagerFlags.Fullscreen);
				_glp.SystemUiVisibility = StatusBarVisibility.Visible;
				ActionBar.Show ();
			}

			_actionBarVisible = !_actionBarVisible;
			return true;
		}

		public bool OnDoubleTapEvent (MotionEvent e)
		{
			return true;
		}

		public bool OnSingleTapConfirmed (MotionEvent e)
		{
			return true;
		}
	}
}