//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    /// <summary>
    /// A simple Microsoft Build task used to generate a list of test assemblies to be
    /// used for testing Azure PowerShell.
    /// </summary>
    public class CIFilterTask : Task
    {
        /// <summary>
        /// Gets or sets the files changed in a given pull request.
        /// </summary>
        [Required]
        public string[] FilesChanged { get; set; }

        /// <summary>
        /// Gets or set the TargetModule, e.g. Storage
        /// </summary>
        public string TargetModule { get; set; }

        /// <summary>
        /// Gets or set the Mode, e.g. Release
        /// </summary>
        [Required]
        public string Mode { get; set; }

        /// <summary>
        ///  Gets or sets the path to the files-to-csproj map.
        /// </summary>
        [Required]
        public string CsprojMapFilePath { get; set; }

        /// <summary>
        /// Gets or sets the test assemblies output produced by the task.
        /// </summary>
        [Output]
        public CIFilterTaskResult FilterTaskResult { get; set; }

        private const string TaskMappingConfigName = ".ci-config.json";

        private const string AllModule = "all";
        private const string SingleModule = "module";
        private const string DependenceModule = "dependence-module"; // self and modules dependent on this module
        private const string DependentModule = "dependent-module"; // self and modules that self dependent on
        private const string RelatedModule = "related-module"; // self, modules that self dependent on and modules dependent on this module

        private const string BUILD_PHASE = "build";
        private const string TEST_PHASE = "test";
        private readonly List<string> ANALYSIS_PHASE_LIST = new List<string>() { "breaking-change", "help-example", "help", "dependency", "signature", "file-change", "ux" };
        private readonly List<string> ONLY_AFFECT_MODULE_PHASE_LIST = new List<string>() { "cmdlet-diff" }; // These phases will be triggered only when the module is modified, not when its dependent module is updated.
        private const string ACCOUNT_MODULE_NAME = "Accounts";

        private const string MODULE_NAME_PLACEHOLDER = "ModuleName";

        private const int OCTOKIT_CHANGED_FILE_LIMIT = 3000; // Octokit only can get the first 3000 changed files in a PR.

        private Dictionary<string, string[]> ReadMapFile(string mapFilePath, string mapFileName)
        {
            if (mapFilePath == null)
            {
                throw new ArgumentNullException(string.Format("The {0} cannot be null.", mapFileName));
            }

            if (!File.Exists(mapFilePath))
            {
                throw new FileNotFoundException(string.Format("The {0} provided could not be found. Please provide a valid MapFilePath.", mapFileName));
            }

            return JsonConvert.DeserializeObject<Dictionary<string, string[]>>(File.ReadAllText(mapFilePath));
        }

        private List<string> GetRelatedCsprojList(string moduleName, Dictionary<string, string[]> csprojMap)
        {
            List<string> csprojList = new List<string>();

            if (csprojMap.ContainsKey(moduleName))
            {
                csprojList.AddRange(csprojMap[moduleName]);
            }
            else
            {
                string expectKey = string.Format("src/{0}/", moduleName);
                foreach (string key in csprojMap.Keys)
                {
                    if (key.ToLower().Equals(expectKey.ToLower()))
                    {
                        csprojList.AddRange(csprojMap[key]);
                    }
                }
            }

            return csprojList;
        }

        private List<string> GetBuildCsprojList(string moduleName, Dictionary<string, string[]> csprojMap)
        {
            return GetRelatedCsprojList(moduleName, csprojMap)
                .Where(x => !x.Contains("Test")).ToList();
        }

        private string GetModuleNameFromCsprojPath(string csprojPath)
        {
            return csprojPath.Replace('/', '\\')
                .Split(new string[] { "src\\" }, StringSplitOptions.None)[1]
                .Split('\\')[0];
        }

        private List<string> GetDependenceModuleList(string moduleName, Dictionary<string, string[]> csprojMap)
        {
            if (moduleName.Equals(ACCOUNT_MODULE_NAME))
            {
                return GetSelectedModuleList();
            }
            List<string> moduleList = new List<string>();

            foreach (string key in csprojMap.Keys)
            {
                bool isDependent = false;
                foreach (string csproj in csprojMap[key])
                {
                    if (csproj.Replace("/", "\\").Contains("\\" + moduleName + "\\"))
                    {
                        isDependent = true;
                    }
                }
                if (isDependent)
                {
                    moduleList.Add(key.Split('/')[1]);
                }
            }

            return moduleList;
        }

        private List<string> GetDependentModuleList(string moduleName, Dictionary<string, string[]> csprojMap)
        {
            return GetRelatedCsprojList(moduleName, csprojMap)
                .Select(GetModuleNameFromCsprojPath)
                .Distinct()
                .ToList();
        }

        // Run a selected module list instead of run all the modules to speed up the CI process.
        private List<string> GetSelectedModuleList()
        {
            CIPhaseFilterConfig config = GetCIPhaseFilterConfig();
            return config.SelectModuleList;
        }

        private List<string> GetTestCsprojList(string moduleName, Dictionary<string, string[]> csprojMap)
        {
            List<string> csprojList = GetRelatedCsprojList(moduleName, csprojMap)
                .Where(x => x.Contains("Test")).ToList();
            if (csprojList.Count == 0)
            {
                csprojList.Add(moduleName);
            }
            return csprojList;
        }

        private bool ProcessTargetModule(Dictionary<string, string[]> csprojMap)
        {
            Dictionary<string, HashSet<string>> influencedModuleInfo = new Dictionary<string, HashSet<string>>
            {
                [BUILD_PHASE] = new HashSet<string>(GetBuildCsprojList(TargetModule, csprojMap).ToList()),
                [TEST_PHASE] = new HashSet<string>(GetTestCsprojList(TargetModule, csprojMap).ToList())
            };
            foreach (var analysisPhase in ANALYSIS_PHASE_LIST)
            {
                influencedModuleInfo.Add(analysisPhase, new HashSet<string>(GetDependenceModuleList(TargetModule, csprojMap).ToList()));
            }

            Console.WriteLine("----------------- InfluencedModuleInfo TargetModule -----------------");
            foreach (string phaseName in influencedModuleInfo.Keys)
            {
                Console.WriteLine(string.Format("{0}: [{1}]", phaseName, string.Join(", ", influencedModuleInfo[phaseName].ToList())));
            }
            Console.WriteLine("--------------------------------------------------------");

            FilterTaskResult.PhaseInfo = influencedModuleInfo;

            return true;
        }

        private string ProcessSinglePattern(string pattern)
        {
            return pattern.Replace(".", "\\.").Replace("*", ".*").Replace("{ModuleName}", "(?<ModuleName>[^/]+)");
        }

        private Dictionary<string, HashSet<string>> CalculateInfluencedModuleInfoForEachPhase(List<(Regex, List<string>)> ruleList, Dictionary<string, string[]> csprojMap)
        {
            Dictionary<string, HashSet<string>> influencedModuleInfo = new Dictionary<string, HashSet<string>>();

            foreach (string filePath in FilesChanged)
            {
                List<string> phaseList = new List<string>();
                bool isMatched = false;
                string matchedModuleName = "";
                foreach ((Regex regex, List<string> phaseConfigList) in ruleList)
                {
                    var regexResult = regex.Match(filePath);
                    if (regexResult.Success)
                    {
                        phaseList = phaseConfigList;
                        isMatched = true;
                        if (regexResult.Groups[MODULE_NAME_PLACEHOLDER].Success)
                        {
                            matchedModuleName = regexResult.Groups[MODULE_NAME_PLACEHOLDER].Value;
                        }
                        Console.WriteLine(string.Format("File {0} match rule: {1} and phaseConfig is: [{2}]", filePath, regex.ToString(), string.Join(", ", phaseConfigList)));
                        break;
                    }
                }
                if (!isMatched)
                {
                    Console.WriteLine(string.Format("File {0} doesn't match any rule, goto fallback logic.", filePath));
                    phaseList = new List<string>()
                    {
                        BUILD_PHASE + ":" + AllModule,
                        TEST_PHASE + ":" + AllModule,
                    };
                    foreach (var analysisPhase in ANALYSIS_PHASE_LIST)
                    {
                        phaseList.Add(string.Format("{0}:{1}", analysisPhase, AllModule));
                    }
                }
                foreach (string phase in phaseList)
                {
                    string phaseName = phase.Split(':')[0];
                    string scope = phase.Split(':')[1];
                    HashSet<string> scopes = influencedModuleInfo.ContainsKey(phaseName) ? influencedModuleInfo[phaseName] : new HashSet<string>();
                    if (scope.Equals(AllModule) && !ONLY_AFFECT_MODULE_PHASE_LIST.Contains(phaseName))
                    {
                        scopes.UnionWith(GetSelectedModuleList());
                    }
                    else
                    {
                        string moduleName = matchedModuleName == "" ? filePath.Split('/')[1] : matchedModuleName;
                        if (scope.Equals(SingleModule))
                        {
                            scopes.Add(moduleName);
                        }
                        else if (scope.Equals(DependenceModule))
                        {
                            scopes.UnionWith(GetDependenceModuleList(moduleName, csprojMap));
                        }
                        else if (scope.Equals(DependentModule))
                        {
                            scopes.UnionWith(GetDependentModuleList(moduleName, csprojMap));
                        }
                        else if (scope.Equals(RelatedModule))
                        {
                            scopes.UnionWith(GetDependenceModuleList(moduleName, csprojMap));
                            scopes.UnionWith(GetDependentModuleList(moduleName, csprojMap));
                        }
                        else
                        {
                            scopes.Add(scope);
                        }
                    }
                    influencedModuleInfo[phaseName] = scopes;
                }
            }
            List<string> expectedKeyList = new List<string>()
            {
                BUILD_PHASE,
                TEST_PHASE
            };
            expectedKeyList.AddRange(ANALYSIS_PHASE_LIST);
            foreach (string phaseName in expectedKeyList)
            {
                if (!influencedModuleInfo.ContainsKey(phaseName))
                {
                    influencedModuleInfo[phaseName] = new HashSet<string>();
                }
            }

            foreach (string moduleName in influencedModuleInfo[TEST_PHASE])
            {
                if (!moduleName.Equals(ACCOUNT_MODULE_NAME))
                {
                    influencedModuleInfo[BUILD_PHASE].UnionWith(GetDependentModuleList(moduleName, csprojMap));
                }
            }
            if (influencedModuleInfo[BUILD_PHASE].Count == 0)
            {
                influencedModuleInfo[BUILD_PHASE].Add(ACCOUNT_MODULE_NAME);
            }
            Console.WriteLine("----------------- InfluencedModuleInfo -----------------");
            foreach (string phaseName in influencedModuleInfo.Keys)
            {
                Console.WriteLine(string.Format("{0}: [{1}]", phaseName, string.Join(", ", influencedModuleInfo[phaseName].ToList())));
            }
            Console.WriteLine("--------------------------------------------------------");

            return influencedModuleInfo;
        }

        /*
         * Calculate the csproj path for modules in Build and Test phase.
         */
        private Dictionary<string, HashSet<string>> CalculateCsprojForBuildAndTest(Dictionary<string, HashSet<string>> influencedModuleInfo, Dictionary<string, string[]> csprojMap)
        {
            var keys = influencedModuleInfo.Keys.ToList();
            foreach (string phaseName in keys)
            {
                if (phaseName.Equals(BUILD_PHASE))
                {
                    HashSet<string> csprojSet = new HashSet<string>();
                    foreach (string moduleName in influencedModuleInfo[phaseName])
                    {
                        csprojSet.UnionWith(GetBuildCsprojList(moduleName, csprojMap));
                    }
                    if (csprojSet.Count != 0)
                    {
                        foreach (string filename in Directory.GetFiles(@"src\Accounts", "*.csproj", SearchOption.AllDirectories).Where(x => !x.Contains("Test")))
                        {
                            csprojSet.Add(filename);
                        }
                    }
                    influencedModuleInfo[phaseName] = csprojSet;
                }
                else if (phaseName.Equals(TEST_PHASE))
                {
                    HashSet<string> csprojSet = new HashSet<string>();
                    foreach (string moduleName in influencedModuleInfo[phaseName])
                    {
                        csprojSet.UnionWith(GetTestCsprojList(moduleName, csprojMap));
                    }
                    if (csprojSet.Count != 0)
                    {
                        csprojSet.Add(@"tools\TestFx\TestFx.csproj");
                    }
                    influencedModuleInfo[phaseName] = csprojSet;
                }
            }

            foreach (string phaseName in influencedModuleInfo.Keys)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(string.Format("{0}: [{1}]", phaseName, string.Join(", ", influencedModuleInfo[phaseName].ToList())));
            }

            return influencedModuleInfo;
        }

        private CIPhaseFilterConfig GetCIPhaseFilterConfig()
        {
            string configPath = Path.GetFullPath(TaskMappingConfigName);
            if (!File.Exists(configPath))
            {
                throw new Exception("CI phase config is not found!");
            }
            string content = File.ReadAllText(configPath);

            return JsonConvert.DeserializeObject<CIPhaseFilterConfig>(content);
        }

        private bool ProcessFileChanged(Dictionary<string, string[]> csprojMap)
        {

            CIPhaseFilterConfig config = GetCIPhaseFilterConfig();
            List<(Regex, List<string>)> ruleList = config.Rules.Select(rule => (new Regex(string.Join("|", rule.Patterns.Select(ProcessSinglePattern).ToList())), rule.Phases)).ToList();

            DateTime startTime = DateTime.Now;

            Dictionary<string, HashSet<string>> influencedModuleInfo = CalculateInfluencedModuleInfoForEachPhase(ruleList, csprojMap);
            DateTime endOfRegularExpressionTime = DateTime.Now;

            influencedModuleInfo = CalculateCsprojForBuildAndTest(influencedModuleInfo, csprojMap);
            DateTime endTime = DateTime.Now;
            Console.WriteLine(string.Format("Takes {0} seconds for RE match, {1} seconds for phase config.", (endOfRegularExpressionTime - startTime).TotalSeconds, (endTime - endOfRegularExpressionTime).TotalSeconds));

            FilterTaskResult.PhaseInfo = influencedModuleInfo;

            if (!Directory.Exists(config.ArtifactPipelineInfoFolder))
            {
                Directory.CreateDirectory(config.ArtifactPipelineInfoFolder);
            }
            Dictionary<string, HashSet<string>> CIPlan = new Dictionary<string, HashSet<string>>
            {
                [BUILD_PHASE] = new HashSet<string>(influencedModuleInfo[BUILD_PHASE].Select(GetModuleNameFromPath).Where(x => x != null)),
                [TEST_PHASE] = new HashSet<string>(influencedModuleInfo[TEST_PHASE].Select(GetModuleNameFromPath).Where(x => x != null))
            };
            foreach (var analysisPhase in ANALYSIS_PHASE_LIST)
            {
                CIPlan.Add(analysisPhase, influencedModuleInfo[analysisPhase]);
            }
            File.WriteAllText(Path.Combine(config.ArtifactPipelineInfoFolder, "CIPlan.json"), JsonConvert.SerializeObject(CIPlan, Formatting.Indented));
            influencedModuleInfo[TEST_PHASE] = new HashSet<string>(influencedModuleInfo[TEST_PHASE].Where(x => x.EndsWith(".csproj")));

            return true;
        }

        private string GetModuleNameFromPath(string path)
        {
            if (path.IndexOf(".csproj") == -1)
            {
                return path;
            }
            if (path.IndexOf("src") == -1)
            {
                return null;
            }
            return path.Replace("\\", "/").Split("src/")[1].Split('/')[0];
        }

        /// <summary>
        /// Executes the task to generate a list of test assemblies
        /// based on file changes from a specified Pull Request.
        /// The output it produces is said list.
        /// </summary>
        /// <returns> Returns a value indicating wheter the success status of the task. </returns>
        public override bool Execute()
        {
            FilterTaskResult = new CIFilterTaskResult();

            var csprojMap = ReadMapFile(CsprojMapFilePath, "CsprojMapFilePath");

            Console.WriteLine(string.Format("FilesChanged: {0}", FilesChanged.Length));
            if (!string.IsNullOrWhiteSpace(TargetModule))
            {
                return ProcessTargetModule(csprojMap);
            }
            else if (FilesChanged != null)
            {
                if (FilesChanged.Length <= 0)
                {
                    return false;
                }
                else if (FilesChanged.Length >= OCTOKIT_CHANGED_FILE_LIMIT)
                {
                    var selectedModuleList = GetSelectedModuleList();
                    Dictionary<string, HashSet<string>> influencedModuleInfo = new Dictionary<string, HashSet<string>>
                    {
                        [BUILD_PHASE] = new HashSet<string>(selectedModuleList),
                        [TEST_PHASE] = new HashSet<string>(selectedModuleList)
                    };
                    foreach (var analysisPhase in ANALYSIS_PHASE_LIST)
                    {
                        influencedModuleInfo.Add(analysisPhase, new HashSet<string>(selectedModuleList));
                    }
                    FilterTaskResult.PhaseInfo = CalculateCsprojForBuildAndTest(influencedModuleInfo, csprojMap);
                    return true;
                }
                else
                {
                    return ProcessFileChanged(csprojMap);
                }
            }
            return true;
        }
    }
}
