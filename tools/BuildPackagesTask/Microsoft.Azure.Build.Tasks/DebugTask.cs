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

namespace Microsoft.Azure.Build.Tasks
{
    using Microsoft.Build.Utilities;
    using System;
    using ThreadTask = System.Threading.Tasks;



    /// <summary>
    /// Utility task to help debug
    /// </summary>
    public class DebugTask : Microsoft.Build.Utilities.Task
    {
        public int Timeoutmiliseconds { get; set; }
        public override bool Execute()
        {
            if (Timeoutmiliseconds == 0) Timeoutmiliseconds = 20000;
            Console.WriteLine("Press any key to continue or it will continue in {0} miliseconds", Timeoutmiliseconds);
            System.Threading.Thread.Sleep(Timeoutmiliseconds);
            return true;
        }
    }
}
