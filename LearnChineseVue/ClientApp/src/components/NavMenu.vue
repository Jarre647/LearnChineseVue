<template>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container">
                <button class="navbar-toggler"
                        type="button"
                        data-toggle="collapse"
                        data-target=".navbar-collapse"
                        aria-label="Toggle navigation"
                        @click="toggle">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse"
                     v-bind:class="{show: isExpanded}">
                    <ul class="navbar-nav flex-grow">
                        <li class="nav-item">
                            <router-link :to="{name:'LearnCards'}" class="nav-link text-dark">Карточка</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{name:'LearnWordsMainPage'}" class="nav-link text-dark">Учить слова</router-link>
                        </li>
                        <li class="nav-item" v-if="state.isLogined">
                            <router-link :to="{name:'home'}" class="nav-link text-dark">Словарь</router-link>
                        </li>
                        <li class="nav-item" v-if="!state.isLogined">
                            <router-link :to="{name:'Login'}" class="nav-link text-dark">LogIn</router-link>
                        </li>
                        <li class="nav-item" v-if="!state.isLogined">
                            <router-link :to="{name:'RegisterAccount'}" class="nav-link text-dark">Register</router-link>
                        </li>
                        <li class="nav-item" v-if="state.isLogined">
                            <router-link :to="{name:'AddWordInDictionary'}" class="nav-link text-dark">Добавить слово</router-link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
</template>
<script>
    import { useState } from '@/store';
    export default {
        name: "NavMenu",
        setup() {
            return { state: useState() };
        },
        data() {
            return {
                isExpanded: false
            }
        },
        methods: {
            collapse() {
                this.isExpanded = false;
            },

            toggle() {
                this.isExpanded = !this.isExpanded;
            }
        }
    }
</script>
<style>
    a.navbar-brand {
        white-space: normal;
        text-align: center;
        word-break: break-all;
    }

    html {
        font-size: 14px;
    }

    @media (min-width: 768px) {
        html {
            font-size: 16px;
        }
    }

    .box-shadow {
        box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);
    }
</style>