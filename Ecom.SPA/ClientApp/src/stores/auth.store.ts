import { IUser } from "@/types/models/IUser";
import { ILogin } from "@/types/models/ILogin";
import { IRegister } from "@/types/models/IRegister";

import { api } from "@/api/index";
import { defineStore } from "pinia";
import { ref } from "vue";

export const useAuthStore = defineStore("auth", () => {
    const applicationUser = ref(null as IUser | null);

    const setApplicationUser = (user: IUser) => {
        applicationUser.value = user;
    };

    const isAuthenticated = (): boolean => {
        return !!applicationUser.value;
    };

    const getApplicationUser = async () => {
        if (isAuthenticated()) return;
        const result = await api.get("/api/account/getAuthUser");
        if (result.data) setApplicationUser(result.data);
    };

    const login = async (login: ILogin) => {
        const result = await api.post("/api/account/login", login);
        if (result.data) setApplicationUser(result.data);
    };

    const register = async (register: IRegister) => {
        const result = await api.post("/api/account/register", register);
        if (result.data) setApplicationUser(result.data);
    };

    const logout = async () => {
        await api.post("/api/account/logout");
        applicationUser.value = null;
    };

    return {
        applicationUser,
        login,
        register,
        isAuthenticated,
        getApplicationUser,
        logout
    };
});
