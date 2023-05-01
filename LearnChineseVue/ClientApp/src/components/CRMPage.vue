<template>
    <div v-if="isAccessGranted">
        <div v-for="item, index in this.users" :key="index">
            {{ item.userName }}
            <select class="form-select" aria-label="Default select example" v-model="item.roleId">
                <option v-for="role, roleIndex in this.roles" :key="roleIndex" :value="role.roleId">{{ role.name }}</option>
            </select>
        </div>
        <div>
            <!-- <button :click="updateUsers()">
                Save
            </button> -->
        </div>
    </div>
    <div v-else>
        <div>недостаточно прав</div>
    </div>
    <h1>zalupa3</h1>
</template>
<script>
    import axios from 'axios';
    export default {
        name: "CRM",
        data() {
            return {
                selectedTest: null,
                isAccessGranted: true,
                roles: [],
                users: []
            }
        },
        created: async function () {
            await this.getUsers();
        },
        methods: {
            updateUsers: async function() {
                let users = this.users.map(item => { return {
                    UserId: item.userId,
                    RoleId: item.roleId
                } })
                console.log(users, "user")
                await axios
                    .post("/api/CRM/update-users", {
                        Users: users
                    })
                    .then(response => {
                        console.log(response)
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }, 
            checkConnection: async function () {
                await axios
                    .post("/api/CRM/CheckUser", {
                    })
                    .then(response => {
                        if (response.data == "zalupa")
                            this.isAccessGranted = true;
                        console.log(response)
                    })
                    .catch(function (error) {
                        alert(error)
                        //todo допилить обработку ошибок
                        console.log(error)
                    });
            },
            getUsers: async function () {
                await axios
                    .post("/api/CRM/get-users", {
                    })
                    .then(response => {
                        this.users = response.data.accounts;
                        this.roles = response.data.roles;
                        console.log(response)
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }
        }
    }
</script>
<style>
</style>