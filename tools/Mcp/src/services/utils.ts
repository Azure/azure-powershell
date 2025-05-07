import fs from 'fs';
import yaml from "js-yaml";
import { yamlContent } from '../types.js';
import { exec } from 'child_process';

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

export function generateAndBuild(workingDirectory: string): void {
    const command = [_pwshCD(workingDirectory), _autorest, _pwshBuild].join(";");
    exec(command);
}

export function getYamlContentFromReadMe(readmePath: string): yamlContent {
    const readmeContent = fs.readFileSync(readmePath, 'utf8');
    const yamlRegex = /```(?:\w+)?\r?\n(?<yaml>[\s\S]*?)\r?\n```/g;
    const matches = [...readmeContent.matchAll(yamlRegex)];
    if (!matches || matches.length === 0 || !matches[0].groups?.yaml) {
        throw new Error("No yaml code block found in the README file.");
    }
    const yamlContent =  matches[0].groups?.yaml;
    return yaml.load(yamlContent) as yamlContent;
}