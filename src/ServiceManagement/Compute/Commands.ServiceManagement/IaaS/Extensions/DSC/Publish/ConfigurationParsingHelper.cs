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

using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Management.Automation.Runspaces;

namespace Microsoft.WindowsAzure.Commands.Common.Extensions.DSC.Publish
{

    public static class ConfigurationParsingHelper
    {
        private static readonly ConcurrentDictionary<string, string> _resourceName2ModuleNameCache =
            new ConcurrentDictionary<string, string>();

        private static bool IsParameterName(CommandElementAst ast, string name)
        {
            var constantAst = ast as CommandParameterAst;
            if (constantAst == null)
            {
                return false;
            }
            return String.Equals(constantAst.ParameterName, name, StringComparison.OrdinalIgnoreCase);
        }

        private static IEnumerable<string> GetLegacyTopLevelParametersFromAst(CommandAst ast, string parameterName)
        {
            var parameters = new List<string>();
            IEnumerable<CommandParameterAst> commandElement =
                ast.CommandElements.Where(x => IsParameterName(x, parameterName)).OfType<CommandParameterAst>();
            foreach (var commandElementAst in commandElement)
            {
                var arrayLiteralAst = commandElementAst.Argument as ArrayLiteralAst;
                if (arrayLiteralAst != null)
                {
                    parameters.AddRange(arrayLiteralAst.Elements.OfType<StringConstantExpressionAst>().Select(x => x.Value));
                }
            }
            return parameters;
        }


        private static bool IsCandidateForImportDscResourceAst(Ast ast, int startOffset)
        {
            return ast.Extent.StartOffset == startOffset && !(ast is StatementBlockAst) && !(ast is NamedBlockAst);
        }
        private static Dictionary<string, string> GetSingleAstRequiredModules(Ast ast, IEnumerable<Token> tokens, Dictionary<string, string> modules)
        {
            var resources = new List<string>();
            var imports = tokens.Where(token =>
                    String.Compare(token.Text, "Import-DscResource", StringComparison.OrdinalIgnoreCase) == 0);

            //
            // Create a function with the same name as Import-DscResource keyword and use powershell
            // argument function binding to emulate Import-DscResource argument binding.
            //
            InitialSessionState initialSessionState = InitialSessionState.Create();
            var importDscResourcefunctionEntry = new SessionStateFunctionEntry(
                "Import-DscResource", @"param($Name, $ModuleName, $ModuleVersion, $Module)
                if ($ModuleName) 
                {
                    foreach ($module in $ModuleName) {
                        if($module.GetType().FullName -eq 'System.Collections.Hashtable'){
                            $mVersion = ""
                            $mName = ""
                            foreach($modulekey in $module.Keys){
                                if($modulekey -eq 'ModuleName'){
                                    $mName = $module[$modulekey]    
                                }
                                elseif($modulekey -eq 'ModuleVersion' -or $modulekey -eq 'RequiredVersion'){
                                    $mVersion = $module[$modulekey]    
                                }
                            }

                            if(!$global:modules.ContainsKey($mName)){
                                $global:modules.Add($mName,$mVersion)
                            }
                        }
                        else{
                            if(!$global:modules.ContainsKey($module)){
                                if($ModuleVersion)
                                {   
                                    $global:modules.Add($module,$ModuleVersion)    
                                }
                                else
                                {
                                    $global:modules.Add($module,"""")
                                }
                            }
                        }
                    }
                } 
                elseif($Module)
                {
                    foreach ($module in $Module) 
                    {
                        if(!$global:modules.ContainsKey($module))
                        {
                            if($ModuleVersion)
                            {   
                                $global:modules.Add($module,$ModuleVersion)    
                            }
                            else
                            {
                                $global:modules.Add($module,"""")
                            }
                        }      
                    }
                }
                else 
                {
                    foreach ($n in $Name) { $global:resources.Add($n) }
                }
            ");

            initialSessionState.Commands.Add(importDscResourcefunctionEntry);
            initialSessionState.LanguageMode = PSLanguageMode.RestrictedLanguage;
            var moduleVarEntry = new SessionStateVariableEntry("modules", modules, "");
            var resourcesVarEntry = new SessionStateVariableEntry("resources", resources, "");
            initialSessionState.Variables.Add(moduleVarEntry);
            initialSessionState.Variables.Add(resourcesVarEntry);

            using (System.Management.Automation.PowerShell powerShell = System.Management.Automation.PowerShell.Create(initialSessionState))
            {
                foreach (var import in imports)
                {
                    int startOffset = import.Extent.StartOffset;
                    var asts = ast.FindAll(a => IsCandidateForImportDscResourceAst(a, startOffset), true);
                    int longestLen = -1;
                    Ast longestCandidate = null;
                    foreach (var candidatAst in asts)
                    {
                        int curLen = candidatAst.Extent.EndOffset - candidatAst.Extent.StartOffset;
                        if (curLen > longestLen)
                        {
                            longestCandidate = candidatAst;
                            longestLen = curLen;
                        }
                    }
                    // longestCandidate should contain AST for import-dscresource, like "Import-DSCResource -Module x -Name y".
                    if (longestCandidate != null)
                    {
                        string importText = longestCandidate.Extent.Text;
                        // We invoke-command "importText" here. Script injection is prevented:
                        // We checked that file represents a valid AST without errors.
                        powerShell.AddScript(importText);
                        powerShell.Invoke();
                        powerShell.Commands.Clear();
                    }
                }
            }

            var modulesFromDscResource = resources.Select(GetModuleNameForDscResource);
            foreach (var moduleName in modulesFromDscResource)
            {
                if (!modules.ContainsKey(moduleName))
                {
                    modules.Add(moduleName, "");
                }
            }

            return modules;
        }

        public static string GetModuleNameForDscResource(string resourceName)
        {
            string moduleName;
            if (!_resourceName2ModuleNameCache.TryGetValue(resourceName, out moduleName))
            {
                try
                {
                    using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
                    {
                        powershell.AddCommand("Get-DscResource").
                            AddCommand("Where-Object").AddParameter("Property", "ResourceType").AddParameter("Value", resourceName).AddParameter("EQ", true).
                            AddCommand("Foreach-Object").AddParameter("MemberName", "Module").
                            AddCommand("Foreach-Object").AddParameter("MemberName", "Name");
                        moduleName = powershell.Invoke<string>().First();
                    }
                }
                catch (InvalidOperationException e)
                {
                    throw new GetDscResourceException(resourceName, e);
                }
                _resourceName2ModuleNameCache.TryAdd(resourceName, moduleName);
            }
            return moduleName;
        }

        private static Dictionary<String, String> GetRequiredModulesFromAst(Ast ast, IEnumerable<Token> tokens)
        {
            var modules = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);

            // We use System.Management.Automation.Language.Parser to extract required modules from ast, 
            // but format of ast is a bit tricky and have changed in time.
            //
            // There are two place where 'Import-DscResource' keyword can appear:
            // 1) 
            // Configuration Foo {
            //   Import-DscResource ....  # outside node
            //   Node Bar {...}
            // }
            // 2)
            // Configuration Foo {
            //   Node Bar {
            //     Import-DscResource .... # inside node
            //     ...
            //   }
            // }
            // 
            // The old version of System.Management.Automation.Language.Parser produces slightly different AST for the first case.
            // In new version, Configuration corresponds to ConfigurationDefinitionAst.
            // In old version is's a generic CommandAst with specific commandElements which capture top-level Imports (case 1).
            // In new version all imports correspond to their own CommandAsts, same for case 2 in old version. 

            // Old version, case 1:
            IEnumerable<CommandAst> legacyConfigurationAsts = ast.FindAll(IsLegacyAstConfiguration, true).Select(x => (CommandAst)x);
            foreach (var legacyConfigurationAst in legacyConfigurationAsts)
            {
                // Note: these two sequences are translated to same AST:
                //
                // Import-DscResource -Module xComputerManagement; Import-DscResource -Name xComputer
                // Import-DscResource -Module xComputerManagement -Name xComputer
                //
                // We cannot distinguish different imports => cannot ignore resource names for imports with specified modules.
                // So we process everything: ModuleDefinition and ResourceDefinition.

                // Example: Import-DscResource -Module xPSDesiredStateConfiguration

                var moduleParams = GetLegacyTopLevelParametersFromAst(legacyConfigurationAst, "ModuleDefinition");
                foreach (var param in moduleParams)
                {
                    if (!modules.ContainsKey(param))
                    {
                        modules.Add(param, "");
                    }
                }

                // Example: Import-DscResource -Name MSFT_xComputer
                var resourceParams = GetLegacyTopLevelParametersFromAst(legacyConfigurationAst, "ResourceDefinition").Select(GetModuleNameForDscResource);
                foreach (var param in resourceParams)
                {
                    if (!modules.ContainsKey(param))
                    {
                        modules.Add(param, "");
                    }
                }
            }

            // Both cases in new version and 2nd case in old version:
            modules = GetSingleAstRequiredModules(ast, tokens, modules);

            return modules;
        }

        private static bool IsLegacyAstConfiguration(Ast node)
        {
            var commandNode = node as CommandAst;
            if (commandNode == null)
            {
                return false;
            }
            // TODO: Add case when configuration name is not a StringConstant, but a variable.
            var commandParameter = (commandNode.CommandElements[0] as StringConstantExpressionAst);
            if (commandParameter == null)
            {
                return false;
            }
            // Find the AST nodes defining configurations. These nodes will be CommandAst nodes
            // with 7 or 8 command elements (8 if the configuration requires any custom modules.)
            return
                commandNode.CommandElements.Count >= 7 &&
                String.Equals(commandParameter.Extent.Text, "configuration", StringComparison.OrdinalIgnoreCase) &&
                String.Equals(commandParameter.Value, @"PSDesiredStateConfiguration\Configuration",
                    StringComparison.OrdinalIgnoreCase);
        }

        public static ConfigurationParseResult ParseConfiguration(string path)
        {
            // Get the resolved script path. This will throw an exception if the file is not found.
            string fullPath = Path.GetFullPath(path);
            Token[] tokens;
            ParseError[] errors;
            // Parse the script into an AST, capturing parse errors. Note - even with errors, the
            // file may still successfully define one or more configurations. We don't process
            // required modules in case of parsing errors to avoid script injection.
            ScriptBlockAst ast = Parser.ParseFile(fullPath, out tokens, out errors);
            var requiredModules = new Dictionary<string, string>();
            if (!errors.Any())
            {
                requiredModules = GetRequiredModulesFromAst(ast, tokens);
            }
            return new ConfigurationParseResult()
            {
                Path = fullPath,
                Errors = errors,
                RequiredModules = requiredModules,
            };
        }
    }
}
