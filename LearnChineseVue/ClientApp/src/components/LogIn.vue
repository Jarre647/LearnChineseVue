<template>
    <div class="login-container">
        <h3>Login</h3>
        <div class="input-group mb-3">
            <span class="input-group-text" id="inputGroup-sizing-default">Email</span>
            <input type="text" 
                   class="form-control" 
                   aria-label="Sizing example input" 
                   aria-describedby="inputGroup-sizing-default" 
                   placeholder="aaa@afaf.com" 
                   v-model="email"/>                
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="inputGroup-sizing-default">Password</span>
            <input type="password" 
                   class="form-control" 
                   aria-label="Sizing example input" 
                   aria-describedby="inputGroup-sizing-default" 
                   placeholder="123456aA!" 
                   v-model="password" />                
        </div>
        <label>Remember me? &nbsp;</label>
        <input v-model="rememberMe" type="checkbox" />
        <br/>
        <br/>
        <button v-on:click="send" className="btn btn-primary">Login</button>
    </div>
</template>
<script>
    import axios from 'axios'
    import { useState } from '@/store';
    export default {
        setup() {
            return { state: useState() };
        },
        name: "LogIn",
        data() {
            return {
                email: "ak647@mail.ru",
                password: "omgwcEMIY1!",
                rememberMe: false
            }
        },
        methods: {
            send: async function () {
                this.state.counter = 10;
                await axios
                    .post("/api/account/login", {
                        Email: this.email,
                        Password: this.password,
                        RememberMe: this.rememberMe
                    })
                    .then(() => {
                        this.state.isLogined = true;
                        this.$router.push({name: "HomePage"})
                    })
                    .catch(function (error) {
                        this.state.isLogined = false;
                        console.log(error)
                    });
            }
        }
    }
</script>
<style scoped>
    .login-container{
        margin-left: auto;
        margin-right: auto;
        width: 70%;
    }
</style>