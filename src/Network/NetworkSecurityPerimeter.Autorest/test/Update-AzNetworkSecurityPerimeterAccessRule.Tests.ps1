if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkSecurityPerimeterAccessRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkSecurityPerimeterAccessRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkSecurityPerimeterAccessRule' {
    It 'UpdateExpanded' {
        { 

        Update-AzNetworkSecurityPerimeterAccessRule -Name $env.tmpAccessRule1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -ProfileName $env.tmpProfile1  -AddressPrefix @('10.10.0.0/17')
        
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
           # this test case is dependent on the above test case
           $GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name $env.tmpAccessRule1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -ProfileName $env.tmpProfile1

           $UpdateObj = Update-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj -AddressPrefix @('10.0.0.0/16')

           $UpdateObj.AddressPrefix | Should -Be @('10.0.0.0/16')
           
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpandedFQDN' {
        {
           # this test case is dependent on the above test case
           $GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name $env.tmpAccessRule2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -ProfileName $env.tmpProfile1

           $UpdateObj = Update-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj -FullyQualifiedDomainName @('microsoft.com', 'nsp.microsoft.com')

           $UpdateObj.FullyQualifiedDomainName | Should -Be @('microsoft.com', 'nsp.microsoft.com')
           
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpandedEmail' {
        {
           # this test case is dependent on the above test case
           $GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name $env.tmpAccessRule3 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -ProfileName $env.tmpProfile1

           $UpdateObj = Update-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj -EmailAddress @('update1@microsoft.com', 'update2@microsoft.com')

           $UpdateObj.EmailAddress | Should -Be @('update1@microsoft.com', 'update2@microsoft.com')
           
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpandedSMS' {
        {
           # this test case is dependent on the above test case
           $GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name $env.tmpAccessRule4 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -ProfileName $env.tmpProfile1

           $UpdateObj = Update-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj -PhoneNumber @('+919876543210', '+919876543211')

           $UpdateObj.PhoneNumber | Should -Be @('+91 9876543210', '+91 9876543211')
           
        } | Should -Not -Throw
    }

}
