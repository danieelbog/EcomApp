<template>
    <InputRawWrapper :text="label" :isRequired="isRequired">
        <input v-model="value" :type="inputType" :id="inputId" class="form-control" />
        <ErrorMessage v-if="errorMessage" :errorMessage="errorMessage"></ErrorMessage>
    </InputRawWrapper>
</template>

<script lang="ts">
import { defineComponent, PropType, watch } from "vue";
import { useField } from "vee-validate";
import ErrorMessage from "./error-message.vue";
import InputRawWrapper from "@/components/layouts/forms/row-input-wrapper.vue";
import * as yup from "yup";

export default defineComponent({
    components: {
        ErrorMessage,
        InputRawWrapper
    },
    props: {
        label: {
            type: String,
            required: true
        },
        field: {
            type: String,
            required: true
        },
        inputType: {
            type: String,
            required: false,
            default: "text"
        },
        inputId: {
            type: String,
            required: true
        },
        validationSchema: {
            type: Object as PropType<yup.AnySchema>,
            required: true
        },
        isRequired: {
            type: Boolean,
            required: false,
            default: false
        }
    },
    setup(props, context) {
        const { value, meta, errorMessage } = useField(() => props.field, props.validationSchema, {
            syncVModel: true
        });

        watch(value, async (newValue) => {
            if (meta.valid && (newValue as string).length != 1) context.emit(`${props.field}Changed`, newValue);
        });

        return {
            value,
            errorMessage
        };
    }
});
</script>
