import fs from 'fs';
import yaml from "js-yaml";
import { yamlContent } from '../types.js';
import { exec } from 'child_process';
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
    const command = [_pwshCD(workingDirectory), _autorest, _pwshBuild].join(";");
    exec(command);
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








































export async function testCase() {
    // const swaggerUrl = 'https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f1546dc981fa5d164d7ecd13588520457462c22c/specification/vmware/resource-manager/Microsoft.AVS/stable/2023-09-01/vmware.json'
    // const polymorphism = new Map<string, Set<string>>();

    // let swaggerContent: any;
    // try {
    //     const response = await fetch(swaggerUrl);
        
    //     if (!response.ok) {
    //         throw new Error(`HTTP error! status: ${response.status}`);
    //     }    
    //     swaggerContent = await response.json();
    //     //console.log('Swagger content:', swaggerContent);
    // } catch (error) {
    //     console.error('Error fetching swagger content:', error);
    //     throw error;
    // }
    // const definitions = swaggerContent.definitions;
    // for (const key of Object.keys(definitions)) {
    //     if (definitions[key]['x-ms-discriminator-value']) {
    //         const parent = definitions[key]['allOf']?.[0]['$ref']?.split('/').pop();
    //         if (!polymorphism.has(parent)) {
    //             polymorphism.set(parent, new Set<string>());
    //         }
    //         polymorphism.get(parent)?.add(key);
    //     }
    // }
    // for (const [k, v] of polymorphism) {
    //     console.log(`Parent: ${k}, Children: ${Array.from(v)}`);
    // }

    // const parents = Array.from(polymorphism.keys());
    // const children = Array.from(polymorphism.values()).map(set => Array.from(set)).flat();
    // console.log("Parents:", parents);
    // console.log("Children:", children);
    const polymorphism = await findAllPolyMorphism("c:\\workspace\\azure-powershell\\src\\VMware\\VMware.Autorest");
    const parents = Array.from(polymorphism.keys());
    const children = Array.from(polymorphism.values()).map(set => Array.from(set)).flat();
    console.log("Parents:", parents);
    console.log("Children:", children);
}