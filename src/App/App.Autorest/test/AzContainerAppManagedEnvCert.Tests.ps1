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

    It 'CreateExpanded' -Skip {
        {
            $selfSignedCert = New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
            Get-ChildItem -Path cert:\LocalMachine\My
            $mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
            Get-ChildItem -Path cert:\localMachine\my\$($selfSignedCert.Thumbprint) | Export-PfxCertificate -FilePath ".\test\mypfx.pfx" -Password $mypwd

            New-AzContainerAppManagedEnvCert -managedEnv1 $env.managedEnv1 -Name $env.managedEnvCert2 -ResourceGroupName $env.resourceGroupManaged -Location $env.location -InputFile ".\test\mypfx.pfx" -Password $mypwd
            $config.Name | Should -Be $env.managedEnvCert2
        } | Should -Not -Throw
    }

    It 'List' -Skip {
        {
            $config = Get-AzContainerAppManagedEnvCert -managedEnv1 $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' -Skip {
        {
            $config = Get-AzContainerAppManagedEnvCert -managedEnv1 $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvCert2
            $config.Name | Should -Be $env.managedEnvCert2
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -Skip {
        {
            $config = Update-AzContainerAppManagedEnvCert -managedEnv1 $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvCert2 -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.managedEnvCert2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -Skip {
        {
            $config = Get-AzContainerAppManagedEnvCert -managedEnv1 $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvCert2
            $config = Update-AzContainerAppManagedEnvCert -InputObject $config -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.managedEnvCert2
        } | Should -Not -Throw
    }

    It 'Delete' -Skip {
        {
            Remove-AzContainerAppManagedEnvCert -managedEnv1 $env.managedEnv1 -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnvCert2
        } | Should -Not -Throw
    }
}
