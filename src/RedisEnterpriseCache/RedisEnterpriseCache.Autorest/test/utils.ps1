function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
function New-RedisEnterpriseCacheTestPolicyTokenObserver {
    param([hashtable]$Observation)
    {
        param($request, $eventListener, $next)
        if ($request.Method.Method -in 'POST', 'PUT', 'PATCH', 'DELETE') {
            $header = 'x-ms-policy-external-evaluations'
            if (-not $request.Headers.Contains($header)) {
                throw 'The tested write has no Change Safety policy header.'
            }
            foreach ($value in $request.Headers.GetValues($header)) {
                if ([string]::IsNullOrWhiteSpace($value) -or $value -eq '[Filtered]') {
                    throw 'The tested write has an empty or filtered Change Safety policy header.'
                }
            }
            $Observation.Writes++
        }
        $next.SendAsync($request, $eventListener)
    }.GetNewClosure()
}

function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.ClusterName  = 'ps-cache-test1-' + (RandomString -allChars $false -len 8)
    $env.ClusterName2 = 'ps-cache-test2-' + (RandomString -allChars $false -len 8)
    $env.ClusterName3  = 'ps-cache-test3-' + (RandomString -allChars $false -len 8)
    $env.ClusterName4 = 'ps-cache-test4-' + (RandomString -allChars $false -len 8)
    $env.ResourceGroupName = 'ps-redisenterprise-rg-' + (RandomString -allChars $false -len 8)
    $env.Location = 'eastus'
    New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location | Out-Null

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroupName | Out-Null
}
