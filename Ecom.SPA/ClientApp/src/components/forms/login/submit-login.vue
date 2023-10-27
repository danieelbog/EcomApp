<template>
    <div class="row justify-content-center">
        <div class="col-md-6 col-lg-4">
            <div class="row">
                <div class="col-12 col-md-6 mb-2">
                    <router-link class="col-12 btn-block" to="/register">Or register</router-link>
                </div>
                <div class="col-12 col-md-6 mb-2">
                    <button
                        @click="login"
                        type="button"
                        class="col-12 btn btn-primary btn-block"
                        :class="[formIsValid ? '' : 'disabled']"
                    >
                        Login
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import router from "@/src/router";
import { useAuthStore } from "@/src/stores/auth.store";
import { defineComponent } from "vue";

export default defineComponent({
    props: {
        username: {
            type: String,
            required: false,
            default: ""
        },
        password: {
            type: String,
            required: false,
            default: ""
        },
        formIsValid: {
            type: Boolean,
            required: false,
            default: false
        }
    },
    setup(props, context) {
        const login = async () => {
            function loginRedirect() {
                router.push({ path: (router.currentRoute.value.query.redirect as string) ?? "/" });
            }

            try {
                const authStore = useAuthStore();
                await authStore.login({
                    username: props.username,
                    password: props.password
                });

                if (authStore.isAuthenticated()) loginRedirect();
            } catch (error: any) {
                context.emit("errorsOccured", (error as any).response?.data.non_field_errors);
            }
        };

        return {
            login
        };
    }
});
</script>
