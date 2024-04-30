if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEmailServiceDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEmailServiceDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEmailServiceDomain' {
    It 'Delete' {
        $name = "EmailServiceDomain-test" + $env.rstr1 + ".net"
        $res = New-AzEmailServiceDomain -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -DomainManagement $env.domainManagement

        Remove-AzEmailServiceDomain -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup

        $serviceList = Get-AzEmailServiceDomain -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }
    It 'DeleteViaIdentityEmailService' {
        $newResourceName = "EmailService-test" + $env.rstr2
        $name = "EmailServiceDomain-test" + $env.rstr2 + ".net"

        $res = New-AzEmailService -EmailServiceName $newResourceName -ResourceGroupName $env.resourceGroup -DataLocation $env.dataLocation
        $res1 = New-AzEmailServiceDomain -DomainName $name -EmailServiceName $newResourceName -ResourceGroupName $env.resourceGroup -DomainManagement $env.domainManagement
        
        Remove-AzEmailServiceDomain -EmailServiceInputObject $res -DomainName $name
        
        $serviceList = Get-AzEmailServiceDomain -EmailServiceName $newResourceName -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }
    It 'DeleteViaIdentity' {
         $name = "EmailServiceDomain-test" + $env.rstr2 + ".net"
        $res = New-AzEmailServiceDomain -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -DomainManagement $env.domainManagement

        Remove-AzEmailServiceDomain -InputObject $res

        $serviceList = Get-AzEmailServiceDomain -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }
}
