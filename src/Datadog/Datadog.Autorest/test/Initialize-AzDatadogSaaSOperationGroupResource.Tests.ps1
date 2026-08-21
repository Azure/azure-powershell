if(($null -eq $TestName) -or ($TestName -contains 'Initialize-AzDatadogSaaSOperationGroupResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Initialize-AzDatadogSaaSOperationGroupResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Initialize-AzDatadogSaaSOperationGroupResource' {
    It 'ActivateExpanded' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        { Initialize-AzDatadogSaaSOperationGroupResource -SubscriptionId $env.SubscriptionId -SaaSResourceId $saaSResourceId -UserInfoName 'azureuser' -UserInfoEmailAddress 'user@example.com' -DatadogOrganizationPropertyName 'testorg' -DatadogOrganizationPropertyId 'org123' -WhatIf } | Should -Not -Throw
    }

    It 'Activate' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        { Initialize-AzDatadogSaaSOperationGroupResource -SubscriptionId $env.SubscriptionId -Body @{ saaSResourceId = $saaSResourceId; userInfo = @{ name = 'azureuser'; emailAddress = 'user@example.com'; phoneNumber = '11111111111' }; datadogOrganizationProperties = @{ name = 'testorg'; id = 'org123' } } -WhatIf } | Should -Not -Throw
    }

    It 'ActivateViaJsonFilePath' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        $tempFile = New-TemporaryFile
        @{ saaSResourceId = $saaSResourceId; userInfo = @{ name = 'azureuser'; emailAddress = 'user@example.com'; phoneNumber = '11111111111' }; datadogOrganizationProperties = @{ name = 'testorg'; id = 'org123' } } | ConvertTo-Json -Depth 4 | Set-Content -Path $tempFile.FullName
        { Initialize-AzDatadogSaaSOperationGroupResource -JsonFilePath $tempFile.FullName -WhatIf } | Should -Not -Throw
        Remove-Item -Path $tempFile.FullName -Force
    }

    It 'ActivateViaJsonString' {
        $saaSResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.SaaS/resources/$($env.monitorName01)SaaS"
        $jsonString = @{ saaSResourceId = $saaSResourceId; userInfo = @{ name = 'azureuser'; emailAddress = 'user@example.com'; phoneNumber = '11111111111' }; datadogOrganizationProperties = @{ name = 'testorg'; id = 'org123' } } | ConvertTo-Json -Depth 4
        { Initialize-AzDatadogSaaSOperationGroupResource -JsonString $jsonString -WhatIf } | Should -Not -Throw
    }
}
