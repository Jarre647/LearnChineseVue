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
      </thead>
      <tbody>
        
        <tr v-for="item, index in getChineseWords" :key="item.id">
          <th scope="row">{{ index }}</th>
          <td>{{ item.chineseWord }}</td>
          <td>{{ item.pinyin }}</td>
          <td>{{ item.tones }}</td>
          <td>{{ item.translation }}</td>
          <td>{{ item.groupId }}</td>
          <td><button @click="showOperatorModal(item.id)" >  Редактировать</button></td>
        </tr>
      </tbody>
    </table>
    <Teleport to="body">
      <!-- use the modal component, pass in the prop -->
      <EditWordModal ref="zalupa"
                     :show="showModal" 
                      @close="showModal = false"
                      :message ="message">
          <template #header>
              <h3>Редактировать</h3>
          </template>
      </EditWordModal>
    </Teleport>
</template>

<script>
  import axios from 'axios';
  import EditWordModal from './EditWordModal.vue'
  export default {
    components: {
      EditWordModal
    },
    name: 'HomePage',
    data() {
      return {
          chineseWords: [],
          message: {},
          showModal: false
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
      },
      getChineseWords: {
        get() {
          return this.chineseWords
        },
        set(val) {
          this.chineseWords = val
        }
      }
    },
    methods: {
      editValue: async function() {

      },
      getWords: async function () {
        await axios
            .post("/ChineseWords/getAllWords", {})
            .then(response => {
                this.getChineseWords = response.data.chineseWords;
            })
            .catch(function (error) {
                console.log(error)
            });
      },
      showOperatorModal: async function(data){
         // console.log(data,"data")
          this.message = await this.getChineseWords.find(item => item.id == data);
          this.showModal = true;
      }
    },
    created() {
      this.getWords();
    }    
  }
</script>

<style scoped>
    td{
        padding:5px;
        border-bottom:solid;
    }
</style>
