import { CallToolResult } from '@modelcontextprotocol/sdk/types.js';
import { z, ZodRawShape, ZodType, ZodTypeAny } from "zod";
import * as utils from "./utils.js";
import path from 'path';
import { get, RequestOptions } from 'http';
import { toolParameterSchema } from '../types.js';
import { logger } from './logger.js';
import { CodegenServer } from '../CodegenServer.js';

export class ToolsService {
    private static _instance: ToolsService;
    private constructor() {}
    private _server: CodegenServer|null = null;
    static getInstance(): ToolsService {
        if (!ToolsService._instance) {
            ToolsService._instance = new ToolsService();
        }
        return ToolsService._instance;
    }
    setServer(server: CodegenServer): ToolsService {
        this._server = server;
        return this;
    }

    getTools = <Args extends ZodRawShape>(name: string, responseTemplate: string|undefined) => {
        let func;
        switch (name) {
            case "generateByAutorest":
                func = this.generateByAutorest<Args>;
                break;
            case "handlePolymorphism":
                func = this.handlePolymorphism<Args>;
                break;
            case "handleNoInline":
                func = this.handleNoInline<Args>;
                break;
            case "handleModelCmdlet":
                func = this.handleModelCmdlet<Args>;
                break;
            case "createExamplesFromSpecs":
                func = this.createExamplesFromSpecs<Args>;
                break;
            case "createTestsFromSpecs":
                func = this.createTestsFromSpecs<Args>;
                break;
            case "setupModuleStructure":
                func = this.setupModuleStructure<Args>;
                break;
            case "runPartnerModuleWorkflow":
                func = this.runPartnerModuleWorkflow<Args>;
                break;
            default:
                throw new Error(`Tool ${name} not found`);
        }
        return this.constructCallback<Args>(func, responseTemplate, name);
    }

    constructCallback = <Args extends ZodRawShape>(fn: (arr: Args) => Promise<string[]>, responseTemplate: string|undefined, toolName: string): (args: Args) => Promise<CallToolResult> => {
        return async (args: Args): Promise<CallToolResult> => {
            const argKeys = Object.keys(args as any);
            const correlationId = `${toolName}-${Date.now()}-${Math.random().toString(16).slice(2,8)}`;
            // Build a sanitized snapshot of arguments (stringified & truncated) for logging
            const rawArgs: any = args as any;
            const sanitized: Record<string, any> = {};
            for (const k of argKeys) {
                try {
                    const v = rawArgs[k];
                    let str: string;
                    if (typeof v === 'string') str = v;
                    else if (typeof v === 'number' || typeof v === 'boolean') str = String(v);
                    else str = JSON.stringify(v);
                    if (str && str.length > 400) str = str.slice(0, 400) + `...[${str.length - 400} trunc]`;
                    sanitized[k] = str;
                } catch {
                    sanitized[k] = '[unserializable]';
                }
            }
            logger.info('Tool invoked', { tool: toolName, correlationId, args: sanitized });
            try {
                const argsArray = await fn(args);
                const response = this.getResponseString(argsArray, responseTemplate) ?? "";
                logger.info(`Tool completed`, { tool: toolName, correlationId });
                return {
                    content: [
                        {
                            type: "text",
                            text: response
                        }
                    ]
                };
            } catch (err: any) {
                logger.error(`Tool failed`, { tool: toolName, correlationId }, err);
                throw err;
            }
        };
    }

    getResponseString(args: string[], responseTemplate: string|undefined): string|undefined {
        if (!args || args.length === 0) {
            return responseTemplate;
        }
        let response = responseTemplate;;
        for (let i = 0; i < args.length; i++) {
            response = response?.replaceAll(`{${i}}`, args[i]);
        }
        return response
    }

    createToolParameterfromSchema(schemas: toolParameterSchema[]){
        const parameter: {[k: string]: z.ZodTypeAny} = {}; 
        for (const schema of schemas) {
            switch (schema.type) {
                case "string":
                    parameter[schema.name] = z.string().describe(schema.description);
                    break;
                case "number":
                    parameter[schema.name] = z.number().describe(schema.description);
                    break;
                case "boolean": 
                parameter[schema.name] = z.boolean().describe(schema.description);
                    break;
                case "array":
                    parameter[schema.name] = z.array(z.string()).describe(schema.description);
                    break;
                // object parameter not supported yet    
                // case "object":
                //     parameter[schema.name] = z.object({}).describe(input.description); // Placeholder for object type
                //     break;
                default:
                    throw new Error(`Unsupported parameter type: ${schema.type}`);
            }
        }
        return parameter;
    }



/*
    below are implementation of tools
*/
    generateByAutorest = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const workingDirectory = z.string().parse(Object.values(args)[0]);
        utils.generateAndBuild(workingDirectory);
        return [workingDirectory];
    };

    handlePolymorphism = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const workingDirectory = z.string().parse(Object.values(args)[0]);
        const polymorphism = await utils.findAllPolyMorphism(workingDirectory);
        const polyArr: [string, string[]][] = Array.from(polymorphism, ([key, valueSet]) => [key, Array.from(valueSet)]);
        const parents = Array.from(polymorphism.keys());
        const children = Array.from(polymorphism.values()).map(set => Array.from(set)).flat();
        return [parents.join(', '), children.join(', '), workingDirectory];
    }

    handleNoInline = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const modelNames = z.array(z.string()).parse(Object.values(args)[0]);
        return [modelNames.join(', ')];
    }

    handleModelCmdlet = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const modelNames = z.array(z.string()).parse(Object.values(args)[0]);
        return [modelNames.join(', ')];
    }

    createExamplesFromSpecs = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const workingDirectory = z.string().parse(Object.values(args)[0]);
        const examplePath = path.join(workingDirectory, "examples");
        const exampleSpecsPath = await utils.getExamplesFromSpecs(workingDirectory);
        // Interactive elicitation removed previously; also parameter export removed (simplified workflow).
        const idealExamplePaths = utils.getIdealModuleExamplePaths();
        return [exampleSpecsPath, examplePath, idealExamplePaths];
    }

    createTestsFromSpecs = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const workingDirectory = z.string().parse(Object.values(args)[0]);
        const testPath = path.join(workingDirectory, "test");
        const exampleSpecsPath = await utils.getExamplesFromSpecs(workingDirectory);
        const idealTestPaths = utils.getIdealModuleTestPaths();
        return [exampleSpecsPath, testPath, idealTestPaths];
    }

    setupModuleStructure = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        try {
            const runId = `setup-${Date.now()}-${Math.random().toString(16).slice(2,8)}`;
            
            // List available services with dropdown
            const modules = await utils.listSpecModules();
            logger.debug('Eliciting user input', { step: 'service-select', runId, moduleCount: modules.length });
            
            const serviceResponse = await this._server!.elicitInput({
                message: `Select an Azure service from the dropdown below:`,
                requestedSchema: {
                    type: "object",
                    properties: {
                        service: {
                            type: "string",
                            description: "Select a service from the dropdown",
                            enum: modules
                        }
                    },
                    required: ["service"]
                }
            });

            const selectedService = serviceResponse.content?.service as string;
            if (!selectedService) {
                throw new Error("No service selected");
            }
            logger.info('User input captured', { step: 'service', service: selectedService, runId });

            // List providers for the selected service with dropdown
            const providers = await utils.listProvidersForService(selectedService);
            if (providers.length === 0) {
                throw new Error(`No providers found for service '${selectedService}'`);
            }
            logger.debug('Eliciting user input', { step: 'provider-select', runId, providerCount: providers.length, service: selectedService });

            const providerResponse = await this._server!.elicitInput({
                message: `Select a provider for ${selectedService} from the dropdown below:`,
                requestedSchema: {
                    type: "object",
                    properties: {
                        provider: {
                            type: "string",
                            description: "Select a provider from the dropdown",
                            enum: providers
                        }
                    },
                    required: ["provider"]
                }
            });

            const selectedProvider = providerResponse.content?.provider as string;
            if (!selectedProvider) {
                throw new Error("No provider selected");
            }
            logger.info('User input captured', { step: 'provider', provider: selectedProvider, runId });

            // List API versions with dropdown combining version and stability
            const apiVersions = await utils.listApiVersions(selectedService, selectedProvider);
            const allVersions = [
                ...apiVersions.stable.map(v => ({ version: v, stability: 'stable' as const })),
                ...apiVersions.preview.map(v => ({ version: v, stability: 'preview' as const }))
            ];

            if (allVersions.length === 0) {
                throw new Error(`No API versions found for ${selectedService}/${selectedProvider}`);
            }

            const versionOptions = allVersions.map(v => `${v.version} (${v.stability})`);
            logger.debug('Eliciting user input', { step: 'version-select', runId, versionOptionCount: versionOptions.length, service: selectedService, provider: selectedProvider });
            
            const versionResponse = await this._server!.elicitInput({
                message: `Select an API version for ${selectedService}/${selectedProvider} from the dropdown below:`,
                requestedSchema: {
                    type: "object",
                    properties: {
                        versionWithStability: {
                            type: "string",
                            description: "Select an API version with stability level",
                            enum: versionOptions
                        }
                    },
                    required: ["versionWithStability"]
                }
            });

            const selectedVersionWithStability = versionResponse.content?.versionWithStability as string;
            if (!selectedVersionWithStability) {
                throw new Error("Version not selected");
            }

            const versionMatch = selectedVersionWithStability.match(/^(.+) \((stable|preview)\)$/);
            if (!versionMatch) {
                throw new Error("Invalid version format selected");
            }
            
            const selectedVersion = versionMatch[1];
            const selectedStability = versionMatch[2] as 'stable' | 'preview';
            logger.info('User input captured', { step: 'version', version: selectedVersion, stability: selectedStability, runId });

            // Resolve Readme placeholder values based on Responses
            const resolved = await utils.resolveAutorestInputs({
                service: selectedService,
                provider: selectedProvider,
                stability: selectedStability,
                version: selectedVersion
            });
            logger.debug('Autorest inputs resolved', { runId, resolvedServiceName: resolved.serviceName, commitId: resolved.commitId });

            const moduleNameResponse = await this._server!.elicitInput({
                message: `What would you like call the powershell module? \n\n Configuration resolved:\n- Service: ${selectedService}\n- Provider: ${selectedProvider}\n- Version: ${selectedVersion} (${selectedStability})\n- Service Name: ${resolved.serviceName}\n- Commit ID: ${resolved.commitId}\n- Service Specs: ${resolved.serviceSpecs}\n- Swagger File: ${resolved.swaggerFileSpecs}`,
                requestedSchema: {
                    type: "object",
                    properties: {
                        moduleName: {
                            type: "string",
                            description: "Enter the PowerShell module name (e.g., 'HybridConnectivity')"
                        }
                    },
                    required: ["moduleName"]
                }
            });

            const moduleName = moduleNameResponse.content?.moduleName as string;
            if (!moduleName) {
                throw new Error("No module name provided");
            }
            logger.info('User input captured', { step: 'moduleName', moduleName, runId });

            // Create folder structure and README.md
            const mcpPath = process.cwd(); // Current working directory is tools/Mcp
            const azurePowerShellRoot = path.resolve(mcpPath, '..', '..'); // Go up two levels to azure-powershell root
            const srcPath = path.join(azurePowerShellRoot, 'src');
            const modulePath = path.join(srcPath, moduleName);
            const autorestPath = path.join(modulePath, `${moduleName}.Autorest`);
            const readmePath = path.join(autorestPath, 'README.md');

            await utils.createDirectoryIfNotExists(modulePath);
            await utils.createDirectoryIfNotExists(autorestPath);

            let readmeContent = this._server!.getResponseTemplate('autorest-readme-template');
            if (!readmeContent) {
                throw new Error('README template not found in server responses');
            }
            
            // Replace placeholders
            readmeContent = readmeContent
                .replace('{commitId}', resolved.commitId)
                .replace('{serviceSpecs}', resolved.serviceSpecs)
                .replace(/\{serviceSpecs\}/g, resolved.serviceSpecs)
                .replace('{swaggerFileSpecs}', resolved.swaggerFileSpecs)
                .replace(/\{moduleName\}/g, moduleName);

            // Write README.md file
            await utils.writeFileIfNotExists(readmePath, readmeContent);

            logger.info('Setup module structure complete', { runId, moduleName });
            return [moduleName];

        } catch (error) {
            const errorMessage = error instanceof Error ? error.message : String(error);
            logger.error('Setup module structure failed', { errorMessage });
            return [`Error during setup: ${errorMessage}`];
        }
    }

    runPartnerModuleWorkflow = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        return [];
    }
}