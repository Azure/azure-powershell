////////////////////////////////////////////////////////////////////////////////
//
// Copyright (C) Microsoft Corporation. All rights reserved.
//
////////////////////////////////////////////////////////////////////////////////

using System.Globalization;

namespace Microsoft.Azure.Cdn.Services.ResourceProvider.Models.EndpointModels
{
    /// <summary>
    /// Represents the validate custom domain action output.
    /// </summary>
    public class ValidateCustomDomainOutput
    {
        /// <summary>
        /// Gets or sets whether the custom domain is validated or not.
        /// </summary>
        public bool CustomDomainValidated { get; set; }

        /// <summary>
        /// Gets or sets the reason why the custom domain is not valid.
        /// Note: This is a string form of an enum type CustomDomainInvalidReason.
        /// This is not an enum type because of the limitation of web api framework.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the message on why the custom domain is not valid.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "ValidateCustomDomainOutput {{{0}}}",
                new
                {
                    CustomDomainValidated,
                    Reason,
                    Message,
                });
        }
    }
}
