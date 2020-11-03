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
Data Collection Rules tests
#>
function Test-AddGetListSetRemoveDataCollectionRulesAndAssociations
{
	Write-Output "Starting Test-AddGetListSetRemoveDataCollectionRules" 

    # Setup
	$resourceGroupName = 'testdcr'
    $location = 'East US 2 EUAP'
    $dcrName01 = 'testSessionDCR01'
    $dcrName02 = 'testSessionDCR02'
    $dcrAssocName01 = 'dcrAssocInput01'
    $dcrAssocName02 = 'dcrAssocInput02'
    #$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name "vmdcrtest"
    $vm = @{Id = "/subscriptions/b97224f3-b199-49b1-84c7-25b09e8fbf84/resourceGroups/testdcr/providers/Microsoft.Compute/virtualMachines/vmdcrtest"}

	[bool]$t = $true
	[bool]$f = $false
	$emptyString=""

    $newDcrJsonFile = New-TemporaryFile
    Set-JsonContent -FileFullPath $newDcrJsonFile.FullName
 	
	try
	{
		Write-Verbose " ****** Creating DCR #1"
        $dcr1 = New-AzDataCollectionRule -Location $location -ResourceGroupName $resourceGroupName -Name $dcrName01 -File $newDcrJsonFile.FullName
		Assert-NotNull $dcr1
		Assert-AreEqual $dcrName01 $dcr1.Name
        Assert-AreEqual "\Processor Information(_Total)\% Processor Time" $dcr1.DataSources.PerformanceCounters[0].CounterSpecifiers[0]

        Write-Verbose " ****** Creating DCR #2"
        $dcr2 = New-AzDataCollectionRule -Location $location -ResourceGroupName $resourceGroupName -Name $dcrName02 -File $newDcrJsonFile.FullName
		Assert-NotNull $dcr2
		Assert-AreEqual $dcrName02 $dcr2.Name
        Assert-AreEqual "azureMonitorMetrics-default" $dcr2.Destinations.AzureMonitorMetrics.Name

        Write-Verbose " ****** Get DCRs By Subscription"
        $dcrList = Get-AzDataCollectionRule
        Assert-NotNull $dcrList
		Assert-AreEqual 2 $dcrList.Length
        Assert-AreEqual "\Processor Information(_Total)\% Processor Time" $dcrList[0].DataSources.PerformanceCounters[0].CounterSpecifiers[0]

        Write-Verbose " ****** Get DCRs By Resource Group"
        $dcrList = Get-AzDataCollectionRule -ResourceGroupName $resourceGroupName
        Assert-NotNull $dcrList
		Assert-AreEqual 2 $dcrList.Length
        Assert-AreEqual "azureMonitorMetrics-default" $dcrList[0].Destinations.AzureMonitorMetrics.Name

        Write-Verbose " ****** Update DCRs from object"
        $dcr1.Description = "Updated Description"
        $dcr1 = $dcr1 | Set-AzDataCollectionRule

        Write-Verbose " ****** Get DCRs By Name"
        $dcrList = Get-AzDataCollectionRule -ResourceGroupName $resourceGroupName -Name $dcr1.Name
        Assert-NotNull $dcrList
		Assert-AreEqual 1 $dcrList.Length
        Assert-AreEqual $dcr1.Name $dcrList[0].Name
        Assert-AreEqual "Updated Description" $dcrList[0].Description

        Write-Verbose " ****** Update DCRs from JSON file"
        $dcr2.Description = "Set Description from file"
        $jsonContent = $dcr2 | ConvertTo-Json -Depth 100
        Set-Content -Path $newDcrJsonFile.FullName -Value $jsonContent
        Set-AzDataCollectionRule -File $newDcrJsonFile.FullName

        Write-Verbose " ****** Get DCRs By Name"
        $dcrList = Get-AzDataCollectionRule -ResourceGroupName $resourceGroupName -Name $dcr2.Name
        Assert-NotNull $dcrList
		Assert-AreEqual 1 $dcrList.Length
        Assert-AreEqual $dcr2.Name $dcrList[0].Name
        Assert-AreEqual "Set Description from file" $dcrList[0].Description

        #======================== TEST Associations ========================

        Write-Verbose " ****** Create DCRA #1 By InputObject"
        $dcrAssoc1 = $dcr1 | New-AzDataCollectionRuleAssociation -ResourceUri $vm.Id -Name $dcrAssocName01
        Assert-NotNull $dcrAssoc1
        Assert-AreEqual $dcrAssocName01 $dcrAssoc1.Name

        Write-Verbose " ****** Create DCRA #2 By ByDataCollectionRuleId"
        $dcrAssoc2 = New-AzDataCollectionRuleAssociation -ResourceUri $vm.Id -Name $dcrAssocName02 -DataCollectionRuleId $dcr2.Id
        Assert-NotNull $dcrAssoc2
        Assert-AreEqual $dcrAssocName02 $dcrAssoc2.Name

        Write-Verbose " ****** Get Associations By Associated Resource"
        $assocList = Get-AzDataCollectionRuleAssociation -ResourceUri $vm.Id
        Assert-NotNull $assocList
		Assert-AreEqual 2 $assocList.Length

        Write-Verbose " ****** Get Associations By Rule"
        $assocList = Get-AzDataCollectionRuleAssociation -ResourceGroupName $resourceGroupName -DataCollectionRuleName $dcrName01
        Assert-NotNull $assocList
		Assert-AreEqual 1 $assocList.Length
        Assert-AreEqual $dcr1.Id $assocList[0].DataCollectionRuleId

        Write-Verbose " ****** Get Associations By Input Object"
        $assocList = $dcr1 | Get-AzDataCollectionRuleAssociation
        Assert-NotNull $assocList
		Assert-AreEqual 1 $assocList.Length
        Assert-AreEqual $dcr1.Id $assocList[0].DataCollectionRuleId

        Write-Verbose " ****** Get Associations By Name"
        $assocList = Get-AzDataCollectionRuleAssociation -ResourceUri $vm.Id -Name $dcrAssocName02
        Assert-NotNull $assocList
		Assert-AreEqual 1 $assocList.Length
        Assert-AreEqual $dcr2.Id $assocList[0].DataCollectionRuleId

        Write-Verbose " ****** Remove DCRA #1"
        Remove-AzDataCollectionRuleAssociation -Name $dcrAssocName01 -ResourceUri $vm.Id

        Write-Verbose " ****** Remove DCRA #2"
        $dcrAssoc2 | Remove-AzDataCollectionRuleAssociation

        Write-Verbose " ****** Remove DCRA #1 by Id"
        $dcrAssoc1 = $dcr1 | New-AzDataCollectionRuleAssociation -ResourceUri $vm.Id -Name $dcrAssocName01
        Remove-AzDataCollectionRuleAssociation -ResourceId $dcrAssoc1.Id

        #===================== END - TEST Associations =====================

        Write-Verbose " ****** Remove DCRs"
        $dcr1 | Remove-AzDataCollectionRule
        Remove-AzDataCollectionRule -ResourceId $dcr2.Id
    }
    finally
    {
        # Cleanup
        Remove-Item $newDcrJsonFile.FullName -Force
    }
}

function Set-JsonContent($FileFullPath)
{
    Set-Content -Path $FileFullPath -Value '{
      "properties": {
        "dataSources": {
          "performanceCounters": [
            {
              "streams": [
                "Microsoft-InsightsMetrics"
              ],
              "scheduledTransferPeriod": "PT1M",
              "samplingFrequencyInSeconds": 10,
              "counterSpecifiers": [
                "\\Processor Information(_Total)\\% Processor Time"
              ],
              "name": "perfCounter01"
            }
          ]
        },
        "destinations": {
          "azureMonitorMetrics": {
            "name": "azureMonitorMetrics-default"
          }
        },
        "dataFlows": [
          {
            "streams": [
              "Microsoft-InsightsMetrics"
            ],
            "destinations": [
              "azureMonitorMetrics-default"
            ]
          }
        ]
      }
    }'
}