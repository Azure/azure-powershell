function Disable-AzAdvisorRecommendation{
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IResourceRecommendationBase])]
[CmdletBinding(DefaultParameterSetName='IdParameterSet', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='IdParameterSet', Mandatory, HelpMessage='Id of the recommendation to be suppressed.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Path')]
    [System.String]
    ${ResourceId},

    [Parameter(ParameterSetName='NameParameterSet', Mandatory, HelpMessage='ResourceName of the recommendation.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Path')]
    [System.String]
    ${RecommendationName},

    [Parameter(ParameterSetName='InputObjectParameterSet', Mandatory, HelpMessage='The powershell object type PsAzureAdvisorResourceRecommendationBase returned by Get-AzAdvisorRecommendation call.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity]
    ${InputObject},

    [Parameter(ParameterSetName='InputObjectParameterSet',  HelpMessage="Days to disable.")]
    [Parameter(ParameterSetName='IdParameterSet',  HelpMessage="Days to disable.")]
    [Parameter(ParameterSetName='NameParameterSet',  HelpMessage="Days to disable.")]
    [ValidateRange("Positive")]
    ${Day}
)
process{
    $DefaultSuppressionName = "HardcodedSuppressionName"
    switch ($PSCmdlet.ParameterSetName) {
        'NameParameterSet' {
            $ResourceUri = "subscriptions/" + (Get-AzContext).Subscription.Id
            $Recommendation= Az.Advisor.internal\Get-AzAdvisorRecommendation -ResourceUri $ResourceUri -Id $RecommendationName
            $ResourceId = $Recommendation.Id
            break
        }
        'InputObjectParameterSet' {
            $ResourceId = $InputObject.Id
            break
        }
    }
    if ($ResourceId.Contains("providers/Microsoft.Advisor")){
        $EndIndex = $ResourceId.IndexOf("providers/Microsoft.Advisor") - 2
        $ResourceUri= $ResourceId.Substring(1, $EndIndex)
    }
    $ResourceIdSplit = $ResourceId.Split('/')
    if ($ResourceIdSplit[$ResourceIdSplit.Length - 2].Equals("recommendations"))
    {
        $RecommendationId = $ResourceIdSplit[$ResourceIdSplit.Length - 1]
    }
    if (!$Day) {$Ttl = ""} 
    else
    {$Ttl = (New-Timespan -Days $Day).ToString("dd\:hh\:mm\:ss")}
    Az.Advisor.internal\New-AzAdvisorSuppression -Name $DefaultSuppressionName -RecommendationId $RecommendationId -ResourceUri $ResourceUri -Ttl $Ttl

}
}