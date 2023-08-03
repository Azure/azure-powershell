if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkSecurityPerimeterAccessRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkSecurityPerimeterAccessRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkSecurityPerimeterAccessRule' {
    It 'CreateExpanded' {
        { 
        
        New-AzNetworkSecurityPerimeterAccessRule -Name $env.accessRule1 -ProfileName $env.tmpProfile2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -AddressPrefix '10.10.0.0/16' -Direction 'Inbound' -Location $env.location
        
        } | Should -Not -Throw
    }

    It 'CreateExpandedWithSubscriptions' {
        {
            $sub1 = @{
                id= '/subscriptions/' + $env.SubscriptionId
            }

            New-AzNetworkSecurityPerimeterAccessRule -Name $env.accessRule1 -ProfileName $env.tmpProfile2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -Subscription @($sub1) -Direction 'Inbound' -Location $env.location

        } | Should -Not -Throw
    }

    It 'CreateExpandedWithEmailAddresses' {
        {
            $emails = @("test123@microsoft.com", "test321@microsoft.com")

            New-AzNetworkSecurityPerimeterAccessRule -Name $env.accessRule2 -ProfileName $env.tmpProfile2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -EmailAddress $emails -Direction 'Outbound' -Location $env.location

        } | Should -Not -Throw
    }

    It 'CreateExpandedWithPhoneNumbers' {
        {
            $phones = @("+919898989898", "+919898989898")

            New-AzNetworkSecurityPerimeterAccessRule -Name $env.accessRule2 -ProfileName $env.tmpProfile2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -PhoneNumber $phones -Direction 'Outbound' -Location $env.location

        } | Should -Not -Throw
    }
}
