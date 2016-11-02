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

using Microsoft.Diagnostics.Tracing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.Azure.Commands.Compute.Properties;

namespace Microsoft.VisualStudio.EtwListener.Common.Contracts
{
    [DataContract]
    internal class ProviderConfiguration
    {
        public static readonly TraceEventLevel DefaultEventLevel = TraceEventLevel.Verbose;
        public static readonly ulong AllKeywords = ulong.MaxValue;
        private static string FieldSeparator = ":";
        private static string ProcessListSeparator = "/";
        private static string ProcessIdSeparator = ",";
        private static string HexadecimalNumberPrefix = "0x";

        public ProviderConfiguration()
        {
            this.MaximumEventLevel = DefaultEventLevel;
            this.EnabledKeywords = AllKeywords;
        }

        [DataMember]
        public Guid ProviderGuid { get; set; }

        [DataMember]
        public string ProviderName { get; set; }

        [DataMember]
        public TraceEventLevel MaximumEventLevel { get; set; }

        [DataMember]
        public ulong EnabledKeywords { get; set; }

        [DataMember]
        public IList<int> ProcessIDFilter { get; set; }

        public static ProviderConfiguration Create(string line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            var retval = new ProviderConfiguration();

            // BUG 
            // The following code probably does not work if process names contain any of the separator characters
            // That is fine because we are only using process IDs for now.

            List<int> processIdList = new List<int>();
            int processListStart = line.LastIndexOf(ProcessListSeparator, StringComparison.Ordinal);
            if (processListStart > 0)
            {
                string[] processIDs = line.Substring(processListStart + 1).Split(new string[] { ProcessIdSeparator }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string pid in processIDs)
                {
                    int pidNumber;
                    if (!int.TryParse(pid, NumberStyles.Integer, CultureInfo.InvariantCulture, out pidNumber))
                    {
                        throw new FormatException(string.Format(CultureInfo.InvariantCulture, Resources.InvalidNumberFormat, pid, typeof(int).Name));
                    }

                    processIdList.Add(pidNumber);
                }

                line = line.Substring(0, processListStart);
            }

            retval.ProcessIDFilter = processIdList;

            string[] fields = line.Split(new string[] { FieldSeparator }, StringSplitOptions.RemoveEmptyEntries);
            switch (fields.Length)
            {
                case 3:
                    string keywordsStr = fields[2];
                    if (keywordsStr.StartsWith(HexadecimalNumberPrefix, StringComparison.OrdinalIgnoreCase))
                    {
                        keywordsStr = keywordsStr.Substring(HexadecimalNumberPrefix.Length);
                    }

                    ulong nums;
                    if (!ulong.TryParse(keywordsStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out nums))
                    {
                        throw new FormatException(string.Format(CultureInfo.InvariantCulture, Resources.InvalidNumberFormat, keywordsStr, typeof(ulong).Name));
                    }

                    retval.EnabledKeywords = nums;
                    goto case 2;

                case 2:
                    int level;
                    if (!int.TryParse(fields[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out level))
                    {
                        throw new FormatException(string.Format(CultureInfo.InvariantCulture, Resources.InvalidNumberFormat, fields[1], typeof(int).Name));
                    }

                    retval.MaximumEventLevel = (TraceEventLevel)level;
                    goto case 1;

                case 1:
                    Guid providerGuid;
                    if (Guid.TryParse(fields[0], out providerGuid))
                    {
                        retval.ProviderGuid = providerGuid;
                    }
                    else
                    {
                        retval.ProviderName = fields[0];
                    }
                    break;

                default:
                    throw new FormatException(nameof(line));
            }

            return retval;
        }
    }
}
