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
    
    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $env.Add("rstr1", $rstr1)
    $env.Add("rstr2", $rstr2)

    # Create the test group
    write-host "creating test resource group..."
    $resourceGroup = "testgroup" + $rstr1
    $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $resourceGroup -Location eastus
    write-host "ResourceGroup : " $resourceGroup

    # Create the resource name for New-AzCommunicationServiceSmtpUsername
    $smtpUsernameResource = "testSmtpUsernameResource" + $rstr1
    $env.Add("smtpUsernameResource", $smtpUsernameResource)
    write-host "SmtpUsernameResource : " $smtpUsernameResource

    $username = "testusername" + $rstr1
    $env.Add("username", $username)

    $entraApplicationId = "735ffca9-2020-4c43-a16d-128dd4221e90"
    $env.Add("entraApplicationId", $entraApplicationId)

    $tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"
    $env.Add("tenantId", $tenantId)

    # Add location values
    $dataLocation = "UnitedStates"
    $location = "Global"
    $env.Add("dataLocation", $dataLocation)
    $env.Add("location", $location)

    write-host "creating a persistent test resource..."
    # Create a persistent test resource
    $persistentACSResourceName = "persistentACSResourceName" + $rstr1
    $env.Add("persistentACSResourceName", $persistentACSResourceName)
    $persistentACSResource = New-AzCommunicationService -ResourceGroupName $resourceGroup -Name $persistentACSResourceName -DataLocation $dataLocation -Location $location
    write-host "PersistentACSResourceName : " $persistentACSResourceName
    
    write-host "creating a persistent test smtp username resource..."
    # Create a persistent test smtp username resource
    $persistentSmtpUsernameResourceName = "persistentSmtpUsernameResourceName" + $rstr1
    $env.Add("persistentSmtpUsernameResourceName", $persistentSmtpUsernameResourceName)
    $persistentSmtpUsernameResource = New-AzCommunicationServiceSmtpUsername -SmtpUsername $smtpUsernameResource -CommunicationServiceName $persistentACSResourceName -ResourceGroupName $resourceGroup -EntraApplicationId $entraApplicationId -TenantId $tenantId -Username $username
    write-host "PersistentSmtpUsernameResourceName : " $persistentSmtpUsernameResourceName

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

