<template>
    <form class="container">
        <RowHeaderWrapper :headerTitle="'Login'" :messages="errorMessages" :applyErrorStyle="true"> </RowHeaderWrapper>
        <TextInput
            label="Username"
            field="username"
            inputId="inputUsername"
            :isRequired="true"
            :validationSchema="usernameValidationSchema"
            @usernameChanged="updateInputField('username', $event)"
        >
        </TextInput>
        <TextInput
            label="Password"
            field="password"
            inputId="inputPassword"
            inputType="password"
            :isRequired="true"
            :validationSchema="passwordValidationSchema"
            @passwordChanged="updateInputField('password', $event)"
        >
        </TextInput>
        <SubmitLogin
            @errorsOccured="updateErrorMessages"
            :username="formData.username"
            :password="formData.password"
            :formIsValid="formIsValid"
        >
        </SubmitLogin>
    </form>
</template>

<script lang="ts">
import { computed, defineComponent, ref } from "vue";
import { usernameValidationSchema } from "@/types/validations/username-schema";
import { passwordValidationSchema } from "@/types/validations/password-schema";
import RowHeaderWrapper from "@/components/layouts/headers/form-header.vue";
import SubmitLogin from "@/components/forms/login/submit-login.vue";
import TextInput from "@/components/forms/text-input.vue";

interface FormData {
    username: string;
    password: string;
}

export default defineComponent({
    components: {
        RowHeaderWrapper,
        SubmitLogin,
        TextInput
    },
    setup() {
        const formData = ref({
            username: "",
            password: ""
        } as FormData);

        const updateInputField = (field: keyof FormData, value: string) => {
            formData.value[field] = value;
        };

        const formIsValid = computed(() => {
            return formData.value.username.length > 0 && formData.value.password.length > 0;
        });

        const errorMessages = ref([] as Array<string>);
        const updateErrorMessages = (value: Array<string>) => {
            errorMessages.value = value;
        };

        return {
            formData,
            updateInputField,
            formIsValid,
            updateErrorMessages,
            errorMessages,
            usernameValidationSchema,
            passwordValidationSchema
        };
    }
});
</script>
