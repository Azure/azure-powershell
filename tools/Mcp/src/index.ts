import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CodegenServer } from "./CodegenServer.js";
import { logger } from "./services/logger.js";

const server = CodegenServer.getInstance();

async function main() {
    logger.info("Server startup begin");
    server.init();
    const transport = new StdioServerTransport();
    await server.connect(transport);
    logger.info("Codegen MCP Server startup complete");
    logger.info("Server listening (stdio)");
    
    // const yaml = utils.getYamlContentFromReadMe("C:/workspace/azure-powershell/tools/Mcp/test/README.md") as yamlContent;
    // console.log(yaml['input-file'])
    // for (const directive of yaml.directive) {
    //     console.log(directive);
    // }
    //utils.testCase();
}

main().catch((error) => {
    logger.error("Fatal error in main()", undefined, error as Error);
    process.exit(1);
});