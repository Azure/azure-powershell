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
Gets the location for the Lab. Default to West US if none found.
#>
function Get-Location
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne `
        [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$namespace = "Microsoft.DevTestLab"
		$type = "sites"
		$location = Get-AzureRmResourceProvider -ProviderNamespace $namespace `
        | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

		if ($location -eq $null)
		{
			return "West US"
		} else
		{
			return $location.Locations[0]
		}
	}

	return "WestUS"
}

<#
.SYNOPSIS
Invoke a script block twice, once with param1 and once with param2.
#>
function Invoke-For-Both
{
    Param($param1,
        $param2,
        [scriptblock]$functionToCall)

    $functionToCall.Invoke($param1);
    $functionToCall.Invoke($param2);
}

<#
.SYNOPSIS
Create a resource group and lab.
#>
function Setup-Test-ResourceGroup
{
    Param($_resourceGroupName,
        $_labName)
    $global:rgname = $_resourceGroupName;
    $global:labName = $_labName;

    $location = Get-Location

    #Setup
    New-AzureRmResourceGroup -Name $rgname -Location $location
    New-AzureRmResourceGroupDeployment -Name $labName -ResourceGroupName $rgname `
    -TemplateParameterObject @{ newLabName = "$labName" } `
    -TemplateFile https://raw.githubusercontent.com/Azure/azure-devtestlab/master/ARMTemplates/101-dtl-create-lab/azuredeploy.json
}

<#
.SYNOPSIS
Set global variables.
#>
function Setup-Test-Vars
{
    Param($_resourceGroupName,
        $_labName)
    $global:rgname = $_resourceGroupName;
    $global:labName = $_labName;
}

<#
.SYNOPSIS
Destroy the lab resource group.
#>
function Destroy-Test-ResourceGroup
{
    Param($_resourceGroupName)

    Remove-AzureRmResourceGroup -Name $_resourceGroupName -Force
}
