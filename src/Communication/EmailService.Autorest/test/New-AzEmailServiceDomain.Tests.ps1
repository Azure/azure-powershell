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
    It 'CreateExpanded' -skip {
       $NewAzEmailServiceDomain = New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName -Location $env.location -DomainManagement $env.domainManagement
       $NewAzEmailServiceDomain.Name | Should -Be $env.domainResourceName
    }
    It 'CreateViaJsonString' -skip  {
        $NewAzEmailServiceDomain = New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName -Location $env.location -DomainManagement $env.domainManagement
        $NewAzEmailServiceDomain.Name | Should -Be $env.domainResourceName
    }

    It 'CreateViaJsonFilePath' -skip {
       
    }
    It 'CreateViaIdentityEmailServiceExpanded' -skip {
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $EmailServiceDomainInstance = New-AzEmailServiceDomain -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.domainResourceName -Location $env.location -DomainManagement $env.domainManagement
        $EmailServiceDomainInstance.Name | Should -Be $env.domainResourceName
    }
    It 'CreateViaIdentityEmailService' -skip {
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $EmailServiceDomainInstance = New-AzEmailServiceDomain -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.domainResourceName -Location $env.location -DomainManagement $env.domainManagement
        $EmailServiceDomainInstance.Name | Should -Be $env.domainResourceName
    }
}
