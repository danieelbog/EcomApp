import { AliasOptions, defineConfig } from "vite";
import { fileURLToPath, URL } from "url";
import vue from "@vitejs/plugin-vue";

export default defineConfig({
	plugins: [vue()],
	resolve: {
		alias: getAliases(),
	},
	server: {
		host: true,
	}
});

function getAliases(): AliasOptions {
	return [
		{
			find: "@/src",
			replacement: fileURLToPath(new URL("./src", import.meta.url)),
		},
		{
			find: "@/views",
			replacement: fileURLToPath(new URL("./src/views", import.meta.url)),
		},
		{
			find: "@/components",
			replacement: fileURLToPath(new URL("./src/components", import.meta.url)),
		},
		{
			find: "@/types",
			replacement: fileURLToPath(new URL("./src/types", import.meta.url)),
		},
		{
			find: "@/stores",
			replacement: fileURLToPath(new URL("./src/stores", import.meta.url)),
		},
		{
			find: "@/api",
			replacement: fileURLToPath(new URL("./src/api", import.meta.url)),
		},
		{
			find: "@/router",
			replacement: fileURLToPath(new URL("./src/router", import.meta.url)),
		},
	];
}
