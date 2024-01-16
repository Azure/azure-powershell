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
        Start-TestSleep -Seconds $WaitTimeInSeconds
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
        # In this latest release, all app settings from Get-AzFunctionApp should be null
        $ExpectedAppSetting[$appSettingName] | Should Be $null

        # Validate that the keys is present
        $ActualAppSetting.ContainsKey($appSettingName) | Should Be $true
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

function GetStorageAccountEndpointSuffix
{
    $environmentName = (Get-AzContext).Environment.Name

    switch ($environmentName)
    {
        "AzureUSGovernment" { ';EndpointSuffix=core.usgovcloudapi.net' }
        "AzureChinaCloud"   { ';EndpointSuffix=core.chinacloudapi.cn' }
        "AzureGermanCloud"  { ';EndpointSuffix=core.cloudapi.de' }
        "AzureCloud"        { ';EndpointSuffix=core.windows.net' }
        default { '' }
    }
}
