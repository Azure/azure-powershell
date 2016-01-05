#!/bin/bash
printf "\n=== Managing Web Apps in Azure ===\n"

#setup
login() {
    echo "Executing Login..."
    export CmdletSessionID=1010
    azure account add --username $azureuser --password $azurepassword
}
export -f login
randomName() {
    echo "$1$RANDOM"
} 
export -f randomName 
login
export groupName=`randomName testrg`
export location="westus"

printf "\nSetup: Creating a new resource group: %s at location: %s.\n" "$groupName" "$location"
azure group create --name "$groupName" --location "$location"

appName1=`randomName testweb`
appName2=`randomName testweb`
appName3=`randomName testweb`
appName4=`randomName testweb`
slotname1="staging"
slotname2="testing"
planName1=`randomName testplan`
planName2=`randomName testplan`
planName3=`randomName testplan`
planName4=`randomName testplan`
tier1="Shared"
tier2="Standard"
tier3="Premium"

printf "\nSetup: Creating a new app service plan: %s under resource group: %s.\n" "$planName1" "$groupName"
serverFarm=`azure app service plan create -n "$planName1" -g "$groupName" -l "$location" --tier "$tier1"`

printf "\n1: Creating a new webapp: %s under resource group: %s.\n" "$appName1" "$groupName"
actual1=`azure webapp create -g "$groupName" -l "$location" -n "$appName1" --plan "$planName1"`

printf "\n2: Getting info about webapp: %s.\n" "$appName1"
result=`azure webapp get -g "$groupName" -n "$appName1"`
[ $(echo $result | jq '.Name' --raw-output) == "$appName1" ]
[ $(echo $result | jq '.serverFarmId' --raw-output) == $(echo $serverFarm | jq '.id' --raw-output) ]

printf "\n3: Creating a new webapp: %s under resource group: %s.\n" "$appName2" "$groupName"
actual2=`azure webapp create -g "$groupName" -l "$location" -n "$appName2" --plan "$planName1"`
[ $(echo $actual2 | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $actual2 | jq '."properties.serverFarmId"' --raw-output) == $(echo $serverFarm | jq '.id' --raw-output) ]

printf "\n4: Get WebApp by ResourceGroup: %s.\n" "$groupName"
count=`azure webapp get -g "$groupName"`
[ $(echo $count | jq '. | length') -eq 2 ]

printf "\n5: Get WebApp by App Plan :%s.\n" "$planName1"
count=`azure webapp get --plan "$serverFarm"`
[ $(echo $count | jq '. | length') -eq 2 ]

printf "\n6: Creating a new app service plan: %s under resource group: %s.\n" "$planName2" "$groupName"
serverFarm2=`azure app service plan create -n "$planName2" -g "$groupName" -l "$location" --tier "$tier2"`

printf "\n7: Change webapp: %s to new service plan: %s\n" "$appName2" "$planName2"
changePlan=`azure webapp set -g "$groupName" -n $appName2 --plan $planName2`
[ $(echo $changePlan | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $changePlan | jq '."properties.serverFarmId"' --raw-output) == $(echo $serverFarm2 | jq '.id' --raw-output) ]

printf "\n8: Set config properties 'httpLoggingEnabled' & 'requestTracingEnabled' of the webapp: %s to true.\n" "$appName2"
changePlan=`echo $changePlan | jq '."properties.siteConfig"."properties.httpLoggingEnabled"'=true`
changePlan=`echo $changePlan | jq '."properties.siteConfig"."properties.requestTracingEnabled"'=true`
changePlan=`echo $changePlan | azure webapp set`
[ $(echo $changePlan | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $changePlan | jq '."properties.serverFarmId"' --raw-output) == $(echo $serverFarm2 | jq '.id' --raw-output) ]
[ $(echo $changePlan | jq '."properties.siteConfig"."properties.httpLoggingEnabled"' --raw-output) == true ]
[ $(echo $changePlan | jq '."properties.siteConfig"."properties.requestTracingEnabled"' --raw-output) == true ]

printf "\n9: Set appsettings and connectionstrings of the webapp: %s.\n" "$appName2"
appsettings="{\"setting1\":\"valueA\",\"setting2\":\"valueB\"}"
#connectionstrings="{ \"connstring1\": { \"Type\": \"MySql\", \"Value\": \"string value 1\" }, \"connstring2\": { \"Type\": \"SqlAzure\", \"Value\": \"string value 2\" } }"

setconn=`azure webapp set -g "$groupName" -n "$appName2" --appsettings "$appsettings"`
[ $(echo $setconn | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $setconn | jq '."properties.siteConfig"."properties.appSettings" | length') -eq 2 ]

app=`echo $setconn | jq -r '."properties.siteConfig"."properties.appSettings"'`
[ $(echo $app | jq -r '.[0].name') == "setting2" ]
[ $(echo $app | jq -r '.[0].value') == "valueB" ]
[ $(echo $app | jq -r '.[0].name') == "setting1" ]
[ $(echo $app | jq -r '.[0].value') == "valueA" ]

printf "\n9: Stop the webapp: %s.\n" "$appName2"
stop=`azure webapp stop -g "$groupName" -n "$appName2"`
[ $(echo $stop | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $stop | jq '."properties.state"' --raw-output) == "Stopped" ]

printf "\n10: Start the webapp: %s.\n" "$appName2"
start=`azure webapp start -g "$groupName" -n "$appName2"`
[ $(echo $start | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $start | jq '."properties.state"' --raw-output) == "Running" ]

printf "\n11: Stop the webapp: %s again.\n" "$appName2"
stop=`azure webapp stop -g "$groupName" -n "$appName2"`
[ $(echo $stop | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $stop | jq '."properties.state"' --raw-output) == "Stopped" ]

printf "\n12: Start the webapp: %s again.\n" "$appName2"
start=`azure webapp start -g "$groupName" -n "$appName2"`
[ $(echo $start | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $start | jq '."properties.state"' --raw-output) == "Running" ]

printf "\n13: Restart the webapp: %s.\n" "$appName2"
start=`azure webapp restart -g "$groupName" -n "$appName2"`
[ $(echo $start | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $start | jq '."properties.state"' --raw-output) == "Running" ]

printf "\n14: Creating a new app service plan: %s under resource group: %s with Premium tier.\n" "$planName3" "$groupName"
serverFarm3=`azure app service plan create -n "$planName3" -g "$groupName" -l "$location" --tier "$tier3"`
[ $(echo $serverFarm3 | jq '.name' --raw-output) == "$planName3" ]

printf "\n15: Changing plan: %s tp Premium tier.\n" "$planName1"
plan1set=`azure app service plan set -n "$planName1" -g "$groupName" --tier "$tier3"`
[ $(echo $plan1set | jq '.sku.tier' --raw-output) == "$tier3" ]

printf "\n.16: Cloning a new webapp: %s from an existing webapp: %s.\n" "$appName3" "$appName1"
clone=`azure webapp create -g "$groupName" -l "$location" -n "$appName3" --plan "$planName3" --sourcewebapp "$actual1"`
[ $(echo $clone | jq '.name' --raw-output) == "$appName3" ]

printf "\n17: Get the newly created webapp: %s\n." "$appName3"
result3=`azure webapp get -g "$groupName" -n "$appName3"`
[ $(echo $result3 | jq '.name' --raw-output) == "$appName3" ]

printf "\n18: Creating a new app service plan: %s under resource group: %s with Premium tier.\n" "$planName4" "$groupName"
serverFarm4=`azure app service plan create -n "$planName4" -g "$groupName" -l "$location" --tier "$tier3"`
[ $(echo $serverFarm4 | jq '.name' --raw-output) == "$planName4" ]

profileName=`randomName profile`
printf "\n.19: Cloning a new webapp: %s from an existing webapp: %s with traffic manager profile: %s.\n" "$appName4" "$appName3" "profileName"
cloneTraffic=`azure webapp create -g "$groupName" -l "$location" -n "$appName4" --plan "$planName4" --sourcewebapp "$clone" --trafficmanagerprofilename "$profileName"`
[ $(echo $cloneTraffic | jq '.name' --raw-output) == "$appName4" ]

printf "\n20: Get the newly created webapp: %s\n." "$appName4"
result4=`azure webapp get -g "$groupName" -n "$appName4"`
[ $(echo $result4 | jq '.name' --raw-output) == "$appName4" ]

printf "\n21: Get the publish profile for webapp: %s and save it to profile.xml file\n." "$appName4"
pubprof=`azure webapp profile get -g "$groupName" -n "$appName4" --outputfile "profile.xml"`
pswd=`xmllint --xpath 'string(//publishProfile[@publishMethod="MSDeploy"]/@userPWD)' "profile.xml"`
[ `xmllint --xpath 'string(//publishProfile[@publishMethod="MSDeploy"]/@msdeploySite)' "profile1.xml"` == "$appName4" ]

printf "\n22: Reset the publish profile for webapp: %s\n." "$appName4"
azure webapp profile reset -g "$groupName" -n "$appName4"

printf "\n23: Get the publish profile for webapp: %s after resetting and save it to profile1.xml file\n." "$appName4"
pubprof2=`azure webapp profile get -g "$groupName" -n "$appName4" --outputfile "profile1.xml"`
newpswd=`xmllint --xpath 'string(//publishProfile[@publishMethod="MSDeploy"]/@userPWD)' "profile1.xml"`
[ "$newpswd" != "$pswd" ]

printf "\n21: Get the publish profile for webapp: %s in format FileZilla3 and save it to profile2.xml file\n." "$appName4"
azure webapp profile get -g "$groupName" -n "$appName4" --outputfile "profile2.xml" --format "FileZilla3"
[ `xmllint --xpath 'string(//FileZilla3/Servers/Server/Name)' "profile2.xml"` == "$appName4" ]