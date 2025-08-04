import { CallToolResult } from '@modelcontextprotocol/sdk/types.js';
import { z, ZodRawShape, ZodType, ZodTypeAny } from "zod";
import * as utils from "./utils.js";
import path from 'path';
import { get } from 'http';
import { toolParameterSchema } from '../types.js';

class ToolsService {
    constructor() {}
    private _server: any;

    setServer(server: any) {
        this._server = server;
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
        // const response = await this._server.createMessage({
        //     messages: [
        //         {
        //             role: "user",
        //             content: {
        //                 type: "text",
        //                 text: `This is a test sampling request, let me know if you receive this message`,
        //             },
        //         },
        //     ],
        //     maxTokens: 500
        // });
        // console.log("Response from server:", response);
    // Notify user that sampling is starting
    this._server.notification({
        params: {
            level: "info",
            message: "Starting AI sampling request for code generation..."
        }
    });
        const workingDirectory = z.string().parse(Object.values(args)[0]);
        // utils.generateAndBuild(workingDirectory);
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
        return [exampleSpecsPath, examplePath];
    }

    createTestsFromSpecs = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const workingDirectory = z.string().parse(Object.values(args)[0]);
        const testPath = path.join(workingDirectory, "test");
        const exampleSpecsPath = await utils.getExamplesFromSpecs(workingDirectory);
        return [exampleSpecsPath, testPath];
    }
}

// Create and export a singleton instance
export const toolsService = new ToolsService();
export default toolsService;