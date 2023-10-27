import * as yup from "yup";

export const usernameValidationSchema = yup.string().required();

export const usernameValidationSchemaCreate = yup
	.string()
	.required()
	.max(150, "Username must be 150 characters or fewer")
	.matches(/^[\w.@+-]+$/, "Allowed pattern: Letters, digits and @/./+/-/_ only");
