import { createWebHistory, createRouter } from "vue-router";
import HomePage from "@/components/HomePage.vue";
import LogIn from "@/components/LogIn.vue";
import RegisterAccount from "@/components/RegisterAccount.vue";
import AddWordInDictionary from "@/components/AddWordInDictionary.vue";
/* eslint-disable */
const routes = [
    {
        path: "/",
        name: "HomePage",
        component: HomePage
    },
    {
        path: "/login",
        name: "Login",
        component: LogIn
    },
    {
        component: "/Register",
        name: "RegisterAccount",
        component: RegisterAccount
    },
    {
        component: "/AddWordInDictionary",
        name: "AddWordInDictionary",
        component: AddWordInDictionary
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;