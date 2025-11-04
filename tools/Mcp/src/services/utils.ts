import fs from 'fs';
import yaml from "js-yaml";
import { yamlContent } from '../types.js';
import { spawnSync } from 'child_process';
import { logger } from './logger.js';
import path from 'path';
import { Dirent } from 'fs';

const GITHUB_API_BASE = 'https://api.github.com';
const REST_API_SPECS_OWNER = 'Azure';
const REST_API_SPECS_REPO = 'azure-rest-api-specs';

const _pwshCD = (path: string): string => { return `pwsh -Command "$path = resolve-path ${path} | Set-Location"` }
const _autorestReset = "autorest --reset"
const _autorest = "autorest"
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
    const genBuildCommands = [_autorestReset, _autorest, _pwshBuild];
    for (const command of genBuildCommands) {
        logger.info(`Executing command`, { command });
        const [bin, ...args] = command.split(/\s+/);
        const res = spawnSync(bin, args, { cwd: workingDirectory, encoding: 'utf-8' });
        if (res.error) {
            logger.error(`Command spawn error`, { command }, res.error as any);
            throw res.error;
        }
        if (res.status !== 0) {
            logger.error(`Command failed`, { command, status: res.status, stderr: trimLarge(res.stderr) });
            throw new Error(`Command failed: ${command}`);
        }
        if (res.stdout) logger.debug(`Command stdout`, { command, stdout: trimLarge(res.stdout) });
        if (res.stderr) logger.debug(`Command stderr`, { command, stderr: trimLarge(res.stderr) });
        logger.info(`Command finished`, { command });
    }
}

function trimLarge(text: string, max = 4000): string {
    if (!text) return '';
    return text.length > max ? text.slice(0, max) + `...[truncated ${text.length - max}]` : text;
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
        logger.error('Error fetching swagger content', { swaggerUrl }, error as Error);
        throw error;
    }
}

export async function getSpecsHeadCommitSha(branch: string = 'main'): Promise<string> {
    const url = `${GITHUB_API_BASE}/repos/${REST_API_SPECS_OWNER}/${REST_API_SPECS_REPO}/branches/${branch}`;
    const res = await fetch(url);
    if (!res.ok) {
        throw new Error(`Failed to fetch branch '${branch}' info: ${res.status}`);
    }
    const data = await res.json();
    return data?.commit?.sha as string;
}

export async function listSpecModules(): Promise<string[]> {
    const url = `${GITHUB_API_BASE}/repos/${REST_API_SPECS_OWNER}/${REST_API_SPECS_REPO}/contents/specification`;
    const res = await fetch(url);
    if (!res.ok) {
        throw new Error(`Failed to list specification directory: ${res.status}`);
    }
    const list = await res.json();
    return (Array.isArray(list) ? list : [])
        .filter((e: any) => e.type === 'dir')
        .map((e: any) => e.name)
        .sort((a: string, b: string) => a.localeCompare(b));
}

export async function listProvidersForService(service: string): Promise<string[]> {
    const url = `${GITHUB_API_BASE}/repos/${REST_API_SPECS_OWNER}/${REST_API_SPECS_REPO}/contents/specification/${service}/resource-manager`;
    const res = await fetch(url);
    if (!res.ok) {
        // Sometimes service has alternate structure or doesn't exist
        throw new Error(`Failed to list providers for service '${service}': ${res.status}`);
    }
    const list = await res.json();
    return (Array.isArray(list) ? list : [])
        .filter((e: any) => e.type === 'dir')
        .map((e: any) => e.name)
        .sort((a: string, b: string) => a.localeCompare(b));
}

export async function listApiVersions(service: string, provider: string): Promise<{ stable: string[]; preview: string[] }> {
    const base = `specification/${service}/resource-manager/${provider}`;
    const folders = ['stable', 'preview'] as const;
    const result: { stable: string[]; preview: string[] } = { stable: [], preview: [] };
    for (const f of folders) {
        const url = `${GITHUB_API_BASE}/repos/${REST_API_SPECS_OWNER}/${REST_API_SPECS_REPO}/contents/${base}/${f}`;
        const res = await fetch(url);
        if (!res.ok) {
            // ignore missing
            continue;
        }
        const list = await res.json();
        const versions = (Array.isArray(list) ? list : [])
            .filter((e: any) => e.type === 'dir')
            .map((e: any) => e.name)
            .sort((a: string, b: string) => a.localeCompare(b, undefined, { numeric: true }));
        result[f] = versions;
    }
    return result;
}

export async function listSwaggerFiles(service: string, provider: string, stability: 'stable'|'preview', version: string): Promise<string[]> {
    const dir = `specification/${service}/resource-manager/${provider}/${stability}/${version}`;
    const url = `${GITHUB_API_BASE}/repos/${REST_API_SPECS_OWNER}/${REST_API_SPECS_REPO}/contents/${dir}`;
    const res = await fetch(url);
    if (!res.ok) {
        throw new Error(`Failed to list files for ${dir}: ${res.status}`);
    }
    const list = await res.json();
    const files: any[] = Array.isArray(list) ? list : [];
    // Find JSON files; prefer names ending with provider or service
    const jsons = files.filter(f => f.type === 'file' && f.name.endsWith('.json'));
    const preferred = jsons.filter(f => new RegExp(`${provider.split('.').pop()}|${service}`, 'i').test(f.name));
    const ordered = (preferred.length ? preferred : jsons).map(f => f.path);
    return ordered;
}

export async function resolveAutorestInputs(params: {
    service: string;
    provider: string;
    stability: 'stable'|'preview';
    version: string;
    swaggerPath?: string; // optional repo-relative path override
}): Promise<{ serviceName: string; commitId: string; serviceSpecs: string; swaggerFileSpecs: string }> {
    const commitId = await getSpecsHeadCommitSha('main');
    const serviceSpecs = `${params.service}/resource-manager`;
    let swaggerFileSpecs = params.swaggerPath ?? '';
    if (!swaggerFileSpecs) {
        const candidates = await listSwaggerFiles(params.service, params.provider, params.stability, params.version);
        if (candidates.length === 0) {
            throw new Error(`No swagger files found for ${params.service}/${params.provider}/${params.stability}/${params.version}`);
        }
        swaggerFileSpecs = candidates[0];
    }
    return {
        serviceName: params.provider.replace(/^Microsoft\./, ''),
        commitId,
        serviceSpecs,
        swaggerFileSpecs
    };
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
            logger.error(`Error fetching examples`, { apiUrl }, error as Error);
        }
    }
    return exampleSpecsPath;
}

export function getExampleJsonContent(exampleSpecsPath: string): Array<{name: string, content: any}> {
    const jsonList: Array<{name: string, content: any}> = [];
    
    if (!fs.existsSync(exampleSpecsPath)) {
        logger.warn(`Example specs directory not found`, { exampleSpecsPath });
    }
    
    try {
        const files = fs.readdirSync(exampleSpecsPath);
        const jsonFiles = files.filter(file => file.endsWith('.json'));
        
        for (const jsonFile of jsonFiles) {
            const filePath = path.join(exampleSpecsPath, jsonFile);
            try {
                const fileContent = fs.readFileSync(filePath, 'utf8');
                const jsonContent = JSON.parse(fileContent);
                jsonList.push({name: jsonFile.split('.json')[0], content: jsonContent});
                logger.debug(`Loaded example JSON`, { file: jsonFile });
            } catch (error) {
                logger.error(`Error reading JSON file`, { file: jsonFile }, error as Error);
            }
        }
    } catch (error) {
        logger.error(`Error reading examples directory`, { exampleSpecsPath }, error as Error);
    }
    
    return jsonList;
}

export function flattenJsonObject(obj: any): Array<{ key: string; value: any }> {
    const result: Array<{ key: string; value: any }> = [];
    const stack: Array<{ obj: any; prefix: string }> = [{ obj, prefix: '' }];
    
    while (stack.length > 0) {
        const { obj: currentObj, prefix } = stack.pop()!;
        
        for (const key in currentObj) {
            if (currentObj.hasOwnProperty(key)) {
                const newKey = prefix ? `${prefix}.${key}` : key;
                
                if (currentObj[key] !== null && typeof currentObj[key] === 'object' && !Array.isArray(currentObj[key])) {
                    // Push nested object to stack for processing
                    stack.push({ obj: currentObj[key], prefix: newKey });
                } else {
                    // Add the key-value pair to result
                    result.push({ key: newKey, value: currentObj[key] });
                }
            }
        }
    }
    return result;
}

export function unflattenJsonObject(keyValuePairs: Array<{ key: string; value: any }>): any {
    const result: any = {};
    
    for (const { key, value } of keyValuePairs) {
        const keys = key.split('.');
        let current = result;
        
        // Navigate to the correct position, creating nested objects as needed
        for (let i = 0; i < keys.length - 1; i++) {
            const currentKey = keys[i];
            
            // If the property doesn't exist or is not an object, create a new object
            if (!current[currentKey] || typeof current[currentKey] !== 'object' || Array.isArray(current[currentKey])) {
                current[currentKey] = {};
            }
            
            current = current[currentKey];
        }
        
        // Set the final value
        const finalKey = keys[keys.length - 1];
        current[finalKey] = value;
    }
    
    return result;
}

export async function createDirectoryIfNotExists(dirPath: string): Promise<void> {
    try {
        if (!fs.existsSync(dirPath)) {
            fs.mkdirSync(dirPath, { recursive: true });
            logger.info(`Created directory`, { dirPath });
        }
    } catch (error) {
        logger.error(`Error creating directory`, { dirPath }, error as Error);
        throw error;
    }
}

export async function writeFileIfNotExists(filePath: string, content: string): Promise<void> {
    try {
        if (!fs.existsSync(filePath)) {
            fs.writeFileSync(filePath, content, 'utf8');
            logger.info(`Created file`, { filePath });
        } else {
            logger.debug(`File already exists`, { filePath });
        }
    } catch (error) {
        logger.error(`Error writing file`, { filePath }, error as Error);
        throw error;
    }
}

export function getIdealModuleExamplePaths(): string {
    const idealModulesRoot = path.join(process.cwd(), 'src', 'assets', 'ideal-modules');
    try {
        if (!fs.existsSync(idealModulesRoot)) {
            return '';
        }
        const modules: Dirent[] = fs.readdirSync(idealModulesRoot, { withFileTypes: true });
        const exampleDirs: string[] = [];
        for (const mod of modules) {
            if (!mod.isDirectory()) continue;
            const candidate = path.join(idealModulesRoot, mod.name, 'examples');
            if (fs.existsSync(candidate)) {
                exampleDirs.push(candidate);
            }
        }
        return exampleDirs.join(';');
    } catch (err) {
        logger.error('Error collecting ideal module example paths', undefined, err as Error);
        return '';
    }
}

export function getIdealModuleTestPaths(): string {
    const idealModulesRoot = path.join(process.cwd(), 'src', 'assets', 'ideal-modules');
    try {
        if (!fs.existsSync(idealModulesRoot)) {
            return '';
        }
        const modules: Dirent[] = fs.readdirSync(idealModulesRoot, { withFileTypes: true });
        const testDirs: string[] = [];
        for (const mod of modules) {
            if (!mod.isDirectory()) continue;
            const candidate = path.join(idealModulesRoot, mod.name, 'tests');
            if (fs.existsSync(candidate)) {
                testDirs.push(candidate);
            }
        }
        return testDirs.join(';');
    } catch (err) {
        logger.error('Error collecting ideal module test paths', undefined, err as Error);
        return '';
    }
}













export async function testCase() {
    const polymorphism = await getExamplesFromSpecs("d:\\workspace\\azure-powershell\\src\\VMware\\VMware.Autorest");
}
