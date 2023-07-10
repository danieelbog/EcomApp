import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"

import App from './App.vue'
import AppError from './App-Error.vue'

import { createApp } from 'vue'

try {
    const app = createApp(App)
    app.mount('#app')
} catch (e) {
    const app = createApp(AppError)
    app.mount('#app')
}




