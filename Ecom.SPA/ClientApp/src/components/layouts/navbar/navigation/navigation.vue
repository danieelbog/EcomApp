<template>
    <div class="d-sm-flex d-grid align-items-center mx-4 my-2 my-sm-0">
        <div
            class="d-flex align-items-center justify-content-center mx-2"
            v-for="route in navigationRoutes"
            v-bind:key="route.name"
        >
            <router-link :to="route.path" :class="[route.path == currentRoute ? 'text-primary' : 'text-dark']">
                {{ route.name }}</router-link
            >
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import { RouteRecordNormalized } from "vue-router";
import router from "@/src/router";

export default defineComponent({
    setup() {
        const navigationRoutes = ref([] as RouteRecordNormalized[]);
        const currentRoute = ref(router.currentRoute.value.path);

        const setNavigationLinks = () => {
            var routes = router.getRoutes();
            if (routes.length == 0) return;

            routes.forEach((route) => {
                if (route.meta?.showInNavigation) navigationRoutes.value.push(route);
            });
        };

        onMounted(setNavigationLinks);

        return {
            navigationRoutes,
            currentRoute
        };
    }
});
</script>
