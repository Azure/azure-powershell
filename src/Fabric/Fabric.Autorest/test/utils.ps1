function RandomString( [int32]$len) {
    if ($len -lt 3) {
        throw "Length must be at least 3."
    }

    # Generate the random string
    return -join ((97..122)  | Get-Random -Count $len | ForEach-Object {[char]$_})
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
    $env.Location = "West US"

    # Create test resource group
    Write-Host -ForegroundColor Green "Creating test resource group..."
    $env.ResourceGroupName = "rg-AzPowerShell-Tests-Fabric-" + (RandomString -allChars $true -len 10)
    Write-Host "ResourceGroupName is $($env.ResourceGroupName)"
    New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location

    # Set the parameter values
    $env.CapacityName = RandomString -allChars $true -len 12
    Write-Host "CapacityName is $($env.CapacityName)"
    $env.SkuName = "F2"
    $env.SkuTier = "Fabric"
    $env.AdministrationMembers = @("VsavTest@pbiotest.onmicrosoft.com")
    $env.CapacityId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Fabric/capacities/$($env.CapacityName)"

    # Set deployment templates files path
    $templateFilePath = "test/deployment-templates/test-resources.json"
    $templateParametersFilePath = "test/deployment-templates/test-resources.parameters.json"

    # Read the parameters file
    $params = Get-Content $templateParametersFilePath | ConvertFrom-Json

    # Update the properties
    $params.parameters.capacityName.value = $env.CapacityName
    $params.parameters.location.value = $env.Location
    $params.parameters.skuName.value = $env.SkuName
    $params.parameters.skuTier.value = $env.SkuTier
    $params.parameters.administrationMembers.value = $env.AdministrationMembers

    # Convert the updated content back to JSON
    $updatedParams = $params | ConvertTo-Json -Depth 10
    # Save the updated parameters back to the file
    $updatedParams | Set-Content -Path $templateParametersFilePath

    # Deploy
    Write-Output "Deploying the temaplte file $templateFilePath to resource group $($env.ResourceGroupName) ..."
    New-AzDeployment -Mode Incremental -TemplateFile $templateFilePath -TemplateParameterFile $templateParametersFilePath -ResourceGroupName $env.ResourceGroupName
    Write-Output "Deployment complete with provisioning state: " $deploymentResult.ProvisioningState

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzFabricCapacity -SubscriptionId $env.SubscriptionId -CapacityName $env.CapacityName -ResourceGroupName $env.ResourceGroupName
}
