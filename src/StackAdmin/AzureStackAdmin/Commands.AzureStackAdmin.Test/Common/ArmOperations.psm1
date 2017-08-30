#------------------------------------------------------------
# Copyright (c) Microsoft Corporation.  All rights reserved.
#------------------------------------------------------------

function New-ResourceGroup
{
    param
    (
        [Alias("Name")]
        [Parameter(Mandatory=$true)]
        [String] $ResourceGroupName,

        [string] $SubscriptionId = $Global:AzureStackConfig.SubscriptionId,

        [string] $Token = $Global:AzureStackConfig.Token
    )

    Write-Verbose "Creating the resource group : $ResourceGroupName"

    if ($Global:AzureStackConfig.IsAad)
    {
        $rgCreated = New-AzureRmResourceGroup -Name $ResourceGroupName -Location $Global:AzureStackConfig.ArmLocation -Force
    }
    else
    {
        # Create resource group request
        $putResourceGroup = @{
            Uri = "{0}subscriptions/{1}/resourcegroups/{2}?api-version={3}" -f $Global:AzureStackConfig.AdminUri, $SubscriptionId, $ResourceGroupName, $Global:AzureStackConfig.ApiVersion
            Method = "PUT"
            Headers = @{ "Authorization" = "Bearer " + $Token }
            ContentType = "application/json"
        }

        # Create resource group body
        $rgBody = [pscustomobject]@{
            Name = $ResourceGroupName
            location = $Global:AzureStackConfig.ArmLocation
        }

        # Make the API call
        $rgCreated = $rgBody | ConvertTo-Json | Invoke-RestMethod @putResourceGroup
    }

    Write-Verbose "Created the resource group successfully : $ResourceGroupName"

    # TODO: Changes needed when we have tests with reseller' tenant creating resources
    $Level = 0
    if ($Token -ne $Global:AzureStackConfig.Token)
    {
        $Level = 1
    }

    $Global:CreatedResourceGroups += @{
        ResourceGroupName = $ResourceGroupName
        SubscriptionId = $SubscriptionId
        Token = $Token
        Level = $Level
        }

    #ToDo: Get RG and assert to make sure RG is created
    return $rgCreated
}

function Remove-ResourceGroup
{
    param
    (
        [Alias("Name")]
        [Parameter(Mandatory=$true)]
        [String] $ResourceGroupName,

        [String] $SubscriptionId = $Global:AzureStackConfig.SubscriptionId,

        [String] $Token = $Global:AzureStackConfig.Token
    )

    Write-Verbose "Deleting the resource group: $ResourceGroupName"

    if($Global:AzureStackConfig.IsAad)
    {
        # Deletes the resources it contains as well
        Remove-AzureRmResourceGroup -Name $ResourceGroupName -Force
    }
    else
    {
        # Delete resource group request
        $deleteResourceGroup = @{
            Uri = "{0}subscriptions/{1}/resourcegroups/{2}?api-version={3}" -f $Global:AzureStackConfig.AdminUri, $SubscriptionId, $ResourceGroupName, $Global:AzureStackConfig.ApiVersion
            Method = "DELETE"
            Headers = @{ "Authorization" = "Bearer " + $Token }
            ContentType = "application/json"
        }

        Invoke-RestMethod @deleteResourceGroup
    }

    Assert-ResourceGroupDeletion -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId

    Write-Verbose "Deleted the resource group successfully: $ResourceGroupName"
}

function Get-ResourceGroup
{
    param
    (
        [String] $ResourceGroupName,

        [String] $SubscriptionId = $Global:AzureStackConfig.SubscriptionId,

        [String] $Token = $Global:AzureStackConfig.Token
    )

    if($ResourceGroupName)
    {
        Write-Verbose "Getting the resourceGroup $ResourceGroupName"

        if($Global:AzureStackConfig.IsAad)
        {
            return Get-AzureRmResourceGroup -Name $ResourceGroupName
        }

        $getResourceGroup = @{
            Uri = $Global:AzureStackConfig.AdminUri + "subscriptions/{0}/resourcegroups/{1}?api-version={2}&includeDetails=true" -f $SubscriptionId, $ResourceGroupName, $Global:AzureStackConfig.ApiVersion
            Method = "GET"
            Headers = @{ "Authorization" = "Bearer " + $Token }
            ContentType = "application/json"
        }
    }
    else
    {
        # If resourcegroup name is not specified return all the resource groups under the subscription
         Write-Verbose "Getting  all the resourceGroups for the subscription $SubscriptionId"

        if($Global:AzureStackConfig.IsAad)
        {
            return Get-AzureRmResourceGroup
        }

        $getResourceGroup = @{
            Uri = $Global:AzureStackConfig.AdminUri + "subscriptions/{0}/resourcegroups?api-version={1}&includeDetails=true" -f $SubscriptionId, $Global:AzureStackConfig.ApiVersion
            Method = "GET"
            Headers = @{ "Authorization" = "Bearer " + $Token }
            ContentType = "application/json"
        }
    }

    $resourceGroups = Invoke-RestMethod @getResourceGroup
    return $resourceGroups.value
}

function Get-ResourceGroupDeployments
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $ResourceGroupName,

        [String] $SubscriptionId = $Global:AzureStackConfig.SubscriptionId,

        [String] $Token = $Global:AzureStackConfig.Token
    )

    Write-Verbose "Getting the Deployment details for the resourceGroup $ResourceGroupName"


    if($Global:AzureStackConfig.IsAad)
    {
        #TODO: implement this
    }

    $getResourceGroupDeployments = @{
        Uri = $Global:AzureStackConfig.AdminUri + "subscriptions/{0}/resourcegroups/{1}/deployments?api-version=2014-04-01-preview&includeDetails=true" -f $SubscriptionId, $ResourceGroupName
        Method = "GET"
        Headers = @{ "Authorization" = "Bearer " + $Token }
        ContentType = "application/json"
    }

    return Invoke-RestMethod @getResourceGroupDeployments
}


function Get-ResourceGroupResources
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $ResourceGroupName,

        [String] $SubscriptionId = $Global:AzureStackConfig.SubscriptionId,

        [String] $Token = $Global:AzureStackConfig.Token
    )

    Write-Verbose "Getting the resource details for the resourceGroup $ResourceGroupName"


    if($Global:AzureStackConfig.IsAad)
    {
        #TODO: implement this
    }

    $getResources = @{
        Uri = $Global:AzureStackConfig.AdminUri + "subscriptions/{0}/resourcegroups/{1}/resources?api-version=2014-04-01-preview" -f $SubscriptionId, $ResourceGroupName
        Method = "GET"
        Headers = @{ "Authorization" = "Bearer " + $Token }
        ContentType = "application/json"
    }

    return Invoke-RestMethod @getResources
}


function Get-FilterQueryParam
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $ResourceType,

        [Parameter(Mandatory=$true)]
        [PsObject[]] $Subscriptions
    )

    $filterString = "("

    for($i=0; $i -le $Subscriptions.Length-2; $i++)
    {
        $filterString += "subscriptionId eq '"+ $Subscriptions[$i].subscriptionId +"' or "
    }

    $filterString += "subscriptionId eq '"+ $Subscriptions[$i].subscriptionId +"'"

    $filterString += ") and (resourceType eq '"
    $filterString += $ResourceType + "')"

    $encodedString = [System.Web.HttpUtility]::UrlEncode($filterString)
    return $encodedString
}

function Get-AllSusbscriptionsResources
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $ResourceType,

        [Parameter(Mandatory=$true)]
        [PsObject[]] $Subscriptions,

        [String] $Token = $Global:AzureStackConfig.Token
    )

    Write-Verbose "Getting the Deployment details for the resourceGroup $ResourceGroupName"

    if($Global:AzureStackConfig.IsAad)
    {
        #TODO: implement this
    }
    $filterParam = '$filter='
    $filterParam += Get-FilterQueryParam -ResourceType $ResourceType -Subscriptions $Subscriptions
    $getResourceGroup = @{
        Uri = $Global:AzureStackConfig.AdminUri + "resources?api-version=2014-04-01-preview&" + $filterParam
        Method = "GET"
        Headers = @{ "Authorization" = "Bearer " + $Token }
        ContentType = "application/json"
    }

    return Invoke-RestMethod @getResourceGroup
}

