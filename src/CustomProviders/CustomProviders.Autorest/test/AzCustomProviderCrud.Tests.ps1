$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Az.CustomProviderCrud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Az CustomProvider Crud' {
	It 'Lists all custom providers in a subscription' {
		$provider = Get-AzCustomProvider
		$provider.Count | Should -BeGreaterOrEqual 1
	}
    It 'Can Create, Update, and Remove a custom provider'{
		$resourceType = @(@{Name="CustomRoute1"; Endpoint="https://www.microsoft.com/"}, @{Name="associations"; Endpoint="https://learn.microsoft.com"; RoutingType="Proxy,Cache,Extension"})
        $provider = New-AzCustomProvider -ResourceGroupName $env.ResourceGroup -Name $env.CustomProvider -Location "West US 2" -ResourceType $resourceType
		$provider | Should -Not -BeNullOrEmpty
		$provider.ResourceType | Should -Not -BeNullOrEmpty
		$provider.ResourceType.Count | Should -Be 2
		Update-AzCustomProvider -InputObject $provider -Tag @{MyTag1="MyValue1"; MyTag2="MyValue2"} | Out-Null
		$provider2 = Get-AzCustomProvider -ResourceGroupName $env.ResourceGroup -Name $env.CustomProvider
		$provider2 | Should -Not -BeNullOrEmpty
		$provider2.Tag | Should -Not -BeNullOrEmpty
		$provider2.Tag.Count | Should -Be 2
		Remove-AzCustomProvider -InputObject $provider2 | Out-Null
		{$provider2 = Get-AzCustomProvider -ResourceGroupName $env.ResourceGroup -Name $env.CustomProvider } | Should -Throw | Out-Null
    }
}
