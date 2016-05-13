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
using System.IO;

namespace StaticAnalysis
{
    /// <summary>
    /// Simple class for logging errors and warnings to the console and writing reports to the file system.
    /// </summary>
    public class ConsoleLogger : AnalysisLogger
    {

        public ConsoleLogger(string baseDirectory, string exceptionsDirectory)
            : base(baseDirectory, exceptionsDirectory)
        {
        }

        public ConsoleLogger(string baseDirectory)
            : base(baseDirectory)
        {
        }
        public override void WriteError(string error)
        {
            Console.WriteLine("### ERROR {0}", error);
        }

        public override void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public override void WriteWarning(string message)
        {
            Console.WriteLine("Warning: {0}", message);
        }

        public override void WriteReport(string name, string records)
        {
            File.WriteAllText(name, records);
        }
    }
}
