<template>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Иероглиф</th>
                <th scope="col">Пиньинь</th>
                <th scope="col">Тоны</th>
                <th scope="col">Перевод</th>
                <th scope="col">Группа</th>
                <th scope="col">Редактировать</th>
            </tr>
            <tr>
                <th scope="col">
                </th>
                <th scope="col">
                    <div class="input-group mb-1">
                        <input type="text"
                               class="form-control"
                               aria-label="Sizing example input"
                               aria-describedby="inputGroup-sizing-default"
                               placeholder="Иероглиф"
                               v-model="chineseWord" />
                    </div>
                </th>
                <th scope="col">
                    <div class="input-group mb-1">
                        <input type="text"
                               class="form-control"
                               aria-label="Sizing example input"
                               aria-describedby="inputGroup-sizing-default"
                               placeholder="Пиньинь"
                               v-model="pinyin" />
                    </div>
                </th>
                <th scope="col">
                    <div class="input-group mb-1">
                        <input type="text"
                               class="form-control"
                               aria-label="Sizing example input"
                               aria-describedby="inputGroup-sizing-default"
                               placeholder="Тоны"
                               v-model="tones" />
                    </div>
                </th>
                <th scope="col">
                    <div class="input-group mb-1">
                        <input type="text"
                               class="form-control"
                               aria-label="Sizing example input"
                               aria-describedby="inputGroup-sizing-default"
                               placeholder="Перевод"
                               v-model="translation" />
                    </div>
                </th>
                <th scope="col">
                    <div class="input-group mb-1">
                        <input type="text"
                               class="form-control"
                               aria-label="Sizing example input"
                               aria-describedby="inputGroup-sizing-default"
                               placeholder="Группа"
                               v-model="groupId" />
                    </div>
                </th>
                <th scope="col">
                  <button @click="clearFilters()">Очистить фильтры</button>
                </th>
            </tr>
        </thead>
        <tbody>          
            <tr v-for="item, index in getChineseWords()" :key="item.id">
                <th scope="row">{{ index }}</th>
                <td>{{ item.chineseWord }}</td>
                <td>{{ item.pinyin }}</td>
                <td>{{ item.tones }}</td>
                <td>{{ item.translation }}</td>
                <td>{{ item.groupId }}</td>
                <td><button @click="showOperatorModal(item.id)">  Редактировать</button></td>
            </tr>
        </tbody>
    </table>
    <Teleport to="body">
        <ErrorModal :show="showModalError"
                    @close="closeErrorModal()"
                    :message="errorMessage">

        </ErrorModal>
        <!-- use the modal component, pass in the prop -->
        <EditWordModal ref="zalupa"
                       :show="showModal"
                       @close="closeModal"
                       :message="message">
            <template #header>
                <h3>Редактировать</h3>
            </template>
        </EditWordModal>
    </Teleport>
</template>

<script>
  import axios from 'axios';
  import EditWordModal from './EditWordModal.vue'
  import ErrorModal from './Errors/ErrorModal.vue';
  export default {
    components: {
      EditWordModal,
      ErrorModal
    },
    name: 'HomePage',
    data() {
      return {
          chineseWord: "",
          pinyin: "",
          tones: "",
          translation: "",
          groupId: "",
          chineseWords: [],
          message: {},
          showModal: false,
          showModalError: false,
          errorMessage: "",
          errored: false
      }
    },
    computed: {
      getChlen: {
        get: function () {
          return this.chlen
        },
        set:function (val)
        {
          this.chlen = val
        }
      }
    },
    methods: {
      closeModal: async function () {
        this.showModal = false;
        await this.getWords();
      },
      closeErrorModal: function() {
        this.errorMessage = "";
        this.showModalError = false;
      },
      openErrorModal: function(err) {
         this.errorMessage = err;
         this.showModalError = true;
      },
      clearFilters: function() {
          this.chineseWord = "";
          this.pinyin = "";
          this.tones = "";
          this.translation = "";
          this.groupId = "";
      },
      getChineseWords: function() {
        let data = this.chineseWords;
        if(this.chineseWord.length > 0)
          data = data.filter(item=> item.chineseWord.includes(this.chineseWord));
        if(this.pinyin.length > 0)
          data = data.filter(item=> item.pinyin.includes(this.pinyin));
        if(this.tones.length > 0)
          data = data.filter(item=> item.tonesincludes(this.tones));
        if(this.translation.length > 0)
          data = data.filter(item=> item.translation.includes(this.translation));
        if(this.groupId.length > 0)
          data = data.filter(item=> item.groupId.includes(this.groupId));
        return data;
      },
      editValue: async function() {

      },
      getWords: async function () {
        await axios
            .post("/ChineseWords/getAllWords", {})
            .then(response => {
                this.chineseWords = response.data.chineseWords;
            })
            .catch(error => {
                this.openErrorModal(error.message)
            });
      },
      showOperatorModal: async function(data){
         // console.log(data,"data")
          this.message = this.chineseWords.find(item => item.id == data);
          this.showModal = true;
      }
    },
    created() {
      this.getWords();
    }
  }
</script>

<style scoped>
    td {
        padding: 5px;
        border-bottom: solid;
    }
</style>
