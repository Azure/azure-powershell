using Microsoft.CLU.Common.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// Type represents a file with more than one line.
    /// </summary>
    internal class MultiLineFile
    {
        /// <summary>
        /// Char[0]: First character of first line
        /// Char[1]: First character of second line
        /// </summary>
        public char[] Chars = new char[2];

        /// <summary>
        /// The file path.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Used to count the lines.
        /// </summary>
        public int Count { get; set; }
    }

    /// <summary>
    /// Type represents pipeline parameters source file with mutiple records.
    /// </summary>
    internal class MultiRecordSourceFile
    {
        /// <summary>
        /// The full path to the file.
        /// </summary>
        public string FullPath { get; private set; }

        /// <summary>
        /// Indicates whether each record in the file is an array or not.
        /// </summary>
        public bool IsArray { get; private set; }

        /// <summary>
        /// Creates an instance of MultiRecordSourceFile.
        /// </summary>
        /// <param name="fullPath">The full path to the file</param>
        /// <param name="isArray">Indicate whether the record is array or not</param>
        public MultiRecordSourceFile(string fullPath, bool isArray)
        {
            FullPath = fullPath;
            IsArray = isArray;
        }
    }

    /// <summary>
    /// In the presence of multiple ‘@@’ files in a single command invocation, only one may
    /// contain more than one record. This type is used to find such an input file which
    /// served as source for multiple records. Whether or not a file treated as mutli-record
    /// source is depends on the type of the parameters that takes value from it. Being a file
    /// that contains mutiple lines doesn't mean it is definitely a muti-record source.
    /// The rule is:
    /// 1. A muti-line file is muti-record source if the parameter taking value from it
    ///    is non-array
    /// 2. if the parameter taking value from muti-line file is an array, then file is a
    ///    muti-record source only if file contains mutiple array values. Note that an
    ///    array value can be represented as single line e.g. [abc,def,ghi] or can be spread
    ///    across mutiple lines like:
    ///     abc
    ///     def
    ///     ghi
    ///    which is another representation of single line array value [abc,def,ghi]. The '@@'
    ///    files may contain array values in both representation. This means below is a valid
    ///    @@file content with muti-records
    ///
    ///    [abc,def,ghi]
    ///    123
    ///    456
    ///    789
    ///
    ///   Which is equivalent to:
    ///    [abc,def,ghi]
    ///    [123,456,789]
    /// </summary>
    internal class MultiRecordSourceFileFinder
    {
        /// <summary>
        /// Find one file which serve as source for mutiple records.
        /// </summary>
        /// <param name="staticBindState">The state of static parameter binding</param>
        /// <param name="dynamicBindState">The state of dynamic parameter binding</param>
        /// <returns>
        /// Return MultiRecordSourceFile instance describing one of the @@ file which contains more than one record.
        /// Return null of there is no such file
        /// </returns>
        public static MultiRecordSourceFile Find(ParameterBindState staticBindState, ParameterBindState dynamicBindState)
        {
            Debug.Assert(staticBindState != null);
            Debug.Assert(dynamicBindState != null);
            MultiRecordSourceFile multiRecordSourceFile = null;
            var multilineFiles = CheckUsingNonArrayPipelineParameters(staticBindState, dynamicBindState, out multiRecordSourceFile);
            if (multiRecordSourceFile != null)
            {
                return multiRecordSourceFile;
            }

            multiRecordSourceFile = CheckUsingArrayPipelineParameters(staticBindState, dynamicBindState, multilineFiles);
            return multiRecordSourceFile;
        }

        /// <summary>
        /// Try locating muti-record file using non-array pipeline arguments.
        /// </summary>
        /// <param name="staticBindState">The state of static pareameter binding</param>
        /// <param name="dynamicBindState">The state of dynamic parameter binding</param>
        /// <param name="multiRecordsFilePath">The muti-record file path if found</param>
        /// <returns>Path to all files checked</returns>
        private static IList<MultiLineFile> CheckUsingNonArrayPipelineParameters(ParameterBindState staticBindState, ParameterBindState dynamicBindState, out MultiRecordSourceFile multiRecordsFilePath)
        {
            multiRecordsFilePath = null;
            var readFromFilePipelineParameters = staticBindState.ReadFromFilePipelineParameters;
            List<MultiLineFile> multilineFiles = new List<MultiLineFile>();
            foreach (var file in GetMultilineFiles(readFromFilePipelineParameters.Keys))
            {
                HashSet<string> inputParameterNames = readFromFilePipelineParameters[file.FilePath];

                bool anyNonArrayPipelineStaticParameter = GetPipelineParameters(staticBindState.CandidateParameters, inputParameterNames)
                    .Where(p => !p.ParameterType.IsArray)
                    .Any();
                if (anyNonArrayPipelineStaticParameter)
                {
                    multiRecordsFilePath = new MultiRecordSourceFile(file.FilePath, false);
                    break;
                }

                bool anyNonArrayPipelineDynamicParameter = GetPipelineParameters(dynamicBindState.CandidateParameters, inputParameterNames)
                    .Where(p => !p.ParameterType.IsArray)
                    .Any();
                if (anyNonArrayPipelineDynamicParameter)
                {
                    multiRecordsFilePath = new MultiRecordSourceFile(file.FilePath, false);
                    break;
                }

                bool anyNonArrayPipelineByPropertyStaticParameter = GetPipelinePropertyByNameParameters(staticBindState.CandidateParameters, inputParameterNames)
                    .Where(p => !p.ParameterType.IsArray)
                    .Any();
                if (anyNonArrayPipelineByPropertyStaticParameter)
                {
                    multiRecordsFilePath = new MultiRecordSourceFile(file.FilePath, false);
                    break;
                }

                bool anyNonArrayPipelineByPropertyDynamicParameter = GetPipelinePropertyByNameParameters(dynamicBindState.CandidateParameters, inputParameterNames)
                    .Where(p => !p.ParameterType.IsArray)
                    .Any();
                if (anyNonArrayPipelineByPropertyDynamicParameter)
                {
                    multiRecordsFilePath = new MultiRecordSourceFile(file.FilePath, false);
                    break;
                }

                multilineFiles.Add(file);
            }

            return multilineFiles;
        }

        /// <summary>
        /// Try locating muti-record file using array pipeline arguments.
        /// </summary>
        /// <param name="staticBindState">The state of static pareameter binding</param>
        /// <param name="dynamicBindState">The state of dynamic parameter binding</param>
        /// <param name="multilineFiles">The muti-line files to be checked to find muti-record file</param>
        /// <returns>The muti-record file path if found, else null</returns>
        /// <returns></returns>
        private static MultiRecordSourceFile CheckUsingArrayPipelineParameters(ParameterBindState staticBindState, ParameterBindState dynamicBindState, IList<MultiLineFile> multilineFiles)
        {
            var readFromFilePipelineParameters = staticBindState.ReadFromFilePipelineParameters;
            foreach (var file in multilineFiles)
            {
                HashSet<string> inputParameterNames = readFromFilePipelineParameters[file.FilePath];

                bool anyArrayPipelineStaticParameter = GetPipelineParameters(staticBindState.CandidateParameters, inputParameterNames)
                    .Where(p => p.ParameterType.IsArray)
                    .Any();

                bool anyArrayPipelineDynamicParameter = GetPipelineParameters(dynamicBindState.CandidateParameters, inputParameterNames)
                    .Where(p => p.ParameterType.IsArray)
                    .Any();

                bool anyArrayPipelineByPropertyStaticParameter = GetPipelinePropertyByNameParameters(staticBindState.CandidateParameters, inputParameterNames)
                    .Where(p => p.ParameterType.IsArray)
                    .Any();

                bool anyArrayPipelineByPropertyDynamicParameter = GetPipelinePropertyByNameParameters(dynamicBindState.CandidateParameters, inputParameterNames)
                    .Where(p => p.ParameterType.IsArray)
                    .Any();

                if (anyArrayPipelineStaticParameter || anyArrayPipelineDynamicParameter || anyArrayPipelineByPropertyStaticParameter || anyArrayPipelineByPropertyDynamicParameter)
                {
                    if (file.Chars[0] == '[' || file.Chars[1] == '[')
                    {
                        return new MultiRecordSourceFile(file.FilePath, true);
                    }

                    // At this point we need to read the file to check the presence of
                    // mix of array represntation
                    // {a}
                    // {b}
                    // [{c},{d}]
                    if (ContainsMultilineArray(file.FilePath))
                    {
                        return new MultiRecordSourceFile(file.FilePath, true);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the pipeline parameters.
        /// </summary>
        /// <param name="candidateParameters">The candidiate parametes to be considered</param>
        /// <param name="inputParameterNames">The parameters that user want to take value from @@ files</param>
        /// <returns>Enumerable collection of pipeline paramaters</returns>
        private static IEnumerable<ParameterMetadata> GetPipelineParameters(IEnumerable<ParameterMetadata> candidateParameters, HashSet<string> inputParameterNames)
        {
            return candidateParameters
                    .Where(parameter => inputParameterNames.Contains(parameter.Name))
                    .Where(p => p.TakesInputFromPipeline && !p.IsBound);
        }

        /// <summary>
        /// Gets the pipeline parameters that takes value by property name.
        /// </summary>
        /// <param name="candidateParameters">The candidiate parametes to be considered</param>
        /// <param name="inputParameterNames">The parameters that user want to take value from @@ files</param>
        /// <returns>Enumerable collection of pipeline paramaters that takes value by property name</returns>
        private static IEnumerable<ParameterMetadata> GetPipelinePropertyByNameParameters(IEnumerable<ParameterMetadata> candidateParameters, HashSet<string> inputParameterNames)
        {
            return candidateParameters
                    .Where(parameter => inputParameterNames.Contains(parameter.Name))
                    .Where(p => p.TakesInputFromPipelineByPropertyName && !p.IsBound);
        }

        /// <summary>
        /// Given the list of file paths returns an enumerable collection of MultiLineSourceFile
        /// which represents file with atleast 2 lines. This function will not count empty-line as line.
        /// </summary>
        /// <param name="filePaths"></param>
        /// <returns></returns>
        private static IEnumerable<MultiLineFile> GetMultilineFiles(IEnumerable<string> filePaths)
        {
            return filePaths.Select(filePath =>
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException(Strings.MultiRecordSourceFileFinder_GetMultilineFiles_FileNotFound, filePath);
                }

                MultiLineFile mutilineFile = new MultiLineFile();
                mutilineFile.Count = 0;
                mutilineFile.FilePath = filePath;
                using (var reader = System.IO.File.OpenText(filePath))
                {
                    string line;
                    while (mutilineFile.Count != 2 && ((line = reader.ReadLine()) != null))
                    {
                        line = line.Trim();
                        if (line != string.Empty)
                        {
                            // Save first character of first two non-empty lines
                            mutilineFile.Chars[mutilineFile.Count] = line[0];
                            mutilineFile.Count++;
                        }
                    }
                }

                return mutilineFile;
            }).Where(m => m.Count > 1);
        }

        /// <summary>
        /// Checks whether the given file contains more than one array value.
        /// The file is expected to contain atleast two lines.
        /// </summary>
        /// <param name="filePath">The path to file</param>
        /// <returns></returns>
        private static bool ContainsMultilineArray(string filePath)
        {
            using (var reader = System.IO.File.OpenText(filePath))
            {
                Func<string> NextNonEmptyLine = () =>
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        line = line.Trim();
                        if (line != string.Empty)
                        {
                            return line;
                        }

                        line = reader.ReadLine();
                    }

                    return null;
                };

                string firstLine = NextNonEmptyLine();
                Debug.Assert(firstLine != null);
                if (firstLine[0] == '[')
                {
                    return true;
                }

                string secondLine = NextNonEmptyLine();
                Debug.Assert(secondLine != null);
                if (secondLine[0] == '[')
                {
                    return true;
                }

                string otherLine = NextNonEmptyLine();
                while (otherLine != null && otherLine[0] != '[')
                {
                    otherLine = NextNonEmptyLine();
                }

                return (otherLine != null);
            }
        }
    }
}
