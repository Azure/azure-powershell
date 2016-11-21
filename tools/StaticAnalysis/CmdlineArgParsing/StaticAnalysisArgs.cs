using System;
using CommandLine;
using CommandLine.Text;
using System.IO;

namespace StaticAnalysis.CmdlineArgParsing
{
    internal class StaticAnalysisArgs
    {
        private string _cmdletDirPath;
        private string _exceptionRootDir;
        
        [Option("legacyMode", Required = false, HelpText = "Specify legacy mode to run Static Analysis tool in legacy mode" )]
        public bool LegacyMode { get; set; }

        [Option('d', "cmdletDir", Required = true, HelpText = "Provide cmdlet install directory to discover cmdlet modules")]
        public string CmdletDirectoryPath
        {
            get
            {
                return _cmdletDirPath;
            }
            set
            {
                if(string.IsNullOrEmpty(_cmdletDirPath))
                {
                    _cmdletDirPath = value;
                    if (!Directory.Exists(_cmdletDirPath))
                        throw new DirectoryNotFoundException(string.Format("{0} is not a valid directory or does not exists", _cmdletDirPath));
                }
            }
        }

        [Option('e', "ExceptionRootDir", Required = false, HelpText = "Root direcotry for exceptions that allow you to bypass grandfathered cmdlets from this tool")]
        public string ExceptionRootDir
        {
            get { return _exceptionRootDir; }
            set
            {
                if (string.IsNullOrEmpty(_exceptionRootDir))
                {
                    _exceptionRootDir = value;
                    if (!Directory.Exists(_exceptionRootDir))
                        throw new DirectoryNotFoundException(string.Format("{0} is not a valid directory or does not exists", _cmdletDirPath));
                }
            }
        }

        [HelpOption]
        public string GetUsage()
        {
            string usageHelpStr = @"
                    StaticAnalysis.exe -cmdlet[D]ir c:\mycmdlets\
                    StaticAnalysis.exe -cmdlet[D]ir ""c:\my documents\mycmdlets\""
                    StaticAnalysis.exe -cmdlet[D]ir c:\mycmdlets\ -[l]egacyMode
            ";

            return usageHelpStr;
        }
    }
}
