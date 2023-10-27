<template>
    <div class="row justify-content-center">
        <div class="col-md-6 col-lg-4">
            <div class="row">
                <div class="col-12 col-md-6 mb-2">
                    <router-link class="col-12 btn-block" to="/login">Or login</router-link>
                </div>
                <div class="col-12 col-md-6 mb-2">
                    <button
                        @click="register"
                        type="button"
                        class="col-12 btn btn-primary btn-block"
                        :class="[formIsValid ? '' : 'disabled']"
                    >
                        Register
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { useAuthStore } from "@/src/stores/auth.store";
import router from "@/src/router";

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
        email: {
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
        function registerRedirect() {
            router.push({ path: "/" });
        }

        const register = async () => {
            const authStore = useAuthStore();
            try {
                await authStore.register({
                    email: props.email,
                    username: props.username,
                    password: props.email
                });
                if (authStore.isAuthenticated()) registerRedirect();
            } catch (error) {
                context.emit("errorsOccured", (error as any).response?.username);
            }
        };

        return {
            register
        };
    }
});
</script>
