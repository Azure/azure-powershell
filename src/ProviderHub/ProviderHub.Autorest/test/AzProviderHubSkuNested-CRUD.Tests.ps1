$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzProviderHubSkuNested-CRUD.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzProviderHubSkuNested-CRUD' {
    It 'Create, get, and delete a nested sku resource type' {
        # New-AzProviderHubSku -ProviderNamespace $env.ProviderNamespace -ResourceType $env.NestedResourceType -Sku "default" -SkuSetting @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"; Capacity = @{Minimum = 1; Maximum = 1; Default = 1; ScaleType = None }}

        $skuSetting1 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}
        $skuSetting2 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku2"; Tier = "Tier1"; Kind = "Standard"}

        $resourceTypeSku = New-AzProviderHubSku -ProviderNamespace $env.ProviderNamespace -ResourceType $env.NestedResourceType -Sku "default" -SkuSetting $skuSetting1, $skuSetting2
        $resourceTypeSku | Should -Not -BeNullOrEmpty

        $resourceTypeSku = Get-AzProviderHubSku -ProviderNamespace $env.ProviderNamespace -ResourceType $env.NestedResourceType
        $resourceTypeSku | Should -Not -BeNullOrEmpty

        $resourceTypeSku = Get-AzProviderHubSku -ProviderNamespace $env.ProviderNamespace -ResourceType $env.NestedResourceType -Sku "default"
        $resourceTypeSku | Should -Not -BeNullOrEmpty

        $resourceTypeSku = Remove-AzProviderHubSku -ProviderNamespace $env.ProviderNamespace -ResourceType $env.NestedResourceType -Sku "default"
        $resourceTypeSku | Should -BeNullOrEmpty
    }
}
