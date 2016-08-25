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

 # The tests are currently recorded against Azure Production, 
 # using the web service definition file specified by $WEBSERVICE_DEFINITION_FILE_DOGFOOD.
 # When testing new changes to the SDK, you can first record the test against dogfood 
 # using the $WEBSERVICE_DEFINITION_FILE_DOGFOOD file. Then once everything
 # is working as expected, re-record the test against Prod before submitting an official pull request.
$WEBSERVICE_DEFINITION_FILE_PROD = 'TestData\GraphWebServiceDefinition_Prod.json'
$WEBSERVICE_DEFINITION_FILE_DOGFOOD = 'TestData\GraphWebServiceDefinition_Dogfoood.json'
$TEST_WEBSERVICE_DEFINITION_FILE = $WEBSERVICE_DEFINITION_FILE_PROD

<#
.SYNOPSIS
Tests creating new AzureML web service from a pipeline definition object, retrieve its keys and
removing the webservice using the pipeline form again. 
#>
function Test-CreateGetRemoveMLService
{  
    $serviceDeleted = $false

    $actualTest = {
        param([string] $rgName, [string] $location, [string] $webServiceName, `
                [string] $commitmentPlanId, [object] $storageAccount)
        try 
        {
            # Create a web service resource using the pipeline and validate its creation
            $svcDefinition = LoadWebServiceDefinitionForTest `
                                $TEST_WEBSERVICE_DEFINITION_FILE $commitmentPlanId $storageAccount
            LogOutput "Creating web service: $webServiceName"
            $svc = $svcDefinition | New-AzureRmMlWebService `
                    -ResourceGroupName $rgName -Location $location -Name $webServiceName -Force
            Assert-NotNull $svc
            LogOutput "Created web service: $($svc.Id)"                     
            ValidateWebServiceResult $rgName $webServiceName $location $svc

            # Fetch the service's keys and validate they are as expected
            $keys = Get-AzureRmMlWebServiceKeys -ResourceGroupName $rgName -Name $webServiceName
            LogOutput "Checking that the service's keys are not null."
            Assert-NotNull $keys
            $expectedPrimaryKey = $svcDefinition.Properties.Keys.Primary        
            $expectedSecondaryKey = $svcDefinition.Properties.Keys.Secondary
            LogOutput "Checking that the primary key value $($keys.Primary) is `
                            equal to the expected value $expectedPrimaryKey"
            Assert-True { [System.String]::Equals($keys.Primary, $expectedPrimaryKey, `
                                                    [System.StringComparison]::OrdinalIgnoreCase) }
            LogOutput "Checking that the secondary key value $($keys.Primary) is `
                            equal to the expected value $expectedSecondaryKey"
            Assert-True { [System.String]::Equals($keys.Secondary, $expectedSecondaryKey, `
                                                    [System.StringComparison]::OrdinalIgnoreCase) }

            # Delete the service using the pipeline form
            LogOutput "Removing web service $webServiceName from resource group $rgName"
            $svc | Remove-AzureRmMlWebService -Force
            LogOutput "Web service $webServiceName was removed."    
            $serviceDeleted = $true

            # Validate that service no longer exists 
            Assert-ThrowsContains { Get-AzureRmMlWebService -ResourceGroupName $rgName `
                                        -Name $webServiceName } "WebServiceNotFound"
        }
        finally
        {
            # Cleanup
            if (!$serviceDeleted) 
            {                   
                Clean-WebService $rgName $webServiceName             
            }       
        }
    };

    RunWebServicesTest $actualTest
}

<#
.SYNOPSIS
Tests creating an Azure ML service directly from a file definition
#>
function Test-CreateWebServiceFromFile
{
    $actualTest = {
        param([string] $rgName, [string] $location, [string] $webServiceName, `
                [string] $commitmentPlanId, [object] $storageAccount)

        $definitionFile = "";
        try 
        {
            # Create a valid service definition file
            $svcDefinition = LoadWebServiceDefinitionForTest $TEST_WEBSERVICE_DEFINITION_FILE `
                                                             $commitmentPlanId $storageAccount
            $definitionFile = "$webServiceName.json"
            LogOutput "Exporting web service definition to file: $definitionFile"
            Export-AzureRmMlWebService -WebService $svcDefinition -OutputFile $definitionFile
            LogOutput "Checking that exported service definition exists at $definitionFile"
            Assert-True { Test-Path $definitionFile }

            # Create a new web service from the local file definition
            LogOutput "Creating web service: $webServiceName"
            $svc = New-AzureRmMlWebService -ResourceGroupName $rgName -Location $location `
                                        -Name $webServiceName -DefinitionFile $definitionFile `
                                        -Force
            LogOutput "Created web service: $webServiceName"
            ValidateWebServiceResult $rgName $webServiceName $location $svc
        }
        finally
        {
            if (Test-Path $definitionFile)
            {
                Remove-Item $definitionFile
            }
            
            Clean-WebService $rgName $webServiceName            
        }
    };

    RunWebServicesTest $actualTest
}

<#
.SYNOPSIS
Tests creating and updating an Azure ML web service resource
#>
function Test-UpdateWebService
{
    $actualTest = {
        param([string] $rgName, [string] $location, [string] $webServiceName, `
                [string] $commitmentPlanId, [object] $storageAccount)        
        try 
        {
            # Create a web service resource and validate its creation
            $svcDefinition = LoadWebServiceDefinitionForTest $TEST_WEBSERVICE_DEFINITION_FILE `
                                    $commitmentPlanId $storageAccount
            LogOutput "Creating web service: $webServiceName"
            $svc = New-AzureRmMlWebService -ResourceGroupName $rgName -Location $location `
                                    -Name $webServiceName -NewWebServiceDefinition $svcDefinition `
                                    -Force
            Assert-NotNull $svc
            LogOutput "Created web service: $($svc.Id)"
            ValidateWebServiceResult $rgName $webServiceName $location $svc
            $creationModifiedOn = [datetime]::Parse($svc.Properties.ModifiedOn)
            LogOutput "Web service's last modified time stamp: $creationModifiedOn"

            # Update the resource by pushing an edited web service definition object 
            $svcDefinition.Properties.Description = "This has now changed."
            LogOutput "Updating description on service $($svc.Id)"
            $updatedSvc = Update-AzureRmMlWebService -ResourceGroupName $rgName `
                                    -Name $webServiceName -ServiceUpdates $svcDefinition `
                                    -Force
            Assert-NotNull $updatedSvc
            LogOutput "Update has completed."
            $updateModifiedOn = [datetime]::Parse($updatedSvc.Properties.ModifiedOn)
            LogOutput "Web service's last modified time stamp: $updateModifiedOn"
            
            # Validate the operation
            ValidateWebServiceResult $rgName $webServiceName $location $updatedSvc
            LogOutput "Checking that the description property has been updated."
            Assert-AreEqual $svcDefinition.Properties.Description $updatedSvc.Properties.Description
            LogOutput "Checking that the ModifiedOn field updated accordingly."
            Assert-True { $creationModifiedOn -lt $updateModifiedOn }

            # Update realtime endpoint settings and the service key by using in line parameters
            $newPrimaryKey = 'highly secure key'
            LogOutput "Updating in line properties on service $($svc.Id)"
            $updatedSvc2 = Update-AzureRmMlWebService -ResourceGroupName $rgName -Name $webServiceName `
                            -RealtimeConfiguration @{ MaxConcurrentCalls = 30 } `
                            -Keys @{ Primary = $newPrimaryKey } -Force
            Assert-NotNull $updatedSvc2
            LogOutput "Update has completed."
            $update2ModifiedOn = [datetime]::Parse($updatedSvc2.Properties.ModifiedOn)
            LogOutput "Web service's last modified time stamp: $update2ModifiedOn"
            
            # Validate the operation    
            ValidateWebServiceResult $rgName $webServiceName $location $updatedSvc2
            LogOutput "Checking that the RealtimeConfiguration property has been updated."
            Assert-AreEqual 30 $updatedSvc2.Properties.RealtimeConfiguration.MaxConcurrentCalls
            LogOutput "Checking that the ModifiedOn field updated accordingly."            
            Assert-True { $updateModifiedOn -lt $update2ModifiedOn }
            
            $keys = Get-AzureRmMlWebServiceKeys -ResourceGroupName $rgName -Name $webServiceName
            LogOutput "Checking that the service's keys are not null."
            Assert-NotNull $keys
            LogOutput "Checking that the service's primary key has changed."
            Assert-AreEqual $newPrimaryKey $keys.Primary
            LogOutput "Checking that the service's secondary key has not changed."
            Assert-AreEqual $svcDefinition.Properties.Keys.Secondary $keys.Secondary
        }
        finally
        {            
            Clean-WebService $rgName $webServiceName         
        }
    };

    RunWebServicesTest $actualTest
}

<#
.SYNOPSIS
Tests the cmdlets for retrieving lists of web services
#>
function Test-ListWebServices
{
    $actualTest = {
        param([string] $rgName, [string] $location, [string] $webServiceName, [string] $commitmentPlanId)        
        try 
        {
            $sameGroupWebServiceName = Get-WebServiceName
            $otherResourceGroupName = Get-ResourceGroupName 
            $otherGroupWebServiceName = Get-WebServiceName

            # Create a few web services in the same resource group
            $svcDefinition = LoadWebServiceDefinitionForTest $TEST_WEBSERVICE_DEFINITION_FILE `
                                    $commitmentPlanId $storageAccount
            LogOutput "Creating web service: $webServiceName"
            $svc1 = New-AzureRmMlWebService -ResourceGroupName $rgName -Location $location `
                                    -Name $webServiceName -NewWebServiceDefinition $svcDefinition `
                                    -Force
            Assert-NotNull $svc1
            LogOutput "Created web service: $($svc1.Id)"                     
            ValidateWebServiceResult $rgName $webServiceName $location $svc1
            LogOutput "Creating web service: $sameGroupWebServiceName"
            $svc2 = New-AzureRmMlWebService -ResourceGroupName $rgName -Location $location `
                            -Name $sameGroupWebServiceName -NewWebServiceDefinition $svcDefinition `
                            -Force
            Assert-NotNull $svc2
            LogOutput "Created web service: $($svc2.Id)"                     
            ValidateWebServiceResult $rgName $sameGroupWebServiceName $location $svc2

            # Create a web service in a different resource group
            LogOutput "Creating resource group: $otherResourceGroupName"    
            $otherGroup = New-AzureRmResourceGroup -Name $otherResourceGroupName -Location $location        
            LogOutput("Created resource group: $($otherGroup.ResourceId)")
            LogOutput "Creating web service: $otherGroupWebServiceName"
            $svc3 = New-AzureRmMlWebService -ResourceGroupName $otherResourceGroupName -Location $location `
                            -Name $otherGroupWebServiceName -NewWebServiceDefinition $svcDefinition -Force
            Assert-NotNull $svc3
            LogOutput "Created web service: $($svc3.Id)"                     
            ValidateWebServiceResult $otherResourceGroupName $otherGroupWebServiceName $location $svc3

            # List all services in the first resource group
            LogOutput "Listing all web services in resource group: $rgName"
            $servicesInGroup = Get-AzureRmMlWebService -ResourceGroupName $rgName
            Assert-NotNull $servicesInGroup
            LogOutput "Group $rgName contains $($servicesInGroup.Count) web services."    
            Assert-AreEqual 2 $servicesInGroup.Count
            LogOutput "Checking that service $($svc1.Id) is part of returned list."
            Assert-NotNull ($servicesInGroup | where { $_.Id -eq $svc1.Id })
            LogOutput "Checking that service $($svc2.Id) is part of returned list."
            Assert-NotNull ($servicesInGroup | where { $_.Id -eq $svc2.Id })

            # List all services in the second resource group
            LogOutput "Listing all web services in resource group: $otherResourceGroupName"
            $servicesInOtherGroup = Get-AzureRmMlWebService -ResourceGroupName $otherResourceGroupName
            Assert-NotNull $servicesInOtherGroup            
            LogOutput "Group $otherResourceGroupName contains $($servicesInOtherGroup.Count) web services."                            
            Assert-AreEqual 1 $servicesInOtherGroup.Count
            LogOutput "Checking that service $($svc3.Id) is part of returned list."
            Assert-True { $servicesInOtherGroup[0].Id -eq $svc3.Id }

            # List all services in the subscription
            $servicesInSubscription = Get-AzureRmMlWebService
            Assert-NotNull $servicesInSubscription
            LogOutput "Found $($servicesInSubscription.Count) web services in the current subscription."    
            Assert-False { $servicesInSubscription.Count -lt 3 }
            LogOutput "Checking that service $($svc1.Id) is part of returned list."
            Assert-NotNull ($servicesInSubscription | where { $_.Id -eq $svc1.Id })
            LogOutput "Checking that service $($svc2.Id) is part of returned list."
            Assert-NotNull ($servicesInSubscription | where { $_.Id -eq $svc2.Id })
            LogOutput "Checking that service $($svc3.Id) is part of returned list."
            Assert-NotNull ($servicesInSubscription | where { $_.Id -eq $svc3.Id })
        }
        finally
        {                
            Clean-WebService $rgName $webServiceName
            Clean-WebService $rgName $sameGroupWebServiceName
            Clean-WebService $otherResourceGroupName $otherGroupWebServiceName
            Clean-ResourceGroup $otherResourceGroupName 
        }
    };

    RunWebServicesTest $actualTest
}

<#
.SYNOPSIS
Base function for running web services tests
#>
function RunWebServicesTest([ScriptBlock] $testScript)
{
    # Setup
    $rgName = Get-ResourceGroupName 
    $location = Get-ProviderLocation "Microsoft.MachineLearning" "webServices"
    $webServiceName = Get-WebServiceName
    $storageAccountName = Get-TestStorageAccountName
    $commitmentPlanName = Get-CommitmentPlanName
    $cpApiVersion = Get-ProviderAPIVersion "Microsoft.MachineLearning" "commitmentPlans"
    LogOutput "Using version $cpApiVersion of the CP RP APIs"

    try
    {
        # Setup
        LogOutput "Creating resource group: $rgName"    
        $group = New-AzureRmResourceGroup -Name $rgName -Location $location        
        LogOutput("Created resource group: $($group.ResourceId)")

        LogOutput "Creating storage account: $storageAccountName"    
        $storageAccount = Create-TestStorageAccount $rgName $location $storageAccountName        
        LogOutput("Created storage account: $storageAccountName")

        LogOutput "Creating commitment plan resource: $commitmentPlanName"
        $cpSku = @{Name = 'PLAN_SKU_NAME'; Tier='PLAN_SKU_TIER'; Capacity=1}
        $cpPlan = New-AzureRmResource -Location $location -ResourceType `
                        "Microsoft.MachineLearning/CommitmentPlans" -ResourceName $commitmentPlanName `
                        -ResourceGroupName $rgName -SkuObject $cpSku -Properties @{} `
                        -ApiVersion $cpApiVersion -Force     
        LogOutput "Created commitment plan resource: $($cpPlan.ResourceId)" 

        &$testScript $rgName $location $webServiceName $cpPlan.ResourceId $storageAccount
    }
    finally
    {  
        Clean-TestStorageAccount $rgName $storageAccountName
        Clean-ResourceGroup $rgName        
    }
}

function LoadWebServiceDefinitionForTest([string] $filePath, [string] $commitmentPlanId, [object] $storageAccount)
{
    $svcDefinition = Import-AzureRmMlWebService -InputFile $filePath
    $svcDefinition.Properties.CommitmentPlan.Id = $commitmentPlanId
    $svcDefinition.Properties.StorageAccount.Name = $storageAccount.Name
    $svcDefinition.Properties.StorageAccount.Key = $storageAccount.Key

    return $svcDefinition
}

function ValidateWebServiceResult([string] $rgName, [string] $webServiceName, [string] $location, `
                    [Microsoft.Azure.Management.MachineLearning.WebServices.Models.WebService] $svc)
{
    $subscriptionId = ((Get-AzureRmContext).Subscription).SubscriptionId        
    $expectedServiceResourceId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.MachineLearning/webservices/$webServiceName"
    LogOutput "Checking that the created webservice's resource id $($svc.Id) matches the expected value $expectedServiceResourceId"
    Assert-AreEqual $expectedServiceResourceId $svc.Id
    LogOutput "Checking that the service's location $($svc.Location) is the expected value $location"
    Assert-True { [System.String]::Equals($svc.Location.Replace(" ", ""), $location, [System.StringComparison]::OrdinalIgnoreCase) }
    LogOutput "Checking the service's resource type: $($svc.Type)"
    Assert-AreEqual "Microsoft.MachineLearning/webservices" $svc.Type
    LogOutput "Checking that the service's properties are not null."
    Assert-NotNull $svc.Properties
    LogOutput "Checking that the service's provisioning has succeeded."
    Assert-AreEqual $svc.Properties.ProvisioningState "Succeeded"
}
