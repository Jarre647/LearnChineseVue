import { createRouter, createWebHistory } from 'vue-router'

import LogIn from "@/components/LogIn.vue";
import HomePage from '@/components/HomePage.vue'
import AddWordInDictionary from "@/components/AddWordInDictionary.vue";
import RegisterAccount from "@/components/RegisterAccount.vue"
import LearnWordsMainPage from "@/components/Learn/LearnWordsMainPage.vue"
import CRMPage from "@/components/CRMPage.vue"
const routes = [
    {
        path: '/',
        name: 'home',
        component: HomePage
    },
    {
        path: "/login",
        name: "Login",
        component: LogIn
    },
    {
        path: '/add-word-in-dictionary',
        name: 'AddWordInDictionary',
        component: AddWordInDictionary
    },
    {
        path:'/register',
        name: 'RegisterAccount',
        component: RegisterAccount
    },
    {
        path: '/learn',
        name: 'LearnWordsMainPage',
        component: LearnWordsMainPage
    },
    {
        path: '/crm',
        name: 'CRMPage',
        component: CRMPage
    }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
