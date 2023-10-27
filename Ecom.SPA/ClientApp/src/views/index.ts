import { IRouteMeta, LayoutType } from "@/router/types";
import { RouteRecordRaw } from "vue-router";

const routes = [
    {
        path: "/",
        name: "Products",
        meta: {
            allowAnonymous: false,
            layoutType: LayoutType.basicLayout,
            pageTitle: "APay | Products",
            showInNavigation: true
        } as IRouteMeta,
        component: () => import("@/views/Products/products.vue")
    } as RouteRecordRaw,
    {
        path: "/product",
        name: "Product",
        meta: {
            allowAnonymous: false,
            layoutType: LayoutType.basicLayout,
            pageTitle: "APay | Product",
            showInNavigation: true
        } as IRouteMeta,
        component: () => import("@/views/Product/product.vue")
    } as RouteRecordRaw,
    {
        path: "/cart",
        name: "Cart",
        meta: {
            allowAnonymous: false,
            layoutType: LayoutType.basicLayout,
            pageTitle: "APay | Login",
            showInNavigation: true
        } as IRouteMeta,
        component: () => import("@/views/Cart/cart.vue")
    } as RouteRecordRaw,
    {
        path: "/login",
        name: "Login",
        meta: {
            allowAnonymous: true,
            layoutType: LayoutType.noLayout,
            pageTitle: "APay | Login",
            showInNavigation: false
        } as IRouteMeta,
        component: () => import("@/views/Login/login.vue")
    } as RouteRecordRaw,
    {
        path: "/register",
        name: "Register",
        meta: {
            allowAnonymous: true,
            layoutType: LayoutType.noLayout,
            pageTitle: "APay | Register",
            showInNavigation: false
        } as IRouteMeta,
        component: () => import("@/views/Register/register.vue")
    } as RouteRecordRaw
];

export default routes;
