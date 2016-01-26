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
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using StaticAnalysis.AliasValidator;
using StaticAnalysis.OutputValidator;
using StaticAnalysis.HelpGenerator;

namespace StaticAnalysis
{
    public class Program
    {
        public static int MaxSeverity = 0;
        public static readonly string[] Modules = new string[]
        {
            "Microsoft.Azure.Commands.Compute",
            "Microsoft.Azure.Commands.Management.Storage",
            "Microsoft.Azure.Commands.Profile",
            "Microsoft.Azure.Commands.Resources",
            "Microsoft.Azure.Commands.Websites",
            "Microsoft.Azure.Commands.Network",
            "Commands.ResourceManager.Cmdlets"
        };

        public static readonly IAssemblyActor[] Actors = new IAssemblyActor[]
        {
            new CmdletOutputActor(),
            new CmdletAliasActor(),
            new CmdletHelpGenerator()
        };

        public IToolsLogger Logger { get; set; }
        public void Main(string[] args)
        {
            var cluDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..");
            var testDirectory = Environment.GetEnvironmentVariable("CLUDirectory");
            if ( Directory.Exists(testDirectory) && Directory.Exists(Path.Combine(testDirectory, 
                "Microsoft.Azure.Commands.Profile")))
            {
                cluDirectory = testDirectory;
            }
            var reportFile = Path.Combine(cluDirectory, "artifacts", "outputTypes.csv");
            if (args != null && args.Length > 0)
            {
                if (!int.TryParse(args[0], out MaxSeverity))
                {
                    MaxSeverity = 0;
                }

                if (args.Length > 1)
                {
                    if (Directory.Exists(Path.GetDirectoryName(args[1])))
                    {
                        reportFile = args[1];
                    }
                }
            }
            Logger = new ConsoleLogger();
            foreach (var assemblyIdentity in Modules)
            {
                Logger.Decorator.AddDecorator(r => r.Assembly = assemblyIdentity, "Assembly");
                var moduleDirectory = Path.Combine(cluDirectory, assemblyIdentity);
                foreach (var  validator in Actors)
                {
                    Logger.Decorator.AddDecorator(r => r.Validator =  validator.Name, "Validator");
                    validator.Logger = Logger;
                    validator.ExecuteAssemblyAction(moduleDirectory, assemblyIdentity);
                    Logger.Decorator.Remove("Validator");
                }
                Logger.Decorator.Remove("Assembly");
            }


            Console.WriteLine("Processing Complete");
            var records = Logger.Records;
            if (records != null && records.Any())
            {
                using (var writer = new StreamWriter(File.OpenWrite(reportFile)))
                {
                    writer.WriteLine(records[0].PrintHeaders());
                    foreach (var record in records)
                    {
                        writer.WriteLine(record.ToString());
                    }
                }
            }

            if (records.Any(r => r.Severity < MaxSeverity))
            {
                throw new InvalidOperationException($"Cmdlet validation produced one or more errors. Check {reportFile} for details.");
            }
        }

    }
}
