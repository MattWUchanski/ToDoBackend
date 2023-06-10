<template>
  <div class="container">
    <div class="tick" 
         :class="{ 
                    'active-blue': mode === 'blue', 
                    'active-green': mode === 'green', 
                    'active-grey': isChecked 
                  }"
    >
      <input type="checkbox" v-model="isChecked" />
      <!--<label :style="{ color: isChecked ? '#a6a6a6' : '' }">{{ task.hour }}</label>tu docelowo będzie jeszcze godzina wyświetlana z bazy danych-->
      <label :style="{ color: isChecked ? '#a6a6a6' : '' }">{{ task.content }}</label>
      <div class="star-wrapper">
        <label class="star-label">
          <i class="fa-solid fa-star" :style="{ color: isChecked ? '#a6a6a6' : '#FF9900' }"></i>
        </label>
        <router-link to="/edit-task">
          <i class="fa-regular fa-pen-to-square" style="color: #8C8C8C; margin-left: 5px;"></i>
        </router-link>
        <i class="fa-solid fa-trash" style="color: #8C8C8C; margin-left: 7px;"></i>
      </div>
    </div>
    <Line />
  </div>
</template>
  
  <script>
  import { mapState } from 'vuex';
import Line from './Line.vue';
  export default {
    components: {
      Line,
    },
    props: {
      task: {
        type: Object,
        required: true
      }
    },
    computed: {
    ...mapState(['mode'])
    },
    data() {
    return {
      isChecked: false,
    };
  },
  }
  </script>
  
  <style scoped>
    .active-grey {
      color: #a6a6a6;
    }
  </style>
  