
function Get-ResourceNameSuffix {
    param(
        [System.String]$ResourceName
    )
    if ($null -ne $ResourceName -and $ResourceName.Contains('/')) {
        $ResourceName = $ResourceName.Split("/")[-1]
    }
    return $ResourceName
}
