<template>
    <form class="container">
        <RowHeaderWrapper :headerTitle="'Register'" :messages="displayMessages" :applyErrorStyle="showError()">
        </RowHeaderWrapper>
        <TextInput
            label="Username"
            field="username"
            inputId="inputUsername"
            :isRequired="true"
            :validationSchema="usernameValidationSchemaCreate"
            @usernameChanged="updateInputField('username', $event)"
        >
        </TextInput>
        <TextInput
            label="Password"
            field="password"
            inputId="inputPassword"
            :isRequired="true"
            inputType="password"
            :validationSchema="passwordValidationSchemaCreate"
            @passwordChanged="updateInputField('password', $event)"
        >
        </TextInput>
        <TextInput
            label="Email"
            field="email"
            inputId="inputEmail"
            :isRequired="true"
            inputType="email"
            :validationSchema="emailValidationSchemaCreate"
            @emailChanged="updateInputField('email', $event)"
        >
        </TextInput>
        <SubmitRegister
            @userCreated="updateSuccessMessage"
            @errorsOccured="updateErrorMessages"
            :username="formData.username"
            :password="formData.password"
            :firstName="formData.firsName"
            :lastName="formData.lastName"
            :email="formData.email"
            :formIsValid="formIsValid"
        >
        </SubmitRegister>
    </form>
</template>

<script lang="ts">
import { computed, defineComponent, ref } from "vue";
import { usernameValidationSchemaCreate } from "@/types/validations/username-schema";
import { passwordValidationSchemaCreate } from "@/types/validations/password-schema";
import { emailValidationSchemaCreate } from "@/types/validations/email-schema";

import RowHeaderWrapper from "@/components/layouts/headers/form-header.vue";
import TextInput from "@/components/forms/text-input.vue";
import SubmitRegister from "@/components/forms/register/submit-register.vue";

interface FormData {
    [key: string]: string;
}

export default defineComponent({
    components: {
        RowHeaderWrapper,
        TextInput,
        SubmitRegister
    },
    setup() {
        const formData = ref({
            username: "",
            password: "",
            email: ""
        } as FormData);

        const updateInputField = (field: string, value: string) => {
            formData.value[field] = value;
        };

        const formIsValid = computed(() => {
            return (
                formData.value.username.length > 0 &&
                formData.value.password.length > 0 &&
                formData.value.email.length > 4
            );
        });

        const errorMessages = ref([] as Array<string>);
        const updateErrorMessages = (value: Array<string>) => {
            errorMessages.value = [];
            errorMessages.value = value;
        };

        const successMessages = ref([] as Array<string>);
        const updateSuccessMessage = (value: string) => {
            successMessages.value = [];
            successMessages.value.push(value);
        };

        const showError = () => {
            return errorMessages.value.length > 0;
        };
        const displayMessages = computed(() => {
            return showError() ? errorMessages.value : successMessages.value;
        });

        return {
            showError,
            updateInputField,
            updateErrorMessages,
            updateSuccessMessage,
            formData,
            errorMessages,
            displayMessages,
            formIsValid,
            usernameValidationSchemaCreate,
            passwordValidationSchemaCreate,
            emailValidationSchemaCreate
        };
    }
});
</script>
