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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;

namespace Microsoft.Azure.Commands.Support.Models
{
    public class PSSupportTicket
    {
        /// <summary>
        ///  Gets or sets the resource Id of the resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets system generated support ticket name.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string SupportTicketId { get; set; }

        /// <summary>
        /// Gets or sets description of the support ticket.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets this is the resource id of ProblemClassification
        /// resource associated with the support ticket. This is the issue or
        /// the problem that the support ticket is opened for.
        /// </summary>
        public string ProblemClassificationId { get; set; }

        /// <summary>
        /// Gets localized name of problem classification.
        /// </summary>
        public string ProblemClassificationDisplayName { get; set; }

        /// <summary>
        /// Gets or sets severity of the support ticket. Possible values
        /// include: 'minimal', 'moderate', 'critical'
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string Severity { get; set; }

        /// <summary>
        /// Gets enrollment ID associated with the support ticket.
        /// </summary>
        public string EnrollmentId { get; set; }

        /// <summary>
        /// Gets or sets indicates if this is a 24x7 support ticket.
        /// </summary>
        public bool? Require24X7Response { get; set; }

        /// <summary>
        /// Gets or sets user information associated with the support ticket.
        /// </summary>
        public PSContactProfile ContactDetail { get; set; }

        /// <summary>
        /// Gets or sets service Level Agreement information for this support
        /// ticket.
        /// </summary>
        public PSServiceLevelAgreement ServiceLevelAgreement { get; set; }

        /// <summary>
        /// Gets or sets information about support engineer working on this
        /// support ticket.
        /// </summary>
        public PSSupportEngineer SupportEngineer { get; set; }

        /// <summary>
        /// Gets support plan type associated with the support ticket.
        /// </summary>
        public string SupportPlanType { get; set; }

        /// <summary>
        /// Gets or sets time in UTC (ISO 8601 format) when the problem
        /// started.
        /// </summary>
        public DateTime? ProblemStartTime { get; set; }

        /// <summary>
        /// Gets or sets this is the resource id of Service resource associated
        /// with the support ticket. This is the Azure service for which the
        /// support ticket was opened.
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets localized name of Azure service.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string ServiceDisplayName { get; set; }

        /// <summary>
        /// Gets status of the support ticket.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string Status { get; set; }

        /// <summary>
        /// Gets time in UTC (ISO 8601 format) when support ticket was created.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets time in UTC (ISO 8601 format) when support ticket was last
        /// modified.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets technical resource id associated with a technical
        /// support ticket request.
        /// </summary>
        public string TechnicalTicketResourceId { get; set; }

        /// <summary>
        /// Gets or sets additional ticket details associated with a quota
        /// support ticket request.
        /// </summary>
        public PSQuotaTicketDetail QuotaTicketDetail { get; set; }
    }
}
