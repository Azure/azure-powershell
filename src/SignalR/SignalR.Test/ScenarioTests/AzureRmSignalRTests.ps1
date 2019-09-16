# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Test common SignalR cmdlets.
#>
function Test-AzureRmSignalR {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $signalrName = Get-RandomSignalRName
    $freeSignalRName = Get-RandomSignalRName "signalr-free-test-"
    $location = Get-ProviderLocation "Microsoft.SignalRService/SignalR"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # New Standard SignalR
        $signalr = New-AzSignalR -ResourceGroupName $resourceGroupName -Name $signalrName -Sku "Standard_S1"
        Verify-SignalR $signalr $signalrName $location "Standard_S1" 1

        # List the SignalR instances by resource group, should return a single SignalR instance
        $signalrs = Get-AzSignalR -ResourceGroupName $resourceGroupName
        Assert-NotNull $signalrs
        Assert-AreEqual "PSSignalRResource" $signalrs.GetType().Name
        Verify-SignalR $signalrs $signalrName $location "Standard_S1" 1

        # Get the SignalR instance by name
        $retrievedSignalR = Get-AzSignalR -ResourceGroupName $resourceGroupName -Name $signalrName
        Verify-SignalR $retrievedSignalR $signalrName $location "Standard_S1" 1

        # create another free instance in the same resource group
        $freeSignalR = New-AzSignalR -ResourceGroupName $resourceGroupName -Name $freeSignalRName -Sku "Free_F1"
        Verify-SignalR $freeSignalR $freeSignalRName $location "Free_F1" 1

        # List all the SignalR instances in the resource group
        $signalrs = Get-AzSignalR -ResourceGroupName $resourceGroupName
        Assert-NotNull $signalrs
        Assert-AreEqual "Object[]" $signalrs.GetType().Name
        Assert-AreEqual 2 $signalrs.Length
        $freeSignalR = $signalrs | Where-Object -FilterScript {$_.Sku.Name -eq "Free_F1"}
        $standardSignalR = $signalrs | Where-Object -FilterScript {$_.Sku.Name -eq "Standard_S1"}
        Assert-NotNull $freeSignalR
        Assert-NotNull $standardSignalR
        Verify-SignalR $freeSignalR $freeSignalRName $location "Free_F1" 1

        # Get the SignalR instance keys
        $keys = Get-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName
        Assert-NotNull $keys
        Assert-NotNull $keys.PrimaryKey
        Assert-NotNull $keys.PrimaryConnectionString
        Assert-NotNull $keys.SecondaryKey
        Assert-NotNull $keys.SecondaryConnectionString

        # regenerate the primary key
        $ret = New-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName -KeyType Primary -PassThru
        Assert-True { $ret }
        $newKeys1 = Get-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName
        Assert-NotNull $newKeys1
        Assert-AreNotEqual $keys.PrimaryKey $newKeys1.PrimaryKey
        Assert-AreNotEqual $keys.PrimaryConnectionString $newKeys1.PrimaryConnectionString
        Assert-AreEqual $keys.SecondaryKey $newKeys1.SecondaryKey
        Assert-AreEqual $keys.SecondaryConnectionString $newKeys1.SecondaryConnectionString

        # regenerate the secondary key
        $ret = New-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName -KeyType Secondary
        Assert-Null $ret
        $newKeys2 = Get-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName
        Assert-NotNull $newKeys2
        Assert-AreEqual $newKeys1.PrimaryKey $newKeys2.PrimaryKey
        Assert-AreEqual $newKeys1.PrimaryConnectionString $newKeys2.PrimaryConnectionString
        Assert-AreNotEqual $newKeys1.SecondaryKey $newKeys2.SecondaryKey
        Assert-AreNotEqual $newKeys1.SecondaryConnectionString $newKeys2.SecondaryConnectionString

        Remove-AzSignalR -ResourceGroupName $resourceGroupName -Name $signalrName

        Get-AzSignalR -ResourceGroupName $resourceGroupName | Remove-AzSignalR
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

<#
.SYNOPSIS
Test SignalR cmdlets using default arguments.
#>
function Test-AzureRmSignalRWithDefaultArgs {
    $resourceGroupName = Get-RandomResourceGroupName
    $signalrName = Get-RandomSignalRName
    $freeSignalRName = Get-RandomSignalRName "signalr-free-test-"
    $location = Get-ProviderLocation "Microsoft.SignalRService/SignalR"

    try {
		New-AzResourceGroup -Name $resourceGroupName -Location $location

        # New without SignalR resource group, use the SignalR instance name as the resource group
        $signalr = New-AzSignalR -Name $resourceGroupName
        Verify-SignalR $signalr $resourceGroupName $location "Standard_S1" 1

        $signalrs = Get-AzSignalR -ResourceGroupName $resourceGroupName
        Assert-NotNull $signalrs
        Assert-AreEqual "PSSignalRResource" $signalrs.GetType().Name
        Verify-SignalR $signalrs $resourceGroupName $location "Standard_S1" 1

        # Set AzureRm default resource group name, and subsequent calls will use this as the resource group if missing.
        Set-AzDefault -ResourceGroupName $resourceGroupName
        $signalr = New-AzSignalR -Name $signalrName -Sku "Free_F1"

        # List all the SignalR instances in the resource group
        $signalrs = Get-AzSignalR -ResourceGroupName $resourceGroupName
        Assert-NotNull $signalrs
        Assert-AreEqual "Object[]" $signalrs.GetType().Name
        Assert-AreEqual 2 $signalrs.Length
        $freeSignalR = $signalrs | Where-Object -FilterScript {$_.Sku.Name -eq "Free_F1"}
        $standardSignalR = $signalrs | Where-Object -FilterScript {$_.Sku.Name -eq "Standard_S1"}
        Assert-NotNull $freeSignalR
        Assert-NotNull $standardSignalR
        Verify-SignalR $freeSignalR $signalrName $location "Free_F1" 1

        #Get keys from the SignalR instance in the default resource group
        $keys = Get-AzSignalRKey -Name $signalrName
        Assert-NotNull $keys
        Assert-NotNull $keys.PrimaryKey
        Assert-NotNull $keys.PrimaryConnectionString
        Assert-NotNull $keys.SecondaryKey
        Assert-NotNull $keys.SecondaryConnectionString

        # Regenerate keys for the SignalR instance in the default resource group
        $ret = New-AzSignalRKey -Name $signalrName -KeyType Primary -PassThru
        Assert-True { $ret }
        $newKeys1 = Get-AzSignalRKey -Name $signalrName
        Assert-NotNull $newKeys1
        Assert-AreNotEqual $keys.PrimaryKey $newKeys1.PrimaryKey
        Assert-AreNotEqual $keys.PrimaryConnectionString $newKeys1.PrimaryConnectionString
        Assert-AreEqual $keys.SecondaryKey $newKeys1.SecondaryKey
        Assert-AreEqual $keys.SecondaryConnectionString $newKeys1.SecondaryConnectionString

        # Remove the SignalR instance with the given name in the default resource group
        Remove-AzSignalR -Name $signalrName

        # Get the SignalR instance with the given name in the default resource group and remove
        Get-AzSignalR -Name $resourceGroupName | Remove-AzSignalR
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

<#
.SYNOPSIS
Verify basic SignalR object properties.
#>
function Verify-SignalR {
    param(
        [Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource] $signalr,
        [string] $signalrName,
        [string] $location,
        [string] $sku,
        [int] $unitCount
    )
    Assert-NotNull $signalr
    Assert-NotNull $signalr.Id
    Assert-NotNull $signalr.Type
    Assert-AreEqual $signalrName $signalr.Name
    Assert-LocationEqual $location $signalr.Location

    Assert-NotNull $signalr.Sku
    Assert-AreEqual ([Microsoft.Azure.Commands.SignalR.Models.PSResourceSku]) $signalr.Sku.GetType()
    Assert-AreEqual $sku $signalr.Sku.Name
    Assert-AreEqual $unitCount $signalr.Sku.Capacity
    Assert-AreEqual "Succeeded" $signalr.ProvisioningState
    Assert-AreEqual "$signalrName.service.signalr.net" $signalr.HostName
    Assert-NotNull $signalr.ExternalIP
    Assert-NotNull $signalr.PublicPort
    Assert-NotNull $signalr.ServerPort
    Assert-NotNull $signalr.Version
}
