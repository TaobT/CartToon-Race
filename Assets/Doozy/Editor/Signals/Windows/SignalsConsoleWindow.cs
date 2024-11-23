﻿// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using Doozy.Editor.EditorUI.Windows.Internal;
using Doozy.Editor.Signals.Layouts;
using Doozy.Editor.UIElements;
using Doozy.Runtime.UIElements.Extensions;
using UnityEditor;
using UnityEngine;

namespace Doozy.Editor.Signals.Windows
{
    public class SignalsConsoleWindow : FluidWindow<SignalsConsoleWindow>
    {
        private const string WINDOW_TITLE = "Signals Console";

        // [MenuItem(SignalsWindow.k_WindowMenuPath + WINDOW_TITLE, priority = -700)]
        public static void Open() => InternalOpenWindow(WINDOW_TITLE);

        protected override void OnEnable()
        {
            base.OnEnable();
            minSize = new Vector2(600, 400);
        }
        
        protected override void CreateGUI() =>
            root
                .RecycleAndClear()
                .AddChild(windowLayout = Activator.CreateInstance<SignalsConsoleWindowLayout>());

        protected override void OnDestroy()
        {
            base.OnDestroy();
            var layout = (SignalsConsoleWindowLayout)windowLayout;
            if (layout == null) return;
            layout.OnDestroy();
            layout.Dispose();
        }
    }
}
