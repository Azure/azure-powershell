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
using System.Linq;
using System.Threading.Tasks;
using StaticAnalysis.OutputValidator;

namespace StaticAnalysis
{
    public class ConsoleLogger : IToolsLogger
    {
        private List<ValidationRecord> _records = new List<ValidationRecord>();
        private Decorator<ValidationRecord> _decorator = Decorator<ValidationRecord>.Create();

        public Decorator<ValidationRecord> Decorator { get { return _decorator; } }
        public IList<ValidationRecord> Records { get { return _records; } }
        public void WriteError(string error)
        {
            Console.WriteLine($"### ERROR {error}");
        }

        public void WriteMessage(string message)
        {
            //Console.WriteLine(message);
        }

        public void WriteWarning(string message)
        {
            Console.WriteLine($"Warning: {message}");
        }

        public void LogRecord(ValidationRecord record)
        {
            Decorator.Apply(record);
            _records.Add(record);
        }
    }
}
