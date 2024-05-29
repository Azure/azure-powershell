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
    $envFile = 'env.json'
	#Connect-AzAccount -UseDeviceAuthentication -Tenant a260d38c-96cf-492d-a340-404d0c4b3ad6
    #ApproveAllItemsCollection
    New-AzMarketplacePrivateStoreCollection -CollectionName AllItemsPWRTest1 -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa0188 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -SubscriptionsList 1052ff5a-aa43-4ca1-bd18-010399494ce5
    #CopyOfferCollection
	New-AzMarketplacePrivateStoreCollection -CollectionName CopyPWRTest1 -CollectionId 8c7a91db-cd41-43b6-af47-2e869654126d -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -SubscriptionsList 1052ff5a-aa43-4ca1-bd18-010399494ce5
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
	#Remove-AzMarketplacePrivateStoreCollection -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1
 	#Remove-AzMarketplacePrivateStoreCollection -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId 7f5402e4-e8f4-46bd-9bd1-8d27866a6065
 	Remove-AzMarketplacePrivateStoreCollection -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa0188
	Remove-AzMarketplacePrivateStoreCollection -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId 8c7a91db-cd41-43b6-af47-2e869654126d
}

