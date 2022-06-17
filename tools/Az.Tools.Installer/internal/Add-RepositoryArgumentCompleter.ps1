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
function Add-RepositoryArgumentCompleter()
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string[]]$cmdlets,
        
        [Parameter(Mandatory=$true)]
        [string]$parameterName
    )

    try
    {
        if(Get-Command -Name Register-ArgumentCompleter -ErrorAction SilentlyContinue)
        {
            Register-ArgumentCompleter -CommandName $cmdlets -ParameterName $parameterName -ScriptBlock {
                param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter) 
                
                Get-PSRepository -Name "$wordTocomplete*"-ErrorAction SilentlyContinue -WarningAction SilentlyContinue | Foreach-Object { 
                    [System.Management.Automation.CompletionResult]::new($_.Name, $_.Name, 'ParameterValue', $_.Name) 
                } 
           }
        }
    }
    catch 
    {
        # All this functionality is optional, so suppress errors 
        Write-Debug -Message "Error registering argument completer: $_"      
    }
}