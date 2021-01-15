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
    $dcrName03 = 'testSessionDCR03'
    $dcrAssocName01 = 'dcrAssocInput01'
    $dcrAssocName02 = 'dcrAssocInput02'
    #$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name "vmdcrtest"
    $vm = @{Id = "/subscriptions/b97224f3-b199-49b1-84c7-25b09e8fbf84/resourceGroups/testdcr/providers/Microsoft.Compute/virtualMachines/vmdcrtest"}

	[bool]$t = $true
	[bool]$f = $false
	$emptyString = ""

    $newDcrJsonFile = New-TemporaryFile
 	
	try
	{
		Write-Verbose " ****** Creating DCR #1"
        Set-JsonContent -FileFullPath $newDcrJsonFile.FullName -NamePerfCounter 'perfCounterDcr1'
        $dcr1 = New-AzDataCollectionRule -Location $location -ResourceGroupName $resourceGroupName -RuleName $dcrName01 -RuleFile $newDcrJsonFile.FullName
		Assert-NotNull $dcr1
		Assert-AreEqual $dcrName01 $dcr1.Name
        Assert-AreEqual "\Processor Information(_Total)\% Processor Time" $dcr1.DataSources.PerformanceCounters[0].CounterSpecifiers[0]

        Write-Verbose " ****** Creating DCR #2"
        Set-JsonContent -FileFullPath $newDcrJsonFile.FullName -NamePerfCounter 'perfCounterDcr2'
        $dcr2 = New-AzDataCollectionRule -Location $location -ResourceGroupName $resourceGroupName -RuleName $dcrName02 -RuleFile $newDcrJsonFile.FullName
		Assert-NotNull $dcr2
		Assert-AreEqual $dcrName02 $dcr2.Name
        Assert-AreEqual "azureMonitorMetrics-default" $dcr2.Destinations.AzureMonitorMetrics.Name

        Write-Verbose " ****** Creating DCR #3"
        Set-JsonContent -FileFullPath $newDcrJsonFile.FullName -NamePerfCounter 'perfCounterDcr3'
        $dcr3 = New-AzDataCollectionRule -Location $location -ResourceGroupName $resourceGroupName -RuleName $dcrName03 -RuleFile $newDcrJsonFile.FullName
		Assert-NotNull $dcr3
		Assert-AreEqual $dcrName03 $dcr3.Name
        Assert-AreEqual "PT1M" $dcr3.DataSources.PerformanceCounters[0].ScheduledTransferPeriod

        Write-Verbose " ****** Get DCRs By Subscription"
        $dcrList = Get-AzDataCollectionRule
        Assert-NotNull $dcrList
		Assert-AreEqual 3 $dcrList.Length
        Assert-AreEqual "\Processor Information(_Total)\% Processor Time" $dcrList[0].DataSources.PerformanceCounters[0].CounterSpecifiers[0]

        Write-Verbose " ****** Get DCRs By Resource Group"
        $dcrList = Get-AzDataCollectionRule -ResourceGroupName $resourceGroupName
        Assert-NotNull $dcrList
		Assert-AreEqual 3 $dcrList.Length
        Assert-AreEqual "azureMonitorMetrics-default" $dcrList[0].Destinations.AzureMonitorMetrics.Name

        Write-Verbose " ****** Set DCRs from object"
        $dcr1.Description = "Updated Description"
        $dcr1 = $dcr1 | Set-AzDataCollectionRule

        Write-Verbose " ****** Get DCRs By Name"
        $dcrList = Get-AzDataCollectionRule -ResourceGroupName $resourceGroupName -RuleName $dcr1.Name
        Assert-NotNull $dcrList
		Assert-AreEqual 1 $dcrList.Length
        Assert-AreEqual $dcr1.Name $dcrList[0].Name
        Assert-AreEqual "Updated Description" $dcrList[0].Description

        Write-Verbose " ****** Set DCRs from JSON PSDataCollectionRuleResource file"
        $dcr2.Description = "Set Description from file"
        $jsonContent = $dcr2 | ConvertTo-Json -Depth 100
        Set-Content -Path $newDcrJsonFile.FullName -Value $jsonContent
        Set-AzDataCollectionRule -Location $location -ResourceGroupName $resourceGroupName -RuleName $dcrName02 -RuleFile $newDcrJsonFile.FullName

        Write-Verbose " ****** Get DCRs By Resource ID"
        $dcrList = Get-AzDataCollectionRule -RuleId $dcr2.Id
        Assert-NotNull $dcrList
		Assert-AreEqual 1 $dcrList.Length
        Assert-AreEqual $dcr2.Name $dcrList[0].Name
        Assert-AreEqual "Set Description from file" $dcrList[0].Description

        Write-Verbose " ****** Set DCR By Resource ID"
        Set-JsonContent -FileFullPath $newDcrJsonFile.FullName -NamePerfCounter 'perfCounterFromSet'
        Set-AzDataCollectionRule -Location $location -RuleId $dcr3.Id -RuleFile $newDcrJsonFile.FullName

        Write-Verbose " ****** Check Set by Resource ID"
        $dcrList = Get-AzDataCollectionRule -RuleId $dcr3.Id
        Assert-NotNull $dcrList
        Assert-AreEqual 1 $dcrList.Length
        $dcr3 = $dcrList[0]
        Assert-AreEqual "perfCounterFromSet" $dcr3.DataSources.PerformanceCounters[0].Name

        Write-Verbose " ****** Update Tags (PATCH Operation) By Name"
        Update-AzDataCollectionRule -ResourceGroupName $resourceGroupName -RuleName $dcrName01 -Tag @{"update1"="test by Name"; "tag2"="value2"}
        $dcrList = Get-AzDataCollectionRule -ResourceGroupName $resourceGroupName -RuleName $dcrName01
        Assert-NotNull $dcrList
        Assert-AreEqual 1 $dcrList.Length
        $dcr1 = $dcrList[0]
        Assert-AreEqual "test by Name" $dcr1.Tags["update1"]

        Write-Verbose " ****** Update Tags (PATCH Operation) By Resource ID"
        Update-AzDataCollectionRule -RuleId $dcr1.Id -Tag @{"update2"="test by Rule Id"; "tag2"="value2"}
        $dcrList = Get-AzDataCollectionRule -ResourceGroupName $resourceGroupName -RuleName $dcrName01
        Assert-NotNull $dcrList
        Assert-AreEqual 1 $dcrList.Length
        $dcr1 = $dcrList[0]
        Assert-AreEqual "test by Rule Id" $dcr1.Tags["update2"]

        Write-Verbose " ****** Update Tags (PATCH Operation) By Input Object"
        $dcr1 | Update-AzDataCollectionRule -Tag @{"update3"="test by Input Object"; "tag2"="value2"}
        $dcrList = Get-AzDataCollectionRule -ResourceGroupName $resourceGroupName -RuleName $dcrName01
        Assert-NotNull $dcrList
        Assert-AreEqual 1 $dcrList.Length
        $dcr1 = $dcrList[0]
        Assert-AreEqual "test by Input Object" $dcr1.Tags["update3"]

        #======================== TEST Associations ========================

        Write-Verbose " ****** Create DCRA #1 By InputObject"
        $dcrAssoc1 = $dcr1 | New-AzDataCollectionRuleAssociation -TargetResourceId $vm.Id -AssociationName $dcrAssocName01
        Assert-NotNull $dcrAssoc1
        Assert-AreEqual $dcrAssocName01 $dcrAssoc1.Name

        Write-Verbose " ****** Create DCRA #2 By ByDataCollectionRuleId"
        $dcrAssoc2 = New-AzDataCollectionRuleAssociation -TargetResourceId $vm.Id -AssociationName $dcrAssocName02 -RuleId $dcr2.Id
        Assert-NotNull $dcrAssoc2
        Assert-AreEqual $dcrAssocName02 $dcrAssoc2.Name

        Write-Verbose " ****** Get Associations By Associated Resource"
        $assocList = Get-AzDataCollectionRuleAssociation -TargetResourceId $vm.Id
        Assert-NotNull $assocList
		Assert-AreEqual 2 $assocList.Length

        Write-Verbose " ****** Get Associations By Rule"
        $assocList = Get-AzDataCollectionRuleAssociation -ResourceGroupName $resourceGroupName -RuleName $dcrName01
        Assert-NotNull $assocList
		Assert-AreEqual 1 $assocList.Length
        Assert-AreEqual $dcr1.Id $assocList[0].DataCollectionRuleId

        Write-Verbose " ****** Get Associations By Input Object"
        $assocList = $dcr1 | Get-AzDataCollectionRuleAssociation
        Assert-NotNull $assocList
		Assert-AreEqual 1 $assocList.Length
        Assert-AreEqual $dcr1.Id $assocList[0].DataCollectionRuleId

        Write-Verbose " ****** Get Associations By Name"
        $assocList = Get-AzDataCollectionRuleAssociation -TargetResourceId $vm.Id -AssociationName $dcrAssocName02
        Assert-NotNull $assocList
		Assert-AreEqual 1 $assocList.Length
        Assert-AreEqual $dcr2.Id $assocList[0].DataCollectionRuleId

        Write-Verbose " ****** Remove DCRA #1"
        Remove-AzDataCollectionRuleAssociation -AssociationName $dcrAssocName01 -TargetResourceId $vm.Id

        Write-Verbose " ****** Remove DCRA #2"
        $dcrAssoc2 | Remove-AzDataCollectionRuleAssociation

        Write-Verbose " ****** Remove DCRA #1 by Id"
        $dcrAssoc1 = $dcr1 | New-AzDataCollectionRuleAssociation -TargetResourceId $vm.Id -AssociationName $dcrAssocName01
        Remove-AzDataCollectionRuleAssociation -AssociationId $dcrAssoc1.Id

        #===================== END - TEST Associations =====================

        Write-Verbose " ****** Remove DCRs"
        $dcr1 | Remove-AzDataCollectionRule
        Remove-AzDataCollectionRule -RuleId $dcr2.Id
        Remove-AzDataCollectionRule -ResourceGroupName $resourceGroupName -RuleName $dcrName03
    }
    finally
    {
        # Cleanup
        Remove-Item $newDcrJsonFile.FullName -Force
    }
}

function Set-JsonContent($FileFullPath, $NamePerfCounter)
{
    Set-Content -Path $FileFullPath -Value ('{
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
              "name": "' + $NamePerfCounter + '"
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
    }')
}