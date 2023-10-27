<template>
    <main class="bg-light h-100">
        <component :is="layoutComponent"></component>
        <ScrollToTop></ScrollToTop>
    </main>
</template>

<script lang="ts">
import { defineComponent, onMounted, watch, shallowRef } from "vue";
import { Popover } from "bootstrap";
import { useLayoutStore } from "@/stores/layout.store";
import ScrollToTop from "@/components/layouts/scroll-to-top/scroll-to-top.vue";

export default defineComponent({
    components: {
        ScrollToTop
    },
    setup() {
        const layoutStore = useLayoutStore();
        const layoutComponent = shallowRef();
        watch(
            layoutStore.$state,
            (state) => {
                if (state.layout) {
                    layoutComponent.value = state.layout;
                }
            },
            { deep: true }
        );

        onMounted(() => {
            document.querySelectorAll('[data-bs-toggle="popover"]').forEach((popover) => {
                new Popover(popover);
            });
            document.getElementById("external-loader")?.remove();
        });

        return {
            layoutComponent
        };
    }
});
</script>
