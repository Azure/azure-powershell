using System.Collections.Generic;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.AggregateValidations
{
    public abstract class AggregateValidation : INamespaceEnumeratorListener
    {
        protected readonly IConfiguration _configuration;
        private readonly IEnumerable<IOutputWriter> _outputWriters;

        protected AggregateValidation(IConfiguration configuration, IEnumerable<IOutputWriter> outputWriters)
        {
            _configuration = configuration;
            _outputWriters = outputWriters;
        }

        public abstract void BeginDir(IDirectoryInfo node);

        public abstract void EndDir(IDirectoryInfo node);

        public void EndOfEnumeration()
        {
            return;
        }

        public abstract void NextFile(IFileInfo node);

        protected void Broadcast(IValidationResult validationResult)
        {
            foreach (IOutputWriter outputWriter in _outputWriters)
            {
                outputWriter.Write(validationResult);
            }
        }

    }
}