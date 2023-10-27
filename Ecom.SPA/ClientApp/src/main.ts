import "@/assets/index.scss";

import App from "./App.vue";
import router from "./router";

import { api, mockApi } from "@/src/api";

import { createApp } from "vue";
import { createPinia } from "pinia";
import { EventBus } from "./stores/event-bus";

const app = createApp(App);

const eventBus = new EventBus();
const pinia = createPinia();

app.config.globalProperties.$api = api;
app.config.globalProperties.$mockApi = mockApi;
app.config.globalProperties.$eventBus = eventBus;

app.use(router);
app.use(pinia);

app.mount("#app");
