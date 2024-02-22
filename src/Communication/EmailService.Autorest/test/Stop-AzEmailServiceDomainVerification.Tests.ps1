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
    It 'CancelExpanded'  {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName7 -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $env.domainResourceName7 -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
        Stop-AzEmailServiceDomainVerification -DomainName $env.domainResourceName7  -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
    }

    It 'CancelViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CancelViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CancelViaIdentityEmailServiceExpanded' {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName8 -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.domainResourceNam8 -VerificationType Domain
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        Stop-AzEmailServiceDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.domainResourceName8 -VerificationType $env.verificationType
    }

    It 'CancelViaIdentityEmailService' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName9 -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.domainResourceName8 -VerificationType Domain
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        Stop-AzEmailServiceDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.domainResourceName9 -VerificationType $env.verificationType
    }

    It 'Cancel' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName10 -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $env.domainResourceName10 -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
        Stop-AzEmailServiceDomainVerification -DomainName $env.domainResourceName10 -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
    }

    It 'CancelViaIdentityExpanded' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName11 -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.domainResourceName11 -VerificationType Domain
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.domainResourceName11
        Stop-AzEmailServiceDomainVerification -InputObject $EmailServiceDomainInstance01 -VerificationType $env.verificationType        
    }

    It 'CancelViaIdentity' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName12 -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.domainResourceName12 -VerificationType Domain
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.domainResourceName12
        Stop-AzEmailServiceDomainVerification -InputObject $EmailServiceDomainInstance01 -VerificationType $env.verificationType   
    }
}
