<template>
    <label for="inputPassword" class="form-label">
        {{ text }}
        <span v-if="isRequired" class="text-danger">*</span>
    </label>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
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