import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap";

import App from "./App.vue";
import AppError from "./App-Error.vue";
import router from "../router";

import { api, mockApi } from "@/src/api";

import { createApp } from "vue";
import { createPinia } from "pinia";

try {
	const app = createApp(App);
	const pinia = createPinia();

	app.config.globalProperties.$api = api;
	app.config.globalProperties.$mockApi = mockApi;

	app.use(router);
	app.use(pinia);

	app.mount("#app");
} catch (e) {
	const app = createApp(AppError);
	app.mount("#app");
}
