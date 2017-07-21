
function Get-ResourceGroupLocationJustDoIt{
    Param(
        [Parameter(Mandatory=$true)]
        [hashtable]$ProvidedParameters
    )
    $resourceGroupLocation = ""
    $defaultLocation = "West Europe"
    
    if($ProvidedParameters.ContainsKey('Location')){
        $resourceGroupLocation = $ProvidedParameters.Location
    } else { 
        $resourceGroupLocation = $defaultLocation;
    }

    return $resourceGroupLocation
}

function Get-ResourceGroupNameJustDoIt{
    Param(
        [Parameter(Mandatory=$true)]
        [hashtable]$ProvidedParameters,
        [Parameter(Mandatory=$false)]
        [object[]]$AppServicePlans
    )
    $resourceGroupName = ""
    $defaultName= "ResourceGroup$(Get-Random)"     

    if($ProvidedParameters.ContainsKey('ResourceGroupName')){
        $resourceGroupName = $ProvidedParameters.ResourceGroupName
    } elseif($ProvidedParameters.ContainsKey('AppServicePlanName')) {
        $appServicePlanName = $ProvidedParameters.AppServicePlanName
        $appServicePlanMatch = $AppServicePlans | Where-Object {$_.Name -eq $appServicePlanName}
        if($appServicePlanMatch){
            $resourceGroupName = $appServicePlanMatch.ResourceGroup
        } else {
            $resourceGroupName = $defaultName
        }
    } else {
         $resourceGroupName = $defaultName
    }

    return $resourceGroupName
}

function Get-ResourceGroupJustDoIt{
    Param(
        [Parameter(Mandatory=$true)]
        [hashtable]$ProvidedParameters,
        [Parameter(Mandatory=$false)]
        [object[]]$ResourceGroups,
        [Parameter(Mandatory=$false)]
        [object[]]$AppServicePlans
    )
    $resourceGroupLocation = ""
    $resourceGroupName = ""
     
    $resourceGroupName = Get-ResourceGroupNameJustDoIt -ProvidedParameters $ProvidedParameters `
                         -AppServicePlans $AppServicePlans
    $resourceGroupMatch = $ResourceGroups | Where-Object {$_.ResourceGroupName -eq $resourceGroupName}
    if($resourceGroupMatch){            
        return $resourceGroupMatch
    }
    $resourceGroupLocation = Get-ResourceGroupLocationJustDoIt -ProvidedParameters $ProvidedParameters 
    return New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation     
    
}
       
function Get-AppServicePlanNameJustDoIt{
    Param(
        [Parameter(Mandatory=$true)]
        [hashtable]$ProvidedParameters
    )
    $appServicePlanName = ""
    $defaultName= "AppServicePlan$(Get-Random)"     

    if($ProvidedParameters.ContainsKey('AppServicePlanName')){
        $appServicePlanName = $ProvidedParameters.AppServicePlanName
    } else {
        $appServicePlanName = $defaultName
    }

    return $appServicePlanName
}

function Get-AppServicePlanLocationJustDoIt{
    Param(
        [Parameter(Mandatory=$true)]
        [hashtable]$ProvidedParameters,
        [Parameter(Mandatory=$true)]
        [object]$ResourceGroup  
    )
    $appServicePlanLocation = ""

    if($ProvidedParameters.ContainsKey('Location')){
        $appServicePlanLocation = $ProvidedParameters.Location
    } else { 
        $appServicePlanLocation = $ResourceGroup.Location;
    }

    return $appServicePlanLocation
}

function Get-AppServicePlanTierJustDoIt{
    Param(
        [Parameter(Mandatory=$true)]
        [hashtable]$ProvidedParameters
    )
    $appServicePlanTier = ""
    $defaultTier= "Free"     

    if($ProvidedParameters.ContainsKey('Tier')){
        $appServicePlanTier = $ProvidedParameters.Tier
    } else {
        $appServicePlanTier = $defaultTier
    }

    return $appServicePlanName
}

function Get-AppServicePlanJustDoIt{
    Param(
        [Parameter(Mandatory=$true)]
        [hashtable ]$ProvidedParameters,
        [Parameter(Mandatory=$true)]
        [object[]]$AppServicePlans,
        [Parameter(Mandatory=$true)]
        [object]$ResourceGroup   
    )
    $appServicePlanName = ""
    $appServicePlanLocation = ""
    $tier = ""
    
    $appServicePlanName = Get-AppServicePlanNameJustDoIt -ProvidedParameters $ProvidedParameters 
    $appServicePlanMatch = $AppServicePlans | Where-Object {$_.Name -eq $appServicePlanName}
    if($appServicePlanMatch){            
        return $appServicePlanMatch
    }
    $appServicePlanLocation = Get-AppServicePlanLocationJustDoIt -ProvidedParameters $ProvidedParameters `
                                -ResourceGroup $ResourceGroup
    $tier = Get-AppServicePlanTierJustDoIt -ProvidedParameters $ProvidedParameter
   
    return New-AzureRmAppServicePlan -Name $appServicePlanName -Location $appServicePlanLocation `
    -ResourceGroupName $ResourceGroup.ResourceGrouName -Tier $tier 
}

function New-AzureRmWebAppJustDoIt{
    [CmdletBinding(
        SupportsShouldProcess=$true
    )]
    Param(
        [Parameter(Mandatory=$false)]
        [Alias("Name")]
        [string]$WebAppName,
        [Parameter(Mandatory=$false)]
        [string]$Location,
        [Parameter(Mandatory=$false)]
        [string]$ResourceGroupName, 
        [Parameter(Mandatory=$false)]
        [string]$AppServicePlanName,  
        [Parameter(Mandatory=$false)]
        [string]$GitRepositoryPath
    )
    PROCESS {
        # This setting will cause all errors to be treated as terminating errors.
        # This means that try/catches will be triggered in all classes (e.g. git errors)
        $ErrorActionPreference = 'Stop'
               
        # NOTE: $PSBoundParameters automatic variable is used to detect passed parameters.      
        
        try
        {
            # Get currently available resource groups and app service plans.
            $resourceGroups = Get-AzureRmResourceGroup
            $appServicePlans = Get-AzureRmAppServicePlan
                        
            # Get a resource group.
            $resourceGroup = Get-ResourceGroupJustDoIt -ProvidedParameters $PSBoundParameters `
                            -ResourceGroups $resourceGroups -AppServicePlans $appServicePlans

            # Get an App Service Plan.
            $appServicePlan = Get-AppServicePlanJustDoIt -ProvidedParameters $PSBoundParameters `
                                -ResourceGroup $resourceGroup

            # Get Name for Web App if not specified.           
            if(-Not $PSBoundParameters.ContainsKey('WebAppName')){
                $WebAppName ="WebApp$(Get-Random)"
            }
            
            # Get Location for Web App if not specified.
            if(-Not $PSBoundParameters.ContainsKey('Location')){
                $Location = $appServicePlan.Location
            }
            
            # Create a web app.
            $webApp = New-AzureRmWebApp -Name $WebAppName -Location $Location -AppServicePlan $appServicePlan.Name `
            -ResourceGroupName $resourceGroup.ResourceGroupName
        }
        catch
        {
            $message ="WebApp could not be created. Check: 1) You are logged into an Azure account. 2) Optional parameters are correct (eg. Location is valid). "+
                      "3) The maximum number of ServerFarms for your subscription has not been reached. 4) A valid App Service Plan Tier was provided."
            $exception = New-Object -TypeName System.Exception -ArgumentList $message, $_.Exception
            throw $exception           
        }  

        Write-Host "Webapp creation successful."  
        Write-Output $webApp     

        ### Deploy web app code in a local Git repository.

        # By default the current path where the script is run will
        # be used for web app code deployement.
        if(-Not $PSBoundParameters.ContainsKey('GitRepositoryPath')){
            $GitRepositoryPath = (Get-Location).Path 
        }

        try
        {
            git -C $GitRepositoryPath status | Out-Null
        }
        catch
        {          
            $message ="Web app code could not be deployed. The current path or path provided does not contain a local Git Repository."
            $exception = New-Object -TypeName System.Exception -ArgumentList $message, $_.Exception      
            throw $exception
        }
        
        # Get app-level deployment credentials
        $xml = [xml](Get-AzureRmWebAppPublishingProfile -Name $webappname -ResourceGroupName $ResourceGroup.ResourceGroupName `
        -OutputFile null)
        $username = $xml.SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@userName").value
        $password = $xml.SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@userPWD").value

        # Add the Azure remote to a local Git respository and push code        
        try
        {
            git -C $GitRepositoryPath remote add azure "https://${username}:$password@$webappname.scm.azurewebsites.net"  
        }
        catch
        {
            $message ="Git repository could not be added to remote 'azure'."
            $exception = New-Object -TypeName System.Exception -ArgumentList $message, $_.Exception      
            throw $exception
        }

        Write-Host "Git repository detected, added remote 'azure'. "                  
    }
}    