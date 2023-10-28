<template>
    <div class="form-floating" v-show="numberStep == 0">
        <div class="label-block">
            <label for="floatingSelect">Выберите желаемую группу</label>&nbsp;
            <!-- <button className="btn btn-primary" v-on:click="continueLearn">Продолжить</button> -->
        </div>
        <div class="group">
            <select class="form-select" id="floatingSelect" aria-label="Floating label select example" v-model="selectedGroupId">
                <option v-for="groupId, index in groupIds" v-bind:value="groupId" :key="index">{{ groupId }}</option>
            </select>
        </div>
        <div class="button-block">
            <button className="btn btn-primary" v-on:click="nextStep">Дальше</button>
        </div>
    </div>
    <div v-if="numberStep == 1">
        <!-- todo вынести в отдельный компонент для возможности расширения функционала-->
        <v-lazy>
            <div class="cards-container">
                <div>
                    <label v-if="!isAll">
                        {{ getShowingChineseWords[0].translation }}
                    </label>
                    <label v-else>
                        закончились слова
                    </label>
                </div>
                <div class="card-item" @click="checkIsCorrect(getCurrentPage[0])" :class="getCurrentPage[0].class" v-if="!isAll">
                    {{getCurrentPage[0].word}}
                </div>
                <div class="card-item" @click="checkIsCorrect(getCurrentPage[1])" :class="getCurrentPage[1].class" v-if="!isAll">
                    {{getCurrentPage[1].word}}
                </div>
                <div class="card-item" @click="checkIsCorrect(getCurrentPage[2])" :class="getCurrentPage[2].class" v-if="!isAll">
                    {{getCurrentPage[2].word}}
                </div>
                <div class="card-item" @click="checkIsCorrect(getCurrentPage[3])" :class="getCurrentPage[3].class" v-if="!isAll">
                    {{getCurrentPage[3].word}}
                </div>
            </div>            
            <div v-if="showLastSelected">
                <label>
                    {{lastSelected.chineseWord}}
                </label>
                <br />
                <label>
                    {{lastSelected.translation}}
                </label>
                <br />
                <label>
                    {{lastSelected.pinyin}}

                </label>
                <br />
                <label>
                    {{lastSelected.tones}}
                </label>
            </div>
        </v-lazy>
        
        <button className="btn btn-primary word-button" v-on:click="nextStep" v-if="numberStep == 0">Дальше</button>


        <button className="btn btn-primary word-button bn" v-on:click="prevStep" v-if="numberStep == 1">Вернуться</button>
        <button className="btn btn-primary word-button bn" v-on:click="reset" v-if="numberStep == 1">Сбросить</button>

        
    </div>
</template>
<script>
    import axios from 'axios';
    export default {
        name: "LearCards",
        data() {
            return {
                groupIds: [],
                chineseWords: [],
                selectedGroupId: 0,
                numberStep: 0,
                showNumberWord: 0,
                showHelpNumber: false,
                chineseWordsToShow: [],
                currentPage: [],
                lastSelected: null,
                showLastSelected: false,
                isAll: false
            }
        },
        created() {
            this.getGroupIds()
        },
        computed: {
            getShowingChineseWords: {
                get: function () {
                    return this.chineseWordsToShow;
                },
                set: function (val) {
                    this.chineseWordsToShow = val;
                }
            },
            getCurrentPage: {
                get: function() {
                    return this.currentPage;
                }, 
                set: function(val) {
                    this.currentPage = val;
                }
            }
        },
        methods: {
            reset: function() {
                this.setShowingChineseWords();
                this.setCurrentPage();
                this.isAll = false;
            },
            setShowingChineseWords: function(){
                this.getShowingChineseWords =  Object.assign([], this.chineseWords);
                this.getShowingChineseWords.forEach(element => {
                    element["number"] = this.randomIntFromInterval(1, 10000);
                });
                this.getShowingChineseWords = this.getShowingChineseWords.sort(function(a,b) {
                    return a.number - b.number
                })
            },
            checkIsCorrect(checkedItem) {
                this.lastSelected = this.chineseWords.find(item => item.chineseWord == checkedItem.word);
                this.showLastSelected = true;
                if(checkedItem.isCorrect) {
                    checkedItem.class = "green"
                    setTimeout(() => {
                        this.getShowingChineseWords.splice(0,1);
                        this.setCurrentPage();
                    }
                     ,1000);
                    
                }
                else{
                    checkedItem.class = "red"
                }
            },
            randomIntFromInterval(min, max) {
                return Math.floor(Math.random() * (max - min + 1) + min)
            },
            setCurrentPage: function() {
                if(this.getShowingChineseWords.length == 0) {
                    this.isAll = true;
                    this.showLastSelected = false;
                    return;
                }
                this.currentPage = [];
                this.currentPage.push( {
                    word: this.getShowingChineseWords[0].chineseWord,
                    isCorrect: true,
                    orderNumber: this.randomIntFromInterval(1, 1000),
                    class: ""
                });
                for(let i = 1; i < 4; i++) {
                    let randomNumber = this.randomIntFromInterval(0, this.chineseWords.length - 1);
                    while(true) {
                        if(this.currentPage.find(item => item.word == this.chineseWords[randomNumber].chineseWord) != null) {
                            randomNumber = this.randomIntFromInterval(0, this.chineseWords.length - 1);
                        }
                        else {
                            break;
                        }
                    };
                    this.currentPage.push({
                        word: this.chineseWords[randomNumber].chineseWord,
                        isCorrect: false,
                        orderNumber: this.randomIntFromInterval(1, 1000),
                        class: ""
                    })
                }
                this.currentPage = this.currentPage.sort(function(a,b) {
                    return a.orderNumber - b.orderNumber
                })
            },
            nextStep: function () {
                this.numberStep++;
                if (this.numberStep == 1) {
                    this.getChineseWords();
                }
                if (this.numberStep > 1) {
                    this.numberStep = 0;
                }
            },
            getChineseWords: function () {
                axios
                    .post("/ChineseWords/getWordsByGroup", {
                        GroupId: this.selectedGroupId
                    })
                    .then(response => {
                        this.chineseWords = response.data.chineseWords;
                        this.setShowingChineseWords();
                        this.setCurrentPage();
                    })
            },
            getGroupIds: function () {
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
        }
    }
</script>
<style scoped>
.bn{
    width: 100px;
    margin: 10px;
}
    .cards-container{
        width: 100%;
        height: 80%;
        float: left;
    }
    label{
        font-size: 200%
    }
    .card-item {
        width: 45%;
        height: 45%;
        background-color: rgb(184, 184, 184);
        float:left;
        color: black;
        margin:10px;
        border: 1px;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 200%
    }
    .green {
        background-color: rgba(8, 255, 8, 0.603);
    }
    .red {
        background-color: rgba(255, 0, 0, 0.397);
    }
</style>