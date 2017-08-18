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


InModuleScope AzureRM.Websites.Experiments {
    
    function Get-AzureRmAppServicePlanMock {
        param(
        [string]$PlanName,
        [string]$GroupName,
        [object[]]$Plans
        )
        if ($PlanName -and $GroupName){
            return @{Id=$PlanName;Name=$PlanName;ResourceGroup=$GroupName}
        } else {                
            return $Plans
        }
    }

    function Get-AzureRmResourceGroupMock {
        param(
        [string]$Name,
        [object[]]$Groups
        )

        return $Groups | Where-Object {$_.ResourceGroupName -eq $Name}
    }

    Describe "Get-WebAppName "{
        $randomNumber = 1
        $defaultName = "WebApp$randomNumber"
        Context "[mock] When name is not provided: " {
            Mock Get-Random {return $randomNumber}
            Mock Test-NameAvailability {return $true} 
        
            $result = Get-WebAppName -ProvidedParameters @{}

            It "Returns string with  defaultName" {   
                $result | Should BeOfType System.String
                $result | Should Be $defaultName                 
            }
        }

        Context "[mock] When name is provided and
                            name is available: " {  
            $customName = "customName"              
            Mock Test-NameAvailability {return $true} 
        
            $result = Get-WebAppName -ProvidedParameters @{WebAppName=$customName}

            It "Returns a string with provided name" {
                $result | Should BeOfType System.String
                $result | Should Be $customName               
            }
        }

        Context "[mock] When name is provided and
                            name is NOT available: " {
            $customName = "customName"        
            Mock Test-NameAvailability {return $false}        

            It "Should throw." {   
                {$result = Get-WebAppName -ProvidedParameters @{WebAppName=$customName}} | Should Throw            
            }
        }
    }

    Describe "Get-ResourceGroupInfo "{
      $webAppName = "MyWebAppName1"
      Context "[mock] When a ResourceGroupName is not provided and
                        WebAppName is not equal to an existing resource group: " {
        Mock Test-ResourceGroupExistence {return $false}
                            
        $result = Get-ResourceGroupInfo `
                    -ProvidedParameters @{} `
                    -WebAppName $webAppName

        It "Returns a hashtable." {
            $result | Should BeOfType System.Collections.Hashtable
        }

        It "Returns a hashtable with key 'Name' set to same value as webAppName." {
            $result.Name| Should Be $webAppName
        }

        It "Returns a hashtable with key 'Exists' set to 'False'." {
            $result.Exists | Should Be $false
        }    
      }

      Context "[mock] When a ResourceGroupName is not provided and
                        WebAppName is equal to an existing resource group: " {
        Mock Test-ResourceGroupExistence {return $true}
                            
        $result = Get-ResourceGroupInfo `
                    -ProvidedParameters @{} `
                    -WebAppName $webAppName

        It "Returns a hashtable." {
            $result | Should BeOfType System.Collections.Hashtable
        }

        It "Returns a hashtable with key 'Name' set to same value as webAppName." {
            $result.Name| Should Be $webAppName
        }

        It "Returns a hashtable with key 'Exists' set to 'False'." {
            $result.Exists | Should Be $true
        }    
      }

      Context "[mock] When a ResourceGroupName is provided and
                        that name does not already exist: " {
        $customName = "customName"
        Mock Test-ResourceGroupExistence {return $false}    
                        
        $result = Get-ResourceGroupInfo `
                    -ProvidedParameters @{ResourceGroupName=$customName} `
                    -WebAppName $webAppName

        It "Returns a hashtable." {
            $result | Should BeOfType System.Collections.Hashtable
        }

        It "Returns a hashtable with key 'Name' set to same value as provided name." {
            $result.Name| Should Be $customName
        }

        It "Returns a hashtable with key 'Exists' set to 'False'." {
            $result.Exists | Should Be $false
        }    
      }

      Context "[mock] When a ResourceGroupName is provided and
                        that name already exists: " {
        $customName = "customName"  
        Mock Test-ResourceGroupExistence {return $true}   
                      
        $result = Get-ResourceGroupInfo `
                        -ProvidedParameters @{ResourceGroupName=$customName} `
                        -WebAppName $webAppName

        It "Returns a hashtable." {
            $result | Should BeOfType System.Collections.Hashtable
        }

        It "Returns a hashtable with key 'Name' set to same value as provided name." {
            $result.Name| Should Be $customName
        }

        It "Returns a hashtable with key 'Exists' set to 'True'." {
            $result.Exists | Should Be $true
        }    
      }
    }
 

    Describe "Get-AppServicePlanInfo" {
        $webAppName = "MyWebAppName1"
        Context "When no parameters are provided and 
                    there is not a default app service plan: " {
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2)
            $groupName = "group1"
            Mock Get-AzureRmAppServicePlan {return $plans}
        
            $result = Get-AppServicePlanInfo `
                        -ProvidedParameters @{} `
                        -WebAppName $webAppName `
                        -ResourceGroupName $groupName

            It "Returns a hashtable. " {
                $result | Should BeOfType System.Collections.Hashtable
            }

            It "Returns a hashtable with key 'Name' set to same value as the WebAppName. " {
                $result.Name | Should Be $webAppName
            }
        
            It "Returns a hashtable with key 'Exists' set to 'False'. " {
                $result.Exists | Should Be $false
            }

            It "Returns a hashtable with key 'ResourceGroup' set to ResourceGroupName passed. " {
                $result.ResourceGroup | Should Be $groupName
            }

            It "Returns a hashtable with key 'IsDefaultPlan' set to 'False'. " {
                $result.IsDefaultPlan | Should Be $false
            }       
        }

        Context "When no parameters are provided and 
                    there is a default app service plan: " {
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2Id";Name="plan2";Sku=@{Tier="Free"};ResourceGroup="group2"}        
            $plan3 = @{Id="plan3Id";Name="plan3";Sku=@{Tier="Free"};ResourceGroup="group3"}
            $plans = @($plan1,$plan2,$plan3)
            $groupName = "group1"
            Mock Get-AzureRmAppServicePlan {return $plans}

            $result = Get-AppServicePlanInfo `
                        -ProvidedParameters @{} `
                        -WebAppName $webAppName `
                        -ResourceGroupName $groupName

            It "Returns a hashtable. " {
                $result | Should BeOfType System.Collections.Hashtable
            }

            It "Returns a hashtable with key 'Name' set to same vaue as the first plan with default characteristics. " {
                $result.Name | Should Be $plan2.Name
            }

            It "Returns a hashtable with key 'Exists' set 'True'. " {
                $result.Exists | Should Be $true
            }

            It "Returns a hashtable with key 'ResourceGroup' set to same value as the first default plan's resource group. " {
                $result.ResourceGroup | Should Be $plan2.ResourceGroup
            }

            It "Returns a hashtable with key 'IsDefaultPlan' set to 'False'. " {
                $result.IsDefaultPlan | Should Be $true
            }
        }  

        Context "When an Id is provided and
                    plan name exists and 
                    group provided matches the provided in the id: " {
            $planName = "plan1"
            $groupName = "group1"
            $planId =  "/subscriptions/f30a7701-df2c-4bc7-ba8d-ab11861ca13c/resourceGroups/$groupName/providers/Microsoft.Web/serverfarms/$planName"
            $plan1 = @{Id=$planId;Name=$planName;Sku=@{Tier="Basic"};ResourceGroup=$groupName}
            $plan2 = @{Id="plan2Id";Name="plan2";Sku=@{Tier="Free"};ResourceGroup="group2"}        
            $plan3 = @{Id="plan3Id";Name="plan3";Sku=@{Tier="Free"};ResourceGroup="group3"}
            $plans = @($plan1,$plan2,$plan3)
            Mock Get-AzureRmAppServicePlan {return $plans}

            $result = Get-AppServicePlanInfo `
                        -ProvidedParameters @{AppServicePlan=$planId} `
                        -WebAppName $webAppName `
                        -ResourceGroupName $groupName
        
            It "Returns a hashtable. " {
                $result | Should BeOfType System.Collections.Hashtable
            }

            It "Returns a hashtable with key 'Name' set to same vaue as the plan wiht matching ID. " {
                $result.Name | Should Be $planName
            }

            It "Returns a hashtable with key 'Exists' set 'True'. " {
                $result.Exists | Should Be $true
            }
        
            It "Returns a hashtable with key 'ResourceGroup' set to same resource group found in the ID. " {
                $result.ResourceGroup | Should Be $groupName
            }

            It "Returns a hashtable with key 'IsDefaultPlan' set to 'False'. " {
                $result.IsDefaultPlan | Should Be $false
            }       
        } 
    
        Context "When an Id is provided and
                    the Id does not belong to any existent plan: " {  
            $planName = "plan1"
            $groupName = "group1"
            $planId =  "/subscriptions/f30a7701-df2c-4bc7-ba8d-ab11861ca13c/resourceGroups/$groupName/providers/Microsoft.Web/serverfarms/$planName"
            $plan2 = @{Id="plan2Id";Name="plan2";Sku=@{Tier="Free"};ResourceGroup="group2"}        
            $plan3 = @{Id="plan3Id";Name="plan3";Sku=@{Tier="Free"};ResourceGroup="group3"}
            $plans = @($plan2,$plan3)
            Mock Get-AzureRmAppServicePlan {return $plans}    

            It "Should throw. " {        
                {
                    $result = Get-AppServicePlanInfo `
                                -ProvidedParameters @{AppServicePlan=$planId} `
                                -WebAppName $webAppName `
                                -ResourceGroupName $nonMatchingGroupName
                } | Should Throw
            }
        } 

        Context "When a plan name is provided and 
                    the plan name does not exist: " {
            $planName = "customName"
            $groupName = "customGroup"
            $plan1 = @{Id="plan1Id";Name="plan1";Sku=@{Tier="Free"};ResourceGroup="group1"}        
            $plan2 = @{Id="plan2Id";Name="plan2";Sku=@{Tier="Free"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2)
            Mock Get-AzureRmAppServicePlan {return $plans}    

            $result = Get-AppServicePlanInfo `
                            -ProvidedParameters @{AppServicePlan=$planName} `
                            -WebAppName $webAppName `
                            -ResourceGroupName $groupName

            It "Returns a hashtable. " {
                $result | Should BeOfType System.Collections.Hashtable
            }

            It "Returns a hashtable with key 'Name' set to same name provided. " {
                $result.Name | Should Be $planName
            } 

            It "Returns a hashtable with key 'Exists' set 'False'. " {
                $result.Exists | Should Be $false
            }

            It "Returns a hashtable with key 'ResourceGroup' set to ResourceGroupName passed. " {
                $result.ResourceGroup | Should Be $groupName
            }

            It "Returns a hashtable with key 'IsDefaultPlan' set to 'False'. " {
                $result.IsDefaultPlan | Should Be $false
            }         
        }  

        Context "When a plan name is provided and 
                    plan name exists and 
                    there are various plans with the same name and
                    a Resource Group matching ResourceGroupName passed contains that plan name : " {
            $existingPlanName = "existingPlan"
            $groupName = "existingGroup"
            $plan1 = @{Id="plan1Id";Name=$existingPlanName;Sku=@{Tier="Free"};ResourceGroup="group1"}  
            $plan2 = @{Id="plan2Id";Name=$existingPlanName;Sku=@{Tier="Free"};ResourceGroup=$groupName}   
            $plan3 = @{Id="plan3Id";Name="plan3";Sku=@{Tier="Free"};ResourceGroup="group3"}
            $plans = @($plan1,$plan2,$plan3)
            Mock Get-AzureRmAppServicePlan {return $plans}  
        
            $result = Get-AppServicePlanInfo `
                        -ProvidedParameters @{AppServicePlan=$existingPlanName} `
                        -WebAppName $webAppName `
                        -ResourceGroupName $groupName

            It "Returns a hashtable. " {
                $result | Should BeOfType System.Collections.Hashtable
            }

            It "Returns a hashtable with key 'Name' set to same name provided. " {
                $result.Name | Should Be $existingPlanName
            } 

            It "Returns a hashtable with key 'Exists' set to 'True'. " {
                $result.Exists | Should Be $true
            }

            It "Returns a hashtable with key 'ResourceGroup' set to passed ResourceGroupName. " {
                $result.ResourceGroup | Should Be $groupName
            }

            It "Returns a hashtable with key 'IsDefaultPlan' set to 'False'. " {
                $result.IsDefaultPlan | Should Be $false
            }
        }     

        Context "When a plan name is provided and 
                    plan name exists and 
                    there are various plans with the same name and
                    a there is not Resource Group matching ResourceGroupName passed which contains that plan name : " {
            $existingPlanName = "customPlan"
            $groupName = "customGroup"
            $plan1 = @{Id="plan1Id";Name=$existingPlanName;Sku=@{Tier="Free"};ResourceGroup="group1"}  
            $plan2 = @{Id="plan2Id";Name=$existingPlanName;Sku=@{Tier="Free"};ResourceGroup="group2"}   
            $plan3 = @{Id="plan3Id";Name="plan3";Sku=@{Tier="Free"};ResourceGroup="group3"}
            $plans = @($plan1,$plan2,$plan3)
            Mock Get-AzureRmAppServicePlan {return $plans}       

            It "Should Throw. " {
                {
                    $result = Get-AppServicePlanInfo `
                                -ProvidedParameters @{AppServicePlan=$existingPlanName} `
                                -WebAppName $webAppName `
                                -ResourceGroupName $groupName
                } | Should Throw
            }
        } 

         Context "When a plan name is provided and 
                    plan name exists and 
                    there is one with that same name and
                    a there is not Resource Group matching ResourceGroupName passed which contains that plan name : " {
            $existingPlanName = "customPlan"
            $existingPlanGroup = "customGroup"
            $groupName = "passedGroup"
            $plan1 = @{Id="plan1Id";Name=$existingPlanName;Sku=@{Tier="Free"};ResourceGroup=$existingPlanGroup}  
            $plan2 = @{Id="plan2Id";Name="plan2";Sku=@{Tier="Free"};ResourceGroup="group2"}   
            $plan3 = @{Id="plan3Id";Name="plan3";Sku=@{Tier="Free"};ResourceGroup="group3"}
            $plans = @($plan1,$plan2,$plan3)
            Mock Get-AzureRmAppServicePlan {return $plans}       

            $result = Get-AppServicePlanInfo `
                        -ProvidedParameters @{AppServicePlan=$existingPlanName} `
                        -WebAppName $webAppName `
                        -ResourceGroupName $groupName

            It "Returns a hashtable. " {
                $result | Should BeOfType System.Collections.Hashtable
            }

            It "Returns a hashtable with key 'Name' set to same name provided. " {
                $result.Name | Should Be $existingPlanName
            } 

            It "Returns a hashtable with key 'Exists' set to 'True'. " {
                $result.Exists | Should Be $true
            }

            It "Returns a hashtable with key 'ResourceGroup' set to passed ResourceGroupName. " {
                $result.ResourceGroup | Should Be $existingPlanGroup
            }

            It "Returns a hashtable with key 'IsDefaultPlan' set to 'False'. " {
                $result.IsDefaultPlan | Should Be $false
            }
          
        }                                    
    }

    Describe "Get-Location" {
        $defaultLocation = "West Europe"
        Mock Get-DefaultLocation {return $defaultLocation}
        Context "When a location is not provided and
                    ResourceGroupName passed does not exist."{
            $groupName = "customGroup"
            $resourceGroupExists = $false

            $result = Get-Location -ProvidedParameters @{} -ResourceGroupName $groupName -ResourceGroupExists $resourceGroupExists

            It "Returns a string with default location. " {
                $result | Should BeOfType System.String
                $result | Should Be $defaultLocation
            }
        }

        Context "When a location is not provided and
                    ResourceGroupName passed exists."{
            $groupName = "customGroup"
            $groupLocation = "customGroupLocation"
            $group1 = @{ResourceGroupName=$groupName;Location=$groupLocation}
            $group2 = @{ResourceGroupName="group2";Location="loc2"}
            $groups = @($group1,$group2)
            $resourceGroupExists = $true
            Mock Get-AzureRmResourceGroup {return $groups | Where-Object {$_.ResourceGroupName -eq $Name}}

            $result = Get-Location -ProvidedParameters @{} -ResourceGroupName $groupName -ResourceGroupExists $resourceGroupExists

            It "Returns a string with default location. " {
                $result | Should BeOfType System.String
                $result | Should Be $groupLocation
            }
        }

        Context "When a location is provided."{
            $providedLocation = "customLocation"

            $result = Get-Location -ProvidedParameters @{Location=$providedLocation} 

            It "Returns a string with the provided location. " {
                $result | Should BeOfType System.String
                $result | Should Be $providedLocation
            }
        }
    }

    Describe "New-AzWebAppJustDoIt"{
        $randomNumber = 1
        $defaultName = "WebApp$randomNumber"
        $defaultLocation = "West Europe"
        Mock Get-Random {return $randomNumber}
        Mock Get-DefaultLocation {return $defaultLocation}
        $validLocations = @("loc1","loc2","loc3")
        Mock Get-AzureRmResourceProvider{return @(@{ProviderNamespace="Microsoft.Web";Locations=$validLocations})} 
        Mock Get-Context {}
        Mock Get-WebSitesClient {}
        Mock Get-ResourceManagementClient {}
        Context "[mock] When no parameters are provided and
                        there is not default plan: " {         
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2Id";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}  
            $plans = @($plan1,$plan2)        
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false} 
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}        
            Mock New-AzureRmAppServicePlan {return @{Id=$Name;Name=$Name;Location=$Location;Sku=@{Tier=$Tier};ResourcerGroupName=$ResourceGroupName}}
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}        

            $result = New-AzWebAppJustDoIt

            It "Returns Site with default name." {  
                $result.Name | Should be $defaultName
            }       

            It "Returns Site with a NEW ResourceGroup with same name as the webapp." {
                $result.ResourceGroupName | Should be $defaultName
                $result.ResourceGroupName | Should be $result.Name
            }

            It "Returns Site with default location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with a NEW AppServicePlan with same name as the webapp." {
                $result.AppServicePlan | Should be $defaultName
                $result.AppServicePlan | Should be $result.Name
            }
        }

        Context "[mock] When name is provided and
                        there is not default plan: " { 
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2Id";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}  
            $plans = @($plan1,$plan2)
            $customName = "customName"
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false} 
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $appPlans}
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}        
            Mock New-AzureRmAppServicePlan {return @{Id=$Name;Name=$Name;Location=$Location;Sku=@{Tier=$Tier};ResourcerGroupName=$ResourceGroupName}}
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}        

            $result = New-AzWebAppJustDoIt -WebAppName $customName

            It "Returns Site with provided name." {  
                $result.Name | Should be $customName
            }       

            It "Returns Site with a NEW ResourceGroup with same name as the webapp." {
                $result.ResourceGroupName | Should be $customName
            }

            It "Returns Site with default location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with a NEW AppServicePlan with same name as the webapp." {
                $result.AppServicePlan | Should be $customName
            }
        }

        Context "[mock] When no parameters are provided and
                        there is one default plan: " {
            $defaultPlanName = "defaultPlan"
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}        
            $plan2 = @{Id="$defaultPlanName";Name=$defaultPlanName;Sku=@{Tier="Free"};ResourceGroup="group2"}  
            $plans = @($plan1,$plan2)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}        
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}} 

            $result = New-AzWebAppJustDoIt

            It "Returns Site with default name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with a NEW ResourceGroup with same name as the webapp." {
                $result.ResourceGroupName | Should be $defaultName
                $result.ResourceGroupName | Should be $result.Name
            }

            It "Returns Site with default Location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with the only EXISTING default plan." {
                $result.AppServicePlan | Should be $defaultPlanName
            }
        }

        Context "[mock] When no parameters are provided and
                        there is multiple default plans: " {
            $defaultPlanName1 = "defaultPlan1"
            $defaultPlanName2 = "defaultPlan2"
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}        
            $plan2 = @{Id="$defaultPlanName1";Name=$defaultPlanName1;Sku=@{Tier="Free"};ResourceGroup="group2"}  
            $plan3 = @{Id="$defaultPlanName2";Name=$defaultPlanName2;Sku=@{Tier="Free"};ResourceGroup="group3"}  
            $plans = @($plan1,$plan2,$plan3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}        
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}} 

            $result = New-AzWebAppJustDoIt

            It "Returns Site with default name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with a NEW ResourceGroup with same name as the webapp." {
                $result.ResourceGroupName | Should be $defaultName
                $result.ResourceGroupName | Should be $result.Name
            }

            It "Returns Site with default Location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with the first EXISTING default plan." {
                $result.AppServicePlan | Should be $defaultPlanName1
            }
        }

        Context "[mock] When group name is provided and
                        group with provided name exists and
                        default plan does not exist: " {
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $existingGroupName = "existingGroupName"
            $existingGroupLocation = "existingGroupLocation"
            $group1 = @{ResourceGroupName=$existingGroupName;Location=$existingGroupLocation}
            $group2 = @{ResourceGroupName="rg2";Location="loc2"}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $true}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
            Mock New-AzureRmAppServicePlan {return @{Id=$Name;Name=$Name;Location=$Location;Sku=@{Tier=$Tier};ResourcerGroupName=$ResourceGroupName}}
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  

            $result = New-AzWebAppJustDoIt -ResourceGroupName $existingGroupName

            It "Returns Site with default name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with EXISTING group with provided ResourceGroupName." {
                $result.ResourceGroupName | Should be $existingGroupName
            }

            It "Returns Site with the SAME Location as the existing resource group 
                that matches the provided ResourceGroupName." {
                $result.Location | Should be $existingGroupLocation
            } 

            It "Returns Site with NEW AppServicePlan with the same name as the webapp." {
                $result.AppServicePlan | Should be $defaultName
                $result.AppServicePlan | Should be $result.Name
            }
        }

        Context "[mock] When group name is provided and
                        group with provided name does not exist and
                        default plan does not exist: " {
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $providedGroupName = "providedGroupName"
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName="rg2";Location="loc2"}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}
            Mock New-AzureRmAppServicePlan {return @{Id=$Name;Name=$Name;Location=$Location;Sku=@{Tier=$Tier};ResourcerGroupName=$ResourceGroupName}}
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  

            $result = New-AzWebAppJustDoIt -ResourceGroupName $providedGroupName

            It "Returns Site with default name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with NEW group with provided ResourceGroupName." {
                $result.ResourceGroupName | Should be $providedGroupName
            }

            It "Returns Site with the default Location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with NEW AppServicePlan with the same name as the webapp." {
                $result.AppServicePlan | Should be $defaultName
                $result.AppServicePlan | Should be $result.Name
            }
        }

        Context "[mock] When plan name is provided and
                        plan with provided name does not exist: " {
            $providedPlanName = "ProvidedPlanName"
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName="rg2";Location="loc2"}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}
            Mock New-AzureRmAppServicePlan {return @{Id=$Name;Name=$Name;Location=$Location;Sku=@{Tier=$Tier};ResourcerGroupName=$ResourceGroupName}}
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  

            $result = New-AzWebAppJustDoIt -AppServicePlan $providedPlanName

            It "Returns Site with default name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with NEW group with same name as the webapp." {
                $result.ResourceGroupName | Should Be $defaultName
                $result.ResourceGroupName  | Should Be $result.Name
            }

            It "Returns Site with the default Location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with NEW AppServicePlan with the same name as the webapp." {
                $result.AppServicePlan | Should be $providedPlanName
            }
        }


        Context "[mock] When plan name is provided and
                        one plan with provided name exist: " {
            $existingPlanName = "ExistingPlanName"
            $existingPlanGroup = "ExistingPlanGroup"
            $plan1 = @{Id=$existingPlanName;Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup=$existingPlanGroup}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName="rg2";Location="loc2"}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  

            $result = New-AzWebAppJustDoIt -AppServicePlan $existingPlanName

            It "Returns Site with default name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with NEW group with same name as the webapp." {
                $result.ResourceGroupName | Should Be $defaultName
                $result.ResourceGroupName  | Should Be $result.Name
            }

            It "Returns Site with the default Location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with EXISTING AppServicePlan name." {
                $result.AppServicePlan | Should be  $existingPlanName
            }
        }

        Context "[mock] When plan name is provided and
                        multiple plans with provided name exist: " {
            $existingPlanName = "ExistingPlanName"
            $existingPlanGroup = "ExistingPlanGroup"
            $plan1 = @{Id="plan1";Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2";Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName="rg2";Location="loc2"}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}
            Mock New-AzureRmAppServicePlan {return @{Id=$Name;Name=$Name;Location=$Location;Sku=@{Tier=$Tier};ResourcerGroupName=$ResourceGroupName}}
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  

        

            It "Should throw." {  
                {$result = New-AzWebAppJustDoIt -AppServicePlan $existingPlanName} | Should Throw
            } 
        }


        Context "[mock] When plan name  and group name are provided and
                        no plan nor group with those names exist: " {
            $providedPlanName = "PlanName"
            $providedGroupName = "GroupNAme"
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName="rg2";Location="loc2"}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}
            Mock New-AzureRmAppServicePlan {return @{Id=$Name;Name=$Name;Location=$Location;Sku=@{Tier=$Tier};ResourcerGroupName=$ResourceGroupName}}
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  
               
            $result = New-AzWebAppJustDoIt -AppServicePlan $providedPlanName -ResourceGroupName $providedGroupName

            It "Returns Site with DEFAULT name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with NEW group with same name provided." {
                $result.ResourceGroupName | Should Be $providedGroupName
            }

            It "Returns Site with the DEFAULT Location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with EXISTING AppServicePlan name." {
                $result.AppServicePlan | Should Be  $providedPlanName 
            }
        }

        Context "[mock] When plan name  and group name are provided and
                        no group with that name exist and
                        plan with that name exist: " {
            $existingPlanName = "ExistingPlanName"
            $providedGroupName = "GroupNAme"
            $plan1 = @{Id=$existingPlanName;Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName="rg2";Location="loc2"}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}        
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  
               
            $result = New-AzWebAppJustDoIt -AppServicePlan $existingPlanName -ResourceGroupName $providedGroupName

            It "Returns Site with DEFAULT name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with NEW group with same name provided." {
                $result.ResourceGroupName | Should Be $providedGroupName
            }

            It "Returns Site with the DEFAULT Location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with EXISTING AppServicePlan name." {
                $result.AppServicePlan | Should Be  $existingPlanName
            }
        }

        Context "[mock] When plan name  and group name are provided and
                        no group with that name exist and
                        multiple plans with that name exist: " {
            $existingPlanName = "ExistingPlanName"
            $providedGroupName = "GroupNAme"
            $plan1 = @{Id="plan1";Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup="group1"}
            $plan2 = @{Id="plan2";Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName="rg2";Location="loc2"}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $false}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
        
            It "Should throw." {       
                {$result = New-AzWebAppJustDoIt -AppServicePlan $existingPlanName -ResourceGroupName $providedGroupName} | Should Throw "There are various App Service Plans with that name"
            }
        }
    
        Context "[mock] When plan name  and group name are provided and
                        group with that name exists
                        plan with that name exist and belongs to that group: " {
            $existingPlanName = "ExistingPlanName"
            $existingGroupName = "GroupNAme"
            $existingGroupLocation = "locationgroup"
            $plan1 = @{Id=$existingPlanName;Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup=$existingGroupName}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName=$existingGroupName;Location=$existingGroupLocation}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $true}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}         
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  
               
            $result = New-AzWebAppJustDoIt -AppServicePlan $existingPlanName -ResourceGroupName $existingGroupName

            It "Returns Site with DEFAULT name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with EXISTING group with same name provided." {
                $result.ResourceGroupName | Should Be $existingGroupName
            }

            It "Returns Site with the location of EXISTING Location." {
                $result.Location | Should be $existingGroupLocation
            } 

            It "Returns Site with EXISTING AppServicePlan name." {
                $result.AppServicePlan | Should Be  $existingPlanName
            }
        }

        Context "[mock] When plan name  and group name are provided and
                        group with that name exists
                        plan with that name exist and belongs to another group: " {
            $existingPlanName = "ExistingPlanName"
            $existingPlanGroup = "ExistingPlanGroup"
            $existingGroupName = "GroupNAme"
            $existingGroupLocation = "locationgroup"
            $plan1 = @{Id=$existingPlanName;Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup=$existingPlanGroup}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup=$existingGroupName}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName=$existingGroupName;Location=$existingGroupLocation}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $true}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}         
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  
               
            $result = New-AzWebAppJustDoIt -AppServicePlan $existingPlanName -ResourceGroupName $existingGroupName

            It "Returns Site with DEFAULT name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with EXISTING group with same name provided." {
                $result.ResourceGroupName | Should Be $existingGroupName
            }

            It "Returns Site with the location of EXISTING Location." {
                $result.Location | Should be $existingGroupLocation
            } 

            It "Returns Site with EXISTING AppServicePlan name." {
                $result.AppServicePlan | Should Be  $existingPlanName
            }
        }

         Context "[mock] When plan name  and group name are provided and
                        group with that name exists
                        multiple plans with that name  and 
                        one belongs to the existing group: " {
            $existingPlanName = "ExistingPlanName"
            $existingPlanGroup = "ExistingPlanGroup"
            $existingPlanGroupLocation = "locationgroup"
            $plan1 = @{Id=$existingPlanName;Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup=$existingPlanGroup}
            $plan2 = @{Id="plan2";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName=$existingPlanGroup ;Location=$existingPlanGroupLocation}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $true}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}         
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  
               
            $result = New-AzWebAppJustDoIt -AppServicePlan $existingPlanName  -ResourceGroupName $existingPlanGroup

            It "Returns Site with DEFAULT name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with EXISTING group with same name provided." {
                $result.ResourceGroupName | Should Be $existingPlanGroup
            }

            It "Returns Site with the location of EXISTING Location." {
                $result.Location | Should be $existingPlanGroupLocation
            } 

            It "Returns Site with EXISTING AppServicePlan name which belongs to the existing group." {
                $result.AppServicePlan | Should Be  $existingPlanName
            }
        }

        Context "[mock] When plan name  and group name are provided and
                        group with that name exists and 
                        plan with that name does not exist, and there is 
                        a default plan: " {
            $defaultPlanName = "DefaultPlanName"
            $customPlan = "customPlan"
            $existingGroup = "exisitingGroup"
            $existingGroupLocation = "locationgroup"
            $plan1 = @{Id="plan1";Name="plan2";Sku=@{Tier="Free"};ResourceGroup="group1"}
            $plan2 = @{Id=$defaultPlanName;Name=$defaultPlanName;Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName=$existingGroup  ;Location=$existingGroupLocation}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $true}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}         
            Mock New-AzureRmAppServicePlan {return @{Id=$Name;Name=$Name;Location=$Location;Sku=@{Tier=$Tier};ResourcerGroupName=$ResourceGroupName}}
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  
               
            $result = New-AzWebAppJustDoIt -AppServicePlan $customPlan -ResourceGroupName $existingGroup

            It "Returns Site with DEFAULT name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with EXISTING group with same name provided." {
                $result.ResourceGroupName | Should Be  $existingGroup
            }

            It "Returns Site with the location of EXISTING Location." {
                $result.Location | Should be $existingGroupLocation
            } 

            It "Returns Site with EXISTING AppServicePlan name which belongs to the existing group." {
                $result.AppServicePlan | Should Be  $customPlan
            }
        }

        Context "[mock] When plan ID and group name are provided and
                        group with that name does not exist and 
                        plan with that ID exist: " {
            $existingPlanName = "existingPlan"
            $existingPlanGroup = "existingPlanGroup"
            $groupExistence = $false
            $existingPlanId = "/subscriptions/f30a7701-df2c-1bc2-ba9d-pb11861cr13c/resourceGroups/$existingPlanGroup/providers/Microsoft.Web/serverfarms/$existingPlanName"
            $providedGroupName = "ProvidedGroupName"        
            $plan1 = @{Id="plan1";Name="plan2";Sku=@{Tier="Free"};ResourceGroup="group1"}
            $plan2 = @{Id=$existingPlanId;Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup=$existingPlanGroup}
            $plans = @($plan1,$plan2) 
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName=$existingPlanGroup ;Location="loc2"}
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $groupExistence}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}         
            Mock New-AzureRmResourceGroup {return @{ResourceGroupName=$Name;Location=$Location}}  
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  
               
            $result = New-AzWebAppJustDoIt -AppServicePlan $existingPlanId -ResourceGroupName $providedGroupName

            It "Returns Site with DEFAULT name." {  
                $result.Name | Should be $defaultName
            } 
        
            It "Returns Site with NEW group with same name as the app." {
                $result.ResourceGroupName | Should be $providedGroupName
            }

            It "Returns Site with the location of DEFAULT Location." {
                $result.Location | Should be $defaultLocation
            } 

            It "Returns Site with EXISTING AppServicePlan name." {
                $result.AppServicePlan | Should Be  $existingPlanName
            }
        }

        Context "[mock] When plan ID and group name are provided and
                            group with that name exists and 
                            plan with that ID exist: " {
            $existingPlanName = "existingPlan"
            $existingPlanGroup = "existingPlanGroup"        
            $existingPlanId = "/subscriptions/f30a7701-df2c-1bc2-ba9d-pb11861cr13c/resourceGroups/$existingPlanGroup/providers/Microsoft.Web/serverfarms/$existingPlanName"
            $groupExistence = $true        
            $plan1 = @{Id="plan1";Name="plan2";Sku=@{Tier="Free"};ResourceGroup="group1"}
            $plan2 = @{Id=$existingPlanId;Name=$existingPlanName;Sku=@{Tier="Basic"};ResourceGroup=$existingPlanGroup}
            $plans = @($plan1,$plan2) 
            $groupLocation = "groupLocation"
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName=$existingPlanGroup ;Location=$groupLocation }
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $groupExistence}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}  
               
            $result = New-AzWebAppJustDoIt -AppServicePlan $existingPlanId -ResourceGroupName $existingPlanGroup

            It "Returns Site with DEFAULT name." {  
                $result.Name | Should Be $defaultName
            } 
        
            It "Returns Site with NEW group with same name as the app." {
                $result.ResourceGroupName | Should Be $existingPlanGroup
            }

            It "Returns Site with the location of DEFAULT Location." {
                $result.Location | Should Be $groupLocation 
            } 

            It "Returns Site with EXISTING AppServicePlan name." {
                $result.AppServicePlan | Should Be  $existingPlanName
            }
        }

        Context "[mock] When plan ID and group name are provided and
                            group with that name exists and 
                            plan with that ID DOES NOT exist: " {
            $providedPlanName = "ProvidedPlanName"  
            $providedPlanGroup = "ProvidedPlanGroup"     
            $providedPlanId = "/subscriptions/f30a7701-df2c-1bc2-ba9d-pb11861cr13c/resourceGroups/$providedPlanName/providers/Microsoft.Web/serverfarms/$providedPlanGroup"
            $groupExistence = $true        
            $plan1 = @{Id="plan1";Name="plan1";Sku=@{Tier="Free"};ResourceGroup="group1"}
            $plan2 = @{Id="plan1";Name="plan2";Sku=@{Tier="Basic"};ResourceGroup="group2"}
            $plans = @($plan1,$plan2) 
            $existingGroup = "Existing Group"
            $groupLocation = "groupLocation"
            $group1 = @{ResourceGroupName="rg1";Location="loc1"}
            $group2 = @{ResourceGroupName=$existingGroup ;Location=$groupLocation }
            $group3 = @{ResourceGroupName="rg3";Location="loc3"}
            $groups = @($group1, $group2, $group3)
            Mock Test-NameAvailability {return $true}
            Mock Test-ResourceGroupExistence {return $groupExistence}
            Mock Get-AzureRmAppServicePlan {return Get-AzureRmAppServicePlanMock $Name $ResourceGroupName $plans}
            Mock Get-AzureRmResourceGroup {return Get-AzureRmResourceGroupMock $Name $groups}     
            Mock New-AzureRmWebApp {return @{Name=$Name;ResourceGroupName=$ResourceGroupName;AppServicePlan=$AppServicePlan;Location=$Location}}         

            It "Should Throw." {  
               {$result = New-AzWebAppJustDoIt -AppServicePlan $providedPlanId -ResourceGroupName $existingGroup} | Should Throw "The app service plan with the id provided does not exist"
            }        
        }    

        Context "[mock] When NON-VALID LOCATION is provided: " {
            $nonValidLocation = "customLocation"               

            It "Should throw." {  
                {$result = New-AzWebAppJustDoIt -ResourceGroupName $existingGroup.ResourceGroupName -Location $nonValidLocation} | Should Throw
            }       
        }
    }
}
