<template>
    <nav-menu></nav-menu>
    <router-view />
</template>

<script>
    import axios from 'axios';
    import NavMenu from './components/NavMenu.vue';
    import { useState } from '@/store';
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
                .then((response) => {
                    console.log(response, "resp")
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
</style>
