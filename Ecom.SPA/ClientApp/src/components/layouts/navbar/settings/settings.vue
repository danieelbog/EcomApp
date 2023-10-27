<template>
    <div class="nav-menu-dropdown-button btn-group">
        <button
            type="button"
            class="btn btn-outline-primary rounded"
            data-bs-toggle="dropdown"
            data-bs-display="static"
            aria-expanded="false"
        >
            <span class="align-middle material-icons-round"> settings </span>
        </button>
        <ul class="nav-menu-dropdown-item dropdown-menu dropdown-menu-end p-1">
            <li>
                <button @click="logout" class="dropdown-item btn btn-light">
                    <span class="align-middle material-icons-outlined text-danger"> power_settings_new </span>
                    <span class="m-2 align-middle">Logout</span>
                </button>
            </li>
        </ul>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { useAuthStore } from "@/src/stores/auth.store";
import router from "@/src/router";

export default defineComponent({
    setup() {
        const logout = () => {
            const authStore = useAuthStore();
            authStore.logout();
            logoutRedirect();
        };

        function logoutRedirect() {
            router.push({ path: "/login" });
        }

        return {
            logout
        };
    }
});
</script>
