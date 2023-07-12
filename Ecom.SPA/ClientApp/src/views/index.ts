const routes = [
	{
		path: "/products",
		name: "Products",
		meta: {
			allowAnonymous: false,
			noLayout: false,
			pageTitle: "Ecom | Products",
		},
		component: () => import("./Products/products.vue"),
	},
	{
		path: "/product",
		name: "Product",
		meta: {
			allowAnonymous: false,
			noLayout: false,
			pageTitle: "Ecom | Product",
		},
		component: () => import("./Product/product.vue"),
	},
	{
		path: "/cart",
		name: "Cart",
		meta: {
			allowAnonymous: false,
			noLayout: false,
			pageTitle: "Cart | Login",
		},
		component: () => import("./Cart/cart.vue"),
	},
	{
		path: "/login",
		name: "Login",
		meta: {
			allowAnonymous: true,
			noLayout: true,
			pageTitle: "Ecom | Login",
		},
		component: () => import("./Authentication/Login.vue"),
	},
	{
		path: "/register",
		name: "Register",
		meta: {
			allowAnonymous: true,
			noLayout: true,
			pageTitle: "Ecom | Register",
		},
		component: () => import("./Authentication/Register.vue"),
	},
];

export default routes;
