<template>
    <div class="row justify-content-center g-0 p-3" :class="{
        'flex-column-reverse': isColumnReverse,
        'flex-column': !isColumnReverse,
    }">
        <slot name="content"></slot>
        <observable-wrapper v-if="showObservable" @intersect="intersect()"></observable-wrapper>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import ObservableWrapper from "@/components/layouts/wrappers/observable/observable-wrapper.vue";

export default defineComponent({
    components: { ObservableWrapper },
    props: {
        isColumnReverse: {
            type: Boolean,
            required: false,
            default: false,
        },
        showObservable: {
            type: Boolean,
            required: false,
            default: true,
        },
    },
    setup(props, context) {
        const loading = ref(false);
        function intersect() {
            context.emit("intersect");
        }

        return {
            loading: loading,
            intersect: intersect,
        };
    },
});
</script>