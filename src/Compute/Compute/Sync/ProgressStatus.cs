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

namespace Microsoft.WindowsAzure.Commands.Sync
{
    public class ProgressStatus
    {
        const double MB = 1024.0 * 1024.0;
        readonly object thisLock = new object();

        public ProgressStatus(long alreadyProcessedBytes, long totalLength) : this(alreadyProcessedBytes, totalLength, new ComputeStats())
        {
        }

        public ProgressStatus(long alreadyProcessedBytes, long totalLength, ComputeStats computeStats)
        {
            this.PreExistingBytes = alreadyProcessedBytes;
            this.BytesProcessed = alreadyProcessedBytes;
            this.TotalLength = totalLength;
            this.ThrougputStats = computeStats;
            this.StartTime = DateTime.UtcNow;
        }

        long PreExistingBytes { get; set; }
        internal long BytesProcessed { get; private set; }
        long TotalLength { get; set; }
        DateTime StartTime { get; set; }
        ComputeStats ThrougputStats { get; set; }

        public bool TryGetProgressRecord(out ProgressRecord record)
        {
            record = null;
            lock (thisLock)
            {
                if (HasProgess())
                {
                    record = Progress();
                    return true;
                }
            }
            return false;
        }

        public void AddToProcessedBytes(long size)
        {
            lock (thisLock)
            {
                this.BytesProcessed += size;
            }
        }

        bool HasProgess()
        {
            return this.BytesProcessed > this.PreExistingBytes;
        }

        ProgressRecord Progress()
        {
            double computeAvg = ThrougputStats.ComputeAvg(ThroughputMBs());
            double avtThroughputMbps = 8.0 * computeAvg;
            double remainingSeconds = (RemainingMB() / computeAvg);
            var pr = new ProgressRecord
            {
                PercentComplete = PercentComplete(),
                AvgThroughputMbPerSecond = avtThroughputMbps,
                RemainingTime = TimeSpan.FromSeconds(remainingSeconds)
            };
            return pr;
        }

        double RemainingMB()
        {
            return (this.TotalLength - this.BytesProcessed) / MB;
        }

        double ThroughputMBs()
        {
            return (this.BytesProcessed - this.PreExistingBytes) / MB / ProcessTime().TotalSeconds;
        }

        TimeSpan ProcessTime()
        {
            return DateTime.UtcNow - this.StartTime;
        }

        double PercentComplete()
        {
            return 100.0 * this.BytesProcessed / ((double)this.TotalLength);
        }
    }
}