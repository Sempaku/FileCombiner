using System;
using System.Collections.Generic;
using System.IO;

namespace AI_FileCombiner
{
    internal class GitignoreParser
    {
        private readonly List<string> ignorePatterns = new List<string>();
        private readonly string basePath;

        public GitignoreParser(string projectPath)
        {
            var gitignorePath = FindGitignoreFile(projectPath);
            if(gitignorePath != null)
            {
                basePath = Path.GetDirectoryName(gitignorePath);
                var lines = File.ReadAllLines(gitignorePath);
                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();
                    if (!string.IsNullOrEmpty(trimmedLine) && !trimmedLine.StartsWith("#"))
                    {
                        ignorePatterns.Add(trimmedLine);
                    }
                }
            }
        }

        public bool IsIgnored(string filePath)
        {
            if (basePath == null)
                return false;

            string relativePath = filePath.Substring(basePath.Length).Replace('\\', '/');
            if (relativePath.StartsWith("/"))
            {
                relativePath = relativePath.Substring(1);
            }

            foreach (var pattern in ignorePatterns)
            {
                // Простое правило для директорий (например, "obj/")
                if (pattern.EndsWith("/") && ("/" + relativePath).Contains("/" + pattern.TrimEnd('/') + "/"))
                {
                    return true;
                }
                // Простое правило для файлов по маске (например, "*.user")
                if (pattern.StartsWith("*") && filePath.EndsWith(pattern.Substring(1)))
                {
                    return true;
                }
                // Простое правило для точного совпадения файла или папки
                if (relativePath.Equals(pattern.Trim('/'), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private string FindGitignoreFile(string startPath)
        {
            var directory = new DirectoryInfo(startPath);
            while (directory != null)
            {
                var gitignoreFile = Path.Combine(directory.FullName, ".gitignore");
                if (File.Exists(gitignoreFile))
                {
                    return gitignoreFile;
                }
                directory = directory.Parent;
            }
            return null;
        }

    }
}
