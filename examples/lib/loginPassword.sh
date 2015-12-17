#!/bin/bash
set -e
printf "\n=== Login as user ===\n"

printf "\n=== Logging in with username %s and password ***** ===\n" "$azureUser" 
azure account add -u "$azureUser" -p "$password"