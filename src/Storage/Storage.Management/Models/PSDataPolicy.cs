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

using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    /// <summary>
    /// Wrapper of SDK type ManagementPolicy
    /// </summary>
    public class PSManagementPolicy
    {
        public PSManagementPolicy()
        { }

        public PSManagementPolicy(ManagementPolicy policy, string ResourceGroupName, string StorageAccountName)
        {
            this.ResourceGroupName = ResourceGroupName;
            this.StorageAccountName = StorageAccountName;
            this.Id = policy.Id;
            this.Name = policy.Name;
            this.Type = policy.Type;
            this.LastModifiedTime = policy.LastModifiedTime;
            this.Rules = PSManagementPolicyRule.GetPSManagementPolicyRules(policy.Policy.Rules);
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
        public DateTime? LastModifiedTime { get; set; }
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

        public PSManagementPolicyRule(ManagementPolicyRule rule)
        {
            this.Enabled = rule.Enabled;
            this.Name = rule.Name;
            this.Definition = rule.Definition is null ? null : new PSManagementPolicyDefinition(rule.Definition);
        }

        public ManagementPolicyRule ParseManagementPolicyRule()
        {
            ManagementPolicyRule rule = new ManagementPolicyRule();
            rule.Enabled = this.Enabled;
            rule.Name = this.Name;
            rule.Definition = this.Definition is null ? null : this.Definition.ParseManagementPolicyDefination();
            return rule;
        }

        public static PSManagementPolicyRule[] GetPSManagementPolicyRules(IList<ManagementPolicyRule> rules)
        {
            if (rules == null)
            {
                return null;
            }
            List<PSManagementPolicyRule> psrules = new List<PSManagementPolicyRule>();
            foreach (ManagementPolicyRule rule in rules)
            {
                psrules.Add(new PSManagementPolicyRule(rule));
            }
            return psrules.ToArray();
        }

        public static List<ManagementPolicyRule> ParseManagementPolicyRules(PSManagementPolicyRule[] psrules)
        {
            if (psrules == null)
            {
                return null;
            }
            List<ManagementPolicyRule> rules = new List<ManagementPolicyRule>();
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

        public PSManagementPolicyDefinition(ManagementPolicyDefinition defination)
        {
            this.Actions = defination.Actions is null ? null : new PSManagementPolicyActionGroup(defination.Actions);
            this.Filters = defination.Filters is null ? null : new PSManagementPolicyRuleFilter(defination.Filters);
        }
        public ManagementPolicyDefinition ParseManagementPolicyDefination()
        {
            return new ManagementPolicyDefinition()
            {
                Actions = this.Actions is null ? null : this.Actions.ParseManagementPolicyAction(),
                Filters = this.Filters is null ? null : this.Filters.ParseManagementPolicyFilter()
            };
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

        public PSManagementPolicyRuleFilter(ManagementPolicyFilter filter)
        {
            this.PrefixMatch = StringListToArray(filter.PrefixMatch);
            this.BlobTypes = StringListToArray(filter.BlobTypes);
        }
        public ManagementPolicyFilter ParseManagementPolicyFilter()
        {
            return new ManagementPolicyFilter()
            {
                PrefixMatch = StringArrayToList(this.PrefixMatch),
                BlobTypes = StringArrayToList(this.BlobTypes),
            };
        }

        public static string[] StringListToArray(IList<string> list)
        {
            return (list is null ? null : ((List<string>)list).ToArray());
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

        public PSManagementPolicyActionGroup(ManagementPolicyAction action)
        {
            this.BaseBlob = (action is null || action.BaseBlob is null) ? null : new PSManagementPolicyBaseBlob(action.BaseBlob);
            this.Snapshot = (action is null || action.Snapshot is null) ? null : new PSManagementPolicySnapShot(action.Snapshot);
            this.Version = (action is null || action.Version is null) ? null : new PSManagementPolicyVersion(action.Version);
        }
        public ManagementPolicyAction ParseManagementPolicyAction()
        {
            return new ManagementPolicyAction()
            {
                BaseBlob = this.BaseBlob is null ? null : this.BaseBlob.ParseManagementPolicyBaseBlob(),
                Snapshot = this.Snapshot is null ? null : this.Snapshot.ParseManagementPolicySnapShot(),
                Version = this.Version is null ? null : this.Version.ParseManagementPolicyVersion(),
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

        public PSManagementPolicyBaseBlob(ManagementPolicyBaseBlob blobAction)
        {
            this.TierToCool = blobAction.TierToCool is null ? null : new PSDateAfterModification(blobAction.TierToCool);
            this.TierToArchive = blobAction.TierToArchive is null ? null : new PSDateAfterModification(blobAction.TierToArchive);
            this.Delete = blobAction.Delete is null ? null : new PSDateAfterModification(blobAction.Delete);
            this.EnableAutoTierToHotFromCool = blobAction.EnableAutoTierToHotFromCool;
        }
        public ManagementPolicyBaseBlob ParseManagementPolicyBaseBlob()
        {
            return new ManagementPolicyBaseBlob()
            {
                TierToCool = this.TierToCool is null ? null : this.TierToCool.ParseDateAfterModification(),
                TierToArchive = this.TierToArchive is null ? null : this.TierToArchive.ParseDateAfterModification(),
                Delete = this.Delete is null ? null : this.Delete.ParseDateAfterModification(),
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

        public PSManagementPolicySnapShot(ManagementPolicySnapShot blobAction)
        {
            this.Delete = blobAction.Delete is null ? null : new PSDateAfterCreation(blobAction.Delete);
            this.TierToCool = blobAction.TierToCool is null ? null : new PSDateAfterCreation(blobAction.TierToCool);
            this.TierToArchive = blobAction.TierToArchive is null ? null : new PSDateAfterCreation(blobAction.TierToArchive);
        }
        public ManagementPolicySnapShot ParseManagementPolicySnapShot()
        {
            return new ManagementPolicySnapShot()
            {
                Delete = this.Delete is null ? null : this.Delete.ParseDateAfterCreation(),
                TierToCool = this.TierToCool is null ? null : this.TierToCool.ParseDateAfterCreation(),
                TierToArchive = this.TierToArchive is null ? null : this.TierToArchive.ParseDateAfterCreation()
            };
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

        public PSManagementPolicyVersion(ManagementPolicyVersion blobAction)
        {
            this.Delete = blobAction.Delete is null ? null : new PSDateAfterCreation(blobAction.Delete);
            this.TierToCool = blobAction.TierToCool is null ? null : new PSDateAfterCreation(blobAction.TierToCool);
            this.TierToArchive = blobAction.TierToArchive is null ? null : new PSDateAfterCreation(blobAction.TierToArchive);
        }
        public ManagementPolicyVersion ParseManagementPolicyVersion()
        {
            return new ManagementPolicyVersion()
            {
                Delete = this.Delete is null ? null : this.Delete.ParseDateAfterCreation(),
                TierToCool = this.TierToCool is null ? null : this.TierToCool.ParseDateAfterCreation(),
                TierToArchive = this.TierToArchive is null ? null : this.TierToArchive.ParseDateAfterCreation()
            };
        }
    }

    /// <summary>
    /// Wrapper of SDK type DateAfterModification
    /// </summary>
    public class PSDateAfterModification
    {
        public int? DaysAfterModificationGreaterThan { get; set; }
        public int? DaysAfterLastAccessTimeGreaterThan { get; set; }
        public int? DaysAfterCreationGreaterThan { get; set; }
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

        public PSDateAfterModification(int? daysAfterModificationGreaterThan, int? daysAfterLastAccessTimeGreaterThan, int? DaysAfterLastTierChangeGreaterThan, int? DaysAfterCreationGreaterThan)
        {
            this.DaysAfterModificationGreaterThan = daysAfterModificationGreaterThan;
            this.DaysAfterLastAccessTimeGreaterThan = daysAfterLastAccessTimeGreaterThan;
            this.DaysAfterLastTierChangeGreaterThan = DaysAfterLastTierChangeGreaterThan;
            this.DaysAfterCreationGreaterThan = DaysAfterCreationGreaterThan;
        }

        public PSDateAfterModification(DateAfterModification data)
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
            if (data.DaysAfterLastTierChangeGreaterThan is null)
            {
                this.DaysAfterLastTierChangeGreaterThan = null;
            }
            else
            {
                this.DaysAfterLastTierChangeGreaterThan = Convert.ToInt32(data.DaysAfterLastTierChangeGreaterThan);
            }
            if (data.DaysAfterCreationGreaterThan is null)
            {
                this.DaysAfterCreationGreaterThan = null;
            }
            else
            {
                this.DaysAfterCreationGreaterThan = Convert.ToInt32(data.DaysAfterCreationGreaterThan);
            }
        }
        public DateAfterModification ParseDateAfterModification()
        {
            return new DateAfterModification(this.DaysAfterModificationGreaterThan, 
                this.DaysAfterLastAccessTimeGreaterThan, 
                this.DaysAfterLastTierChangeGreaterThan, 
                this.DaysAfterCreationGreaterThan);
        }
    }


    /// <summary>
    /// Wrapper of SDK type DateAfterCreation
    /// </summary>
    public class PSDateAfterCreation
    {
        public int DaysAfterCreationGreaterThan { get; set; }
        public int? DaysAfterLastTierChangeGreaterThan { get; set; }

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

        public PSDateAfterCreation(DateAfterCreation data)
        {
            this.DaysAfterCreationGreaterThan = Convert.ToInt32(data.DaysAfterCreationGreaterThan);
            if (data.DaysAfterLastTierChangeGreaterThan is null)
            {
                this.DaysAfterLastTierChangeGreaterThan = null;
            }
            else
            {
                this.DaysAfterLastTierChangeGreaterThan = Convert.ToInt32(data.DaysAfterLastTierChangeGreaterThan);
            }
        }
        public DateAfterCreation ParseDateAfterCreation()
        {
            return new DateAfterCreation(this.DaysAfterCreationGreaterThan, this.DaysAfterLastTierChangeGreaterThan);
        }
    }

}
