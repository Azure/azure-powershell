const mappings = require('./src/Accounts/Accounts/AzureRmAlias/Mappings.json');
const fs = require('fs');

const newMappings = { commands: {} };

for (var module in mappings) {
    for (var cmdlet in mappings[module]) {
        newMappings.commands[cmdlet] = { module };
    }
}

fs.writeFileSync('./src/Accounts/Accounts/Utilities/CommandMappings.json', JSON.stringify(newMappings));