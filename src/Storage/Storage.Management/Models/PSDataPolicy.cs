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

using Azure.ResourceManager.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    /// <summary>
    /// Wrapper of SDK type ManagementPolicy
    /// </summary>
    public class PSManagementPolicy
    {
        public PSManagementPolicy()
        { }

        public PSManagementPolicy(Track2.ManagementPolicyResource policyResource, string resourceGroupName, string storageAccountName)
        {
            this.ResourceGroupName = resourceGroupName;
            this.StorageAccountName = storageAccountName;
            this.Id = policyResource.Id;
            this.Name = policyResource.Data.Name;
            this.Type = Track2.ManagementPolicyResource.ResourceType.ToString();
            this.LastModifiedTime = policyResource.Data.LastModifiedOn;
            this.Rules = PSManagementPolicyRule.GetPSManagementPolicyRules(policyResource.Data.Rules);
        }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.List, Position = 0)]
        public string ResourceGroupName { get; set; }
        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.List, Position = 1)]
        public string StorageAccountName { get; set; }
        [Ps1Xml(Label = "Id", Target = ViewControl.List, Position = 2)]
        public string Id { get; set; }
        public string Name { get; set; }
        [Ps1Xml(Label = "Type", Target = ViewControl.List, Position = 3)]
        public string Type { get; set; }
        [Ps1Xml(Label = "LastModifiedTime", Target = ViewControl.List, Position = 4)]
        public DateTimeOffset? LastModifiedTime { get; set; }
        [Ps1Xml(Label = "Rules", Target = ViewControl.List, ScriptBlock = "ConvertTo-Json $_ -Depth 10", Position = 5)]
        public PSManagementPolicyRule[] Rules { get; set; }
    }

    /// <summary>
    /// Wrapper of SDK type ManagementPolicyRule
    /// </summary>
    public class PSManagementPolicyRule
    {
        public bool? Enabled { get; set; }
        public string Name { get; set; }
        public PSManagementPolicyDefinition Definition { get; set; }

        public PSManagementPolicyRule()
        {
        }

        public PSManagementPolicyRule(Track2Models.ManagementPolicyRule rule)
        {
            this.Enabled = rule.Enabled;
            this.Name = rule.Name;
            this.Definition = rule.Definition is null ? null : new PSManagementPolicyDefinition(rule.Definition);
        }

        public Track2Models.ManagementPolicyRule ParseManagementPolicyRule()
        {
            Track2Models.ManagementPolicyRule rule = new Track2Models.ManagementPolicyRule(
                this.Name,
                RuleType.Lifecycle,
                this.Definition?.ParseManagementPolicyDefination()
                );
            rule.Enabled = this.Enabled;
            return rule;
        }

        public static PSManagementPolicyRule[] GetPSManagementPolicyRules(IList<Track2Models.ManagementPolicyRule> rules)
        {
            if (rules == null)
            {
                return null;
            }
            List<PSManagementPolicyRule> psrules = new List<PSManagementPolicyRule>();
            foreach (Track2Models.ManagementPolicyRule rule in rules)
            {
                psrules.Add(new PSManagementPolicyRule(rule));
            }
            return psrules.ToArray();
        }

        public static List<Track2Models.ManagementPolicyRule> ParseManagementPolicyRules(PSManagementPolicyRule[] psrules)
        {
            if (psrules == null)
            {
                return null;
            }
            List<Track2Models.ManagementPolicyRule> rules = new List<Track2Models.ManagementPolicyRule>();
            foreach (PSManagementPolicyRule psrule in psrules)
            {
                rules.Add(psrule.ParseManagementPolicyRule());
            }
            return rules;
        }
    }

    /// <summary>
    /// Wrapper of SDK type ManagementPolicyDefinition
    /// </summary>
    public class PSManagementPolicyDefinition
    {
        public PSManagementPolicyActionGroup Actions { get; set; }
        public PSManagementPolicyRuleFilter Filters { get; set; }

        public PSManagementPolicyDefinition()
        {
        }

        public PSManagementPolicyDefinition(Track2Models.ManagementPolicyDefinition defination)
        {
            this.Actions = defination.Actions is null ? null : new PSManagementPolicyActionGroup(defination.Actions);
            this.Filters = defination.Filters is null ? null : new PSManagementPolicyRuleFilter(defination.Filters);
        }
        public Track2Models.ManagementPolicyDefinition ParseManagementPolicyDefination()
        {
            Track2Models.ManagementPolicyAction actions = this.Actions?.ParseManagementPolicyAction();
            Track2Models.ManagementPolicyDefinition policyDefinition = new Track2Models.ManagementPolicyDefinition(actions);
            policyDefinition.Filters = this.Filters?.ParseManagementPolicyFilter();

            return policyDefinition;
        }

        public static string[] StringListToArray(IList<string> list)
        {
            return (list is null ? null : ((List<string>)list).ToArray());
        }
    }

    /// <summary>
    /// Wrapper of SDK type ManagementPolicyFilter
    /// </summary>
    public class PSManagementPolicyRuleFilter
    {
        public string[] PrefixMatch { get; set; }
        public string[] BlobTypes { get; set; }

        public PSManagementPolicyRuleFilter()
        { }

        public PSManagementPolicyRuleFilter(Track2Models.ManagementPolicyFilter filter)
        {
            this.PrefixMatch = StringListToArray(filter.PrefixMatch);
            this.BlobTypes = StringListToArray(filter.BlobTypes);
        }
        public Track2Models.ManagementPolicyFilter ParseManagementPolicyFilter()
        {
            Track2Models.ManagementPolicyFilter policyFilter = new Track2Models.ManagementPolicyFilter(StringArrayToList(this.BlobTypes));
            if (this.PrefixMatch != null)
            {
                foreach (string prefixMatch in this.PrefixMatch)
                {
                    policyFilter.PrefixMatch.Add(prefixMatch);
                }
            }
            return policyFilter;
        }

        public static string[] StringListToArray(IList<string> list)
        {
            if (list is null)
            {
                return null;
            }

            var result = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                result[i] = list[i].ToString();
            }
            return result;
        }

        public static List<string> StringArrayToList(string[] array)
        {
            return (array is null ? null : new List<string>(array));
        }
    }

    /// <summary>
    /// Wrapper of SDK type ManagementPolicyAction
    /// </summary>
    public class PSManagementPolicyActionGroup
    {
        public PSManagementPolicyBaseBlob BaseBlob { get; set; }
        public PSManagementPolicySnapShot Snapshot { get; set; }
        public PSManagementPolicyVersion Version { get; set; }

        public PSManagementPolicyActionGroup()
        { }

        public PSManagementPolicyActionGroup(Track2Models.ManagementPolicyAction action)
        {
            this.BaseBlob = (action is null || action.BaseBlob is null) ? null : new PSManagementPolicyBaseBlob(action.BaseBlob);
            this.Snapshot = (action is null || action.Snapshot is null) ? null : new PSManagementPolicySnapShot(action.Snapshot);
            this.Version = (action is null || action.Version is null) ? null : new PSManagementPolicyVersion(action.Version);
        }
        public Track2Models.ManagementPolicyAction ParseManagementPolicyAction()
        {
            return new Track2Models.ManagementPolicyAction()
            {
                BaseBlob = this.BaseBlob?.ParseManagementPolicyBaseBlob(),
                Snapshot = this.Snapshot?.ParseManagementPolicySnapShot(),
                Version = this.Version?.ParseManagementPolicyVersion(),
            };
        }
    }

    /// <summary>
    /// Wrapper of SDK type ManagementPolicyBaseBlob
    /// </summary>
    public class PSManagementPolicyBaseBlob
    {
        public PSDateAfterModification TierToCool { get; set; }
        public PSDateAfterModification TierToArchive { get; set; }
        public PSDateAfterModification Delete { get; set; }
        public bool? EnableAutoTierToHotFromCool { get; set; }

        public PSManagementPolicyBaseBlob()
        { }

        public PSManagementPolicyBaseBlob(Track2Models.ManagementPolicyBaseBlob blobAction)
        {
            this.TierToCool = blobAction.TierToCool is null ? null : new PSDateAfterModification(blobAction.TierToCool);
            this.TierToArchive = blobAction.TierToArchive is null ? null : new PSDateAfterModification(blobAction.TierToArchive);
            this.Delete = blobAction.Delete is null ? null : new PSDateAfterModification(blobAction.Delete);
            this.EnableAutoTierToHotFromCool = blobAction.EnableAutoTierToHotFromCool;
        }
        public Track2Models.ManagementPolicyBaseBlob ParseManagementPolicyBaseBlob()
        {
            return new Track2Models.ManagementPolicyBaseBlob()
            {
                TierToCool = this.TierToCool?.ParseDateAfterModification(),
                TierToArchive = this.TierToArchive?.ParseDateAfterModification(),
                Delete = this.Delete?.ParseDateAfterModification(),
                EnableAutoTierToHotFromCool = this.EnableAutoTierToHotFromCool
            };
        }
    }

    /// <summary>
    /// Wrapper of SDK type ManagementPolicySnapShot
    /// </summary>
    public class PSManagementPolicySnapShot
    {
        public PSDateAfterCreation Delete { get; set; }
        public PSDateAfterCreation TierToCool { get; set; }
        public PSDateAfterCreation TierToArchive { get; set; }

        public PSManagementPolicySnapShot()
        { }

        public PSManagementPolicySnapShot(Track2Models.ManagementPolicySnapShot blobAction)
        {

            this.Delete = blobAction.Delete is null ? null : new PSDateAfterCreation((int)blobAction.Delete.DaysAfterCreationGreaterThan);
            this.TierToCool = blobAction.TierToCool is null ? null : new PSDateAfterCreation((int)blobAction.TierToCool.DaysAfterCreationGreaterThan);
            TierToArchive = blobAction.TierToArchive is null ? null : new PSDateAfterCreation((int)blobAction.TierToArchive.DaysAfterCreationGreaterThan);
        }
        public Track2Models.ManagementPolicySnapShot ParseManagementPolicySnapShot()
        {

            Track2Models.ManagementPolicySnapShot snapShot = new Track2Models.ManagementPolicySnapShot();

            if (this.Delete != null)
            {
                snapShot.Delete = new Track2Models.DateAfterCreation(this.Delete.DaysAfterCreationGreaterThan);
            }
            if (this.TierToCool != null)
            {
                snapShot.TierToCool = new Track2Models.DateAfterCreation(this.TierToCool.DaysAfterCreationGreaterThan);
            }
            if (this.TierToArchive != null)
            {
                snapShot.TierToArchive = new Track2Models.DateAfterCreation(this.TierToArchive.DaysAfterCreationGreaterThan);
            }

            return snapShot;
        }
    }

    /// <summary>
    /// Wrapper of SDK type ManagementPolicySnapShot
    /// </summary>
    public class PSManagementPolicyVersion
    {
        public PSDateAfterCreation Delete { get; set; }
        public PSDateAfterCreation TierToCool { get; set; }
        public PSDateAfterCreation TierToArchive { get; set; }

        public PSManagementPolicyVersion()
        { }

        public PSManagementPolicyVersion(Track2Models.ManagementPolicyVersion blobAction)
        {
            this.Delete = blobAction.Delete is null ? null : new PSDateAfterCreation((int)blobAction.Delete.DaysAfterCreationGreaterThan);
            this.TierToCool = blobAction.TierToCool is null ? null :new PSDateAfterCreation((int)blobAction.TierToCool.DaysAfterCreationGreaterThan);
            this.TierToArchive = blobAction.TierToArchive is null ? null : new PSDateAfterCreation((int)blobAction.TierToArchive.DaysAfterCreationGreaterThan);
        }
        public Track2Models.ManagementPolicyVersion ParseManagementPolicyVersion()
        {
            Track2Models.ManagementPolicyVersion policyVersion = new Track2Models.ManagementPolicyVersion();
            if (this.Delete != null)
            {
                policyVersion.Delete = new DateAfterCreation(this.Delete.DaysAfterCreationGreaterThan);
            }
            if (this.TierToCool != null)
            {
                policyVersion.TierToCool = new DateAfterCreation(this.TierToCool.DaysAfterCreationGreaterThan);
            }
            if (this.TierToArchive != null)
            {
                policyVersion.TierToArchive = new DateAfterCreation(this.TierToArchive.DaysAfterCreationGreaterThan);
            }

            return policyVersion;
        }
    }

    /// <summary>
    /// Wrapper of SDK type DateAfterModification
    /// </summary>
    public class PSDateAfterModification
    {
        public int? DaysAfterModificationGreaterThan { get; set; }
        public int? DaysAfterLastAccessTimeGreaterThan { get; set; }

        // TODO: DaysAfterLastTierChangeGreaterThan it not supported by SDK yet. Will add later.
        public int? DaysAfterLastTierChangeGreaterThan { get; set; }

        public PSDateAfterModification()
        {
            this.DaysAfterModificationGreaterThan = null;
            this.DaysAfterLastAccessTimeGreaterThan = null;
        }

        public PSDateAfterModification(int daysAfterModificationGreaterThan)
        {
            this.DaysAfterModificationGreaterThan = daysAfterModificationGreaterThan;
            this.DaysAfterLastAccessTimeGreaterThan = null;
        }

        public PSDateAfterModification(int? daysAfterModificationGreaterThan, int? daysAfterLastAccessTimeGreaterThan)
        {
            this.DaysAfterModificationGreaterThan = daysAfterModificationGreaterThan;
            this.DaysAfterLastAccessTimeGreaterThan = daysAfterLastAccessTimeGreaterThan;
        }

        public PSDateAfterModification(int? daysAfterModificationGreaterThan, int? daysAfterLastAccessTimeGreaterThan, int? DaysAfterLastTierChangeGreaterThan)
        {
            this.DaysAfterModificationGreaterThan = daysAfterModificationGreaterThan;
            this.DaysAfterLastAccessTimeGreaterThan = daysAfterLastAccessTimeGreaterThan;
            this.DaysAfterLastTierChangeGreaterThan = DaysAfterLastTierChangeGreaterThan;
        }

        public PSDateAfterModification(Track2Models.DateAfterModification data)
        {
            if (data.DaysAfterModificationGreaterThan is null)
            {
                this.DaysAfterModificationGreaterThan = null;
            }
            else
            {
                this.DaysAfterModificationGreaterThan = Convert.ToInt32(data.DaysAfterModificationGreaterThan);
            }
            if (data.DaysAfterLastAccessTimeGreaterThan is null)
            {
                this.DaysAfterLastAccessTimeGreaterThan = null;
            }
            else
            {
                this.DaysAfterLastAccessTimeGreaterThan = Convert.ToInt32(data.DaysAfterLastAccessTimeGreaterThan);
            }
        }
        public Track2Models.DateAfterModification ParseDateAfterModification()
        {
            Track2Models.DateAfterModification dateAfterModification = new Track2Models.DateAfterModification();
            dateAfterModification.DaysAfterLastAccessTimeGreaterThan = this.DaysAfterLastAccessTimeGreaterThan;
            dateAfterModification.DaysAfterModificationGreaterThan = this.DaysAfterModificationGreaterThan;
            // TODO: Add DaysAfterLastTierChangeGreaterThan once supported by Track2 SDK
            return dateAfterModification;

        }
    }


    /// <summary>
    /// Wrapper of SDK type DateAfterCreation
    /// </summary>
    public class PSDateAfterCreation
    {
        public int DaysAfterCreationGreaterThan { get; set; }
        public int? DaysAfterLastTierChangeGreaterThan { get; set; }

        // TODO: DaysAfterLastTierChangeGreaterThan is still not supported by SDK, will add later.

        public PSDateAfterCreation()
        {
            this.DaysAfterCreationGreaterThan = 0;
        }

        public PSDateAfterCreation(int daysAfterCreationGreaterThan)
        {
            this.DaysAfterCreationGreaterThan = daysAfterCreationGreaterThan;
        }
        public PSDateAfterCreation(int daysAfterCreationGreaterThan, int? DaysAfterLastTierChangeGreaterThan)
        {
            this.DaysAfterCreationGreaterThan = daysAfterCreationGreaterThan;
            this.DaysAfterLastTierChangeGreaterThan = DaysAfterLastTierChangeGreaterThan;
        }
    }
}
