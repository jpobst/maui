﻿#nullable enable
using System;
using Microsoft.Maui.Graphics;
using Microsoft.UI.Xaml.Controls;

namespace Microsoft.Maui
{
	public class ContentPanel : Panel
	{
		internal Func<double, double, Size>? CrossPlatformMeasure { get; set; }
		internal Func<Rectangle, Size>? CrossPlatformArrange { get; set; }

		protected override global::Windows.Foundation.Size MeasureOverride(global::Windows.Foundation.Size availableSize)
		{
			if (CrossPlatformMeasure == null)
			{
				return base.MeasureOverride(availableSize);
			}

			var measure = CrossPlatformMeasure(availableSize.Width, availableSize.Height);

			return measure.ToNative();
		}

		protected override global::Windows.Foundation.Size ArrangeOverride(global::Windows.Foundation.Size finalSize)
		{
			if (CrossPlatformArrange == null)
			{
				return base.ArrangeOverride(finalSize);
			}

			var width = finalSize.Width;
			var height = finalSize.Height;

			var actual = CrossPlatformArrange(new Rectangle(0, 0, width, height));

			return new global::Windows.Foundation.Size(actual.Width, actual.Height);
		}
	}
}
