param (
    [Parameter(Mandatory)]
    [string] $moduleName,
    [Parameter(Mandatory)]
    [int] $majorVersion
)

if ([string]::IsNullOrWhiteSpace($moduleName))
{
    return
}

$mutexName = "AzModulesInterceptSurvey"
$mutexTiimeout = 1000
$interceptDays = 30
$interceptLoadTimes = 3
$today = Get-Date

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

    if ($today -ne $recordedLastActiveDate) {
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

$mutex.WaitOne($mutexTimeout)
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
} finally
{
    $mutex.ReleaseMutex()
}

Write-Host "To enable suggestions from Az predictor, run: Set-PSReadLineOption -PredictionSource HistoryAndPlugin"

if ($shouldIntercept) {
    $userId = (Get-AzContext).Account.Id
    if ($userId -ne $null)
    {
        $surveyId = Get-Random -Maximum 1000000 -SetSeed $userId.GetHashCode()
        Write-Host "We are listening, please share your feedback about Az Predictor: http://aka.ms/azpredictorsurvey?iQ_CHL=intercept&surveyId=$surveyId"

        try {
            $azPredictorSettingFilePath = Join-Path -Path (Join-Path -Path $env:USERPROFILE -ChildPath ".Azure") -ChildPath "AzPredictorSettings.json"
            $setting = @{
                "surveyId"=$surveyId;
            }

            if (Test-Path $azPredictorSettingFilePath) {
                try {
                    $setting = Get-Content $azPredictorSettingFilePath | Out-String | ConvertFrom-Json
                    $setting | Add-Member -NotePropertyName "surveyId" -NotePropertyValue $surveyId
                } catch {
                }
            }

            ConvertTo-Json -InputObject $setting | Out-File -FilePath $azPredictorSettingFilePath -Encoding utf8
        } catch {
        }
    } else {
        Write-Host "We are listening, please share your feedback about Az Predictor: http://aka.ms/azpredictorsurvey?iQ_CHL=intercept"
    }
}
