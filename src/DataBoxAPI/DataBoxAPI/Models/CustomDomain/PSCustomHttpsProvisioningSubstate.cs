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

namespace Microsoft.Azure.Commands.Cdn.Models.CustomDomain
{
    public enum PSCustomHttpsProvisioningSubstate
    {
        /// <summary>
        /// Unset.
        /// </summary>
        None,

        /// <summary>
        /// The substate is unknown.
        /// This is a generic substate that can be used for cases where certificate provisioning workflow fails unexpectedly.
        /// This should never happen unless there is an unhandled failure case.
        /// </summary>
        Unknown,

        /// <summary>
        /// The DCV request is being submitted to the CA.
        /// </summary>
        SubmittingDomainControlValidationRequest,

        /// <summary>
        /// The DCV request is pending for the domain owner approval.
        /// </summary>
        PendingDomainControlValidationRequestApproval,

        /// <summary>
        /// The DCV request is approved by the domain owner.
        /// </summary>
        DomainControlValidationRequestApproved,

        /// <summary>
        /// The DCV request is rejected by the domain owner.
        /// </summary>
        DomainControlValidationRequestRejected,

        /// <summary>
        /// The DCV request is timed out.
        /// </summary>
        DomainControlValidationRequestTimedOut,

        /// <summary>
        /// Issuing the certificate from the CA.
        /// </summary>
        IssuingCertificate,

        /// <summary>
        /// Deploying the certificate to the CDN network.
        /// </summary>
        DeployingCertificate,

        /// <summary>
        /// The certificate has been deployed to the CDN network.
        /// </summary>
        CertificateDeployed,

        /// <summary>
        /// Deleting the certificate from the CDN network.
        /// </summary>
        DeletingCertificate,

        /// <summary>
        /// The certificate has been deleted from the CDN network.
        /// </summary>
        CertificateDeleted,

        /// <summary>
        /// The certificate is being imported from an external source specified by the user.
        /// Example: Azure Key Vault
        /// </summary>
        ImportingUserProvidedCertificate
    }
}
