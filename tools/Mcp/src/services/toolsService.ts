import { CallToolResult } from '@modelcontextprotocol/sdk/types.js';
import { z, ZodRawShape, ZodType, ZodTypeAny } from "zod";
import * as utils from "./utils.js";
import path from 'path';
import { get, RequestOptions } from 'http';
import { toolParameterSchema } from '../types.js';
import { CodegenServer } from '../CodegenServer.js';
import {
    listSpecModules,
    listProvidersForService,
    listApiVersions,
    resolveAutorestInputs
} from './utils.js';

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
            case "listSpecModules":
                func = this.toolListSpecModules<Args>;
                break;
            case "listProvidersForService":
                func = this.toolListProvidersForService<Args>;
                break;
            case "listApiVersions":
                func = this.toolListApiVersions<Args>;
                break;
            case "resolveAutorestInputs":
                func = this.toolResolveAutorestInputs<Args>;
                break;
            default:
                throw new Error(`Tool ${name} not found`);
        }
        return this.constructCallback<Args>(func, responseTemplate);
    }

    constructCallback = <Args extends ZodRawShape>(fn: (arr: Args) => Promise<string[]>, responseTemplate: string|undefined): (args: Args) => Promise<CallToolResult> => {
        return async (args: Args): Promise<CallToolResult> => {
            const argsArray = await fn(args);
            const response = this.getResponseString(argsArray, responseTemplate) ?? "";
            return {
                content: [
                    {
                        type: "text",
                        text: response
                    }
                ]
            };
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
        const exampleSpecs = await utils.getExampleJsonContent(exampleSpecsPath);
        for (const {name, content} of exampleSpecs) {
            const example = await utils.flattenJsonObject(content['parameters']);
            try {
                const response = await this._server!.elicitInput({
                    "message": `Please review example data for ${name}: ${example.map(({key: k, value:v}) => `  \n${k}: ${v}`)}`,
                    "requestedSchema": {
                        "type": "object",
                        "properties": {
                            "skipAll": {
                                "type": "boolean",
                                "description": "If true, skip the review of all examples and proceed to the next step."
                            }
                        },
                    }
                });
                if (response.content && response.content['skipAll'] === true) {
                    break;
                }
            } catch (error) {
                console.error(`Error eliciting input for example ${name}:`, error);
            }
        }
        return [exampleSpecsPath, examplePath];
    }

    createTestsFromSpecs = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const workingDirectory = z.string().parse(Object.values(args)[0]);
        const testPath = path.join(workingDirectory, "test");
        const exampleSpecsPath = await utils.getExamplesFromSpecs(workingDirectory);
        return [exampleSpecsPath, testPath];
    }

    toolListSpecModules = async <Args extends ZodRawShape>(_args: Args): Promise<string[]> => {
        const modules = await listSpecModules();
        return [JSON.stringify(modules)];
    }

    toolListProvidersForService = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const service = z.string().parse(Object.values(args)[0]);
        const providers = await listProvidersForService(service);
        return [service, JSON.stringify(providers)];
    }

    toolListApiVersions = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const service = z.string().parse(Object.values(args)[0]);
        const provider = z.string().parse(Object.values(args)[1]);
        const res = await listApiVersions(service, provider);
        return [service, provider, JSON.stringify(res.stable), JSON.stringify(res.preview)];
    }

    toolResolveAutorestInputs = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const service = z.string().parse(Object.values(args)[0]);
        const provider = z.string().parse(Object.values(args)[1]);
        const stability = z.enum(['stable','preview']).parse(Object.values(args)[2]);
        const version = z.string().parse(Object.values(args)[3]);
        const swaggerPath = Object.values(args)[4] ? z.string().parse(Object.values(args)[4]) : undefined;
        const resolved = await resolveAutorestInputs({ service, provider, stability, version, swaggerPath });
        return [resolved.serviceName, resolved.commitId, resolved.serviceSpecs, resolved.swaggerFileSpecs];
    }
}