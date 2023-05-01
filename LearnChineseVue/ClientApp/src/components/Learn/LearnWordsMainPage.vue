<template>
    <div class="form-floating" v-show="numberStep == 0">
        <select class="form-select" id="floatingSelect" aria-label="Floating label select example" v-model="selectedGroupId">
            <option v-for="groupId, index in groupIds" v-bind:value="groupId" :key="index">{{ groupId }}</option>
        </select>
        <label for="floatingSelect">Выберите желаемую группу</label>
        <button className="btn btn-primary" v-on:click="nextStep">Дальше</button>
    </div>
    <div v-if="numberStep == 1">
        <div>
            <div>
                <div v-if="chineseWords.length > 0">
                    <h2>
                        {{ chineseWords[showNumberWord].translation }}
                    </h2>
                    <div v-if="showHelpNumber">
                        <p>
                            {{ chineseWords[showNumberWord].chineseWord }}
                        </p>
                        <p>
                            {{ chineseWords[showNumberWord].pinyin }}
                        </p>
                        <p>
                            {{ chineseWords[showNumberWord].tones }}
                        </p>
                    </div>
                </div>
            </div>
            <div>
                <button className="btn btn-primary" v-on:click="prevWord">Предыдущее слово</button>
                <button className="btn btn-primary" v-on:click="showHelp()">Показать иероглиф</button>
                <button className="btn btn-primary" v-on:click="nextWord">Следующее слово</button>
            </div>
        </div>

        <button className="btn btn-primary" v-on:click="nextStep">Дальше</button>
        <button className="btn btn-primary" v-on:click="prevStep">Вернуться</button>
    </div>
</template>
<script>
    import axios from 'axios';
    export default {
        name: 'MainLearnPage',
        data() {
            return {
                groupIds: [],
                chineseWords: [],
                selectedGroupId: 0,
                numberStep: 0,
                showNumberWord: 0,
                showHelpNumber: false
            }
        },
        methods: {
            getGroupIds: function() {
                axios
                    .post("/ChineseWords/GetGroups", {
                    })
                    .then(response => {
                        this.groupIds = response.data.groupIds;
                        this.groupIds.unshift(0);
                        console.log(response)
                    })
                    .catch(function (error) {
                        alert(error)
                        //todo допилить обработку ошибок
                        console.log(error)
                    });
            },
            showHelp: function() {                
                this.showHelpNumber = true
            },
            nextWord: function() {              
                if(this.showNumberWord < this.chineseWords.length - 1)
                {
                    this.showNumberWord++;
                    this.showHelpNumber = false;
                }
                else
                {
                    this.showNumberWord = 0;
                }
            },
            prevWord:function () {
                if(this.showNumberWord -1 > 0)
                {
                    this.showNumberWord--;
                    this.showHelpNumber = false;
                }
                else
                {
                    this.showNumberWord = this.chineseWords.length - 1;
                }
            },
            nextStep: function() {
                this.numberStep++;
                if(this.numberStep == 1)
                {
                    this.getChineseWords();
                }
                if(this.numberStep>1)
                {
                    this.numberStep = 0;
                }
            },
            prevStep: function() {
                this.numberStep--;
            },
            getChineseWords: function() {
                axios
                    .post("/ChineseWords/getWordsByGroup", {
                        GroupId: this.selectedGroupId
                    })
                    .then(response => {
                        this.chineseWords = response.data.chineseWords;
                        console.log(response, "respon")
                    })
            }
        },
        computed: {

        },
        created() {
            this.getGroupIds()
        }
    }
</script>
<style>

</style>