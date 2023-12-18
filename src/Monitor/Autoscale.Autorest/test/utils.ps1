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
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $resourceGroupName = 'autoscale-group' + (RandomString -allChars $false -len 6)
    write-host "start to create test group $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location eastus
    $null = $env.Add("resourceGroupName", $resourceGroupName)

    $vmssName = 'test-vmss' + (RandomString -allChars $false -len 6)
    $vmPassword = ConvertTo-SecureString "Testpassword001!" -AsPlainText -Force
    $vmCred = New-Object System.Management.Automation.PSCredential('USERNAME', $vmPassword)
    write-host "start to create vm scale set $vmssName"
    New-AzVmss -Credential $vmCred -VMScaleSetName $vmssName -ResourceGroup $resourceGroupName
    $null = $env.Add("vmssName", $vmssName)
    $vmssId = (Get-AzVmss -ResourceGroupName $resourceGroupName -VMScaleSetName $vmssName).Id
    $null = $env.Add("vmssId", $vmssId)

    $autoscaleSettingName = 'test-autoscalesetting' + (RandomString -allChars $false -len 6)
    $env.Add('autoscaleSettingName', $autoscaleSettingName)

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroupName
}

