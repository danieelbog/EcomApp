<template>
    <RowHeaderWrapper>
        <div class="form-group">
            <div class="mb-3">
                <RowInputLabel :text="text" :isRequired="isRequired"></RowInputLabel>
                <slot></slot>
            </div>
        </div>
    </RowHeaderWrapper>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import RowHeaderWrapper from "./row-header-wrapper.vue";
import RowInputLabel from "@/components/layouts/labels/row-input-label.vue";

export default defineComponent({
    components: {
        RowHeaderWrapper,
        RowInputLabel
    },
    props: {
        text: {
            type: String,
            required: true
        },
        isRequired: {
            type: Boolean,
            required: false,
            default: false
        }
    }
})
</script>

<style scoped></style>