import { AliasOptions, defineConfig } from "vite";
import { fileURLToPath, URL } from "url";
import vue from "@vitejs/plugin-vue";
import basicSsl from "@vitejs/plugin-basic-ssl";

export default defineConfig({
    plugins: [vue(), basicSsl()],
    resolve: {
        alias: getAliases()
    },
    server: {
        https: true,
        port: 5000
    }
});

function getAliases(): AliasOptions {
    return [
        {
            find: "~bootstrap",
            replacement: fileURLToPath(new URL("./node_modules/@types/bootstrap", import.meta.url))
        },
        {
            find: "@/src",
            replacement: fileURLToPath(new URL("./src", import.meta.url))
        },
        {
            find: "@/views",
            replacement: fileURLToPath(new URL("./src/views", import.meta.url))
        },
        {
            find: "@/components",
            replacement: fileURLToPath(new URL("./src/components", import.meta.url))
        },
        {
            find: "@/types",
            replacement: fileURLToPath(new URL("./src/types", import.meta.url))
        },
        {
            find: "@/stores",
            replacement: fileURLToPath(new URL("./src/stores", import.meta.url))
        },
        {
            find: "@/api",
            replacement: fileURLToPath(new URL("./src/api", import.meta.url))
        },
        {
            find: "@/router",
            replacement: fileURLToPath(new URL("./src/router", import.meta.url))
        },
        {
            find: "@/assets",
            replacement: fileURLToPath(new URL("./src/assets", import.meta.url))
        }
    ];
}
