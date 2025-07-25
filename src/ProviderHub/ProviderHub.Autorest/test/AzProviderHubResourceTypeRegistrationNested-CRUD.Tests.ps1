$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzProviderHubResourceTypeRegistration.Nested.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzProviderHubResourceTypeRegistration-NestedResourceType-CRUD' {
    It 'Create, get, and delete a nested resource type registration' {
        $swaggerSpec = @{ ApiVersion = "2019-01-01"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/tree/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" }
        $endpoint = @{ ApiVersion = "2019-01-01"; Location = ""; RequiredFeatures = "Microsoft.Contoso/RPaaSSampleApp"; Extension = @($extensions) }
        $extensions =  @{EndpointUri = "https://provider.chinaeast2.cloudapp.chinacloudapi.cn/"; ExtensionCategory = "ResourceReadValidate"}

        $resourceTypeRegistration = New-AzProviderHubResourceTypeRegistration `
        -ProviderNamespace $env.ProviderNamespace `
        -ResourceType $env.NestedResourceType `
        -RoutingType "ProxyOnly" -Regionality "Global" `
        -Endpoint $endpoint -SwaggerSpecification $swaggerSpec
        $resourceTypeRegistration | Should -Not -BeNullOrEmpty

        $resourceTypeRegistration = Get-AzProviderHubResourceTypeRegistration `
        -ProviderNamespace $env.ProviderNamespace `
        -ResourceType $env.NestedResourceType
        $resourceTypeRegistration | Should -Not -BeNullOrEmpty
        $resourceTypeRegistration.Name | Should -BeExactly $env.NestedResourceType
        $resourceTypeRegistration.Regionality | Should -BeExactly "Global"

        { Remove-AzProviderHubResourceTypeRegistration `
        -ProviderNamespace $env.ProviderNamespace `
        -ResourceType $env.NestedResourceType } | Should -Throw
    }
}
