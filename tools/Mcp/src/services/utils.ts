import fs from 'fs';
import yaml from "js-yaml";
import { yamlContent } from '../types.js';
import { execSync } from 'child_process';
import path from 'path';

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
    const genBuildCommand = `${_pwshCD(workingDirectory)}; ${_autorest}; ${_pwshBuild};"`;
    try {
        const result = execSync(genBuildCommand, { stdio: 'inherit' });
    } catch (error) {
        console.error("Error executing command:", error);
        throw error;
    }
}

export function getYamlContentFromReadMe(readmePath: string): string {
    const readmeContent = fs.readFileSync(readmePath, 'utf8');
    const yamlRegex = /```\s*yaml(?:\w+)?\r?\n?(?<yaml>[\s\S]*?)\r?\n```/g;
    const matches = [...readmeContent.matchAll(yamlRegex)];
    if (!matches || matches.length === 0 || !matches[0].groups?.yaml) {
        throw new Error("No yaml code block found in the README file.");
    }
    return matches[0].groups?.yaml;
}

export function dumpYamlContentToReadMe(readmePath: string, yamlContent: yamlContent): void {
    const yamlString = yaml.dump(yamlContent);
    const readmeContent = fs.readFileSync(readmePath, 'utf8');
    const yamlRegex = /```\s*yaml(?:\w+)?\r?\n?(?<yaml>[\s\S]*?)\r?\n```/g;
    const newReadmeContent = readmeContent.replace(yamlRegex, `\`\`\`yaml\n${yamlString}\n\`\`\``);
    fs.writeFileSync(readmePath, newReadmeContent, 'utf8');
}

export function getSwaggerUrl(commit: string, filePaths: string[]): string[] {
    const swaggerBaseUrl = 'https://raw.githubusercontent.com/Azure/azure-rest-api-specs';
    const swaggerUrls: string[] = [];
    for (let filePath of filePaths) {
        filePath = filePath.replace("$(repo)/", "");
        const swaggerUrl = `${swaggerBaseUrl}/${commit}/${filePath}`;
        swaggerUrls.push(swaggerUrl);
    }
    return swaggerUrls;
}

export async function getSwaggerContentFromUrl(swaggerUrl: string): Promise<any> {
    try {
        const response = await fetch(swaggerUrl);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }    
        return await response.json();
    } catch (error) {
        console.error('Error fetching swagger content:', error);
        throw error;
    }
}

export async function findAllPolyMorphism(workingDirectory: string): Promise<Map<string, Set<string>>> {
    const polymorphism = new Map<string, Set<string>>();
    const moduleReadmePath = path.join(workingDirectory, "README.md");
    const yamlContent: yamlContent = yaml.load(getYamlContentFromReadMe(moduleReadmePath)) as yamlContent;
    const swaggerUrls = getSwaggerUrl(yamlContent.commit, yamlContent['input-file'] as string[]);
    for (const url of swaggerUrls) {
        const definitions = (await getSwaggerContentFromUrl(url))['definitions'];    
        for (const key of Object.keys(definitions)) {
            if (!definitions[key]['x-ms-discriminator-value']) {
                continue;
            }
            const parent = definitions[key]['allOf']?.[0]['$ref']?.split('/').pop();
            if (!polymorphism.has(parent)) {
                polymorphism.set(parent, new Set<string>());
            }
            polymorphism.get(parent)?.add(key);
        }
    }
    return polymorphism;
}

export async function getExamplesFromSpecs(workingDirectory: string): Promise<string> {
    const moduleReadmePath = path.join(workingDirectory, "README.md");
    const yamlContent: yamlContent = yaml.load(getYamlContentFromReadMe(moduleReadmePath)) as yamlContent;

    if (!yamlContent['input-file']) {
        throw new Error("'input-file' field is missing in the 'README.md' Autorest Config file.");
    }

    const inputFiles = Array.isArray(yamlContent['input-file']) ? yamlContent['input-file'] : [yamlContent['input-file']];
    const swaggerUrls = getSwaggerUrl(yamlContent.commit, inputFiles);
    const exampleSet: Set<string> = new Set<string>();
    
    const exampleSpecsPath = path.join(workingDirectory, "exampleSpecs");
    if (!fs.existsSync(exampleSpecsPath)) {
        fs.mkdirSync(exampleSpecsPath);
    }

    for (const url of swaggerUrls) {
        // Convert raw GitHub URL to directory path
        // From: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/commit/path/to/file.json
        // To: https://api.github.com/repos/Azure/azure-rest-api-specs/contents/path/to/examples?ref=commit
        
        const urlParts = url.split('/');
        const owner = urlParts[3]; // The owner, e.g., Azure
        const repo = urlParts[4]; // The repository name, e.g., azure-rest-api-specs
        const commit = urlParts[5]; // The commit hash
        const pathParts = urlParts.slice(6); // Everything after commit
        pathParts.pop(); // Remove the filename
        const directoryPath = pathParts.join('/');
        const examplesPath = directoryPath + '/examples';
        
        const apiUrl = `https://api.github.com/repos/${owner}/${repo}/contents/${examplesPath}?ref=${commit}`;
        
        try {
            const response = await fetch(apiUrl);
            if (!response.ok) {
                console.warn(`No examples directory found at ${apiUrl}`);
                continue;
            }
            
            const list = await response.json();
            for (const ex of list) {
                if (!exampleSet.has(ex.download_url)) {
                    const exResponse = await fetch(ex.download_url);
                    if (!exResponse.ok) {
                        console.warn(`Invalid file at ${ex.download_url}`);
                        continue;
                    }
                    const exJson = await exResponse.json();
                    const exampleFileName = path.join(exampleSpecsPath, `${ex.name}`);
                    fs.writeFileSync(exampleFileName, JSON.stringify(exJson, null, 2), 'utf8');
                    console.log(`Example saved to ${exampleFileName}`);
                    exampleSet.add(ex.download_url);
                }
            }
        } catch (error) {
            console.error(`Error fetching examples from ${apiUrl}:`, error);
        }
    }
    return exampleSpecsPath;
}








































export async function testCase() {
    const polymorphism = await getExamplesFromSpecs("d:\\workspace\\azure-powershell\\src\\VMware\\VMware.Autorest");
}