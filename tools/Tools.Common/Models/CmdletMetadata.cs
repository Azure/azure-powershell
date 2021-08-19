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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Tools.Common.Models
{
    /// <summary>
    /// Data about the cmdlet
    /// </summary>
    [Serializable]
    public class CmdletMetadata
    {
        private List<OutputMetadata> _outputTypes = new List<OutputMetadata>();
        private List<ParameterMetadata> _parameters = new List<ParameterMetadata>();
        private List<ParameterSetMetadata> _parameterSets = new List<ParameterSetMetadata>();
        private List<string> _aliases = new List<string>();

        #region ShouldContinueVerbs
        [JsonIgnore]
        private static readonly List<string> ShouldContinueVerbs = new List<string>
        {
             VerbsCommon.Clear,
             VerbsCommon.Copy,
             VerbsData.Edit,
             VerbsData.Export,
             VerbsData.Import,
             VerbsData.Initialize,
             VerbsCommon.Move,
             VerbsCommon.Redo,
             VerbsCommon.Remove,
             VerbsCommon.Rename,
             VerbsDiagnostic.Repair,
             VerbsCommon.Reset,
             VerbsCommon.Resize,
             VerbsLifecycle.Restart,
             VerbsData.Restore,
             VerbsCommon.Set,
             VerbsLifecycle.Stop,
             VerbsLifecycle.Suspend,
             VerbsLifecycle.Uninstall,
             VerbsData.Update,
             VerbsCommunications.Write
      };
        #endregion

        #region ShouldProcessVerbs
        [JsonIgnore]
        private static readonly List<string> ShouldProcessVerbs = new List<string>
        {
            VerbsCommon.Close,
            VerbsData.Compress,
            VerbsLifecycle.Disable,
            VerbsCommunications.Disconnect,
            VerbsData.Dismount,
            VerbsCommon.Exit,
            VerbsCommon.Hide,
            VerbsCommon.Lock,
            VerbsData.Merge,
            VerbsData.Mount,
            VerbsData.Limit,
            VerbsCommon.New,
            VerbsCommon.Optimize,
            VerbsData.Publish,
            VerbsData.Save,
            VerbsData.Sync,
            VerbsCommon.Switch,
            VerbsCommon.Undo,
            VerbsCommon.Unlock,
            VerbsSecurity.Unprotect,
            VerbsData.Unpublish,
            VerbsLifecycle.Unregister,
            VerbsCommon.Add,
            VerbsLifecycle.Approve,
            VerbsData.Backup,
            VerbsData.Checkpoint,
            VerbsLifecycle.Complete,
            VerbsCommunications.Connect,
            VerbsData.Convert,
            VerbsData.ConvertFrom,
            VerbsData.ConvertTo,
            VerbsLifecycle.Deny,
            VerbsLifecycle.Enable,
            VerbsData.Group,
            VerbsCommon.Enter,
            VerbsData.Expand,
            VerbsCommon.Format,
            VerbsLifecycle.Install,
            VerbsLifecycle.Invoke,
            VerbsCommon.Open,
            VerbsCommon.Push,
            VerbsCommon.Pop,
            VerbsCommunications.Read,
            VerbsCommunications.Receive,
            VerbsLifecycle.Register,
            VerbsLifecycle.Request,
            VerbsLifecycle.Resume,
            VerbsCommunications.Send,
            VerbsCommon.Split,
            VerbsLifecycle.Start,
            VerbsLifecycle.Submit,
            VerbsSecurity.Block,
            VerbsSecurity.Grant,
            VerbsSecurity.Protect,
            VerbsSecurity.Revoke,
            VerbsSecurity.Unblock
        };
        #endregion

        #region ApprovedVerbs
        [JsonIgnore]
        private static List<string> ApprovedVerbs;

        private static List<string> GetApprovedVerbs()
        {
            if (ApprovedVerbs == null)
            {
                ApprovedVerbs = new List<string>();

                PowerShell powershell = PowerShell.Create();
                powershell.AddCommand("Get-Verb");

                var cmdletResult = powershell.Invoke();

                foreach (PSObject result in cmdletResult)
                {
                    ApprovedVerbs.Add(result.Members["Verb"].Value.ToString());
                }
            }

            return ApprovedVerbs;
        }
        #endregion

        #region SingularNouns
        [JsonIgnore]
        private static readonly List<string> SingularNouns = new List<string>
        {
            "Access",
            "Address",
            "Alerts",
            "Alias",
            "Anonymous",
            "Assets",
            "Bypass",
            "Credentials",
            "Diagnostics",
            "Dns",
            "Expires",
            "Express",
            "Https",
            "InBytes",
            "InDays",
            "InHours",
            "InMinutes",
            "InMonths",
            "InSeconds",
            "Insights",
            "Loss",
            "Mbps",
            "Permissions",
            "Process",
            "Progress",
            "Properties",
            "ProxyUseDefaultCredentials",
            "SaveAs",
            "Statistics",
            "Status",
            "Success",
            "Vmss",
            "Windows"
        };

        public List<ParameterMetadata> GetParametersWithPluralNoun()
        {
            List<ParameterMetadata> pluralParameters = new List<ParameterMetadata>();
            foreach (var parameter in _parameters)
            {
                if (parameter.Name.EndsWith("s") && SingularNouns.Find(n => parameter.Name.EndsWith(n)) == null)
                {
                    pluralParameters.Add(parameter);
                }
            }

            return pluralParameters;
        }

        #endregion

        /// <summary>
        /// The verb portion of the cmdlet name
        /// </summary>
        public string VerbName { get; set; }

        /// <summary>
        /// The noun portion of the cmdlet name
        /// </summary>
        public string NounName { get; set; }

        /// <summary>
        /// The name of the cmdlet
        /// </summary>
        public string Name { get { return string.Format("{0}-{1}", VerbName, NounName); } }

        /// <summary>
        /// True if the cmdlet should have execution protected by ShouldProcess
        /// </summary>
        [JsonIgnore]
        public bool IsShouldProcessVerb
        {
            get { return VerbName != null && ShouldProcessVerbs.Contains(VerbName) || ShouldContinueVerbs.Contains(VerbName); }
        }

        /// <summary>
        /// True if the cmdlet may have an additional ShouldContinue
        /// </summary>
        [JsonIgnore]
        public bool IsShouldContinueVerb
        {
            get { return VerbName != null && ShouldContinueVerbs.Contains(VerbName); }
        }

        /// <summary>
        /// True if the cmdlet has an approved verb
        /// </summary>
        [JsonIgnore]
        public bool IsApprovedVerb
        {
            get { return VerbName != null && GetApprovedVerbs().Contains(VerbName); }
        }

        /// <summary>
        /// True if the cmdlet has a singular noun
        /// </summary>
        [JsonIgnore]
        public bool HasSingularNoun
        {
            get { return !NounName.EndsWith("s") || SingularNouns.Find(n => NounName.EndsWith(n)) != null; }
        }

        /// <summary>
        /// The name of the class that implements the cmdlet
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Indicates whether the cmdlet may ask for confirmation
        /// </summary>
        public bool SupportsShouldProcess { get; set; }

        /// <summary>
        /// The impact of the operation, used to determine prompting with ShouldProcess
        /// </summary>
        public ConfirmImpact ConfirmImpact { get; set; }

        /// <summary>
        /// Indicates whether the cmdlet has a -Force switch parameter
        /// </summary>
        [JsonIgnore]
        public bool HasForceSwitch { get; set; }

        /// <summary>
        /// Indicates whether the cmdlet supports paging
        /// </summary>
        public bool SupportsPaging { get; set; }

        /// <summary>
        /// The default parameter set for the cmdlet
        /// </summary>
        public string DefaultParameterSetName { get; set; }

        /// <summary>
        /// The default parameter set
        /// </summary>
        [JsonIgnore]
        public ParameterSetMetadata DefaultParameterSet { get { return _parameterSets.Find(p => string.Equals(p.Name, this.DefaultParameterSetName, StringComparison.OrdinalIgnoreCase)); } }

        /// <summary>
        /// The set of output types for the cmdlet
        /// </summary>
        public List<OutputMetadata> OutputTypes { get { return _outputTypes; } }

        /// <summary>
        /// The set of cmdlet parameters
        /// </summary>
        public List<ParameterMetadata> Parameters { get { return _parameters; } }

        /// <summary>
        /// The set of cmdlet parameter sets
        /// </summary>
        public List<ParameterSetMetadata> ParameterSets { get { return _parameterSets; } }

        /// <summary>
        /// The set of aliases
        /// </summary>
        public List<string> AliasList { get { return _aliases; } }

        /// <summary>
        /// Checks if two CmdletMetadata objects are equal by comparing
        /// each of the properties.
        /// </summary>
        /// <param name="other">The CmdletMetadata object being compared to this object.</param>
        /// <returns>True if the two objects are equal, false otherwise.</returns>
        public override bool Equals(Object obj)
        {
            var other = obj as CmdletMetadata;
            if (other == null)
            {
                return false;
            }

            var cmdletsEqual = true;

            cmdletsEqual &= string.Equals(this.Name, other.Name, StringComparison.OrdinalIgnoreCase) &&
                            this.SupportsShouldProcess == other.SupportsShouldProcess &&
                            this.ConfirmImpact == other.ConfirmImpact &&
                            this.SupportsPaging == other.SupportsPaging;
            var thisDefaultSet = _parameterSets.Find(p => string.Equals(p.Name, this.DefaultParameterSetName, StringComparison.OrdinalIgnoreCase));
            var otherDefaultSet = _parameterSets.Find(p => string.Equals(p.Name, other.DefaultParameterSetName, StringComparison.OrdinalIgnoreCase));
            if (thisDefaultSet == null)
            {
                if (otherDefaultSet != null)
                {
                    cmdletsEqual = false;
                }
            }
            else
            {
                if (otherDefaultSet == null)
                {
                    cmdletsEqual = false;
                }
                else
                {
                    cmdletsEqual &= thisDefaultSet.Equals(otherDefaultSet);
                }
            }
            foreach (var thisParameterSet in this.ParameterSets)
            {
                var otherParameterSet = other.ParameterSets.Find(p => string.Equals(p.Name, thisParameterSet.Name, StringComparison.OrdinalIgnoreCase));
                if (otherParameterSet == null)
                {
                    return false;
                }

                cmdletsEqual &= thisParameterSet.Equals(otherParameterSet);
            }

            cmdletsEqual &= this.ParameterSets.Count == other.ParameterSets.Count;
            return cmdletsEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
