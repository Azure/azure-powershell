using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.CLU.Help
{
    internal class CommandDispatchHelper
    {
        /// <summary>
        /// Find all commands that start with the complete words indicated in args:
        /// 
        /// For example, the command line "ab cde" does *not* match the command "ab cdef" since the second words don't match.
        /// It does, however, consider the command "ab cde fgh" as a (partial) match.
        /// 
        /// Most common usage is for help where you want to see all possible matches for the words you have written so far
        /// </summary>
        /// <param name="pkgRoot"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IEnumerable<CommandInfo> FindCommands(string pkgRoot, string[] args)
        {
            var semiColonSeparatedArgs = String.Join(";", args) + ";";

            Func<string, bool> matcher = (cmd) =>
            {
                return CommandDispatchHelper.MatchScore(cmd, semiColonSeparatedArgs) >= cmd.Length;
            };

            return FindCommandMatches(pkgRoot, args, matcher);
        }

        /// <summary>
        /// Find all commands that start with the complete words indicated in args. This includes partial matches 
        /// for the last word.
        /// 
        /// For example, the command line "ab cde" *does* match the command "ab cdef" as well as the command "ab cde fgh"
        /// 
        /// Most common usage is to get statement completion where you want to see all the possible matches for the current last word
        /// on the command line
        /// </summary>
        /// <param name="pkgRoot"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IEnumerable<CommandInfo> CompleteCommands(string pkgRoot, string[] args)
        {
            var semiColonSeparatedArgs = String.Join(";", args);

            Func<string, bool> matcher = (cmd) =>
            {
                return CommandDispatchHelper.MatchScore(cmd, semiColonSeparatedArgs) >= semiColonSeparatedArgs.Length;
            };

            return FindCommandMatches(pkgRoot, args, matcher);
        }

        public static HelpInfo FindBestHelp(string pkgRoot, string[] args)
        {
            var semiColonSeparatedArgs = String.Join(";", args) + ";";

            Func<string, bool> matcher = (hlp) =>
            {
                return hlp.Length <= semiColonSeparatedArgs.Length && CommandDispatchHelper.MatchScore(hlp, semiColonSeparatedArgs) == hlp.Length;
            };

            return FindHelpMatches(pkgRoot, args, matcher).OrderByDescending((hi) => CommandDispatchHelper.MatchScore(hi.Discriminators, semiColonSeparatedArgs)).ThenBy((hi) => hi.Discriminators).FirstOrDefault();
        }

        public static IEnumerable<HelpInfo> FindHelpMatches(string pkgRoot, string[] args, Func<string, bool> matchFunc)
        {
            foreach (var helpInfo in GetPackages(pkgRoot).SelectMany((p) => p.GetHelp()))
            {
                var semiColonSeparatedCommand = helpInfo.Discriminators + ";";
                if (matchFunc(semiColonSeparatedCommand))
                {
                    yield return helpInfo;
                }
            }
        }

        public static IEnumerable<CommandInfo> FindCommandMatches(string pkgRoot, string[] args, Func<string, bool> matchFunc)
        {
            foreach (var commandIndex in GetCommandIndexes(pkgRoot).SelectMany((s) => { return s; }))
            {
                var semiColonSeparatedCommand = commandIndex.Discriminators + ";";
                if (matchFunc(semiColonSeparatedCommand))
                {
                    yield return commandIndex;
                }
            }
        }


        public static IEnumerable<CommandInfo[]> GetCommandIndexes(string pkgsRootPath)
        {
            foreach (var pkgInfo in GetPackages(pkgsRootPath))
            {
                yield return pkgInfo.GetCommands().ToArray();
            }
        }

        public static IEnumerable<PkgInfo> GetPackages(string pkgsRootPath)
        {
            var rootInfo = new System.IO.DirectoryInfo(pkgsRootPath);

            foreach (var pkgPath in rootInfo.EnumerateDirectories())
            {
                foreach (var versionPath in pkgPath.EnumerateDirectories())
                {
                    yield return new PkgInfo(pkgPath.Name, versionPath.Name, pkgPath.FullName);
                }
            }

        }

        public static int MatchScore(string semiColonSeparatedArgs, string semiColonSeparatedCommand)
        {
            int score = 0;
            for (int charPos = 0; charPos < Math.Min(semiColonSeparatedArgs.Length, semiColonSeparatedCommand.Length); ++charPos)
            {
                if (semiColonSeparatedArgs[charPos] != semiColonSeparatedCommand[charPos])
                {
                    break;
                }
                else
                {
                    score = charPos + 1;
                }
            }

            return score;
        }

        public class PkgInfo
        {
            public PkgInfo(string Name, string Version, string FullPath)
            {
                this.Name = Name;
                this.Version = Version;
                this.Path = FullPath;
            }

            public string Name { get; private set; }

            public string Version { get; private set; }

            public string Path { get; private set; }

            public string IndexPath
            {
                get
                {
                    return System.IO.Path.Combine(Path, Version, "_indexes", "_cmdlets.idx");
                }
            }

            public string HelpPath
            {
                get
                {
                    return System.IO.Path.Combine(Path, Version, "content", "help");
                }
            }
            public virtual IEnumerable<CommandInfo> GetCommands()
            {
                if (System.IO.File.Exists(IndexPath))
                {
                    return System.IO.File.ReadAllLines(IndexPath).Select((s) =>
                    {
                        var parts = s.Split(':');
                        return new CommandInfo() { Discriminators = parts[0], Package = this };
                    }).ToArray();
                }
                else
                {
                    return new CommandInfo[] { };
                }
            }

            public virtual IEnumerable<HelpInfo> GetHelp()
            {
                if (System.IO.Directory.Exists(HelpPath))
                {
                    return System.IO.Directory.EnumerateFiles(HelpPath, "*.hlp", System.IO.SearchOption.TopDirectoryOnly).Select((f) =>
                    {
                        return new HelpInfo(f);
                    });
                }
                else
                {
                    return new HelpInfo[] { };
                }
            }
        }

        public class HelpInfo
        {
            private string _path;

            public HelpInfo(string path)
            {
                _path = path;

                Discriminators = System.IO.Path.GetFileNameWithoutExtension(path).Replace('.', ';');
            }

            public IEnumerable<string> GetHelpContent()
            {
                if (System.IO.File.Exists(_path))
                {
                    return System.IO.File.ReadAllLines(_path);
                }
                else
                {
                    return new string[] { };
                }
            }

            public string Discriminators { get; private set; }
        }

        public class CommandInfo
        {
            public PkgInfo Package { get; set; }
            public string Discriminators { get; set; }

            public string Commandline
            {
                get
                {
                    return Discriminators.Replace(';', ' ');
                }
            }
        }
    }
}

