import axios from "axios";
import MockAdapter from "axios-mock-adapter";

import { initMockApis } from "@/src/mocks";
import { useAuthStore } from "@/stores/auth.store";

const api = createInstance("https://localhost:7277/");
export { api };

const mockApi = createMockAdapter();
export { mockApi };

function createInstance(baseURL: string) {
    const instance = axios.create({
        baseURL,
        withCredentials: true,
        headers: {
            "Content-Type": "application/json"
        }
    });

    instance.interceptors.response.use(undefined, function (error: any) {
        return new Promise(function (resolve, reject) {
            const originalRequest = error.config;
            console.log("api error", originalRequest);
            if (error.response.status === 401 && !originalRequest._retry) {
                const authStore = useAuthStore();
                resolve(authStore.logout());
            }
            reject(error);
        });
    });

    return instance;
}

if (enviromentIsDev()) initMockApis();

function createMockAdapter() {
    const adapter = new MockAdapter(api, {
        onNoMatch: "throwException",
        delayResponse: 1500
    });
    if (!enviromentIsDev()) adapter.restore();
}

function enviromentIsDev(): boolean {
    return false;
}
