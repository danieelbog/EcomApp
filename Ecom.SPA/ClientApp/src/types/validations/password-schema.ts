import * as yup from "yup";

export const passwordValidationSchema = yup.string().required();

export const passwordValidationSchemaCreate = yup.string().required().max(128, "Password must be 128 characters or fewer");
