if(($null -eq $TestName) -or ($TestName -contains 'New-AzEmailServiceDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEmailServiceDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEmailServiceDomain' {
    It 'CreateExpanded' {
       $NewAzEmailServiceDomain = New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName -DomainManagement $env.domainManagement
       $NewAzEmailServiceDomain.Name | Should -Be $env.domainResourceName
    }
    It 'CreateViaJsonString' -skip  {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'CreateViaIdentityEmailServiceExpanded' {
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $EmailServiceDomainInstance = New-AzEmailServiceDomain -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.domainResourceName -DomainManagement $env.domainManagement
        $EmailServiceDomainInstance.Name | Should -Be $env.domainResourceName
    }
    It 'CreateViaIdentityEmailService' {
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $EmailServiceDomainInstance = New-AzEmailServiceDomain -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.domainResourceName -DomainManagement $env.domainManagement
        $EmailServiceDomainInstance.Name | Should -Be $env.domainResourceName
    }
}
