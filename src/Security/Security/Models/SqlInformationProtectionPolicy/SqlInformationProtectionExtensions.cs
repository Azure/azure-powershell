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

using Microsoft.Azure.Management.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.SecurityCenter.Models.SqlInformationProtectionPolicy
{
    public static class SqlInformationProtectionExtensions
    {
        public static PSSqlInformationProtectionPolicy ConverToPSType(this InformationProtectionPolicy policy) => new PSSqlInformationProtectionPolicy
        {
            Version = policy.Version,
            InformationTypes = policy.InformationTypes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ConvertToPSType()),
            Labels = policy.Labels.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ConverToPSType())
        };

        public static InformationProtectionPolicy ConverToSDKType(this PSSqlInformationProtectionPolicy policy) => new InformationProtectionPolicy
        {
            InformationTypes = policy.InformationTypes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ConvertToSDKType()),
            Labels = policy.Labels.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ConvertToSDKType())
        };

        public static PSSqlInformationProtectionSensitivityLabel ConverToPSType(this SensitivityLabel sensitivityLabel) => new PSSqlInformationProtectionSensitivityLabel
        {
            DisplayName = sensitivityLabel.DisplayName,
            Description = sensitivityLabel.Description,
            Enabled = sensitivityLabel.Enabled.HasValue ? sensitivityLabel.Enabled.Value : false,
            Order = Convert.ToInt32(sensitivityLabel.Order),
            Rank = sensitivityLabel.Rank.ConvertToPSType()
        };

        public static SensitivityLabel ConvertToSDKType(this PSSqlInformationProtectionSensitivityLabel sensitivityLabel) => new SensitivityLabel
        {
            DisplayName = sensitivityLabel.DisplayName,
            Description = sensitivityLabel.Description,
            Enabled = sensitivityLabel.Enabled,
            Order = Convert.ToInt32(sensitivityLabel.Order),
            Rank = sensitivityLabel.Rank.ConvertToSDKType()
        };

        public static PSSqlInformationProtectionRank? ConvertToPSType(this Rank? rank)
        {
            if (rank.HasValue)
            {
                switch (rank.Value)
                {
                    case Rank.Critical:
                        return PSSqlInformationProtectionRank.Critical;
                    case Rank.High:
                        return PSSqlInformationProtectionRank.High;
                    case Rank.Low:
                        return PSSqlInformationProtectionRank.Low;
                    case Rank.Medium:
                        return PSSqlInformationProtectionRank.Medium;
                    case Rank.None:
                        return PSSqlInformationProtectionRank.None;
                    default:
                        break;
                }
            }

            return null;
        }

        public static Rank? ConvertToSDKType(this PSSqlInformationProtectionRank? rank)
        {
            if (rank.HasValue)
            {
                switch (rank.Value)
                {
                    case PSSqlInformationProtectionRank.Critical:
                        return Rank.Critical;
                    case PSSqlInformationProtectionRank.High:
                        return Rank.High;
                    case PSSqlInformationProtectionRank.Low:
                        return Rank.Low;
                    case PSSqlInformationProtectionRank.Medium:
                        return Rank.Medium;
                    case PSSqlInformationProtectionRank.None:
                        return Rank.None;
                    default:
                        break;
                }
            }

            return null;
        }

        public static PSSqlInformationProtectionInformationType ConvertToPSType(this InformationType informationType) => new PSSqlInformationProtectionInformationType
        {
            Custom = ToBool(informationType.Custom),
            DisplayName = informationType.DisplayName,
            Description = informationType.Description,
            Enabled = ToBool(informationType.Enabled),
            Keywords = informationType.Keywords.Select(k => k.ConvertToPSType()).ToList(),
            Order = Convert.ToInt32(informationType.Order),
            RecommendedLabelId = informationType.RecommendedLabelId
        };

        public static InformationType ConvertToSDKType(this PSSqlInformationProtectionInformationType informationType) => new InformationType
        {
            Custom = informationType.Custom,
            DisplayName = informationType.DisplayName,
            Description = informationType.Description,
            Enabled = informationType.Enabled,
            Keywords = informationType.Keywords.Select(k => k.ConvertToSDKType()).ToList(),
            Order = Convert.ToInt32(informationType.Order),
            RecommendedLabelId = informationType.RecommendedLabelId
        };

        public static PSSqlInformationProtectionKeyword ConvertToPSType(this InformationProtectionKeyword keyword) => new PSSqlInformationProtectionKeyword
        {
            CanBeNumeric = ToBool(keyword.CanBeNumeric),
            Custom = ToBool(keyword.Custom),
            Excluded = ToBool(keyword.Excluded),
            Pattern = keyword.Pattern,
        };

        public static InformationProtectionKeyword ConvertToSDKType(this PSSqlInformationProtectionKeyword keyword) => new InformationProtectionKeyword
        {
            CanBeNumeric = keyword.CanBeNumeric,
            Custom = keyword.Custom,
            Excluded = keyword.Excluded,
            Pattern = keyword.Pattern,
        };

        public static string PrintObject(this object o)
        {
            List<string> valuesPerPropertyName = new List<string>();
            foreach (var property in o.GetType().GetProperties())
            {
                string name = property.Name;
                object value = property.GetValue(o);
                valuesPerPropertyName.Add($"\t{name}: {value}");
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");
            builder.AppendLine(string.Join($",{Environment.NewLine}", valuesPerPropertyName));
            builder.Append("}");

            return builder.ToString();
        }

        private static bool ToBool(bool? b)
        {
            return b.HasValue ? b.Value : false;
        }
    }
}
