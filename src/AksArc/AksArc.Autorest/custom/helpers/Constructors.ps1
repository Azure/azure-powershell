function CreateAgentPoolProfile {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [System.Int32] ${MinCount}, 
        [System.Int32] ${MaxCount}, 
        [System.Management.Automation.SwitchParameter] ${EnableAutoScaling}, 
        [System.Int32] ${MaxPod}, 
        [System.String[]] $NodeTaint,
        [System.Collections.Hashtable] $NodeLabel
    )

    $AgentPoolProfile = [Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.AgentPoolProfile]::New()
    $AgentPoolProfile.MinCount = $MinCount
    $AgentPoolProfile.MaxCount = $MaxCount
    $AgentPoolProfile.EnableAutoScaling = $EnableAutoScaling
    $AgentPoolProfile.MaxPod = $MaxPod
    $AgentPoolProfile.NodeTaint = $NodeTaint
    $AgentPoolProfile.NodeLabel = $NodeLabel

    return $AgentPoolProfile
}