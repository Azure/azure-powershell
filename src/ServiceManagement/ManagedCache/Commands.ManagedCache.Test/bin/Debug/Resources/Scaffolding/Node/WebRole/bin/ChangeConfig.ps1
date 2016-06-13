$configFile = $args[0]

Write-Host "Adding iisnode section to config file '$configFile'"
$config = New-Object System.Xml.XmlDocument
$config.load($configFile)
$xpath = $config.CreateNavigator()
$parentElement = $xpath.SelectSingleNode("//configuration/configSections/sectionGroup[@name='system.webServer']")
$iisnodeElement = $parentElement.SelectSingleNode("//section[@name='iisnode']")
if ($iisnodeElement) {
    Write-Host "Removing existing iisnode section from config file '$configFile'"
    $iisnodeElement.DeleteSelf()
}

$parentElement.AppendChild("<section name=`"iisnode`" />")
$config.Save($configFile)
