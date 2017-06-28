<#
    .SYNOPSIS
    Experimental Azure PowerShell cmdlet to create a web app and deploy code from a local Git repository.

    .DESCRIPTION
    This Experimental Azure PowerShell cmdlet creates a web app with its related resources, and deploys the 
    web app code in a local Git Repository without any required parameters. All the necesary information 
    will be chosen intellently by Azure PowerShell. 

    .PARAMETER WebAppName

    Specifies a name for the webapp.

    .PARAMETER WebAppLocation

    Specifies a location for the webapp. By default, it will take a location where web services is available.

    .PARAMETER ResourceGroupName

    Specifies a name for the Resource Group. By default, it will be the same as the webapp name.

    .PARAMETER ResourceGroupLocation

    Specifies a location for the Resource Group. By default, it will be the same as the webapp location.

    .PARAMETER AppServicePlanName

    Specifies a name for the App Service Plan.By default, it will be the same as the webapp name.

    .PARAMETER AppServicePlanLocation

    Specifies a location for the App Service Plan. By default, it will be the same as the webapp location.

    .PARAMETER Tier

    Specifies a Tier for the App Service Plan. By default, it will be "free".

    .PARAMETER GitRepositoryPath

    Specifies the path for the local Git repository. By default, it will be the current path.

    .EXAMPLE

    C:\PS> New-AzureRmWebAppExperimental

    .INPUTS

    None. You cannot pipe objects to New-AzureRmWebAppExperimental.

    .OUTPUTS

    Microsoft.Azure.Management.WebSites.Models.Site. New-AzureRmWebAppExperimental returns a site with 
    information about the site that was created.

#>

# NOTE: The functionality of this script was based on 
#      the sample "Create a web app and deploy code from a local Git repository"
#      from https://docs.microsoft.com/en-us/azure/app-service-web/scripts/app-service-powershell-deploy-local-git

function New-AzureRmWebAppExperimental{
    [CmdletBinding(
        SupportsShouldProcess=$true
    )]
    Param(
        [Parameter(Mandatory=$false)]
        [string]$WebAppName="mywebapp$(Get-Random)",
        [Parameter(Mandatory=$false)]
        [alias("Location")]
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

        if(-Not $PSBoundParameters.ContainsKey('WebAppLocation')){
            $WebAppLocation="West Europe"
            # TODO: Implement a 'smarter' way to choose a location.
            # For this experiment a random location where web
            # services is available was chosen.
        }  
        # By default, resource-group and app-service-plan location and 
        # names will be the same as the webapp.
        if(-Not $PSBoundParameters.ContainsKey('ResourceGroupName')){
            $ResourceGroupName = $WebAppName
        }

        if(-Not $PSBoundParameters.ContainsKey('ResourceGroupLocation')){
            $ResourceGroupLocation = $WebAppLocation
        }

        if(-Not $PSBoundParameters.ContainsKey('AppServicePlanName')){
            $AppServicePlanName = $WebAppName
        }

        if(-Not $PSBoundParameters.ContainsKey('AppServicePlanLocation')){
            $AppServicePlanLocation = $WebAppLocation
        }

        # By default the current path where the script is run will
        # be used for web app code deployement.
        if(-Not $PSBoundParameters.ContainsKey('GitRepositoryPath')){
            $GitRepositoryPath = (Get-Location).Path 
        }
        
        try
        {            
            # Create a resource group.
            New-AzureRmResourceGroup -Name $ResourceGroupName -Location $ResourceGroupLocation | Out-Null

            # Create an App Service plan in "Free" tier.
            New-AzureRmAppServicePlan -Name $AppServicePlanName -Location $AppServicePlanLocation `
            -ResourceGroupName $ResourceGroupName -Tier $Tier | Out-Null

            # Create a web app.
            $webApp = New-AzureRmWebApp -Name $WebAppName -Location $WebAppLocation -AppServicePlan $AppServicePlanName `
            -ResourceGroupName $ResourceGroupName
        }
        catch
        {
            $message ="WebApp could not be created. Check: 1) You are logged into an Azure account. 2) Optional parameters are correct (eg. Location is valid). "+
                      "3) The maximum number of ServerFarms for your subscription has not been reached. 4) A valid App Service Plan Tier was provided."
            $exception = New-Object -TypeName System.Exception -ArgumentList $message, $_.Exception
            throw $exception           
        }
        # Extract info from site object returned
        $name = $WebApp.SiteName
        $parsedServerFarmId = $webApp.ServerFarmId.split('/')
        $plan = $parsedServerFarmId[$parsedServerFarmId.Count - 1]
        $resourceGroup = $webApp.ResourceGroup
       

        Write-Host "Webapp creation successful."
        Write-Host "Name: $name."
        Write-Host "Plan: $plan."
        Write-Host "Resource Group: $resourceGroup."

        # Deploy web app code in a local Git repository.
        try
        {
            git status | Out-Null
        }
        catch
        {
            Write-Host "Web app code could not be deployed. The current path does not contain a local Git Repository."
            return $webApp
        }
        
        # Get app-level deployment credentials
        $xml = [xml](Get-AzureRmWebAppPublishingProfile -Name $webappname -ResourceGroupName $ResourceGroupName `
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
            return $WebApp
        }

        Write-Host "Git repository detected, added remote 'azure'. " 

        return $webApp                  
    }
}


