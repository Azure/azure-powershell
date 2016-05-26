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
using System.Xml.Linq;

namespace StaticAnalysis.HelpAnalyzer
{
    /// <summary>
    /// Parse the cmdlet help file
    /// </summary>
    public class CmdletHelpParser
    {
        public const string MamlSchemaUri = "http://schemas.microsoft.com/maml/2004/10";
        public const string MamlDevSchemaUri = "http://schemas.microsoft.com/maml/dev/2004/10";
        public const string CommandSchemaUri = "http://schemas.microsoft.com/maml/dev/command/2004/10";
        const int MissingCommandName = 5000;
        const int MissingCommandDetails = 5010;
        const int InvalidHelpFile = 5020;
        public static IList<string> GetHelpTopics(string helpPath, ReportLogger<HelpIssue> logger)
        {
            IList<string> cmdlets = new List<string>();
            try
            {
                XDocument document = XDocument.Parse(File.ReadAllText(helpPath));
                var root = document.Root;
                foreach (var command in root.GetChildElements("command"))
                {
                    if (command.ContainsChildElement("details"))
                    {
                        var details = command.GetChildElement("details");
                        if (details.ContainsChildElement("name"))
                        {
                            cmdlets.Add(details.GetChildElement("name").Value.Trim());
                        }
                        else
                        {
                            logger.LogRecord(new HelpIssue
                          {
                              HelpFile = helpPath,
                              Severity = 0,
                              ProblemId = MissingCommandName,
                              Description = string.Format("Missing command:name element for file {0}", helpPath),
                              Remediation = "Correct the xml format of the help file"
                          });

                        }
                    }
                    else
                    {

                        logger.LogRecord(new HelpIssue
                        {
                            HelpFile = helpPath,
                            Severity = 0,
                            ProblemId = MissingCommandDetails,
                            Description = string.Format("Missing command:details element for file {0}", helpPath),
                            Remediation = "Correct the xml format of the help file"
                        });
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogRecord(new HelpIssue
                {
                    HelpFile = helpPath,
                    Severity = 0,
                    ProblemId = InvalidHelpFile,
                    Description = string.Format("Parsing error for help file {0}: {1}", helpPath, e.ToString()),
                    Remediation = "Correct the xml format of the help file"
                });
            }

            return cmdlets;
        }
    }
}
