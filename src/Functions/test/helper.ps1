function WaitForJobToComplete
{
    Param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [int]
        $JobId,

        $WaitTimeInSeconds = 3,

        $MaxNumberOfTries = 100
    )

    # Wait for the job to complete. Max timeout is 5 minutes
    $result = $null
    $maxNumberOfTries = 100
    $waitTimeinSeconds = 3

    $tries = 1
    while ($true)
    {
        Write-Verbose "Wait time in seconds: $($tries*$WaitTimeInSeconds)" -Verbose
        Start-Sleep -Seconds $WaitTimeInSeconds
        $result = Get-Job -Id $JobId
        Write-Verbose "JobState: $($result.State)" -Verbose

        if (($tries -ge $maxNumberOfTries) -or ($result.State -ne "Running"))
        {
            Write-Verbose "JobState: $($result.State)" -Verbose
            return $result
        }

        $tries++
    }
}

function ValidateAppSetting
{
    Param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNull()]
        [Hashtable]
        $ExpectedAppSetting,

        [Parameter(Mandatory=$true)]
        [ValidateNotNull()]
        [Hashtable]
        $ActualAppSetting
    )

    $ExpectedAppSetting.Count | Should Be $ActualAppSetting.Count

    foreach ($appSettingName in $ExpectedAppSetting.Keys)
    {
        $ActualAppSetting[$appSettingName] | Should Be $ExpectedAppSetting[$appSettingName]
    }
}

function ValidateAvailableLocation
{
    Param
    (
        [Parameter(Mandatory=$true)]
        [String[]]
        $ActualRegions,

        [Parameter(Mandatory=$true)]
        [String[]]
        $ExpectedRegions
    )

    foreach ($region in $ExpectedRegions)
    {
        $ActualRegions | Should -Contain $region
    }
}