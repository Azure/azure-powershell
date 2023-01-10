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
    [string] $BuildId,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $OSVersion,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $PSVersion,

    [Parameter()]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $DataLocation
)

New-Variable -Name ResourceGroupPrefix -Value "azpsliverg" -Scope Script -Option Constant
New-Variable -Name ResourcePrefix -Value "azpslive" -Scope Script -Option Constant
New-Variable -Name StorageAccountPrefix -Value "azpslivesa" -Scope Script -Option Constant

New-Variable -Name CommandMaxRetryCount -Value 3 -Scope Script -Option Constant
New-Variable -Name CommandDelay -Value 10 -Scope Script -Option Constant
New-Variable -Name ScenarioMaxRetryCount -Value 5 -Scope Script -Option Constant
New-Variable -Name ScenarioMaxDelay -Value 60 -Scope Script -Option Constant
New-Variable -Name ScenarioDelay -Value 5 -Scope Script -Option Constant

New-Variable -Name LiveTestAnalysisDirectory -Value (Join-Path -Path $DataLocation -ChildPath "LiveTestAnalysis") -Scope Script -Option Constant
New-Variable -Name LiveTestRawDirectory -Value (Join-Path -Path $script:LiveTestAnalysisDirectory -ChildPath "Raw") -Scope Script -Option Constant
New-Variable -Name LiveTestRawCsvFile -Value (Join-Path -Path $script:LiveTestRawDirectory -ChildPath "Az.$ModuleName.csv") -Scope Script -Option Constant

function InitializeLiveTestModule {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [string] $ModuleName
    )

    if (!(Test-Path -LiteralPath $script:LiveTestAnalysisDirectory -PathType Container)) {
        New-Item -Path $script:LiveTestAnalysisDirectory -ItemType Directory -Force
        New-Item -Path $script:LiveTestRawDirectory -ItemType Directory -Force
    }

    ({} | Select-Object "BuildId", "OSVersion", "PSVersion", "Module", "Name", "Description", "StartDateTime", "EndDateTime", "IsSuccess", "Errors" | ConvertTo-Csv -NoTypeInformation)[0] | Out-File -LiteralPath $script:LiveTestRawCsvFile -Encoding utf8 -Force
}

function New-LiveTestRandomName {
    [CmdletBinding()]
    [OutputType([string])]
    param ()

    $alphanumerics = "0123456789abcdefghijklmnopqrstuvwxyz"
    $randomName = $alphanumerics[(Get-Random -Maximum 10)]
    for ($i = 0; $i -lt 9; $i ++) {
        $randomName += $alphanumerics[(Get-Random -Maximum $alphanumerics.Length)]
    }

    $randomName
}

function New-LiveTestResourceGroupName {
    [CmdletBinding()]
    [OutputType([string])]
    param ()

    $rgPrefix = $script:ResourceGroupPrefix
    $rgName = New-LiveTestRandomName

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

    $rg = Invoke-LiveTestCommand -Command "New-AzResourceGroup -Name $Name -Location $Location"
    $rg
}

function New-LiveTestResourceName {
    [CmdletBinding()]
    [OutputType([string])]
    param ()

    $rPrefix = $script:ResourcePrefix
    $rName = New-LiveTestRandomName

    $rFullName = "$rPrefix$rName"
    $rFullName
}

function New-LiveTestStorageAccountName {
    [CmdletBinding()]
    [OutputType([string])]
    param ()

    $saPrefix = $script:StorageAccountPrefix
    $saName = New-LiveTestRandomName

    $saFullName = "$saPrefix$saName"
    $saFullName
}

function Invoke-LiveTestCommand {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory, ValueFromPipeline)]
        [ValidateNotNullOrEmpty()]
        [string] $Command
    )

    $cmdRetryCount = 0

    do {
        try {
            Write-Host "##[section]Start to execute the command '$Command'" -ForegroundColor Green
            Write-Host "##[command]The command '$Command' is running" -ForegroundColor Cyan

            $cmdResult = Invoke-Expression -Command $Command -ErrorAction Stop

            Write-Host "##[section]Successfully executed the command '$Command'" -ForegroundColor Green
            $cmdResult
            break
        }
        catch {
            $cmdErrorMessage = $_.Exception.Message
            if ($cmdRetryCount -le $script:CommandMaxRetryCount) {
                Write-Warning "Error occurred when executing the command '$Command' with error message '$cmdErrorMessage'."
                Write-Warning "Live test will retry automatically in $script:CommandMaxRetryCount seconds."
                Write-Host

                Start-Sleep -Seconds $script:CommandDelay
                $cmdRetryCount++
                Write-Warning "Retrying #$cmdRetryCount to execute the command '$Command'."
            }
            else {
                throw "Failed to execute the command '$Command' after retrying for $script:CommandMaxRetryCount time(s) with error message '$cmdErrorMessage'."
            }
        }
    }
    while ($true)
}

function Invoke-LiveTestScenario {
    [CmdletBinding()]
    [OutputType([bool])]
    param (
        [Parameter(Mandatory, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [string] $Name,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $Description,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $ResourceGroupLocation,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [scriptblock] $ScenarioScript
    )

    if (!(Test-Path -LiteralPath $script:LiveTestRawCsvFile -PathType Leaf -ErrorAction SilentlyContinue)) {
        throw "Error occurred when initializing live tests. The csv file was not found."
    }

    Write-Host "##[group]Start to execute the live scenario '$Name'." -ForegroundColor Green

    try {
        $snrCsvData = [PSCustomObject]@{
            BuildId       = $BuildId
            OSVersion     = $OSVersion
            PSVersion     = $PSVersion
            Module        = $ModuleName
            Name          = $Name
            Description   = $Description
            StartDateTime = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss")
            EndDateTime   = $null
            IsSuccess     = $true
            Errors        = ""
        }

        $snrResourceGroupName = New-LiveTestResourceGroupName
        $snrResourceGroupLocation = "westus"
        if ($PSBoundParameters.ContainsKey("ResourceGroupLocation")) {
            $snrResourceGroupLocation = $ResourceGroupLocation
        }

        Write-Host "##[section]Start to create a resource group."
        Write-Host "##[section]Resource group name: $snrResourceGroupName" -ForegroundColor Green
        Write-Host "##[section]Resource group location: $snrResourceGroupLocation" -ForegroundColor Green

        $snrResourceGroup = New-LiveTestResourceGroup -Name $snrResourceGroupName -Location $snrResourceGroupLocation

        Write-Host "##[section]Successfully created the resource group."

        $snrRetryCount = 0
        $snrRetryErrors = @()

        do {
            try {
                Invoke-Command -ScriptBlock $ScenarioScript -ArgumentList $snrResourceGroup -ErrorAction Stop
                Write-Host "##[section]Successfully executed the live scenario '$Name'." -ForegroundColor Green
                break
            }
            catch {
                $snrErrorMessage = $_.Exception.Message
                if ($snrRetryCount -eq 0) {
                    $snrErrorDetails = "Error occurred when executing the live scenario [$Name] with error message [$snrErrorMessage]"
                }
                else {
                    $snrErrorDetails = "Error occurred when retrying #$snrRetryCount of the live scenario with error message [$snrErrorMessage]"
                }

                $snrInvocationInfo = $_.Exception.CommandInvocation
                if ($null -ne $snrInvocationInfo) {
                    $snrErrorDetails += " thrown at line:$($snrInvocationInfo.ScriptLineNumber) char:$($snrInvocationInfo.OffsetInLine) by cmdlet [$($snrInvocationInfo.InvocationName)] on [$($snrInvocationInfo.Line.ToString().Trim())]."
                }

                $snrRetryErrors += $snrErrorDetails

                if ($snrRetryCount -lt $script:ScenarioMaxRetryCount) {
                    $snrRetryCount++
                    $exponentialDelay = [Math]::Min((1 -shl ($snrRetryCount - 1)) * [int](Get-Random -Minimum ($script:ScenarioDelay * 0.8) -Maximum ($script:ScenarioDelay * 1.2)), $script:ScenarioMaxDelay)
                    Write-Warning "Error occurred when executing the live scenario '$Name' with error message '$snrErrorMessage'."
                    Write-Warning "Live test will retry automatically in $exponentialDelay seconds."
                    Write-Host

                    Start-Sleep -Seconds $exponentialDelay
                    Write-Warning "Retrying #$snrRetryCount to execute live scenario '$Name'."
                }
                else {
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
        Write-Warning "Error occurred when executing the live scenario '$Name' with error message '$snrErrorMessage'"
        $snrCsvData.IsSuccess = $false
        $snrCsvData.Errors = ConvertToLiveTestJsonErrors -Errors $snrErrorMessage
    }
    finally {
        if ($null -ne $snrResourceGroup) {
            try {
                Write-Host "##[section]Start to clean up the resource group '$snrResourceGroupName'." -ForegroundColor Green
                Clear-LiveTestResources -Name $snrResourceGroupName
                Write-Host "##[section]Successfully cleaned up the resource group '$snrResourceGroupName'" -ForegroundColor Green
            }
            catch {
                if ($snrCsvData.Errors -eq "") {
                    $snrCsvData.Errors = ConvertToLiveTestJsonErrors -Errors $_.Exception.Message
                }
            }
        }
        $snrCsvData.EndDateTime = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss")
        Export-Csv -LiteralPath $script:LiveTestRawCsvFile -InputObject $snrCsvData -Encoding utf8 -NoTypeInformation -Append

        Write-Host "##[endgroup]"
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

    Invoke-LiveTestCommand -Command "Remove-AzResourceGroup -Name $Name -Force"
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

InitializeLiveTestModule -ModuleName $ModuleName
