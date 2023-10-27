import { createRouter, createWebHistory } from "vue-router";
import { useAuthStore } from "@/stores/auth.store";
import { useLayoutStore } from "@/src/stores/layout.store";

import routes from "../views";
import { IRouteMeta } from "./types";

const router = createRouter({
    history: createWebHistory(),
    routes
});

router.beforeEach(async (to, from, next) => {
    document.title = (to.meta as IRouteMeta).pageTitle;
    const authStore = useAuthStore();
    const isRouteAnonymous = to.matched.some((record) => record.meta.allowAnonymous);

    if (!isRouteAnonymous && !authStore.isAuthenticated()) {
        try {
            await authStore.getApplicationUser();
            if (authStore.isAuthenticated()) next();
            else next({ path: "/login", query: { redirect: to.fullPath } });
        } catch (error) {
            console.error("Navigation error:", error);
            next({ path: "/login", query: { redirect: to.fullPath } });
        }
    } else next();
});

router.afterEach(async (to) => {
    const layoutStore = useLayoutStore();
    layoutStore.setLayout((to.meta as IRouteMeta).layoutType);
});

export default router;
