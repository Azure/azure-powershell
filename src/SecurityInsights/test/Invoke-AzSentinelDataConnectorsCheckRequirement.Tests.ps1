if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSentinelDataConnectorsCheckRequirement'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSentinelDataConnectorsCheckRequirement.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSentinelDataConnectorsCheckRequirement' {
    It 'Custom_AzureSecurityCenter'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind AzureSecurityCenter -ASCSubscriptionId $env.SubscriptionId
        $result | Should -Not -Be $null
    }

    It 'Custom_AzureActiveDirectory'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind AzureActiveDirectory -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_AzureAdvancedThreatProtection'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind AzureAdvancedThreatProtection -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_Dynamics365'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind Dynamics365 -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_MicrosoftCloudAppSecurity'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind MicrosoftCloudAppSecurity -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_MicrosoftDefenderAdvancedThreatProtection'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind MicrosoftDefenderAdvancedThreatProtection -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_MicrosoftThreatIntelligence'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind MicrosoftThreatIntelligence -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_MicrosoftThreatProtection'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind MicrosoftThreatProtection -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_OfficeATP'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind OfficeATP -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_OfficeIRM'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind OfficeIRM -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_ThreatIntelligence'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind ThreatIntelligence -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }

    It 'Custom_ThreatIntelligenceTaxii'  {
        $result = Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName -Kind ThreatIntelligenceTaxii -TenantId $env.Tenant
        $result | Should -Not -Be $null
    }
}
