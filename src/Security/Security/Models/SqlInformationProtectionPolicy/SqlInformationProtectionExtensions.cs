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
        public static PSSqlInformationProtectionPolicy ToPSSqlInformationProtectionPolicy(this InformationProtectionPolicy policy)
        {
            Dictionary<Guid, List<PSSqlInformationProtectionPolicyInformationType>> infoTypesPerLabelId =
                policy.Labels.Keys.Select(id => Guid.Parse(id)).ToDictionary(id => id, id => new List<PSSqlInformationProtectionPolicyInformationType>());

            foreach (var idInformationTypePair in policy.InformationTypes)
            {
                if (idInformationTypePair.Value.RecommendedLabelId.HasValue)
                {
                    Guid sensitivityLabelId = idInformationTypePair.Value.RecommendedLabelId.Value;
                    if (!infoTypesPerLabelId.ContainsKey(sensitivityLabelId))
                    {
                        throw new Exception(string.Format(
                            Resources.SqlInformationProtectionPolicyAssociatedLabelIdNotFoundError,
                            idInformationTypePair.Value.DisplayName, sensitivityLabelId));
                    }

                    infoTypesPerLabelId[sensitivityLabelId].Add(idInformationTypePair.ToPSSqlInformationProtectionPolicyInformationType());
                }
            }

            return new PSSqlInformationProtectionPolicy
            {
                Labels = policy.Labels.Select(idSensitivityLabelPair => idSensitivityLabelPair.ToPSSqlInformationProtectionPolicySensitivityLabel(infoTypesPerLabelId[Guid.Parse(idSensitivityLabelPair.Key)])).ToArray()
            };
        }

        public static PSSqlInformationProtectionPolicySensitivityLabel ToPSSqlInformationProtectionPolicySensitivityLabel(this KeyValuePair<string, SensitivityLabel> idSensitivityLabelPair,
            List<PSSqlInformationProtectionPolicyInformationType> informationTypes) => new PSSqlInformationProtectionPolicySensitivityLabel
            {
                Id = Guid.Parse(idSensitivityLabelPair.Key),
                DisplayName = idSensitivityLabelPair.Value.DisplayName,
                Order = idSensitivityLabelPair.Value.Order.HasValue ? Convert.ToInt32(idSensitivityLabelPair.Value.Order.Value) : (int?)null,
                Enabled = idSensitivityLabelPair.Value.Enabled.HasValue ? idSensitivityLabelPair.Value.Enabled.Value : false,
                InformationTypes = informationTypes.ToArray(),
            };

        public static PSSqlSensitivityLabel ToPSSqlSensitivityLabel(this KeyValuePair<string, SensitivityLabel> idLabelPair, InformationProtectionPolicy policy) => new PSSqlSensitivityLabel
        {
            DisplayName = idLabelPair.Value.DisplayName,
            Order = idLabelPair.Value.Order,
            State = idLabelPair.Value.Enabled == true ? PSSqlSensitivityObjectState.Enabled : PSSqlSensitivityObjectState.Disabled,
            InformationTypes = policy.InformationTypes.Values
                .Where(iT => iT.RecommendedLabelId.HasValue && iT.RecommendedLabelId.Value.ToString().Equals(idLabelPair.Key))
                .Select(it => it.DisplayName)
                .ToArray()
        };

        public static PSSqlInformationProtectionPolicyInformationType ToPSSqlInformationProtectionPolicyInformationType(this KeyValuePair<string, InformationType> idInformationTypePair) => new PSSqlInformationProtectionPolicyInformationType
        {
            Id = Guid.Parse(idInformationTypePair.Key),
            DisplayName = idInformationTypePair.Value.DisplayName,
            Enabled = idInformationTypePair.Value.Enabled,
            Order = idInformationTypePair.Value.Order.HasValue ? Convert.ToInt32(idInformationTypePair.Value.Order.Value) : (int?)null,
            Custom = idInformationTypePair.Value.Custom,
            Keywords = idInformationTypePair.Value.Keywords.Select(k => k.ToPSSqlInformationProtectionPolicyKeyword()).ToArray()
        };

        public static PSSqlInformationType ToPSSqlInformationType(this InformationType informationType, Management.Security.Models.InformationProtectionPolicy policy) => new PSSqlInformationType
        {
            DisplayName = informationType.DisplayName,
            State = informationType.Enabled == true ? PSSqlSensitivityObjectState.Enabled : PSSqlSensitivityObjectState.Disabled,
            Order = informationType.Order,
            AssociatedLabel = informationType.GetAssociatedLabelName(policy),
            Type = informationType.Custom == true ? PSSqlSensitivityObjectType.Custom : PSSqlSensitivityObjectType.BuiltIn,
            Keywords = informationType.Keywords.Select(k => k.ToPSSqlInformationProtectionKeyword()).ToList()
        };

        public static PSSqlInformationProtectionPolicyKeyword ToPSSqlInformationProtectionPolicyKeyword(this InformationProtectionKeyword keyword) => new PSSqlInformationProtectionPolicyKeyword
        {
            Pattern = keyword.Pattern,
            CanBeNumeric = keyword.CanBeNumeric.HasValue ? keyword.CanBeNumeric.Value : false,
            Custom = keyword.Custom,
            Excluded = keyword.Excluded,
        };

        public static PSSqlInformationProtectionKeyword ToPSSqlInformationProtectionKeyword(this InformationProtectionKeyword keyword) => new PSSqlInformationProtectionKeyword
        {
            Pattern = keyword.Pattern,
            State = keyword.Excluded == true ? PSSqlSensitivityObjectState.Disabled : PSSqlSensitivityObjectState.Enabled,
            Type = keyword.Custom == true ? PSSqlSensitivityObjectType.Custom : PSSqlSensitivityObjectType.BuiltIn,
            AllowNumeric = keyword.CanBeNumeric == true
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

        private static string GetAssociatedLabelName(this InformationType informationType, InformationProtectionPolicy policy)
        {
            Guid? recommendedLabelId = informationType.RecommendedLabelId;
            return (!recommendedLabelId.HasValue || recommendedLabelId.Value == Guid.Empty) ? null :
                policy.Labels[recommendedLabelId.Value.ToString()].DisplayName;
        }
    }
}
