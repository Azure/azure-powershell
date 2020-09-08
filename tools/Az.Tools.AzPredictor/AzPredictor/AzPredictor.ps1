$version = $PSVersionTable.PSVersion

function PSConsoleHostPredictor
{
    Microsoft.PowerShell.Core\Set-StrictMode -Off

    $options = Get-PSReadLineOption
    $predictionColor = $options.PredictionColor
    $predictionColor = $predictionColor.Replace("m", ";7m")
    Set-PSReadLineOption -Colors @{ "Prediction" = $predictionColor }

    # Only use plugin
    Set-PSReadLineOption -PredictionSource Plugin
    # Use history and plugin
    # Set-PSReadlineOption -PredictionSource HistoryAndPlugin

    # Show the prediction inline
    Set-PSReadLineOption -PredictionViewStyle InlineView
    # Show the prediction in a list
    # Set-PSReadLineOption -PredictionViewStyle ListView
}

PSConsoleHostPredictor
