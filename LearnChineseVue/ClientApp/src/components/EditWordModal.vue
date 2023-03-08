<template>
    <Transition name="modal">
      <div v-if="getShow" class="modal-mask">
        <div class="modal-container">
          <div class="modal-header">
            <slot name="header">default header</slot>
          </div>
  
          <div class="modal-body">
            <slot name="body">  
              <div class="input-group mb-3">
                <span class="input-group-text" id="inputGroup-sizing-default">Иероглиф</span>
                <input type="text" 
                       class="form-control" 
                       aria-label="Sizing example input" 
                       aria-describedby="inputGroup-sizing-default" 
                       placeholder="我 (китайский иероглиф)" 
                       v-model="model.chineseWord"/>                
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="inputGroup-sizing-default">Перевод&nbsp;&nbsp;</span>
                <input type="text" 
                       class="form-control" 
                       aria-label="Sizing example input" 
                       aria-describedby="inputGroup-sizing-default" 
                       placeholder="Я (перевод)"
                       v-model="model.translation"/>
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="inputGroup-sizing-default">Пиньинь&nbsp;&nbsp;</span>
                <input type="text" 
                       class="form-control" 
                       aria-label="Sizing example input" 
                       aria-describedby="inputGroup-sizing-default" 
                       placeholder="wo (без тонов тут)"
                       v-model="model.pinyin"/>   
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="inputGroup-sizing-default">Тоны&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                <input type="text" 
                       class="form-control" 
                       aria-label="Sizing example input" 
                       aria-describedby="inputGroup-sizing-default" 
                       placeholder="3 (тоны цифрами по порядку)"
                       v-model="model.tones"/>   
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="inputGroup-sizing-default">Группа&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                <input type="text" 
                       class="form-control" 
                       aria-label="Sizing example input" 
                       aria-describedby="inputGroup-sizing-default" 
                       placeholder="1 (пока группирую слова по группам, что бы потом показывать)"
                       v-model="groupId"/>   
            </div>
          <button className="btn btn-primary" v-on:click="save()">Сохранить</button>

            </slot>
          </div>
  
          <div class="modal-footer">
            <slot name="footer">
              <button
                class="modal-default-button btn btn-primary"
                @click="$emit('close')"
              >Закрыть</button>
            </slot>
          </div>
        </div>
      </div>
    </Transition>
  </template>
  
  <script>
    /* eslint-disable */ 
  import axios from 'axios';
  /* eslint-disable */ 
  export default {
    name:"zalupa",
    props: {
      show: Boolean,
      message: Object,
      footerMessage: Text
    },
    data() {
      return {
        model: {},
        groupId: 0
      }
    },
    methods: {           
      save: function() {
        axios
          .post("/ChineseWords/UpdateChineseWord", {
            Id: this.model.id,
            ChineseWord: this.model.chineseWord,
            Translation: this.model.translation,
            Tones: this.model.tones,
            Pinyin: this.model.pinyin,
            GroupId: this.groupId
          })
          .then(response => {
              console.log(response)
          })
          .catch(function (error) {
              alert(error)
              //todo допилить обработку ошибок
              console.log(error)
          });
      },
      getZalupa: async function(id)
      {
        await axios
            .post("/ChineseWords/getWordById", { Id: id})
            .then(response => {
                this.model = response.data.chineseWord;
            })
            .catch(function (error) {
                console.log(error)
            });
      }
    },
    computed: {
      getShow: {
        get() {
          if(this.show)
          {
            this.getZalupa(this.message.id)
          }
          return this.show;
        },

      },
      getModel: {
        get: function() {
          return this.model;
        },
        set: function (val) {
          this.model = val;
        }
      }
    }
  }
  </script>
  
  <style scoped>
  .modal-mask {
    position: fixed;
    z-index: 9998;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    display: flex;
    transition: opacity 0.3s ease;
  }
  
  .modal-container {
    width: 300px;
    margin: auto;
    padding: 20px 30px;
    background-color: #fff;
    border-radius: 2px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
    transition: all 0.3s ease;
  }
  
  .modal-header h3 {
    margin-top: 0;
    color: #42b983;
  }
  
  .modal-body {
    margin: 20px 0;
  }
  
  .modal-default-button {
    float: right;
  }
  
  /*
   * The following styles are auto-applied to elements with
   * transition="modal" when their visibility is toggled
   * by Vue.js.
   *
   * You can easily play with the modal transition by editing
   * these styles.
   */
  
  .modal-enter-from {
    opacity: 0;
  }
  
  .modal-leave-to {
    opacity: 0;
  }
  
  .modal-enter-from .modal-container,
  .modal-leave-to .modal-container {
    -webkit-transform: scale(1.1);
    transform: scale(1.1);
  }
  </style>