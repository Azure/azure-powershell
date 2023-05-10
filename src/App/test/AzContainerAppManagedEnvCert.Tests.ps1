if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppManagedEnvCert'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppManagedEnvCert.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppManagedEnvCert' {

    # Contains confidential information, please run it locally

    It 'CreateExpanded' -skip {
        {
            $mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText

            $config = New-AzContainerAppManagedEnvCert -EnvName $env.envName -Name $env.envCertName2 -ResourceGroupName $env.resourceGroup -Location $env.location -InputFile ".\test\mypfx.pfx" -Password $mypwd
            $config.Name | Should -Be $env.envCertName2

            $config = New-AzContainerAppManagedEnvCert -EnvName $env.envName -Name $env.envCertName3 -ResourceGroupName $env.resourceGroup -Location $env.location -InputFile ".\test\mypfx.pfx" -Password $mypwd
            $config.Name | Should -Be $env.envCertName3
        } | Should -Not -Throw
    }

    It 'List' -skip {
        {
            $config = Get-AzContainerAppManagedEnvCert -EnvName $env.envName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' -skip {
        {
            $config = Get-AzContainerAppManagedEnvCert -EnvName $env.envName -ResourceGroupName $env.resourceGroup -Name $env.envCertName2
            $config.Name | Should -Be $env.envCertName2
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -skip {
        {
            $config = Update-AzContainerAppManagedEnvCert -EnvName $env.envName -ResourceGroupName $env.resourceGroup -Name $env.envCertName2 -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.envCertName2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        {
            $config = Get-AzContainerAppManagedEnvCert -EnvName $env.envName -ResourceGroupName $env.resourceGroup -Name $env.envCertName3
            $config = Update-AzContainerAppManagedEnvCert -InputObject $config -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.envCertName3
        } | Should -Not -Throw
    }

    It 'Delete' -skip {
        {
            Remove-AzContainerAppManagedEnvCert -EnvName $env.envName -ResourceGroupName $env.resourceGroup -Name $env.envCertName2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        {
            $config = Get-AzContainerAppManagedEnvCert -EnvName $env.envName -ResourceGroupName $env.resourceGroup -Name $env.envCertName3
            Remove-AzContainerAppManagedEnvCert -InputObject $config
        } | Should -Not -Throw
    }
}
