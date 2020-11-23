<h1>Mapping from ADLS Gen1 Cmdlets -> ADLS Gen2 Cmdlets</h1>
<table>
    <thead>
        <tr>
            <th>ADLS Gen1 Cmdlet</th>
            <th>ADLS Gen2 Cmdlet</th>
            <th>Notes</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Add-AzDataLakeStoreItemContent</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Export-AzDataLakeStoreChildItemProperty</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Export-AzDataLakeStoreItem</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Get-AzDataLakeStoreChildItem</td>
            <td>Get-AzDataLakeGen2ChildItem</td>
            <td>By default Get-AzDataLakeGen2ChildItem will only list the first level child items. With “-Recurse” will list child items recursively.</td>
        </tr>
        <tr>
            <td>Get-AzDataLakeStoreChildItemSummary</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Get-AzDataLakeStoreItem</td>
            <td rowspan=4>Get-AzDataLakeGen2Item</td>
            <td rowspan=4>The output items of Get-AzDataLakeGen2Item has properties: Acl, Owner, Group, Permission.</td>
        </tr>
        <tr>
            <td>Get-AzDataLakeStoreItemAclEntry</td>
        </tr>
        <tr>
            <td>Get-AzDataLakeStoreItemOwner</td>
        </tr>
        <tr>
            <td>Get-AzDataLakeStoreItemPermission</td>
        </tr>
        <tr>
            <td>Get-AzDataLakeStoreItemContent</td>
            <td>Get-AzDataLakeGen2FileContent</td>
            <td>Get-AzDataLakeGen2FileContent will download File content to local file.</td>
        </tr>
        <tr>
            <td>Import-AzDataLakeStoreItem</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Join-AzDataLakeStoreItem</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Move-AzDataLakeStoreItem</td>
            <td>Move-AzDataLakeGen2Item</td>
            <td></td>
        </tr>
        <tr>
            <td>New-AzDataLakeStoreItem</td>
            <td>New-AzDataLakeGen2Item</td>
            <td>Create a File with New-AzDataLakeGen2Item, will upload the new File content from a local file.</td>
        </tr>
        <tr>
            <td>Remove-AzDataLakeStoreItem</td>
            <td>Remove-AzDataLakeGen2Item</td>
            <td></td>
        </tr>
        <tr>
            <td>Set-AzDataLakeStoreItemOwner</td>
            <td rowspan=3>Update-AzDataLakeGen2Item</td>
            <td rowspan=2>Update-AzDataLakeGen2Item only update single item, not recursively. (If want to update recursively, list items recursively with Get-AzDataLakeStoreChildItem, then pipeline to Update-AzDataLakeGen2Item.)</td>
        </tr>
        <tr>
            <td>Set-AzDataLakeStoreItemPermission</td>
        </tr>
        <tr>
            <td>Set-AzDataLakeStoreItemAcl</td>
			<td>To update Acl with Update-AzDataLakeGen2Item, prepare the ACL object with cmdlet New-AzDataLakeGen2ItemAclObject.</td>
        </tr>
        <tr>
            <td>Remove-AzDataLakeStoreItemAcl</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Remove-AzDataLakeStoreItemAclEntry</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Set-AzDataLakeStoreItemAclEntry</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Set-AzDataLakeStoreItemExpiry</td>
            <td>N/A</td>
            <td></td>
        </tr>
        <tr>
            <td>Test-AzDataLakeStoreItem</td>
            <td>Get-AzDataLakeGen2Item</td>
            <td>Get-AzDataLakeGen2Item will report error when get not exist item.</td>
        </tr>
        <tr>
            <td>N/A</td>
            <td>New-AzDatalakeGen2FileSystem</td>
            <td rowspan=3>New cmdlets in Gen2, to manage File System. They are actually cmdlet alias of blob container cmdlets.</td>
        </tr>
        <tr>
            <td>N/A</td>
            <td>Get-AzDatalakeGen2FileSystem</td>
        </tr>
        <tr>
            <td>N/A</td>
            <td>Remove-AzDatalakeGen2FileSystem</td>
        </tr>
        <tr>
            <td>N/A</td>
            <td>New-AzDataLakeGen2ItemAclObject </td>
            <td>New cmdlet in Gen2, to prepare the Acl object, which will be used in cmdlet Update-AzDataLakeGen2Item.</td>
        </tr>
    </tbody>
</table>