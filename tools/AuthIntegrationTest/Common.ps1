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
function ConvertTo-PlainString
{
    param (
        [Parameter(Mandatory=$true, Position=0)]
        [object]
        $Secret
    )

    $ssPtr = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($Secret)
    try {
        $secretValueText = [System.Runtime.InteropServices.Marshal]::PtrToStringBSTR($ssPtr)
    } finally {
        [System.Runtime.InteropServices.Marshal]::ZeroFreeBSTR($ssPtr)
    }
    return $secretValueText
}

function Invoke-PowerShellCommand
{
    param (
        [Parameter(Mandatory)]
        [bool] $UseWindowsPowerShell,

        [Parameter(Mandatory, ParameterSetName = "ByScriptFile")]
        [ValidateNotNullOrEmpty()]
        [string] $ScriptFile,

        [Parameter(Mandatory, ParameterSetName = "ByScriptBlock")]
        [ValidateNotNullOrEmpty()]
        [string] $ScriptBlock
    )

    if ($UseWindowsPowerShell) {
        $process = "powershell"
        Write-Host "##[section]Using Windows PowerShell"
    }
    else {
        $process = "pwsh"
        Write-Host "##[section]Using PowerShell"
        pwsh -NoLogo -NoProfile -NonInteractive -Version
    }

    switch ($PSCmdlet.ParameterSetName) {
        "ByScriptFile" {
            Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -File $ScriptFile"
        }
        "ByScriptBlock" {
            #Write-Host "The commnd to execute:"
            #Write-Host "$ScriptBlock"
            Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -Command $ScriptBlock"
        }
    }
}