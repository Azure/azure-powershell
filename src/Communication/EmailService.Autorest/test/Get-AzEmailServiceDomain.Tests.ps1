if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEmailServiceDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEmailServiceDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEmailServiceDomain' {
    It 'List' {
        $services = Get-AzEmailServiceDomain -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $services.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $service = Get-AzEmailServiceDomain -Name $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $service.Name | Should -Be $env.persistentResourceDomainName
    }

    It 'GetViaIdentityEmailService' {
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $EmailServiceDomainInstance = Get-AzEmailServiceDomain -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.persistentResourceDomainName
        $EmailServiceDomainInstance.Name | Should -Be $env.persistentResourceDomainName
    }

    It 'GetViaIdentity' {
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.persistentResourceDomainName
        $EmailServiceDomainInstance = Get-AzEmailServiceDomain -InputObject $EmailServiceDomainInstance01
        $EmailServiceDomainInstance.Name | Should -Be $env.persistentResourceDomainName
    }
}
