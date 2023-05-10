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

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $PowerShellLatest,

    [Parameter()]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
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

    if (!(Test-Path -LiteralPath $script:LiveTestAnalysisDirectory -PathType Container)) {
        New-Item -Path $script:LiveTestAnalysisDirectory -ItemType Directory -Force
        New-Item -Path $script:LiveTestRawDirectory -ItemType Directory -Force
    }

    ({} | Select-Object "PSVersion", "Module", "Name", "Description", "StartDateTime", "EndDateTime", "IsSuccess", "Errors" | ConvertTo-Csv -NoTypeInformation)[0] | Out-File -LiteralPath $script:LiveTestRawCsvFile -Encoding utf8 -Force
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
        [string] $Location = "westus"
    )

    $rg = Invoke-LiveTestCommand -Command { New-AzResourceGroup -Name $Name -Location $Location -Force }
    $rg
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

function Invoke-LiveTestCommand {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory, ValueFromPipeline)]
        [ValidateNotNullOrEmpty()]
        [scriptblock] $Command
    )

    $cmdRetryCount = 0

    do {
        try {
            $expandedCommand = $ExecutionContext.InvokeCommand.ExpandString($Command)
            Write-Host "##[section]Start executing the command `"$expandedCommand`"." -ForegroundColor Green
            Write-Host "##[command]The command `"$expandedCommand`" is running." -ForegroundColor Cyan

            $cmdResult = $Command.InvokeWithContext($null, [psvariable]::new("ErrorActionPreference", "Stop"))

            Write-Host "##[section]Finish executing the command `"$expandedCommand`"" -ForegroundColor Green

            $cmdResult
            break
        }
        catch {
            $cmdErrorMessage = $_.Exception.InnerException.Message
            if ($cmdRetryCount -lt $script:CommandMaxRetryCount) {
                Write-Host "##[warning]Error occurred when executing the command `"$Command`" with error message `"$cmdErrorMessage`"." -ForegroundColor Yellow
                Write-Host "##[warning]Live test will retry automatically in $script:CommandDelay seconds." -ForegroundColor Yellow
                Write-Host

                Start-Sleep -Seconds $script:CommandDelay
                $cmdRetryCount++
                Write-Host "##[warning]Retry #$cmdRetryCount to execute the command `"$Command`"." -ForegroundColor Yellow
            }
            else {
                $cmdFinalErrorMessage = "Failed to execute the command `"$Command`" after retrying for $script:CommandMaxRetryCount time(s) with error message `"$cmdErrorMessage`"."
                Write-Host "##[error]$cmdFinalErrorMessage" -ForegroundColor Red
                Write-Host
                throw $cmdFinalErrorMessage
            }
        }
    }
    while ($true)
}

function Invoke-LiveTestScenario {
    [CmdletBinding(DefaultParameterSetName = "HasDefaultResourceGroup")]
    [OutputType([bool])]
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
        [ValidateSet("5.1", "Latest")]
        [string[]] $PowerShellVersion,

        [Parameter(ParameterSetName = "HasDefaulResourceGroup")]
        [ValidateNotNullOrEmpty()]
        [string] $ResourceGroupLocation,

        [Parameter(ParameterSetName = "HasNoDefaultResourceGroup")]
        [switch] $NoResourceGroup,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [scriptblock] $ScenarioScript
    )

    $proceed = $true

    if ($PSBoundParameters.ContainsKey("Platform") -and $RunPlatform -notin $Platform) {
        $proceed = $false
    }

    $curPSVer = (Get-Variable -Name PSVersionTable -ValueOnly).PSVersion
    if ($PSBoundParameters.ContainsKey("PowerShellVersion")) {
        $psSimpleVer = $PowerShellVersion -replace "Latest", $PowerShellLatest
        $curMajorVer = $curPSVer.Major
        $curMinorVer = $curPSVer.Minor
        $curSimpleVer = "$curMajorVer.$curMinorVer"
        if ($curSimpleVer -notin $psSimpleVer) {
            $proceed = $false
        }
    }

    if (!(Test-Path -LiteralPath $script:LiveTestRawCsvFile -PathType Leaf -ErrorAction SilentlyContinue)) {
        throw "Error occurred when initializing live tests. The csv file was not found."
    }

    if ($proceed) {
        Write-Host "##[group]Start executing the live scenario `"$Name`"." -ForegroundColor Magenta

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

                Write-Host "##[section]Start creating a resource group." -ForegroundColor Green
                Write-Host "##[section]Resource group name: $snrResourceGroupName" -ForegroundColor Green
                Write-Host "##[section]Resource group location: $snrResourceGroupLocation" -ForegroundColor Green

                $snrResourceGroup = New-LiveTestResourceGroup -Name $snrResourceGroupName -Location $snrResourceGroupLocation

                Write-Host "##[section]Finish creating the resource group." -ForegroundColor Green
            }

            $snrRetryCount = 0
            $snrRetryErrors = @()

            do {
                try {
                    $prefs = @([psvariable]::new("ErrorActionPreference", "Stop"), [psvariable]::new("ConfirmPreference", "None"))
                    if ($snrRetryCount -eq $script:ScenarioMaxRetryCount) {
                        $prefs += [psvariable]::new("DebugPreference", "Continue")
                    }

                    $ScenarioScript.InvokeWithContext($null, $prefs, $snrResourceGroup)

                    Write-Host "##[section]Finish executing the live scenario `"$Name`"." -ForegroundColor Green

                    break
                }
                catch {
                    $snrErrorRecord = $_.Exception.InnerException.ErrorRecord
                    $snrErrorMessage = $snrErrorRecord.Exception.Message
                    $snrErrorDetails = $snrErrorMessage

                    $snrInvocationInfo = $snrErrorRecord.InvocationInfo

                    if ($null -ne $snrInvocationInfo) {
                        $snrScriptName = Split-Path -Path $snrInvocationInfo.ScriptName -Leaf -ErrorAction SilentlyContinue
                        if ($snrScriptName -eq "Assert.ps1") {
                            Write-Host "##[error]Exception was thrown from the Assert.ps1. The stack trace is:" -ForegroundColor Red
                            Write-Host "##[error]$($snrErrorRecord.ScriptStackTrace)" -ForegroundColor Red
                        }
                        else {
                            $snrErrorDetails += " thrown at line:$($snrInvocationInfo.ScriptLineNumber) char:$($snrInvocationInfo.OffsetInLine) by cmdlet '$($snrInvocationInfo.MyCommand)' on '$($snrInvocationInfo.Line.ToString().Trim())'"
                        }
                    }

                    $snrRetryErrors += $snrErrorDetails

                    if ($snrRetryCount -lt $script:ScenarioMaxRetryCount) {
                        $snrRetryCount++
                        $exponentialDelay = [Math]::Min((1 -shl ($snrRetryCount - 1)) * [int](Get-Random -Minimum ($script:ScenarioDelay * 0.8) -Maximum ($script:ScenarioDelay * 1.2)), $script:ScenarioMaxDelay)
                        Write-Host "##[warning]Error occurred when executing the live scenario `"$Name`" with error details `"$snrErrorDetails`"." -ForegroundColor Yellow
                        Write-Host "##[warning]Live test will retry automatically in $exponentialDelay seconds." -ForegroundColor Yellow
                        Write-Host

                        Start-Sleep -Seconds $exponentialDelay
                        Write-Host "##[warning]Retry #$snrRetryCount to execute the live scenario `"$Name`"." -ForegroundColor Yellow
                    }
                    else {
                        Write-Host "##[error]Failed to execute the live scenario `"$Name`" with error details `"$snrErrorDetails`"." -ForegroundColor Red
                        Write-Host
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
            Write-Host "##[error]Error occurred when executing the live scenario `"$Name`" with error details `"$snrErrorDetails`"" -ForegroundColor Red
            Write-Host
            $snrCsvData.IsSuccess = $false
            $snrCsvData.Errors = ConvertToLiveTestJsonErrors -Errors $snrErrorMessage
        }
        finally {
            $snrCsvData.EndDateTime = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss")
            $snrCsvData | Export-Csv -LiteralPath $script:LiveTestRawCsvFile -Encoding utf8 -NoTypeInformation -Append

            if (!$NoResourceGroup.IsPresent -and $null -ne $snrResourceGroup) {
                try {
                    Write-Host "##[section]Start cleaning up the resource group `"$snrResourceGroupName`"." -ForegroundColor Green
                    Clear-LiveTestResources -Name $snrResourceGroupName
                }
                catch {
                    # Ignore exception for clean up
                }
            }

            Write-Host "##[endgroup]" -ForegroundColor Magenta
        }
    }
}

function Clear-LiveTestResources {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [Alias("ResourceGroupname")]
        [string] $Name
    )

    Invoke-LiveTestCommand -Command { Remove-AzResourceGroup -Name $Name -Force -AsJob | Out-Null }
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
