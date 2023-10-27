<template>
    <div class="container-fluid g-0">
        <NavBar></NavBar>
        <router-view></router-view>
        <CustomFooter></CustomFooter>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NavBar from "./navbar/navbar.vue";
import CustomFooter from "./footer/footer.vue";

export default defineComponent({
    components: {
        NavBar,
        CustomFooter
    },
    setup() {
        return {};
    }
});
</script>
