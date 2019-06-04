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

function Test-GetBlueprintWithDefinitionLocationNameAndVersion
{
	$mgId = "AzBlueprint"
	$name = "Filiz_Powershell_Test"
	$version = "6.0"
	$blueprintByMG = Get-AzBlueprint -ManagementGroupId $mgId -Name $name -Version $version

	Assert-NotNull $blueprintByMG
	Assert-NotNull $blueprintByMG.Id
	Assert-NotNull $blueprintByMG.Scope
	Assert-NotNull $blueprintByMG.DefinitionLocationId
	Assert-NotNull $blueprintByMG.TargetScope
}

function Test-GetBlueprintWithDefinitionLocationNameAndLatestPublished
{
	$mgId = "AzBlueprint"
	$name = "Filiz_Powershell_Test"
	$blueprintByMG = Get-AzBlueprint -ManagementGroupId $mgId -Name $name -LatestPublished

	Assert-NotNull $blueprintByMG
	Assert-NotNull $blueprintByMG.Id
	Assert-NotNull $blueprintByMG.Scope
	Assert-NotNull $blueprintByMG.DefinitionLocationId
	Assert-NotNull $blueprintByMG.TargetScope
}
