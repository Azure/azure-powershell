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

using Microsoft.Azure.Commands.Support.Models;
using Microsoft.Azure.Management.Support.Models;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.Azure.Commands.Support.Helpers
{
    public static class ModelExtensions
    {
        public static PSSupportService ToPSSupportService(this Service sdkService)
        {
            Debug.Assert(sdkService.DisplayName != null, "sdkService.DisplayName != null");

            return new PSSupportService
            {
                Id = sdkService.Id,
                Name = sdkService.Name,
                Type = sdkService.Type,
                DisplayName = sdkService.DisplayName,
                ResourceTypes = sdkService.ResourceTypes?.ToArray()
            };
        }

        public static PSSupportProblemClassification ToPSSupportProblemClassification(this ProblemClassification sdkProblemClassification)
        {
            Debug.Assert(sdkProblemClassification.DisplayName != null, "sdkProblemClassification.DisplayName != null");

            return new PSSupportProblemClassification
            {
                Id = sdkProblemClassification.Id,
                Name = sdkProblemClassification.Name,
                Type = sdkProblemClassification.Type,
                DisplayName = sdkProblemClassification.DisplayName
            };
        }

        public static PSSupportTicket ToPSSupportTicket(this SupportTicketDetails sdkSupportTicketDetails)
        {
            return new PSSupportTicket
            {
                Id = sdkSupportTicketDetails.Id,
                Name = sdkSupportTicketDetails.Name,
                Type = sdkSupportTicketDetails.Type,
                Title = sdkSupportTicketDetails.Title,
                Description = sdkSupportTicketDetails.Description,
                SupportTicketId = sdkSupportTicketDetails.SupportTicketId,
                ServiceId = sdkSupportTicketDetails.ServiceId,
                ServiceDisplayName = sdkSupportTicketDetails.ServiceDisplayName,
                ProblemClassificationId = sdkSupportTicketDetails.ProblemClassificationId,
                ProblemClassificationDisplayName = sdkSupportTicketDetails.ProblemClassificationDisplayName,
                Severity = sdkSupportTicketDetails.Severity,
                Require24X7Response = sdkSupportTicketDetails.Require24X7Response,
                ProblemStartTime = sdkSupportTicketDetails.ProblemStartTime,
                CreatedDate = sdkSupportTicketDetails.CreatedDate,
                ModifiedDate = sdkSupportTicketDetails.ModifiedDate,
                SupportPlanType = sdkSupportTicketDetails.SupportPlanType,
                EnrollmentId = sdkSupportTicketDetails.EnrollmentId,
                Status = sdkSupportTicketDetails.Status,
                ContactDetail = sdkSupportTicketDetails.ContactDetails.ToPSContactProfile(),
                ServiceLevelAgreement = sdkSupportTicketDetails.ServiceLevelAgreement.ToPSServiceLevelAgreement(),
                SupportEngineer = sdkSupportTicketDetails.SupportEngineer.ToPSSupportEngineer(),
                TechnicalTicketResourceId = sdkSupportTicketDetails.TechnicalTicketDetails?.ResourceId,
                QuotaTicketDetail = sdkSupportTicketDetails.QuotaTicketDetails.ToPSQuotaTicketDetails()
            };
        }

        public static SupportTicketDetails ToSdkSupportTicket(this PSSupportTicket psSupportTicketDetails)
        {
            return new SupportTicketDetails
            {
                Title = psSupportTicketDetails.Title,
                Description = psSupportTicketDetails.Description,
                SupportTicketId = psSupportTicketDetails.SupportTicketId,
                ServiceId = psSupportTicketDetails.ServiceId,
                ProblemClassificationId = psSupportTicketDetails.ProblemClassificationId,
                Severity = psSupportTicketDetails.Severity,
                Require24X7Response = psSupportTicketDetails.Require24X7Response,
                ProblemStartTime = psSupportTicketDetails.ProblemStartTime,
                ContactDetails = psSupportTicketDetails.ContactDetail.ToContactProfile(),
                TechnicalTicketDetails = !string.IsNullOrWhiteSpace(psSupportTicketDetails.TechnicalTicketResourceId) ?
                    new TechnicalTicketDetails
                    {
                        ResourceId = psSupportTicketDetails.TechnicalTicketResourceId
                    } :
                    null,
                QuotaTicketDetails = psSupportTicketDetails.QuotaTicketDetail.ToQuotaTicketDetails()
            };
        }

        public static PSQuotaChangeRequest ToPSQuotaChangeRequest(this QuotaChangeRequest sdkQuotaChangeRequest)
        {
            if (sdkQuotaChangeRequest == null)
            {
                return null;
            }

            return new PSQuotaChangeRequest
            {
                Region = sdkQuotaChangeRequest.Region,
                Payload = sdkQuotaChangeRequest.Payload
            };
        }

        public static QuotaChangeRequest ToQuotaChangeRequest(this PSQuotaChangeRequest psQuotaChangeRequest)
        {
            if (psQuotaChangeRequest == null)
            {
                return null;
            }

            return new QuotaChangeRequest
            {
                Region = psQuotaChangeRequest.Region,
                Payload = psQuotaChangeRequest.Payload
            };
        }


        public static PSQuotaTicketDetail ToPSQuotaTicketDetails(this QuotaTicketDetails sdkQuotaTicketDetails)
        {
            if (sdkQuotaTicketDetails == null)
            {
                return null;
            }

            return new PSQuotaTicketDetail
            {
                QuotaChangeRequestVersion = sdkQuotaTicketDetails.QuotaChangeRequestVersion,
                QuotaChangeRequestSubType = sdkQuotaTicketDetails.QuotaChangeRequestSubType,
                QuotaChangeRequests = sdkQuotaTicketDetails.QuotaChangeRequests.Select(x => x.ToPSQuotaChangeRequest()).ToArray()
            };
        }

        public static QuotaTicketDetails ToQuotaTicketDetails(this PSQuotaTicketDetail psQuotaTicketDetails)
        {
            if (psQuotaTicketDetails == null)
            {
                return null;
            }

            return new QuotaTicketDetails
            {
                QuotaChangeRequestVersion = psQuotaTicketDetails.QuotaChangeRequestVersion,
                QuotaChangeRequestSubType = psQuotaTicketDetails.QuotaChangeRequestSubType,
                QuotaChangeRequests = psQuotaTicketDetails.QuotaChangeRequests.Select(x => x.ToQuotaChangeRequest()).ToList()
            };
        }

        public static PSServiceLevelAgreement ToPSServiceLevelAgreement(this ServiceLevelAgreement sdkServiceLevelAgreement)
        {
            if (sdkServiceLevelAgreement == null)
            {
                return null;
            }

            return new PSServiceLevelAgreement
            {
                StartTime = sdkServiceLevelAgreement.StartTime,
                ExpirationTime = sdkServiceLevelAgreement.ExpirationTime,
                SlaMinutes = sdkServiceLevelAgreement.SlaMinutes
            };
        }

        public static PSSupportEngineer ToPSSupportEngineer(this SupportEngineer sdkSupportEngineer)
        {
            if (sdkSupportEngineer == null)
            {
                return null;
            }

            return new PSSupportEngineer
            {
                EmailAddress = sdkSupportEngineer.EmailAddress
            };
        }

        public static PSContactProfile ToPSContactProfile(this ContactProfile sdkContactProfile)
        {
            if (sdkContactProfile == null)
            {
                return null;
            }

            return new PSContactProfile
            {
                FirstName = sdkContactProfile.FirstName,
                LastName = sdkContactProfile.LastName,
                PhoneNumber = sdkContactProfile.PhoneNumber,
                Country = sdkContactProfile.Country,
                PreferredContactMethod = sdkContactProfile.PreferredContactMethod,
                PreferredTimeZone = sdkContactProfile.PreferredTimeZone,
                PreferredSupportLanguage = sdkContactProfile.PreferredSupportLanguage,
                PrimaryEmailAddress = sdkContactProfile.PrimaryEmailAddress,
                AdditionalEmailAddresses = sdkContactProfile.AdditionalEmailAddresses?.ToArray()
            };
        }

        public static ContactProfile ToContactProfile(this PSContactProfile psContactProfile)
        {
            if (psContactProfile == null)
            {
                return null;
            }

            return new ContactProfile
            {
                FirstName = psContactProfile.FirstName,
                LastName = psContactProfile.LastName,
                PhoneNumber = psContactProfile.PhoneNumber,
                Country = psContactProfile.Country,
                PreferredContactMethod = psContactProfile.PreferredContactMethod,
                PreferredTimeZone = psContactProfile.PreferredTimeZone,
                PreferredSupportLanguage = psContactProfile.PreferredSupportLanguage,
                PrimaryEmailAddress = psContactProfile.PrimaryEmailAddress,
                AdditionalEmailAddresses = psContactProfile.AdditionalEmailAddresses?.ToList()
            };
        }

        public static PSSupportTicketCommunication ToPSSupportTicketCommunication(this CommunicationDetails sdkCommunication)
        {
            if (sdkCommunication == null)
            {
                return null;
            }

            return new PSSupportTicketCommunication
            {
                Id = sdkCommunication.Id,
                Name = sdkCommunication.Name,
                Type = sdkCommunication.Type,
                Subject = sdkCommunication.Subject,
                Body = sdkCommunication.Body,
                Sender = sdkCommunication.Sender,
                CommunicationDirection = sdkCommunication.CommunicationDirection,
                CommunicationType = sdkCommunication.CommunicationType,
                CreatedDate = sdkCommunication.CreatedDate
            };
        }

        public static UpdateContactProfile ToSdkContactProfile(this PSContactProfile contactProfile)
        {
            if (contactProfile == null)
            {
                return null;
            }

            return new UpdateContactProfile
            {
                FirstName = contactProfile.FirstName,
                LastName = contactProfile.LastName,
                PhoneNumber = contactProfile.PhoneNumber,
                Country = contactProfile.Country,
                PreferredContactMethod = contactProfile.PreferredContactMethod,
                PreferredTimeZone = contactProfile.PreferredTimeZone,
                PreferredSupportLanguage = contactProfile.PreferredSupportLanguage,
                PrimaryEmailAddress = contactProfile.PrimaryEmailAddress,
                AdditionalEmailAddresses = contactProfile.AdditionalEmailAddresses
            };
        }
    }
}
