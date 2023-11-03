$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzProviderHubResourceTypeRegistration-CRUD.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzProviderHubResourceTypeRegistration-CRUD' {
    It 'Create, get, list, and delete ResourceTypeRegistration' {
        $endpoint = @{ApiVersion = "2018-11-01-preview", "2020-01-01-preview", "2019-01-01"; Location = "West US", "West Central US", "West Europe", "Southeast Asia", "West US 2", "East US 2 EUAP", "North Europe", "East US", "East Asia"; RequiredFeature = "Microsoft.Contoso/RPaaSSampleApp" }
        $swaggerSpecification = @{ApiVersion = "2018-11-01-preview", "2020-01-01-preview", "2019-01-01"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" }

        $resourceTypeRegistration = New-AzProviderHubResourceTypeRegistration -ProviderNamespace $env.ProviderNamespace -ResourceType "Employees" -RoutingType "Default" -Regionality "Regional" -Endpoint $endpoint -SwaggerSpecification $swaggerSpecification -EnableAsyncOperation -TemplateDeploymentOptionPreflightOption "DefaultValidationOnly" -TemplateDeploymentOptionPreflightSupported -ResourceMovePolicyCrossResourceGroupMoveEnabled -ResourceMovePolicyCrossSubscriptionMoveEnabled
        $resourceTypeRegistration | Should -Not -BeNullOrEmpty
        $resourceTypeRegistration.Name | Should -BeExactly "Employees"
        $resourceTypeRegistration.Regionality | Should -BeExactly "Regional"
        $resourceTypeRegistration.EnableAsyncOperation | Should -BeExactly $true

        $resourceTypeRegistration = Get-AzProviderHubResourceTypeRegistration -ProviderNamespace $env.ProviderNamespace -ResourceType "Employees"
        $resourceTypeRegistration | Should -Not -BeNullOrEmpty

        $resourceTypeRegistrationList = Get-AzProviderHubResourceTypeRegistration -ProviderNamespace $env.ProviderNamespace
        $resourceTypeRegistrationList.Count | Should -BeGreaterOrEqual 1

        $resourceTypeRegistration = Remove-AzProviderHubResourceTypeRegistration -ProviderNamespace $env.ProviderNamespace -ResourceType "Employees"
        $resourceTypeRegistration | Should -BeNullOrEmpty

        $resourceTypeRegistration = New-AzProviderHubResourceTypeRegistration -ProviderNamespace $env.ProviderNamespace -ResourceType "Employees" -RoutingType "Default" -Regionality "Regional" -Endpoint $endpoint -SwaggerSpecification $swaggerSpecification -EnableAsyncOperation -TemplateDeploymentOptionPreflightOption "DefaultValidationOnly" -TemplateDeploymentOptionPreflightSupported -ResourceMovePolicyCrossResourceGroupMoveEnabled -ResourceMovePolicyCrossSubscriptionMoveEnabled
        $resourceTypeRegistration | Should -Not -BeNullOrEmpty
    }
}
