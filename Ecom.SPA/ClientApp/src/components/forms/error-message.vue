<template>
    <p class="fst-italic fw-lighter text-danger mt-1">{{ errorMessage }}</p>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
    props: {
        errorMessage: {
            type: String,
            required: false,
            default: null
        }
    },
    setup() {
        return {}
    }
})
</script>