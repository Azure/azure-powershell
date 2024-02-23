if(($null -eq $TestName) -or ($TestName -contains 'Update-AzEmailServiceSenderUsername'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzEmailServiceSenderUsername.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzEmailServiceSenderUsername' {
    It 'UpdateExpanded' {
        $UpdatedAzEmailServiceSenderUsername = Update-AzEmailServiceSenderUsername -SenderUsername $env.persistentResourceDomainSenderUsername -Username $env.persistentResourceDomainSenderUsername -DisplayName $env.displayName -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup

        $UpdatedAzEmailServiceSenderUsername.DisplayName | Should -Be $env.displayName
    }

    It 'UpdateViaIdentityEmailServiceExpanded' {
        $UpdatedAzEmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $UpdatedAzEmailServiceSenderUsername = Update-AzEmailServiceSenderUsername -EmailServiceInputObject $UpdatedAzEmailServiceInstance01 -DomainName $env.persistentResourceDomainName -SenderUsername $env.persistentResourceDomainSenderUsername -Username $env.persistentResourceDomainSenderUsername -DisplayName $env.displayName

        $UpdatedAzEmailServiceSenderUsername.DisplayName | Should -Be $env.displayName
    }

    It 'UpdateViaIdentityEmailService' {
       $UpdatedAzEmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $UpdatedAzEmailServiceSenderUsername = Update-AzEmailServiceSenderUsername -EmailServiceInputObject $UpdatedAzEmailServiceInstance01 -DomainName $env.persistentResourceDomainName -SenderUsername $env.persistentResourceDomainSenderUsername -Username $env.persistentResourceDomainSenderUsername -DisplayName $env.displayName

        $UpdatedAzEmailServiceSenderUsername.DisplayName | Should -Be $env.displayName
    }

    It 'UpdateViaIdentityDomainExpanded' {
        $UpdatedAzEmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.persistentResourceDomainName
        $UpdatedAzEmailServiceSenderUsername = Update-AzEmailServiceSenderUsername -DomainInputObject $UpdatedAzEmailServiceDomainInstance01 -SenderUsername $env.persistentResourceDomainSenderUsername -Username $env.persistentResourceDomainSenderUsername -DisplayName $env.displayName

        $UpdatedAzEmailServiceSenderUsername.DisplayName | Should -Be $env.displayName
    }

    It 'UpdateViaIdentityDomain' {
        $UpdatedAzEmailServiceDomainInstance01 = Get-AzEmailServiceDomain -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName -DomainName $env.persistentResourceDomainName
        $UpdatedAzEmailServiceSenderUsername = Update-AzEmailServiceSenderUsername -DomainInputObject $UpdatedAzEmailServiceDomainInstance01 -SenderUsername $env.persistentResourceDomainSenderUsername -Username $env.persistentResourceDomainSenderUsername -DisplayName $env.displayName

        $UpdatedAzEmailServiceSenderUsername.DisplayName | Should -Be $env.displayName
    }

    It 'UpdateViaIdentityExpanded' {
        $res = Get-AzEmailServiceSenderUsername -SenderUsername $env.persistentResourceDomainSenderUsername -DomainName $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $UpdatedAzEmailServiceSenderUsername = Update-AzEmailServiceSenderUsername -InputObject $res -DisplayName $env.displayName

        $UpdatedAzEmailServiceSenderUsername.DisplayName | Should -Be $env.displayName
    }
}
