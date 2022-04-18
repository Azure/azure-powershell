#!/bin/bash -i

# This script is created to set up the env to generate Azure PowerShell modules based on swagger. 

# Installed required packages
sudo apt-get update \
    && sudo apt-get install -y curl \
    && sudo apt-get install -y dotnet-sdk-2.1 \
    && curl -o- https://raw.githubusercontent.com/creationix/nvm/v0.33.11/install.sh | bash \
    && export NVM_DIR="$HOME/.nvm" \
    && [ -s "$NVM_DIR/nvm.sh" ] && \. "$NVM_DIR/nvm.sh" \
    && [ -s "$NVM_DIR/bash_completion" ] && \. "$NVM_DIR/bash_completion" \
    && nvm install 14.15.5 \
    && npm config set unsafe-perm true \
    && npm install -g autorest

# Write $PATH and some other envs to a file for later usage

echo "{\"envs\":{\"PATH\":\"$PATH\",\"DOTNET_SKIP_FIRST_TIME_EXPERIENCE\":1}}" > $2
