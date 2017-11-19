# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Walks trought all test function headers and collects those 
that has the 'AutomationTest' tag in the dot Description section
.PARAMETER path
Path to the directory where test sctipts are located
.EXAMPLE
ListTestFunctions "e:\git\azure-powershell\src\ResourceManager\Compute\Commands.Compute.Test\ScenarioTests"
#>
function ListTestFunctions(
     [string] $path
    ,[string] $tag = 'AzureAutomationTest') {

    $lines = [System.Collections.ArrayList]@()
    
    $currentFunctions = Get-ChildItem function:
    $testFiles = Get-ChildItem -Path $path -Filter "*Tests.ps1" -ErrorAction Stop
    $variableList = @()
    
    foreach ($testFile in $testFiles) {

        # get function list from the script file
        . "$path\$testFile"

        $scriptFunctions = Get-ChildItem function: | Where-Object { $currentFunctions -notcontains $_ }
        
        $testFunctions = $scriptFunctions | Where-Object { 
            ($_.Name.StartsWith("Test-", "CurrentCultureIgnoreCase")) 
        } | Where-Object {
            $desc = (Get-Help $_).Description
            $desc -and ($desc[0].Text -contains $tag)
        } 
        
        if ($testFunctions.Count -gt 0) {
            $variableList +=  $testFile.BaseName
            $null = $lines.Add("# from $testFile")  
            $null = $lines.Add('${0} = @(' -f $testFile.BaseName)     
            for ($i=0; $i -lt $testFunctions.Length; $i++) {
                $testFunction = $testFunctions[$i];
                if ($i -eq 0) {
                    $null = $lines.Add("`t '$testFunction'")
                }
                else {
                    $null = $lines.Add( "`t,'$testFunction'")
                }
            }
            $null = $lines.Add(')')
        } else {
            $null = $lines.Add("# from $testFile - no tests found")
        }

        $scriptFunctions | ForEach-Object { Remove-Item function:\$_ }
    }

    if ($testFile.Count -eq 0) {
        $null = $lines.Add("# no test files found")
    }

    if ($variableList.Count -gt 0) {
        $null = $lines.Add('$testList =')
        $count = 0;
        $lastIndex = $variableList.Count - 1
    
        $variableList | ForEach-Object { 
            if ($count -lt $lastIndex) {  
                $null = $lines.Add("`t`$$_ +")
            } else {
                $null = $lines.Add("`t`$$_")
            }
            $count++
        }
    }

    $lines
}