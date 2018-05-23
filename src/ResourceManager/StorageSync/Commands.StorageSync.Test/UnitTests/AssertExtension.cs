using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
using Xunit;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    static class AssertExtension
    {
        public static void ValidationResultIsError(IValidationResult validationResult, string message)
        {
            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        public static void ValidationResultTypeIs(IValidationResult validationResult, string message)
        {
            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        internal static void ValidationResultIsSuccess(IValidationResult validationResult, string message)
        {
            Assert.StrictEqual<Result>(Result.Success, validationResult.Result);
        }
    }
}
