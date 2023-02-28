<template>
    <div class="register-container">        
        <h3>Register</h3>

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
        <div class="input-group mb-3">
            <span class="input-group-text" id="inputGroup-sizing-default">Confirm password</span>
            <input type="password" 
                   class="form-control" 
                   aria-label="Sizing example input" 
                   aria-describedby="inputGroup-sizing-default" 
                   placeholder="123456aA!" 
                   v-model="confirmPassword"  />                
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="inputGroup-sizing-default">Nick Name</span>
            <input type="text" 
                   class="form-control" 
                   aria-label="Sizing example input" 
                   aria-describedby="inputGroup-sizing-default" 
                   v-model="nickName"  />                
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="inputGroup-sizing-default">Phone number</span>
            <input type="text" 
                   class="form-control" 
                   aria-label="Sizing example input" 
                   aria-describedby="inputGroup-sizing-default" 
                   v-model="phoneNumber" />
        </div>

        <button v-on:click="send" className="btn btn-primary">Register</button>
    </div>
</template>
<script>
    import axios from 'axios'
    export default {
        name: "RegisterAccount",
        data() {
            return {
                email: "",
                password: "",
                confirmPassword: "",
                nickName: "",
                phoneNumber: ""
            }
        },
        methods: {
            send: async function () {
                await axios
                    .post("/api/account/register", {
                        Email: this.email,
                        Password: this.password,
                        ConfirmPassword: this.confirmPassword,
                        NickName: this.nickName,
                        PhoneNumber: this.phoneNumber
                    })
                    .then(() => {
                        this.$router.push({name: "Login"})
                    })
                    .catch(function (error) {
                        console.log(error)
                    });
            }
        }
    }
</script>
<style scoped>
    .register-container{
        margin-left: auto;
        margin-right: auto;
        width: 70%;
    }
</style>