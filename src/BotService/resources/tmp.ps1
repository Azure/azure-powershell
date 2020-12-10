# create logic
new-azbotservice -Debug -resourcegroupname wyunchi-botservice -name wyunchi-bot1 -ApplicationId "528b263a-4085-4051-92d0-3fd027775e8e"-Location eastus -Sku F0 -Description "123134" -Registration

# deploy logic
Invoke-AzBotServicePrepareDeploy -Language 'C#' -CodeDir .\tmp\ -ProjFilePath a.csproj
Compress-Archive .\wyunchi-test-bot\* wyunchi-test-bot.zip
Import-Module Az.Websites
Publish-AzWebApp -ArchivePath .\wyunchi-test-bot.zip -ResourceGroupName wyunchi-botservice -Name wyunchi-bot1