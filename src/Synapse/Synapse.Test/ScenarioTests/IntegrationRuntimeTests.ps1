<#
.SYNOPSIS
Creates a self-hosted integration runtime and then does operations.
Deletes the created integration runtime at the end.
#>
function Test-SelfHosted-IntegrationRuntime
{
    param
    (
        $resourceGroupName = (Get-ResourceGroupName),
        $workspaceName = (Get-SynapseWorkspaceName),
        $irname = "selfhosted-test-integrationruntime"
    )

    try
    {
        $resourceGroupName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("resourceGroupName", $resourceGroupName)
        $workspaceName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("workspaceName", $workspaceName)

        $actual = Set-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force
        Assert-AreEqual $actual.Name $irname

        $expected = Get-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name

        $expected = Get-AzSynapseIntegrationRuntime -ResourceId $actual.Id
        Assert-AreEqual $actual.Name $expected.Name

        $status = Get-AzSynapseIntegrationRuntime -ResourceId $actual.Id -Status
        Assert-NotNull $status

        $metric = Get-AzSynapseIntegrationRuntimeMetric -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname
        Assert-NotNull $metric

        $description = "description"
        $result = Set-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Description $description `
            -Force
        Assert-AreEqual $result.Description $description

        $status = Get-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Status
        Assert-NotNull $status.LatestVersion

        Remove-AzSynapseIntegrationRuntime -ResourceId $actual.Id -Force
	}
    finally
    {
        Invoke-HandledCmdlet -Command {Remove-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $irname} -IgnoreFailures
    }
}

<#
.SYNOPSIS
Creates an azure integration runtime and then does operations.
Deletes the created integration runtime at the end.
#>
function Test-Azure-IntegrationRuntime
{
    param
    (
        $resourceGroupName = (Get-ResourceGroupName),
        $workspaceName = (Get-SynapseWorkspaceName),
        $irname = "test-ManagedElastic-integrationruntime"
    )

    try
    {
        $resourceGroupName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("resourceGroupName", $resourceGroupName)
        $workspaceName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("workspaceName", $workspaceName)

        $description = "ManagedElastic"
   
        $actual = Set-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Type Managed `
            -Description $description `
            -Force

        $expected = Get-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname
        Assert-AreEqual $actual.Name $expected.Name
        Get-AzSynapseIntegrationRuntime -ResourceId $actual.Id -Status

        Remove-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $irname -Force
    }
    finally
    {
        Invoke-HandledCmdlet -Command {Remove-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $irname} -IgnoreFailures
    }
}

<#
.SYNOPSIS
Creates a self-hosted integration runtime and then does piping operations.
#>
function Test-IntegrationRuntime-Piping
{
    param
    (
        $resourceGroupName = (Get-ResourceGroupName),
        $workspaceName = (Get-SynapseWorkspaceName),
        $irname = "test-integrationruntime-for-piping"
    )

    try
    {
        $resourceGroupName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("resourceGroupName", $resourceGroupName)
        $workspaceName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("workspaceName", $workspaceName)
    
        $result = Set-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName `
            -WorkspaceName $workspaceName `
            -Name $irname `
            -Type 'SelfHosted' `
            -Force 
            
        $result | Get-AzSynapseIntegrationRuntime
        $result | Get-AzSynapseIntegrationRuntimeKey
        $result | New-AzSynapseIntegrationRuntimeKey -KeyName AuthKey1 -Force
        $result | Get-AzSynapseIntegrationRuntimeMetric
        $result | Remove-AzSynapseIntegrationRuntime -Force
    }
    finally
    {
        Invoke-HandledCmdlet -Command {Remove-AzSynapseIntegrationRuntime -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $irname} -IgnoreFailures
    }
}