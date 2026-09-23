function Test-ExpressRouteCrossConnectionMigrationParameterBinding
{
    $mapping = New-AzExpressRouteCrossConnectionPortMapping -SourcePortId 'source-port' -TargetPortId 'target-port'
    Assert-AreEqual 'PSExpressRouteCrossConnectionPortMapping' $mapping.GetType().Name
    Assert-AreEqual 'source-port' $mapping.SourcePortId
    Assert-AreEqual 'target-port' $mapping.TargetPortId

    $diagnostics = @('Test-AzExpressRouteCrossConnectionMigration', 'Get-AzExpressRouteCrossConnectionMigrationInfo')
    $actions = @(
        'Invoke-AzExpressRouteCrossConnectionPrepareMigration',
        'Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration',
        'Invoke-AzExpressRouteCrossConnectionMigrate',
        'Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration',
        'Invoke-AzExpressRouteCrossConnectionCommitMigration',
        'Invoke-AzExpressRouteCrossConnectionRollbackMigration'
    )
    foreach ($name in ($diagnostics + $actions))
    {
        $command = Get-Command $name -Module Az.Network
        Assert-AreEqual 3 $command.ParameterSets.Count
        Assert-True { $command.Parameters.ContainsKey('AsJob') }
        foreach ($parameterSet in $command.ParameterSets)
        {
            $location = $parameterSet.Parameters | Where-Object Name -eq 'TargetPeeringLocation'
            $ports = $parameterSet.Parameters | Where-Object Name -eq 'TargetPortMapping'
            Assert-AreEqual ($diagnostics -contains $name) $location.IsMandatory
            Assert-AreEqual ($diagnostics -contains $name) $ports.IsMandatory
        }
        Assert-AreEqual ($actions -contains $name) $command.Parameters.ContainsKey('WhatIf')
    }

    Assert-Throws { New-AzExpressRouteCrossConnectionPortMapping -SourcePortId '' -TargetPortId 'target-port' }
    Assert-Throws { Test-AzExpressRouteCrossConnectionMigration -Name 'test' -ResourceGroupName 'test-rg' -TargetPeeringLocation '' -TargetPortMapping $mapping }
    Assert-Throws { Get-AzExpressRouteCrossConnectionMigrationInfo -Name 'test' -ResourceGroupName 'test-rg' -TargetPeeringLocation 'target' -TargetPortMapping @() }
    Assert-Throws { Invoke-AzExpressRouteCrossConnectionPrepareMigration -Name 'test' -ResourceGroupName 'test-rg' -PortId 'port' -WhatIf }
    Assert-Throws { Invoke-AzExpressRouteCrossConnectionCommitMigration -Name 'test' -ResourceGroupName 'test-rg' -PortId 'port' -WhatIf }
}

function Test-ExpressRouteCrossConnectionMigrationWhatIf
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $resourceId = "/subscriptions/$subscriptionId/resourceGroups/migration-rg/providers/Microsoft.Network/expressRouteCrossConnections/test-cross-connection"
    $crossConnection = New-Object Microsoft.Azure.Commands.Network.Models.PSExpressRouteCrossConnection
    $crossConnection.Id = $resourceId
    $actions = @(
        'Invoke-AzExpressRouteCrossConnectionPrepareMigration',
        'Invoke-AzExpressRouteCrossConnectionShutDownBgpForMigration',
        'Invoke-AzExpressRouteCrossConnectionMigrate',
        'Invoke-AzExpressRouteCrossConnectionRestoreBgpForMigration',
        'Invoke-AzExpressRouteCrossConnectionCommitMigration',
        'Invoke-AzExpressRouteCrossConnectionRollbackMigration'
    )
    foreach ($command in $actions)
    {
        $result = & $command -Name 'test-cross-connection' -ResourceGroupName 'migration-rg' -WhatIf -ErrorAction Stop
        Assert-Null $result
        $result = & $command -ResourceId $resourceId -WhatIf -ErrorAction Stop
        Assert-Null $result
        $result = $crossConnection | & $command -WhatIf -ErrorAction Stop
        Assert-Null $result
        $result = [pscustomobject]@{ ResourceId = $resourceId } | & $command -WhatIf -ErrorAction Stop
        Assert-Null $result
    }

    Assert-Throws { Invoke-AzExpressRouteCrossConnectionPrepareMigration -ResourceId "$resourceId/peerings/AzurePrivatePeering" -WhatIf }
    Assert-Throws { Invoke-AzExpressRouteCrossConnectionPrepareMigration -ResourceId ($resourceId -replace 'expressRouteCrossConnections', 'expressRouteCircuits') -WhatIf }
    $otherSubscriptionId = [Guid]::NewGuid().ToString()
    Assert-Throws { Invoke-AzExpressRouteCrossConnectionPrepareMigration -ResourceId ($resourceId -replace $subscriptionId, $otherSubscriptionId) -WhatIf }
    $invalidMapping = New-Object Microsoft.Azure.Commands.Network.Models.PSExpressRouteCrossConnectionPortMapping
    Assert-Throws { Invoke-AzExpressRouteCrossConnectionPrepareMigration -ResourceId $resourceId -TargetPortMapping $invalidMapping -WhatIf }
    $crossConnection.Id = $null
    Assert-Throws { $crossConnection | Invoke-AzExpressRouteCrossConnectionPrepareMigration -WhatIf }
}