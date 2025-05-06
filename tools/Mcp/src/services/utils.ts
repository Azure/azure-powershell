import fs from 'fs';
import yaml from "js-yaml";
import { exec } from 'child_process';
import { start } from 'repl';

const _pwshCD = (path: string): string => { return `pwsh -Command "$path = resolve-path ${path} | Set-Location"` }
const _autorest = "autorest --reset; autorest"
const _pwshBuild = "pwsh -File build-module.ps1"

function testYaml() {
    const data = {
        name: 'John Doe',
        age: 30,
        skills: ['TypeScript', 'Node.js']
      };
      
      const yamlData = yaml.dump(data);
      
      fs.writeFileSync('./testYaml.yaml', yamlData, 'utf8');
}

export function generateAndBuild(workingDirectory: string) {
    const command = [_pwshCD(workingDirectory), _autorest, _pwshBuild].join(";");
    exec(command);
}

 export function getYamlContentFromReadMe(readmePath: string) {
    const readmeContent = fs.readFileSync(readmePath, 'utf8');
    const startSign = "``` yaml";
    const endSign = "```";
    const startIndex = readmeContent.indexOf(startSign) + startSign.length;
    const endIndex = readmeContent.indexOf(endSign, startIndex);
    const yamlContent = readmeContent.substring(startIndex, endIndex).trim();
    return yamlContent
    return yaml.load(yamlContent);
}