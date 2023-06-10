<template>
    <div>
      <CloseNavbar :mode="mode" />

      <div class="container">
        <div class="opcje">
          
          <div class="tryb-zielony">
            <a href="#" class="tryb-zielony1" 
              :class="mode === 'green' ? 'green-text' : 'inactive-text'" 
              @click="changeGreen">Tryb zielony</a>
            <i :class="mode === 'green' ? 'fa-solid fa-check float-right green-icons' : 'fa-solid fa-xmark float-right inactive-icons'"></i>
            <Line />
          </div>

          <div class="tryb-niebieski">
            <a href="#" class="tryb-niebieski1" 
              :class="mode === 'blue' ? 'blue-text' : 'inactive-text'" 
              @click="changeBlue">Tryb niebieski</a>
            <i :class="mode === 'blue' ? 'fa-solid fa-check float-right blue-icons' : 'fa-solid fa-xmark float-right inactive-icons'"></i>
            <Line />
          </div>
              
          <HelpOption :mode="mode" />

          <LogoutOption :mode="mode" />

        </div>
      </div> 
    </div> 
</template>


<script>
  import LogoutOption from '../components/LogoutOption.vue';
  import HelpOption from '../components/HelpOption.vue';
  import CloseNavbar from '../components/CloseNavbar.vue'
  import Line from '../components/Line.vue';
  import { mapMutations, mapState } from 'vuex';

  export default {
      components: {
        LogoutOption,
        HelpOption,
        CloseNavbar,
        Line
      },
      computed: {
    // użyj funkcji mapState, aby pobierać wartość 'mode' z Vuex store
    ...mapState(['mode'])
  },
  methods: {
    ...mapMutations(['setMode']), // dodaj mapMutations do methods
    changeGreen() {
      this.setMode("green"); // użyj mutacji setMode zamiast bezpośrednio zmieniać this.mode
      localStorage.setItem("mode", "green");
    },
    changeBlue() {
      this.setMode("blue"); // użyj mutacji setMode zamiast bezpośrednio zmieniać this.mode
      localStorage.setItem("mode", "blue");
    }
  }
  };
</script>

<style scoped>
  .tryb-zielony, .tryb-niebieski {
    padding: 1%;
  }
  .tryb-zielony1 {
    color: #009900;
    text-align: center;
    font-size: 150%;
  }
  .tryb-niebieski1 {
    color: #A6A6A6;        ;
    text-align: center;
    font-size: 150%;
  }
  .opcje {
    padding-top: 7%;
    padding-bottom: 5%;
    padding-left: 20%;
    padding-right: 20%;
  }
  .fa-check {
    color:#009900;
    font-size: 150%;
  }
  .fa-xmark {
    color: #A6A6A6;
    font-size: 150%;
  }
  .float-right {
    float: right;
  }
  .tryb-zielony1:hover, .tryb-niebieski1:hover {
    text-decoration: none;
  }
  .green {
    background-color: #009900;
  }
  .blue {
    background-color: #0099FF;
  }
  .green-text {
    color: #009900;
  }
  .blue-text {
    color: #0099FF;
  }
  .green-icons {
    color: #009900;
  }
  .blue-icons {
    color: #0099FF;
  }
  .inactive-text {
    color: #A6A6A6;
  }
</style>
