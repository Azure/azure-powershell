
function Get-ResourceNameSuffix {
    param(
        [string]$ResourceName
    )
    if ($null -ne $ResourceName -and $ResourceName.Contains('/')) {
        $ResourceName = $ResourceName.Split("/")[-1]
    }
    return $ResourceName
}
