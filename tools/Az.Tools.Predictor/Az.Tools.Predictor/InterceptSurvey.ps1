# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.internal
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# This file is a temporary approach to prompt the user for a survey.
# It doesn't cover every case well or not tested well:
# 1. Allow two or more modules to show the survey link.
# 2. When the major version is changed.
# 3. Not sure about the way to handle survey id or if it's needed in future.
# 4. The file format is also subject to change in future.

param (
    [Parameter(Mandatory)]
    [string] $moduleName,
    [Parameter(Mandatory)]
    [int] $majorVersion
)

if ([string]::IsNullOrWhiteSpace($moduleName)) {
    return
}

if ($majorVersion -lt 0) {
    return
}

if ($env:Azure_PS_Intercept_Survey -eq "false") {
    return
}

$mutexName = "AzModulesInterceptSurvey"
$mutexTiimeout = 1000
$interceptDays = 30
$interceptLoadTimes = 3
$today = Get-Date
$mutexTimeout = 500

function ConvertTo-String {
    param (
        [Parameter(Mandatory)]
        [DateTime] $date
    )

    return $date.ToString("yyyy-MM-dd")
}

function Init-InterceptFile {
    $interceptContent = @{
        "lastInterceptCheckDate"=ConvertTo-String($today);
        "interceptTriggered"=$false;
        "modules"=@(@{
            "name"=$moduleName;
            "majorVersion"=$majorVersion;
            "activeDays"=1;
            "lastActiveDate"=ConvertTo-String($today);
        })
    }

    ConvertTo-Json -InputObject $interceptContent | Out-File -FilePath $interceptFilePath -Encoding utf8
}

# Update the intercept object and return $true if we need to show the survey.
function Update-InterceptObject {
    param (
        $interceptObject
    )

    $thisModule = $null

    foreach ($m in $interceptObject.modules) {
        if ($m.name -eq $moduleName) {
            $thisModule = $m
            break
        }
    }

    if ($thisModule -eq $null) {
        # There is no information about this module. The file could be created by another module or in some other way.
        # We need to add this module to the list.

        $thisModule = @{
            "name"=$moduleName;
            "majorVersion"=$majorVersion;
            "activeDays"=1;
            "lastActiveDate"=ConvertTo-String($today);
        }

        $interceptObject.modules += $thisModule

        return $false
    }

    $recordedMajorVersion = $thisModule.majorVersion
    $thisModule.majorVersion = $majorVersion

    if ($recordedMajorVersion -ne $majorVersion) {
        $thisModule.activeDays = 1
        $thisModule.lastActiveDate = ConvertTo-String($today)
        $interceptObject.interceptTriggered = $false

        return $false
    }

    $recordedLastActiveDate = Get-Date $thisModule.lastActiveDate
    $recordedActiveDays = $thisModule.activeDays

    $elapsedDays = ($today - $recordedLastActiveDate).Days

    if ($elapsedDays -gt $interceptDays) {
        $thisModule.activeDays = 1
        $thisModule.lastActiveDate = ConvertTo-String($today)

        return $false
    }

    $newActiveDays = $recordedActiveDays

    if ($elapsedDays -ne 0) {
        $newActiveDays++
    }

    if ($newActiveDays -ge $interceptLoadTimes) {
        $thisModule.activeDays = 0
        $thisModule.lastActiveDate = ConvertTo-String($today)
        $interceptObject.interceptTriggered = $true
        return $true
    }

    $thisModule.activeDays = $newActiveDays
    $thisModule.lastActiveDate = ConvertTo-String($today)
}

$mutex = New-Object System.Threading.Mutex($false, $mutexName)

$hasMutex = $mutex.WaitOne($mutexTimeout)

if (-not $hasMutex) {
    return
}

$shouldIntercept = $false

try
{
    $interceptFilePath = Join-Path -Path (Join-Path -Path $env:USERPROFILE -ChildPath ".Azure") -ChildPath "InterceptSurvey.json"

    if (-not (Test-Path $interceptFilePath)) {
        New-Item -ItemType File -Force -Path $interceptFilePath
        Init-InterceptFile
    } else {
        $interceptObject = $null
        try {
            $fileContent = Get-Content $interceptFilePath | Out-String
            $interceptObject = ConvertFrom-Json $fileContent
        } catch {
            Init-InterceptFile
        }

        if (-not ($interceptObject -eq $null)) {
            $shouldIntercept = Update-InterceptObject($interceptObject)

            ConvertTo-Json -InputObject $interceptObject | Out-File $interceptFilePath -Encoding utf8
        }
    }
} catch {
}

$mutex.ReleaseMutex()

if ($shouldIntercept) {
    $userId = (Get-AzContext).Account.Id
    $surveyId = "000000"

    if ($userId -ne $null)
    {
        $surveyId = Get-Random -Maximum 1000000 -SetSeed $userId.GetHashCode()
        try {
            $azPredictorSettingFilePath = Join-Path -Path (Join-Path -Path $env:USERPROFILE -ChildPath ".Azure") -ChildPath "AzPredictorSettings.json"
            $setting = @{
                "surveyId"=$surveyId;
            }

            if (Test-Path $azPredictorSettingFilePath) {
                try {
                    $setting = Get-Content $azPredictorSettingFilePath | Out-String | ConvertFrom-Json
                    $setting | Add-Member -NotePropertyName "surveyId" -NotePropertyValue $surveyId -Force
                } catch {
                }
            }

            ConvertTo-Json -InputObject $setting | Out-File -FilePath $azPredictorSettingFilePath -Encoding utf8
        } catch {
        }
    }

    $escape = $([char]27)
    Write-Host "`n$escape[7mHow was your experience using Az predictor?      $escape[27m`n" -NoNewline; Write-Host "$escape[7mhttp://aka.ms/azpredictorisurvey?SessionId=$surveyId$escape[27m" -NoNewline
    Write-Host "`n"
}
