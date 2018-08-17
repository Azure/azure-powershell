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

namespace Microsoft.Azure.Commands.TrafficManager.Models
{
    using Microsoft.Azure.Management.TrafficManager.Models;
    using System.Text;

    public class TrafficManagerExpectedStatusCodeRange
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public MonitorConfigExpectedStatusCodeRangesItem ToSDKMonitorConfigStatusCodeRangesItem()
        {
            return new MonitorConfigExpectedStatusCodeRangesItem
            {
                Min = this.Min,
                Max = this.Max,
            };
        }

        /// <remarks>
        /// Since this class does not handle null elements, this function returns null if either element is null.
        /// Calling function must handle null return value in that case.
        /// </remarks>
        public static TrafficManagerExpectedStatusCodeRange FromSDKMonitorConfigStatusCodeRangesItem(
            MonitorConfigExpectedStatusCodeRangesItem monitorConfigStatusCodeRangesItem)
        {
            if (monitorConfigStatusCodeRangesItem.Min == null || monitorConfigStatusCodeRangesItem.Max == null)
            {
                return null;
            }

            return new TrafficManagerExpectedStatusCodeRange
            {
                Min = (int)monitorConfigStatusCodeRangesItem.Min,
                Max = (int)monitorConfigStatusCodeRangesItem.Max,
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" {");
            sb.Append($"Min:{this.Min}, Max:{this.Max}");
            sb.Append("} ");
            return sb.ToString();
        }
    }
}
