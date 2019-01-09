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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists the certificates matching the specified filter options.
        /// </summary>
        /// <param name="options">The options to use when querying for certificates.</param>
        /// <returns>The certificates matching the specified filter options.</returns>
        public IEnumerable<PSCertificate> ListCertificates(ListCertificateOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Get the single certificate matching the specified thumbprint
            if (!string.IsNullOrWhiteSpace(options.Thumbprint))
            {
                WriteVerbose(string.Format(Resources.GetCertificateByThumbprint, options.Thumbprint));
                CertificateOperations certOperations = options.Context.BatchOMClient.CertificateOperations;
                ODATADetailLevel getDetailLevel = new ODATADetailLevel(selectClause: options.Select);
                Certificate certificate = certOperations.GetCertificate(options.ThumbprintAlgorithm, options.Thumbprint,
                    detailLevel: getDetailLevel, additionalBehaviors: options.AdditionalBehaviors);
                PSCertificate psCertificate = new PSCertificate(certificate);
                return new PSCertificate[] { psCertificate };
            }
            // List certificates using the specified filter
            else
            {
                string verboseLogString = null;
                ODATADetailLevel listDetailLevel = new ODATADetailLevel(selectClause: options.Select);
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = Resources.GetCertificatesByFilter;
                    listDetailLevel.FilterClause = options.Filter;
                }
                else
                {
                    verboseLogString = Resources.GetCertificatesNoFilter;
                }
                WriteVerbose(verboseLogString);

                CertificateOperations certOperations = options.Context.BatchOMClient.CertificateOperations;
                IPagedEnumerable<Certificate> certificates = certOperations.ListCertificates(listDetailLevel, options.AdditionalBehaviors);
                Func<Certificate, PSCertificate> mappingFunction = c => { return new PSCertificate(c); };
                return PSPagedEnumerable<PSCertificate, Certificate>.CreateWithMaxCount(
                    certificates, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Adds a certificate to the specified Batch account.
        /// </summary>
        /// <param name="parameters">The parameters to use when creating the certificate.</param>
        public void AddCertificate(NewCertificateParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            CertificateOperations certOperations = parameters.Context.BatchOMClient.CertificateOperations;
            Certificate unboundCert;

            if (!string.IsNullOrWhiteSpace(parameters.FilePath))
            {
                if (string.IsNullOrWhiteSpace(parameters.Password))
                {
                    unboundCert = certOperations.CreateCertificate(parameters.FilePath);
                }
                else
                {
                    unboundCert = certOperations.CreateCertificate(parameters.FilePath, parameters.Password);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(parameters.Password))
                {
                    unboundCert = certOperations.CreateCertificate(parameters.RawData);
                }
                else
                {
                    unboundCert = certOperations.CreateCertificate(parameters.RawData, parameters.Password);
                }
            }

            WriteVerbose(string.Format(Resources.AddingCertificate, unboundCert.Thumbprint));
            unboundCert.Commit(parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Deletes the specified certificate.
        /// </summary>
        /// <param name="parameters">The parameters indicating which certificate to delete.</param>
        public void DeleteCertificate(CertificateOperationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            CertificateOperations certOperations = parameters.Context.BatchOMClient.CertificateOperations;
            certOperations.DeleteCertificate(parameters.ThumbprintAlgorithm, parameters.Thumbprint, parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Cancels a failed deletion of the specified certificate.
        /// </summary>
        /// <param name="parameters">The parameters indicating which certificate to failed to delete.</param>
        public void CancelDeleteCertificate(CertificateOperationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            WriteVerbose(string.Format(Resources.CancelCertificateDelete, parameters.Thumbprint));
            CertificateOperations certOperations = parameters.Context.BatchOMClient.CertificateOperations;
            certOperations.CancelDeleteCertificate(parameters.ThumbprintAlgorithm, parameters.Thumbprint, parameters.AdditionalBehaviors);
        }
    }
}