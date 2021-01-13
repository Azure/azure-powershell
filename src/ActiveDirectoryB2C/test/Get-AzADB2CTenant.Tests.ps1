$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzADB2CTenant.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzADB2CTenant' {
    It 'List1'  {
        $tenantList = Get-AzADB2CTenant
        $tenantList.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
      $tenant = Get-AzADB2CTenant -ResourceGroupName $env.resourceGroup -Name $env.tenantName00
      $tenant.Name | Should -Be $env.tenantName00
    }

    It 'List' {
        $tenantList = Get-AzADB2CTenant -ResourceGroupName $env.resourceGroup
        $tenantList.Count | Should -Be 2
    }

    It 'GetViaIdentity' {
      $tenant = Get-AzADB2CTenant -ResourceGroupName $env.resourceGroup -Name $env.tenantName00 
      $tenant =  Get-AzADB2CTenant -InputObject $tenant
      $tenant.Name | Should -Be $env.tenantName00
    }
}
