if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubApplicationGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubApplicationGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHubApplicationGroup' {
    It 'SetExpanded' -Skip {
        $t3 = New-AzEventHubThrottlingPolicyConfig -Name t3 -MetricId OutgoingMessages -RateLimitThreshold 12000
        $appGroup = Get-AzEventHubApplicationGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.appGroup2
        $appGroup.Policy += $t3
        $updateAppGroup = Set-AzEventHubApplicationGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.appGroup2 -Policy $appGroup.Policy
        $updateAppGroup.Name | Should -Be $env.appGroup2
        $updateAppGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $updateAppGroup.Policy.Count | Should -Be 3
        $updateAppGroup.ClientAppGroupIdentifier | Should -Be $appGroup.ClientAppGroupIdentifier
    }

    It 'SetViaIdentityExpanded' -Skip {
        $t4 = New-AzEventHubThrottlingPolicyConfig -Name t4 -MetricId IncomingBytes -RateLimitThreshold 13000
        $appGroup = Get-AzEventHubApplicationGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.appGroup2
        $appGroup.Policy += $t4
        
        { Set-AzEventHubApplicationGroup -InputObject $appGroup -ErrorAction Stop } | Should -Throw 'Please specify the property you want to update on the -InputObject'
        
        $updateAppGroup = Set-AzEventHubApplicationGroup -InputObject $appGroup -Policy $appGroup.Policy
        $updateAppGroup.Name | Should -Be $env.appGroup2
        $updateAppGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $updateAppGroup.Policy.Count | Should -Be 4
        $updateAppGroup.ClientAppGroupIdentifier | Should -Be $appGroup.ClientAppGroupIdentifier

        $updateAppGroup = Set-AzEventHubApplicationGroup -InputObject $appGroup -IsEnabled:$false
        $updateAppGroup.Name | Should -Be $env.appGroup2
        $updateAppGroup.ResourceGroupName | Should -Be $env.resourceGroup
        $updateAppGroup.Policy.Count | Should -Be 4
        $updateAppGroup.ClientAppGroupIdentifier | Should -Be $appGroup.ClientAppGroupIdentifier
        $updateAppGroup.IsEnabled | Should -Be $false
    }
}
