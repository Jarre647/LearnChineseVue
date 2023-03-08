<template>
    <nav-menu></nav-menu>
    <router-view />
</template>
<script>
    import axios from 'axios';
    import { useState } from '@/store';
    import NavMenu from './components/NavMenu.vue';
    export default {
        name: 'App',
        components: {
            NavMenu
        },
        data() {
            return {
                isLoged: false
            }
        },
        setup() {
            return { state: useState() };
        },

        computed: {
            getIsLoged: {
                get: function() {
                    return this.isLoged;
                },
                set: function(val) {
                    this.isLoged = val;
                }
            }
        },

        created: async function () {
            this.state.isLogined = false;
            await axios
                .get("/api/test")
                .then(() => {
                    this.state.isLogined = true;
                })
                .catch(() => {
                    this.state.isLogined = false;
                });
        }
    }
</script>
<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
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
