<#
.SYNOPSIS
Scenario tests for New-AzInterconnectBlock, Get-AzInterconnectBlock, Update-AzInterconnectBlock, and Remove-AzInterconnectBlock cmdlets.
#>

<#
.SYNOPSIS
Test full CRUD lifecycle of an Interconnect Block: create, get (single/list/subscription),
get with instanceView, update capacity, update tags, delete, and piped input object.
#>
function Test-InterconnectBlockCRUD
{
    # Setup
    $rgname = Get-ComputeTestResourceName
    $loc = 'eastus2euap'
    $icbName = 'icb' + $rgname
    # Use a well-known test interconnect group ID for playback mode
    $igId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/' + $rgname + '/providers/Microsoft.Network/interconnectGroups/testIG'
    $sku = 'Standard_ND128isr_GB300_v6'
    $initialCapacity = 18

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force

        # Step 1: Create ICB
        $icb = New-AzInterconnectBlock `
            -ResourceGroupName $rgname `
            -Name $icbName `
            -Location $loc `
            -InterconnectGroupId $igId `
            -SkuName $sku `
            -SkuCapacity $initialCapacity `
            -Zone @('1') `
            -Tag @{ Environment = 'Test'; Project = 'ICB-CRUD' }

        Assert-NotNull $icb
        Assert-AreEqual $icbName $icb.Name
        Assert-AreEqual $loc $icb.Location
        Assert-AreEqual $sku $icb.Sku.Name
        Assert-AreEqual $initialCapacity $icb.Sku.Capacity
        Assert-AreEqual 1 $icb.Zones.Count
        Assert-AreEqual '1' $icb.Zones[0]
        Assert-NotNull $icb.Tags
        Assert-AreEqual 'Test' $icb.Tags['Environment']
        Assert-NotNull $icb.ProvisioningState

        # Step 2: Get single ICB by name
        $getResult = Get-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName
        Assert-NotNull $getResult
        Assert-AreEqual $icbName $getResult.Name
        Assert-AreEqual $sku $getResult.Sku.Name
        Assert-AreEqual $initialCapacity $getResult.Sku.Capacity
        Assert-NotNull $getResult.Id

        # Step 3: Get ICB with instanceView
        $getWithView = Get-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName -Expand 'instanceView'
        Assert-NotNull $getWithView
        Assert-AreEqual $icbName $getWithView.Name

        # Step 4: List ICBs in resource group
        $listRg = Get-AzInterconnectBlock -ResourceGroupName $rgname
        Assert-NotNull $listRg
        Assert-True { $listRg.Count -ge 1 }
        $names = $listRg | Select-Object -ExpandProperty Name
        Assert-True { $names -contains $icbName }

        # Step 5: List ICBs in subscription
        $listSub = Get-AzInterconnectBlock
        Assert-NotNull $listSub
        Assert-True { $listSub.Count -ge 1 }

        # Step 6: Update capacity (scale up)
        $newCapacity = 36
        $updated = Update-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName -SkuCapacity $newCapacity
        Assert-NotNull $updated
        Assert-AreEqual $icbName $updated.Name
        Assert-AreEqual $newCapacity $updated.Sku.Capacity

        # Verify persisted via Get
        $getAfterScale = Get-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName
        Assert-AreEqual $newCapacity $getAfterScale.Sku.Capacity

        # Step 7: Update tags
        $updatedTags = Update-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName `
            -Tag @{ Environment = 'Production'; Capacity = '36-nodes' }
        Assert-NotNull $updatedTags
        Assert-AreEqual 'Production' $updatedTags.Tags['Environment']
        Assert-AreEqual '36-nodes' $updatedTags.Tags['Capacity']

        # Verify tags persisted via Get
        $getAfterTag = Get-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName
        Assert-AreEqual 'Production' $getAfterTag.Tags['Environment']

        # Step 8: Update using InputObject (piped object)
        $icbObj = Get-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName
        $updatedViaObj = Update-AzInterconnectBlock -InputObject $icbObj -SkuCapacity 18 `
            -Tag @{ Environment = 'Staging' }
        Assert-NotNull $updatedViaObj
        Assert-AreEqual 18 $updatedViaObj.Sku.Capacity
        Assert-AreEqual 'Staging' $updatedViaObj.Tags['Environment']

        # Step 9: Remove using InputObject
        $icbToDelete = Get-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName
        Remove-AzInterconnectBlock -InputObject $icbToDelete -Force

        # Verify deletion
        $deletedList = Get-AzInterconnectBlock -ResourceGroupName $rgname
        $remainingNames = if ($deletedList) { $deletedList | Select-Object -ExpandProperty Name } else { @() }
        Assert-False { $remainingNames -contains $icbName }
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzInterconnectBlock with -PassThru returns an operation status response.
#>
function Test-InterconnectBlockRemovePassThru
{
    $rgname = Get-ComputeTestResourceName
    $loc = 'eastus2euap'
    $icbName = 'icb' + $rgname
    $igId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/' + $rgname + '/providers/Microsoft.Network/interconnectGroups/testIG'
    $sku = 'Standard_ND128isr_GB300_v6'

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force

        New-AzInterconnectBlock `
            -ResourceGroupName $rgname `
            -Name $icbName `
            -Location $loc `
            -InterconnectGroupId $igId `
            -SkuName $sku `
            -SkuCapacity 18 `
            -Zone @('1')

        # Remove with PassThru
        $result = Remove-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName -Force -PassThru
        # PassThru emits a PSOperationStatusResponse
        Assert-NotNull $result
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzInterconnectBlock with placement constraints (IncludeZone, ExcludeZone, ZonePlacementPolicy).
#>
function Test-InterconnectBlockPlacement
{
    $rgname = Get-ComputeTestResourceName
    $loc = 'eastus2euap'
    $icbName = 'icb' + $rgname
    $igId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/' + $rgname + '/providers/Microsoft.Network/interconnectGroups/testIG'
    $sku = 'Standard_ND128isr_GB300_v6'

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force

        # Create ICB with placement parameters
        $icb = New-AzInterconnectBlock `
            -ResourceGroupName $rgname `
            -Name $icbName `
            -Location $loc `
            -InterconnectGroupId $igId `
            -SkuName $sku `
            -SkuCapacity 18 `
            -Zone @('1') `
            -PlacementZonePlacementPolicy 'Any' `
            -PlacementIncludeZone @('1', '2') `
            -PlacementExcludeZone @('3')

        Assert-NotNull $icb
        Assert-AreEqual $icbName $icb.Name
        Assert-NotNull $icb.Placement
        Assert-AreEqual 'Any' $icb.Placement.ZonePlacementPolicy
        Assert-AreEqual 2 $icb.Placement.IncludeZones.Count
        Assert-AreEqual 1 $icb.Placement.ExcludeZones.Count

        # Verify persisted via Get
        $getResult = Get-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName
        Assert-NotNull $getResult.Placement
        Assert-AreEqual 'Any' $getResult.Placement.ZonePlacementPolicy
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzInterconnectBlock and Remove-AzInterconnectBlock operations run asynchronously with -AsJob.
#>
function Test-InterconnectBlockAsJob
{
    $rgname = Get-ComputeTestResourceName
    $loc = 'eastus2euap'
    $icbName = 'icb' + $rgname
    $igId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/' + $rgname + '/providers/Microsoft.Network/interconnectGroups/testIG'
    $sku = 'Standard_ND128isr_GB300_v6'

    try
    {
        New-AzResourceGroup -Name $rgname -Location $loc -Force

        # Create with -AsJob
        $job = New-AzInterconnectBlock `
            -ResourceGroupName $rgname `
            -Name $icbName `
            -Location $loc `
            -InterconnectGroupId $igId `
            -SkuName $sku `
            -SkuCapacity 18 `
            -Zone @('1') `
            -AsJob
        $job | Wait-Job
        $icb = $job | Receive-Job
        Assert-NotNull $icb
        Assert-AreEqual $icbName $icb.Name

        # Remove with -AsJob
        $removeJob = Remove-AzInterconnectBlock -ResourceGroupName $rgname -Name $icbName -Force -AsJob
        $removeJob | Wait-Job
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}
