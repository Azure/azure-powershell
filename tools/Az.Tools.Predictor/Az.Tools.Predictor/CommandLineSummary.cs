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

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// The summary of the commands used in <see cref="CommandLinePredictor" />.
    /// </summary>
    /// <param name="ReceivedCommandCount">The number of commands that the predictor receives.</param>
    /// <param name="ValidCommandCount">The number of commands that are valid and can be used by the predictor.</param>
    /// <param name="Errors">The errors we encounter when we try to parse the command line.</param>
    public record CommandLineSummary(int ReceivedCommandCount, int ValidCommandCount, IEnumerable<string> Errors);
}
