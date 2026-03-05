# ----------------------------------------------------------------------------------
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

param (
    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $ModuleName,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $RunPlatform,

    [Parameter()]
    [ValidateScript({ Test-Path -Path $_ -PathType Container })]
    [string] $DataLocation
)

New-Variable -Name ResourceGroupPrefix -Value "azpslrg" -Scope Script -Option Constant
New-Variable -Name ResourcePrefix -Value "azpsl" -Scope Script -Option Constant
New-Variable -Name StorageAccountPrefix -Value "azpslsa" -Scope Script -Option Constant

New-Variable -Name CommandMaxRetryCount -Value 3 -Scope Script -Option Constant
New-Variable -Name CommandDelay -Value 10 -Scope Script -Option Constant
New-Variable -Name ScenarioMaxRetryCount -Value 3 -Scope Script -Option Constant
New-Variable -Name ScenarioMaxDelay -Value 20 -Scope Script -Option Constant
New-Variable -Name ScenarioDelay -Value 5 -Scope Script -Option Constant

New-Variable -Name LiveTestAnalysisDirectory -Value (Join-Path -Path $DataLocation -ChildPath "LiveTestAnalysis") -Scope Script -Option Constant
New-Variable -Name LiveTestRawDirectory -Value (Join-Path -Path $script:LiveTestAnalysisDirectory -ChildPath "Raw") -Scope Script -Option Constant
New-Variable -Name LiveTestRawCsvFile -Value (Join-Path -Path $script:LiveTestRawDirectory -ChildPath "Az.$ModuleName.csv") -Scope Script -Option Constant

function InitializeLiveTestModule {
    [CmdletBinding()]
    param ()

    if (!(Test-Path -Path $script:LiveTestAnalysisDirectory -PathType Container)) {
        New-Item -Path $script:LiveTestAnalysisDirectory -ItemType Directory -Force
        New-Item -Path $script:LiveTestRawDirectory -ItemType Directory -Force
    }

    if (!(Test-Path -Path $script:LiveTestRawCsvFile -PathType Leaf)) {
        ({} | Select-Object "PSVersion", "Module", "Name", "Description", "StartDateTime", "EndDateTime", "IsSuccess", "Errors" | ConvertTo-Csv -NoTypeInformation)[0] | Out-File -FilePath $script:LiveTestRawCsvFile -Encoding utf8 -Force
    }
}

function New-LiveTestRandomName {
    [CmdletBinding()]
    [OutputType([string])]
    param (
        [Parameter()]
        [ValidateSet("Alphanumerics", "AllNumbers", "AllLetters", "StartWithNumber", "StartWithLetter", IgnoreCase = $false)]
        [string] $Option = "Alphanumerics",

        [Parameter()]
        [ValidateRange(1, 20)]
        [int] $MaxLength = 10
    )

    $alphanumerics = "0123456789abcdefghijklmnopqrstuvwxyz"
    $numLast = 10
    $alphanumLast = $alphanumerics.Length

    switch ($Option) {
        "Alphanumerics" {
            $firstChar = ""
            $maxLen = $MaxLength
            $min = 0
            $max = $alphanumLast
        }
        "AllNumbers" {
            $firstChar = ""
            $maxLen = $MaxLength
            $min = 0
            $max = $numLast
        }
        "AllLetters" {
            $firstChar = ""
            $maxLen = $MaxLength
            $min = $numLast
            $max = $alphanumLast
        }
        "StartWithNumber" {
            $firstChar = $alphanumerics[(Get-Random -Maximum $numLast)]
            $maxLen = $MaxLength - 1
            $min = 0
            $max = $alphanumLast
        }
        "StartWithLetter" {
            $firstChar = $alphanumerics[(Get-Random -Minimum $numLast -Maximum $alphanumLast)]
            $maxLen = $MaxLength - 1
            $min = 0
            $max = $alphanumLast
        }
    }

    $randomName += $firstChar
    for ($i = 0; $i -lt $maxLen; $i ++) {
        $randomName += $alphanumerics[(Get-Random -Minimum $min -Maximum $max)]
    }

    $randomName
}

function New-LiveTestResourceGroupName {
    [CmdletBinding()]
    [OutputType([string])]
    param ()

    $rgPrefix = $script:ResourceGroupPrefix
    $rgName = New-LiveTestRandomName -Option StartWithNumber

    $rgFullName = "$rgPrefix$rgName"
    $rgFullName
}

function New-LiveTestResourceGroup {
    [CmdletBinding()]
    param (
        [Parameter(Position = 0)]
        [Alias("ResourceGroupName")]
        [ValidateNotNullOrEmpty()]
        [ValidateScript({ $_ -match "^$script:ResourceGroupPrefix\d[a-zA-Z0-9]{9}$" })]
        [string] $Name = (New-LiveTestResourceGroupName),

        [Parameter(Position = 1)]
        [ValidateNotNullOrEmpty()]
        [string] $Location = "westus",

        [Parameter()]
        [ref] $Result
    )

    $cmd = { New-AzResourceGroup -Name $Name -Location $Location -Force }
    $displayCmd = $ExecutionContext.InvokeCommand.ExpandString($cmd.ToString())

    $allOutput = @(Invoke-LiveTestCommand -Command $cmd -DisplayCommand $displayCmd)
    $allOutput | Where-Object { $_ -is [string] } | ForEach-Object { Write-Output $_ }

    $rg = $allOutput | Where-Object { $_ -isnot [string] } | Select-Object -First 1

    if ($PSBoundParameters.ContainsKey('Result')) {
        $Result.Value = $rg
    }
    else {
        $rg
    }
}

function New-LiveTestResourceName {
    [CmdletBinding()]
    [OutputType([string])]
    param ()

    $rPrefix = $script:ResourcePrefix
    $rName = New-LiveTestRandomName -Option StartWithNumber

    $rFullName = "$rPrefix$rName"
    $rFullName
}

function New-LiveTestStorageAccountName {
    [CmdletBinding()]
    [OutputType([string])]
    param ()

    $saPrefix = $script:StorageAccountPrefix
    $saName = New-LiveTestRandomName -Option StartWithNumber

    $saFullName = "$saPrefix$saName"
    $saFullName
}

function New-LiveTestPassword {
    [CmdletBinding()]
    [OutputType([string])]
    param (
        [Parameter()]
        [ValidateRange(12, 123)]
        [int] $MaxLength = 16
    )

    $lowercase = 'abcdefghijklmnopqrstuvwxyz'
    $uppercase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
    $numbers = '0123456789'
    $special = '!@#$%^&*()-_=+[]{}|;:,.<>?'
    $allCharacters = $lowercase + $uppercase + $numbers + $special

    # Ensure at least three of the required character types
    $password = @()
    $characterTypes = @($lowercase, $uppercase, $numbers, $special)
    $selectedTypes = Get-Random -InputObject $characterTypes -Count 3

    foreach ($type in $selectedTypes) {
        $password += $type[(Get-Random -Minimum 0 -Maximum $type.Length)]
    }

    # Ensure the first character is not a special character
    $nonSpecialCharacters = $lowercase + $uppercase + $numbers
    $firstChar = $nonSpecialCharacters[(Get-Random -Minimum 0 -Maximum $nonSpecialCharacters.Length)]
    $password = @($firstChar) + $password

    # Fill the rest of the password length with random characters from all sets
    $remainingLength = $MaxLength - $password.Length
    $password += (1..$remainingLength | ForEach-Object { $allCharacters[(Get-Random -Minimum 0 -Maximum $allCharacters.Length)] })

    # Shuffle the password to ensure randomness, excluding the first character
    $password = $password[0] + ( -join ($password[1..($password.Length - 1)] | Get-Random -Count ($password.Length - 1)))
    return -join $password
}

filter Write-LiveTestMessage {
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [string] $Message,

        [Parameter(Mandatory)]
        [ValidateSet("command", "debug", "error", "section", "warning", IgnoreCase = $false)]
        [string] $Level
    )

    $Message -split "`r?`n" | ForEach-Object { Write-Output "##[$Level]$_" }
}

function Get-LiveTestTypeTableState {
    param([string]$Label)
    try {
        $bf = [System.Reflection.BindingFlags]("Public,NonPublic,Instance")
        $rs = [runspace]::DefaultRunspace
        $ec = $rs.GetType().GetProperty("ExecutionContext", $bf).GetValue($rs)
        $tt = $ec.GetType().GetProperty("TypeTable", $bf).GetValue($ec)
        $em = $tt.GetType().GetField("_extendedMembers", $bf).GetValue($tt)
        $ttCount = $em.Count
        $hasJob = $em.ContainsKey("System.Management.Automation.Job")
        $ttHash = [System.Runtime.CompilerServices.RuntimeHelpers]::GetHashCode($tt)
        $diag = "TT._ext=$ttCount,hasJob=$hasJob,ttHash=$ttHash"
    } catch { $diag = "TT_ERROR: $($_.Exception.Message)"; $ttCount = -1 }
    try {
        $iss = $rs.GetType().GetProperty("InitialSessionState", $bf).GetValue($rs)
        $diag += " | ISS.Types=$($iss.Types.Count)"
    } catch { $diag += " | ISS=ERR" }
    try { $diag += " | Mods=$((Get-Module).Count)" } catch {}
    Write-Output "##[warning]DIAG[$ModuleName|$Label] $diag"
    if ($ttCount -ge 0 -and $ttCount -lt 100) {
        try {
            $keys = ($em.Keys | Sort-Object) -join ","
            Write-Output "##[warning]DIAG[$ModuleName|$Label] INCOMPLETE TT keys: $keys"
        } catch {}
    }
}

function Invoke-LiveTestCommand {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory, ValueFromPipeline)]
        [ValidateNotNullOrEmpty()]
        [scriptblock] $Command,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $DisplayCommand
    )

    $cmdRetryCount = 0

    do {
        try {
            $displayCommand = if ($PSBoundParameters.ContainsKey('DisplayCommand')) {
                $DisplayCommand
            }
            else {
                $Command.ToString().Trim()
            }
            Write-Output "##[section]Start executing the command `"$displayCommand`"."
            Write-Output "##[command]The command `"$displayCommand`" is running."

            $cmdResult = $Command.InvokeWithContext($null, [psvariable]::new("ErrorActionPreference", "Stop"))

            Write-Output "##[section]Finish executing the command `"$displayCommand`"."

            $cmdResult

            break
        }
        catch {
            $cmdErrorMessage = $_.Exception.InnerException.Message
            if ($cmdRetryCount -lt $script:CommandMaxRetryCount) {
                $cmdRetryMessage = "Error occurred when executing the command `"$Command`" with error message `"$cmdErrorMessage`"."
                $cmdRetryMessage | Write-LiveTestMessage -Level warning
                Write-Output "##[warning]Live test will retry automatically in $script:CommandDelay seconds."

                Start-Sleep -Seconds $script:CommandDelay
                $cmdRetryCount++
                Write-Output "##[warning]Retry #$cmdRetryCount to execute the command `"$Command`"."
            }
            else {
                $cmdFinalErrorMessage = "Failed to execute the command `"$Command`" after retrying for $script:CommandMaxRetryCount time(s) with error message `"$cmdErrorMessage`"."
                $cmdFinalErrorMessage | Write-LiveTestMessage -Level error
                throw $cmdFinalErrorMessage
            }
        }
    }
    while ($true)
}

function Invoke-LiveTestScenario {
    [CmdletBinding(DefaultParameterSetName = "HasDefaultResourceGroup")]
    param (
        [Parameter(Mandatory, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [string] $Name,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $Description,

        [Parameter()]
        [ValidateSet("Windows", "Linux", "MacOS", IgnoreCase = $false)]
        [string[]] $Platform,

        [Parameter()]
        [ValidateSet("5.1", "Latest", IgnoreCase = $false)]
        [string[]] $PowerShellVersion,

        [Parameter(ParameterSetName = "HasDefaultResourceGroup")]
        [ValidateNotNullOrEmpty()]
        [string] $ResourceGroupLocation,

        [Parameter(ParameterSetName = "HasNoDefaultResourceGroup")]
        [switch] $NoResourceGroup,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [scriptblock] $ScenarioScript
    )

    Get-LiveTestTypeTableState -Label "FUNC-ENTRY:$Name"

    if ($PSBoundParameters.ContainsKey("Platform") -and $RunPlatform -notin $Platform) {
        Write-Output "##[warning]Skip live scenario `"$Name`" for platform `"$RunPlatform`" due to platform not specified."
        return
    }

    $curPSVer = (Get-Variable -Name PSVersionTable -ValueOnly).PSVersion
    if ($PSBoundParameters.ContainsKey("PowerShellVersion")) {
        $psSimpleVer = $PowerShellVersion -replace "Latest", ${env:POWERSHELLLATEST}
        $curMajorVer = $curPSVer.Major
        $curMinorVer = $curPSVer.Minor
        $curSimpleVer = "$curMajorVer.$curMinorVer"
        if ($curSimpleVer -notin $psSimpleVer) {
            Write-Output "##[warning]Skip live scenario `"$Name`" for PowerShell version `"$curSimpleVer`" due to PowerShell version not specified."
            return
        }
    }

    Write-Output "##[group]Start executing the live scenario `"$Name`""

    if ($curPSVer.Major -eq 5) {
        $PSVersion = "5.1"
    }
    else {
        $PSVersion = $curPSVer.ToString()
    }

    try {
        $snrCsvData = [PSCustomObject]@{
            PSVersion     = $PSVersion
            Module        = $ModuleName
            Name          = $Name
            Description   = $Description
            StartDateTime = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss")
            EndDateTime   = $null
            IsSuccess     = $true
            Errors        = $null
        }

        if (!$NoResourceGroup.IsPresent) {
            $snrResourceGroupName = New-LiveTestResourceGroupName
            $snrResourceGroupLocation = "westus"
            if ($PSBoundParameters.ContainsKey("ResourceGroupLocation")) {
                $snrResourceGroupLocation = $ResourceGroupLocation
            }

            Write-Output "##[section]Resource group name: $snrResourceGroupName"
            Write-Output "##[section]Resource group location: $snrResourceGroupLocation"

            $snrResourceGroup = $null
            New-LiveTestResourceGroup -Name $snrResourceGroupName -Location $snrResourceGroupLocation -Result ([ref]$snrResourceGroup)
        }

        Get-LiveTestTypeTableState -Label "POST-RG:$Name"

        $snrRetryCount = 0
        $snrRetryErrors = @()

        do {
            try {
                if ($snrRetryCount -eq $script:ScenarioMaxRetryCount) {
                    $prefs = @([psvariable]::new("ErrorActionPreference", "Stop"), [psvariable]::new("DebugPreference", "Continue"))
                }
                else {
                    $prefs = [psvariable]::new("ErrorActionPreference", "Stop")
                }

                Get-LiveTestTypeTableState -Label "PRE-SCENARIO:$Name"

                $ScenarioScript.InvokeWithContext($null, $prefs, $snrResourceGroup)

                Get-LiveTestTypeTableState -Label "POST-SCENARIO:$Name"
                Write-Output "##[section]Finish executing the live scenario `"$Name`""

                break
            }
            catch {
                Get-LiveTestTypeTableState -Label "CATCH-SCENARIO:$Name"

                $snrErrorRecord = $_.Exception.InnerException.ErrorRecord
                $snrErrorMessage = $snrErrorRecord.Exception.Message
                $snrErrorDetails = $snrErrorMessage

                $snrInvocationInfo = $snrErrorRecord.InvocationInfo

                if ($null -ne $snrInvocationInfo) {
                    $snrScriptName = Split-Path -Path $snrInvocationInfo.ScriptName -Leaf -ErrorAction SilentlyContinue
                    if ($snrScriptName -eq "Assert.ps1") {
                        Write-Output "##[error]Exception was thrown from the Assert.ps1. The stack trace is:"
                        $snrErrorRecord.ScriptStackTrace | Write-LiveTestMessage -Level error
                    }
                    else {
                        $snrErrorDetails += " thrown at line:$($snrInvocationInfo.ScriptLineNumber) char:$($snrInvocationInfo.OffsetInLine) by cmdlet '$($snrInvocationInfo.MyCommand)' on '$($snrInvocationInfo.Line.ToString().Trim())'"
                    }
                }

                $snrRetryErrors += $snrErrorDetails

                if ($snrRetryCount -lt $script:ScenarioMaxRetryCount) {
                    $snrRetryCount++
                    $exponentialDelay = [Math]::Min((1 -shl ($snrRetryCount - 1)) * [int](Get-Random -Minimum ($script:ScenarioDelay * 0.8) -Maximum ($script:ScenarioDelay * 1.2)), $script:ScenarioMaxDelay)
                    $snrRetryMessage = "Error occurred when executing the live scenario `"$Name`" with error details `"$snrErrorDetails`"."
                    $snrRetryMessage | Write-LiveTestMessage -Level warning
                    Write-Output "##[warning]Live test will retry automatically in $exponentialDelay seconds."

                    Start-Sleep -Seconds $exponentialDelay
                    Write-Output "##[warning]Retry #$snrRetryCount to execute the live scenario `"$Name`"."
                }
                else {
                    $snrFinalMessage = "Failed to execute the live scenario `"$Name`" with error details `"$snrErrorDetails`"."
                    $snrFinalMessage | Write-LiveTestMessage -Level error
                    $snrCsvData.IsSuccess = $false
                    $snrCsvData.Errors = ConvertToLiveTestJsonErrors -Errors $snrRetryErrors
                    break
                }
            }
        }
        while ($true)
    }
    catch {
        $snrErrorMessage = $_.Exception.Message
        $snrFailureMessage = "Failed to execute the live scenario `"$Name`" with error details `"$snrErrorMessage`"."
        $snrFailureMessage | Write-LiveTestMessage -Level error
        $snrCsvData.IsSuccess = $false
        $snrCsvData.Errors = ConvertToLiveTestJsonErrors -Errors $snrErrorMessage
    }
    finally {
        $snrCsvData.EndDateTime = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss")

        $snrCsvData | Export-Csv -Path $script:LiveTestRawCsvFile -Encoding utf8 -NoTypeInformation -Append

        if (!$NoResourceGroup.IsPresent -and $null -ne $snrResourceGroup) {
            try {
                Write-Output "##[section]Cleaning up the resource group `"$snrResourceGroupName`"."
                Clear-LiveTestResources -Name $snrResourceGroupName
            }
            catch {
                # Ignore exception for clean up
            }
        }

        Write-Output "##[endgroup]"
    }
}

function Clear-LiveTestResources {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [Alias("ResourceGroupName")]
        [string] $Name
    )

    $cmd = { Remove-AzResourceGroup -Name $Name -Force -AsJob | Out-Null }
    $displayCmd = $ExecutionContext.InvokeCommand.ExpandString($cmd.ToString())
    Invoke-LiveTestCommand -Command $cmd -DisplayCommand $displayCmd
}

function ConvertToLiveTestJsonErrors {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Errors
    )

    $errorsObj = [PSCustomObject]@{
        Exception = $Errors[0]
    }
    for ($n = 1; $n -lt $Errors.Count; $n++) {
        $errorsObj | Add-Member -NotePropertyName "Retry$($n)Exception" -NotePropertyValue $Errors[$n]
    }

    (ConvertTo-Json $errorsObj -Compress)
}

InitializeLiveTestModule
