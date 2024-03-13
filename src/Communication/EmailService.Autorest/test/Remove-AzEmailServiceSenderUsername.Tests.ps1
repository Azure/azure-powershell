if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEmailServiceSenderUsername'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEmailServiceSenderUsername.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEmailServiceSenderUsername' {
    It 'Delete' {
        $name = "EmailServiceSenderUsername-test" + $env.rstr1
        $res = New-AzEmailServiceSenderUsername -SenderUsername $name -Username $name -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup

        Remove-AzEmailServiceSenderUsername -SenderUsername $name -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup

        $serviceList = Get-AzEmailServiceSenderUsername -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }

    It 'DeleteViaIdentityEmailService' {
        $newResourceName = "EmailService-test" + $env.rstr2
        $newResourceDomainName = "EmailServiceDomain-test" + $env.rstr2 + ".net"
        $name = "EmailServiceSenderUsername-test" + $env.rstr2

        $res = New-AzEmailService -EmailServiceName $newResourceName -ResourceGroupName $env.resourceGroup -DataLocation $env.dataLocation
        $res1 = New-AzEmailServiceDomain -DomainName $newResourceDomainName -EmailServiceName $newResourceName -ResourceGroupName $env.resourceGroup -DomainManagement $env.domainManagement
        $res2 = New-AzEmailServiceSenderUsername -SenderUsername $name -Username $name -DomainName $newResourceDomainName -EmailServiceName $newResourceName -ResourceGroupName $env.resourceGroup
        
        Remove-AzEmailServiceSenderUsername -EmailServiceInputObject $res -DomainName $newResourceDomainName -SenderUsername $name
        
        $serviceList = Get-AzEmailServiceSenderUsername -DomainName $newResourceDomainName -EmailServiceName $newResourceName -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }

    It 'DeleteViaIdentityDomain' {
        $newResourceDomainName = "EmailServiceDomain-test" + $env.rstr2 + ".net"
        $name = "EmailServiceSenderUsername-test" + $env.rstr2

        $res = New-AzEmailServiceDomain -DomainName $newResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -DomainManagement $env.domainManagement
        $res1 = New-AzEmailServiceSenderUsername -SenderUsername $name -Username $name -DomainName $newResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        
        Remove-AzEmailServiceSenderUsername -DomainInputObject $res -SenderUsername $name
        
        $serviceList = Get-AzEmailServiceSenderUsername -DomainName $newResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }

    It 'DeleteViaIdentity' {
        $name = "EmailServiceSenderUsername-test" + $env.rstr2
        $res = New-AzEmailServiceSenderUsername -SenderUsername $name -Username $name -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup

        Remove-AzEmailServiceSenderUsername -InputObject $res

        $serviceList = Get-AzEmailServiceSenderUsername -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }
}
