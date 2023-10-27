<template>
    <RowHeaderWrapper>
        <h2 v-if="headerTitle.length > 0" class="text-center mt-5">{{ headerTitle }}</h2>
        <div v-if="messages.length > 0">
            <p
                v-for="errorMessage in messages"
                class="text-center my-3"
                v-bind:key="errorMessage.toString()"
                :class="[applyErrorStyle ? 'text-danger' : 'text-success']"
            >
                {{ errorMessage }}
            </p>
        </div>
        <slot></slot>
    </RowHeaderWrapper>
</template>
<script lang="ts">
import { defineComponent } from "vue";
import RowHeaderWrapper from "@/components/layouts/forms/row-header-wrapper.vue";

export default defineComponent({
    components: {
        RowHeaderWrapper
    },
    props: {
        messages: {
            type: Array<String>,
            required: true
        },
        applyErrorStyle: {
            type: Boolean,
            required: false,
            default: false
        },
        headerTitle: {
            type: String,
            required: false,
            default: ""
        }
    }
});
</script>
