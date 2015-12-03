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

function Remove-Modules
{
  param([string]$basePath)
  $paths = "Azure", "AzureRM", "AzureRM.*", "Azure.Storage"
  $paths | ForEach-Object {
    $modulePath = ([System.IO.Path]::Combine($basePath, $_))
    try {
      Write-Host Removing $_
      if (Test-Path $modulePath)
      {
        Remove-Item -Recurse $modulePath -Force
      }
    }
    catch {}
  }
}

if (Test-Path 'Env:\ProgramFiles(x86)')
{
   Remove-Modules ([System.IO.Path]::Combine(${env:ProgramFiles(x86)}, "WindowsPowerShell", "Modules"))
}

if (Test-Path Env:\ProgramFiles)
{
   Remove-Modules ([System.IO.Path]::Combine($env:ProgramFiles, "WindowsPowerShell", "Modules"))
}

