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

function New-AzWebAppJustDoIt
{
    [CmdletBinding()]
    [OutputType([Microsoft.Azure.Management.WebSites.Models.Site])]
    param(
    [string][Parameter(Mandatory=$false)][alias("Name")]$WebAppName,
    [string][Parameter(Mandatory=$false)][alias("Group")]$ResourceGroupName,
    [string][Parameter(Mandatory=$false)][alias("Plan")]$AppServicePlan
    )
    DynamicParam{
        #Set the dynamic parameters' name
        $ParamName_location = 'Location'
        # Create the collection of attributes
        $AttributeCollection = New-Object  System.Collections.ObjectModel.Collection[System.Attribute]
        # Create and set the parameters' attributes
        $ParameterAttribute = New-Object  System.Management.Automation.ParameterAttribute
        $ParameterAttribute.Mandatory = $false
        # Add the attributes to the attributes collection        
        $AttributeCollection.Add($ParameterAttribute) 
        # Create the dictionary
        $RuntimeParameterDictionary = New-Object  System.Management.Automation.RuntimeDefinedParameterDictionary
        #Generate and set the ValidateSet
        $providerNamespace = "Microsoft.Web"
        try
        {
            $availableLocations = $(Get-AzureRmResourceProvider | Where-Object {$_.ProviderNamespace -eq $providerNamespace}).Locations   
        }
        catch
        {
            throw $_        
        }     
        $ValidateSetAttribute = New-Object System.Management.Automation.ValidateSetAttribute($availableLocations)
        # Add the ValidateSet to the attributes collection
        $AttributeCollection.Add($ValidateSetAttribute)
        # Create and return the dynamic parameter
        $RuntimeParameter = New-Object  System.Management.Automation.RuntimeDefinedParameter($ParamName_location, [string],  $AttributeCollection)        
        $RuntimeParameterDictionary.Add($ParamName_location, $RuntimeParameter)  

        return $RuntimeParameterDictionary
    }

    BEGIN {         
        $context = Get-Context
        $webSitesClient = Get-WebSitesClient $context
        $resourceManagementClient = Get-ResourceManagementClient $context
    }

    PROCESS {
        $mainActivity = "Create Azure Web App" 
        [string]$Location = $PSBoundParameters[$ParamName_location]
        Write-Progress `
            -Activity "Some Activity." `
            -CurrentOperation "Getting App Name information."   
        [string]$appName = Get-WebAppName $PSBoundParameters $webSitesClient
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting Resource Group information."  
        $operationNumber = 2 
        [hashtable]$groupInfo = Get-ResourceGroupInfo $PSBoundParameters $appName $resourceManagementClient
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting App Service Plan information." 
        $operationNumber = 3   
        [hashtable]$appPlanInfo = Get-AppServicePlanInfo $PSBoundParameters $appName $groupInfo.Name        
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting App Location information."  
        $operationNumber++   
        [string]$appLocation = Get-AppLocation $PSBoundParameters $groupInfo.Name $groupInfo.Exists $availableLocations
        if ($groupInfo.Exists) {          
            $appGroup = Get-AzureRmResourceGroup `
                            -Name $groupInfo.Name 
            $message = "Using resource group '$($appGroup.ResourceGroupName)' in location '$($appGroup.Location)'."    
            Write-Information -MessageData $message -InformationAction Continue            
        } else {           
            $appGroup =  New-AzureRmResourceGroup `
                            -Name $groupInfo.Name `
                            -Location $appLocation 
            $message = "Created resource group '$($appGroup.ResourceGroupName)' in location '$($appGroup.Location)'."
            Write-Information -MessageData $message -InformationAction Continue   
        }

        $operationNumber = 4 
        if ($appPlanInfo.Exists) {            
            $appPlan = Get-AzureRmAppServicePlan `
                        -Name $appPlanInfo.Name `
                        -ResourceGroupName $appPlanInfo.ResourceGroup
            $message = "Using app service plan '$($appPlan.Name)' in location '$($appPlan.Location)'." 
            Write-Information -MessageData $message -InformationAction Continue       
        } else {           
            $defaultTier = "Free"
            $appPlan = New-AzureRmAppServicePlan `
                        -Name $appPlanInfo.Name `
                        -Location $appLocation `
                        -Tier $defaultTier `
                        -ResourceGroupName $appPlanInfo.ResourceGroup
            $message = "Created app service plan '$($appPlan.Name)' in location '$($appPlan.Location)' with Tier '$($appPlan.Sku.Tier)'." 
            Write-Information -MessageData $message -InformationAction Continue        
        } 
          
        $webapp =  New-AzureRmWebApp `
                    -Name $appName `
                    -AppServicePlan $appPlan.Id `
                    -ResourceGroupName $appGroup.ResourceGroupName `
                    -Location $appLocation   
         
        Write-Output $webapp            
    }

    END {}
}

function New-AzWebApp
{
    [CmdletBinding()]
    [OutputType([Microsoft.Azure.Management.WebSites.Models.Site])]
    param(
    [string][Parameter(Mandatory=$false)][alias("Name")]$WebAppName,
    [string][Parameter(Mandatory=$false)][alias("Group")]$ResourceGroupName,
    [string][Parameter(Mandatory=$false)][alias("Plan")]$AppServicePlan,
    [switch][Parameter(Mandatory=$false)]$Auto,
    [switch][Parameter(Mandatory=$false)]$AddRemote,
    [string][Parameter(Mandatory=$false)]$GitRepositoryPath
    )
    DynamicParam{
        #Set the dynamic parameters' name
        $ParamName_location = 'Location'
        # Create the collection of attributes
        $AttributeCollection = New-Object  System.Collections.ObjectModel.Collection[System.Attribute]
        # Create and set the parameters' attributes
        $ParameterAttribute = New-Object  System.Management.Automation.ParameterAttribute
        $ParameterAttribute.Mandatory = $false
        # Add the attributes to the attributes collection        
        $AttributeCollection.Add($ParameterAttribute) 
        # Create the dictionary
        $RuntimeParameterDictionary = New-Object  System.Management.Automation.RuntimeDefinedParameterDictionary
        #Generate and set the ValidateSet
        $providerNamespace = "Microsoft.Web"
        try
        {
            $availableLocations = $(Get-AzureRmResourceProvider | Where-Object {$_.ProviderNamespace -eq $providerNamespace}).Locations   
        }
        catch
        {
            throw $_        
        }     
        $ValidateSetAttribute = New-Object System.Management.Automation.ValidateSetAttribute($availableLocations)
        # Add the ValidateSet to the attributes collection
        $AttributeCollection.Add($ValidateSetAttribute)
        # Create and return the dynamic parameter
        $RuntimeParameter = New-Object  System.Management.Automation.RuntimeDefinedParameter($ParamName_location, [string],  $AttributeCollection)        
        $RuntimeParameterDictionary.Add($ParamName_location, $RuntimeParameter)  

        return $RuntimeParameterDictionary
    }

    BEGIN {         
        $context = Get-Context
        $webSitesClient = Get-WebSitesClient $context
        $resourceManagementClient = Get-ResourceManagementClient $context
    }

    PROCESS {
        #Validate Parameters 
        if (-not $PSBoundParameters.ContainsKey('Auto')) {
            $parametersNotProvided = @()
            if(-not $PSBoundParameters.ContainsKey('WebAppName')){
                $parametersNotProvided += 'WebAppName'
            }

            if(-not $PSBoundParameters.ContainsKey('ResourceGroupName')){
                $parametersNotProvided += 'ResourceGroupName'
            }

            if(-not $PSBoundParameters.ContainsKey('AppServicePlan')){
                $parametersNotProvided += 'AppServicePlan'
            }

            if(-not $PSBoundParameters.ContainsKey('Location')){
                $parametersNotProvided += 'Location'
            }		
               
            $message = "The following parameters were not provided: " 
            $message +=  $($parametersNotProvided -join ',') + " ."
            $message += "You can provide -Auto switch to use Smart Defaults."
            $exception = New-Object -TypeName System.Exception -ArgumentList $message
            throw $exception                   
        }

        $mainActivity = "Create Azure Web App" 
        [string]$Location = $PSBoundParameters[$ParamName_location]
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting App Name information."   
        [string]$appName = Get-WebAppName `
                            -ProvidedParameters $PSBoundParameters `
                            -WebSitesClient $webSitesClient
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting Resource Group information."  
        [hashtable]$groupInfo = Get-ResourceGroupInfo `
                                    -ProvidedParameters $PSBoundParameters `
                                    -WebAppName $appName `
                                    -ResourceManagementClient $resourceManagementClient
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting App Service Plan information."  
        [hashtable]$appPlanInfo = Get-AppServicePlanInfo `
                                    -ProvidedParameters $PSBoundParameters `
                                    -WebAppName $appName `
                                    -ResourceGroupName $groupInfo.Name        
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting App Location information."  
        [string]$appLocation = Get-AppLocation `
                                -ProvidedParameters $PSBoundParameters `
                                -ResourceGroupName $groupInfo.Name`
                                -ResourceGroupExists $groupInfo.Exists `
                                -AvailableLocations $availableLocations            
        if ($groupInfo.Exists) {          
            $appGroup = Get-AzureRmResourceGroup `
                            -Name $groupInfo.Name 
            $message = "Using resource group '$($appGroup.ResourceGroupName)' in location '$($appGroup.Location)'."    
            Write-Information -MessageData $message -InformationAction Continue            
        } else {           
            $appGroup =  New-AzureRmResourceGroup `
                            -Name $groupInfo.Name `
                            -Location $appLocation 
            $message = "Created resource group '$($appGroup.ResourceGroupName)' in location '$($appGroup.Location)'."
            Write-Information -MessageData $message -InformationAction Continue   
        }

        if ($appPlanInfo.Exists) {            
            $appPlan = Get-AzureRmAppServicePlan `
                        -Name $appPlanInfo.Name `
                        -ResourceGroupName $appPlanInfo.ResourceGroup
            $message = "Using app service plan '$($appPlan.Name)' in location '$($appPlan.Location)' with Tier '$($appPlan.Sku.Tier)'." 
            Write-Information -MessageData $message -InformationAction Continue       
        } else {           
            $defaultTier = "Free"
            $appPlan = New-AzureRmAppServicePlan `
                        -Name $appPlanInfo.Name `
                        -Location $appLocation `
                        -Tier $defaultTier `
                        -ResourceGroupName $appPlanInfo.ResourceGroup
            $message = "Created app service plan '$($appPlan.Name)' in location '$($appPlan.Location)' with Tier '$($appPlan.Sku.Tier)'." 
            Write-Information -MessageData $message -InformationAction Continue        
        } 
          
        $webapp =  New-AzureRmWebApp `
                    -Name $appName `
                    -AppServicePlan $appPlan.Id `
                    -ResourceGroupName $appGroup.ResourceGroupName `
                    -Location $appLocation   
         
        Write-Output $webapp
        
        if (($PSBoundParameters.ContainsKey('AddRemote') -or $PSBoundParameters.ContainsKey('Auto')) -and $webapp) { 
            Add-Remote -ProvidedParameters $PSBoundParameters -WebApp $webapp -GitRepositoryPath $GitRepositoryPath                   
        }            
    }

    END {}
}

function Add-Remote 
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [Microsoft.Azure.Management.WebSites.Models.Site][Parameter()]$WebApp,
    [string][Parameter()] $GitRepositoryPath 
    )
    [bool]$repoDetected = $true
    [bool]$repoAdded = $true
    $OriginalErrorActionPreference = $ErrorActionPreference

    if(-Not $ProvidedParameters.ContainsKey('GitRepositoryPath')){
        $GitRepositoryPath = (Get-Location).Path 
    }

    try
    {
        $ErrorActionPreference = 'Stop'
        git -C $GitRepositoryPath status | Out-Null
    }
    catch
    {          
        $repoDetected = $false
    }
    finally
    {
        $ErrorActionPreference = $OriginalErrorActionPreference
    }

    if ($repoDetected) { 
        $message = "A git repository has been detected. " 
        try
        {               
            $ErrorActionPreference = 'Stop'
            # Get app-level deployment credentials
            $xml = [xml](Get-AzureRmWebAppPublishingProfile -Name $WebApp.Name -ResourceGroupName $WebApp.ResourceGroup -OutputFile null)
            $username = [System.Uri]::EscapeDataString($xml.SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@userName").value)
            $password = [System.Uri]::EscapeDataString($xml.SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@userPWD").value)
            $remoteName = "azure"
			$url = ("https://$username" + ':' + "$password@$($WebApp.EnabledHostNames[1])")
            # Add the Azure remote to a local Git respository 
            $command = "git -C $GitRepositoryPath remote add $remoteName $url"
            Invoke-Expression -Command $command | Out-Null
            if ($gitOutPut) {
                $repoAdded = $false
            }
        }
        catch
        {
            $repoAdded = $false
        }
        finally 
        {
            $ErrorActionPreference = $OriginalErrorActionPreference
        }
        
        if ($repoAdded) {        
            $message += "Added remote '$($remoteName)'. Push your code by running the command 'git push $($remoteName) master.' "            
        } else {
            $message += "However, remote '$($remoteName)' could not be added. "
        }

        Write-Information $message -InformationAction Continue
    }
}

function Get-WebAppName 
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [Microsoft.Azure.Commands.Websites.Experiments.CustomWebSiteManagementClient][Parameter()]$WebSitesClient
    )
    [string]$name = ""
    [bool]$nameIsAvailable = $false
 
    if ($ProvidedParameters.ContainsKey('WebAppName')) {      
        $name = $ProvidedParameters.WebAppName
        $nameIsAvailable = Test-NameAvailability $name $WebSitesClient
        if (-not $NameIsAvailable) {
            $message = "Website with given name '$name' already exists."
            $exception = New-Object -TypeName System.Exception -ArgumentList $message
            throw $exception             
        }
    } else {
        for ($i = 0; $i -le 2; $i++) {
            $name ="WebApp$(Get-Random -max 1000000)"
            $nameIsAvailable = Test-NameAvailability $name $WebSitesClient
            if ($NameIsAvailable) {
                 break
            }
        }
    }
    return $name
}

function Test-NameAvailability
{
    param(
    [string][Parameter()]$WebAppName,
    [Microsoft.Azure.Commands.Websites.Experiments.CustomWebSiteManagementClient][Parameter()]$WebSitesClient
    )
    [string]$resourceType = "Site"
    return $WebSitesClient.CheckNameAvailabilityWithHttpMessagesAsync($WebAppName, $resourceType).Result.Body.NameAvailable
}

function Get-ResourceGroupInfo
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [string][Parameter(Mandatory=$false)]$WebAppName,    
    [Microsoft.Azure.Management.ResourceManager.ResourceManagementClient][Parameter()]$ResourceManagementClient
    )
    [hashtable]$resourceGroupInfo = @{Name="";Exists=$false}
    $defaultName = $WebAppName 

    if ($ProvidedParameters.ContainsKey('ResourceGroupName')) {
        $resourceGroupInfo.Name = $ProvidedParameters.ResourceGroupName 
    } else {
        $resourceGroupInfo.Name = $defaultName 
    }

    $resourceGroupInfo.Exists = Test-ResourceGroupExistence $resourceGroupInfo.Name $ResourceManagementClient

    return $resourceGroupInfo
}

function Test-ResourceGroupExistence 
{
    param(
    [string][Parameter()]$ResourceGroupName,    
    [Microsoft.Azure.Management.ResourceManager.ResourceManagementClient][Parameter()]$ResourceManagementClient
    )
    return $ResourceManagementClient.ResourceGroups.CheckExistenceWithHttpMessagesAsync($ResourceGroupName).Result.Body   
}

function Get-AppServicePlanInfo
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [string][Parameter()]$WebAppName,
    [string][Parameter()]$ResourceGroupName
    )
    [hashtable]$appServicePlanInfo = @{Name="";ResourceGroup="";IsDefaultPlan=$false;Exists=$false}   
    [object[]]$appServicePlans = Get-AzureRmAppServicePlan
    $defaultName = $WebAppName 

    if ($ProvidedParameters.ContainsKey('AppServicePlan')) {  
         $regexp = '/subscriptions/[-A-Za-z0-9]+/resourceGroups/[-\w\._\(\)]+/providers/Microsoft.Web/serverfarms/[-\w\._\(\)]+$'
         $idWasProvided = $ProvidedParameters.AppServicePlan -imatch $regexp
         if ($idWasProvided) {
            $parsedId = $ProvidedParameters.AppServicePlan.split('/')            
            $appServicePlanInfo.Name = $parsedId[$parsedId.Length - 1]
            $appServicePlanInfo.ResourceGroup =  $parsedId[4] 
            $existingPlan = $appServicePlans | Where-Object {$_.Id -eq $ProvidedParameters.AppServicePlan}
            if (-not $existingPlan) {
                $message = "The app service plan with the id provided does not exist."
                $exception = New-Object -TypeName System.Exception -ArgumentList $message
                throw $exception
            }                                
        } else {
            $appServicePlanInfo.Name = $ProvidedParameters.AppServicePlan
        }
            $appServicePlanInfo.IsDefaultPlan = $false
    } else {
        $existentDefaultPlan = Get-DefaultAppServicePlan $AppServicePlans
        if ($existentDefaultPlan) {        
            $appServicePlanInfo.Name = $existentDefaultPlan.Name 
            $appServicePlanInfo.ResourceGroup = $existentDefaultPlan.ResourceGroup
            $appServicePlanInfo.IsDefaultPlan = $true   
            $appServicePlanInfo.Exists = $true
        } else {                        
            $appServicePlanInfo.Name = $defaultName
            $appServicePlanInfo.IsDefaultPlan = $false
        }
    }

    if (-not $appServicePlanInfo.IsDefaultPlan) {
        [object[]]$appServicePlansWithProvidedName = $appServicePlans | Where-Object {$_.Name -eq $appServicePlanInfo.Name}
        if ($appServicePlansWithProvidedName) {
            $appServicePlanInfo.Exists = $true
            $appServicePlanWithProvidedNameAndGroup =  $appServicePlansWithProvidedName | Where-Object {$_.ResourceGroup -eq $ResourceGroupName}
            if ($appServicePlanWithProvidedNameAndGroup) {
                $appServicePlanInfo.ResourceGroup = $appServicePlanWithProvidedNameAndGroup.ResourceGroup
            } else {
                if ($appServicePlansWithProvidedName.Count -gt 1) {
                    $message = "There are various App Service Plans with that name. An existing Resource Group name should be provided."
                    $exception = New-Object -TypeName System.Exception -ArgumentList $message
                    throw $exception
                } else {                    
                    $appServicePlanInfo.ResourceGroup = $appServicePlansWithProvidedName.ResourceGroup
                }                
            }
        } else {            
            $appServicePlanInfo.Exists = $false
            $appServicePlanInfo.ResourceGroup = $ResourceGroupName
        }
    }  

    return $appServicePlanInfo
}

function Get-DefaultAppServicePlan
{
    param(
    [object[]][Parameter()]$AppServicePlans
    )
    [object[]]$appServicePlanMatches = $AppServicePlans | Where-Object {$_.Sku.Tier -eq "Free"}
    if($appServicePlanMatches){
        return $appServicePlanMatches[0]
    } else {
        return $null
    }
}

function Get-AppLocation 
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [string][Parameter()]$ResourceGroupName,
    [bool][Parameter()]$ResourceGroupExists,
    [string[]][Parameter()]$AvailableLocations
    )
    [string]$location = ""

    if ($ProvidedParameters.ContainsKey('Location')) {
        $location = $ProvidedParameters.Location
    } else {
        if ($ResourceGroupExists) {
            $location = $(Get-AzureRmResourceGroup -Name $ResourceGroupName).Location
        } else {
            $location = Get-DefaultLocation $AvailableLocations
        }
    }
    return $location
}

function Get-DefaultLocation
{
    param(
    [string[]][Parameter()]$AvailableLocations
    )
    # TODO: figure out a way to get a 'Smart Default Location'
    return $AvailableLocations[0]
}

function Get-Context
{
      return [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
}

function Get-ResourceManagementClient
{
    param(
    [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext] $Context
    )
    $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.ClientFactory
    [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext], [string]
    $resourceManagementClient = [Microsoft.Azure.Management.ResourceManager.ResourceManagementClient]
    $method = [Microsoft.Azure.Commands.Common.Authentication.IClientFactory].GetMethod("CreateArmClient", $types)
    
    $closedMethod = $method.MakeGenericMethod($resourceManagementClient)
    $arguments = $Context, [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment+Endpoint]::ResourceManager
    $client = $closedMethod.Invoke($factory, $arguments)

    return $client
}

function Get-WebSitesClient
{
    param(
    [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext] $Context
    )
    $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.ClientFactory
    [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext], [string]
    $webSitesClient = [Microsoft.Azure.Commands.Websites.Experiments.CustomWebSiteManagementClient]
    $method = [Microsoft.Azure.Commands.Common.Authentication.IClientFactory].GetMethod("CreateArmClient", $types)

    $closedMethod = $method.MakeGenericMethod($webSitesClient)
    $arguments = $context, [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment+Endpoint]::ResourceManager
    $client = $closedMethod.Invoke($factory, $arguments)

    return $client
}

function New-AzWebAppGrayParam
{
    [CmdletBinding()]        
    [OutputType([Microsoft.Azure.Management.WebSites.Models.Site])]
    param(
    [string][Parameter(Mandatory=$false)][alias("Name")]$WebAppName,
    [string][Parameter(Mandatory=$false)][alias("Group")]$ResourceGroupName,
    [string][Parameter(Mandatory=$false)][alias("Plan")]$AppServicePlan,
    [switch][Parameter(Mandatory=$false)]$Auto,
    [switch][Parameter(Mandatory=$false)]$AddRemote,
    [string][Parameter(Mandatory=$false)]$GitRepositoryPath
    )
    DynamicParam{
        #Set the dynamic parameters' name
        $ParamName_location = 'Location'
        # Create the collection of attributes
        $AttributeCollection = New-Object  System.Collections.ObjectModel.Collection[System.Attribute]
        # Create and set the parameters' attributes
        $ParameterAttribute = New-Object  System.Management.Automation.ParameterAttribute
        if ($PSBoundParameters.ContainsKey('Auto')) {
            $ParameterAttribute.Mandatory = $false
        } else {             
            $ParameterAttribute.Mandatory = $true
        }
        # Add the attributes to the attributes collection        
        $AttributeCollection.Add($ParameterAttribute) 
        # Create the dictionary
        $RuntimeParameterDictionary = New-Object  System.Management.Automation.RuntimeDefinedParameterDictionary
        #Generate and set the ValidateSet
        $providerNamespace = "Microsoft.Web"
        try
        {
            $availableLocations = $(Get-AzureRmResourceProvider | Where-Object {$_.ProviderNamespace -eq $providerNamespace}).Locations   
        }
        catch
        {
            throw $_        
        }     
        $ValidateSetAttribute = New-Object System.Management.Automation.ValidateSetAttribute($availableLocations)
        # Add the ValidateSet to the attributes collection
        $AttributeCollection.Add($ValidateSetAttribute)
        # Create and return the dynamic parameter
        $RuntimeParameter = New-Object  System.Management.Automation.RuntimeDefinedParameter($ParamName_location, [string],  $AttributeCollection)        
        $RuntimeParameterDictionary.Add($ParamName_location, $RuntimeParameter)  

        return $RuntimeParameterDictionary
    }

    BEGIN {         
        $context = Get-Context
        $webSitesClient = Get-WebSitesClient $context
        $resourceManagementClient = Get-ResourceManagementClient $context
    }

    PROCESS {
        $mainActivity = "Create Azure Web App" 
        [string]$Location = $PSBoundParameters[$ParamName_location]
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting App Name information."   
        [string]$appName = Get-WebAppNameGrayParam $PSBoundParameters $webSitesClient
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting Resource Group information." 
        [hashtable]$groupInfo = Get-ResourceGroupInfoGrayParam $PSBoundParameters $appName $resourceManagementClient
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting App Service Plan information."   
        [hashtable]$appPlanInfo = Get-AppServicePlanInfoGrayParam $PSBoundParameters $appName $groupInfo.Name        
        Write-Progress `
            -Activity $mainActivity `
            -CurrentOperation "Getting App Location information."   
        [string]$appLocation = Get-LocationGrayParam $PSBoundParameters $groupInfo.Name $groupInfo.Exists $availableLocations
        if ($groupInfo.Exists) {          
            $appGroup = Get-AzureRmResourceGroup `
                            -Name $groupInfo.Name 
            $message = "Using resource group '$($appGroup.ResourceGroupName)' in location '$($appGroup.Location)'."    
            Write-Information -MessageData $message -InformationAction Continue            
        } else {           
            $appGroup =  New-AzureRmResourceGroup `
                            -Name $groupInfo.Name `
                            -Location $appLocation 
            $message = "Created resource group '$($appGroup.ResourceGroupName)' in location '$($appGroup.Location)'."
            Write-Information -MessageData $message -InformationAction Continue   
        }

        if ($appPlanInfo.Exists) {            
            $appPlan = Get-AzureRmAppServicePlan `
                        -Name $appPlanInfo.Name `
                        -ResourceGroupName $appPlanInfo.ResourceGroup
            $message = "Using app service plan '$($appPlan.Name)' in location '$($appPlan.Location)' with Tier '$($appPlan.Sku.Tier)'." 
            Write-Information -MessageData $message -InformationAction Continue       
        } else {           
            $defaultTier = "Free"
            $appPlan = New-AzureRmAppServicePlan `
                        -Name $appPlanInfo.Name `
                        -Location $appLocation `
                        -Tier $defaultTier `
                        -ResourceGroupName $appPlanInfo.ResourceGroup
            $message = "Created app service plan '$($appPlan.Name)' in location '$($appPlan.Location)' with Tier '$($appPlan.Sku.Tier)'." 
            Write-Information -MessageData $message -InformationAction Continue        
        } 
          
        $webapp =  New-AzureRmWebApp `
                    -Name $appName `
                    -AppServicePlan $appPlan.Id `
                    -ResourceGroupName $appGroup.ResourceGroupName `
                    -Location $appLocation  
         
        Write-Output $webapp 

        Add-RemoteGrayParam -ProvidedParameters $PSBoundParameters -WebApp $webapp -GitRepositoryPath $GitRepositoryPath            
    }

    END {}
}

function Add-RemoteGrayParam 
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [Microsoft.Azure.Management.WebSites.Models.Site][Parameter()]$WebApp,
    [string][Parameter()] $GitRepositoryPath 
    )
    [bool]$repoDetected = $true
    [bool]$repoAdded = $true
    $OriginalErrorActionPreference = $ErrorActionPreference

    if(-Not $ProvidedParameters.ContainsKey('GitRepositoryPath')){
        $GitRepositoryPath = (Get-Location).Path 
    }

    try
    {
        $ErrorActionPreference = 'Stop'
        git -C $GitRepositoryPath status | Out-Null
    }
    catch
    {          
        $repoDetected = $false
    }
    finally
    {
        $ErrorActionPreference = $OriginalErrorActionPreference
    }

    if ($repoDetected) { 
        $message = "A git repository has been detected. "         
        try
        {              
            $ErrorActionPreference = 'Stop'

            # Get app-level deployment credentials
            $xml = [xml](Get-AzureRmWebAppPublishingProfile -Name $WebApp.Name -ResourceGroupName $WebApp.ResourceGroup -OutputFile null)
            $username = $xml.SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@userName").value
            $password = $xml.SelectNodes("//publishProfile[@publishMethod=`"MSDeploy`"]/@userPWD").value
            
            # Add remote azure
            $remoteName = "azure"
            if ($ProvidedParameters.ContainsKey('Auto') -or $ProvidedParameters.ContainsKey('AddRemote')){
                Write-Information $message -InformationAction Continue                
            } else {
                $title = $message
                $message = "Would you like to add this webapp as a remote named '$remoteName'?"
                $yes = New-Object System.Management.Automation.Host.ChoiceDescription "&Yes", `
                    "Adds this webapp as a remote named '$remoteName'"
                $no = New-Object System.Management.Automation.Host.ChoiceDescription "&No", `
                    "No action is taken"
                $options = [System.Management.Automation.Host.ChoiceDescription[]]($no, $yes)
                $result = $host.ui.PromptForChoice($title, $message, $options, 0) 
            }

            if ($result -eq 1 -or $ProvidedParameters.ContainsKey('AddRemote') -or $ProvidedParameters.ContainsKey('Auto')) {
                # Add the Azure remote to a local Git respository 
                $command = "git -C $GitRepositoryPath remote add $remoteName 'https://${username}:$password@$($WebApp.EnabledHostNames[0])'" + " 2> $gitOutput"
                Invoke-Expression -Command $command | Out-Null

            }            
            
            if ($gitOutPut) {
                $repoAdded = $false
            }
        }
        catch
        {
            $repoAdded = $false
        }
        finally 
        {
            $ErrorActionPreference = $OriginalErrorActionPreference
        }
        
        if ($repoAdded) {        
            $message = "Added remote '$($remoteName)'. Push your code by running the command 'git push $($remoteName) master.' "            
        } else {
            $message = "Remote '$($remoteName)' could not be added. "
        }

        Write-Information $message -InformationAction Continue
    }
}

function Get-WebAppNameGrayParam 
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [Microsoft.Azure.Commands.Websites.Experiments.CustomWebSiteManagementClient][Parameter()]$WebSitesClient
    )
    [string]$name = ""
    [bool]$nameIsAvailable = $false
    
    if ($ProvidedParameters.ContainsKey('WebAppName')) {      
        $name = $ProvidedParameters.WebAppName
        $nameIsAvailable = Test-NameAvailability $name $WebSitesClient
        if (-not $NameIsAvailable) {
            $message = "Website with given name '$name' already exists."
            $exception = New-Object -TypeName System.Exception -ArgumentList $message
            throw $exception             
        }
    } else {
        for ($i = 0; $i -le 2; $i++) {
            $defaultName ="WebApp$(Get-Random -max 1000000)"
            $nameIsAvailable = Test-NameAvailability $defaultName $WebSitesClient
            if ($NameIsAvailable) {
                 break
            }
        }

        if ($ProvidedParameters.ContainsKey('Auto')) {
            $name = $defaultName
        } else {
            $name = Get-WebAppNameFromUser $defaultName
        }
    }

    return $name          
}

function Get-WebAppNameFromUser
{
    param(
    [string][Parameter()]$DefaultName
    )
    
    $selection = Read-Host "Enter a name for you WebApp or leave blank for default($defaultName)"
    if ($selection) {
        $nameIsAvailable = Test-NameAvailability $selection $WebSitesClient
        if (-not $NameIsAvailable) {
            $message = "Website with given name '$selection' already exists."
            $exception = New-Object -TypeName System.Exception -ArgumentList $message
            throw $exception             
        } else {
            $name = $selection
        }
    } else {
        $name = $DefaultName
    }

    return $name
}


function Get-ResourceGroupInfoGrayParam
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [string][Parameter(Mandatory=$false)]$WebAppName,    
    [Microsoft.Azure.Management.ResourceManager.ResourceManagementClient][Parameter()]$ResourceManagementClient
    )
    [hashtable]$resourceGroupInfo = @{Name="";Exists=$false}
    $defaultName = $WebAppName 

    if ($ProvidedParameters.ContainsKey('ResourceGroupName')) {
        $resourceGroupInfo.Name = $ProvidedParameters.ResourceGroupName 
    } else {
        if ($ProvidedParameters.ContainsKey('Auto')) {
            $resourceGroupInfo.Name = $defaultName 
        } else {
            $resourceGroupInfo.Name = Get-ResourceGroupNameFromUser $defaultName                       
        }
        
    }

    $resourceGroupInfo.Exists = Test-ResourceGroupExistence $resourceGroupInfo.Name $ResourceManagementClient

    return $resourceGroupInfo
}

function Get-ResourceGroupNameFromUser
{
    param(
    [string][Parameter()]$DefaultName
    )
    [object[]]$resourceGroups = Get-AzureRmResourceGroup 
    Write-Host "Resource Group options: "
    Write-Host "[Default] $DefaultName"
    for ($i = 1; $i -le $resourceGroups.Count; $i++) {
        Write-Host "[$i] $($resourceGroups[$i-1].ResourceGroupName)"
    }

    $selection = Read-Host "Enter your selection or a new resource group name (leave blank for default)"
    if ($selection) {
        if ($selection -match '^\d+$' -and $selection -le $resourceGroups.Count -and $selection -gt 0) {
            $name = $resourceGroups[$selection - 1].ResourceGroupName
        } else {
             $name = $selection
        }
    } else {
        $name = $DefaultName
    }

    return $name
}

function Get-AppServicePlanInfoGrayParam
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [string][Parameter()]$WebAppName,
    [string][Parameter()]$ResourceGroupName
    )
    [hashtable]$appServicePlanInfo = @{Name="";ResourceGroup="";IsDefaultPlan=$false;Exists=$false}   
    [object[]]$appServicePlans = Get-AzureRmAppServicePlan
    $defaultName = $WebAppName 

    if ($ProvidedParameters.ContainsKey('AppServicePlan')) {  
         $regexp = '/subscriptions/[-A-Za-z0-9]+/resourceGroups/[-\w\._\(\)]+/providers/Microsoft.Web/serverfarms/[-\w\._\(\)]+$'
         $idWasProvided = $ProvidedParameters.AppServicePlan -imatch $regexp
         if ($idWasProvided) {
            $parsedId = $ProvidedParameters.AppServicePlan.split('/')            
            $appServicePlanInfo.Name = $parsedId[$parsedId.Length - 1]
            $appServicePlanInfo.ResourceGroup =  $parsedId[4] 
            $existingPlan = $appServicePlans | Where-Object {$_.Id -eq $ProvidedParameters.AppServicePlan}
            if (-not $existingPlan) {
                $message = "The app service plan with the id provided does not exist."
                $exception = New-Object -TypeName System.Exception -ArgumentList $message
                throw $exception
            }                                
        } else {
            $appServicePlanInfo.Name = $ProvidedParameters.AppServicePlan
        }
            $appServicePlanInfo.IsDefaultPlan = $false
    } else {
        if($ProvidedParameters.ContainsKey('Auto')){
            $existentDefaultPlan = Get-DefaultAppServicePlan $appServicePlans
            if ($existentDefaultPlan) {        
                $appServicePlanInfo.Name = $existentDefaultPlan.Name 
                $appServicePlanInfo.ResourceGroup = $existentDefaultPlan.ResourceGroup
                $appServicePlanInfo.IsDefaultPlan = $true   
                $appServicePlanInfo.Exists = $true
            } else {                        
                $appServicePlanInfo.Name = $defaultName
                $appServicePlanInfo.IsDefaultPlan = $false
            }
        } else {
            $appServicePlanInfo = Get-AppServicePlanInfoFromUser $appServicePlans $defaultName
        }              
    }

    if (-not $appServicePlanInfo.IsDefaultPlan) {
        [object[]]$appServicePlansWithProvidedName = $appServicePlans | Where-Object {$_.Name -eq $appServicePlanInfo.Name}
        if ($appServicePlansWithProvidedName) {
            $appServicePlanInfo.Exists = $true
            $appServicePlanWithProvidedNameAndGroup =  $appServicePlansWithProvidedName | Where-Object {$_.ResourceGroup -eq $ResourceGroupName}
            if ($appServicePlanWithProvidedNameAndGroup) {
                $appServicePlanInfo.ResourceGroup = $appServicePlanWithProvidedNameAndGroup.ResourceGroup
            } else {
                if ($appServicePlansWithProvidedName.Count -gt 1) {
                    $message = "There are various App Service Plans with that name. An existing Resource Group name should be provided."
                    $exception = New-Object -TypeName System.Exception -ArgumentList $message
                    throw $exception
                } else {                    
                    $appServicePlanInfo.ResourceGroup = $appServicePlansWithProvidedName.ResourceGroup
                }                
            }
        } else {            
            $appServicePlanInfo.Exists = $false
            $appServicePlanInfo.ResourceGroup = $ResourceGroupName
        }
    }  

    return $appServicePlanInfo
}

function Get-AppServicePlanInfoFromUser
{
    param(
    [object[]]$Plans,
    [string]$DefaultName
    )
    [hashtable]$appServicePlanInfo = @{Name="";ResourceGroup="";IsDefaultPlan=$false;Exists=$false}   
    $existentDefaultPlan = Get-DefaultAppServicePlan $Plans    

    Write-Host "Plan options:"
    if ($existentDefaultPlan) {
        Write-Host "[Default] $($existentDefaultPlan.Name) {Tier=$($existentDefaultPlan.Sku.Tier);Location=$($existentDefaultPlan.Location)}"
    } else {
        Write-Host "[Default] $($defaultName) {Tier=Free}"
    }

    for ($i = 1; $i -le $Plans.Count; $i++) {
        Write-Host "[$i] $($Plans[$i-1].Name) {Tier=$($Plans[$i-1].Sku.Tier);Location=$($Plans[$i-1].Location)}"
    }

    $selection = Read-Host "Enter your selection (leave blank for default)"
    if ($selection) {
        if ($selection -match '^\d+$' -and $selection -le $Plans.Count -and $selection -gt 0) {
            $appServicePlanInfo.Name = $Plans[$selection - 1].Name 
            $appServicePlanInfo.IsDefaultPlan = $false 
        } else {
            $appServicePlanInfo.Name = $selection
            $appServicePlanInfo.IsDefaultPlan = $false
        }        
    } else {
        if ($existentDefaultPlan) {               
            $appServicePlanInfo.Name = $existentDefaultPlan.Name 
            $appServicePlanInfo.ResourceGroup = $existentDefaultPlan.ResourceGroup
            $appServicePlanInfo.IsDefaultPlan = $true   
            $appServicePlanInfo.Exists = $true        
        } else {               
            $appServicePlanInfo.Name = $defaultName
            $appServicePlanInfo.IsDefaultPlan = $false
        }        
    }

    return $appServicePlanInfo
  }

function Get-LocationGrayParam
{
    param(
    [hashtable][Parameter()]$ProvidedParameters,
    [string][Parameter()]$ResourceGroupName,
    [bool][Parameter()]$ResourceGroupExists,
    [string[]][Parameter()]$AvailableLocations
    )
    [string]$location = ""

    if ($ProvidedParameters.ContainsKey('Location')) {
        $location = $ProvidedParameters.Location
    } else {
        if ($ResourceGroupExists) {
            $location = $(Get-AzureRmResourceGroup -Name $ResourceGroupName).Location
        } else {
            $location = Get-DefaultLocation $AvailableLocations
        }    
    }

    return $location
}

function Get-LocationFromUser 
{
    param(
    [string][Parameter()]$DefaultLocation,
    [string[]][Parameter()]$AvailableLocations
    )    
    Write-Host "WebApp Location options: "
    Write-Host "[Default] $DefaultLocation"
    for ($i = 1; $i -le $AvailableLocations.Count; $i++) {
        Write-Host "[$i] $($AvailableLocations[$i-1])"
    }

    $selection = Read-Host "Enter your selection (leave blank for default)"
    if ($selection) {
        if ($selection -match '^\d+$' -and $selection -le $AvailableLocations.Count -and $selection -gt 0) {
            $location = $AvailableLocations[$selection - 1]
        } else {
             $location = $selection
        }        
    } else {
        $location = $DefaultLocation
    }

    return $location
}


Export-ModuleMember -Cmdlet New-AzWebApp
Export-ModuleMember -Cmdlet New-AzWebAppGrayParam

