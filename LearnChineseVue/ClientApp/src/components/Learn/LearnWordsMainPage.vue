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
        <swiper :pagination="{
                    clickable: true,
                }"
                :loop="true"
                :navigation="true"
                :modules="modules"
                class="mySwiper ">

            <swiper-slide v-for="item, index in chineseWords" :key="index">
                <v-lazy>
                    <div class="swiper-block">
                        {{ item.translation }}
                    </div>
                    <div v-if="showHelpNumber">
                        <p>
                            {{ item.chineseWord }}
                        </p>
                        <p>
                            {{ item.pinyin }}
                        </p>
                        <p>
                            {{ item.tones }}
                        </p>
                    </div>
                </v-lazy>
            </swiper-slide>
        </swiper>
        <!-- <div>
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
        </div> -->
        <button className="btn btn-primary word-button" v-on:click="showHelp" v-if="numberStep == 1">Показывать подсказку</button>
        <button className="btn btn-primary word-button" v-on:click="nextStep" v-if="numberStep == 0">Дальше</button>
        <button className="btn btn-primary word-button" v-on:click="prevStep" v-if="numberStep == 1">Вернуться</button>
        <!-- <button className="btn btn-primary word-button" v-on:click="continueLearn" v-if="numberStep == 1">Сохранить</button> -->
    </div>
</template>
<script>
    import axios from 'axios';
    import { Swiper, SwiperSlide } from 'swiper/vue';
    import { Navigation } from 'swiper/modules';
    import 'swiper/css';
    import 'swiper/css/pagination';
    import 'swiper/css/navigation';
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
        components: {
            Swiper,
            SwiperSlide,
        },
        setup() {
            return {
                modules: [Navigation],
            };
        },
        methods: {
            continueLearn: function () {
                this.selectedGroupId = this.getCookie("selected-group");
                this.Swiper.slideTo(3, 1, false)
            },
            getActiveIndex: function (swiper) {
                console.log(swiper, "zalupa")
                return swiper.activeIndex
            },
            getCookie: function (name) {
                let matches = document.cookie.match(new RegExp(
                    //впадлу разбираться
                    // eslint-disable-next-line
                    "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
                ));
                return matches ? decodeURIComponent(matches[1]) : undefined;
            },
            save: function () {
                document.cookie = "zalupa=chlen";
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
            showHelp: function () {
                this.showHelpNumber = !this.showHelpNumber;
            },
            nextWord: function () {
                if (this.showNumberWord < this.chineseWords.length - 1) {
                    this.showNumberWord++;
                    //this.showHelpNumber = false;
                }
                else {
                    this.showNumberWord = 0;
                }
            },
            prevWord: function () {
                if (this.showNumberWord - 1 > 0) {
                    this.showNumberWord--;
                    this.showHelpNumber = false;
                }
                else {
                    this.showNumberWord = this.chineseWords.length - 1;
                }
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
            prevStep: function () {
                this.numberStep--;
            },
            getChineseWords: function () {
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
            mySwiper: () => {
                return this.$refs.mySwiper.swiper
            }
        },
        created() {
            this.getGroupIds()
        },
    }
</script>
<style scoped>
    p {
        font-size:large
    }
    .swiper-test {
        width: 100%;
        height: 700px;
    }

    .word-button {
        margin: 10px;
    }

    .swiper-block {
        display: flex;
        align-items: center;
        justify-content: center;
        height: 80%;
        font-size: 4em;
    }

    .label-block {
        display: block;
        display: flex;
        align-items: center;
        justify-content: center;
        float: left;
        width: 100%;
        height: 100px;
        font-size: 2em;
    }

    .group {
        float: left;
        display: flex;
        align-items: center;
        justify-content: center;
        margin: auto;
        width: 70%;
        margin: 15px;
    }

    .button-block {
        float: left;
        display: flex;
        align-items: center;
        justify-content: center;
        height: 80%;
        font-size: 20em;
        margin: 15px;
    }
</style>