function Get-ResourceGroupJustDoIt{
    Param(
        [Parameter(Mandatory=$false)]
        [hashtable]$ProvidedParameters     
    )
    $resourceGroupName = ""
    $resourceGroupLocation = ""

    if(-Not $ProvidedParameters.ContainsKey('ResourceGroupName')){
            $resourceGroupName = "ResourceGroup$(Get-Random)"            
    } else {
        $resourceGroupName = $ProvidedParameters.ResourceGroupName
    }

    if(-Not $ProvidedParameters.ContainsKey('ResourceGroupLocation')){
            $resourceGroupLocation = "West Europe"
            # TODO: Implement a 'smarter' way to choose a location.
            # For this experiment a random location where web
            # services is available was chosen.
    } else {
        $resourceGroupLocation = $ProvidedParameters.ResourceGroupLocation
    }

    $resourceGroupMatch = Get-AzureRmResourceGroup | Where-Object {$_.ResourceGroupName -eq $resourceGroupName}

    if($resourceGroupMatch){
        if($resourceGroupMatch.Location -eq $resourceGroupLocation){
            return $resourceGroupMatch
        }    
    }
    return New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
    
}

function Get-AppServicePlanJustDoIt{
    Param(
        [Parameter(Mandatory=$false)]
        [hashtable ]$ProvidedParameters, 
        [Parameter(Mandatory=$true)]
        [string]$ResourceGroupName     
    )
    $appServicePlanName = ""
    $appServicePlanLocation = ""

    if(-Not $ProvidedParameters.ContainsKey('AppServicePlanName')){
            $appServicePlanName = "AppServicePlan$(Get-Random)"
    } else {
        $appServicePlanName = $ProvidedParameters.AppServicePlanName
    }

    if(-Not $ProvidedParameters.ContainsKey('AppServicePlanLocation')){
            $appServicePlanLocation = "West Europe"
            # TODO: Implement a 'smarter' way to choose a location.
            # For this experiment a random location where web
            # services is available was chosen.
    } else {
        $appServicePlanLocation = $ProvidedParameters.AppServicePlanLocation
    }

    if(-Not $ProvidedParameters.ContainsKey('Tier')){
            $tier = "Free"
    } else {
        $tier = $ProvidedParameters.Tier
    }

    $appServicePlanMatch = Get-AzureRmAppServicePlan | Where-Object {$_.Name -eq $appServicePlanName}

    if($appServicePlanMatch){
        if($appServicePlanMatch.Location -eq $appServicePlanLocation){
            return $appServicePlanMatch
        }    
    }
    return New-AzureRmAppServicePlan -Name $appServicePlanName -Location $appServicePlanLocation `
    -ResourceGroupName $ResourceGroupName -Tier $tier
}

function New-AzureRmWebAppJustDoIt{
    [CmdletBinding(
        SupportsShouldProcess=$true
    )]
    Param(
        [Parameter(Mandatory=$false)]
        [string]$WebAppName,
        [Parameter(Mandatory=$false)]
        [string]$WebAppLocation,
        [Parameter(Mandatory=$false)]
        [string]$ResourceGroupName, 
        [Parameter(Mandatory=$false)]
        [string]$ResourceGroupLocation,
        [Parameter(Mandatory=$false)]
        [string]$AppServicePlanName,        
        [Parameter(Mandatory=$false)]
        [string]$AppServicePlanLocation, 
        [Parameter(Mandatory=$false)]
        [string]$Tier="Free",       
        [Parameter(Mandatory=$false)]
        [string]$GitRepositoryPath
    )
    PROCESS {
        # This setting will cause all errors to be treated as terminating errors.
        # This means that try/catches will be triggered in all classes (e.g. git errors)
        $ErrorActionPreference = 'Stop'

        # validate parameters        
        # NOTE: $PSBoundParameters automatic variable is used to detect passed parameters.

        if(-Not $PSBoundParameters.ContainsKey('WebAppName')){
            $WebAppName ="WebApp$(Get-Random)"
        }

        if(-Not $PSBoundParameters.ContainsKey('WebAppLocation')){
            $WebAppLocation="West Europe"
            # TODO: Implement a 'smarter' way to choose a location.
            # For this experiment a random location where web
            # services is available was chosen.
        }  

        # By default the current path where the script is run will
        # be used for web app code deployement.
        if(-Not $PSBoundParameters.ContainsKey('GitRepositoryPath')){
            $GitRepositoryPath = (Get-Location).Path 
        }
        
        try
        {            
            # Create a resource group.
            $resourceGroup = Get-ResourceGroupJustDoIt -ProvidedParameters $PSBoundParameters

            # Create an App Service plan in "Free" tier.
            $appServicePlan = Get-AppServicePlanJustDoIt -ProvidedParameters $PSBoundParameters -ResourceGroupName $resourceGroup.ResourceGroupName

            # Create a web app.
            $webApp = New-AzureRmWebApp -Name $WebAppName -Location $WebAppLocation -AppServicePlan $appServicePlan.Name `
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

        # Deploy web app code in a local Git repository.
        try
        {
            git -C $GitRepositoryPath status | Out-Null
        }
        catch
        {
            Write-Host "Web app code could not be deployed. The current path or path provided does not contain a local Git Repository."
            Write-Output $webApp
            return
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
            Write-Host "Git repository could not be added to remote 'azure'."
            write-Output $webApp
            return 
        }

        Write-Host "Git repository detected, added remote 'azure'. " 

        Write-Output $webApp                  
    }
}    