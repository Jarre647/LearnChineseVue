<template>
    <div>
            <h1>Добавить слово</h1> 
            <div class="input-group mb-3">
                <span class="input-group-text" id="inputGroup-sizing-default">Иероглиф</span>
                <input type="text" 
                       class="form-control" 
                       aria-label="Sizing example input" 
                       aria-describedby="inputGroup-sizing-default" 
                       placeholder="我 (китайский иероглиф)" 
                       v-model="hieroglyph"/>                
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="inputGroup-sizing-default">Перевод&nbsp;&nbsp;</span>
                <input type="text" 
                       class="form-control" 
                       aria-label="Sizing example input" 
                       aria-describedby="inputGroup-sizing-default" 
                       placeholder="Я (перевод)"
                       v-model="translate"/>
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="inputGroup-sizing-default">Пиньинь&nbsp;&nbsp;</span>
                <input type="text" 
                       class="form-control" 
                       aria-label="Sizing example input" 
                       aria-describedby="inputGroup-sizing-default" 
                       placeholder="wo (без тонов тут)"
                       v-model="pinyin"/>   
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="inputGroup-sizing-default">Тоны&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                <input type="text" 
                       class="form-control" 
                       aria-label="Sizing example input" 
                       aria-describedby="inputGroup-sizing-default" 
                       placeholder="3 (тоны цифрами по порядку)"
                       v-model="tones"/>   
            </div>
          <button className="btn btn-primary" v-on:click="save">Добавить</button>
          <button className="btn btn-primary" v-on:click="reset">Очистить</button>
        </div>
</template>
<script>
    import axios from 'axios';
    export default{ 
        name: "AddWordInDictionary",
        data() {
            return {
                hieroglyph: "",
                translate: "",
                pinyin: "",
                tones: 0
            }
        },
        methods: {
            save: function() {
                axios
                    .post("/ChineseWords/AddChineseWordInDictionary", {
                        ChineseWord: this.hieroglyph,
                        Translation: this.translate,
                        Tones: parseInt(this.tones),
                        Pinyin: this.pinyin
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
            reset: function () {
                this.hieroglyph = "",
                this.translate =  "",
                this.pinyin = "",
                this.tones = 0
            }
        }        
    }    
</script>
<styles>
</styles>