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
using System.Diagnostics;

namespace Microsoft.Azure.Commands.Compute.Extension.AEM
{
    public class AEMTestResult
    {
        private bool? _Result = null;

        public string TestName { get; set; }
        public List<AEMTestResult> PartialResults { get; set; }
        public bool Result
        {
            get
            {
                if (this._Result.HasValue)
                {
                    if (this.PartialResults.Count > 0)
                    {
                        Debug.WriteLine("There should be no partial results.");
                    }

                    return this._Result.Value;
                }
                else if (this.PartialResults.Count > 0)
                {
                    bool partialResult = true;
                    foreach (var partResult in this.PartialResults)
                    {
                        partialResult &= partResult.Result;
                    }

                    return partialResult;
                }

                return false;
            }
            set
            {
                this._Result = value;
            }
        }

        public AEMTestResult()
        {
            this.PartialResults = new List<AEMTestResult>();
        }
        public AEMTestResult(string testName, params string[] args) : this()
        {
            this.TestName = String.Format(testName, args);
        }

        public AEMTestResult(string testName, bool result, params string[] args) : this(testName, args)
        {
            this.Result = result;
        }
    }
}
