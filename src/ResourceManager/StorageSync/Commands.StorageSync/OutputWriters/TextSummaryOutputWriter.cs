using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using AFSEvaluationTool.Validations;

namespace AFSEvaluationTool.OutputWriters
{
    class TextSummaryOutputWriter : IOutputWriter, INamespaceEnumeratorListener
    {
        private int _filesScanned;
        private int _directoriesScanned;
        private readonly List<IValidationResult> _systemValidationResults;
        private readonly Dictionary<ValidationType, long> _validationErrorsHistogram;
        private readonly string _rootPath;
        private readonly IConsoleWriter _consoleWriter;

        private readonly HashSet<ValidationType> _systemValidationTypes = new HashSet<ValidationType>
        {
            ValidationType.FileSystem,
            ValidationType.OsVersion
        };

        private readonly Dictionary<ValidationType, string> _validationTypeDescriptions = new Dictionary<ValidationType, string>
        {
            {ValidationType.FileSystem, "Filesystem check"},
            {ValidationType.OsVersion, "OS Compatibility check"},
            {ValidationType.FilenameCharacters, "Invalid characters on filenames"},
            {ValidationType.FilenameLength, "Too long filenames"},
            {ValidationType.Filename, "Invalid Filenames"},
            {ValidationType.PathLength, "Too long paths"},
            {ValidationType.NodeDepth, "Files are too deep"},
            {ValidationType.DatasetSize, "Dataset is too big"}
        };

        public TextSummaryOutputWriter(string rootPath, IConsoleWriter consoleWriter)
        {
            _rootPath = rootPath;
            _consoleWriter = consoleWriter;
            _validationErrorsHistogram = new Dictionary<ValidationType, long>();
            _systemValidationResults = new List<IValidationResult>();
        }

        public void BeginDir(IDirectoryInfo node)
        {
            _directoriesScanned += 1;
        }

        public void EndDir(IDirectoryInfo node)
        {
            return;
        }

        public void NextFile(IFileInfo node)
        {
            _filesScanned += 1;
        }

        public void Write(IValidationResult validationResult)
        {
            if (IsSystemValidation(validationResult))
            {
                _systemValidationResults.Add(validationResult);
            }
            else
            {
                if (IsError(validationResult))
                {
                    if (!_validationErrorsHistogram.ContainsKey(validationResult.Type))
                    {
                        _validationErrorsHistogram[validationResult.Type] = 0;
                    }

                    _validationErrorsHistogram[validationResult.Type] =
                        _validationErrorsHistogram[validationResult.Type] + 1;
                }
            }
        }

        private bool IsSystemValidation(IValidationResult validationResult)
        {
            return _systemValidationTypes.Contains(validationResult.Type);
        }

        private bool IsError(IValidationResult validationResult)
        {
            return validationResult.Result == Result.Fail;
        }

        public void EndOfEnumeration()
        {
            WriteReport();
        }

        private void WriteReport()
        {
            _consoleWriter.WriteLine(" ");
            WritePathScanned();
            WriteSystemValidationResults();
            WriteCountOfScannedNodes();
            WriteCountOfErrorsFound();

            if (!_validationErrorsHistogram.Any())
            {
                _consoleWriter.WriteLine("There were no compatibility issues found with your files.");
            }
        }

        private void WriteCountOfErrorsFound()
        {
            foreach (KeyValuePair<ValidationType, long> entry in _validationErrorsHistogram)
            {
                string description = DescriptionForValidationType(entry.Key);
                _consoleWriter.WriteLine($"{description}: {entry.Value}");
            }
        }

        private string DescriptionForValidationType(ValidationType validationType)
        {
            if (_validationTypeDescriptions.ContainsKey(validationType))
            {
                return _validationTypeDescriptions[validationType];
            }

            return validationType.ToString();
        }

        private void WriteCountOfScannedNodes()
        {
            _consoleWriter.WriteLine($"Files scanned: {_filesScanned}");
            _consoleWriter.WriteLine($"Directories scanned: {_directoriesScanned}");
        }

        private void WriteSystemValidationResults()
        {
            foreach (IValidationResult validatonResult in _systemValidationResults)
            {
                string result = IsError(validatonResult) ? "Failed" : "Passed";
                _consoleWriter.WriteLine($"{DescriptionForValidationType(validatonResult.Type)}: {result}.");
            }
        }

        private void WritePathScanned()
        {
            _consoleWriter.WriteLine($"Evaluated: {_rootPath}");
        }
    }
}
