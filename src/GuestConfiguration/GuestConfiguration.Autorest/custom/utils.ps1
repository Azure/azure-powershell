function TransformPSBoundParameters{
    [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        $PSBoundParameters
    )
    if($PSBoundParameters.ContainsKey("InputObject") -and $null -ne $PSBoundParameters["InputObject"]){
        $Id = $PSBoundParameters["InputObject"].Id
        if($Id -match "/subscriptions/(?<subId>.+)/resourceGroups/(?<rgName>.+)/providers/Microsoft.Compute/virtualMachines/(?<vmName>.+)/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/(?<guestConfigurationAssignmentName>.+)"){
            # Is a VM assignment
            $PSBoundParameters.Add("SubscriptionId", $Matches.subId)
            $PSBoundParameters.Add("ResourceGroupName", $Matches.rgName)
            $PSBoundParameters.Add("VMName", $Matches.vmName)
            $PSBoundParameters.Add("Name", $Matches.guestConfigurationAssignmentName)
        }elseif($Id -match "/subscriptions/(?<subId>.+)/resourceGroups/(?<rgName>.+)/providers/Microsoft.HybridCompute/machines/(?<machineName>.+)/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/(?<guestConfigurationAssignmentName>.+)"){
            # Is a HybridCompute machines assignment
            $PSBoundParameters.Add("SubscriptionId", $Matches.subId)
            $PSBoundParameters.Add("ResourceGroupName", $Matches.rgName)
            $PSBoundParameters.Add("MachineName", $Matches.machineName)
            $PSBoundParameters.Add("Name", $Matches.guestConfigurationAssignmentName)
        }elseif($Id -match "/subscriptions/(?<subId>.+)/resourceGroups/(?<rgName>.+)/providers/Microsoft.Compute/virtualMachineScaleSets/(?<vmssName>.+)/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/(?<guestConfigurationAssignmentName>.+)"){
            # Is a virtualMachineScaleSets assignment
            $PSBoundParameters.Add("SubscriptionId", $Matches.subId)
            $PSBoundParameters.Add("ResourceGroupName", $Matches.rgName)
            $PSBoundParameters.Add("VmssName", $Matches.vmssName)
            $PSBoundParameters.Add("Name", $Matches.guestConfigurationAssignmentName)
        }else {
            throw "Unrecogized InputObject"
        }
       $null = $PSBoundParameters.Remove("InputObject")
    }
    return $PSBoundParameters
}

