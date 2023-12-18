if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppConnectedEnvCert'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppConnectedEnvCert.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppConnectedEnvCert' {

    # Contains confidential information, please run it locally

    It 'CreateExpanded' -Skip {
        {
            $selfSignedCert = New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
            Get-ChildItem -Path cert:\LocalMachine\My
            $mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
            Get-ChildItem -Path cert:\localMachine\my\$($selfSignedCert.Thumbprint) | Export-PfxCertificate -FilePath ".\test\mypfx.pfx" -Password $mypwd

            $config = New-AzContainerAppConnectedEnvCert -Name $env.connectedEnvCert2 -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Location $env.location -InputFile ".\test\mypfx.pfx" -Password $mypwd
            $config.Name | Should -Be $env.connectedEnvCert2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppConnectedEnvCert -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerAppConnectedEnvCert -Name $env.connectedEnvCert2 -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected
            $config.Name | Should -Be $env.connectedEnvCert2
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzContainerAppConnectedEnvCert -Name $env.connectedEnvCert2 -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.connectedEnvCert2
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' {
        {
            $config = Get-AzContainerAppConnectedEnvCert -Name $env.connectedEnvCert2 -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected
            $config = Update-AzContainerAppConnectedEnvCert -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.connectedEnvCert2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppConnectedEnvCert -Name $env.connectedEnvCert2 -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected
        } | Should -Not -Throw
    }
}
