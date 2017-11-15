#------------------------------------------------------------
# Copyright (c) Microsoft Corporation.  All rights reserved.
#------------------------------------------------------------

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
    $Offer | Set-AzsOffer -ResourceGroupName $ResourceGroup

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

    $Plan | Set-AzsPlan -ResourceGroupName $ResourceGroup

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

    $plan = New-AzsPlan -Name $PlanName -DisplayName $PlanName -ArmLocation $Global:AzureStackConfig.ArmLocation -ResourceGroupName $ResourceGroupName -QuotaIds $quotaIds

    Write-Verbose "Plan created successfully: $PlanName"

    $plan = Get-Plan -PlanName $PlanName -ResourceGroupName $ResourceGroupName

    Assert-NotNull $plan
    Assert-True { $plan.Properties.DisplayName -eq  $PlanName}

    Write-Output $plan
}

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

    Remove-AzsPlan -Name $PlanName -ResourceGroupName $ResourceGroupName

    Assert-ResourceDeletion {Get-Plan -PlanName $PlanName -ResourceGroupName $ResourceGroupName}

    Write-Verbose "Deleted the plan successfully: $PlanName"
}

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

    return Get-AzsPlan -Name $PlanName -ResourceGroupName $ResourceGroupName
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

    $offer = New-AzsOffer -Name $OfferName -DisplayName $OfferName -State Private -BasePlanIds $BasePlanIds -ArmLocation $AzureStackConfig.ArmLocation -ResourceGroupName $ResourceGroupName

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

    $offer = Remove-AzsOffer -Name $OfferName -ResourceGroupName $ResourceGroupName

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
            return Get-AzsManagedOffer -Name $OfferName -ResourceGroupName $ResourceGroupName
        }
        "Tenant"
        {
            return Get-AzsOffer -Provider "default" | Where-Object name -eq $OfferName
        }
    }
}


function New-Subscription
{
    param
    (
        [String] $SubscriptionUser,

        [Parameter(Mandatory=$true)]
        [String] $OfferId
    )


    if ($SubscriptionUser)
    {
        $subDisplayName = "Test User-$SubscriptionUser"
        $subscription = New-AzsTenantSubscription -Owner $SubscriptionUser -OfferId $OfferId -DisplayName $subDisplayName
    }
    else
    {
        $userName = (Get-AzureRMContext).Account.Id
        $subDisplayName = "Test User-$userName"
        $subscription = New-AzsSubscription  -OfferId $OfferId -DisplayName $subDisplayName
    }

    Assert-True { $subscription.DisplayName -eq $subDisplayName } | Out-Null
    $Global:CreatedSubscriptions += @{
        SubscriptionId = $subscription.SubscriptionId
        }

    if ($SubscriptionUser)
    {
        Retry-Function -ScriptBlock {
            (Get-AzsTenantSubscription -SubscriptionId $subscription.SubscriptionId).State -ieq "Enabled"
        } -MaxTries 12 -IntervalInSeconds 5 | Out-Null
    }
    else
    {
        Retry-Function -ScriptBlock {
            (Get-AzsSubscription)[0].State -ieq "Enabled"
        } -MaxTries 12 -IntervalInSeconds 5 | Out-Null
    }

    Write-Verbose "Successfully created the subscription for user : $SubscriptionUser"
    return $subscription
}

function Remove-Subscription
{
   param
   (
       [Parameter(Mandatory=$true)]
       [String] $TargetSubscriptionId
   )
    Write-Verbose "Deleting the subscription : $TargetSubscriptionId"

    $subscription = Get-AzsTenantSubscription -SubscriptionId $TargetSubscriptionId
    Remove-AzsTenantSubscription -SubscriptionId $TargetSubscriptionId

    Assert-SubscriptionDeletion {Get-AzsTenantSubscription -SubscriptionId $TargetSubscriptionId}
    Write-Verbose "Successfully deleted the subscription : $TargetSubscriptionId"
}

function Get-TenantPublicOffers
{
 param
    (
        [Parameter(Mandatory=$true)]
        [String] $Token
    )

     return Get-AzsOffer -Provider "default"
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
}

function Unregister-ResourceProvider
{
    param
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Namespaces
    )

    foreach ($namespace in $Namespaces)
    {
        Unregister-AzureRmResourceProvider -ProviderNamespace $Namespace -Force
    }
}

