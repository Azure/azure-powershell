# path to the help/docs folder
param([string]$path = './')

# laad platyps dll
$null = [Reflection.Assembly]::LoadFile((Join-Path $PSScriptRoot "Markdown.MAML.dll"))

$parser = new-object Markdown.MAML.Parser.MarkdownParser
$transformer = new-object Markdown.MAML.Transformer.ModelTransformerVersion2
#$renderer = new-object Markdown.MAML.Renderer.MamlRenderer

$failedHelps = @()

$MarkdownFiles = Get-ChildItem $path
foreach ($item in $MarkdownFiles) {
    if($item.Name.StartsWith("Az.") -or $item.Name.StartsWith("readme")) {
        continue
    }
    try {
        $markdown = Get-Content $item.VersionInfo.FileName -Raw
        $m = [string[]] @("$markdown")
        $markdownModel = $parser.ParseString($m)
        $null = $transformer.NodeModelToMamlModel($markdownModel)
    } catch {
        $failedHelps = $failedHelps + $item.Name
    }
}
if ($failedHelps.Count -gt 0) {
    $errorMsg = "PlatyPS schema check failed for {0}" -f ($failedHelps -join ",")
    Write-Error $errorMsg
} else {
    Write-Host "PlatyPS check passesd"
}