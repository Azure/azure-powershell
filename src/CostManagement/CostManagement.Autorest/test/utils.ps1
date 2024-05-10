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

function getUseModules() {
    $usedModule = & 'gmo'
    foreach($module in $usedModule)
    {
      $name = $module.Name
      $version = $module.Version
      Write-Host -ForegroundColor Green "Using module name: $name $version"
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'eastus'
    # For any resources you created for test, you should add it to $env here.
    $exportName01 = 'export-' + (RandomString -allChars $false -len 6)
    $exportName02 = 'export-' + (RandomString -allChars $false -len 6)
    $exportName03 = 'export-' + (RandomString -allChars $false -len 6)
    $exportName04 = 'export-' + (RandomString -allChars $false -len 6)

    $null = $env.Add('exportName01', $exportName01)
    $null = $env.Add('exportName02', $exportName02)
    $null = $env.Add('exportName03', $exportName03)
    $null = $env.Add('exportName04', $exportName04)

    Write-Host -ForegroundColor Green "Create test group..."
    $resourceGroup = 'costmanagement-rg-' + (RandomString -allChars $false -len 6)
    Write-Host $resourceGroup
    New-AzResourceGroup -Name $resourceGroup -Location $env.location
    $null = $env.Add('resourceGroup', $resourceGroup)
    Write-Host -ForegroundColor Green 'The test group create completed.'

    # Deploy storage account for test.
    Write-Host -ForegroundColor Green "Deploying storage account..."
    <# Cause error: The request content was invalid and could not be deserialized: 'Error converting value "staaccountuigcan" to type
                    'Microsoft.WindowsAzure.ResourceStack.Frontdoor.Data.Definitions.DeploymentParameterDefinition'. Path
                    'properties.parameters.storageAccounts_wyunchistorageaccount_name', line 5, position 70.'.

    $staaccountName = 'staaccount' + (RandomString -allChars $false -len 6)
    $staaccountParam = Get-Content .\test\deployment-templates\storage-account\parameters.json | ConvertFrom-Json
    $staaccountParam.parameters.storageAccounts_name = $staaccountName
    set-content -Path .\test\deployment-templates\storage-account\parameters.json -Value (ConvertTo-Json $staaccountParam)
    #>
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\storage-account\template.json -TemplateParameterFile .\test\deployment-templates\storage-account\parameters.json -ResourceGroupName $env.resourceGroup
    $staaccountName = 'staaccountjshubiu' # Value in template.json
    $env.storageAccountId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Storage/storageAccounts/$($staaccountName)"
    Start-Sleep -s 60 # Waiting storage account create complete.
    Write-Host -ForegroundColor Green "The storage account deployed successfully."

    Write-Host -ForegroundColor Green "Create cost management export for test..."
    $env.fromDate = (Get-Date).ToString()
    $env.toDate = (Get-Date).AddDays(20).ToString()
    #Create One CostManagementExport
    New-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01 `
    -ScheduleStatus "Active" -ScheduleRecurrence "Daily" `
    -RecurrencePeriodFrom $env.fromDate -RecurrencePeriodTo $env.toDate `
    -Format "Csv" `
    -DestinationResourceId $env.storageAccountId `
    -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" `
    -DefinitionTimeframe "MonthToDate" -DatasetGranularity "Daily"

    # Invoke-AzCostManagementExecuteExport -Scope "subscriptions/$($env.SubscriptionId)" -ExportName $env.exportName01

    Write-Host -ForegroundColor Green "The cost management export created successfully."

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

