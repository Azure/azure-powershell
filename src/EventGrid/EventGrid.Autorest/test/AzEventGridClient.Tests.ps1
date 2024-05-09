if(($null -eq $TestName) -or ($TestName -contains 'AzEventGridClient'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzEventGridClient.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzEventGridClient' {
    It 'New-AzEventGridClient' {
        {
            $attribute = @{"room"="345";"floor"="3";"deviceTypes"="Fan"}
            $config = New-AzEventGridClient -Name $env.client -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Attribute $attribute -State Enabled -ClientCertificateAuthenticationValidationScheme "SubjectMatchesAuthenticationName"
            $config.Name | Should -Be $env.client
        } | Should -Not -Throw
    }

    It 'New-AzEventGridClientGroup' {
        {
            $config = New-AzEventGridClientGroup -Name $env.clientGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Query "attributes.b IN ['a', 'b', 'c']"
            $config.Name | Should -Be $env.clientGroup
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridClient' {
        {
            $config = Get-AzEventGridClient -Name $env.client -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.client
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridClientGroup' {
        {
            $config = Get-AzEventGridClientGroup -Name $env.clientGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.clientGroup
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridClient' {
        {
            $attribute = @{"room"="345";"floor"="3";"deviceTypes"="AC"}
            $config = Update-AzEventGridClient -Name $env.client -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Attribute $attribute -Description "This is a test client"
            $config.Name | Should -Be $env.client
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridClientGroup' {
        {
            $config = Update-AzEventGridClientGroup -Name $env.clientGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Description "This is a test client group" -Query "attributes.b IN ['a', 'b', 'c', 'd']"
            $config.Name | Should -Be $env.clientGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridClientGroup' {
        {
            Remove-AzEventGridClientGroup -Name $env.clientGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridClient' {
        {
            Remove-AzEventGridClient -Name $env.client -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
