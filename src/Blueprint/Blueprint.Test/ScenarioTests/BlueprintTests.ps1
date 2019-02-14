
function Get-TestManagementGroupId
{
	return "AzBlueprint"
}

function Get-TestSubscriptionId
{
	return "a1bfa635-f2bf-42f1-86b5-848c674fc321"
}

function Get-LatestPublishedDate($dates) {

}

<#
.SYNOPSIS
Test Blueprint cmdlets. Get a single Blueprint and list of Blueprints.
#>
function Test-GetBlueprint
{
    $blueprints = Get-AzBlueprint

    Assert-True {$blueprints.Count -ge 1}
	Assert-NotNull $blueprints[0].Name
	Assert-NotNull $blueprints[0].Id
	Assert-NotNull $blueprints[0].Scope
	Assert-NotNull $blueprints[0].DefinitionLocationId
	Assert-NotNull $blueprints[0].TargetScope
	Assert-NotNull $blueprints[0].Description
}

function Test-GetBlueprintWithDefinitionLocation
{
	$mgId = Get-TestManagementGroupId
	$blueprints = Get-AzBlueprint

    Assert-True {$blueprints.Count -ge 1}
	Assert-NotNull $blueprints[0].Name
	Assert-NotNull $blueprints[0].Id
	Assert-NotNull $blueprints[0].Scope
	Assert-NotNull $blueprints[0].DefinitionLocationId
	Assert-NotNull $blueprints[0].TargetScope
	Assert-NotNull $blueprints[0].Description

	$DefinitionLocationId = $blueprints[0].DefinitionLocationId
	$blueprintsByMG = Get-AzBlueprint -ManagementGroupId $DefinitionLocationId

	Assert-True {$blueprintsByMG.Count -ge 1}
	Assert-NotNull $blueprintsByMG[0].Name
	Assert-NotNull $blueprintsByMG[0].Id
	Assert-NotNull $blueprintsByMG[0].Scope
	Assert-NotNull $blueprintsByMG[0].DefinitionLocationId
	Assert-NotNull $blueprintsByMG[0].TargetScope
	Assert-NotNull $blueprintsByMG[0].Description
	Assert-AreEqual $blueprintsByMG[0].DefinitionLocationId $DefinitionLocationId
}

function Test-GetBlueprintWithDefinitionLocationAndName
{
	$blueprints = Get-AzBlueprint

    Assert-True {$blueprints.Count -ge 1}
	Assert-NotNull $blueprints[0].Name
	Assert-NotNull $blueprints[0].Id
	Assert-NotNull $blueprints[0].Scope
	Assert-NotNull $blueprints[0].DefinitionLocationId
	Assert-NotNull $blueprints[0].TargetScope
	Assert-NotNull $blueprints[0].Description

	$DefinitionLocationId = $blueprints[0].DefinitionLocationId
	$blueprintName = $blueprints[0].Name
	$blueprintsByMG = Get-AzBlueprint -ManagementGroupId $DefinitionLocationId -Name $blueprintName

	Assert-True {$blueprintsByMG.Count -ge 1}
	Assert-NotNull $blueprintsByMG[0].Name
	Assert-NotNull $blueprintsByMG[0].Id
	Assert-NotNull $blueprintsByMG[0].Scope
	Assert-NotNull $blueprintsByMG[0].DefinitionLocationId
	Assert-NotNull $blueprintsByMG[0].TargetScope
	Assert-NotNull $blueprintsByMG[0].Description
	Assert-AreEqual $blueprintsByMG[0].DefinitionLocationId $DefinitionLocationId
	Assert-AreEqual $blueprintsByMG[0].Name $blueprintName
}

function Test-GetBlueprintWithDefinitionLocationNameAndVersion
{
	$blueprints = Get-AzBlueprint

    Assert-True {$blueprints.Count -ge 1}
	Assert-NotNull $blueprints[0].Name
	Assert-NotNull $blueprints[0].Id
	Assert-NotNull $blueprints[0].Scope
	Assert-NotNull $blueprints[0].DefinitionLocationId
	Assert-NotNull $blueprints[0].TargetScope
	Assert-NotNull $blueprints[0].Description
	Assert-NotNull $blueprints[0].VersionList
	Assert-True { $blueprints[0].VersionList.Count -ge 1 }

	$DefinitionLocationId = $blueprints[0].DefinitionLocationId
	$blueprintName = $blueprints[0].Name
	$blueprintVersion = $blueprints[0].VersionList[0]
	$blueprint = Get-AzBlueprint -ManagementGroupId $DefinitionLocationId -Name $blueprintName -Version $blueprintVersion

	Assert-NotNull $blueprint.BlueprintName
	Assert-NotNull $blueprint.Id
	Assert-NotNull $blueprint.Scope
	Assert-NotNull $blueprint.DefinitionLocationId
	Assert-NotNull $blueprint.TargetScope
	Assert-NotNull $blueprint.Description
	Assert-AreEqual $blueprint.DefinitionLocationId $DefinitionLocationId
	Assert-AreEqual $blueprint.BlueprintName $blueprintName
	Assert-AreEqual $blueprint.Name $blueprintVersion
}

function Test-GetBlueprintWithDefinitionLocationNameAndLatestPublished
{
	$blueprints = Get-AzBlueprint

    Assert-True {$blueprints.Count -ge 1}
	Assert-NotNull $blueprints[0].Name
	Assert-NotNull $blueprints[0].Id
	Assert-NotNull $blueprints[0].Scope
	Assert-NotNull $blueprints[0].DefinitionLocationId
	Assert-NotNull $blueprints[0].TargetScope
	Assert-NotNull $blueprints[0].Description
	Assert-NotNull $blueprints[0].VersionList
	Assert-True { $blueprints[0].VersionList.Count -ge 1 }

	$definitionLocationId = $blueprints[0].DefinitionLocationId
	$blueprintName = $blueprints[0].Name
	$lastItem = $blueprints[0].VersionList.Count - 1
	$blueprintLatestVersion = $blueprints[0].VersionList[$lastItem]
	$blueprint = Get-AzBlueprint -ManagementGroupId $DefinitionLocationId -Name $blueprintName -LatestPublished

	Assert-NotNull $blueprint.BlueprintName
	Assert-NotNull $blueprint.Id
	Assert-NotNull $blueprint.Scope
	Assert-NotNull $blueprint.DefinitionLocationId
	Assert-NotNull $blueprint.TargetScope
	Assert-NotNull $blueprint.Description
	Assert-AreEqual $blueprint.BlueprintName $blueprintName
	Assert-AreEqual $blueprint.DefinitionLocationId $definitionLocationId
	Assert-AreEqual $blueprint.Name $blueprintLatestVersion
}
