using Microsoft.Azure.Management.Security.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions
{
    public static class PSIotSecuritySolutionsConverters
    {
        public static PSIotSecuritySolution ConvertToPSType(this IoTSecuritySolutionModel value)
        {
            return new PSIotSecuritySolution()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Tags = value.Tags,
                Location = value.Location,
                Workspace = value.Workspace,
                DisplayName = value.DisplayName,
                Status = value.Status,
                Export = value.Export,
                DisabledDataSources = value.DisabledDataSources,
                IotHubs = value.IotHubs,
                UserDefinedResources = value.UserDefinedResources.ConvertToPSType(),
                AutoDiscoveredResources = value.AutoDiscoveredResources,
                RecommendationsConfiguration = value.RecommendationsConfiguration.ConvertToPSType(),
                UnmaskedIpLoggingStatus = value.UnmaskedIpLoggingStatus
            };
        }

        public static List<PSIotSecuritySolution> ConvertToPSType(this IEnumerable<IoTSecuritySolutionModel> value)
        {
            return value.Select(solution => solution.ConvertToPSType()).ToList();
        }

        public static PSUserDefinedResources ConvertToPSType(this UserDefinedResourcesProperties value)
        {
            return new PSUserDefinedResources()
            {
                Query = value.Query,
                QuerySubscriptions = value.QuerySubscriptions
            };
        }

        public static PSRecommendationConfiguration ConvertToPSType(this RecommendationConfigurationProperties value)
        {
            return new PSRecommendationConfiguration()
            {
                RecommendationType = value.RecommendationType,
                Name = value.Name,
                Status = value.Status
            };
        }

        public static List<PSRecommendationConfiguration> ConvertToPSType(this IEnumerable<RecommendationConfigurationProperties> value)
        {
            return value.Select(rec => rec.ConvertToPSType()).ToList();
        }


        // Convert FROM Powershell type
        public static IoTSecuritySolutionModel CreatePSType(this PSIotSecuritySolution value)
        {
            return new IoTSecuritySolutionModel()
            {
                Tags = value.Tags,
                Location = value.Location,
                Workspace = value.Workspace,
                DisplayName = value.DisplayName,
                Status = value.Status,
                Export = value.Export,
                DisabledDataSources = value.DisabledDataSources,
                IotHubs = value.IotHubs,
                UserDefinedResources = value.UserDefinedResources?.CreatePSType(),
                RecommendationsConfiguration = value.RecommendationsConfiguration?.CreatePSType(),
                UnmaskedIpLoggingStatus = value.UnmaskedIpLoggingStatus
            };
        }

        public static List<IoTSecuritySolutionModel> CreatePSType(this IEnumerable<PSIotSecuritySolution> value)
        {
            return value.Select(solution => solution.CreatePSType()).ToList();
        }

        public static UserDefinedResourcesProperties CreatePSType(this PSUserDefinedResources value)
        {
            return new UserDefinedResourcesProperties()
            {
                Query = value.Query,
                QuerySubscriptions = value.QuerySubscriptions
            };
        }

        public static RecommendationConfigurationProperties CreatePSType(this PSRecommendationConfiguration value)
        {
            return new RecommendationConfigurationProperties()
            {
                RecommendationType = value.RecommendationType,
                Status = value.Status
            };
        }

        public static List<RecommendationConfigurationProperties> CreatePSType(this IEnumerable<PSRecommendationConfiguration> value)
        {
            return value.Select(rec => rec.CreatePSType()).ToList();
        }

    }
}
