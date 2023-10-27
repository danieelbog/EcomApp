import * as yup from "yup";

export const emailValidationSchemaCreate = yup.string().email().nullable().notRequired().max(150, "Email must be 254 characters or fewer");
