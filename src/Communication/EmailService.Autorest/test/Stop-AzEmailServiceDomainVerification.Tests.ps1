if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzEmailServiceDomainVerification'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzEmailServiceDomainVerification.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzEmailServiceDomainVerification' {
    It 'CancelExpanded' {
        $name = "EmailServiceDomain-test1" + $env.rstr1 + ".net"
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $name -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
        Stop-AzEmailServiceDomainVerification -DomainName $name  -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
    }

    It 'CancelViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CancelViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CancelViaIdentityEmailServiceExpanded' {
        $name = "EmailServiceDomain-test2" + $env.rstr1 + ".net"
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $name -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        Stop-AzEmailServiceDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -DomainName $name -VerificationType $env.verificationType
    }

    It 'CancelViaIdentityEmailService' {
        $name = "EmailServiceDomain-test3" + $env.rstr1 + ".net"
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $name -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        Stop-AzEmailServiceDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -DomainName $name -VerificationType $env.verificationType
    }

    It 'Cancel' {
        $name = "EmailServiceDomain-test4" + $env.rstr1 + ".net"
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $name -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
        Stop-AzEmailServiceDomainVerification -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
    }

    It 'CancelViaIdentityExpanded' {
        $name = "EmailServiceDomain-test5" + $env.rstr1 + ".net"
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $name -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $name
        Stop-AzEmailServiceDomainVerification -InputObject $EmailServiceDomainInstance01 -VerificationType $env.verificationType        
    }

    It 'CancelViaIdentity' {
        $name = "EmailServiceDomain-test6" + $env.rstr1 + ".net"
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $name -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $name -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $name
        Stop-AzEmailServiceDomainVerification -InputObject $EmailServiceDomainInstance01 -VerificationType $env.verificationType   
    }
}
