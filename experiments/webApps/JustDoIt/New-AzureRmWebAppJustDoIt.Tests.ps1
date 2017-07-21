$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path) -replace '\.Tests\.', '.'
. "$here\$sut"

$randomNumber = 1
$defaultName = "ResourceGroup$randomNumber"
$testCases = @(
    @{ProvidedParameters=@{};AppServicePlans=@()},
    @{ProvidedParameters=@{ResourceGroupName="RG"};AppServicePlans=@()},
    @{ProvidedParameters=@{AppServicePlanName="ASP"};AppServicePlans=@(@{Name="ASP1";ResourceGroup="RG1"},@{Name="ASP2";ResourceGroup="RG2"})},
    @{ProvidedParameters=@{AppServicePlanName="ASP2"};AppServicePlans=@(@{Name="ASP1";ResourceGroup="RG1"},@{Name="ASP2";ResourceGroup="RG2"})}

)

Describe "Get-ResourceGroupNameJustDoIt" {

    Context "[mock] When ParametersProvided hashset does not contain ResourceGroupName, 
            and it does not contain AppServiceName: " {

            Mock Get-Random { return $randomNumber }

        It "Returns the default name." {
            $result = Get-ResourceGroupNameJustDoIt -ProvidedParameters $testCases[0].ProvidedParameters -AppServicePlans $testCases[0].AppServicePlans
            $result | Should be $defaultName          
        }                
    }

    Context "[mock] When ParametersProvided hashset contains ResourceGroupName, 
            and it does not contain AppServicePlanName: " {
        It "Returns the specified name on ResourceGroupName." {
            $result = Get-ResourceGroupNameJustDoIt -ProvidedParameters $testCases[1].ProvidedParameters -AppServicePlans $testCases[1].AppServicePlans
            $result | Should be $testCases[1].ProvidedParameters.ResourceGroupName          
        }                
    }
    Context "[mock] When ParametersProvided hashset does not contain ResourceGroupName, 
            but it contains AppServicePlanName. However, AppServicePlanName does not match 
            any AppServicePlan from the passed list: " {

            Mock Get-Random { return $randomNumber }

        It "Returns the default name." {
            $result = Get-ResourceGroupNameJustDoIt -ProvidedParameters $testCases[2].ProvidedParameters -AppServicePlans $testCases[2].AppServicePlans
            $result | Should be $defaultName        
        }                
    }

    Context "[mock] When ParametersProvided hashset does not contain ResourceGroupName, 
            but it contains AppServicePlanName. Moreover, AppServicePlanName matches 
            an AppServicePlan from the passed list: " {

        It "Returns the name of the ResourceGroup from the AppServic." {
            $result = Get-ResourceGroupNameJustDoIt -ProvidedParameters $testCases[3].ProvidedParameters -AppServicePlans $testCases[3].AppServicePlans
            $result | Should be $testCases[3].AppServicePlans[1].ResourceGroup     
        }                
    }
}

$defaultLocation = "West Europe"
$testCases = @(
    @{ProvidedParameters=@{}},
    @{ProvidedParameters=@{Location="Custom Location"}}
)


Describe "Get-ResourceGroupLocationJustDoIt" {

    Context "[mock] When ParametersProvided hashset does not contain Location: " {
        It "Returns the default location." {
            $result = Get-ResourceGroupLocationJustDoIt -ProvidedParameters $testCases[0].ProvidedParameters 
            $result | Should be $defaultLocation           
        }                
    }

    Context "[mock] When ParametersProvided contains Location: " {
        It "Returns the specified location." {
            $result = Get-ResourceGroupLocationJustDoIt -ProvidedParameters $testCases[1].ProvidedParameters 
            $result | Should be $testCases[1].ProvidedParameters.Location        
        }                
    }
}

$defaultLocation = "West Europe"
$randomNumber = 1
$defaultName = "ResourceGroup$randomNumber"

$testCases = @(
    @{ProvidedParameters=@{};ResourceGroups=@();AppServicePlans=@()}, 
    @{ProvidedParameters=@{ResourceGroupName="CustomName"};ResourceGroups=@();AppServicePlans=@()}, 
    @{ProvidedParameters=@{ResourceGroupName="RG1"};ResourceGroups=@(@{ResourceGroupName="RG1";Location="Loc1"},@{ResourceGroupName="RG2";Location="Loc2"});AppServicePlans=@()}, 
    @{ProvidedParameters=@{AppServicePlanName="ASP2"};ResourceGroups=@(@{ResourceGroupName="RG1";Location="Loc1"});AppServicePlans=@(@{Name="ASP1";ResourceGroup="RG1"},@{Name="ASP2";ResourceGroup="RG1"})},
    @{ProvidedParameters=@{ResourceGroupName="CustomName"; Location="CustomLocation"};ResourceGroups=@();AppServicePlans=@()}, 
    @{ProvidedParameters=@{ResourceGroupName="RG1";Location="CustomLocation"};ResourceGroups=@(@{ResourceGroupName="RG1";Location="Loc1"},@{ResourceGroupName="RG2";Location="Loc2"});AppServicePlans=@()}
    
)
Describe "Get-ResourceGroupJustDoIt" {
    Context "When ParametersProvided hashset does not contain Location, and it does not contain ResourceGroupName, 
            and ResourceGroups array is empty, and AppServicePlans array is empty: "{

        Mock Get-Random { return $randomNumber} 
        Mock New-AzureRmResourceGroup { return @{ResourceGroupName=$ResourceGroupName; Location=$Location} }

        It "Returns a Resource Group with default values." {
            $result = Get-ResourceGroupJustDoIt -ProvidedParameters $testCases[0].ProvidedParameters `
                        -ResourceGroups $testCases[0].ResourceGroups `
                        -AppServicePlans $testCases[0].AppServicePlans 

            $result.ResourceGroupName | Should be $defaultName
            $result.Location | Should be $defaultLocation
                        
        }
    }

    Context "When ParametersProvided hashset does not contain Location, and it contains ResourceGroupName, 
            and ResourceGroups array is empty, and AppServicePlans array is empty: "{

        Mock New-AzureRmResourceGroup { return @{ResourceGroupName=$ResourceGroupName; Location=$Location} }

        It "Returns a Resource Group with the Name provided, but with default location." {
            $result = Get-ResourceGroupJustDoIt -ProvidedParameters $testCases[1].ProvidedParameters `
                        -ResourceGroups $testCases[1].ResourceGroups `
                        -AppServicePlans $testCases[1].AppServicePlans 

            $result.ResourceGroupName | Should be $testCases[1].ProvidedParameters.ResourceGroupName
            $result.Location | Should be $defaultLocation
                        
        }
    }

    Context "When ParametersProvided hashset does not contain Location, 
            but it contains a matching ResourceGroupName: "{

        Mock New-AzureRmResourceGroup { return @{ResourceGroupName=$ResourceGroupName; Location=$Location} }

        It "Returns the matching Resource Group with its original name and original location." {
            $result = Get-ResourceGroupJustDoIt -ProvidedParameters $testCases[2].ProvidedParameters `
                        -ResourceGroups $testCases[2].ResourceGroups `
                        -AppServicePlans $testCases[2].AppServicePlans 

            $result.ResourceGroupName | Should be $testCases[2].ResourceGroups[0].ResourceGroupName
            $result.Location | Should be $testCases[2].ResourceGroups[0].Location
                        
        }
    }

    Context "When ParametersProvided hashset does not contain Location, and it does not contain a 
            ResourceGroupName, but it contains a matching AppServicePlanName: "{

        Mock New-AzureRmResourceGroup { return @{ResourceGroupName=$ResourceGroupName; Location=$Location} }

        It "Returns the Resource Group of the matching AppServicePlan." {
            $result = Get-ResourceGroupJustDoIt -ProvidedParameters $testCases[3].ProvidedParameters `
                        -ResourceGroups $testCases[3].ResourceGroups `
                        -AppServicePlans $testCases[3].AppServicePlans 

            $result.ResourceGroupName | Should be $testCases[3].ResourceGroups[0].ResourceGroupName
            $result.Location | Should be $testCases[3].ResourceGroups[0].Location
        }
    }

    Context "When ParametersProvided hashset contains Location, and it contains ResourceGroupName, 
            but ResourceGroups array is empty, and AppServicePlans array is empty: "{

        Mock New-AzureRmResourceGroup { return @{ResourceGroupName=$ResourceGroupName; Location=$Location} }

        It "Returns a Resource Group with the name provided, and with location provided." {
            $result = Get-ResourceGroupJustDoIt -ProvidedParameters $testCases[4].ProvidedParameters `
                        -ResourceGroups $testCases[4].ResourceGroups `
                        -AppServicePlans $testCases[4].AppServicePlans 

            $result.ResourceGroupName | Should be $testCases[4].ProvidedParameters.ResourceGroupName
            $result.Location | Should be $testCases[4].ProvidedParameters.Location
                        
        }
    }

    Context "When ParametersProvided hashset contains Location, and it contains a matching ResourceGroupName, 
            but the location provided is different to the current location of the matching Resource Group: "{

        Mock New-AzureRmResourceGroup { return @{ResourceGroupName=$ResourceGroupName; Location=$Location} }

        It "Returns the matching Resource Group with its original name, and its original location." {
            $result = Get-ResourceGroupJustDoIt -ProvidedParameters $testCases[5].ProvidedParameters `
                        -ResourceGroups $testCases[5].ResourceGroups `
                        -AppServicePlans $testCases[5].AppServicePlans 

            $result.ResourceGroupName | Should be $testCases[5].ResourceGroups[0].ResourceGroupName
            $result.Location | Should be $testCases[5].ResourceGroups[0].Location
                        
        }
    }    
}

$randomNumber = 1
$defaultName = "AppServicePlan$randomNumber"

$testCases = @(
    @{ProvidedParameters=@{}},
    @{ProvidedParameters=@{AppServicePlanName="CustomASP"}}
)

Describe "Get-AppServicePlanNameJustDoIt" {

    Context "[mock] When ParametersProvided hashset does not contain AppServicePlanName: " {

        Mock Get-Random { return $randomNumber }

        It "Returns the default name." {
            $result = Get-AppServicePlanNameJustDoIt -ProvidedParameters $testCases[0].ProvidedParameters 
            $result | Should be $defaultName          
        }                
    }

    Context "[mock] When ParametersProvided hashset contains AppServicePlanName: " {

        Mock Get-Random { return $randomNumber }

        It "Returns the name specified." {
            $result = Get-AppServicePlanNameJustDoIt -ProvidedParameters $testCases[1].ProvidedParameters 
            $result | Should be $testCases[1].ProvidedParameters.AppServicePlanName         
        }                
    }
}

$testCases = @(
    @{ProvidedParameters=@{};ResourceGroup=@{Location="Loc1"}},
    @{ProvidedParameters=@{Location="Loc"};ResourceGroup=@{Location="Loc1"}}
)

Describe "Get-AppServicePlanLocationJustDoIt" {

    Context "[mock] When ParametersProvided hashset does not contain Location: " {

        It "Returns the location of the ResourceGroup passed." {
            $result = Get-AppServicePlanLocationJustDoIt -ProvidedParameters $testCases[0].ProvidedParameters -ResourceGroup $testCases[0].ResourceGroup
            $result | Should be $testCases[0].ResourceGroup.Location          
        }                
    }

    Context "[mock] When ParametersProvided hashset contains Location: " {

        It "Returns the location specified." {
            $result = Get-AppServicePlanLocationJustDoIt -ProvidedParameters $testCases[1].ProvidedParameters -ResourceGroup $testCases[1].ResourceGroup
            $result | Should be $testCases[1].ProvidedParameters.Location        
        }                
    }
}

$defaultTier = "Free"

$testCases = @(
    @{ProvidedParameters=@{}},
    @{ProvidedParameters=@{Tier="Basic"}}
)

Describe "Get-AppServicePlanTierJustDoIt" {

    Context "[mock] When ParametersProvided hashset does not contain Tier: " {

        It "Returns the default Tier." {
            $result = Get-AppServicePlanTierJustDoIt -ProvidedParameters $testCases[0].ProvidedParameters 
            $result | Should be $defaultTier          
        }                
    }

     Context "[mock] When ParametersProvided hashset does not contain Tier: " {

        It "Returns the default Tier." {
            $result = Get-AppServicePlanTierJustDoIt -ProvidedParameters $testCases[1].ProvidedParameters 
            $result | Should be $testCases[1].ProvidedParameters.Tier       
        }                
    }
}


$testCases = @(
    @{ProvidedParameters=@{}; AppServicePlans=@(); ResourceGroup=@{ResourceGroupName="RG1"; Location="Loc1"}},
    @{ProvidedParameters=@{Location="Loc2"}; AppServicePlans=@(); ResourceGroup=@{ResourceGroupName="RG3"; Location="Loc3"}},
    @{ProvidedParameters=@{Location="Loc3"; AppServicePlanName="ASPCustom"}; AppServicePlans=@(@{Name="ASP1"; Location="Loc1"; ResourceGroup="RG4"}); ResourceGroup=@{ResourceGroupName="RG4"; Location="Loc4"}},
    @{ProvidedParameters=@{Location="Loc4"; AppServicePlanName="ASP5"}; AppServicePlans=@(@{Name="ASP5"; Location="Loc5"; ResourceGroup="RG5";Tier="Basic"}); ResourceGroup=@{ResourceGroupName="RG5"; Location="Loc6"}}
)

$randomNumber = 1
$defaultName = "AppServicePlan$randomNumber"
$defaultTier = "Free"

Describe "Get-AppServicePlanJustDoIt" {

    Context "[mock] When ParametersProvided hashset does not contain any elements: " {

        Mock Get-Random { return $randomNumber }
        Mock New-AzureRmAppServicePlan { return @{Name=$Name; Tier=$Tier; Location=$Location;ResourceGroupName=$ResourceGroupName} }

        It "Returns an AppServicePlan with the same location as the passed ResourceGroup,
           , with a default name, default Tier and the same ResourceGroup passed ." {
            $result = Get-AppServicePlanJustDoIt -ProvidedParameters $testCases[0].ProvidedParameters -AppServicePlans $testCases[0].AppServicePlans -ResourceGroup $testCases[0].ResourceGroup
            $result.Name | Should be $defaultName
            $result.Tier | Should be $defaultTier     
            $result.Location |  Should be $testCases[0].ResourceGroup.Location
            $result.ResourceGroupName | Should be $testCases[0].ResourceGroup.ResourceGroupName    
        }                
    }

    Context "[mock] When ParametersProvided hashset just contains Location for WebApp: " {

        Mock Get-Random { return $randomNumber }
        Mock New-AzureRmAppServicePlan { return @{Name=$Name; Tier=$Tier; Location=$Location;ResourceGroup=$ResourceGroupName} }

        It "Returns an AppServicePlan with the same location as the passed Location for the WebApp,
           but with a default name, default Tier, and the same ResourceGroup passed." {
            $result = Get-AppServicePlanJustDoIt -ProvidedParameters $testCases[1].ProvidedParameters -AppServicePlans $testCases[1].AppServicePlans -ResourceGroup $testCases[1].ResourceGroup
            $result.Name | Should be $defaultName
            $result.Tier | Should be $defaultTier     
            $result.Location |  Should be $testCases[1].ProvidedParameters.Location
            $result.ResourceGroup | Should be $testCases[1].ResourceGroup.ResourceGroupName    
        }                
    }

    Context "[mock] When ParametersProvided hashset contains Location for WebApp, 
            and an AppServicePlanName that does not exist: " {

        Mock Get-Random { return $randomNumber }
        Mock New-AzureRmAppServicePlan { return @{Name=$Name; Tier=$Tier; Location=$Location;ResourceGroup=$ResourceGroupName} }

        It "Returns an AppServicePlan with the same location as the passed Location for the WebApp,
           with the AppServicePlanName specified, default Tier, and the same ResourceGroup passed." {
            $result = Get-AppServicePlanJustDoIt -ProvidedParameters $testCases[2].ProvidedParameters -AppServicePlans $testCases[2].AppServicePlans -ResourceGroup $testCases[2].ResourceGroup
            $result.Name | Should be $testCases[2].ProvidedParameters.AppServicePlanName
            $result.Tier | Should be $defaultTier     
            $result.Location |  Should be $testCases[2].ProvidedParameters.Location
            $result.ResourceGroup | Should be $testCases[2].ResourceGroup.ResourceGroupName    
        }                
    }

    Context "[mock] When ParametersProvided hashset contains Location for WebApp, 
            and an AppServicePlanName that already exists: " {

        Mock Get-Random { return $randomNumber }
        Mock New-AzureRmAppServicePlan { return @{Name=$Name; Tier=$Tier; Location=$Location;ResourceGroup=$ResourceGroupName} }

        It "Returns the same AppServicePlan that matches the name passed." {
            $result = Get-AppServicePlanJustDoIt -ProvidedParameters $testCases[3].ProvidedParameters -AppServicePlans $testCases[3].AppServicePlans -ResourceGroup $testCases[3].ResourceGroup
            $result.Name | Should be $testCases[3].AppServicePlans[0].Name
            $result.Tier | Should be $testCases[3].AppServicePlans[0].Tier    
            $result.Location |  Should be $testCases[3].AppServicePlans[0].Location
            $result.ResourceGroup | Should be $testCases[3].AppServicePlans[0].ResourceGroup   
        }                
    }
}

$errorMessage = "WebApp could not be created."

<#
$testCases = @(
                @{Name="AppServicePlan1";Location="West Europe";ResourceGroup="mockResourceGroup1";Tier="Free"}
)

#>

<#
Describe "Get-AppServiceJustDoIt" {

    Context "[mock] When 'parameters provided' hashset is empty: "{
        
        Mock Get-Random { return 1 }
        Mock New-AzureRmAppServicePlan{
            return @{Name=$Name;Location=$Location;ResourceGroup=$ResourceGroupName;Tier=$Tier}
         }            

        It "Returns an App Service Plan with default values." {
            $result = Get-AppServicePlanJustDoIt -ProvidedParameters @{} -ResourceGroupName $testCases[0].ResourceGroup
            $result.Name | Should be $testCases[0].Name
            $result.Location | Should be $testCases[0].Location
            $result.ResourceGroup | Should be $testCases[0].ResourceGroup
            $result.Tier | Should be $testCases[0].Tier
        }
    }
    
}
#>

<#
Describe "New-AzureRmWebAppJustDoIt" {
    
    Context "[live test] When an invalid Webapp location is provided: "{

        It "Throws an error: " {
            { New-AzureRmWebAppJustDoIt -WebAppLocation random} | Should Throw $errorMessage
        }        
    }

    Context "[live test] When an invalid App Service Plan location is provided: "{

        It "Throws an error: " {
            { New-AzureRmWebAppJustDoIt -AppServicePlanLocation random} | Should Throw $errorMessage
        }        
    }

    Context "[live test] When an invalid Resource Group location is provided: "{

        It "Throws an error: " {
            { New-AzureRmWebAppJustDoIt -ResourceGroupLocation random} | Should Throw $errorMessage
        }        
    }

    Context "[live test] When an invalid Tier for App Service Plan is provided: "{

        It "Throws an error: " {
            { New-AzureRmWebAppJustDoIt -Tier random} | Should Throw $errorMessage
        }        
    }     
        
}

#>