<template>
    <footer class="bg-transparent text-dark fst-italic fw-light border-top text-center py-3">
        <p> MiniOpply &copy; {{ currentYear }} {{ yourName }}</p>
    </footer>
</template>
  
<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
    data() {
        return {
            yourName: 'Daniel Bogdan',
        };
    },
    computed: {
        currentYear(): number {
            return new Date().getFullYear();
        },
    },
});
</script>