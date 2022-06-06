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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using Track2Models = Azure.ResourceManager.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    /// <summary>
    /// Wrapper of SDK type BlobRestoreRange
    /// </summary>
    public class PSBlobRestoreRange
    {
        public string StartRange { get; set; }
        public string EndRange { get; set; }

        public PSBlobRestoreRange()
        { }

        public PSBlobRestoreRange(string startRange, string endRange)
        {
            this.StartRange = startRange;
            this.EndRange = endRange;
        }

        public PSBlobRestoreRange(Track2Models.BlobRestoreRange range)
        {
            this.StartRange = range.StartRange;
            this.EndRange = range.EndRange;
        }

        public static IList<Track2Models.BlobRestoreRange> ParseBlobRestoreRanges(PSBlobRestoreRange[] ranges)
        {
            IList<Track2Models.BlobRestoreRange> re = new List<Track2Models.BlobRestoreRange>();
            if (ranges == null)
            {
                re.Add(
                    new Track2Models.BlobRestoreRange("", ""));
            }
            else
            {
                foreach (PSBlobRestoreRange range in ranges)
                {
                    re.Add(
                        new Track2Models.BlobRestoreRange(range.StartRange, range.EndRange));
                }
            }
            return re;
        }

        public static PSBlobRestoreRange[] ParsePSBlobRestoreRanges(IList<Track2Models.BlobRestoreRange> ranges)
        {
            if (ranges == null)
            {
                return null;
            }

            List<PSBlobRestoreRange> re = new List<PSBlobRestoreRange>();
            foreach (Track2Models.BlobRestoreRange range in ranges)
            {
                re.Add(
                    new PSBlobRestoreRange
                    {
                        StartRange = range.StartRange,
                        EndRange = range.EndRange
                    });
            }
            return re.ToArray();
        }
    }

    /// <summary>
    /// Wrapper of SDK type BlobRestoreStatus
    /// </summary>
    public class PSBlobRestoreStatus
    {
        [Ps1Xml(Label = "Status", Target = ViewControl.Table, Position = 0)]
        public string Status { get; }
        [Ps1Xml(Label = "FailureReason", Target = ViewControl.Table, Position = 2)]
        public string FailureReason { get; }
        [Ps1Xml(Label = "RestoreId", Target = ViewControl.Table, Position = 1)]
        public string RestoreId { get; }
        [Ps1Xml(Label = "Parameters.TimeToRestore", Target = ViewControl.Table, ScriptBlock = "$_.Parameters.TimeToRestore", Position = 3)]
        [Ps1Xml(Label = "Parameters.BlobRanges", Target = ViewControl.Table, ScriptBlock = "if ($s.Parameters.BlobRanges[0] -ne $null) {if ($s.Parameters.BlobRanges[1] -ne $null) {'[' + $s.Parameters.BlobRanges[0].StartRange + ' -> ' + $s.Parameters.BlobRanges[0].EndRange  + ',...]'} else {'[' + $s.Parameters.BlobRanges[0].StartRange + ' -> ' + $s.Parameters.BlobRanges[0].EndRange  + ']'}} else {$null}", Position = 4)]
        public PSBlobRestoreParameters Parameters { get; }

        public PSBlobRestoreStatus()
        { }

        public PSBlobRestoreStatus(Track2Models.BlobRestoreStatus status)
        {
            if (status != null)
            {
                this.Status = status.Status != null ? status.Status.ToString() : null;
                this.FailureReason = status.FailureReason;
                this.RestoreId = status.RestoreId;
                this.Parameters = status.Parameters is null ? null : new PSBlobRestoreParameters(status.Parameters);
            }
        }

        public PSBlobRestoreStatus(string status, string failureReason, string restoreId, PSBlobRestoreParameters parameters)
        {
            Status = status;
            FailureReason = failureReason;
            RestoreId = restoreId;
            Parameters = parameters;
        }
    }

    /// <summary>
    /// Wrapper of SDK type BlobRestoreParameters
    /// </summary>
    public class PSBlobRestoreParameters
    {
        public DateTimeOffset TimeToRestore { get; set; }
        public PSBlobRestoreRange[] BlobRanges { get; set; }

        public PSBlobRestoreParameters()
        { }

        public PSBlobRestoreParameters(Track2Models.BlobRestoreContent parameters)
        {
            this.TimeToRestore = parameters.TimeToRestore;
            this.BlobRanges = PSBlobRestoreRange.ParsePSBlobRestoreRanges(parameters.BlobRanges);
        }
    }
}

