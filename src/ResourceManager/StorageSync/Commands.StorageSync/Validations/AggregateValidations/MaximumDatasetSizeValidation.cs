using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.AggregateValidations
{
    internal class MaximumDatasetSizeValidation : AggregateValidation
    {
        private readonly Dictionary<string, long> _directorySizeInBytes;

        public MaximumDatasetSizeValidation(IConfiguration configuration, IEnumerable<IOutputWriter> outputWriters) : base(configuration, outputWriters)
        {
            _directorySizeInBytes = new Dictionary<string, long>();
        }

        public override void BeginDir(IDirectoryInfo node)
        {
            _directorySizeInBytes.Add(node.FullName, 0);
        }

        public override void EndDir(IDirectoryInfo node)
        {
            IValidationResult validationResult = ValidateDirectorySize(node);          
            UpdateParentsSize(node);
            RemoveNodeFromSizeTable(node);
            Broadcast(validationResult);
        }

        private void RemoveNodeFromSizeTable(IDirectoryInfo node)
        {
            _directorySizeInBytes.Remove(node.FullName);
        }

        private IValidationResult ValidateDirectorySize(IDirectoryInfo node)
        {
            long maxDatasetSize = _configuration.MaximumDatasetSizeInBytes();
            bool directoryIsTooBig = _directorySizeInBytes[node.FullName] > maxDatasetSize;
            if (directoryIsTooBig)
            {
                return new ValidationResult
                {
                    Type = ValidationType.DatasetSize,
                    Level = ResultLevel.Error,
                    Description = $"The dataset is too big. Maximum dataset size is {maxDatasetSize}.",
                    Path = node.FullName,
                };
            }
           
                return ValidationResult.SuccessfullValidationResult(ValidationType.DatasetSize);
           
        }

        private void UpdateParentsSize(IDirectoryInfo node)
        {
            if (_directorySizeInBytes.ContainsKey(node.Parent.FullName))
            {
                _directorySizeInBytes[node.Parent.FullName] =
                    _directorySizeInBytes[node.Parent.FullName] + _directorySizeInBytes[node.FullName];
            }
        }

        public override void NextFile(IFileInfo node)
        {
            string parent = node.Directory.FullName;
            _directorySizeInBytes[parent] = _directorySizeInBytes[parent] + node.Length;
        }
    }
}