$mapping = [ordered]@{}

$psd1s = Get-ChildItem -Path $PSScriptRoot/../src -Recurse | `
    Where-Object {($_.Name -like "*AzureRM*psd1"  -or $_.Name -eq "Azure.AnalysisServices.psd1" -or $_.Name -eq "Azure.Storage.psd1") `
    -and $_.FullName -notlike "*Stack*" -and $_.FullName -notlike "*`\Package`\*" -and $_.FullName -notlike "*Test*" -and $_.FullName -notlike "*`\bin`\*" -and $_.FullName -notlike "*`\obj`\*"}

$psd1s | ForEach-Object {
    $name = (($_.Name -replace "AzureRM", "Az") -replace "Azure", "Az") -replace ".psd1", ""
    if (!($mapping.Contains($name)))
    {
        $mapping.Add($name, [ordered]@{})
    }
    Import-LocalizedData -BindingVariable psd1info -BaseDirectory $_.DirectoryName -FileName $_.Name
    $psd1info.CmdletsToExport | ForEach-Object {
        if ($_ -like "*AzureRmStorageContainer*")
        {
            $cmdletalias = $_ -replace "-AzureRM", "-AzRm"
            $mapping[$name].Add($cmdletalias, $_)
        }
        elseif ($_ -like "*Azure*")
        {
            $cmdletalias = ($_ -replace "-AzureRM", "-Azure") -replace "-Azure", "-Az"
            $mapping[$name].Add($cmdletalias, $_)
        }
        else
        {
            Write-Warning $_
        }
    }
    $psd1info.AliasesToExport | ForEach-Object {
        if ($_ -like "*Azure*")
        {
            $cmdletalias = ($_ -replace "-AzureRM", "-Azure") -replace "-Azure", "-Az"
            $mapping[$name].Add($cmdletalias, $_)
        }
        else
        {
            Write-Warning $_
        }
    }
}

$json = ConvertTo-Json $mapping
"// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the 'License');
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an 'AS IS' BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Profile.AzureRmAlias
{
    public class Mappings
    {
        public static Dictionary<string, object> GetCaseInsensitiveMapping()
        {
            string jsonmapping = jsonMappings;
            Dictionary<string, object> caseSensitiveMapping = (Dictionary<string, object>)JsonConvert.DeserializeObject(jsonmapping, typeof(Dictionary<string, object>));
            var mapping = new Dictionary<string, object>(StringComparer.CurrentCultureIgnoreCase);
            foreach (var key in caseSensitiveMapping.Keys)
            {
                mapping.Add(key, caseSensitiveMapping[key]);
            }

            return mapping;
        }

        public static string jsonMappings = @`"`r`n" + ($json -replace "`"", "`'") + "`r`n`r`n`";`r`n`r`n    }`r`n}" | Set-Content -Path $PSScriptRoot/../src/ResourceManager/Profile/Commands.Profile/AzureRmAlias/Mappings.cs