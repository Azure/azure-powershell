# if(($null -eq $TestName) -or ($TestName -contains 'Set-AzVmssVMRunCommand'))
# {
#   $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
#   if (-Not (Test-Path -Path $loadEnvPath)) {
#       $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
#   }
#   . ($loadEnvPath)
#   $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzVmssVMRunCommand.Recording.json'
#   $currentPath = $PSScriptRoot
#   while(-not $mockingPath) {
#       $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
#       $currentPath = Split-Path -Path $currentPath -Parent
#   }
#   . ($mockingPath | Select-Object -First 1).FullName
# }

# Describe 'Set-AzVmssVMRunCommand' {

#     BeforeAll { 
#         $vmname = "testpwshellvm"
#         $vmssname = "testpwshellvmss"
#         $rgname = "testpwshellcompute"
#         $user = "Foo12";
#         $password = RandomString -allChars $True -len 13 
#         $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
#         $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
#         New-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssname -ImageName 'Win2016Datacenter' -Credential $cred -InstanceCount 1
#         $vms = Get-Azvmssvm -ResourceGroupName $rgname -VMScaleSetName $vmssname
#         $instance = $vms.InstanceID[0]
#     }

#     It 'UpdateExpanded'  {
#         Set-AzVmssVMRunCommand -InstanceId $instance -ResourceGroupName $rgname -RunCommandName "first" -VMScaleSetName $vmssname -Location "eastus"
#     }
# }
