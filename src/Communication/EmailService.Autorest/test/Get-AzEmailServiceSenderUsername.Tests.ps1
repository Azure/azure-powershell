if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEmailServiceSenderUsername'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEmailServiceSenderUsername.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEmailServiceSenderUsername' {
    It 'List' {
        $services = Get-AzEmailServiceSenderUsername -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $services.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentityEmailService' {
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $EmailServiceDomainSenderUsernameInstance = Get-AzEmailServiceSenderUsername -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.persistentResourceDomainName -SenderUsername $env.persistentResourceDomainSenderUsername
        $EmailServiceDomainSenderUsernameInstance.Name | Should -Be $env.persistentResourceDomainSenderUsername
    }

    It 'Get' {
        $service = Get-AzEmailServiceSenderUsername -SenderUsername $env.persistentResourceDomainSenderUsername -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $service.Name | Should -Be $env.persistentResourceDomainSenderUsername
    }

    It 'GetViaIdentityDomain' {
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.persistentResourceDomainName
        $EmailServiceDomainSenderUsernameInstance = Get-AzEmailServiceSenderUsername -DomainInputObject $EmailServiceDomainInstance01 -SenderUsername $env.persistentResourceDomainSenderUsername
        $EmailServiceDomainSenderUsernameInstance.Name | Should -Be $env.persistentResourceDomainSenderUsername
    }

    It 'GetViaIdentity' {
        $EmailServiceDomainSenderUsernameInstance01 = Get-AzEmailServiceSenderUsername -SenderUsername $env.persistentResourceDomainSenderUsername -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $EmailServiceDomainSenderUsernameInstance = Get-AzEmailServiceSenderUsername -InputObject $EmailServiceDomainSenderUsernameInstance01
        $EmailServiceDomainSenderUsernameInstance.Name | Should -Be $env.persistentResourceDomainSenderUsername
    }
}
