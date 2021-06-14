$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzProviderHubProviderRegistration-CRUD.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzProviderHubProviderRegistration-CRUD' {
    It 'Create and get a ProviderRegistration' {
        $providerHubMetadataProviderAuthorization = @{ApplicationId = "3d834152-5efa-46f7-85a4-a18c2b5d46f9";RoleDefinitionId = "760505bf-dcfa-4311-b890-18da392a00b2"}
        $managementServiceTreeInfo = @{ComponentId = "d1b7d8ba-05e2-48e6-90d6-d781b99c6e69"; ServiceId = "d1b7d8ba-05e2-48e6-90d6-d781b99c6e69"}
        $capabilities1 = @{QuotaId = "CSP_2015-05-01"; Effect = "Allow"}
        $capabilities2 = @{QuotaId = "CSP_MG_2017-12-01"; Effect = "Allow"}

        $providerRegistration = New-AzProviderHubProviderRegistration -ProviderNamespace $env.ProviderNamespace -ProviderHubMetadataProviderAuthenticationAllowedAudience "https://management.core.windows.net/" -ProviderHubMetadataProviderAuthorization $providerHubMetadataProviderAuthorization -Namespace $env.ProviderNamespace -ProviderVersion "2.0" -ProviderType "Internal" -ManagementManifestOwner "SPARTA-PlatformServiceAdministrator" -ManagementIncidentContactEmail "rpaascore@microsoft.com" -ManagementIncidentRoutingService "Resource Provider Service as a Service" -ManagementIncidentRoutingTeam "RPaaS" -ManagementServiceTreeInfo $managementServiceTreeInfo -Capability $capabilities1, $capabilities2
        $providerRegistration | Should -Not -BeNullOrEmpty

        $providerRegistration = Get-AzProviderHubProviderRegistration -ProviderNamespace $env.ProviderNamespace
        $providerRegistration | Should -Not -BeNullOrEmpty

        $providerRegistration = Remove-AzProviderHubProviderRegistration -ProviderNamespace $env.ProviderNamespace
        $providerRegistration | Should -BeNullOrEmpty

        $providerRegistration = New-AzProviderHubProviderRegistration -ProviderNamespace $env.ProviderNamespace -ProviderHubMetadataProviderAuthenticationAllowedAudience "https://management.core.windows.net/" -ProviderHubMetadataProviderAuthorization $providerHubMetadataProviderAuthorization -Namespace $env.ProviderNamespace -ProviderVersion "2.0" -ProviderType "Internal" -ManagementManifestOwner "SPARTA-PlatformServiceAdministrator" -ManagementIncidentContactEmail "rpaascore@microsoft.com" -ManagementIncidentRoutingService "Resource Provider Service as a Service" -ManagementIncidentRoutingTeam "RPaaS" -ManagementServiceTreeInfo $managementServiceTreeInfo -Capability $capabilities1, $capabilities2
        $providerRegistration | Should -Not -BeNullOrEmpty
    }
}
