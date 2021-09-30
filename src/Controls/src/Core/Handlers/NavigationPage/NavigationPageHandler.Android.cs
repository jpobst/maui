﻿using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.Controls.Handlers
{
	// Currently only inheriting because we can't tap into CreateNativeView
	// Once we can wire up into CreateNativeView then all of this code can move into the 
	// Remap structures
	internal partial class NavigationPageHandler : NavigationViewHandler
	{
		public static PropertyMapper<NavigationPage, NavigationPageHandler> NavigationPageMapper =
			new PropertyMapper<NavigationPage, NavigationPageHandler>(NavigationViewHandler.NavigationViewMapper)
			{
				[NavigationPage.HasNavigationBarProperty.PropertyName] = UpdateToolBar,
				[NavigationPage.HasBackButtonProperty.PropertyName] = UpdateToolBar,
				[NavigationPage.TitleIconImageSourceProperty.PropertyName] = UpdateToolBar,
				[NavigationPage.TitleViewProperty.PropertyName] = UpdateToolBar,
				[NavigationPage.IconColorProperty.PropertyName] = UpdateToolBar,
				[Page.TitleProperty.PropertyName] = UpdateToolBar,
				[NavigationPage.CurrentPageProperty.PropertyName] = UpdateToolBar,
				[PlatformConfiguration.AndroidSpecific.AppCompat.NavigationPage.BarHeightProperty.PropertyName] = UpdateToolBar,
			};

		ControlsNavigationManager _controlsNavigationManager;
		public NavigationPageHandler() : base(NavigationPageMapper)
		{

		}

		protected override NavigationManager CreateNavigationManager()
			=> _controlsNavigationManager ??= new ControlsNavigationManager(MauiContext);

		private static void UpdateToolBar(NavigationPageHandler arg1, NavigationPage arg2)
		{
			//TODO: TOOLBAR MAUI
			//arg1._controlsNavigationManager.ToolbarPropertyChanged();
		}
	}
}
