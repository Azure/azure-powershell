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

using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Sync
{
    public class ComputeStats
    {
        IList<double> history;
        int historySize;

        public ComputeStats() : this(60)
        {
        }

        public ComputeStats(int historySize)
        {
            history = new List<double>(historySize);
            this.historySize = historySize;
        }

        public double ComputeAvg(double current)
        {
            if (history.Count > historySize)
            {
                history.RemoveAt(0);
            }
            history.Add(current);
            double sum = 0.0;
            foreach (var x in history)
            {
                sum += x;
            }
            return sum / history.Count;
        }
    }
}


