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
        </tr>
      </tbody>
    </table>
</template>

<script>
  import axios from 'axios';
  export default {
    name: 'HomePage',
    data() {
      return {
          chineseWords: [],
      }
    },
    computed: {
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
      getWords: async function () {
        await axios
            .post("/ChineseWords/getAllWords", { UserName: "1"})
            .then(response => {
                this.getChineseWords = response.data.chineseWords;
                console.log(response, "resp")
            })
            .catch(function (error) {
                console.log(error)
            });
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
