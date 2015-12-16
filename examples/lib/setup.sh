#!/bin/bash
# Login
login() {
    echo "Executing Login..."
    export CmdletSessionId=1010
    azure account add --username $azureuser --password $azurepassword
}

cleanup() {
    set +e
    printf "\nCleanup: removing resource group: %s\n" $groupName
    azure group remove --name "$groupName" --force
    set -e
}

export -f login 
export -f cleanup 