if(($null -eq $TestName) -or ($TestName -contains 'New-AzEmailServiceSenderUsername'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEmailServiceSenderUsername.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEmailServiceSenderUsername' {
    It 'CreateExpanded' {
       $NewAzEmailServiceDomainSenderUsername = New-AzEmailServiceSenderUsername -SenderUsername $env.senderUsername -Username $env.senderUsername -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
       $NewAzEmailServiceDomainSenderUsername.Name | Should -Be $env.senderUsername
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip  {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityEmailServiceExpanded' {
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $EmailServiceDomainSenderUsernameInstance = New-AzEmailServiceSenderUsername -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.persistentResourceDomainName -SenderUsername $env.senderUsername -Username $env.senderUsername
        $EmailServiceDomainSenderUsernameInstance.Name | Should -Be $env.senderUsername
    }

    It 'CreateViaIdentityEmailService' {
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $EmailServiceDomainSenderUsernameInstance = New-AzEmailServiceSenderUsername -EmailServiceInputObject $EmailServiceInstance01 -DomainName $env.persistentResourceDomainName -SenderUsername $env.senderUsername -Username $env.senderUsername
        $EmailServiceDomainSenderUsernameInstance.Name | Should -Be $env.senderUsername
    }

    It 'CreateViaIdentityDomainExpanded' {
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.persistentResourceDomainName
        $EmailServiceDomainSenderUsernameInstance = New-AzEmailServiceSenderUsername -DomainInputObject $EmailServiceDomainInstance01 -SenderUsername $env.senderUsername -Username $env.senderUsername
        $EmailServiceDomainSenderUsernameInstance.Name | Should -Be $env.senderUsername
    }

    It 'CreateViaIdentityDomain' {
        $EmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.persistentResourceDomainName
        $EmailServiceDomainSenderUsernameInstance = New-AzEmailServiceSenderUsername -DomainInputObject $EmailServiceDomainInstance01 -SenderUsername $env.senderUsername -Username $env.senderUsername
        $EmailServiceDomainSenderUsernameInstance.Name | Should -Be $env.senderUsername
    }
}
