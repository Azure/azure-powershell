if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzEmailServiceInitiateDomainVerification'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzEmailServiceInitiateDomainVerification.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzEmailServiceInitiateDomainVerification' {
    It 'InitiateExpanded' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName1 -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $env.domainResourceName1 -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType $env.verificationType
    }

    It 'InitiateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InitiateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InitiateViaIdentityEmailServiceExpanded' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName2 -DomainManagement $env.domainManagement
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        Invoke-AzEmailServiceInitiateDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.domainResourceName2 -VerificationType Domain
    }

    It 'InitiateViaIdentityEmailService' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName3 -DomainManagement $env.domainManagement
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        Invoke-AzEmailServiceInitiateDomainVerification -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.domainResourceName3 -VerificationType Domain
    }

    It 'Initiate' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName4 -DomainManagement $env.domainManagement
        Invoke-AzEmailServiceInitiateDomainVerification -DomainName $env.domainResourceName4 -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -VerificationType Domain
    }

    It 'InitiateViaIdentityExpanded' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName5 -DomainManagement $env.domainManagement
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.domainResourceName5
        Invoke-AzEmailServiceInitiateDomainVerification -InputObject $EmailServiceDomainInstance01 -VerificationType Domain
    }

    It 'InitiateViaIdentity' -skip {
        New-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -Name $env.domainResourceName6 -DomainManagement $env.domainManagement
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.domainResourceName6
        Invoke-AzEmailServiceInitiateDomainVerification -InputObject $EmailServiceDomainInstance01 -VerificationType Domain
    }
}
