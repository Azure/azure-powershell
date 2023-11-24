if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppManagedCert'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppManagedCert.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppManagedCert' {

    # Create a Managed Certificate.
    # Users need to create new resources about "App Service Domain" and "DNS zone" in the same resource group.
    # Follow the steps in the help file to configure the resource "DNS zone" that you just created: https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates?pivots=azure-portal

    It 'CreateExpanded' -Skip {
        {
            $config = New-AzContainerAppManagedCert -EnvName $env.managedEnv1 -Name $env.managedCert1 -ResourceGroupName $env.resourceGroupManaged -Location $env.location -DomainControlValidation TXT -SubjectName "mycertweb.com"
            $config.Name | Should -Be $env.managedCert1
        } | Should -Not -Throw
    }

    It 'List' -Skip {
        {
            $config = Get-AzContainerAppManagedCert -EnvName $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' -Skip {
        {
            $config = Get-AzContainerAppManagedCert -EnvName $env.managedEnv1 -Name $env.managedCert1 -ResourceGroupName $env.resourceGroupManaged
            $config.Name | Should -Be $env.managedCert1
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -Skip {
        {
            $config = Update-AzContainerAppManagedCert -EnvName $env.managedEnv1 -Name $env.managedCert1 -ResourceGroupName $env.resourceGroupManaged -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.managedCert1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppManagedCert -EnvName $env.managedEnv1 -Name $env.managedCert1 -ResourceGroupName $env.resourceGroupManaged
        } | Should -Not -Throw
    }
}
