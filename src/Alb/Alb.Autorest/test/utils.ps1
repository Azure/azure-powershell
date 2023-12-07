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
    $env.resourceGroup = "test-rg"
    $env.vnetName = "test-vnet"
    $env.subnetName = "alb-subnet"
    $env.extraSubnetName = "extra-alb-subnet"
    $env.albName = "test-alb"
    $env.removeAlbName = ("remove-{0}" -f $env.albName)
    $env.deleteAlbName = ("delete-{0}" -f $env.albName)
    $env.associationAlbName = ("association-{0}" -f $env.albName)
    $env.albAssociationName = "test-association"
    $env.albFrontendName = "test-frontend"
    $env.region = "northcentralus"
    $env.subnetId = ("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}/subnets/{3}" -f $env.SubscriptionId, $env.resourceGroup, $env.vnetName, $env.subnetName)
    $env.extraSubnetId = ("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}/subnets/{3}" -f $env.SubscriptionId, $env.resourceGroup, $env.vnetName, $env.extraSubnetName)

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)

    # Build dependent resources
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.region
    New-AzDeployment -TemplateFile "/src/Alb/test/prereqs.json" -Mode Complete -ResourceGroupName $env.resourceGroup -TemplateParameterObject @{}

}
function cleanupEnv() {
    # Clean resources you create for testing
}

