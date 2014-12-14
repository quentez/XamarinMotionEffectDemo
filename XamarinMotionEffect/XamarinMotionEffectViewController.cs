using System;
using System.Drawing;

using Foundation;
using UIKit;

namespace XamarinMotionEffect
{
	public partial class XamarinMotionEffectViewController : UIViewController
	{
		#region Constructor & Private fields.

		public XamarinMotionEffectViewController(IntPtr handle) : base(handle)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		private const int MotionEffectScale = 30;

		#endregion

		#region View lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.
			this.BuildUI();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}

		#endregion

		#region UI Logic.

		private void BuildUI()
		{
			// Create the background image.
			var imageBackground = new UIImageView {
				TranslatesAutoresizingMaskIntoConstraints = false,
				Image = UIImage.FromFile("Background.jpg"),
				ContentMode = UIViewContentMode.ScaleAspectFill
			};

			// Add motion effects to the background image.
			imageBackground.AddMotionEffect(new UIInterpolatingMotionEffect("center.x", UIInterpolatingMotionEffectType.TiltAlongHorizontalAxis) {
				MinimumRelativeValue = NSNumber.FromInt32(MotionEffectScale),
				MaximumRelativeValue = NSNumber.FromInt32(-MotionEffectScale)
			});
			imageBackground.AddMotionEffect(new UIInterpolatingMotionEffect("center.y", UIInterpolatingMotionEffectType.TiltAlongVerticalAxis) {
				MinimumRelativeValue = NSNumber.FromInt32(MotionEffectScale),
				MaximumRelativeValue = NSNumber.FromInt32(-MotionEffectScale)
			});

			// Create the main title.
			var labelTitle = new UILabel {
				TranslatesAutoresizingMaskIntoConstraints = false,
				Text = "UIMotionEffect Demo",
				Font = UIFont.FromName("HelveticaNeue-Thin", 30),
				TextColor = UIColor.White,
				TextAlignment = UITextAlignment.Center
			};

			var labelSubtitle = new UILabel {
				TranslatesAutoresizingMaskIntoConstraints = false,
				Text = "Using Xamarin.iOS",
				Font = UIFont.SystemFontOfSize(12),
				TextColor = UIColor.White,
				TextAlignment = UITextAlignment.Center
			};

			// Add views to main view.
			this.View.AddSubview(imageBackground);
			this.View.AddSubview(labelTitle);
			this.View.AddSubview(labelSubtitle);

			// Setup autolayout.
			var metrics = NSDictionary.FromObjectsAndKeys(
				new NSObject[] { NSNumber.FromInt32(-MotionEffectScale) },
				new NSObject[] { new NSString("motionEffectScale") });

			var subViews = NSDictionary.FromObjectsAndKeys(
				new NSObject[] { imageBackground, labelTitle, labelSubtitle },
				new NSObject[] { new NSString("imageBackground"), new NSString("labelTitle"), new NSString("labelSubtitle") });

			this.View.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-motionEffectScale-[imageBackground]-motionEffectScale-|", 0, metrics, subViews));
			this.View.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-200-[labelTitle]-5-[labelSubtitle]", 0, metrics, subViews));
			this.View.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-motionEffectScale-[imageBackground]-motionEffectScale-|", 0, metrics, subViews));
			this.View.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[labelTitle]|", 0, metrics, subViews));
			this.View.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[labelSubtitle]|", 0, metrics, subViews));
		}

		#endregion
	}
}

