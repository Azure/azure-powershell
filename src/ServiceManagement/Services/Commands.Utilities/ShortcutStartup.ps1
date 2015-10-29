﻿# ----------------------------------------------------------------------------------
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

function Get-ScriptDirectory
{
    $Invocation = (Get-Variable MyInvocation -Scope 1).Value
    Split-Path $Invocation.MyCommand.Path
}

$modulePath = Join-Path $(Split-Path ( Get-ScriptDirectory)) "Azure.psd1"
$resourceModulePath = Join-Path $(Split-Path (Get-ScriptDirectory)) "..\..\ResourceManager\AzureResourceManager\AzureResourceManager.psd1"
Import-Module $modulePath

if(Test-Path $resourceModulePath)
{
	Import-Module $resourceModulePath
}

cd c:\
$welcomeMessage = @"
For a list of all Azure cmdlets type 'get-help azure'.
For a list of Windows Azure Pack cmdlets type 'Get-Command *wapack*'.
"@
Write-Output $welcomeMessage

Set-ExecutionPolicy -Scope Process Undefined -Force
if ($(Get-ExecutionPolicy) -eq "Restricted")
{
    Set-ExecutionPolicy -Scope Process -ExecutionPolicy RemoteSigned -Force
}
