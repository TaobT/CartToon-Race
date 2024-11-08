﻿// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using System.IO;
using Doozy.Runtime.Common;
using Doozy.Runtime.Common.Extensions;
// ReSharper disable MemberCanBePrivate.Global

namespace Doozy.Editor.Common.Utils
{
    public static class FileGenerator
    {
        public static string GetFile(string path)
        {
            if (File.Exists(path)) return File.ReadAllText(path);
            Debugger.LogError($"File Not Found: {path}");
            return string.Empty;
        }

        public static bool WriteFile(string filePath, string data, bool silent = false)
        {
            if (filePath.IsNullOrEmpty())
            {
                Debugger.LogError("FilePath cannot be empty...");
                return false;
            }

            if (data.IsNullOrEmpty())
            {
                Debugger.LogError("Data cannot be empty...");
                return false;
            }

            if (!silent) Debugger.Log($"Writing file {filePath}");
            File.WriteAllText(filePath, data);
            return true;
        }
        
        /// <summary> Cleans any path returning Assets/... </summary>
        /// <param name="rawPath"> Raw path </param>
        public static string CleanPath(string rawPath)
        {
            string path = rawPath.Replace('\\', '/');
            int index = path.IndexOf("Assets/", StringComparison.Ordinal);
            path = path.Substring(index);
            return path;
        }
    }
}
