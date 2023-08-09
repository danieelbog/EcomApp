<template>
    <div class="container p-3 pt-lg-5">
        <h2 class="text-center my-3">Register</h2>
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
                <div class="mt-3">
                    <button @click="register" class="btn btn-primary w-100">Register</button>
                    <router-link to="/login">
                        <p class="mt-2 mb-2">Or Login</p>
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent, ref } from "vue";
    import { useAuthStore } from "@/stores/auth.store";
    import { RegisterDto } from "@/types/auth.dto"
    import router from "@/router/index";

    export default defineComponent({
        setup() {
            var errorMessage = ref("da");
            var showError = ref(false);

            var authStore = useAuthStore();
            var password = ref("");
            var username = ref("");

            async function register() {
                try {
                    var registerDto = {
                        email: username.value,
                        username: username.value,
                        password: password.value
                    } as RegisterDto;
                    await authStore.registerUser(registerDto);
                    if (authStore.isAuthenticated()) registerRedirect();
                } catch (error: any) {
                    showError.value = true;
                    errorMessage.value = error;
                }               
            }

            function registerRedirect() {
                router.push((router.currentRoute.value.query) || ("/"));
            }

            return {
                errorMessage,
                showError,
                password,
                username,
                register
            }
        }
    })
</script>