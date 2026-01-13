import { z, ZodRawShape } from "zod";
import { resourceSchema } from "../types.js";
import { CodegenServer } from "../CodegenServer.js";

export class ResourcesService {
    private static _instance: ResourcesService;
    private _server: CodegenServer | null = null;
    private constructor() {}

    static getInstance(): ResourcesService {
        if (!ResourcesService._instance) {
            ResourcesService._instance = new ResourcesService();
        }
        return ResourcesService._instance;
    }

    setServer(server: CodegenServer): ResourcesService {
        this._server = server;
        return this;
    }

    getResources<Args extends ZodRawShape>(name: string, responseTemplate: string | undefined) {
        let func;
        switch (name) {
            case "autorestReadmeTemplate":
                func = this.autorestReadmeTemplate<Args>;
                break;
            default:
                throw new Error(`Resource ${name} not found`);
        }
        return this.constructCallback<Args>(func, responseTemplate);
    }

    constructCallback<Args extends ZodRawShape>(fn: (arr: Args) => Promise<string>, responseTemplate: string | undefined) {
        return async (args: Args) => {
            const content = await fn(args);
            return {
                contents: [
                    {
                        uri: `resource://template`,
                        mimeType: "text/plain",
                        text: content
                    }
                ]
            };
        };
    }

    createResourceParametersFromSchema(schemas: any[]) {
        // Resources typically don't have parameters in MCP, but keeping for consistency
        const parameter: { [k: string]: any } = {};
        return parameter;
    }

    autorestReadmeTemplate = async <Args extends ZodRawShape>(args: Args): Promise<string> => {
        const template = this._server?.getResponseTemplate('autorest-readme-template');
        return template || "Template Not Found!";
    };

}