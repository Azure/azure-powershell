<#
.SYNOPSIS
Tests the Get-AzureDtlLab cmdlet (parameterset = ListAll)
#>
function Test-GetAzureDtlLab-ListAll
{
	$labs = get-AzureDtlLab

	Assert-NotNull $labs
	Assert-AreEqual $labs.Count 1

	Assert-NotNull $labs[0]
	Assert-NotNull $labs[0].Name

	Assert-AreEqual $labs[0].Name "HackathonLab"
}

<#
.SYNOPSIS
Tests the Get-AzureDtlLab cmdlet (parameterset = ListAllWithinResourceGroup)
#>
function Test-GetAzureDtlLab-ListAllWithinResourceGroup
{
	$resourcegroup = "HackathonLabRG"
	$labs = get-AzureDtlLab -ResourceGroupName $resourcegroup

	Assert-NotNull $labs
	Assert-AreEqual $labs.Count 1

	Assert-NotNull $labs[0]
	Assert-NotNull $labs[0].Name

	Assert-AreEqual $labs[0].Name "HackathonLab"
}

<#
.SYNOPSIS
Tests the Get-AzureDtlLab cmdlet (parameterset = GetSpecificWithinResourceGroup)
#>
function Test-GetAzureDtlLab-GetSpecificWithinResourceGroup
{
	$resourcegroup = "HackathonLabRG"
	$labname = "HackathonLab"
	$labs = get-AzureDtlLab -ResourceGroupName $resourcegroup -LabName $labname

	Assert-NotNull $labs
	Assert-AreEqual $labs.Count 1

	Assert-NotNull $labs[0]
	Assert-NotNull $labs[0].Name

	Assert-AreEqual $labs[0].Name $labname
}