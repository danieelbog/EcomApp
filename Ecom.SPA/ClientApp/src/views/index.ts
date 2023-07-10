const Products  = () => import( "./Products/products.vue");
const Product  = () => import( "./Product/product.vue");
const Cart = () => import("./Cart/cart.vue");

const routes = [
    { path: '/', component: Products },
    { path: '/product', component: Product },
    { path: '/cart', component: Cart },
]

export default routes;