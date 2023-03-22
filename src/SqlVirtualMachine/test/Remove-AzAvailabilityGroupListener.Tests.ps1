if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzAvailabilityGroupListener')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAvailabilityGroupListener.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAvailabilityGroupListener' {
    It 'Delete' {
        Remove-AzAvailabilityGroupListener -ResourceGroupName $env.ResourceGroupName -SqlVMGroupName $env.SqlVMGroupName -Name $env.SqlVMGroupLoadBalancerListnerName
        { Get-AzAvailabilityGroupListener -ResourceGroupName $env.ResourceGroupName -SqlVMGroupName $env.SqlVMGroupName -Name $env.SqlVMGroupLoadBalancerListnerName } | Should -Throw -ExpectedMessage "The requested resource of type 'Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups/availabilityGroupListeners' with name 'aglblistener' was not found."
    }

    It 'DeleteViaIdentity' {
        $SubscriptionId = $PSDefaultParameterValues["*:SubscriptionId"]
        $PSDefaultParameterValues.Remove("*:SubscriptionId")

        $msListner = [Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.AvailabilityGroupListener]@{Id = $env.SqlVMGroupMultiSubnetIPListnerId }
        $msListner | Remove-AzAvailabilityGroupListener
        { $msListner | Get-AzAvailabilityGroupListener } | Should -Throw -ExpectedMessage "The requested resource of type 'Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups/availabilityGroupListeners' with name 'agmslistener' was not found."

        $PSDefaultParameterValues["*:SubscriptionId"] = $SubscriptionId
    }
}
