import { defineStore } from "pinia";
import { defineAsyncComponent, shallowRef } from "vue";
import { LayoutType } from "../router/types";

export const useLayoutStore = defineStore("layout", () => {
    const layout = shallowRef();

    const setLayout = (layoutType: LayoutType) => {
        switch (layoutType) {
            case LayoutType.noLayout:
                layout.value = defineAsyncComponent(() => import("@/components/layouts/empty-layout.vue"));
                break;
            case LayoutType.basicLayout:
                layout.value = defineAsyncComponent(() => import("@/components/layouts/default-layout.vue"));
                break;
        }
    };

    return { layout, setLayout };
});
