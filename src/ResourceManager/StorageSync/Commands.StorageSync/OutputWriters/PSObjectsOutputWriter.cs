namespace Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters
{
    using Validations;
    using Models;
    using Interfaces;

    public class PsObjectsOutputWriter : IOutputWriter
    {
        #region Fields and Properties
        private readonly ICmdlet _cmdlet;
        #endregion

        #region Constructors
        public PsObjectsOutputWriter(ICmdlet cmdlet)
        {
            _cmdlet = cmdlet;
        }
        #endregion

        #region Public methods
        public void Write(IValidationResult validationResult)
        {
            if (validationResult.Result != Result.Success)
            {
                _cmdlet.WriteObject(new PSValidationResult(validationResult));
            }

        }
        #endregion
    }
}