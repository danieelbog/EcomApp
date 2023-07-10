import { fileURLToPath, URL } from 'node:url'
import { defineConfig } from 'vite'

import vue from '@vitejs/plugin-vue'
import vueJsx from '@vitejs/plugin-vue-jsx'
import { resolve } from 'node:path/posix'
import path from "path";

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [
        vue(),
        vueJsx(),
    ],
    root: path.resolve(__dirname, 'src/app'),
    build: {
        rollupOptions: {
            input: {
                'entry-point-a': path.resolve(__dirname, 'src/app/main.ts'),
            },
        }
    },
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        host: true,
        hmr: {
            protocol: 'ws',
            port: 52896
        }
    }
})


