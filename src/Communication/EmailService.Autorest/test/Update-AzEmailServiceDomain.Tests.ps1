if(($null -eq $TestName) -or ($TestName -contains 'Update-AzEmailServiceDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzEmailServiceDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzEmailServiceDomain' {
    It 'UpdateExpanded' {
        $tag = @{$env.exampleKey1=$env.exampleValue1; $env.exampleKey2=$env.exampleValue2}
        $UpdatedAzEmailServiceDomain = Update-AzEmailServiceDomain -Name $env.persistentResourceDomainName -EmailServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -Tag $tag

        $UpdatedAzEmailServiceDomain.Tag[$env.exampleKey1] | Should -Be $env.exampleValue1
        $UpdatedAzEmailServiceDomain.Tag[$env.exampleKey2] | Should -Be $env.exampleValue2
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityEmailServiceExpanded' {
        $tag = @{$env.exampleKey1=$env.exampleValue1; $env.exampleKey2=$env.exampleValue2}
        $UpdatedAzEmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $UpdatedAzEmailServiceDomain = Update-AzEmailServiceDomain -EmailServiceInputObject $UpdatedAzEmailServiceInstance01 -DomainName $env.persistentResourceDomainName -Tag $tag

        $UpdatedAzEmailServiceDomain.Tag[$env.exampleKey1] | Should -Be $env.exampleValue1
        $UpdatedAzEmailServiceDomain.Tag[$env.exampleKey2] | Should -Be $env.exampleValue2
    }

    It 'UpdateViaIdentityEmailService' {
        $tag = @{$env.exampleKey1=$env.exampleValue1; $env.exampleKey2=$env.exampleValue2}
        $UpdatedAzEmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $UpdatedAzEmailServiceDomain = Update-AzEmailServiceDomain -EmailServiceInputObject $UpdatedAzEmailServiceInstance01 -DomainName $env.persistentResourceDomainName -Tag $tag

        $UpdatedAzEmailServiceDomain.Tag[$env.exampleKey1] | Should -Be $env.exampleValue1
        $UpdatedAzEmailServiceDomain.Tag[$env.exampleKey2] | Should -Be $env.exampleValue2
    }

    It 'UpdateViaIdentityExpanded' {
       $tag = @{$env.exampleKey1=$env.exampleValue1; $env.exampleKey2=$env.exampleValue2}
        $UpdatedAzEmailServiceInstance01 = Get-AzEmailServiceDomain -DomainName $env.persistentResourceDomainName -ResourceGroupName $env.resourceGroup -EmailServiceName $env.persistentResourceName
        $UpdatedAzEmailServiceDomain = Update-AzEmailServiceDomain -InputObject $UpdatedAzEmailServiceInstance01 -Tag $tag

        $UpdatedAzEmailServiceDomain.Tag[$env.exampleKey1] | Should -Be $env.exampleValue1
        $UpdatedAzEmailServiceDomain.Tag[$env.exampleKey2] | Should -Be $env.exampleValue2
    }
}
