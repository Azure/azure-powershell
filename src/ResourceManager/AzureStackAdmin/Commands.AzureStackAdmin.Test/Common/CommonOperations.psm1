#------------------------------------------------------------
# Copyright (c) Microsoft Corporation.  All rights reserved.
#------------------------------------------------------------

function Get-ResourceProviderRegistration
{
    if ($Global:AzureStackConfig.IsAAD)
    {
        $providers = Get-AzureRMResourceProviderRegistration -ResourceGroup $systemResourceGroup
    }
    else
    {
        $providers = Get-AzureRMResourceProviderRegistration -ResourceGroup $systemResourceGroup `
            -SubscriptionId $Global:AzureStackConfig.SubscriptionId `
            -AdminUri $Global:AzureStackConfig.AdminUri `
            -Token $Global:AzureStackConfig.Token `
            -ApiVersion $ApiVersion
    }

    return $providers
}

function Get-SqlRpQuotas
{
    $getSqlQuota = @{
        Uri = "{0}subscriptions/{1}/providers/Microsoft.Sql.Admin/locations/{2}/quotas?api-version=2014-04-01-preview" -f $Global:AzureStackConfig.AdminUri, $Global:AzureStackConfig.SubscriptionId, $Global:AzureStackConfig.ArmLocation
        Method = "GET"
        Headers = @{ "Authorization" = "Bearer " + $Global:AzureStackConfig.Token }
        ContentType = "application/json"
    }

    $sqlQuota = Invoke-RestMethod @getSqlQuota

    Write-Output $sqlQuota.value
}

function Get-SubscriptionsDefaultQuota
{
	$defaultQuota = "/subscriptions/{0}/providers/Microsoft.Subscriptions.Admin/locations/local/quotas/delegatedProviderQuota" -f $Global:AzureStackConfig.SubscriptionId
    Write-Output $defaultQuota
}

function Get-SqlRpDefaultQuota
{
    $sqlQuotas=Get-SqlRpQuotas
    return $sqlQuotas[0].id
}

function Get-StorageDefaultQuota
{
    # Assumption - RP location is same as ARM
    # Idempotent PUT call, creates it if does not exist
    $quota = New-StorageQuota -QuotaName "Basic" -Location $Global:AzureStackConfig.ArmLocation

    Write-Output $quota.Id
}

function Get-ComputeDefaultQuota
{
    # Assumption - RP location is same as ARM
    # Idempotent PUT call, creates it if does not exist
    $quota = New-ComputeQuota -QuotaName "Basic" -Location $Global:AzureStackConfig.ArmLocation

    Write-Output $quota.Id
}

function Get-NetworkDefaultQuota
{
    # Assumption - RP location is same as ARM
    # Idempotent PUT call, creates it if does not exist
    $quota = New-NetworkQuota -QuotaName "Basic" -Location $Global:AzureStackConfig.ArmLocation

    Write-Output $quota.Id
}

function Get-KeyvaultDefaultQuota
{
    $getKeyvaultQuota = @{
        Uri = "{0}subscriptions/{1}/providers/Microsoft.Keyvault.Admin/locations/{2}/quotas?api-version=2014-04-01-preview" -f $Global:AzureStackConfig.AdminUri, $Global:AzureStackConfig.SubscriptionId, $Global:AzureStackConfig.ArmLocation
        Method = "GET"
        Headers = @{ "Authorization" = "Bearer " + $Global:AzureStackConfig.Token }
        ContentType = "application/json"
    }

    # keyvault Creates only one default quota 'unlimited' as part of the deployment, just get that 
    $keyvaultQuota = Invoke-RestMethod @getKeyvaultQuota

    Write-Output $keyvaultQuota.value.Id
}

function Set-Offer
{
    param
    (
        [Parameter(Mandatory=$true)]
        [PSObject] $Offer,

        [Parameter(Mandatory=$true)]
        [String] $ResourceGroup,

        [Parameter(Mandatory=$true)]
        [ValidateSet("Public", "Private", "Decommissioned")]
        [String] $State
    )

    $Offer.properties.state = $State
    if ($Global:AzureStackConfig.IsAAD)
    {
        $Offer | Set-AzureRMOffer -ResourceGroup $ResourceGroup  
    }
    else
    {
        $Offer | Set-AzureRMOffer -ResourceGroup $ResourceGroup -SubscriptionId $Global:AzureStackConfig.SubscriptionId -AdminUri $Global:AzureStackConfig.AdminUri -Token $Global:AzureStackConfig.Token -ApiVersion $Global:AzureStackConfig.ApiVersion
    }

    Write-Verbose "$Offer state got updated to $State"
}

function Set-Plan
{
    param
    (
        [Parameter(Mandatory=$true)]
        [PSObject] $Plan,

        [Parameter(Mandatory=$true)]
        [String] $ResourceGroup

    )

    if ($Global:AzureStackConfig.IsAAD)
    {
        $Plan | Set-AzureRMPlan -ResourceGroup $ResourceGroup 
    }
    else
    {
        $Plan | Set-AzureRMPlan -ResourceGroup $ResourceGroup -SubscriptionId $Global:AzureStackConfig.SubscriptionId -AdminUri $Global:AzureStackConfig.AdminUri -Token $Global:AzureStackConfig.Token -ApiVersion $Global:AzureStackConfig.ApiVersion
    }

    Write-Verbose "$Plan state got updated to $State"
}

function Get-ServiceQuotas
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String[]] $Services
    )

    $serviceQuotas = @()
    
    foreach ($service in $Services)
    {
       switch($service)
       {
            "Microsoft.Sql" { 
                        $serviceQuotas  += Get-SQLRPDefaultQuota
                    } 
            "Microsoft.Subscriptions" { 
                        $serviceQuotas  += Get-SubscriptionsDefaultQuota
                    } 
            "Microsoft.Storage" { 
                        $serviceQuotas  += Get-StorageDefaultQuota
                    } 
            "Microsoft.Compute" { 
                        $serviceQuotas  += Get-ComputeDefaultQuota
                    } 
            "Microsoft.Network" { 
                        $serviceQuotas  += Get-NetworkDefaultQuota
                    } 
            "Microsoft.Keyvault" { 
                        $serviceQuotas  += Get-KeyvaultDefaultQuota
                    } 
            Default { throw "Wrong service name provided" }
       }
    }

    return $serviceQuotas
}

function New-Plan
{
    param
    (
        [Alias("Name")]
        [Parameter(Mandatory=$true)]
        [String] $PlanName,

        [Parameter(Mandatory=$true)]
        [String[]] $Services,

        [Parameter(Mandatory=$true)]
        [String] $ResourceGroupName
    )

    Write-Verbose "Creating the plan: $PlanName"

    $quotaIds = Get-ServiceQuotas -Services $Services

    if ($Global:AzureStackConfig.IsAAD)
    {
        $plan = New-AzureRMPlan -Name $PlanName -DisplayName $PlanName -ArmLocation $Global:AzureStackConfig.ArmLocation -ResourceGroup $ResourceGroupName -QuotaIds $quotaIds -ApiVersion $Global:AzureStackConfig.ApiVersion
    }
    else
    {
        $plan = New-AzureRMPlan -Name $PlanName -DisplayName $PlanName -ArmLocation $Global:AzureStackConfig.ArmLocation -ResourceGroup $ResourceGroupName -QuotaIds $quotaIds -ApiVersion $Global:AzureStackConfig.ApiVersion  -SubscriptionId $Global:AzureStackConfig.SubscriptionId -AdminUri $Global:AzureStackConfig.AdminUri -Token $Global:AzureStackConfig.Token 
    }

    Write-Verbose "Plan created successfully: $PlanName"

    $plan = Get-Plan -PlanName $PlanName -ResourceGroupName $ResourceGroupName

    Assert-NotNull $plan
    Assert-True { $plan.Properties.DisplayName -eq  $PlanName}

    Write-Output $plan
}

# TODO: pass subscription id when needed
function Remove-Plan
{
 param
    (
        [Alias("Name")]
        [Parameter(Mandatory=$true)]
        [String] $PlanName,

        [Parameter( Mandatory=$true)]
        [String] $ResourceGroupName
    )

    if ($Global:AzureStackConfig.IsAAD)
    {
        Remove-AzureRMPlan -Name $PlanName -ResourceGroup $ResourceGroupName -SubscriptionId $Global:AzureStackConfig.SubscriptionId 
    }
    else
    {
        Remove-AzureRMPlan -Name $PlanName -ResourceGroup $ResourceGroupName -SubscriptionId $Global:AzureStackConfig.SubscriptionId -AdminUri $Global:AzureStackConfig.AdminUri -Token $Global:AzureStackConfig.Token -ApiVersion $Global:AzureStackConfig.ApiVersion
    }
    
    Assert-ResourceDeletion {Get-Plan -PlanName $PlanName -ResourceGroupName $ResourceGroupName}

    Write-Verbose "Deleted the plan successfully: $PlanName"
}

# TODO: pass subscription id when needed
function Get-Plan
{
 param
    (
        [Alias("Name")]
        [Parameter(Mandatory=$true)]
        [String] $PlanName,

        [Parameter(Mandatory=$true)]
        [String] $ResourceGroupName
    )

    if ($Global:AzureStackConfig.IsAAD)
    {
        return Get-AzureRMPlan -Name $PlanName -SubscriptionId $AzureStackConfig.SubscriptionId -ResourceGroup $ResourceGroupName -Managed 
    }
    else
    {
        return Get-AzureRMPlan -Name $PlanName -AdminUri $AzureStackConfig.AdminUri -Token $AzureStackConfig.Token -ApiVersion $AzureStackConfig.ApiVersion -SubscriptionId $AzureStackConfig.SubscriptionId -ResourceGroup $ResourceGroupName -Managed
    }
}

function New-Offer
{
 param
    (
        [Alias("Name")]
        [Parameter(Mandatory=$false)]
        [String] $OfferName,

        [Parameter(Mandatory=$false)]
        [string[]] $BasePlanIds,

        [Parameter(ValueFromPipeline=$true, Mandatory=$true, ValueFromPipelineByPropertyName=$true)]
        [String] $ResourceGroupName
    )

    if ($Global:AzureStackConfig.IsAAD)
    {
        $offer = New-AzureRMOffer -Name $OfferName -DisplayName $OfferName -State Private -BasePlanIds $BasePlanIds -ArmLocation $AzureStackConfig.ArmLocation -ResourceGroup $ResourceGroupName
    }
    else
    {
        $offer = New-AzureRMOffer -Name $OfferName -DisplayName $OfferName -State Private -BasePlanIds $BasePlanIds -ArmLocation $AzureStackConfig.ArmLocation -ResourceGroup $ResourceGroupName -SubscriptionId $AzureStackConfig.SubscriptionId -Token $AzureStackConfig.Token -AdminUri $AzureStackConfig.AdminUri -ApiVersion $AzureStackConfig.ApiVersion
    }

    Assert-NotNull $offer
    Assert-True {$offer.Properties.DisplayName -eq  $OfferName}

    return $offer
}

function Remove-Offer
{
 param
    (
        [Alias("Name")]
        [Parameter(Mandatory=$true)]
        [String] $OfferName,

        [Parameter( Mandatory=$true)]
        [String] $ResourceGroupName
    )
    if ($Global:AzureStackConfig.IsAAD)
    {
        $offer = Remove-AzureRMOffer -Name $OfferName -ResourceGroup $ResourceGroupName -SubscriptionId $Global:AzureStackConfig.SubscriptionId
    }
    else
    {
        $offer = Remove-AzureRMOffer -Name $OfferName -ResourceGroup $ResourceGroupName -SubscriptionId $Global:AzureStackConfig.SubscriptionId -AdminUri $Global:AzureStackConfig.AdminUri -Token $Global:AzureStackConfig.Token -ApiVersion $Global:AzureStackConfig.ApiVersion
    }

    Assert-ResourceDeletion {Get-Offer -OfferName $OfferName -ResourceGroupName $ResourceGroupName}

    Write-Verbose "Deleted the offer successfully: $OfferName"
}

function Get-Offer
{
 param
    (
        [Alias("Name")]
        [Parameter(Mandatory=$true, ParameterSetName="Admin")]
        [Parameter(Mandatory=$true, ParameterSetName="Tenant")]
        [String] $OfferName,

        [Parameter(Mandatory=$true, ParameterSetName="Admin")]
        [String] $ResourceGroupName,

        [String] $Token
    )

    switch ($PsCmdlet.ParameterSetName)
    {
        "Admin"
        {
            if ($Global:AzureStackConfig.IsAAD)
            {
                return Get-AzureRMOffer -Name $OfferName -SubscriptionId $AzureStackConfig.SubscriptionId -ResourceGroup $ResourceGroupName -Managed
            }
            else
            {
                return Get-AzureRMOffer -Name $OfferName -AdminUri $AzureStackConfig.AdminUri -Token $AzureStackConfig.Token -ApiVersion $AzureStackConfig.ApiVersion -SubscriptionId $AzureStackConfig.SubscriptionId -ResourceGroup $ResourceGroupName -Managed
            }
        }
        "Tenant"
        {
            if ($Global:AzureStackConfig.IsAAD)
            {
                return Get-AzureRMOffer -Provider "default" | where name -eq $OfferName
            }
            else
            {
                return Get-AzureRMOffer -Provider "default" -AdminUri $AzureStackConfig.AdminUri -Token $Token -ApiVersion $AzureStackConfig.ApiVersion | where name -eq $OfferName
            }
            #ToDo- Not to hardcode default
        }
    }
}


function New-Subscription
{
    param
    (
        [Parameter(Mandatory=$true, ParameterSetName="Admin")]
        [String] $SubscriptionUser,

        [Parameter(Mandatory=$true, ParameterSetName="Admin")]
        [Parameter(Mandatory=$true, ParameterSetName="Tenant")]
        [String] $OfferId,

        [Parameter(Mandatory=$false, ParameterSetName="Tenant")]
        [String] $Token
    )

    Write-Verbose "Creating the subscription for the user : $SubscriptionUser"
    $subDisplayName = "Test User-$SubscriptionUser"

    switch ($PsCmdlet.ParameterSetName)
    {
        "Admin"
        {
                $subscription = New-AzureRmManagedSubscription -Owner $SubscriptionUser -OfferId $OfferId -DisplayName $subDisplayName -SubscriptionId $Global:AzureStackConfig.SubscriptionId
        }
        "Tenant"
        {
                $subscription = New-AzureRmTenantSubscription  -OfferId $OfferId -DisplayName $subDisplayName
        }
    }

    Assert-True { $subscription.DisplayName -eq $subDisplayName } | Out-Null
    $Global:CreatedSubscriptions += @{
        SubscriptionId = $subscription.SubscriptionId
        Token = $Token
        }

    Retry-Function -ScriptBlock {
        (Get-AzureRmManagedSubscription -TargetSubscriptionId $subscription.SubscriptionId).State -ieq "Enabled"
    } -MaxTries 12 -IntervalInSeconds 5 | Out-Null

    Write-Verbose "Successfully created the subscription for user : $SubscriptionUser"
    return $subscription
}

function Get-Subscription
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $SubscriptionId
    )

    if ($Global:AzureStackConfig.IsAAD)
    {
        return Get-AzureRmManagedSubscription -TargetSubscriptionId $SubscriptionId
    }
    else
    {
        return Get-AzureRmManagedSubscription -TargetSubscriptionId $SubscriptionId `
        -SubscriptionId $Global:AzureStackConfig.SubscriptionId `
        -AdminUri $Global:AzureStackConfig.AdminUri `
        -Token $Global:AzureStackConfig.Token `
        -ApiVersion $Global:AzureStackConfig.ApiVersion
    }
}

function Remove-Subscription
{
   param
   (
       [Parameter(Mandatory=$true)]
       [String] $TargetSubscriptionId
   )
    Write-Verbose "Deleting the subscription : $TargetSubscriptionId"

    $subscription = Get-Subscription -SubscriptionId $TargetSubscriptionId
    $subscription.State = "disabled"

    if ($Global:AzureStackConfig.IsAAD)
    {
        Set-AzureRMManagedSubscription -Subscription $subscription  -ApiVersion $Global:AzureStackConfig.ApiVersion
        Retry-Function -ScriptBlock {(Get-AzureRmManagedSubscription -TargetSubscriptionId $subscription.SubscriptionId).State -ieq "Disabled"} -MaxTries 12 -IntervalInSeconds 5
        Remove-AzureRmManagedSubscription -TargetSubscriptionId $TargetSubscriptionId  -ApiVersion $Global:AzureStackConfig.ApiVersion
    }
    else
    {
        Set-AzureRMManagedSubscription -SubscriptionId $Global:AzureStackConfig.SubscriptionId -AdminUri $Global:AzureStackConfig.AdminUri -Token $Global:AzureStackConfig.Token -Subscription $subscription 
        Retry-Function -ScriptBlock {(Get-AzureRmManagedSubscription -TargetSubscriptionId $subscription.SubscriptionId -SubscriptionId $Global:AzureStackConfig.SubscriptionId -AdminUri $Global:AzureStackConfig.AdminUri -Token $Global:AzureStackConfig.Token).State -ieq "Disabled"} -MaxTries 12 -IntervalInSeconds 5
        Remove-AzureRmManagedSubscription -TargetSubscriptionId $TargetSubscriptionId -SubscriptionId $Global:AzureStackConfig.SubscriptionId -AdminUri $Global:AzureStackConfig.AdminUri -Token $Global:AzureStackConfig.Token -ApiVersion $Global:AzureStackConfig.ApiVersion
    }
    
    Assert-SubscriptionDeletion {Get-Subscription -SubscriptionId $TargetSubscriptionId}
    Write-Verbose "Successfully deleted the subscription : $TargetSubscriptionId"
}

function Get-TenantPublicOffers
{
 param
    (
        [Parameter(Mandatory=$true)]
        [String] $Token
    )

    #ToDo- Not to hardcode default
    if ($Global:AzureStackConfig.IsAAD)
    {
        return Get-AzureRMOffer -Provider "default"  -ApiVersion $Global:AzureStackConfig.ApiVersion
    }
    else
    {
        return Get-AzureRMOffer -Provider "default" -AdminUri $Global:AzureStackConfig.AdminUri -Token $Token -ApiVersion $AzureStackConfig.ApiVersion
    }
}

function Get-Subscriptions
{
    param
    (
        [Parameter( Mandatory=$true)]
        [String] $Token
    )

    $getSubscriptions = @{
        Uri = $Global:AzureStackConfig.AdminUri + "subscriptions?api-version=2014-04-01-preview"
        Method = "GET"
        Headers = @{ "Authorization" = "Bearer " + $Token }
        ContentType = "application/json"
    }

    $subscriptions = Invoke-RestMethod @getSubscriptions

    return $subscriptions.value
}

function Get-DeploymentStatus
{
    param
    (
        [Parameter(Mandatory=$true)]
        [string] $ResourceType,

        [Parameter(Mandatory=$true)]
        [string] $ResourceGroupName,

        [Parameter(Mandatory=$true)]
        [string] $SubscriptionId,

        [Parameter(Mandatory=$true)]
        [string] $Token
    )

    $deploymentUri = "{0}subscriptions/{1}/resourcegroups/{2}/deployments/{3}?api-version={4}" -f  $Global:AzureStackConfig.AdminUri, $SubscriptionId, $ResourceGroupName, $ResourceType, $Global:AzureStackConfig.ApiVersion
    $deploymentHeaders = @{ "Authorization" = "Bearer "+ $Token }
    $deploymentContentType = "application/json"

    $deploymentResponse = Invoke-RestMethod -Method Get -Uri $deploymentUri -Headers $deploymentHeaders -ContentType $deploymentContentType

    return $deploymentResponse.properties.provisioningState
}

function Register-ResourceProvider
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Namespaces
    )

    foreach ($namespace in $Namespaces)
    {
        Register-AzureRmResourceProvider -ProviderNamespace $Namespace -Force
    }

    # TODO: Remove the need for this sleep
    # BUG 7391118: Expose QuotaSyncState thru Get Admin and Tenant subscription
    Start-Sleep -Seconds 30
}

function Unregister-ResourceProvider
{
    param
    (
        [Parameter(Mandatory=$false)]
        [string] $SubscriptionId,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Namespaces
    )

    foreach ($namespace in $Namespaces)
    {
        Unregister-AzureRmResourceProvider -ProviderNamespace $Namespace -Force
    }

    # TODO: Remove the need for this sleep
    # BUG 7391118: Expose QuotaSyncState thru Get Admin and Tenant subscription
    Start-Sleep -Seconds 30
}

