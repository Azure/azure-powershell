// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.CognitiveServices.Models
{
    using System.Linq;

    /// <summary>
    /// The commitment plan account association properties.
    /// </summary>
    public partial class CommitmentPlanAccountAssociationProperties
    {
        /// <summary>
        /// Initializes a new instance of the CommitmentPlanAccountAssociationProperties class.
        /// </summary>
        public CommitmentPlanAccountAssociationProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CommitmentPlanAccountAssociationProperties class.
        /// </summary>

        /// <param name="accountId">The Azure resource id of the account.
        /// </param>
        public CommitmentPlanAccountAssociationProperties(string accountId = default(string))

        {
            this.AccountId = accountId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the Azure resource id of the account.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "accountId")]
        public string AccountId {get; set; }
    }
}