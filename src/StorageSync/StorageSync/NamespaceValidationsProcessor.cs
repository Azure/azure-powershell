// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using System.Collections.Generic;
    using Validations;
    using Interfaces;
    using System.Linq;

    /// <summary>
    /// Class NamespaceValidationsProcessor.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.INamespaceEnumeratorListener" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.INamespaceEnumeratorListener" />
    public class NamespaceValidationsProcessor : INamespaceEnumeratorListener
    {
        #region Fields and Properties
        /// <summary>
        /// The validations
        /// </summary>
        private readonly IList<INamespaceValidation> _validations;
        /// <summary>
        /// The output writers
        /// </summary>
        private readonly IList<IOutputWriter> _outputWriters;
        /// <summary>
        /// The progress reporter
        /// </summary>
        private readonly IProgressReporter _progressReporter;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceValidationsProcessor" /> class.
        /// </summary>
        /// <param name="validations">The validations.</param>
        /// <param name="outputWriters">The output writers.</param>
        /// <param name="progressReporter">The progress reporter.</param>
        public NamespaceValidationsProcessor(IList<INamespaceValidation> validations, IList<IOutputWriter> outputWriters, IProgressReporter progressReporter)
        {
            _validations = validations;
            _outputWriters = outputWriters;
            _progressReporter = progressReporter;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Begins the dir.
        /// </summary>
        /// <param name="node">The node.</param>
        public void BeginDir(IDirectoryInfo node)
        {
            foreach (INamespaceValidation validation in _validations)
            {
                IValidationResult validationResult = validation.Validate(node);
                Broadcast(validationResult);
            }
        }

        /// <summary>
        /// Ends the dir.
        /// </summary>
        /// <param name="node">The node.</param>
        public void EndDir(IDirectoryInfo node)
        {
            _progressReporter.CompleteStep();
        }

        /// <summary>
        /// Ends the of enumeration.
        /// </summary>
        /// <param name="namespaceInfo">The namespace information.</param>
        public void EndOfEnumeration(INamespaceInfo namespaceInfo)
        {
            foreach (INamespaceValidation validation in _validations)
            {
                IValidationResult validationResult = validation.Validate(namespaceInfo);
                Broadcast(validationResult);
            }
        }

        /// <summary>
        /// Nexts the file.
        /// </summary>
        /// <param name="node">The node.</param>
        public void NextFile(IFileInfo node)
        {
            foreach (INamespaceValidation validation in _validations)
            {
                IValidationResult validationResult = validation.Validate(node);
                Broadcast(validationResult);
            }
            _progressReporter.CompleteStep();
        }

        /// <summary>
        /// Unauthorizeds the dir.
        /// </summary>
        /// <param name="dir">The dir.</param>
        public void UnauthorizedDir(IDirectoryInfo dir)
        {
            var firstValidation = _validations.FirstOrDefault() as IValidationDescription;
            if (firstValidation != null)
            {
                Broadcast(ValidationResult.UnauthorizedAccessDir(firstValidation.ValidationType, firstValidation.ValidationKind, dir));
            }
        }

        /// <summary>
        /// Namespaces the hint.
        /// </summary>
        /// <param name="directoryCount">The directory count.</param>
        /// <param name="fileCount">The file count.</param>
        public void NamespaceHint(long directoryCount, long fileCount)
        {
            _progressReporter.ReserveSteps(directoryCount + fileCount);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Broadcasts the specified validation result.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        private void Broadcast(IValidationResult validationResult)
        {
            foreach (IOutputWriter outputWriter in _outputWriters)
            {
                outputWriter.Write(validationResult);
            }
        }
        #endregion
    }
}