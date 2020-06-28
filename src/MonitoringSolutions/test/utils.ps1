function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    Write-Host -ForegroundColor Yellow "Required Az.OperationalInsights, please check if Az.OperationalInsights installed"
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'eastus'
    # For any resources you created for test, you should add it to $env here.
    #Generate some random strings for use in the test.
    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6

    #Create the test group.
    Write-Host -ForegroundColor Green 'Create test group'
    $resourceGroup = 'monitoringsolutions-rg-' + $rstr1
    New-AzResourceGroup -Name $resourceGroup -Location $env.location
    $null = $env.Add('resourceGroup', $resourceGroup)
    Write-Host -ForegroundColor Green 'The test group created successfully'

    # Deploy operational insights workspace
    Write-Host -ForegroundColor Green 'Deploying operational insights workspace'
    $workspacesName01 = 'monitoringworkspace-' + (RandomString -allChars $false -len 6)
    $workspacesName02 = 'monitoringworkspace-' + (RandomString -allChars $false -len 6)
    <# Deploy failed, azure portal responsed error message: "statusMessage": "{\"error\":{\"code\":\"InvalidRequestContent\",\"message\":\"The request content was invalid and could not be deserialized: 'Error converting value \\\"insights-jxvq9o\\\" to type 'Microsoft.WindowsAzure.ResourceStack.Frontdoor.Data.Definitions.DeploymentParameterDefinition'. Path 'properties.parameters.workspaces_name', line 5, position 42.'.\"}}",
    $workspacesParam = Get-Content .\test\deployment-templates\operational-insightsworkspace\parameters.json | ConvertFrom-Json
    $workspacesParam.parameters.workspaces_yemingmonitor_name = 'lucasmonitor'
    set-content -Path .\test\deployment-templates\operational-insightsworkspace\parameters.json -Value (ConvertTo-Json $workspacesParam)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\operational-insightsworkspace\template.json -TemplateParameterFile .\test\deployment-templates\operational-insightsworkspace\parameters.json -ResourceGroupName $env.resourceGroup
    #>
    $workspace01 = New-AzOperationalInsightsWorkspace -ResourceGroupName $env.resourceGroup -Name $workspacesName01 -Location $env.location -Sku "Standard"
    $workspace02 = New-AzOperationalInsightsWorkspace -ResourceGroupName $env.resourceGroup -Name $workspacesName02 -Location $env.location -Sku "Standard"
    $null = $env.Add('workspaceResourceId01', $workspace01.ResourceId)
    $null = $env.Add('workspaceResourceId02', $workspace02.ResourceId)
    Write-Host -ForegroundColor Green 'The operational insights workspace deployed successfully'

    # Create monitor log analytics for test.
    Write-Host -ForegroundColor Green 'create monitor log analytics'
    $monitor = New-AzMonitorLogAnalyticsSolution -Type Containers -ResourceGroupName $env.resourceGroup -Location $env.location -WorkspaceResourceId $env.workspaceResourceId01
    $env.Add('monitorName01', $monitor.Name)
    Write-Host -ForegroundColor Green 'The monitor log analytics created successfully'

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

