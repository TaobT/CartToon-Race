// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using System.Collections.Generic;
// ReSharper disable All
namespace Doozy.Runtime.UIManager.Containers
{
    public partial class UIView
    {
        public static IEnumerable<UIView> GetViews(UIViewId.EndGame id) => GetViews(nameof(UIViewId.EndGame), id.ToString());
        public static void Show(UIViewId.EndGame id, bool instant = false) => Show(nameof(UIViewId.EndGame), id.ToString(), instant);
        public static void Hide(UIViewId.EndGame id, bool instant = false) => Hide(nameof(UIViewId.EndGame), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.EndGameMenus id) => GetViews(nameof(UIViewId.EndGameMenus), id.ToString());
        public static void Show(UIViewId.EndGameMenus id, bool instant = false) => Show(nameof(UIViewId.EndGameMenus), id.ToString(), instant);
        public static void Hide(UIViewId.EndGameMenus id, bool instant = false) => Hide(nameof(UIViewId.EndGameMenus), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.InGameMenu id) => GetViews(nameof(UIViewId.InGameMenu), id.ToString());
        public static void Show(UIViewId.InGameMenu id, bool instant = false) => Show(nameof(UIViewId.InGameMenu), id.ToString(), instant);
        public static void Hide(UIViewId.InGameMenu id, bool instant = false) => Hide(nameof(UIViewId.InGameMenu), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.MainMenu id) => GetViews(nameof(UIViewId.MainMenu), id.ToString());
        public static void Show(UIViewId.MainMenu id, bool instant = false) => Show(nameof(UIViewId.MainMenu), id.ToString(), instant);
        public static void Hide(UIViewId.MainMenu id, bool instant = false) => Hide(nameof(UIViewId.MainMenu), id.ToString(), instant);
    }
}

namespace Doozy.Runtime.UIManager
{
    public partial class UIViewId
    {
        public enum EndGame
        {
            RaceResults,
            Records
        }

        public enum EndGameMenus
        {
            RacesResults
        }

        public enum InGameMenu
        {
            PauseMenu,
            RaceResults
        }

        public enum MainMenu
        {
            ChooseCar,
            ChooseLevel,
            MainMenu,
            Settings
        }    
    }
}
