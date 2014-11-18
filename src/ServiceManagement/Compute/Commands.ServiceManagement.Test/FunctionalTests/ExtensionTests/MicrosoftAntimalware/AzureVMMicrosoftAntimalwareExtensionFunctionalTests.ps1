# preview of scenario tests for (Get/Set)-AzureVMMicrosoftAntimalwareExtension
# next action is to automate as unit tests in the test project 

$service_name = ""
$storage_account_name = ""
$path_to_xml_config = ""

Import-Module 'C:\Program Files (x86)\Microsoft SDKs\Azure\PowerShell\ServiceManagement\Azure\Azure.psd1'

#help - should see get/remove/set
help *vm*antimalware* 
get-help Get-AzureVMMicrosoftAntimalwareExtension -full
get-help Set-AzureVMMicrosoftAntimalwareExtension -full
get-help Remove-AzureVMMicrosoftAntimalwareExtension -full

#Enable antimalware using a ConfigFile parameter (do not enable event monitoring)
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Set-AzureVMMicrosoftAntimalwareExtension -AntimalwareConfigFile $path_to_xml_config | Update-AzureVM

#Get Microsoft Antimalware Extension configuration information and review
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMMicrosoftAntimalwareExtension

#Enable antimalware using a ConfigFile parameter and enable monitoring via parameters
$path_to_xml_config = "C:\test\AntimalwareConfig.xml"
$storage_context = New-AzureStorageContext -StorageAccountName $storage_account_name -StorageAccountKey (Get-AzureStorageKey $storage_account_name).Primary
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Set-AzureVMMicrosoftAntimalwareExtension -AntimalwareConfigFile $path_to_xml_config -Monitoring ON -StorageContext $storage_context | Update-AzureVM

#Get Microsoft Antimalware Extension configuration information and review
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMMicrosoftAntimalwareExtension

#Set monitoring OFF via parameter
$path_to_xml_config = "C:\test\AntimalwareConfig.xml"
$storage_context = New-AzureStorageContext -StorageAccountName $storage_account_name -StorageAccountKey (Get-AzureStorageKey $storage_account_name).Primary
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Set-AzureVMMicrosoftAntimalwareExtension -AntimalwareConfigFile $path_to_xml_config -Monitoring OFF -StorageContext $storage_context | Update-AzureVM 

#Get Microsoft Antimalware Extension configuration information and review
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMMicrosoftAntimalwareExtension

#Enable antimalware using XmlDocument parameter 
$path_to_xml_config = "C:\test\AntimalwareConfig.xml"
[System.Xml.XmlDocument] $xml_config = new-object System.Xml.XmlDocument
$xml_config.load($path_to_xml_config)
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Set-AzureVMMicrosoftAntimalwareExtension -AntimalwareConfiguration $xml_config | Update-AzureVM

#Get Microsoft Antimalware Extension configuration information and review
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMMicrosoftAntimalwareExtension

#Disable the extension
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Set-AzureVMMicrosoftAntimalwareExtension -Disable | Update-AzureVM

#Get Microsoft Antimalware Extension configuration information and review
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMMicrosoftAntimalwareExtension

#remove antimalware monitoring extension
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Remove-AzureVMMicrosoftAntimalwareExtension | Update-AzureVM 

#Get status of all extensions on the service using general purpose cmdlet  (confirm absence of extension after remove)
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMExtension

#Uninstall the extension 
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Set-AzureVMMicrosoftAntimalwareExtension -Uninstall | Update-AzureVM

#Get Microsoft Antimalware Extension configuration information and review
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMMicrosoftAntimalwareExtension

#Explicitly uninstall the diagnostics extension 
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Set-AzureVMExtension -ExtensionName "IaaSDiagnostics" -Publisher "Microsoft.Azure.Diagnostics" -Version 1.1 -Uninstall | Update-AzureVM

#Get Microsoft Antimalware Extension configuration information and review
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMMicrosoftAntimalwareExtension

#Get status of all extensions on the service using general purpose cmdlet
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMExtension

#Get Microsoft Antimalware Extension configuration information and review
(Get-AzureVM -ServiceName $service_name -Name $service_name) | Get-AzureVMMicrosoftAntimalwareExtension


#Check storage account for presence of antimalware events

# export to csv file 
Function GetMonitoringCsv
{ 
 Param(
  [string]$storage_account_name,
  [string]$csv_output_file = "c:\test\test.csv"
 ) 

$subscription_name = (Get-AzureSubscription -Default).SubscriptionName

Set-AzureSubscription -SubscriptionName $subscription_name -CurrentStorageAccountName $storage_account_name

$keys = Get-AzureStorageKey -StorageAccountName $storage_account_name
$storage_account_key = $keys.Primary

$tableName = (Get-AzureStorageTable -Prefix "WADWindowsEventLogs").Name;
if ($tableName)
{
    $blob_endpoint = "https://" + $storage_account_name + ".blob.core.windows.net/";
    $queue_endpoint = "https://" + $storage_account_name + ".queue.core.windows.net/";
    $table_endpoint = "https://" + $storage_account_name + ".table.core.windows.net/"

    $stg = New-Object Microsoft.WindowsAzure.Storage.CloudStorageAccount( 
        (New-Object Microsoft.WindowsAzure.Storage.Auth.StorageCredentials($storage_account_name, $storage_account_key)),
        $blob_endpoint, $queue_endpoint, $table_endpoint)

    $cloudTableClient = $stg.CreateCloudTableClient()
    $cloudTableData = $cloudTableClient.GetTableReference($tableName)
    $query = New-Object Microsoft.WindowsAzure.Storage.Table.TableQuery
    $response = $cloudTableData.ExecuteQuery($query) 

    #extract out the relevant information 
    $results = New-Object System.Collections.ArrayList 
    foreach ($row in $response)
    {
        $obj = new-object psobject
        Add-Member -InputObject $obj -MemberType NoteProperty -Name "Timestamp" -Value $row.Properties.TIMESTAMP.PropertyAsObject.ToOADate()
        Add-Member -InputObject $obj -MemberType NoteProperty -Name "EventId" -Value $row.Properties.EventId.Int32Value
        Add-Member -InputObject $obj -MemberType NoteProperty -Name "Role" -Value $row.Properties.Role.StringValue
        Add-Member -InputObject $obj -MemberType NoteProperty -Name "RoleInstance" -Value $row.Properties.RoleInstance.StringValue
        Add-Member -InputObject $obj -MemberType NoteProperty -Name "Description" -Value $row.Properties.Description.StringValue.replace("`n","").replace("`r","")

        $total = $results.Add($obj)
    } 

    Write-Host $total 'rows exported to csv output file (' $csv_output_file ')'

    #export to csv 
    $results | Export-Csv -path $csv_output_file -NoTypeInformation
}
else
{
    Write-Host 'no data found in storage account' 
    Write-Host $storage_account_name
}
}

GetMonitoringCsv $storage_account_name
