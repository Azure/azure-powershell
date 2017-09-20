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

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public class VhdTimeStamp
    {
        private static readonly DateTime VhdBaseTime = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private readonly uint value;

        public VhdTimeStamp(DateTime dateTime)
        {
            if (dateTime < VhdBaseTime)
            {
                var message = String.Format("DateTime must be after Base Vhd Time: {0}", VhdBaseTime);
                throw new ArgumentOutOfRangeException("dateTime", message);
            }

            this.TotalSeconds = (uint)dateTime.Subtract(VhdBaseTime).TotalSeconds;
        }

        public VhdTimeStamp(uint value)
        {
            this.value = value;
        }

        public uint TotalSeconds { get; private set; }

        public DateTime ToDateTime()
        {
            return VhdBaseTime.AddSeconds(value).ToUniversalTime();
        }
    }
}