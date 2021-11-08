if(($null -eq $TestName) -or ($TestName -contains 'Get-AzVMRunCommand'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzVMRunCommand.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName

}


Describe 'Get-AzVMRunCommand' {
    
    BeforeAll { 
        $vmname = "testpwshellvm"
        $rgname = "testpwshellcompute"
        $user = "Foo12";
        $password = RandomString -allChars $True -len 120 
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        Write-Host $env.rgname
        New-AzVM -ResourceGroupName $rgname -Location "eastus" -Name $vmname -Credential $cred
        Set-AzVMRunCommand -ResourceGroupName $rgname -VMName $vmname -RunCommandName 'firstruncommand1' -Location "eastus"
        
    }

    It 'List' {
        $returnlist = Get-AzVMRunCommand -ResourceGroupName $rgname -VMName $vmname
    }

    It 'Get' {
        $returnlist = Get-AzVMRunCommand -ResourceGroupName $rgname -VMName $vmname -RunCommandName "firstruncommand1"
    }

    It 'List1'{
        Get-AzVMRunCommand -Location eastus
    }

    It 'Get1' {
        Get-AzVMRunCommand -CommandId RunPowerShellScript -Location eastus
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
