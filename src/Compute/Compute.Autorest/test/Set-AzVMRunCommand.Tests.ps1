# if(($null -eq $TestName) -or ($TestName -contains 'Set-AzVMRunCommand'))
# {
#   $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
#   if (-Not (Test-Path -Path $loadEnvPath)) {
#       $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
#   }
#   . ($loadEnvPath)
#   $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzVMRunCommand.Recording.json'
#   $currentPath = $PSScriptRoot
#   while(-not $mockingPath) {
#       $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
#       $currentPath = Split-Path -Path $currentPath -Parent
#   }
#   . ($mockingPath | Select-Object -First 1).FullName
# }

# Describe 'Set-AzVMRunCommand' {

#     BeforeAll { 
#         $vmname = "testpwshellvm"
#         $rgname = "testpwshellcompute"
#         $user = "Foo12";
#         $password = RandomString -allChars $True -len 13 
#         $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
#         $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
#         Write-Host $env.rgname
#         New-AzVM -ResourceGroupName $rgname -Location "eastus" -Name $vmname -Credential $cred
#     }
    
#     It 'UpdateExpanded' {
#         Set-AzVMRunCommand -ResourceGroupName $rgname -VMName $vmname -RunCommandName 'firstruncommand1' -Location "eastus"
#     }
# }
