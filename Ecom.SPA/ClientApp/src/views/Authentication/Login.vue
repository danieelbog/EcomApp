<template>
    <div class="container p-3 pt-lg-5">
        <h2 class="text-center my-3">Login</h2>
        <div class="row">
            <div class="col-12 col-lg-4"></div>
            <div class="col-12 col-lg-4">
                <div v-if="showError" class="alert alert-danger d-flex flex-row align-items-center error-messages">
                    <span>Error:</span>
                    <i class="material-icons material-icon-24">{{errorMessage}}</i>
                </div>
                <div class="mb-3">
                    <label for="inputUsername" class="form-label">Username</label>
                    <input id="inputUsername" v-model="username" type="email" class="form-control" aria-describedby="emailHelp">
                </div>
                <div class="mb-3">
                    <label for="inputPassword" class="form-label">Password</label>
                    <input id="inputPassword" v-model="password" type="password" class="form-control">
                </div>
                <div class="mb-3 form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1">
                    <label class="form-check-label" for="exampleCheck1">Remeber me</label>
                </div>
                <div class="mt-3">
                    <button @click="login" class="btn btn-primary w-100">Login</button>
                    <router-link to="/register">
                        <p class="mt-2 mb-2">Or Register</p>
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent, ref } from "vue";
    import { useAuthStore } from "@/stores/auth.store";
    import { LoginDto } from "@/types/auth.dto"
    import router from "@/router/index";

    export default defineComponent({
        setup() {
            var errorMessage = ref("da");
            var showError = ref(false);

            var authStore = useAuthStore();
            var password = ref("");
            var username = ref("");

            async function login() {
                try {
                    var loginDto = {
                        username: username.value,
                        password: password.value,
                    } as LoginDto;
                    await authStore.login(loginDto);
                    if (authStore.isAuthenticated()) loginRedirect();
                } catch (error: any) {
                    showError.value = true;
                    errorMessage.value = error;
                }
            }

            function loginRedirect() {
                router.push((router.currentRoute.value.query) || ("/"));
            }

            return {
                errorMessage,
                showError,
                password,
                username,
                login
            }
        }
    })
</script>