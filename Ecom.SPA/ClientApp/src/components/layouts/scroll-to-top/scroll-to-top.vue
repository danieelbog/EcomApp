<template>
    <div>
        <button class="btn btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle shadow-sm" @click="scrollToTop"
            v-if="showScrollButton">
            <span class="material-icons-outlined">
                keyboard_double_arrow_up
            </span>
        </button>
    </div>
</template>
  
<script lang="ts">
import { defineComponent, ref, onMounted, onBeforeUnmount } from 'vue';

export default defineComponent({
    setup() {
        const showScrollButton = ref(false);

        const handleScroll = () => {
            showScrollButton.value = window.scrollY > 200;
        };

        const scrollToTop = () => {
            window.scrollTo({ top: 0, behavior: 'smooth' });
        };

        onMounted(() => {
            window.addEventListener('scroll', handleScroll);
        });

        onBeforeUnmount(() => {
            window.removeEventListener('scroll', handleScroll);
        });

        return {
            showScrollButton,
            scrollToTop,
        };
    },
});
</script>