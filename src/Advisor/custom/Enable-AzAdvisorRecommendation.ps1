function Enable-AzAdvisorRecommendation{
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

    ${InputObject}
)
process{
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
    $SuppressionList = Az.Advisor.internal\Get-AzAdvisorSuppression
    foreach ($Suppression in $SuppressionList) 
    {
        if ($Suppression.Id.Contains($RecommendationId))
        {
            Az.Advisor.internal\Remove-AzAdvisorSuppression -Name $Suppression.Name -RecommendationId $RecommendationId -ResourceUri $ResourceUri
        }
    }
    . Az.Advisor.internal\Get-AzAdvisorRecommendation -ResourceUri $ResourceUri -Id $RecommendationId

}
}