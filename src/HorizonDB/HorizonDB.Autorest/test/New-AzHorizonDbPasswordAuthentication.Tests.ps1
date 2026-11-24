if(($null -eq $TestName) -or ($TestName -contains 'New-AzHorizonDbPasswordAuthentication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzHorizonDbPasswordAuthentication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzHorizonDbPasswordAuthentication' {
    It 'CreateExpanded' {
        $password = [System.Security.SecureString]::new()
        foreach ($character in ('Aa1!' + [guid]::NewGuid().ToString('N')).ToCharArray()) {
            $password.AppendChar($character)
        }
        $password.MakeReadOnly()
        try {
            $authentication = New-AzHorizonDbPasswordAuthentication -ResourceGroupName $env.clusterResourceGroup -ClusterName $env.newClusterName -SubscriptionId $env.SubscriptionId -State 'Enabled' -AdministratorLogin 'adminlogin1' -AdministratorLoginPassword $password -ErrorAction Stop

            $authentication.Name | Should -Be 'passwordMethod'
            $authentication.ResourceGroupName | Should -Be $env.clusterResourceGroup
            $authentication.Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.clusterResourceGroup)/providers/Microsoft.HorizonDb/clusters/$($env.newClusterName)/authentications/passwordMethod"
            $authentication.Type | Should -Be 'Microsoft.HorizonDb/clusters/authentications'
            $authentication.State | Should -Be 'Enabled'
            $authentication.AdministratorLogin | Should -Be 'adminlogin1'
        }
        finally {
            $password.Dispose()
            if ($TestMode -eq 'record' -and (Test-Path -LiteralPath $TestRecordingFile)) {
                Protect-HorizonDbPasswordRecording -Path $TestRecordingFile
            }
        }
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
