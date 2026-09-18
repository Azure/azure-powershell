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
    Get-AzContext
    
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    
    $resourceGroup = "azmdppwsh" + (RandomString -allChars $false -len 6)
    $location = "westus"
    New-AzResourceGroup -Name $resourceGroup -Location $location

    $devCenterLocation = "australiaeast"
    $devCenterName = "azmdp-" + (RandomString -allChars $false -len 6)
    $devCenterProjectName = "azmdp-" + (RandomString -allChars $false -len 6)
    $mdpPoolNameGet = "azmdp-" + (RandomString -allChars $false -len 6)
    $mdpPoolNameDelete = "azmdp-" + (RandomString -allChars $false -len 6)
    $mdpPoolNameNew = "azmdp-" + (RandomString -allChars $false -len 6)

    $env.Add("Location", $location)
    $env.Add("ResourceGroup", $resourceGroup)
    $env.Add("DevCenterName", $devCenterName)
    $env.Add("DevCenterProjectName", $devCenterProjectName)
    $env.Add("DevCenterLocation", $devCenterLocation)
    $env.Add("MdpPoolNameGet", $mdpPoolNameGet)
    $env.Add("MdpPoolNameDelete", $mdpPoolNameDelete)
    $env.Add("MdpPoolNameNew", $mdpPoolNameNew)

    $template = Get-Content .\test\deploymentTemplates\parameter.json | ConvertFrom-Json

    $template.parameters.location.value = $location
    $template.parameters.devCenterName.value = $devCenterName
    $template.parameters.devCenterProjectName.value = $devCenterProjectName
    $template.parameters.devCenterLocation.value = $devCenterLocation
    $template.parameters.mdpPoolNameGet.value = $mdpPoolNameGet
    $template.parameters.mdpPoolNameDelete.value = $mdpPoolNameDelete

    Write-Host -ForegroundColor Magenta "Deploying test setup resources"
    Set-Content -Path .\test\deploymentTemplates\parameter.json -Value (ConvertTo-Json $template -depth 10)
    New-AzResourceGroupDeployment -TemplateFile .\test\deploymentTemplates\template.json -TemplateParameterFile .\test\deploymentTemplates\parameter.json -Name azMdpInitTestTemplate -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Magenta "Deployed test setup resources"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}
