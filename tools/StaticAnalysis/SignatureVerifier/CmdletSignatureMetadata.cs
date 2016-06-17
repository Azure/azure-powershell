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

using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace StaticAnalysis.SignatureVerifier
{
    /// <summary>
    /// Data about the cmdlet signature
    /// </summary>
    [Serializable]
    public class CmdletSignatureMetadata
    {
        private IList<OutputMetadata> _outputTypes = new List<OutputMetadata>();
        private IList<ParameterMetadata> _parameters = new List<ParameterMetadata>();

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
            VerbsDiagnostic.Resolve,
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
        public bool IsShouldProcessVerb
        {
            get { return VerbName != null && ShouldProcessVerbs.Contains(VerbName) || ShouldContinueVerbs.Contains(VerbName); }
        }

        /// <summary>
        /// True if the cmdlet may have an additional ShouldContinue
        /// </summary>
        public bool IsShouldContinueVerb
        {
            get { return VerbName != null && ShouldContinueVerbs.Contains(VerbName); }
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
        /// The impact of the operation, used to determine prompting with SHouldProcess
        /// </summary>
        public ConfirmImpact ConfirmImpact { get; set; }

        /// <summary>
        /// Indicates whether the cmdlet has a -Force switch parameter
        /// </summary>
        public bool HasForceSwitch { get; set; }

        /// <summary>
        /// The set of output types for the cmdlet
        /// </summary>
        public IList<OutputMetadata> OutputTypes { get { return _outputTypes; } }

        /// <summary>
        /// The set of cmdlet parameters
        /// </summary>
        public IList<ParameterMetadata> Parameters { get { return _parameters; } }

    }
}